-- Ejercicio 1

CREATE FUNCTION Suma
(
	@num1 INT, @num2 INT
)
RETURNS INT
AS
BEGIN
	RETURN @num1 + @num2
END

PRINT dbo.Suma(2,4)

-- Ejercicio 2

CREATE FUNCTION GetGenero
(
	@curp VARCHAR(18)
)
RETURNS VARCHAR(20)
AS
BEGIN
	RETURN IIF(SUBSTRING(@curp,11,1) = 'H', 'Hombre', 'Mujer')
END

PRINT dbo.GetGenero('TYHD560312HSRNDS01')

-- Ejercicio 3

CREATE OR ALTER FUNCTION GetFechaNacimiento
(
	@curp VARCHAR(18)
)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @resultado VARCHAR(10)
	DECLARE @fechaCompleta VARCHAR(10)
	SET @resultado = CONCAT(SUBSTRING(@curp,5,2),'-',SUBSTRING(@curp,7,2),'-',SUBSTRING(@curp,9,2))
	IF(SUBSTRING(@curp,5,2) = '00')
		SET @resultado = CONCAT('20',@resultado)
	ELSE
		SET @resultado = CONCAT('19',@resultado)
	RETURN @resultado
END

PRINT dbo.GetFechaNacimiento('LARO230621')

-- Ejercicio 4

CREATE OR ALTER FUNCTION GetEstado
(
	@curp VARCHAR(18)
)
RETURNS VARCHAR(18)
AS
BEGIN
	DECLARE @estadoCurp VARCHAR(2) = SUBSTRING(@curp,12,2)
	DECLARE @idEstado INT

	SET @idEstado = CASE @estadoCurp
		WHEN 'AS' THEN 1
		WHEN 'BC' THEN 2
		WHEN 'BS' THEN 3
		WHEN 'CC' THEN 4
		WHEN 'CH' THEN 5
		WHEN 'CS' THEN 6
		WHEN 'CL' THEN 7
		WHEN 'CM' THEN 8
		WHEN 'DG' THEN 9
		WHEN 'GT' THEN 10
		WHEN 'GR' THEN 11
		WHEN 'HG' THEN 12
		WHEN 'JS' THEN 13
		WHEN 'MC' THEN 14
		WHEN 'MN' THEN 15
		WHEN 'MS' THEN 16
		WHEN 'NT' THEN 17
		WHEN 'NL' THEN 18
		WHEN 'OC' THEN 19
		WHEN 'PL' THEN 20
		WHEN 'QT' THEN 21
		WHEN 'QR' THEN 22
		WHEN 'SP' THEN 23
		WHEN 'SL' THEN 24
		WHEN 'SR' THEN 25
		WHEN 'TC' THEN 26
		WHEN 'TS' THEN 27
		WHEN 'TL' THEN 28
		WHEN 'VZ' THEN 29
		WHEN 'YN' THEN 30
		WHEN 'ZS' THEN 31
		ELSE 0
	END
	RETURN @idEstado
END

PRINT dbo.GetEstado('LARO990621HVZNDS')

-- Ejercicio 5

CREATE OR ALTER FUNCTION Calculadora
(
	@num1 DECIMAL, @num2 DECIMAL, @ope VARCHAR(1)
)
RETURNS DECIMAL
AS
BEGIN
	DECLARE @resul DECIMAL

	SET @resul = CASE @ope
		WHEN '+' THEN @num1 + @num2
		WHEN '-' THEN @num1 - @num2
		WHEN '*' THEN @num1 * @num2
		WHEN '/' THEN IIF(@num2 != 0,@num1 / @num2, 0)
		WHEN '%' THEN IIF(@num2 != 0,@num1 % @num2, 0)
	END
	RETURN @resul
END

PRINT dbo.Calculadora(7,0,'/')

-- Ejercicio 6

CREATE OR ALTER FUNCTION GetHonorarios
(
	@idInstructor INT, @idCurso INT
)
RETURNS FLOAT
AS
BEGIN
	DECLARE @cuotaHora FLOAT
	DECLARE @horasCurso FLOAT

	SELECT @cuotaHora = Instructores.cuotaHora
	FROM Instructores
	WHERE Instructores.id = @idInstructor

	SELECT @horasCurso = CatCursos.horas
	FROM CatCursos
	WHERE CatCursos.id = @idCurso

	RETURN @horasCurso * @cuotaHora
END

PRINT dbo.GetHonorarios(1,3)

select * from CursosInstructores

-- Ejercicio 7

CREATE OR ALTER FUNCTION GetEdad
(
	@fechaNacimiento DATE, @fechaCalcular DATE
)
RETURNS INT
AS
BEGIN
	DECLARE @edad INT

	SET @edad = DATEDIFF(year,@fechaNacimiento, @fechaCalcular)
	
	IF(MONTH(@fechaNacimiento) >= MONTH(@fechaCalcular))
		IF(DAY(@fechaNacimiento) > DAY(@fechaCalcular))
			SET @edad = @edad - 1

	RETURN @edad
