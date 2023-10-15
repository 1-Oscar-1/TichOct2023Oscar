-- Consulta por estados

SELECT Estados.nombre, COUNT(CursosAlumnos.idAlumno) AS Total
FROM Alumnos
	INNER JOIN Estados
ON Alumnos.idEstadoOrigen = Estados.id
	INNER JOIN CursosAlumnos
ON Alumnos.id = CursosAlumnos.idAlumno 
GROUP BY Estados.nombre
ORDER BY Estados.nombre

-- Consulta por estatus

SELECT EstatusAlumnos.nombre, COUNT(Alumnos.id) AS Total
FROM Alumnos
	INNER JOIN EstatusAlumnos
ON Alumnos.idEstatus = EstatusAlumnos.id
GROUP BY EstatusAlumnos.nombre
ORDER BY EstatusAlumnos.nombre

-- Consulta calificaciones

SELECT 'Calificacion Alumnos' AS 'Resumen Calificaciones', COUNT(Alumnos.id) AS 'Total', MAX(CursosAlumnos.calificacion) AS 'Maxima', MIN(CursosAlumnos.calificacion) AS 'Minima', AVG(CursosAlumnos.calificacion) AS 'Promedio'
FROM CursosAlumnos
	INNER JOIN Alumnos
ON Alumnos.id = CursosAlumnos.idAlumno

-- Consulta calificaciones por curso

SELECT CatCursos.nombre AS 'Curso', Cursos.fechaInicio, Cursos.fechaTermino, COUNT(Alumnos.id) AS 'Total', MAX(CursosAlumnos.calificacion) AS 'Maxima', MIN(CursosAlumnos.calificacion) AS 'Minima', AVG(CursosAlumnos.calificacion) AS 'Promedio'
FROM CursosAlumnos
	INNER JOIN Alumnos
ON Alumnos.id = CursosAlumnos.idAlumno
	INNER JOIN Cursos
ON Cursos.id = CursosAlumnos.idCurso
	INNER JOIN CatCursos
ON Cursos.idCatCurso = CatCursos.id
GROUP BY CatCursos.nombre, Cursos.fechaInicio, Cursos.fechaTermino

-- Consulta calificaciones por estado promedio mayor a 6
SELECT Estados.nombre, COUNT(Alumnos.id) AS 'Total', MAX(CursosAlumnos.calificacion) AS 'Maxima', MIN(CursosAlumnos.calificacion) AS 'Minima', AVG(CursosAlumnos.calificacion) AS 'Promedio'
FROM CursosAlumnos
	INNER JOIN Alumnos
ON Alumnos.id = CursosAlumnos.idAlumno
	INNER JOIN Estados
ON Alumnos.idEstadoOrigen = Estados.id
GROUP BY Estados.nombre
HAVING AVG(CursosAlumnos.calificacion) > 6