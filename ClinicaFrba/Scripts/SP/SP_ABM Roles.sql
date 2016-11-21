/*baja rol*/

CREATE PROCEDURE SELECT_GROUP.BAJA_ROL(@ROL varchar(45)) AS 

BEGIN

UPDATE ROL SET
habilitado = 0
where nombre = @ROL


END 
GO
create procedure SELECT_GROUP.Habilitar_Rol(@ROL varchar(45)) as
begin
update Rol SET
habilitado = 1
where nombre = @ROL and habilitado = 0
end
go

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

CREATE PROCEDURE [SELECT_GROUP].[asignarRol](@ROL VARCHAR(45), @username VARCHAR(45))
AS
BEGIN



if exists ((SELECT * FROM SELECT_GROUP.Usuario_Por_Rol where usuario_username=@rol and rol_idRol=@rol

begin 
print('Ya existe la asignacion para el Usuario:'+@username'con el Rol:'+@rol)
return
end

begin
INSERT INTO SELECT_GROUP.Usuario_Por_Rol(@ROL,@username)
end


CREATE PROCEDURE [SELECT_GROUP].[desasignarRol](@ROL VARCHAR(45), @username VARCHAR(45))
AS
BEGIN

begin
DELETE FROM SELECT_GROUP.Usuario_Por_Rol(@username, @ROL)
WHERE rol_idROL = @ROL and usuario_username=@username

end























