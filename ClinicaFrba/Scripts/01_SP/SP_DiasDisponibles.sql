USE [GD2C2016]
GO
/****** Object:  StoredProcedure [Select_Group].[sp_getDiasDisponibles]    Script Date: 13/11/2016 16:46:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Select_Group].[sp_getDiasDisponibles] (@Dia int,  @idProfesional int, @especialidad int)

AS
BEGIN
	

	SELECT idAgenda, profesional_idProfesional, horaDesde, horaHasta
	
	FROM Select_Group.Agenda WHERE diaDisponible = @Dia AND profesional_IdProfesional = @idProfesional AND especialidad = @especialidad

END
