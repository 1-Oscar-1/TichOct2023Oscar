-- Ejercicio 1

CREATE OR ALTER FUNCTION TablaAmorti
(
	@sueldo DECIMAL(9,2)
)
RETURNS @tablaMor TABLE
(
	Quiencena INT,
	saldoAnterior DECIMAL(9,2),
	Pago DECIMAL(9,2),
	SaldoNuevo DECIMAL(9,2)
)
AS
BEGIN
	DECLARE @saldoAnterior DECIMAL(9,2) = @sueldo
	DECLARE @pago DECIMAL(9,2) = @saldoAnterior / 12
	DECLARE @saldoNuevo DECIMAL(9,2)
	DECLARE @count INT = 1

	WHILE @count < 13
	BEGIN
		SET @saldoNuevo = @saldoAnterior - @pago

		INSERT INTO @tablaMor
			SELECT @count, @saldoAnterior, @pago, @saldoNuevo
		
		SET @saldoAnterior = @saldoNuevo
		SET @count = @count + 1
	END

	RETURN
		
END

SELECT * FROM TablaAmorti(22000)

-- Ejercicio 2

CREATE OR ALTER FUNCTION InteresAmorti
(
	@idInstructor INT
)
RETURNS @tablaInteres TABLE
(
	Mes INT,
	saldoAnterior DECIMAL(9,2),
	interes DECIMAL(9,2),
	pago DECIMAL(9,2),
	saldoNuevo DECIMAL(9,2),
	idIns INT
)
AS
BEGIN
	DECLARE @cuotaHora DECIMAL(9,2)
	DECLARE @prestamo DECIMAL(9,2)
	DECLARE @saldoInteres DECIMAL(9,2)
	DECLARE @saldoNuevo DECIMAL(9,2)
	DECLARE @porInteres DECIMAL(9,2)
	DECLARE @pago DECIMAL(9,2)
	DECLARE @count INT = 1

	--Se trae la cuota por hora
	SELECT @cuotaHora = Instructores.cuotaHora
	FROM Instructores
	WHERE @idInstructor = Instructores.id

	--Se calcula el prestamo y pago inicial
	SET @prestamo = @cuotaHora * 200
	SET @pago = @cuotaHora * 25

	-- Fija % de interes
	IF(@cuotaHora > 200)
		BEGIN
			SET @porInteres =  CONVERT(decimal(5,2),24)/CONVERT(decimal(5,2),12)
		END
	ELSE
		BEGIN
			SET @porInteres = CONVERT(decimal(5,2),18)/CONVERT(decimal(5,2),12)
		END
	
	-- Inserta datos en tabla con ciclo
	SET @saldoNuevo = 1
	WHILE @count < 13 AND @saldoNuevo > 0
		BEGIN
			--Se calcula el interes
			SET @saldoInteres = (@prestamo * @porInteres) / 100
			--Se calcula salDo nuevo
			SET @saldoNuevo = (@prestamo + @saldoInteres) - @pago
			IF(@saldoNuevo < 0)
				SET @saldoNuevo = 0
			--Se verifica si es el ultimo pago
			IF(@saldoNuevo = 0)
				SET @pago = @prestamo + @saldoInteres
			--Se insertan datos
			INSERT INTO @tablaInteres
				SELECT @count, @prestamo, @saldoInteres, @pago, @saldoNuevo, @idInstructor
			--Se igual el prestamo a saldo nuevo
			SET @prestamo = @saldoNuevo
			--Se actualiza count
			SET @count = @count + 1
		END

	RETURN
END

SELECT * FROM InteresAmorti(1)

SELECT * FROM Instructores