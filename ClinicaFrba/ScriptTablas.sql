BEGIN TRANSACTION creacionTablas
use GD2C2016

GO
create schema SELECT_GROUP
GO


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
	
)
create table SELECT_GROUP.Afiliado(
	idAfiliado numeric(7,0) identity(001,100) not null,
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
	horaHasta varchar(45),
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
	CONSTRAINT pk_idEstadoTurno primary key (idEstadoTurno)
)

create table SELECT_GROUP.Turno(
	idTurno numeric(18,0) not null,
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
INSERT INTO SELECT_GROUP.Afiliado(numeroDni,nombre,apellido,tipoDni,telefono,mail,fechaNac,sexo,estadoCivil,direccion,familiares,idUsuario,plan_idPlan)
SELECT distinct Paciente_Dni,Paciente_Nombre,Paciente_Apellido,'DNI',Paciente_Telefono,Paciente_mail,Paciente_Fecha_Nac,'SEXO','EC',Paciente_Direccion,'Familiares',(select idUsuario from SELECT_GROUP.Usuario where nombreUsuario = (cast(Paciente_Dni as varchar(45)))),(select idPlan from SELECT_GROUP.Plan_Med where idPlan = 555555) 
from gd_esquema.Maestra
where Paciente_Dni is not null
order by Paciente_Nombre

/*Cargo los Profesionales de la tabla maestra */
INSERT INTO SELECT_GROUP.Profesional(numeroDni,nombre,apellido,telefono,direccion,mail,fechaNac,sexo,idUsuario)
SELECT distinct Medico_Dni,Medico_Nombre,Medico_Apellido,Medico_Telefono,Medico_Direccion,Medico_Mail,Medico_Fecha_Nac,'Sexo', (select idUsuario from SELECT_GROUP.Usuario where nombreUsuario = (cast(Medico_Dni as varchar(45))))
from gd_esquema.Maestra
where Medico_Dni is not null
order by Medico_Dni

INSERT INTO SELECT_GROUP.Estado_Turno(idEstadoTurno,descripcion) values
	(1,'Atendido'),
	(2,'Cancelado'),
	(3,'En espera');

insert into SELECT_GROUP.Tipo_Cancelacion(descripcion) values
	('Cancela Medico'),
	('Cancela Afiliado');

INSERT INTO SELECT_GROUP.Turno(idTurno,idAgenda,fechaTurno,cancelacion_idCancelacion,estado,idDiagnostico) 
SELECT distinct Turno_Numero,null,Turno_Fecha,null,1/*(select idEstadoTurno from SELECT_GROUP.Estado_Turno where descripcion = 'Atendido')*/,1 /*select idDiagnostico from SELECT_GROUP.Diagnostico where sintomas = 'Sintoma 1'*/ from gd_esquema.Maestra
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


INSERT INTO SELECT_GROUP.Tipo_Especialidad(idTipo,descripcion)
SELECT distinct Tipo_Especialidad_Codigo,Tipo_Especialidad_Descripcion from gd_esquema.Maestra
where Tipo_Especialidad_Codigo is not null

INSERT INTO SELECT_GROUP.Especialidad(idEspecialidad,descripcion)
SELECT distinct Especialidad_Codigo,Especialidad_Descripcion from gd_esquema.Maestra
where Especialidad_Codigo is not null

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
SELECT distinct Compra_Bono_Fecha, (select idAfiliado from SELECT_GROUP.Afiliado where numeroDni = Paciente_Dni ), count(*)
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
  
  JOIN Select_Group.Afiliado as Afi ON Afi.numeroDni = M.Paciente_Dni
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

--=============================================================================================================
--TIPO		: Procedure
--NOMBRE	: ComprarBono
--OBJETIVO  : Crear un registro en la tabla compras.                                     
--=============================================================================================================
CREATE PROCEDURE [SELECT_GROUP].[ComprarBono](@userName VARCHAR(45), @cantidad INT)
AS
BEGIN

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

	Insert into SELECT_GROUP.Compras(FechaCompra,afiliado_Comprador,unidades,monto)
	Values(@fechaActual, @nroAfiliado, @cantidad, (@precio * @cantidad));

END
GO

--=============================================================================================================
--TIPO		: Trigger
--NOMBRE	: RegistrarBonos
--OBJETIVO  : Crea una cantidad de registros(Bonos) igual al campo "unidades" de la tabla Compras.                                     
--=============================================================================================================

CREATE TRIGGER [Select_Group].[RegistrarBonos] ON [Select_Group].[Compras]
AFTER INSERT
AS

BEGIN 
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
		set @nroConsulta = (SELECT (max(numero_consulta)+1) FROM Select_Group.Bono );
		Insert into Select_Group.Bono(idCompra,idPlan,idAfiliado,numero_Consulta,estado,bonoConsulta_FechaImpresion)
		Values(@idCompra, @idPlan, @idAfiliado,@nroConsulta ,'1',@fechacompra);
		set @contador = @contador + 1;
	END;
	FETCH NEXT FROM CompraDeBonos into @idCompra,@fechacompra,@idAfiliado,@unidades,@monto;
END;


CLOSE CompraDeBonos;
DEALLOCATE CompraDeBonos;
END
GO

COMMIT TRANSACTION creacionTablas




