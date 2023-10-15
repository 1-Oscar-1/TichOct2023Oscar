-- Consulta 1

SELECT nombre, LEN(nombre) AS 'Numero de Carcateres'
FROM Alumnos
WHERE LEN(NOMBRE) >= ALL (SELECT LEN(nombre) FROM Alumnos)

-- Consulta 2

SELECT *
FROM Alumnos
WHERE fechaNacimiento <= ALL (SELECT fechaNacimiento FROM Alumnos)

-- Consulta 3

SELECT Alumnos.nombre, Alumnos.primerApellido, Alumnos.segundoApellido, CatCursos.nombre, Cursos.fechaInicio, Cursos.fechaTermino, CursosAlumnos.calificacion
FROM Alumnos
	INNER JOIN CursosAlumnos
ON CursosAlumnos.idAlumno = Alumnos.id
	INNER JOIN Cursos
ON Cursos.id = CursosAlumnos.idCurso
	INNER JOIN CatCursos
ON CatCursos.id = Cursos.idCatCurso
WHERE CursosAlumnos.calificacion >= SOME (SELECT MAX(CursosAlumnos.calificacion) FROM CursosAlumnos)

-- Consulta 4

SELECT CatCursos.nombre, Cursos.fechaInicio, Cursos.fechaTermino, COUNT(CursosAlumnos.calificacion) AS 'Total', MAX(CursosAlumnos.calificacion) AS 'CalMax', MIN(CursosAlumnos.calificacion) AS 'CalMin', AVG(CursosAlumnos.calificacion) AS 'CalProm'
FROM CursosAlumnos
	INNER JOIN Cursos
ON Cursos.id = CursosAlumnos.idCurso
	INNER JOIN CatCursos
ON CatCursos.id = Cursos.idCatCurso
GROUP BY CatCursos.nombre, Cursos.fechaInicio, Cursos.fechaTermino

-- Consulta 5

SELECT Alumnos.nombre, CursosAlumnos.calificacion
FROM Alumnos
	INNER JOIN CursosAlumnos
ON CursosAlumnos.idAlumno = Alumnos.id
WHERE CursosAlumnos.calificacion <= SOME (SELECT AVG(calificacion) FROM CursosAlumnos)

-- Consulta 6

SELECT Alumnos.nombre, Alumnos.primerApellido, Alumnos.segundoApellido, fechaNacimiento, CalMax.nombre AS 'Curso', CalMax.fechaInicio, CalMax.fechaTermino, CalMax.calificacion
FROM CursosAlumnos
	INNER JOIN Alumnos
ON Alumnos.id = CursosAlumnos.idAlumno
	INNER JOIN(SELECT CatCursos.nombre, MAX(CursosAlumnos.calificacion) AS calificacion, Cursos.id, Cursos.fechaInicio, Cursos.fechaTermino
		FROM CursosAlumnos
			INNER JOIN Cursos
		ON Cursos.id = CursosAlumnos.idCurso
			INNER JOIN CatCursos
		ON CatCursos.id = Cursos.idCatCurso
		GROUP BY CatCursos.nombre, Cursos.id, Cursos.fechaInicio, Cursos.fechaTermino) AS CalMax
ON CalMax.id = CursosAlumnos.idCurso
WHERE CursosAlumnos.idCurso = CalMax.id AND CursosAlumnos.calificacion = CalMax.calificacion