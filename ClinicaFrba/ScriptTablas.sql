BEGIN TRANSACTION creacionTablas
use GD2C2016
GO
Create schema SELECT_GROUP
GO

create table SELECT_GROUP.Plann(
	idPlan numeric(18,0) not null,
	descripcion varchar(255),
	precioDelBono_Consulta numeric(18,0),
	precioDelBono_Farmacia numeric(18,0),
	primary key(idPlan)
)

create table SELECT_GROUP.Rol(
	idRol numeric(6,0) identity(1,1) not null,
	nombre varchar(45),
	habilitado bit,
	CONSTRAINT pk_IdRol primary key (idRol)
)

create table SELECT_GROUP.Usuario(
	username numeric(6,0) identity(1,1) not null,
	nombreUsuario varchar(45),
	contraseña varbinary(45),
	intentosFallidos numeric(1,0),
	habilitado bit,
	CONSTRAINT pk_IdUsername primary key (username),
)
create table SELECT_GROUP.Usuario_Por_Rol(
	rol_idRol numeric(6,0),
	usuario_username numeric(6,0)
	CONSTRAINT fk_Usuario_PorRol foreign key (usuario_username) references SELECT_GROUP.Usuario (username),
	CONSTRAINT fk_Rol_idRol foreign key (rol_idRol) references SELECT_GROUP.Rol (idRol)
)

create table SELECT_GROUP.Afiliado(
	idAfiliado numeric(7,0) identity(1,1) not null,
	nombre varchar(255),
	apellido varchar(255),
	tipoDni varchar(45),
	numeroDni numeric(18,0) unique,
	telefono numeric(18,0),
	mail varchar(255),
	fechaNac datetime,
	sexo varchar(45),
	estadoCivil varchar(45),
	direccion varchar(255),
	familiares varchar(45),
	username numeric(6,0) unique,
	plan_idPlan numeric(18,0),
	CONSTRAINT pk_IdAfiliado primary key(idAfiliado),
	CONSTRAINT fk_Afiliado_Usuario foreign key (username) references SELECT_GROUP.Usuario (username),
	CONSTRAINT fk_Afiliado_Plann foreign key (plan_idPlan) references SELECT_GROUP.Plann (idPlan)
	)

create table SELECT_GROUP.Tipo_Especialidad(
	idTipo numeric(18,0) identity(1,1) not null,
	descripcion varchar(255),
	CONSTRAINT pk_IdTipoEspecialidad primary key (idTipo)
)
create table SELECT_GROUP.Especialidad(
	idEspecialidad numeric(18,0) identity(1,1) not null,
	tipoEspecialidad_idTipoEspecialidad numeric(18,0),
	descripcion varchar(255),
	CONSTRAINT pk_IdEspecialidad primary key (idEspecialidad),
	CONSTRAINT fk_Especialidad_TipoEspecialidad foreign key (tipoEspecialidad_idTipoEspecialidad) references SELECT_GROUP.Tipo_Especialidad (idTipo)
)

create table SELECT_GROUP.Profesional(
	matricula numeric(7,0) identity(1000,1) not null,
	nombre varchar(255),
	apellido varchar(255),
	numeroDni numeric(18,0),
	telefono numeric(18,0),
	direccion varchar(255),
	mail varchar(255),
	fechaNac datetime,
	sexo varchar(45),
	username numeric(6,0) unique,
	CONSTRAINT pk_IdProfesional primary key(matricula),
	CONSTRAINT fk_Profesional_Usuario foreign key (username) references SELECT_GROUP.Usuario (username),
)
create table SELECT_GROUP.Profesional_Por_Especialidad(
	especialidad_idEspecialidad numeric(18,0), 
	profesional_idProfesional numeric(7,0),
	CONSTRAINT fk_ProfesionalPorEspecialidad_Especailidad foreign key (especialidad_idEspecialidad) references SELECT_GROUP.Especialidad (idEspecialidad),
	CONSTRAINT fk_ProfesonalPorEspecialidad_Profesional foreign key (profesional_idProfesional) references SELECT_GROUP.Profesional (matricula)
)
create table SELECT_GROUP.Funcionalidad(
	idFuncionalidad numeric(6,0) identity(1,1) not null,
	descripcion varchar(45),
	CONSTRAINT pk_IdFuncionalidad primary key (idFuncionalidad)
)
create table SELECT_GROUP.Funcionalidad_Por_Rol(
	rol_idRol numeric(6,0),
	funcionalidad_idFuncionalidad numeric(6,0)
	CONSTRAINT fk_FuncionalidadPorRol_Funcionalidad foreign key (funcionalidad_idFuncionalidad) references SELECT_GROUP.Funcionalidad (idFuncionalidad),
	CONSTRAINT fk_FuncionalidadPorRol_idRol foreign key (rol_idRol) references SELECT_GROUP.Rol (idRol)
		)

