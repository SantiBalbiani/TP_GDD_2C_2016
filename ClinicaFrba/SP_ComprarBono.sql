USE [GD2C2016]
GO

CREATE PROCEDURE [Select_Group].[ComprarBono](@userName VARCHAR(45), @cantidad INT)
AS
BEGIN
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
	
	set @idUser = (SELECT idUsuario FROM Select_Group.Usuario WHERE Usuario.nombreUsuario = @userName);

	set @nroAfiliado = (SELECT idAfiliado FROM Select_Group.Afiliado WHERE idUsuario = @idUser);

	set @idPlan = (SELECT TOP 1 plan_idPlan FROM Select_Group.Afiliado WHERE idAfiliado = @nroAfiliado);

	set @precio = (SELECT precioDelBono_Consulta FROM Select_Group.Plan_Med WHERE Select_Group.Plan_Med.idPlan = @idPlan );

	Insert into Select_Group.Compras(FechaCompra,afiliado_Comprador,unidades,monto)
	Values(@fechaActual, @nroAfiliado, @cantidad, (@precio * @cantidad));



	

COMMIT TRAN

END
