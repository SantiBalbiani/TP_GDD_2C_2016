
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Select_Group.sp_registrar_llegada (@idBono int, @idTurno int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

BEGIN TRAN

   UPDATE Select_Group.Bono
   Set estado = 0
   WHERE idBono = @idBono

   UPDATE Select_Group.Turno
   Set estado = 4
   WHERE idTurno = @idTurno

COMMIT TRAN

END
GO
