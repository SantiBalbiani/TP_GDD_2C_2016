USE [GD2C2016]
GO
/****** Object:  StoredProcedure [Select_Group].[sp_guardarDiagnostico]    Script Date: 29/11/2016 2:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Select_Group].[sp_guardarDiagnostico](@sintomas VARCHAR(255), @enfermedades VARCHAR(255), @idTurno int )

AS
BEGIN
	
	SET NOCOUNT ON;

	BEGIN TRAN

	DECLARE @idDiagnostico int;

	IF (@sintomas <> 'NO SE COMPLETO DIAGNOSTICO')

	BEGIN
    INSERT INTO Select_Group.Diagnostico (sintomas, enfermedades, fechaYHora)
	VALUES ( @sintomas, @enfermedades, GETDATE());

	SET @idDiagnostico = (SELECT max(idDiagnostico) FROM Select_Group.Turno)+1;

	UPDATE Select_Group.Turno

	SET 
	estado = 1,
	idDiagnostico = @idDiagnostico
	WHERE idTurno = @idTurno;

	END
	ELSE
	BEGIN

	UPDATE Select_Group.Turno

	SET estado = 2
	WHERE idTurno = @idTurno;

	END
	

	
	COMMIT TRAN



END
