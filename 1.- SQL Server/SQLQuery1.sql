-- Se crea la base de datos
CREATE DATABASE EjerciciosTich

-- Se usa la DB
use EjerciciosTich

-- Se crean las tablas
CREATE TABLE CursosInstructores (
id INT PRIMARY KEY IDENTITY(1,1),
idCurso SMALLINT,
idInstructor INT,
fechaContratacion DATE NULL
)

CREATE TABLE AlumnosBaja (
id INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(60),
primerApellido VARCHAR(50),
segundoApellido VARCHAR(50),
fechaBaja DATETIME
)