USE [GD2C2016]
GO

INSERT INTO [Select_Group].[Agenda]
           ([profesional_IdProfesional]
           ,[diaDisponible]
           ,[horaDesde]
           ,[horaHasta])
     VALUES
           (1003
           ,1 --El d�a 0(cero) es el d�a Domingo
           ,0900 --Formato HHMM
           ,1905) --Formato HHMM
GO


