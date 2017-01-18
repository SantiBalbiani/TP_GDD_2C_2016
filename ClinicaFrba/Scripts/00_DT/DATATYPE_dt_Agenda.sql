use GD2C2016;


CREATE TYPE Select_Group.dt_Agenda AS TABLE

(
	profesional_IdProfesional numeric(7,0) not null,
    diaDisponible int not null,    
    horaDesde int not null,
	horaHasta int not null,
	especialidad int not null)

GO
