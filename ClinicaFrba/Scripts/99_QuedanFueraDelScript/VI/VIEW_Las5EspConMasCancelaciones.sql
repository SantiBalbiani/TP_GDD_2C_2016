USE [GD2C2016]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [Select_Group].[V_Las5EspConMasCancelaciones]
AS
SELECT TOP 5 T.especialidad 
FROM Select_Group.Turno T 
WHERE T.cancelacion_idCancelacion is not null GROUP BY T.especialidad ORDER BY count(*) desc

GO


