USE [GD2C2016]
GO
/****** Object:  StoredProcedure [Select_Group].[sp_Reservar_Turno]    Script Date: 29/11/2016 2:14:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Select_Group].[sp_Reservar_Turno](@idAgenda int, @fechaHoraTurno datetime, @userName VARCHAR(45) )
	
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

	set @idTurno = ((Select max(idTurno) FROM Select_Group.Turno)+1);

	 INSERT into Select_Group.Turno(idTurno, idAgenda, fechaTurno,afiliado_idAfiliado,cancelacion_idCancelacion,estado,idDiagnostico)
	VALUES (@idTurno, @idAgenda, @fechaHoraTurno,@nroAfiliado, null, 3,null);

	INSERT into Select_Group.Agenda_Detalle(fecha_Hora_Turno, estaCancelado, idAgenda)
	VALUES (@fechaHoraTurno,0,@idAgenda);

COMMIT TRANSACTION RESERVARTURNO
END
