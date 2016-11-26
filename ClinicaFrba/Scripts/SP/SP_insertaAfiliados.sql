SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Select_Group.sp_AltaAfiliado 

					(@Afiliados Select_Group.dt_Afiliados READONLY)
	
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		INSERT Select_Group.Afiliado
				(nombre, apellido, tipoDni, numeroDni, telefono, mail, fechaNac, sexo, estadoCivil, direccion, idUsuario, plan_idPlan)
				SELECT * FROM @Afiliados

	END TRY

	BEGIN CATCH

		DECLARE @MensajeError nvarchar(4000) = ERROR_MESSAGE(), @ErrNum INT = ERROR_NUMBER(), @ErrProc nvarchar(126) = ERROR_PROCEDURE();

		DECLARE @DatosError nvarchar(4000) = 'Hubo un error al insertar los datos en la tabla Afiliados'
		+ @MensajeError
		RAISERROR (@DatosError, 16,1)

	END CATCH

    
END
GO
