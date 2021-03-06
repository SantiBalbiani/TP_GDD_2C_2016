USE [GD2C2016]
GO
/****** Object:  StoredProcedure [Select_Group].[ComprarBono]    Script Date: 09/12/2016 23:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================================
--TIPO		: Procedure
--NOMBRE	: ComprarBono
--OBJETIVO  : Crear un registro en la tabla compras.                                     
--=============================================================================================================
CREATE PROCEDURE [Select_Group].[ComprarBono](@userName VARCHAR(45), @cantidad INT, @fechaActual datetime)
AS
BEGIN
BEGIN TRAN
	DECLARE @nroAfiliado int;
	DECLARE @contador int;
	DECLARE @idPlan int;
	DECLARE @precio int;
	DECLARE @idCompra int;
	DECLARE @nroConsulta int;
	DECLARE @idUser int;
	
	set @idUser = (SELECT idUsuario FROM Select_Group.Usuario WHERE Usuario.nombreUsuario = @userName);

	set @nroAfiliado = (SELECT idAfiliado FROM Select_Group.Afiliado WHERE idUsuario = @idUser);

	set @idPlan = (SELECT TOP 1 plan_idPlan FROM Select_Group.Afiliado WHERE idAfiliado = @nroAfiliado);

	set @precio = (SELECT precioDelBono_Consulta FROM Select_Group.Plan_Med WHERE Select_Group.Plan_Med.idPlan = @idPlan );

	Insert into Select_Group.Compras(FechaCompra,afiliado_Comprador,unidades,monto)
	Values(@fechaActual, @nroAfiliado, @cantidad, (@precio * @cantidad));



	

COMMIT TRAN

END
