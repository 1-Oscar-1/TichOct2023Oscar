-- Consulta 1

SELECT *
FROM Alumnos
WHERE primerApellido = 'Mendoza'

-- Consulta 2

SELECT *
FROM Alumnos
	INNER JOIN EstatusAlumnos
ON EstatusAlumnos.id = Alumnos.idEstatus
WHERE EstatusAlumnos.nombre LIKE '%capaci%'

-- Consulta 3

SELECT *
FROM Instructores
WHERE DATEDIFF(YEAR, fechaNacimiento, GETDATE()) > 30

-- Consulta 4

SELECT *
FROM Alumnos
WHERE DATEDIFF(YEAR, fechaNacimiento, GETDATE()) BETWEEN 20 AND 25

-- Consulta 5

SELECT *
FROM Alumnos
	INNER JOIN Estados
ON Estados.id = Alumnos.idEstadoOrigen
	INNER JOIN EstatusAlumnos
ON EstatusAlumnos.id = Alumnos.idEstatus
WHERE Estados.nombre = 'Oaxaca' AND EstatusAlumnos.nombre LIKE '%capaci%' OR Estados.nombre = 'Campeche' AND EstatusAlumnos.nombre LIKE '%prospec%'

-- Consulta 6

SELECT *
FROM Alumnos
WHERE correo LIKE '%gmail%'

-- Consulta 7

SELECT *
FROM Alumnos
WHERE fechaNacimiento LIKE '%-03-%'

-- Consulta 8

SELECT *
FROM Alumnos
WHERE DATEDIFF(YEAR,fechaNacimiento,DATEADD(YEAR,5,GETDATE())) >= 30

-- Consulta 9

SELECT *
FROM Alumnos
WHERE nombre LIKE '__________%'

-- Consulta 10

SELECT *
FROM Alumnos
WHERE curp LIKE '%[0-9]'

-- Consulta 11

SELECT *
FROM Alumnos
	INNER JOIN CursosAlumnos
ON Alumnos.id = CursosAlumnos.idAlumno
WHERE calificacion > 8

-- Consulta 12

SELECT *
FROM Alumnos
	INNER JOIN EstatusAlumnos
ON Alumnos.idEstatus = EstatusAlumnos.id
WHERE Alumnos.sueldo > 15000 AND EstatusAlumnos.nombre IN ('laborando', 'en capacitacion')

-- Consulta 13

SELECT *
FROM Alumnos
WHERE YEAR(fechaNacimiento) BETWEEN 1990 AND 1995 AND primerApellido LIKE '[B,C,Z]%'

-- Consulta 14

SELECT nombre, curp, fechaNacimiento
FROM Alumnos
WHERE SUBSTRING(REPLACE(CONVERT(varchar, fechaNacimiento, 102), '.', '-'), 3, 8) != CONCAT(SUBSTRING(curp, 5, 2),'-',SUBSTRING(curp, 7, 2),'-',SUBSTRING(curp, 9, 2))

-- Consulta 15

SELECT *
FROM Alumnos
WHERE primerApellido LIKE 'A%' AND fechaNacimiento LIKE '%-04-%' AND DATEDIFF(YEAR,fechaNacimiento,GETDATE()) BETWEEN 21 AND 30

-- Consulta 16

SELECT *
FROM Alumnos
WHERE nombre LIKE '%Luis%'

-- Consulta 17

SELECT CatCursos.nombre AS 'Curso', Cursos.fechaInicio, Cursos.fechaTermino, COUNT(CursosAlumnos.idAlumno) AS 'Cantidad de alumnos', AVG(CursosAlumnos.calificacion) AS 'Promedio de calificaciones'
FROM CatCursos
	INNER JOIN Cursos
ON Cursos.idCatCurso = CatCursos.id
	INNER JOIN CursosAlumnos
ON CursosAlumnos.idCurso = Cursos.id
WHERE YEAR(Cursos.fechaInicio) = 2021
GROUP BY CatCursos.nombre, Cursos.fechaInicio, Cursos.fechaTermino

-- Consulta 18

SELECT Estados.nombre, COUNT(CursosAlumnos.idAlumno) AS 'Total', AVG(CursosAlumnos.calificacion) AS 'Promedio', AVG(Alumnos.sueldo) AS 'Prom Sueldo'
FROM Alumnos
	INNER JOIN Estados
ON Alumnos.idEstadoOrigen = Estados.id
	INNER JOIN CursosAlumnos
ON CursosAlumnos.idAlumno = Alumnos.id
WHERE CursosAlumnos.calificacion > 6
GROUP BY Estados.nombre
HAVING COUNT(CursosAlumnos.idAlumno) > 1