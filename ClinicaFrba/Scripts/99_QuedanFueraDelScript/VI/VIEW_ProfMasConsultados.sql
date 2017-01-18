USE [GD2C2016]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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
ORDER BY COUNT(Af.plan_idPlan)

GO


