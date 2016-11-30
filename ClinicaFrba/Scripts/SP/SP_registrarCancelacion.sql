-- ================================================

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Select_Group.sp_registrarCancelacion(@idTipoCanc numeric(6,0), @Motivo varchar(45),  @idTurno numeric(18,0))
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO Select_Group.Cancelacion(motivo,tipo_Cancelacion_idTipoCanc)
	VALUES (@Motivo, @idTipoCanc)

	declare @idCanc numeric(6,0);

	SET @idCanc = (SELECT max(idCancelacion) FROM Select_Group.Cancelacion);

	UPDATE Select_Group.Turno
	Set cancelacion_idCancelacion = @idCanc,
	estado = 2
	WHERE idTurno = @idTurno;

	Declare @idAgenda int;

	SET @idAgenda = (Select idAgenda FROM Select_Group.Turno WHERE idTurno = @idTurno);

	UPDATE Select_Group.Agenda_Detalle
	Set estaCancelado = 1
	WHERE idAgenda = @idAgenda;
    
	
END
GO
