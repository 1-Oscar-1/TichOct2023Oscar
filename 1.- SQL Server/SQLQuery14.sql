-- Ejercicio 1

CREATE OR ALTER VIEW V_Alumnos
AS
SELECT Alumnos.id, Alumnos.nombre, Alumnos.primerApellido, Alumnos.segundoApellido, Alumnos.correo, Alumnos.telefono, Alumnos.curp, Estados.nombre AS Estado, EstatusAlumnos.nombre AS Estatus
FROM Alumnos
	LEFT JOIN Estados
ON Estados.id = Alumnos.idEstadoOrigen
	INNER JOIN EstatusAlumnos
ON EstatusAlumnos.id = Alumnos.idEstatus

SELECT *
FROM V_Alumnos

-- Ejercicio 2

CREATE OR ALTER PROCEDURE SP_ConsultarEstados
(
	@idEstado INT
)
AS
BEGIN
	SELECT *
	FROM Estados
	WHERE Estados.id = @idEstado OR @idEstado < 0
END

EXECUTE SP_ConsultarEstados -1

-- Ejercicio 3

CREATE OR ALTER PROCEDURE SP_ConsultarEsatusAlumnos
(
	@idAlumno INT
)
AS
BEGIN
	SELECT EstatusAlumnos.nombre
	FROM Alumnos
		INNER JOIN EstatusAlumnos
	ON EstatusAlumnos.id = Alumnos.idEstatus
	WHERE Alumnos.id = @idAlumno OR @idAlumno < 0
END

EXECUTE SP_ConsultarEsatusAlumnos -3

-- Ejercicio 4

CREATE OR ALTER PROCEDURE SP_ConsultarAlumnos
(
	@idAlumno INT
)
AS
BEGIN
	SELECT Alumnos.id, Alumnos.nombre, Alumnos.primerApellido, Alumnos.segundoApellido, Alumnos.correo, Alumnos.fechaNacimiento, Alumnos.telefono, Alumnos.curp, Estados.nombre AS Estado, EstatusAlumnos.nombre AS Estatus
	FROM Alumnos
		INNER JOIN Estados
	ON Estados.id = Alumnos.idEstadoOrigen
		INNER JOIN EstatusAlumnos
	ON EstatusAlumnos.id = Alumnos.idEstatus
	WHERE Alumnos.id = @idAlumno OR @idAlumno < 0
END

EXECUTE SP_ConsultarAlumnos 3

-- Ejercicio 5

CREATE OR ALTER PROCEDURE SP_ConsultarEAlumnos
(
	@idAlumno INT
)
AS
BEGIN
	SELECT Alumnos.id, Alumnos.nombre, Alumnos.primerApellido, Alumnos.segundoApellido, Alumnos.correo, Alumnos.fechaNacimiento, Alumnos.telefono, Alumnos.curp, Estados.id AS Estado, EstatusAlumnos.id AS Estatus
	FROM Alumnos
		INNER JOIN Estados
	ON Estados.id = Alumnos.idEstadoOrigen
		INNER JOIN EstatusAlumnos
	ON EstatusAlumnos.id = Alumnos.idEstatus
	WHERE Alumnos.id = @idAlumno OR @idAlumno < 0
END

EXECUTE SP_ConsultarEAlumnos 2

-- Ejercicio 6

CREATE OR ALTER PROCEDURE SP_ActualizarEstatusAlumnos 
(
	@idAlumno INT, @idEstatus INT
)
AS
BEGIN
	UPDATE Alumnos
	SET idEstatus = @idEstatus
	WHERE Alumnos.id = @idAlumno
END

EXECUTE SP_ActualizarEstatusAlumnos 2,3

-- Ejercicio 7

CREATE OR ALTER PROCEDURE SP_AgregarAlumnos
(
	@nombre VARCHAR(50), @ape1 VARCHAR(50), @ape2 VARCHAR(50), @correo VARCHAR(50), @telefono NCHAR(10), @fecha DATE, @curp CHAR(18), @sueldo DECIMAL(9,2), @idEstado INT, @idEsatus SMALLINT
)
AS
BEGIN
	DECLARE @ultimoId INT

	INSERT INTO Alumnos VALUES(@nombre, @ape1, @ape2, @correo, @telefono, @fecha, @curp, @sueldo, @idEstado, @idEsatus)

	SET @ultimoId = SCOPE_IDENTITY()
	PRINT @ultimoId
END

EXECUTE SP_AgregarAlumnos 'Roberto','Lozano','Ramirez','roberto@gmail.com','2283586148','1997-02-12','RRLO970212HSRND',30000,3,4

