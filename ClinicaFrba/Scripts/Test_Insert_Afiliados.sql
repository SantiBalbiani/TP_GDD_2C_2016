USE [GD2C2016]
GO

DECLARE @RC int
DECLARE @Afiliados dt_Afiliados

INSERT @Afiliados (nombre, apellido, tipoDNI, DNI, telefono, mail)

VALUES ('Che', 'Guevara1', 'DNI', 123253, 123213,'unEmail'),
		('Che2', 'Guevara2', 'DNI', 123353, 123213,'unEmail'),
		('Che3', 'Guevara3', 'DNI', 123553, 123213,'unEmail'),
		('Che4', 'Guevara4', 'DNI', 123653, 123213,'unEmail'),
		('Che5', 'Guevara5', 'DNI', 123753, 123213,'unEmail')
-- TODO: Set parameter values here.

EXEC Select_Group.sp_AltaAfiliado @Afiliados;


GO


