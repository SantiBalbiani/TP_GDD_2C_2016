USE [GD2C2016]
GO
/****** Object:  StoredProcedure [SELECT_GROUP].[sp_cancelacionProfesional]    Script Date: 05/02/2017 20:27:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_cancelacionProfesional
--OBJETIVO  : Cuando un profesional cancela un turno                                    
--=============================================================================================================

ALTER PROCEDURE [SELECT_GROUP].[sp_cancelacionProfesional](@Motivo varchar(45), @tipoMot int, @idProf int, @fechaDesde datetime, @fechaHasta datetime,@idCanc int out)
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE turnos CURSOR FOR
	SELECT T.idTurno, D.idAgendaDetalle
	FROM Select_Group.Agenda A
	JOIN Select_Group.Turno T ON T.idAgenda = A.idAgenda
	JOIN SELECT_GROUP.Agenda_Detalle D ON D.idAgenda = A.idAgenda AND T.fechaTurno = D.fecha_Hora_Turno
	WHERE A.profesional_IdProfesional = @idProf
	AND T.fechaTurno BETWEEN @fechaDesde AND @fechaHasta

	declare @idAgDetalle int;

	declare @idTurno int;

	INSERT INTO Select_Group.Cancelacion(motivo, tipo_Cancelacion_idTipoCanc)
	VALUES(@Motivo, @tipoMot);

	SET @idCanc = (SELECT max(idCancelacion) FROM Select_Group.Cancelacion);

	OPEN turnos;

	FETCH NEXT FROM turnos INTO @idTurno, @idAgDetalle;

	WHILE (@@FETCH_STATUS = 0)

	BEGIN

	UPDATE [Select_Group].[Turno]
	SET estado = 2,
	cancelacion_idCancelacion = @idCanc
	WHERE 
	idTurno = @idTurno;

	UPDATE SELECT_GROUP.Agenda_Detalle
	SET
	estaCancelado = 1,
	cancelacion_idCancelacion = @idCanc
	WHERE
	idAgendaDetalle = @idAgDetalle;


	FETCH NEXT FROM turnos INTO @idTurno, @idAgDetalle;
	END;

	CLOSE turnos;
	DEALLOCATE turnos;

END

