USE [GD2C2016]
GO
/****** Object:  StoredProcedure [Select_Group].[sp_Reservar_Turno]    Script Date: 29/11/2016 8:31:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Select_Group].[sp_Reservar_Turno](@idAgenda int, @fechaHoraTurno datetime, @userName VARCHAR(45), @especialidad int )
	
AS
BEGIN
BEGIN TRANSACTION RESERVARTURNO
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @idUser int;
	DECLARE @nroAfiliado int;
	DECLARE @idTurno int;


    -- Insert statements for procedure here

	set @idUser = (SELECT idUsuario FROM Select_Group.Usuario WHERE Usuario.nombreUsuario = @userName);

	set @nroAfiliado = (SELECT idAfiliado FROM Select_Group.Afiliado WHERE idUsuario = @idUser);

	set @idTurno = 1;

	set @idTurno = @idTurno +(Select isnull(max(idTurno),0) FROM Select_Group.Turno);

	 INSERT into Select_Group.Turno(idTurno, idAgenda, fechaTurno,afiliado_idAfiliado,cancelacion_idCancelacion,estado,idDiagnostico, especialidad)
	VALUES (@idTurno, @idAgenda, @fechaHoraTurno,@nroAfiliado, null, 3,null, @especialidad);

	INSERT into Select_Group.Agenda_Detalle(fecha_Hora_Turno, estaCancelado, idAgenda)
	VALUES (@fechaHoraTurno,0,@idAgenda);

COMMIT TRANSACTION RESERVARTURNO
END
