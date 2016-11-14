
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Select_Group.sp_Alta_Nuevo_Turno(@idAgenda int, @fechaTurno datetime, @idAfiliado int)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT into Select_Group.Turno(idAgenda, fechaTurno,afiliado_idAfiliado,cancelacion_idCancelacion,estado,idDiagnostico)
	VALUES (@idAgenda, @fechaTurno,@idAfiliado, null, 0,null);
END
GO
