CREATE DATABASE AUDITORIA
GO
USE [AUDITORIA]
GO
/****** Object:  Table [dbo].[PRIMOS]    Script Date: 27/01/2019 23:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRIMOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NUMERO_INICIAL] [int] NOT NULL,
	[NUMERO_FINAL] [int] NOT NULL,
	[FECHA] [date] NOT NULL CONSTRAINT [DF__PRIMOS__FECHA__108B795B]  DEFAULT (sysdatetime()),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[HALLAR_PRIMOS]    Script Date: 27/01/2019 23:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HALLAR_PRIMOS] 
@nInicial INT,
@nFinal INT
AS
DECLARE @count int
DECLARE @countprimos INT
DECLARE @aux INT

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = N'PRIMOS') -- Esta consulta me permite saber si la tabla existe
	BEGIN
		CREATE TABLE [dbo].[PRIMOS](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[NUMERO_INICIAL] [int] NOT NULL,
		[NUMERO_FINAL] [int] NOT NULL,
		[FECHA] [date] NOT NULL   DEFAULT sysdatetime()
		)
	END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_NAME = N'TEMP') 
				BEGIN
						DELETE FROM TEMP
				END
				ELSE
						CREATE TABLE TEMP(
								DATO int
							) 

IF @nInicial < @nFinal --Validamos que nIni sea menor 
BEGIN
INSERT INTO PRIMOS (NUMERO_INICIAL, NUMERO_FINAL) VALUES (@nInicial, @nFinal)--inserto la auditoria 

SET @count = @nInicial --asigno datos
	SET @aux = 1
	SET @countprimos = 0
	WHILE @count < @nFinal--count representa el numero inicial 
	BEGIN
		WHILE @aux <= @count --Hago que se haga un ciclo de 1 hasta n
		BEGIN
			IF @count % @aux = 0--preguntando siempre si n es modulo de 
			  SET @countprimos = @countprimos +1 
			SET @aux = @aux + 1;--aux se va sumando
		END
		IF @countprimos = 2 --Los numeros primos solo tiene dos numeros multiplos
			INSERT INTO TEMP VALUES (@count)--inserto de ser asi
		SET @aux = 1
		SET @countprimos = 0
	SET @count = @count + 1;--El proceso se repite hasta que se recorran todos los datos entre nIni a nFin sin contarse asi mismos
	END
	SELECT * FROM TEMP
END
ELSE
SELECT * FROM TEMP
GO
