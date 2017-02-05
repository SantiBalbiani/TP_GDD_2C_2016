-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_getDiasDisponibles
--OBJETIVO  : obtiene el horario de trabajo de un profesional para un dia de la semana                                   
--=============================================================================================================
CREATE PROCEDURE [SELECT_GROUP].[sp_getDiasCancelables] (@Dia int,  @idProfesional int)

AS
BEGIN
	

	SELECT idAgenda, profesional_idProfesional, horaDesde, horaHasta
	
	FROM Select_Group.Agenda WHERE diaDisponible = @Dia AND profesional_IdProfesional = @idProfesional

END
GO
