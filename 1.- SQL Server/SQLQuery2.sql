-- Se crean las tablas

CREATE TABLE Estados (
id INT PRIMARY KEY,
nombre VARCHAR(100) NULL
)

CREATE TABLE EstatusAlumnos (
id SMALLINT PRIMARY KEY,
clave char(10),
nombre VARCHAR(100)
)

CREATE TABLE CatCursos (
id SMALLINT PRIMARY KEY IDENTITY(1,1),
clave VARCHAR(15),
nombre VARCHAR(50),
descripcion VARCHAR(1000) NULL,
horas TINYINT,
idPreRequisito SMALLINT NULL,
activo BIT
)

CREATE TABLE Cursos (
id SMALLINT PRIMARY KEY IDENTITY(1,1),
idCatCurso SMALLINT NULL,
fechaInicio DATE NULL,
fechaTermino DATE NULL,
activo BIT NULL
)

CREATE TABLE Alumnos (
id INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(60),
primerApellido VARCHAR(50),
segundoApellido VARCHAR(50) NULL,
correo VARCHAR(80),
telefono NCHAR(10),
fechaNacimiento DATE,
curp CHAR(18),
sueldo DECIMAL(9,2) NULL,
idEstadoOrigen INT,
idEstatus SMALLINT
)

CREATE TABLE Instructores (
id SMALLINT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(60),
primerApellido VARCHAR(50),
segundoApellido VARCHAR(50) NULL,
correo VARCHAR(80),
telefono NCHAR(10),
fechaNacimiento DATE,
rfc CHAR(13),
curp CHAR(18),
cuotaHora DECIMAL(9,2),
activo BIT
)

CREATE TABLE CursosAlumnos (
id INT PRIMARY KEY IDENTITY(1,1),
idCurso SMALLINT,
idAlumno INT,
fechaInscripcion DATE,
fechaBaja DATE NULL,
calificacion TINYINT NULL
)

CREATE TABLE CursosInstructores (
id INT PRIMARY KEY IDENTITY(1,1),
idCurso SMALLINT,
idInstructor SMALLINT,
fechaContratacion DATE NULL
)

CREATE TABLE AlumnosBaja (
id INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(60),
primerApellido VARCHAR(50),
segundoApellido VARCHAR(50),
fechaBaja DATETIME
)