-- Ejercicio 8

CREATE OR ALTER PROCEDURE SP_ActualizarAlumnos
(
	@idAlumno INT, @nombre VARCHAR(50), @ape1 VARCHAR(50), @ape2 VARCHAR(50), @correo VARCHAR(50), @telefono NCHAR(10), @fecha DATE, @curp CHAR(18), @sueldo DECIMAL(9,2), @idEstado INT, @idEsatus SMALLINT
)
AS
BEGIN

	SET NOCOUNT OFF;

	UPDATE Alumnos
	SET nombre = @nombre, primerApellido = @ape1, segundoApellido = @ape2, correo = @correo, telefono = @telefono, fechaNacimiento = @fecha, curp = @curp, sueldo = @sueldo, idEstadoOrigen = @idEstado, idEstatus = @idEsatus
	WHERE Alumnos.id = @idAlumno

END

EXECUTE SP_ActualizarAlumnos 1001,'Robert','Lozano','Ramirez','roberto@gmail.com','2283586148','1997-02-12','RRLO970212HSRND',30000,3,4

SELECT * FROM Alumnos

-- Ejercicio 9

CREATE OR ALTER PROCEDURE SP_EliminarAlumnos
(
	@idAlumno INT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
			DELETE FROM CursosAlumnos WHERE CursosAlumnos.idAlumno = @idAlumno
			DELETE FROM Alumnos WHERE Alumnos.id = @idAlumno
		COMMIT TRANSACTION
		PRINT 'Se elimino el alumno'
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		PRINT 'No se logro completar la eliminacion';
		THROW 50001,'Error al realizar la transferencia', 1
	END CATCH
END

EXECUTE SP_EliminarAlumnos 1
select * from AlumnosBaja
-- Ejercicio 10

CREATE OR ALTER TRIGGER Trigger_EliminarAlumnos
ON Alumnos
AFTER DELETE
AS
BEGIN
	INSERT INTO AlumnosBaja(nombre, primerApellido, segundoApellido, fechaBaja)
	SELECT d.nombre, d.primerApellido, d.segundoApellido, GETDATE()
	FROM deleted d
END

-- Ejercicio 11

use InstitutoTich

BACKUP DATABASE InstitutoTich TO DISK = 'URL a guardar'

RESTORE DATABASE InstitutoTich FILE = 'nombre' FROM DISK = 'URL del archivo'

-- Ejercicio 12

RESTORE FILELISTONLY
FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\InstitutoTich.bak'


RESTORE DATABASE PruebasTich
FROM DISK = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup\InstitutoTich.bak'
WITH
   MOVE 'InstitutoTich' TO 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebasTich.mdf',
   MOVE 'InstitutoTich_log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebasTich_log.ldf';

-- Ejercicio 13

use PruebasTich

CREATE OR ALTER PROCEDURE SP_EliminaAlumnosCurso
(
	@nombreCurso VARCHAR(100)
)
AS
BEGIN
	DECLARE @idCurso INT
	DECLARE @count INT = 0
	DECLARE @numAlum INT
	DECLARE @idAlum INT

	SELECT @idCurso = CatCursos.id FROM CatCursos WHERE LOWER(CatCursos.nombre) = LOWER(@nombreCurso)

	SELECT @numAlum = COUNT(CursosAlumnos.idAlumno) FROM CursosAlumnos WHERE CursosAlumnos.idCurso = @idCurso

	WHILE @count < @numAlum
	BEGIN
		SELECT @idAlum = Alumnos.id FROM Alumnos
			WHERE Alumnos.id = (SELECT TOP(1) CursosAlumnos.idAlumno FROM CursosAlumnos WHERE CursosAlumnos.idCurso = @idCurso)

		EXECUTE SP_EliminarAlumnos @idAlum

		SET @count = @count + 1
	END

END

EXECUTE SP_EliminaAlumnosCurso 'c#'

SELECT * FROM CursosAlumnos
SELECT * FROM Alumnos
SELECT * FROM CatCursos

-- Ejercicio 14

use InstitutoTich; -- Cambia al contexto de la base de datos InstitutoTich

-- Para obtener scripts de procedimientos almacenados, vistas y funciones:
SELECT OBJECT_DEFINITION(OBJECT_ID(object_id)) AS 'Script'
FROM sys.objects
WHERE type IN ('P', 'V', 'FN', 'IF', 'TF');

-- Ejercicio 15

DECLARE @Script NVARCHAR(MAX)
SELECT @Script = OBJECT_DEFINITION(OBJECT_ID('dbo.SP_EliminaAlumnosCurso'))

PRINT @Script