END

PRINT dbo.GetEdad('1999-06-21','2023-06-20')

-- Ejercicio 8

CREATE OR ALTER FUNCTION Factorial
(
	@num INT
)
RETURNS INT
AS
BEGIN
	DECLARE @resultado INT
	DECLARE @cont INT = @num
	DECLARE @totalMul INT = 1
	DECLARE @numAnt INT

	WHILE @cont > 1
	BEGIN
		SET @numAnt = @cont -1
		SET @totalMul = @totalMul * @cont
		SET @cont = @cont - 1
	END
	RETURN @totalMul
END

PRINT dbo.Factorial(5)

-- Ejercicio 9

CREATE OR ALTER FUNCTION ReembolsoQuinsenal
(
	@sueldoMensual FLOAT
)
RETURNS FLOAT
AS
BEGIN
	DECLARE @importe FLOAT
	DECLARE @reembolso FLOAT

	SET @importe = (@sueldoMensual * 2.5)
	SET @reembolso = @importe / 12

	RETURN @reembolso
END

PRINT dbo.ReembolsoQuinsenal(20000)

-- Ejercicio 10

CREATE OR ALTER FUNCTION Impuesto
(
	@idInstructor INT, @idCurso INT
)
RETURNS FLOAT
AS
BEGIN
	DECLARE @cuotaHora FLOAT
	DECLARE @cursoHora FLOAT
	DECLARE @impuesto FLOAT
	DECLARE @estado VARCHAR(2)

	SELECT @cuotaHora = Instructores.cuotaHora, @estado = SUBSTRING(Instructores.curp,12,2)
	FROM Instructores
	WHERE Instructores.id = @idInstructor

	SELECT @cursoHora = CatCursos.horas
	FROM CatCursos
	WHERE CatCursos.id = @idCurso

	SET @impuesto = CASE @estado
		WHEN 'CS' THEN (@cursoHora * @cuotaHora) - (@cursoHora * @cuotaHora) * 0.05
		WHEN 'SR' THEN (@cursoHora * @cuotaHora) - (@cursoHora * @cuotaHora) * 0.1
		WHEN 'VZ' THEN (@cursoHora * @cuotaHora) - (@cursoHora * @cuotaHora) * 0.07
		ELSE (@cursoHora * @cuotaHora) - (@cursoHora * @cuotaHora) * 0.08
	END

	RETURN @impuesto

END

PRINT dbo.Impuesto(1,1)

-- Ejercicio 11

SELECT Alumnos.nombre, CursosAlumnos.fechaInscripcion, dbo.GetEdad(Alumnos.fechaNacimiento,GETDATE()) AS 'Edad'
FROM Alumnos
	INNER JOIN CursosAlumnos
ON CursosAlumnos.idAlumno = Alumnos.id
WHERE dbo.GetEdad(Alumnos.fechaNacimiento,GETDATE()) > 25

-- Ejercicio 12

CREATE OR ALTER FUNCTION Descuento
(
	@sueldoLogrado FLOAT, @meses INT
)
RETURNS FLOAT
AS
BEGIN
	DECLARE @porcentaje FLOAT
	DECLARE @porcentajeMax FLOAT

	SET @porcentajeMax = @sueldoLogrado / 1000

	SET @porcentaje = CASE @meses
		WHEN 1 THEN @porcentajeMax * 1
		WHEN 2 THEN @porcentajeMax * 0.75
		WHEN 3 THEN @porcentajeMax * 0.5
		WHEN 4 THEN @porcentajeMax * 0.25
		ELSE @porcentajeMax / 6
	END

	RETURN @porcentaje
END

PRINT dbo.Descuento(30000, 3)

-- Ejercicio 13

CREATE OR ALTER FUNCTION ConvMayus
(
	@texto VARCHAR(100)
)
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @longText INT = LEN(@texto)
	DECLARE @newText VARCHAR(100) = @texto
	DECLARE @convert BIT = 1
	DECLARE @count INT = 1

	WHILE @count < @longText +  1
	BEGIN
		IF(SUBSTRING(@texto,@count,1) = ' ')
			BEGIN
				SET @newText = STUFF(@newText, @count,1, ' ')
				SET @convert = 1
			END
		ELSE IF (@convert = 1)
			BEGIN
				SET @newText = STUFF(@newText, @count,1, UPPER(SUBSTRING(@texto,@count,1)))
				SET @convert = 0
			END

		SET @count = @count + 1
	END

	RETURN @newText

END

PRINT dbo.ConvMayus('twer bwer c')