create table SELECT_GROUP.Compras(
	idCompra numeric(6,0),
	compra_bono_fecha datetime,
	usuario_Comprador numeric(6,0),
	unidades int,
	monto money,
	CONSTRAINT pk_IdCompras primary key (idCompra),
	CONSTRAINT fk_Compras_Usuario foreign key(usuario_Comprador) references SELECT_GROUP.Usuario (username)
)

create table SELECT_GROUP.Diagnostico(
	idDiagnostico numeric(6,0) identity(1,1) not null,
	sintomas varchar(255),
	enfermedades varchar(255),
	fechaYHora datetime,
	CONSTRAINT pk_IdDiagnostico primary key (idDiagnostico)
)
create table SELECT_GROUP.Bono_Por_Afiliado(
	numero_Consulta numeric(6,0),
	afiliado_idAfiliado numeric(7,0),
	/*afiliado_usuario_username numeric(6,0), para mi no (duplicacion con el id afiliado)*/
	bono_idBono numeric(6,0),
	estado bit,
	CONSTRAINT pk_IdConsulta primary key (numero_Consulta),
	CONSTRAINT fk_BonoPorAfiliado_Afiliado foreign key (afiliado_idAfiliado) references SELECT_GROUP.Afiliado (idAfiliado),
	)
create table SELECT_GROUP.Bono( 
	idBono numeric(18,0) identity(1,1) not null,
	idCompra numeric(6,0),
	idPlan numeric(18,0),
	estado bit,
	bonoConsulta_FechaImpresion datetime,
	CONSTRAINT pk_IdBono primary key (idBono),
	CONSTRAINT fk_Bono_Compra foreign key (idCompra) references SELECT_GROUP.Compras (idCompra),
	CONSTRAINT fk_Bono_Plan foreign key (idPlan) references SELECT_GROUP.Plann (idPlan)
)

create table SELECT_GROUP.Tipo_Cancelacion(
	idTipoCanc numeric(6,0),
	descripcion varchar(45),
	CONSTRAINT pk_IdTipoCancelacion primary key (idTipoCanc)
)

create table SELECT_GROUP.Cancelacion(
	idCancelacion numeric(6,0) identity(1,1) not null,
	motivo varchar(45),
	tipo_Cancelacion_idTipoCanc numeric(6,0),
	bono_idBono numeric(18,0),
	CONSTRAINT pk_IdCancelacion primary key (idCancelacion),
	CONSTRAINT fk_Cancelacion_TipoCancelacion foreign key (tipo_Cancelacion_idTipoCanc) references SELECT_GROUP.Tipo_Cancelacion (idTipoCanc),
	CONSTRAINT fk_Cancelacion_Bono foreign key (bono_idBono) references SELECT_GROUP.Bono (idBono)
)

create table SELECT_GROUP.Plan_Historico(
	idPlanNuevo numeric(6,0) identity(1,1) not null,
	motivoCambio varchar(45),
	fechaCambio datetime,
	planAnterior numeric(6,0),
	afiliado_idAfiliado numeric(7,0),
	CONSTRAINT pk_idPlanHistorico primary key(idPlanNuevo),
	CONSTRAINT fk_PlanHistorico_PlanHistorico foreign key (planAnterior) references SELECT_GROUP.Plan_Historico (idPlanNuevo),
	CONSTRAINT fk_PlanHistorico_Afiliado foreign key (afiliado_idAfiliado) references SELECT_GROUP.Afiliado (idAfiliado)

)

create table SELECT_GROUP.Agenda(
	idAgenda numeric(6,0) identity(1,1) not null,
	profesional_IdProfesional numeric(7,0),
	diaDisponible int,
	horaDesde int,
	horaHasta varchar(45),
	CONSTRAINT pk_IdAgenda primary key (idAgenda),
	CONSTRAINT fk_Agenda_IdProfesional foreign key (profesional_IdProfesional) references SELECT_GROUP.Profesional (matricula)
)


