using Microsoft.EntityFrameworkCore;
using WebAPIEstatusAlumnos.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Agregar esto para los permisos
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:53357").AllowAnyMethod().AllowAnyHeader();
                      });
});

// Agregar referencia para la base de datos
var conectionstring = builder.Configuration.GetConnectionString("InstitutoTich");
builder.Services.AddDbContext<EstatusContext>(x => x.UseSqlServer(conectionstring));

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

// Habilitar servicio importante
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();