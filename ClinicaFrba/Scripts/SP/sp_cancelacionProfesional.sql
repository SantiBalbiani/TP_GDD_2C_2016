
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Select_Group.sp_cancelacionProfesional(@Motivo varchar(45), @tipoMot int, @idProf int, @fechaDesde datetime, @fechaHasta datetime)
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE turnos CURSOR FOR
	SELECT T.idTurno
	FROM Select_Group.Agenda A
	JOIN Select_Group.Turno T ON T.idAgenda = A.idAgenda
	WHERE A.profesional_IdProfesional = @idProf
	AND T.fechaTurno BETWEEN @fechaDesde AND @fechaHasta

	
	declare @idCanc int;
	declare @idTurno int;

	INSERT INTO Select_Group.Cancelacion(motivo, tipo_Cancelacion_idTipoCanc)
	VALUES(@Motivo, @tipoMot);

	SET @idCanc = (SELECT max(idCancelacion) FROM Select_Group.Cancelacion);


	FETCH NEXT turnos INTO @idTurno;

	WHILE (@@FETCH_STATUS = 0)

	BEGIN

	UPDATE [Select_Group].[Turno]
	SET estado = 2,
	cancelacion_idCancelacion = @idCanc
	WHERE 
	idTurno = @idTurno;


	FETCH NEXT turnos INTO @idTurno;
	END

END
GO
