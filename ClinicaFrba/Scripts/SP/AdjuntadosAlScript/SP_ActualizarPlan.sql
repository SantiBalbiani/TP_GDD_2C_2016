USE [GD2C2016]
GO
/****** Object:  StoredProcedure [Select_Group].[ActualizarPlan]    Script Date: 06/12/2016 0:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: ActualizarPlan
--OBJETIVO  : Actualiza el plan de un afiliado.                                     
--=============================================================================================================

CREATE PROCEDURE [Select_Group].[ActualizarPlan](@idPlan int,@idAfiliado int)
		
AS

BEGIN
	SET NOCOUNT ON;

	UPDATE Select_Group.Afiliado
		Set plan_idPlan = @idPlan
		Where nroAfiliado = @idAfiliado

END
