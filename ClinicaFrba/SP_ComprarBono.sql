USE [GD2C2016]
GO
/****** Object:  StoredProcedure [Select_Group].[ComprarBono]    Script Date: 06/11/2016 19:26:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Select_Group].[ComprarBono](@userName VARCHAR, @cantidad INT)
AS

BEGIN TRAN
	DECLARE @nroAfiliado int;
	DECLARE @contador int;
	DECLARE @fechaActual datetime;
	DECLARE @idPlan int;
	DECLARE @precio int;
	DECLARE @idCompra int;
	DECLARE @nroConsulta int;
	DECLARE @idUser int;

	set @fechaActual = sysdatetime();
	
	set @idUser = (SELECT idUsuario FROM Usuario WHERE Usuario.nombreUsuario = @userName);

	set @nroAfiliado = (SELECT TOP 1 idAfiliado FROM Select_Group.Afiliado WHERE idUsuario = @idUser);

	set @idPlan = (SELECT TOP 1 plan_idPlan FROM Select_Group.Afiliado WHERE idUsuario = @idUser);

	set @precio = (SELECT precioDelBono_Consulta FROM Select_Group.Plan_Med WHERE Select_Group.Plan_Med.idPlan = @idPlan );

	Insert into Select_Group.Compras(FechaCompra,afiliado_Comprador,unidades,monto)
	Values(@fechaActual, @nroAfiliado, @cantidad, (@precio * @cantidad));

	SET @idCompra = @@IDENTITY;

	SET @contador = '0';

	
		WHILE(@contador < @cantidad )
	
	BEGIN
	set @nroConsulta = (SELECT (max(numero_consulta)+1) FROM Select_Group.Bono );
	Insert into Select_Group.Bono(idCompra,idPlan,idAfiliado,numero_Consulta,estado,bonoConsulta_FechaImpresion)
	Values(@idCompra, @idPlan, @nroAfiliado,@nroConsulta ,'1',@fechaActual);

	set @contador = @contador + 1;
	END

COMMIT TRAN