create table SELECT_GROUP.Agenda_Detalle(
	idAgenda numeric(6,0) identity(1,1) not null,
	fecha_Hora_Turno datetime,
	estaCancelado bit,
	primary key (idAgenda),

	)

create table SELECT_GROUP.Estado_Turno(
	idEstadoTurno numeric(6,0) identity(1,1) not null,
	descripcion varchar(45),
	CONSTRAINT pk_idEstadoTurno primary key (idEstadoTurno)
)

create table SELECT_GROUP.Turno(
	idTurno numeric(18,0) identity(1,1) not null,
	idAgenda numeric(6,0),
	fechaTurno datetime,
	afiliado_idAfiliado numeric(7,0),
	cancelacion_idCancelacion numeric(6,0),
	estado numeric(6,0),
	idDiagnostico numeric(6,0),
	CONSTRAINT pk_IdTurno primary key (idTurno),
	CONSTRAINT fk_Turno_Agenda foreign key (idAgenda) references SELECT_GROUP.Agenda (idAgenda),
	CONSTRAINT fk_Turno_Afiliado foreign key (afiliado_idAfiliado) references SELECT_GROUP.Afiliado (idAfiliado),
	CONSTRAINT fk_Turno_Cancelacion foreign key (cancelacion_idCancelacion) references SELECT_GROUP.Cancelacion (idCancelacion),
	CONSTRAINT fk_Turno_Estado foreign key (estado) references SELECT_GROUP.Estado_Turno (idEstadoTurno),
	CONSTRAINT fk_Turno_Diagnostico foreign key (idDiagnostico) references SELECT_GROUP.Diagnostico (idDiagnostico)

)

COMMIT TRANSACTION creacionTablas

BEGIN TRANSACTION MigracionDeDatos
/*Cargo tabla ROL*/
INSERT INTO	SELECT_GROUP.Rol (nombre, habilitado) VALUES
		('Afiliado',1),
		('Administrativo', 1),
		('Profesional',1);
/*Cargo tabla Funcion*/		
INSERT INTO SELECT_GROUP.Funcionalidad(descripcion) VALUES
		('Anunciarse'),
		('Comprar_Bono'),
		('Cancelar_Turno'),
		('Atender'),
		('ABM_Rol'),
		('Listado_Estadistico'),
		('ABM_Usuarios'),
		('Reservar Turno'),
		('Abandonar Consultorio');

/*Cargo tabla ROL_funcion (tabla intermedia)*/
INSERT INTO SELECT_GROUP.Funcionalidad_Por_Rol(rol_idRol,funcionalidad_idFuncionalidad) VALUES
		(1,1),
		(1,2),
		(1,3),
		(1,8),
		(1,9),
		(3,4),
		(3,3),
		(2,5),
		(2,7);

/*Cargo usuario Admin pedido por catedra */ 
INSERT INTO SELECT_GROUP.Usuario(nombreUsuario,contraseña,intentosFallidos,habilitado) values
('admin', HASHBYTES('SHA2_256','w23e'),0,1);

/*Cargo tabla de Usuario_Por_Rol para admin*/
insert into SELECT_GROUP.Usuario_Por_Rol(rol_idRol,usuario_username) values
(2,1);


/*Cargo los usuarios pertenecientes a los Afiliados */
INSERT INTO SELECT_GROUP.Usuario(nombreUsuario,contraseña,intentosFallidos,habilitado)
select distinct cast(Paciente_Dni as varchar(45)), HASHBYTES('SHA2_256',Paciente_Apellido),0,1
from gd_esquema.Maestra
where Paciente_Dni is not null
order by cast(Paciente_Dni as varchar(45));

COMMIT TRANSACTION MigracionDeDatos

/*Cargo los demas roles para afiliado */
insert into SELECT_GROUP.Usuario_Por_Rol(usuario_username) 
select distinct U.username
from SELECT_GROUP.Usuario U
inner join gd_esquema.Maestra M
on cast(M.Paciente_Dni as varchar(45)) = U.nombreUsuario
Select * from SELECT_GROUP.Usuario_Por_Rol

update SELECT_GROUP.Usuario_Por_Rol
set rol_idRol = (select idRol where nombre = 'Afiliado')
from SELECT_GROUP.Rol
where rol_idRol is NULL


/*Cargo los usuarios pertenecientes a los profesionales */
INSERT INTO SELECT_GROUP.Usuario(nombreUsuario,contraseña,intentosFallidos,habilitado)
select distinct cast(Medico_Dni as varchar(45)), HASHBYTES('SHA2_256',Medico_Apellido),0,1
from gd_esquema.Maestra
where Medico_Dni is not null
order by cast(Medico_Dni as varchar(45))

