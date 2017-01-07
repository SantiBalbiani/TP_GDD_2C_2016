use GD2C2016;

CREATE TYPE Select_Group.dt_Agenda AS TABLE

(
	profesional_IdProfesional numeric(7,0) not null,
    diaDisponible int not null,    
    horaDesde int not null,
	horaHasta int not null
)
GO


CREATE PROCEDURE [SELECT_GROUP].[AltaAgenda] 
@Agenda SELECT_GROUP.dt_Agenda READONLY
AS
BEGIN
	Insert into SELECT_GROUP.Agenda(profesional_IdProfesional,diaDisponible,horaDesde,horaHasta) 
	SELECT * FROM @Agenda

END
go
