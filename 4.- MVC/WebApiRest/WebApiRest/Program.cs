using Microsoft.EntityFrameworkCore;
using WebApiRest.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Agregar referencia para la conexion a la base de datos
var conectionString = builder.Configuration.GetConnectionString("InstitutoTch");
builder.Services.AddDbContext<EstadosContext>(x => x.UseSqlServer(conectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
