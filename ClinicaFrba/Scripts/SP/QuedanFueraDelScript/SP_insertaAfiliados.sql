drop PROCEDURE Select_Group.sp_AltaAfiliado 


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

CREATE TYPE afiliado as Table (nombre VARCHAR(255), apellido VARCHAR(255),tipoDni VARCHAR(45),numeroDni NUMERIC(18,0),
								telefono NUMERIC(18,0),mail VARCHAR(255),fechaNac datetime,sexo varchar(45), estadoCivil VARCHAR(45),direccion VARCHAR(255), planMed NUMERIC(18,0),idUsuario NUMERIC(6,0))

GO
CREATE PROCEDURE Select_Group.sp_AltaAfiliado 
					(@Afiliados afiliado READONLY)
	
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		INSERT Select_Group.Afiliado
				(nombre, apellido, tipoDni, numeroDni, telefono, mail, fechaNac, sexo, estadoCivil, direccion,plan_idPlan,idUsuario)
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
