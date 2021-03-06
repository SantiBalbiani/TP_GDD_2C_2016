USE [GD2C2016]
GO
/****** Object:  Trigger [Select_Group].[RegistrarBonos]    Script Date: 05/12/2016 18:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================================
--TIPO		: Trigger
--NOMBRE	: RegistrarBonos
--OBJETIVO  : Crea una cantidad de registros(Bonos) igual al campo "unidades" de la tabla Compras.                                     
--=============================================================================================================

CREATE TRIGGER [Select_Group].[RegistrarBonos] ON [Select_Group].[Compras]
AFTER INSERT
AS

BEGIN TRAN
DECLARE @contador int;
DECLARE @nroConsulta int;
DECLARE @idPlan int;
DECLARE @idCompra int;
DECLARE @fechacompra datetime;
DECLARE @idAfiliado int;
DECLARE @unidades int;
DECLARE @monto int;
SET @contador = '0';

DECLARE CompraDeBonos CURSOR FOR
SELECT * FROM inserted

OPEN CompraDeBonos;
FETCH NEXT FROM CompraDeBonos into @idCompra,@fechacompra,@idAfiliado,@unidades,@monto;
WHILE (@@FETCH_STATUS = 0)
BEGIN

set @idPlan = (SELECT TOP 1 plan_idPlan FROM Select_Group.Afiliado WHERE idAfiliado = @idAfiliado);
	
	WHILE(@contador < @unidades )
	
	BEGIN
		set @nroConsulta = (SELECT isnull((max(numero_consulta)),0) FROM Select_Group.Bono WHERE idAfiliado = @idAfiliado);
		set @nroConsulta = @nroConsulta + 1;
		
		Insert into Select_Group.Bono(idCompra,idPlan,idAfiliado,numero_Consulta,estado,bonoConsulta_FechaImpresion)
		Values(@idCompra, @idPlan, @idAfiliado,@nroConsulta ,'1',@fechacompra);
		set @contador = @contador + 1;
	END;
	FETCH NEXT FROM CompraDeBonos into @idCompra,@fechacompra,@idAfiliado,@unidades,@monto;
END;


CLOSE CompraDeBonos;
DEALLOCATE CompraDeBonos;

COMMIT TRAN
