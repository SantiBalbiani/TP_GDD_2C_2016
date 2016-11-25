SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Select_Group.sp_AltaAfiliado 

					(@Afiliados dt_Afiliados READONLY)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRY

		INSERT Select_Group.Afiliado
				(nombre, apellido, tipoDni, numeroDni, telefono, mail, fechaNac, sexo, estadoCivil, direccion, idUsuario, plan_idPlan)
				SELECT * FROM @Afiliados
    
END
GO
GO
