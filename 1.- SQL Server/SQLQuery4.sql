SELECT TOP(6) primerApellido AS 'Apellido Paterno', segundoApellido AS 'Apellido Materno', nombre, telefono, correo FROM Alumnos

SELECT nombre, primerApellido AS 'Apellido Paterno', segundoApellido AS 'Apellido Materno', rfc, cuotaHora AS 'Cuota por Hora' FROM Instructores

SELECT clave, nombre, descripcion, horas FROM CatCursos

SELECT TOP 5 * FROM Alumnos ORDER BY fechaNacimiento DESC

CREATE DATABASE Ejercicios

use EjerciciosTich

SELECT * INTO Alumnos  FROM EjerciciosTich.dbo.Alumnos
SELECT * INTO Instructores FROM EjerciciosTich.dbo.Instructores