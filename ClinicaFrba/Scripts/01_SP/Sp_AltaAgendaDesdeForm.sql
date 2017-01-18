use GD2C2016;




CREATE PROCEDURE [SELECT_GROUP].[AltaAgenda] 
@Agenda SELECT_GROUP.dt_Agenda READONLY
AS
BEGIN
	Insert into SELECT_GROUP.Agenda(profesional_IdProfesional,diaDisponible,horaDesde,horaHasta, especialidad) 
	SELECT * FROM @Agenda

END
go
