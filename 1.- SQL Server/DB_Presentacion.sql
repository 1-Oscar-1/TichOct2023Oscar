create database SistemaInventario 

use SistemaInventario

create table usuarios (
id_us int primary key identity(1,1),
nombre varchar(50),
apellidoPaterno  varchar(50),
apellidoMaterno varchar(50),
email varchar(50),
clave varchar(50)
)

create table productos (
id_prod int primary key identity(1,1),
nombre_prod varchar(200),
descripcion_prod varchar(1000),
costo_prod decimal(9,2),
existencias_total int,
importe decimal(9,2)
)

create table inventarioBodega (
id_inbod int primary key identity(1,1),
id_prod int,
desc_prod varchar(100),
lote varchar(100),
entradas int,
salidas int,
stock int,
costo_prod decimal(9,2),
importe decimal(9,2)
)

create table distribuidor(
id_dis int primary key identity(1,1),
nombre_dis varchar(100)
)

create table inventariodistribuidor(
id_indis int primary key identity(1,1),
id_dis int,
id_prod int,
nombre_prod varchar(50),
desc_prod varchar(50),
lote varchar(50),
entradas int,
salidas int,
stock int,
costo_prod decimal(9,2),
importe decimal(9,2)
)