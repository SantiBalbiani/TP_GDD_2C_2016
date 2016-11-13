
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Select_Group.sp_getDiasDisponibles (@Dia int,  @idProfesional int)

AS
BEGIN
	

	SELECT profesional_idProfesional, horaDesde, horaHasta
	
	FROM Select_Group.Agenda WHERE diaDisponible = @Dia AND profesional_IdProfesional = @idProfesional

END
GO
