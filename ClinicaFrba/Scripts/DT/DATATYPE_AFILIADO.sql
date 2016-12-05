
USE [GD2C2016]
GO


CREATE TYPE Select_Group.dt_Afiliados AS TABLE

(
	nombre varchar(255) NOT NULL
	,apellido varchar(255) NOT NULL
	,tipoDNI varchar(45) NOT NULL
	,DNI numeric(18,0) NOT NULL
	,telefono numeric (18,0) NOT NULL
	,mail varchar(255) NOT NULL
	,fechaNac datetime NOT NULL
	,sexo varchar(45) NOT NULL
	,estadoCivil varchar(45) NOT NULL
	,direccion varchar(255) NOT NULL
	,idUsuario varchar(45) NOT NULL
	,idPlan numeric(18,0) NOT NULL
)
GO
