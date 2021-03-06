USE [GD2C2016]
GO
/****** Object:  StoredProcedure [Select_Group].[sp_registrarCancelacion]    Script Date: 30/11/2016 15:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Select_Group].[sp_registrarCancelacion](@idTipoCanc int, @Motivo varchar(45),  @idTurno int)
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
