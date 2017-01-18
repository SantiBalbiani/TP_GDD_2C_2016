SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

GO
CREATE PROCEDURE Select_Group.sp_CrearUsuario 
					(@Dni numeric(18,0))
	
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		INSERT into Select_Group.Usuario
				(nombreUsuario, contraseña, intentosFallidos, habilitado) values
				(cast(@Dni as varchar(45)), HASHBYTES('SHA2_256',cast(@Dni as varchar(45))),0,1)



	END TRY

	BEGIN CATCH

		DECLARE @MensajeError nvarchar(4000) = ERROR_MESSAGE(), @ErrNum INT = ERROR_NUMBER(), @ErrProc nvarchar(126) = ERROR_PROCEDURE();

		DECLARE @DatosError nvarchar(4000) = 'Hubo un error al insertar los datos en la tabla Usuario'
		+ @MensajeError
		RAISERROR (@DatosError, 16,1)

	END CATCH

    
END
GO
