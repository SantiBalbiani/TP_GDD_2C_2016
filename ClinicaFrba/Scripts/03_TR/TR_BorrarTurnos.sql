
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER Select_Group.BorrarTurnos 
   ON Select_Group.Afiliado 
   FOR UPDATE
AS 
BEGIN
	
	SET NOCOUNT ON;

DECLARE @idAfiliado numeric(7,0);

    if(update(fechaBaja))
	BEGIN
	
	SET @idAfiliado = (SELECT TOP 1 idAfiliado FROM inserted);

	UPDATE Select_Group.Turno
	SET estado = 2
	WHERE afiliado_idAfiliado = @idAfiliado

	END

END
GO
