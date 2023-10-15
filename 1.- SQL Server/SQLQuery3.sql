select * from CursosInstructores

SET IDENTITY_INSERT [dbo].[CursosInstructores] ON 

INSERT INTO CatCursos ([id],[clave],[nombre],[descripcion],[horas],[idPreRequisito],[activo]) VALUES(1, 'KSLAJE', 'JavaScript', NULL, 60, NULL, 1)
INSERT INTO CatCursos ([id],[clave],[nombre],[descripcion],[horas],[idPreRequisito],[activo]) VALUES(2, 'OIHGAS', 'C#', NULL, 50, NULL, 1)
INSERT INTO CatCursos ([id],[clave],[nombre],[descripcion],[horas],[idPreRequisito],[activo]) VALUES(3, 'ASDDAS', 'PHP', NULL, 50, NULL, 1)
INSERT INTO CatCursos ([id],[clave],[nombre],[descripcion],[horas],[idPreRequisito],[activo]) VALUES(4, 'IUKUIK', 'Python', NULL, 50, NULL, 1)

SET IDENTITY_INSERT [dbo].[CursosInstructores] Off

INSERT INTO Cursos ([id],[idCatCurso],[fechaInicio],[fechaTermino],[activo]) VALUES(1, 1, '01/12/2023', '30/12/2023', 1)
INSERT INTO Cursos ([id],[idCatCurso],[fechaInicio],[fechaTermino],[activo]) VALUES(2, 2, '01/12/2023', '30/12/2023', 1)
INSERT INTO Cursos ([id],[idCatCurso],[fechaInicio],[fechaTermino],[activo]) VALUES(3, 3, '01/12/2023', '30/12/2023', 1)
INSERT INTO Cursos ([id],[idCatCurso],[fechaInicio],[fechaTermino],[activo]) VALUES(4, 4, '01/12/2023', '30/12/2023', 1)
INSERT INTO Cursos ([id],[idCatCurso],[fechaInicio],[fechaTermino],[activo]) VALUES(5, 1, '01/12/2023', '30/12/2023', 1)
INSERT INTO Cursos ([id],[idCatCurso],[fechaInicio],[fechaTermino],[activo]) VALUES(6, 2, '01/12/2023', '30/12/2023', 1)


INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(1, 1, 1, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(2, 2, 2, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(3, 3, 3, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(4, 4, 4, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(5, 5, 5, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(6, 6, 6, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(7, 1, 7, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(8, 2, 8, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(9, 3, 9, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(10, 4, 10, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(11, 5, 11, '01/12/2023', '30/12/2023', 8)
INSERT INTO CursosAlumnos([id],[idCurso],[idAlumno],[fechaInscripcion],[fechaBaja],[calificacion]) VALUES(12, 6, 12, '01/12/2023', '30/12/2023', 8)

INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(1, 1, 1, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(2, 1, 2, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(3, 2, 3, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(4, 2, 4, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(5, 3, 1, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(6, 3, 2, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(7, 4, 3, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(8, 4, 4, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(9, 5, 1, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(10, 5, 2, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(11, 6, 3, '30/12/2023')
INSERT INTO CursosInstructores([id],[idCurso],[idInstructor],[fechaContratacion]) VALUES(12, 6, 4, '30/12/2023')