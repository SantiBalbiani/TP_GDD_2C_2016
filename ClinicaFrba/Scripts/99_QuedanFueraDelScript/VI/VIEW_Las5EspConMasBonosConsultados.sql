USE [GD2C2016]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [Select_Group].[V_Las5EspConMasBonos]
AS
SELECT TOP 5 PE.especialidad_idEspecialidad, Esp.descripcion 
FROM Select_Group.Turno T 
JOIN Select_Group.Agenda Ag ON Ag.idAgenda = T.idAgenda 
JOIN Select_Group.Profesional_Por_Especialidad PE ON PE.profesional_idProfesional = Ag.profesional_IdProfesional 
JOIN Select_Group.Bono Bo ON Bo.estado = 0 AND Bo.idAfiliado = T.afiliado_idAfiliado 
JOIN Select_Group.Especialidad Esp ON Esp.idEspecialidad = T.especialidad 
GROUP BY PE.especialidad_idEspecialidad, Esp.descripcion 
ORDER BY count (*) desc

GO


