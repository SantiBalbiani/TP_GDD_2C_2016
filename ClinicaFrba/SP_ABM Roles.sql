/*baja rol*/

CREATE PROCEDURE SELECT_GROUP.BAJA_ROL(@ROL INT) AS 

BEGIN

UPDATE ROL SET
habilitado = 0
where idRol = @ROL

/*UPDATE SELECT_GROUP.USUARIO_POR_ROL SET

FROM Select_group.USUARIO_POR_ROL UPR, Select_group.USUARIO U 
WHERE U.username = UPR.usuario_username AND UPR.rol_idRol=@ROL
*/
END 
GO
/*----------------------------*/
/*crear rol*/

CREATE PROCEDURE [SELECT_GROUP].[CrearRol](@ROL_DESCRIP VARCHAR(45), @FUNCIONALIDAD_DESCIP VARCHAR(45))
AS
BEGIN


	DECLARE @rol int;
	DECLARE @FUNCIONALIDAD int;
	DECLARE @idUser int;

	
	/*set @idUser = (SELECT idUsuario FROM Select_Group.Usuario WHERE Usuario.nombreUsuario = @userName);*/


	Insert into SELECT_GROUP.Rol(nombre,habilitado)
	select @ROL_DESCRIP, 1
	WHERE not (@ROL_DESCRIP = (select nombre from SELECT_GROUP.Rol));

	/*Insert into SELECT_GROUP.Usuario_por_Rol(idRol,userName(
	Values(@rol,@idUser)*/
	
	Insert into Select_Group.Funcionalidad(descripcion)
	values(@FUNCIONALIDAD_DESCIP)

	Insert into Select_Group.Funcionalidad_Por_Rol(rol_idRol,funcionalidad_idFuncionalidad)
	select (select idRol from SELECT_GROUP.Rol where @ROL_DESCRIP = nombre), (select idFuncionalidad from SELECT_GROUP.Funcionalidad where @FUNCIONALIDAD_DESCIP = descripcion)



END
go

CREATE PROCEDURE [SELECT_GROUP].[ModificarRol](@ROL_DESCRIP VARCHAR(45), @FUNCIONALIDAD_QUITAR VARCHAR(45), @FUNCIONALIDAD_AGREGAR VARCHAR(45))
AS
BEGIN

UPDATE Rol set
nombre = @ROL_DESCRIP

insert into SELECT_GROUP.Funcionalidad(descripcion)
SELECT @FUNCIONALIDAD_AGREGAR

delete from SELECT_GROUP.Funcionalidad_Por_Rol
where ((select idRol from SELECT_GROUP.Rol where nombre = @ROL_DESCRIP ) = rol_idRol) AND ((select idFuncionalidad from SELECT_GROUP.Funcionalidad where descripcion = @FUNCIONALIDAD_QUITAR) = funcionalidad_idFuncionalidad)


insert into SELECT_GROUP.Funcionalidad_Por_Rol(rol_idRol,funcionalidad_idFuncionalidad)
values ((select idRol from SELECT_GROUP.Rol where nombre = @ROL_DESCRIP),(select idFuncionalidad from SELECT_GROUP.Funcionalidad where descripcion = @FUNCIONALIDAD_AGREGAR))

END
go