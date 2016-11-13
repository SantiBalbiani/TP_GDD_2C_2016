USE [GD2C2016]
GO

INSERT INTO [Select_Group].[Agenda]
           ([profesional_IdProfesional]
           ,[diaDisponible]
           ,[horaDesde]
           ,[horaHasta])
     VALUES
           (1003
           ,1 --El día 0(cero) es el día Domingo
           ,0900 --Formato HHMM
           ,1905) --Formato HHMM
GO


