BEGIN TRANSACTION creacionTablas
use GD2C2016

GO

--create schema SELECT_GROUP
--GO


create table SELECT_GROUP.Plan_Med(
	idPlan numeric(18,0) not null,
	descripcion varchar(255),
	precioDelBono_Consulta numeric(18,0),
	precioDelBono_Farmacia numeric(18,0),
	CONSTRAINT pk_planMed primary key(idPlan)
)

create table SELECT_GROUP.Rol(
	idRol numeric(6,0) identity(1,1) not null,
	nombre varchar(45),
	habilitado bit,
	CONSTRAINT pk_IdRol primary key (idRol)
)

create table SELECT_GROUP.Usuario(
	idUsuario numeric(6,0) identity(1,1) not null,
	nombreUsuario varchar(45),
	contraseña varbinary(45),
	intentosFallidos numeric(1,0),
	habilitado bit,
	CONSTRAINT pk_IdUsername primary key (idUsuario),
	CONSTRAINT AK_nombreUsuario UNIQUE (nombreUsuario)
	
)
create table SELECT_GROUP.Afiliado(
	idAfiliado numeric(7,0) identity(1,1) not null,
	nroAfiliado numeric(10,0),
	nombre varchar(255),
	apellido varchar(255),
	tipoDoc varchar(45),
	numeroDoc numeric(18,0) unique,
	telefono numeric(18,0),
	mail varchar(255),
	fechaNac datetime,
	sexo varchar(45),
	estadoCivil varchar(45),
	cantidadHijos numeric(2,0),
	direccion varchar(255),
	idUsuario numeric(6,0) unique,
	plan_idPlan numeric(18,0),
	CONSTRAINT pk_IdAfiliado primary key(idAfiliado),
	CONSTRAINT fk_Afiliado_Usuario foreign key (idUsuario) references SELECT_GROUP.Usuario (idUsuario),
	CONSTRAINT fk_Afiliado_Plann foreign key (plan_idPlan) references SELECT_GROUP.Plan_Med (idPlan)
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
	idUsuario numeric(6,0) unique,
	CONSTRAINT pk_IdProfesional primary key(matricula),
	CONSTRAINT fk_Profesional_Usuario foreign key (idUsuario) references SELECT_GROUP.Usuario (idUsuario)
)

create table SELECT_GROUP.Usuario_Por_Rol(
	rol_idRol numeric(6,0),
	usuario_username numeric(6,0)
	CONSTRAINT fk_Usuario_PorRol foreign key (usuario_username) references SELECT_GROUP.Usuario (idUsuario),
	CONSTRAINT fk_Rol_idRol foreign key (rol_idRol) references SELECT_GROUP.Rol (idRol),
	primary key(rol_idRol,usuario_username)
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
	CONSTRAINT fk_FuncionalidadPorRol_idRol foreign key (rol_idRol) references SELECT_GROUP.Rol (idRol),
	primary key(rol_idRol,funcionalidad_idFuncionalidad)
)

create table SELECT_GROUP.Compras(
	idCompra numeric(6,0) identity(1,1),
	FechaCompra datetime,
	afiliado_Comprador numeric(7,0),
	unidades int,
	monto money,
	CONSTRAINT pk_IdCompras primary key (idCompra),
	CONSTRAINT fk_Compras_Usuario foreign key(afiliado_Comprador) references SELECT_GROUP.Afiliado (idAfiliado)
)

create table SELECT_GROUP.Diagnostico(
	idDiagnostico numeric(6,0) identity(1,1) not null,
	sintomas varchar(255),
	enfermedades varchar(255),
	fechaYHora datetime,
	CONSTRAINT pk_IdDiagnostico primary key (idDiagnostico)
)
create table SELECT_GROUP.Bono( 
	idBono numeric(18,0) identity(1,1) not null,
	idCompra numeric(6,0),
	idPlan numeric(18,0),
	idAfiliado numeric (7,0),
	numero_Consulta numeric(6,0),
	estado bit,
	bonoConsulta_FechaImpresion datetime,
	CONSTRAINT pk_IdBono primary key (idBono),
	CONSTRAINT fk_Bono_Afiliado foreign key (idAfiliado) references SELECT_GROUP.Afiliado (idAfiliado),
	CONSTRAINT fk_Bono_Compra foreign key (idCompra) references SELECT_GROUP.Compras (idCompra),
	CONSTRAINT fk_Bono_Plan foreign key (idPlan) references SELECT_GROUP.Plan_Med (idPlan)
)

