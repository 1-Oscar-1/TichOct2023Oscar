use EjerciciosTich
-- Consulta de Instructores
SELECT nombre, primerApellido AS 'Apellido Paterno', segundoApellido AS 'Apellido Materno', rfc, cuotaHora AS 'Cuota por Hora', IIF(activo = 1, 'Activo', 'No Activo') AS 'Estatus' FROM Instructores

-- Consulta cursos
SELECT nombre AS 'Curso', horas, fechaInicio, fechaTermino FROM CatCursos INNER JOIN Cursos
ON CatCursos.id = Cursos.idCatCurso

-- Consulta alumnos
SELECT Alumnos.nombre, primerApellido, segundoApellido, curp, Estados.nombre AS 'Estado', EstatusAlumnos.nombre AS 'Estatus' FROM Alumnos 
	INNER JOIN Estados
ON Alumnos.idEstadoOrigen = Estados.id
	INNER JOIN EstatusAlumnos
ON Alumnos.idEstatus = EstatusAlumnos.id

-- Consulta instructores
SELECT Instructores.nombre AS 'Instructor', cuotaHora, CatCursos.nombre AS 'Nombre', fechaInicio, fechaTermino FROM Instructores 
	INNER JOIN CursosInstructores
ON Instructores.id = CursosInstructores.idInstructor
	INNER JOIN Cursos
ON CursosInstructores.idCurso = Cursos.id
	INNER JOIN CatCursos
ON Cursos.idCatCurso = CatCursos.id

-- Consulta alumnos
SELECT Alumnos.nombre, primerApellido, segundoApellido, Estados.nombre AS 'Estado', CatCursos.nombre AS 'Curso', fechaInscripcion, fechaInicio, fechaTermino, calificacion FROM Alumnos
	INNER JOIN Estados
ON Estados.id = Alumnos.idEstadoOrigen
	INNER JOIN CursosAlumnos
ON CursosAlumnos.idAlumno = Alumnos.id
	INNER JOIN Cursos
ON Cursos.id = CursosAlumnos.idCurso
	INNER JOIN CatCursos
ON CatCursos.id = Cursos.id

select * from CatCursos

-- Consulta cursos
SELECT CatCursos.id, CatCursos.clave, CatCursos.nombre AS 'Curso', CatCursos.horas, IIF(CatCursos.idPreRequisito IS NULL, 'Sin Prerrequisito', Pre.nombre) AS 'Prerrequisito' FROM CatCursos
	LEFT JOIN CatCursos AS Pre
ON CatCursos.idPreRequisito = Pre.id

-- Consulta alumnos curso
SELECT Alumnos.id, Alumnos.nombre, primerApellido, segundoApellido,  CatCursos.nombre, fechaInicio, fechaTermino, calificacion,
CASE
	WHEN calificacion>8 THEN 'Excelente'
	WHEN calificacion>6 THEN 'Bien'
	WHEN calificacion=6 THEN 'Suficiente'
	WHEN calificacion<6 THEN 'N/A'
END AS 'Nivel'
FROM Alumnos
	INNER JOIN Estados
ON Estados.id = Alumnos.idEstadoOrigen
	INNER JOIN CursosAlumnos
ON CursosAlumnos.idAlumno = Alumnos.id
	INNER JOIN Cursos
ON Cursos.id = CursosAlumnos.idCurso
	INNER JOIN CatCursos
ON CatCursos.id = Cursos.id