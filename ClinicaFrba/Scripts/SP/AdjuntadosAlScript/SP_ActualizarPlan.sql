
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SELECT_GROUP.ActualizarPlan(@idPlan int,@idAfiliado int)
		
AS

BEGIN
	SET NOCOUNT ON;

	UPDATE Select_Group.Afiliado
		Set plan_idPlan = @idPlan
		Where idAfiliado = @idAfiliado

END
GO
