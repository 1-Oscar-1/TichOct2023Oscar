-- Consulta Union

SELECT 'Alumno' AS TipoPersona, nombre, primerApellido, segundoApellido, SUBSTRING(CONVERT(varchar, fechaNacimiento, 102),6,2) AS MesNacimiento, SUBSTRING(CONVERT(varchar,fechaNacimiento,102),9,2) AS DiaNacimiento
FROM Alumnos
UNION
SELECT 'Profesor' AS TipoPersona, nombre, primerApellido, segundoApellido, SUBSTRING(CONVERT(varchar, fechaNacimiento, 102),6,2) AS MesNacimiento, SUBSTRING(CONVERT(varchar,fechaNacimiento,102),9,2) AS DiaNacimiento
FROM Instructores

-- Consulta 1

SELECT Alumnos.nombre, EstatusAlumnos.nombre
FROM Alumnos
	INNER JOIN EstatusAlumnos
ON EstatusAlumnos.id = Alumnos.idEstatus

UPDATE Alumnos
SET idEstatus = 3
WHERE Alumnos.idEstatus = 2

-- Consulta 2

UPDATE Alumnos
SET segundoApellido = UPPER(segundoApellido)

--Consulta 3

UPDATE Alumnos
SET segundoApellido = STUFF(LOWER(segundoApellido),1,1,UPPER(LEFT(segundoApellido,1)))

-- Consulta 4

UPDATE Instructores
SET telefono = STUFF(telefono,1,2,'55')
WHERE SUBSTRING(curp,12,2) = 'DF'

-- Consulta 5

SELECT Alumnos.nombre, CursosAlumnos.calificacion, Estados.nombre, Cursos.fechaInicio
FROM Alumnos
	INNER JOIN CursosAlumnos
ON CursosAlumnos.idAlumno = Alumnos.id
	INNER JOIN Estados
ON Estados.id = Alumnos.idEstadoOrigen
	INNER JOIN Cursos
ON Cursos.id = CursosAlumnos.idCurso

UPDATE CursosAlumnos
SET calificacion = calificacion + 1
FROM CursosAlumnos
	INNER JOIN Alumnos
ON Alumnos.id = CursosAlumnos.idAlumno
	INNER JOIN Cursos
ON Cursos.id = CursosAlumnos.idCurso
WHERE Alumnos.idEstadoOrigen IN (12,19) AND fechaInicio BETWEEN CONVERT(date,'2021-06-01') AND CONVERT(date,'2021-06-30') AND CursosAlumnos.calificacion < 10


-- Consulta 6

SELECT Instructores.nombre, CatCursos.nombre, Instructores.cuotaHora, Cursos.id
FROM CursosInstructores
	INNER JOIN Instructores
ON Instructores.id = CursosInstructores.idInstructor
	INNER JOIN Cursos
ON Cursos.id = CursosInstructores.idCurso
	INNER JOIN CatCursos
ON CatCursos.id = Cursos.idCatCurso
ORDER BY CatCursos.nombre

UPDATE Ins
SET cuotaHora = cuotaHora + (cuotaHora * 0.1)
FROM Instructores Ins
	INNER JOIN CursosInstructores
ON CursosInstructores.idInstructor = Ins.id
	INNER JOIN Cursos
ON Cursos.id = CursosInstructores.idCurso
WHERE Cursos.id = 2

-- Consulta 7

use Ejercicios
SELECT * FROM Estados

-- A
SELECT *
INTO AlumnosTodos
FROM EjerciciosTich.dbo.Alumnos

-- B
SELECT *
INTO AlumnosHgo
FROM EjerciciosTich.dbo.Alumnos
WHERE Alumnos.idEstadoOrigen = 12

-- C
UPDATE AlumnosHgo
SET telefono = STUFF(telefono,1,2,77)

-- D
UPDATE AlumnosTodos
SET telefono = AlumnosHgo.telefono
FROM AlumnosTodos
	INNER JOIN AlumnosHgo
ON AlumnosTodos.id = AlumnosHgo.id

SELECT * FROM AlumnosTodos