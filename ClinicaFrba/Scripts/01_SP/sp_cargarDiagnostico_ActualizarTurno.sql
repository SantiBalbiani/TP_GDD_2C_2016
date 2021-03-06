USE [GD2C2016]
GO
/****** Object:  StoredProcedure [Select_Group].[sp_guardarDiagnostico]    Script Date: 09/12/2016 23:36:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_guardarDiagnostico
--OBJETIVO  : Cuando un profesional registra resultado                                    
--=============================================================================================================
CREATE PROCEDURE [Select_Group].[sp_guardarDiagnostico](@sintomas VARCHAR(255), @enfermedades VARCHAR(255), @idTurno int, @fechaActual datetime )

AS
BEGIN
	
	SET NOCOUNT ON;

	

	DECLARE @idDiagnostico int;

	IF (@sintomas <> 'NO SE COMPLETO DIAGNOSTICO')

	BEGIN
    INSERT INTO Select_Group.Diagnostico (sintomas, enfermedades, fechaYHora)
	VALUES ( @sintomas, @enfermedades, @fechaActual);

	SET @idDiagnostico = ((SELECT max(idDiagnostico) FROM Select_Group.Diagnostico));

	UPDATE Select_Group.Turno

	SET 
	estado = 1,
	idDiagnostico = @idDiagnostico
	WHERE idTurno = @idTurno;

	END
	ELSE
	BEGIN

	UPDATE Select_Group.Turno

	SET estado = 2 --Si no se completó el diagnóstico el Afiliado se retiró antes y el turno queda cancelado
	WHERE idTurno = @idTurno;

	END
	
END
