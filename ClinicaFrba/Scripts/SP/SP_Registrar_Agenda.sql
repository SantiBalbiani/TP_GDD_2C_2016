
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Select_Group.sp_Agendar_Turno(@fechaHoraTurno datetime, @idAgenda int ) 
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT into Select_Group.Agenda_Detalle(fecha_Hora_Turno, estaCancelado, idAgenda)
	VALUES (@fechaHoraTurno,0,@idAgenda);
END
GO
