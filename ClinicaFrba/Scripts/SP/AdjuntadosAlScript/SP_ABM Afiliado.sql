CREATE PROCEDURE [SELECT_GROUP].[AltaAfiliado](@Afiliado_nombre VARCHAR(255), @Afiliado_Apellido VARCHAR(255),@Afiliado_tipoDni VARCHAR(45), 
												@Afiliado_numeroDni NUMERIC(18,0),@Afiliado_telefono NUMERIC(18,0),@Afiliado_mail VARCHAR(255),
												@Afiliado_fechaNac datetime,@Afiliado_Sexo varchar(45), @Afiliado_EstadoCivil VARCHAR(45), 
												@Afiliado_Direccion VARCHAR(255))
AS
BEGIN
	Insert into SELECT_GROUP.Afiliado(nombre,apellido,tipoDni,numeroDni,telefono,mail,fechaNac,sexo,estadoCivil,direccion) values
	(@Afiliado_nombre, @Afiliado_Apellido,@Afiliado_tipoDni, @Afiliado_numeroDni,@Afiliado_telefono,@Afiliado_mail,@Afiliado_fechaNac,
	@Afiliado_Sexo, @Afiliado_EstadoCivil, @Afiliado_Direccion)
END
go