create table SELECT_GROUP.Tipo_Cancelacion(
	idTipoCanc numeric(6,0) identity (1,1) primary key (idTipoCanc),
	descripcion varchar(45),
)

create table SELECT_GROUP.Cancelacion(
	idCancelacion numeric(6,0) identity(1,1) not null,
	motivo varchar(45),
	tipo_Cancelacion_idTipoCanc numeric(6,0),
	/*turno numeric(18,0),*/
	CONSTRAINT pk_IdCancelacion primary key (idCancelacion),
	CONSTRAINT fk_Cancelacion_TipoCancelacion foreign key (tipo_Cancelacion_idTipoCanc) references SELECT_GROUP.Tipo_Cancelacion (idTipoCanc),
	/*CONSTRAINT fk_Cancelacion_Turno foreign key (Turno) references SELECT_GROUP.Turno (idTurno)*/
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

create table SELECT_GROUP.Tipo_Especialidad(
	idTipo numeric(18,0) not null,
	descripcion varchar(255),
	CONSTRAINT pk_IdTipoEspecialidad primary key (idTipo)
)
create table SELECT_GROUP.Especialidad(
	idEspecialidad numeric(18,0) not null,
	idTipoEspecialidad numeric(18,0),
	descripcion varchar(255),
	CONSTRAINT pk_IdEspecialidad primary key (idEspecialidad),
	CONSTRAINT fk_Especialidad_TipoEspecialidad foreign key (idTipoEspecialidad) references SELECT_GROUP.Tipo_Especialidad (idTipo)
)

create table SELECT_GROUP.Profesional_Por_Especialidad(
	especialidad_idEspecialidad numeric(18,0), 
	profesional_idProfesional numeric(7,0),
	CONSTRAINT fk_ProfesionalPorEspecialidad_Especailidad foreign key (especialidad_idEspecialidad) references SELECT_GROUP.Especialidad (idEspecialidad),
	CONSTRAINT fk_ProfesonalPorEspecialidad_Profesional foreign key (profesional_idProfesional) references SELECT_GROUP.Profesional (matricula),
	primary key (especialidad_idEspecialidad,profesional_idProfesional)
)

create table SELECT_GROUP.Agenda(
	idAgenda numeric(6,0) identity(1,1) not null,
	profesional_IdProfesional numeric(7,0),
	diaDisponible int,
	horaDesde int,
	horaHasta int,
	CONSTRAINT pk_IdAgenda primary key (idAgenda),
	CONSTRAINT fk_Agenda_IdProfesional foreign key (profesional_IdProfesional) references SELECT_GROUP.Profesional (matricula)
)

create table SELECT_GROUP.Agenda_Detalle(
	idAgendaDetalle numeric(6,0) identity(1,1) not null,
	fecha_Hora_Turno datetime,
	estaCancelado bit,
	idAgenda numeric(6,0),
	constraint fk_AgendaDetalle_Agenda foreign key (idAgenda) references SELECT_GROUP.Agenda (idAgenda),
	primary key (idAgendaDetalle)
)

create table SELECT_GROUP.Estado_Turno(
	idEstadoTurno numeric(6,0) not null,
	descripcion varchar(45),
	CONSTRAINT pk_idEstadoTurno  primary key (idEstadoTurno)
)

create table SELECT_GROUP.Turno(
	idTurno numeric(18,0),  
	idAgenda numeric(6,0),
	fechaTurno datetime,
	afiliado_idAfiliado numeric(7,0),
	cancelacion_idCancelacion numeric(6,0),
	estado numeric(6,0),
	idDiagnostico numeric(6,0),
	especialidad numeric(18,0), 
	CONSTRAINT pk_IdTurno primary key (idTurno),
	CONSTRAINT fk_Turno_Agenda foreign key (idAgenda) references SELECT_GROUP.Agenda (idAgenda),
	CONSTRAINT fk_Turno_Afiliado foreign key (afiliado_idAfiliado) references SELECT_GROUP.Afiliado (idAfiliado),
	CONSTRAINT fk_Turno_Cancelacion foreign key (cancelacion_idCancelacion) references SELECT_GROUP.Cancelacion (idCancelacion),
	CONSTRAINT fk_Turno_Estado foreign key (estado) references SELECT_GROUP.Estado_Turno (idEstadoTurno),
	CONSTRAINT fk_Turno_Diagnostico foreign key (idDiagnostico) references SELECT_GROUP.Diagnostico (idDiagnostico),
	CONSTRAINT fk_ProfesionalXEspecialidad foreign key (especialidad) references SELECT_GROUP.Especialidad (idEspecialidad)
	
)

/*Cargo tabla ROL*/
INSERT INTO	SELECT_GROUP.Rol (nombre, habilitado) VALUES
		('Administrativo', 1),
		('Profesional',1),
		('Afiliado',1);

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
		(1,5),(1,6),(1,7), /*Usuario Administrativo funciones*/
		(2,3),(2,4),		/*Usuario Profesional funciones*/
		(3,1),(3,2),(3,3),(3,8),(3,9); /*Usuario Afiliado funciones*/

/*Cargo usuario Admin pedido por catedra */ 
INSERT INTO SELECT_GROUP.Usuario(nombreUsuario,contraseña,intentosFallidos,habilitado) values
('admin', HASHBYTES('SHA2_256','w23e'),0,1)

/*Cargo los usuarios pertenecientes a los Afiliados */
INSERT INTO SELECT_GROUP.Usuario(nombreUsuario,contraseña,intentosFallidos,habilitado)
select distinct cast(Paciente_Dni as varchar(45)), HASHBYTES('SHA2_256',cast(Paciente_Dni as varchar(45))),0,1
from gd_esquema.Maestra
where Paciente_Dni is not null
order by cast(Paciente_Dni as varchar(45))

/*Cargo los usuarios pertenecientes a los profesionales */
INSERT INTO SELECT_GROUP.Usuario(nombreUsuario,contraseña,intentosFallidos,habilitado)
select distinct cast(Medico_Dni as varchar(45)), HASHBYTES('SHA2_256',Medico_Apellido),0,1
from gd_esquema.Maestra
where Medico_Dni is not null
order by cast(Medico_Dni as varchar(45))

/*Cargo los planes de la tabla maestra */
INSERT INTO SELECT_GROUP.Plan_Med(idPlan,descripcion,precioDelBono_Consulta,precioDelBono_Farmacia)
SELECT distinct Plan_Med_Codigo,Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia 
from gd_esquema.Maestra
order by Plan_Med_Codigo

/*Cargo los diagnosticos de la tabla maestra*/
INSERT INTO SELECT_GROUP.Diagnostico(sintomas,enfermedades,fechaYHora)
SELECT distinct Consulta_Enfermedades,Consulta_Sintomas, GETDATE() /*(CONVERT (date,GETDATE())) Obtiene la fecha*/
from gd_esquema.Maestra
where Consulta_Enfermedades is not null

/*Cargo los afiliados de la tabla maestra */
INSERT INTO SELECT_GROUP.Afiliado(numeroDoc,nombre,apellido,tipoDoc,telefono,mail,fechaNac,sexo,estadoCivil,cantidadHijos,direccion,idUsuario,plan_idPlan)
SELECT distinct Paciente_Dni,Paciente_Nombre,Paciente_Apellido,'DNI',Paciente_Telefono,Paciente_mail,Paciente_Fecha_Nac,'SEXO','EC',0,Paciente_Direccion,(select idUsuario from SELECT_GROUP.Usuario where nombreUsuario = (cast(Paciente_Dni as varchar(45)))),(select idPlan from SELECT_GROUP.Plan_Med where idPlan = 555555) 
from gd_esquema.Maestra
where Paciente_Dni is not null
order by Paciente_Nombre


/*Inserto nro de afiliado para cada uno de los afiliados principales */
update SELECT_GROUP.Afiliado set nroAfiliado = ((idAfiliado * 100) + 1)

alter table SELECT_GROUP.Afiliado 
alter column nroAfiliado numeric(10,0) not null


/*Cargo los Profesionales de la tabla maestra */
INSERT INTO SELECT_GROUP.Profesional(numeroDni,nombre,apellido,telefono,direccion,mail,fechaNac,sexo,idUsuario)
SELECT distinct Medico_Dni,Medico_Nombre,Medico_Apellido,Medico_Telefono,Medico_Direccion,Medico_Mail,Medico_Fecha_Nac,'Sexo', (select idUsuario from SELECT_GROUP.Usuario where nombreUsuario = (cast(Medico_Dni as varchar(45))))
from gd_esquema.Maestra
where Medico_Dni is not null
order by Medico_Dni

INSERT INTO SELECT_GROUP.Tipo_Especialidad(idTipo,descripcion)
SELECT distinct Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion from gd_esquema.Maestra
where Tipo_Especialidad_Codigo is not null

INSERT INTO SELECT_GROUP.Especialidad(idEspecialidad,descripcion)
SELECT distinct Especialidad_Codigo,Especialidad_Descripcion from gd_esquema.Maestra
where Especialidad_Codigo is not null

INSERT INTO SELECT_GROUP.Estado_Turno(idEstadoTurno,descripcion) values
	(1,'Atendido'),
	(2,'Cancelado'),
	(3,'En espera'),
	(4,'Presentado en Recepcion');

insert into SELECT_GROUP.Tipo_Cancelacion(descripcion) values
	('Razones Personales'),
	('Disconformidad con el Profesional'),
	('Solicitud de Turno Equivocada');

INSERT INTO SELECT_GROUP.Turno(idTurno,idAgenda,fechaTurno,cancelacion_idCancelacion,estado,idDiagnostico,especialidad ) 
SELECT distinct Turno_Numero,null,Turno_Fecha,null,1/*(select idEstadoTurno from SELECT_GROUP.Estado_Turno where descripcion = 'Atendido')*/,1, Especialidad_Codigo /*select idDiagnostico from SELECT_GROUP.Diagnostico where sintomas = 'Sintoma 1'*/ from gd_esquema.Maestra
where Turno_Numero is not null

/*idAgenda en null porque al estar utilizados los turnos no se van a agendar */
/*cancelacion_idCancelacion en null porque al estar utilizados mo se cancelan */ 

update t
set t.afiliado_idAfiliado = dt.idAfiliado
from SELECT_GROUP.Turno as t
join
 (
select   
		t.idTurno, 
		g.idAfiliado 
from
 (   select idTurno,
      (row_number() over (order by newid())
    % (select count(*) from SELECT_GROUP.Afiliado))+1 as rn -- number from 1 to n 
   from SELECT_GROUP.Turno
 ) AS t 
join 
 ( select idAfiliado,
     row_number() over (order by newid()) as rn -- sequential number from 1 to n
   from SELECT_GROUP.Afiliado 
 ) as g
   on t.rn = g.rn 
 ) as dt
on t.idTurno = dt.idTurno;




update SELECT_GROUP.Especialidad 
set idTipoEspecialidad = (CASE 
                    WHEN descripcion like '%Cirugía%'
                        THEN 1001
					WHEN descripcion like '%Radio%'
                        THEN 1003
					WHEN descripcion like '%Médico-Quirúrgica%'
						THEN 1002
					ELSE 1000
		END);	

INSERT INTO SELECT_GROUP.Compras(FechaCompra,afiliado_Comprador,unidades)
SELECT distinct Compra_Bono_Fecha, (select idAfiliado from SELECT_GROUP.Afiliado where numeroDoc = Paciente_Dni ), count(*)
from gd_esquema.Maestra
where Compra_Bono_Fecha is not null
group by Compra_Bono_Fecha,Paciente_Dni

update SELECT_GROUP.Compras /*TCompras TAfiliado TPlan Medico*/
set monto = PM.precioDelBono_Consulta * unidades
from SELECT_GROUP.Afiliado as AF inner join SELECT_GROUP.Compras as CO on AF.idAfiliado = CO.afiliado_Comprador
inner join SELECT_GROUP.Plan_Med as PM on PM.idPlan = AF.plan_idPlan

INSERT INTO Select_Group.Bono
(numero_Consulta,idCompra, idPlan, idAfiliado,estado,bonoConsulta_FechaImpresion)

SELECT distinct Bono_Consulta_Numero,C.idCompra,Afi.plan_idPlan,Afi.idAfiliado, 1, M.Bono_Consulta_Fecha_Impresion

  FROM gd_esquema.Maestra as M
  
  JOIN Select_Group.Afiliado as Afi ON Afi.numeroDoc = M.Paciente_Dni
  inner JOIN Select_Group.Compras as C ON  C.afiliado_Comprador = Afi.idAfiliado and C.FechaCompra = M.Compra_Bono_Fecha
  
  WHERE M.Bono_Consulta_Numero is not null
  AND M.Bono_Consulta_Fecha_Impresion is not null

  ORDER BY M.Bono_Consulta_Numero
GO

insert into SELECT_GROUP.Usuario_Por_Rol (rol_idRol,usuario_username)
select R.idRol,U.idUsuario
from SELECT_GROUP.Usuario as U, SELECT_GROUP.Rol as R, SELECT_GROUP.Afiliado as A
where U.idUsuario = A.idUsuario and r.nombre = 'Afiliado'

insert into SELECT_GROUP.Usuario_Por_Rol (rol_idRol,usuario_username)
select R.idRol,U.idUsuario
from SELECT_GROUP.Usuario as U, SELECT_GROUP.Rol as R, SELECT_GROUP.Profesional as P
where U.idUsuario = P.idUsuario and r.nombre = 'Profesional'

insert into SELECT_GROUP.Usuario_Por_Rol (rol_idRol,usuario_username)
select R.idRol,U.idUsuario
from SELECT_GROUP.Usuario as U, SELECT_GROUP.Rol as R
where U.nombreUsuario = 'admin' and r.nombre = 'Administrativo'

INSERT INTO Select_Group.Profesional_Por_Especialidad
([especialidad_idEspecialidad], [profesional_idProfesional])
SELECT distinct M.Especialidad_Codigo, P.matricula FROM gd_esquema.Maestra M JOIN Select_Group.Profesional P ON M.Medico_Dni = P.numeroDni 

INSERT INTO [Select_Group].[Agenda]
           ([profesional_IdProfesional]
           ,[diaDisponible]
           ,[horaDesde]
           ,[horaHasta])
     VALUES
           
           --El día 0(cero) es el día Domingo
           --Formato HHMM
           

(1000,2,900,1900),
(1001,3,900,1900),
(1002,4,900,1900),
(1003,1,900,1900),
(1004,5,900,1900),
(1005,6,900,1900),
(1006,7,900,1900),
(1007,4,900,1900),
(1008,3,900,1900),
(1009,2,900,1900),
(1010,2,900,1900),
(1011,1,900,1900),
(1012,4,800,1700),
(1013,1,800,1700),
(1014,1,800,1700),
(1015,2,800,1700),
(1016,4,800,1700),
(1017,6,800,1700),
(1018,6,800,1700),
(1019,2,800,1700),
(1020,3,800,1700),
(1021,5,800,1700),
(1022,3,800,1700),
(1023,2,800,1700),
(1024,1,800,1700),
(1025,6,1000,2000),
(1026,7,1000,2000),
(1027,5,1000,2000),
(1000,4,1000,2000),
(1001,4,1000,2000),
(1002,2,1000,2000),
(1003,3,1000,2000),
(1004,2,1000,2000),
(1005,3,1000,2000),
(1006,2,1000,2000),
(1007,2,1000,2000),
(1008,2,1000,2000),
(1009,4,1000,2000),
(1010,4,1000,2000),
(1011,5,1000,2000),
(1012,3,1000,2000),
(1013,2,1000,2000),
(1014,2,1000,2000),
(1015,4,1000,2000),
(1016,1,1000,2000),
(1017,4,1000,2000),
(1018,4,1000,2000),
(1019,3,1000,2000),
(1020,4,1000,2000),
(1021,1,1000,2000),
(1022,2,1000,2000),
(1023,3,1000,2000),
(1024,4,1000,2000),
(1025,2,1000,2000),
(1026,1,1000,2000),
(1027,3,1000,2000)

GO
--=============================================================================================================
--TIPO		: Procedure
--NOMBRE	: ComprarBono
--OBJETIVO  : Crear un registro en la tabla compras.                                     
--=============================================================================================================
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
GO
--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_Reservar_Turno
--OBJETIVO  : un afiliado cancela un turno                                  
--=============================================================================================================

CREATE PROCEDURE [Select_Group].[sp_Reservar_Turno](@idAgenda int, @fechaHoraTurno datetime, @userName VARCHAR(45), @especialidad int )
	
AS
BEGIN
BEGIN TRANSACTION RESERVARTURNO
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @idUser int;
	DECLARE @nroAfiliado int;
	DECLARE @idTurno int;


    -- Insert statements for procedure here

	set @idUser = (SELECT idUsuario FROM Select_Group.Usuario WHERE Usuario.nombreUsuario = @userName);

	set @nroAfiliado = (SELECT idAfiliado FROM Select_Group.Afiliado WHERE idUsuario = @idUser);

	set @idTurno = 1;

	set @idTurno = @idTurno +(Select isnull(max(idTurno),0) FROM Select_Group.Turno);

	 INSERT into Select_Group.Turno(idTurno, idAgenda, fechaTurno,afiliado_idAfiliado,cancelacion_idCancelacion,estado,idDiagnostico, especialidad)
	VALUES (@idTurno, @idAgenda, @fechaHoraTurno,@nroAfiliado, null, 3,null, @especialidad);

	INSERT into Select_Group.Agenda_Detalle(fecha_Hora_Turno, estaCancelado, idAgenda)
	VALUES (@fechaHoraTurno,0,@idAgenda);

COMMIT TRANSACTION RESERVARTURNO
END
GO
--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_registrarCancelacion
--OBJETIVO  : un afiliado cancela un turno                                  
--=============================================================================================================

CREATE PROCEDURE [Select_Group].[sp_registrarCancelacion](@idTipoCanc int, @Motivo varchar(45),  @idTurno int)
AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO Select_Group.Cancelacion(motivo,tipo_Cancelacion_idTipoCanc)
	VALUES (@Motivo, @idTipoCanc)

	declare @idCanc numeric(6,0);

	SET @idCanc = (SELECT max(idCancelacion) FROM Select_Group.Cancelacion);

	UPDATE Select_Group.Turno
	Set cancelacion_idCancelacion = @idCanc,
	estado = 2
	WHERE idTurno = @idTurno;

	Declare @idAgenda int;

	SET @idAgenda = (Select idAgenda FROM Select_Group.Turno WHERE idTurno = @idTurno);

	UPDATE Select_Group.Agenda_Detalle
	Set estaCancelado = 1
	WHERE idAgenda = @idAgenda;
    
	
END
GO
--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_registrar_llegada
--OBJETIVO  : actualiza el bono como usado y el turno como presentado en recepcion                                   
--=============================================================================================================


CREATE PROCEDURE Select_Group.sp_registrar_llegada (@idBono int, @idTurno int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

BEGIN TRAN

   UPDATE Select_Group.Bono
   Set estado = 0
   WHERE idBono = @idBono

   UPDATE Select_Group.Turno
   Set estado = 4
   WHERE idTurno = @idTurno

COMMIT TRAN

END
GO


--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_getDiasDisponibles
--OBJETIVO  : obtiene el horario de trabajo de un profesional para un dia de la semana                                   
--=============================================================================================================
CREATE PROCEDURE [Select_Group].[sp_getDiasDisponibles] (@Dia int,  @idProfesional int)

AS
BEGIN
	

	SELECT idAgenda, profesional_idProfesional, horaDesde, horaHasta
	
	FROM Select_Group.Agenda WHERE diaDisponible = @Dia AND profesional_IdProfesional = @idProfesional

END
GO


--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_CrearUsuario
--OBJETIVO  : Crea un usuario                                    
--=============================================================================================================

CREATE PROCEDURE Select_Group.sp_CrearUsuario 
					(@Dni numeric(18,0))
	
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRY

		INSERT into Select_Group.Usuario
				(nombreUsuario, contraseña, intentosFallidos, habilitado) values
				(cast(@Dni as varchar(45)), HASHBYTES('SHA2_256',cast(@Dni as varchar(45))),0,1)



	END TRY

	BEGIN CATCH

		DECLARE @MensajeError nvarchar(4000) = ERROR_MESSAGE(), @ErrNum INT = ERROR_NUMBER(), @ErrProc nvarchar(126) = ERROR_PROCEDURE();

		DECLARE @DatosError nvarchar(4000) = 'Hubo un error al insertar los datos en la tabla Usuario'
		+ @MensajeError
		RAISERROR (@DatosError, 16,1)

	END CATCH

    
END
GO


--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_guardarDiagnostico
--OBJETIVO  : Cuando un profesional registra resultado                                    
--=============================================================================================================
CREATE PROCEDURE [Select_Group].[sp_guardarDiagnostico](@sintomas VARCHAR(255), @enfermedades VARCHAR(255), @idTurno int )

AS
BEGIN
	
	SET NOCOUNT ON;

	

	DECLARE @idDiagnostico int;

	IF (@sintomas <> 'NO SE COMPLETO DIAGNOSTICO')

	BEGIN
    INSERT INTO Select_Group.Diagnostico (sintomas, enfermedades, fechaYHora)
	VALUES ( @sintomas, @enfermedades, GETDATE());

	SET @idDiagnostico = ((SELECT max(idDiagnostico) FROM Select_Group.Diagnostico));

	UPDATE Select_Group.Turno

	SET 
	estado = 1,
	idDiagnostico = @idDiagnostico
	WHERE idTurno = @idTurno;

	END
	ELSE
	BEGIN

	UPDATE Select_Group.Turno

	SET estado = 2 --Si no se completó el diagnóstico el Afiliado se retiró antes y el turno queda cancelado
	WHERE idTurno = @idTurno;

	END
	
END
GO

--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: sp_cancelacionProfesional
--OBJETIVO  : Cuando un profesional cancela un turno                                    
--=============================================================================================================

CREATE PROCEDURE [Select_Group].[sp_cancelacionProfesional](@Motivo varchar(45), @tipoMot int, @idProf int, @fechaDesde datetime, @fechaHasta datetime)
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE turnos CURSOR FOR
	SELECT T.idTurno
	FROM Select_Group.Agenda A
	JOIN Select_Group.Turno T ON T.idAgenda = A.idAgenda
	WHERE A.profesional_IdProfesional = @idProf
	AND T.fechaTurno BETWEEN @fechaDesde AND @fechaHasta

	
	declare @idCanc int;
	declare @idTurno int;

	INSERT INTO Select_Group.Cancelacion(motivo, tipo_Cancelacion_idTipoCanc)
	VALUES(@Motivo, @tipoMot);

	SET @idCanc = (SELECT max(idCancelacion) FROM Select_Group.Cancelacion);

	OPEN turnos;

	FETCH NEXT FROM turnos INTO @idTurno;

	WHILE (@@FETCH_STATUS = 0)

	BEGIN

	UPDATE [Select_Group].[Turno]
	SET estado = 2,
	cancelacion_idCancelacion = @idCanc
	WHERE 
	idTurno = @idTurno;


	FETCH NEXT FROM turnos INTO @idTurno;
	END;

	CLOSE turnos;
	DEALLOCATE turnos;

END
GO
--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: ActualizarPlan
--OBJETIVO  : Actualiza el plan de un afiliado.                                     
--=============================================================================================================

CREATE PROCEDURE SELECT_GROUP.ActualizarPlan(@idPlan int,@idAfiliado int)
		
AS

BEGIN
	SET NOCOUNT ON;

	UPDATE Select_Group.Afiliado
		Set plan_idPlan = @idPlan
		Where idAfiliado = @idAfiliado

END
GO

--=============================================================================================================
--TIPO		: Store Procedure
--NOMBRE	: AltaAfiliado
--OBJETIVO  : da de alta un afiliado.                                     
--=============================================================================================================

/*CREATE PROCEDURE [SELECT_GROUP].[AltaAfiliado](@Afiliado_nombre VARCHAR(255), @Afiliado_Apellido VARCHAR(255),@Afiliado_tipoDni VARCHAR(45), 
												@Afiliado_numeroDni NUMERIC(18,0),@Afiliado_telefono NUMERIC(18,0),@Afiliado_mail VARCHAR(255),
												@Afiliado_fechaNac datetime,@Afiliado_Sexo varchar(45), @Afiliado_EstadoCivil VARCHAR(45), 
												@Afiliado_Direccion VARCHAR(255))
AS
BEGIN
	Insert into SELECT_GROUP.Afiliado(nombre,apellido,tipoDni,numeroDni,telefono,mail,fechaNac,sexo,estadoCivil,direccion) values
	(@Afiliado_nombre, @Afiliado_Apellido,@Afiliado_tipoDni, @Afiliado_numeroDni,@Afiliado_telefono,@Afiliado_mail,@Afiliado_fechaNac,
	@Afiliado_Sexo, @Afiliado_EstadoCivil, @Afiliado_Direccion)
END
GO*/
CREATE TYPE Select_Group.dt_Afiliados AS TABLE

(
	nombre varchar(255) NOT NULL
	,nroAfiliado numeric(10,0) NOT NULL
	,apellido varchar(255) NOT NULL
	,tipoDoc varchar(45) NOT NULL
	,numeroDoc numeric(18,0) NOT NULL
	,telefono numeric (18,0) NOT NULL
	,mail varchar(255) NOT NULL
	,fechaNac datetime NOT NULL
	,sexo varchar(45) NOT NULL
	,estadoCivil varchar(45) NOT NULL
	,cantidadHijos numeric(2,0) not null
	,direccion varchar(255) NOT NULL
	,idUsuario varchar(45) NOT NULL
	,plan_idPlan numeric(18,0) NOT NULL
)
GO


CREATE PROCEDURE [SELECT_GROUP].[AltaAfiliado] 
@Afiliados SELECT_GROUP.dt_Afiliados READONLY
AS
BEGIN
	
	declare @nroAfiliado int;
	declare @idAfiliado int;
	declare @nroDocumento int;

	--set @nroDocumento = (select numeroDoc from @Afiliados)
	--set @nroAfiliado =  (select nroAfiliado from @Afiliados)
	
	Insert into SELECT_GROUP.Afiliado(nombre,nroAfiliado,apellido,tipoDoc,numeroDoc,telefono,mail,fechaNac,sexo,estadoCivil
										,cantidadHijos,direccion,idUsuario,plan_idPlan) 
	SELECT * FROM @Afiliados

	--set @idAfiliado = (SELECT min(idAfiliado) FROM Select_Group.Afiliado as AF0, @Afiliados as AF1 where AF0.numeroDoc = AF1.numeroDoc)


	--update SELECT_GROUP.Afiliado
		--set nroAfiliado = ((@idAfiliado * 100) + @nroAfiliado)
		--where numeroDoc = @nroDocumento
	--update SELECT_GROUP.Afiliado
	--	set nroAfiliado = case (select nroAfiliado from @Afiliados) 
	--		when 1 then ((@idAfiliado * 100) + 1)
	--		when 2 then ((@idAfiliado * 100) + 2)
	--	end
	--where numeroDoc in (select numeroDoc from @Afiliados)	
	
END
go

--=============================================================================================================
--TIPO		: Vista
--NOMBRE	: ProfMasConsultados
--OBJETIVO  : Vista que obtiene los 5 profesionales mas consultados por especialidad.                                     
--=============================================================================================================
CREATE VIEW [Select_Group].[ProfMasConsultados]
AS

SELECT        TOP (5) P.matricula, P.apellido, P.nombre, E.descripcion
FROM            Select_Group.Profesional AS P INNER JOIN
                         Select_Group.Profesional_Por_Especialidad AS PE ON PE.profesional_idProfesional = P.matricula INNER JOIN
                         Select_Group.Especialidad AS E ON E.idEspecialidad = PE.especialidad_idEspecialidad INNER JOIN
                         Select_Group.Agenda AS Ag ON Ag.profesional_IdProfesional = P.matricula INNER JOIN
                         Select_Group.Turno AS T ON T.idAgenda = Ag.idAgenda INNER JOIN
                         Select_Group.Afiliado AS Af ON Af.idAfiliado = T.afiliado_idAfiliado
GROUP BY P.matricula, Af.plan_idPlan, E.descripcion, P.apellido, P.nombre
ORDER BY COUNT(Af.plan_idPlan);

GO

--=============================================================================================================
--TIPO		: Vista
--NOMBRE	: V_Las5EspConMasCancelaciones
--OBJETIVO  : Vista que obtiene las 5 especialidades con mas cancelaciones.                                     
--=============================================================================================================
CREATE VIEW [Select_Group].[V_Las5EspConMasCancelaciones]
AS

SELECT TOP 5 T.especialidad 
FROM Select_Group.Turno T 
WHERE T.cancelacion_idCancelacion is not null GROUP BY T.especialidad ORDER BY count(*) desc;

GO

--=============================================================================================================
--TIPO		: Vista
--NOMBRE	: V_Las5EspConMasBonos
--OBJETIVO  : Vista que obtiene las 5 especialidades con mas bonos.                                     
--=============================================================================================================

CREATE VIEW [Select_Group].[V_Las5EspConMasBonos]
AS

SELECT TOP 5 PE.especialidad_idEspecialidad, Esp.descripcion 
FROM Select_Group.Turno T 
JOIN Select_Group.Agenda Ag ON Ag.idAgenda = T.idAgenda 
JOIN Select_Group.Profesional_Por_Especialidad PE ON PE.profesional_idProfesional = Ag.profesional_IdProfesional 
JOIN Select_Group.Bono Bo ON Bo.estado = 0 AND Bo.idAfiliado = T.afiliado_idAfiliado 
JOIN Select_Group.Especialidad Esp ON Esp.idEspecialidad = T.especialidad 
GROUP BY PE.especialidad_idEspecialidad, Esp.descripcion 
ORDER BY count (*) desc;

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
GO



COMMIT TRANSACTION creacionTablas









