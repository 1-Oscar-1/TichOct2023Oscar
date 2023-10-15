-- Ejercicio 1

CREATE OR ALTER PROCEDURE SP_ProcedureCodigoAscii
AS
BEGIN
	DECLARE @count INT = 32
	DECLARE @codigo VARCHAR(1)
	WHILE @count < 256
		BEGIN
			PRINT CONCAT(NCHAR(@count), ' ASCII=> ', CONVERT(varchar,@count))
			SET @count = @count + 1
		END
END

EXECUTE SP_ProcedureCodigoAscii

-- Ejercicio 2

CREATE OR ALTER PROCEDURE SP_ProcedureFactorial
(
	@num INT, @numFact INT OUTPUT
)
AS
BEGIN
	SET @numFact = dbo.Factorial(@num)
END

DECLARE @numFacSal INT
EXECUTE SP_ProcedureFactorial 3, @numFact = @numFacSal OUTPUT
PRINT @numFacSal

-- Ejercicio 3

CREATE OR ALTER PROCEDURE SP_CrearTablas
AS
BEGIN
	CREATE TABLE Saldos(
		id INT PRIMARY KEY IDENTITY(1,1),
		Nombre VARCHAR(50),
		Saldo DECIMAL(9,2)
	)
	
	CREATE TABLE Transacciones(
		id INT PRIMARY KEY IDENTITY(1,1),
		idOrigen INT,
		idDestino INT,
		monto DECIMAL

		CONSTRAINT FK_TransaccionUno
		FOREIGN KEY(idOrigen) REFERENCES Saldos(id)
			ON UPDATE CASCADE
			ON DELETE CASCADE,
		CONSTRAINT FK_TransaccionDos
		FOREIGN KEY(idDestino) REFERENCES Saldos(id)
	)
END

EXECUTE SP_CrearTablas

-- Ejercicio 4

CREATE OR ALTER PROCEDURE SP_Transacciones
(
	@CuentaOrigen INT,
	@CuentaDestino INT,
	@Cantidad DECIMAL(18, 2)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar saldo suficiente en la cuenta origen
        DECLARE @SaldoOrigen DECIMAL(18, 2);
        SELECT @SaldoOrigen = Saldo FROM Saldos WHERE Saldos.id = @CuentaOrigen

        IF (@SaldoOrigen >= @Cantidad)
        BEGIN
            -- Restar la cantidad de la cuenta origen
            UPDATE Saldos SET Saldo = Saldo - @Cantidad WHERE ID = @CuentaOrigen

            -- Sumar la cantidad a la cuenta destino
            UPDATE Saldos SET Saldo = Saldo + @Cantidad WHERE ID = @CuentaDestino
            COMMIT
            PRINT 'Transacción completada exitosamente.'
        END
        ELSE
        BEGIN
            ROLLBACK
            PRINT 'Saldo insuficiente en la cuenta origen.'
        END
    END TRY
    BEGIN CATCH
        ROLLBACK
        PRINT 'Error en la transacción. Se ha realizado un rollback.';
		THROW 51000,'Error al realizar la transferencia', 1
    END CATCH
END

EXECUTE SP_Transacciones 1,3,300

insert into Saldos values('oscar', 400)
insert into Saldos values('xavi', 500)
insert into Saldos values('victor', 700)
select * from Saldos