/* Cargo los roles para los profesionales */
insert into SELECT_GROUP.Usuario_Por_Rol(usuario_username) 
select distinct U.username
from SELECT_GROUP.Usuario U
inner join gd_esquema.Maestra M
on cast(M.Medico_Dni as varchar(45)) = U.nombreUsuario

update SELECT_GROUP.Usuario_Por_Rol
set rol_idRol = (select idRol where nombre = 'Profesional')
from SELECT_GROUP.Rol
where rol_idRol is NULL

/*Cargo los planes de la tabla maestra */
INSERT INTO SELECT_GROUP.Plann(idPlan,descripcion,precioDelBono_Consulta,precioDelBono_Farmacia)
SELECT distinct Plan_Med_Codigo,Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia 
from gd_esquema.Maestra
order by Plan_Med_Codigo

/*Cargo los diagnosticos de la tabla maestra*/
INSERT INTO SELECT_GROUP.Diagnostico(sintomas,enfermedades,fechaYHora)
SELECT distinct Consulta_Enfermedades,Consulta_Sintomas, (CONVERT (date,GETDATE()))
from gd_esquema.Maestra
where Consulta_Enfermedades is not null

/*Cargo los afiliados de la tabla maestra */
INSERT INTO SELECT_GROUP.Afiliado(numeroDni,nombre,apellido,tipoDni,telefono,mail,fechaNac,sexo,estadoCivil,direccion,familiares,username,plan_idPlan)
SELECT distinct Paciente_Dni,Paciente_Nombre,Paciente_Apellido,'DNI',Paciente_Telefono,Paciente_mail,Paciente_Fecha_Nac,'SEXO','EC',Paciente_Direccion,'Familiares',(select username from SELECT_GROUP.Usuario where nombreUsuario = (cast(Paciente_Dni as varchar(45)))),(select idPlan from SELECT_GROUP.Plann where idPlan = 555555) 
from gd_esquema.Maestra
where Paciente_Dni is not null
order by Paciente_Nombre

/*Cargo los Profesionales de la tabla maestra */
INSERT INTO SELECT_GROUP.Profesional(numeroDni,nombre,apellido,telefono,direccion,mail,fechaNac,sexo,username)
SELECT distinct Medico_Dni,Medico_Nombre,Medico_Apellido,Medico_Telefono,Medico_Direccion,Medico_Mail,Medico_Fecha_Nac,'Sexo', (select username from SELECT_GROUP.Usuario where nombreUsuario = (cast(Medico_Dni as varchar(45))))
from gd_esquema.Maestra
where Medico_Dni is not null
order by Medico_Dni

/*
select distinct Turno_Numero,Turno_Fecha from gd_esquema.Maestra
where Turno_Numero is not null
order by Turno_Fecha

INSERT INTO SELECT_GROUP.Especialidad(idEspecialidad,tipoEspecialidad_idTipoEspecialidad,descripcion)
SELECT distinct Especialidad_Codigo,'TipoEspecialidad',Especialidad_Descripcion from gd_esquema.Maestra
where Especialidad_Codigo is not null

INSERT INTO SELECT_GROUP.Tipo_Especialidad(idTipo,descripcion)
SELECT distinct Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion from gd_esquema.Maestra
where Tipo_Especialidad_Codigo is not null

INSERT INTO SELECT_GROUP.Turno(idTurno,idAgenda,fechaTurno,afiliado_idAfiliado,cancelacion_idCancelacion,estado,idDiagnostico) 
SELECT distinct Turno_Numero,'AGENDA',Turno_Fecha,'AFILIADO','CANCELACION','ESTADO','DIAGNOSTICO' from gd_esquema.Maestra
where Turno_Numero is not null

INSERT INTO SELECT_GROUP.Compras(compra_bono_fecha,usuario_Comprador,unidades,monto)
SELECT distinct Compra_Bono_fecha,'Usuario','Monto' from gd_esquema.Maestra
where Compra_Bono_Fecha is not null

INSERT INTO SELECT_GROUP.Bono(idBono,idCompra,idPlan,estado,bonoConsulta_FechaImpresion)
SELECT distinct Bono_Consulta_Numero,'Compra','Plan','Estado',Bono_Consulta_Fecha_Impresion from gd_esquema.Maestra
where Bono_Consulta_Numero is not null
*/

