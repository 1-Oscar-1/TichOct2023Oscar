-- Consulta alumnos
SELECT id, nombre, primerApellido, segundoApellido, fechaNacimiento, GETDATE() AS 'Hoy', DATEDIFF(YEAR,fechaNacimiento,GETDATE()) AS 'Edad', DATEDIFF(YEAR,fechaNacimiento,DATEADD(MONTH,5,GETDATE())) AS 'Edad en 5 meses' FROM Alumnos

-- Consulta mayusculas
SELECT id, UPPER(nombre) AS 'Nombre', upper(primerApellido) AS 'Apellido Paterno', upper(segundoApellido) AS 'Apellido Materno', fechaNacimiento, GETDATE() AS 'Hoy', DATEDIFF(YEAR,fechaNacimiento,GETDATE()) AS 'Edad', DATEDIFF(YEAR,fechaNacimiento,DATEADD(MONTH,5,GETDATE())) AS 'Edad en 5 meses' FROM Alumnos

-- Consulta CURP fecha
SELECT id, nombre, primerApellido, segundoApellido, fechaNacimiento, curp, CONCAT(SUBSTRING(curp,5,2),'-',SUBSTRING(curp,7,2),'-',SUBSTRING(curp,9,2)) AS 'Fecha CURP' FROM Alumnos

-- Consulta genero
SELECT id, nombre, primerApellido, segundoApellido, fechaNacimiento, curp, IIF(SUBSTRING(curp,11,1) = 'H', 'Hombre', 'Mujer') AS 'Genero' FROM Alumnos

--Consulta cambiar correo
SELECT id, nombre, primerApellido, segundoApellido, fechaNacimiento, correo, REPLACE(correo, 'gmail', 'hotmail') AS 'Correo hotmail' FROM Alumnos
