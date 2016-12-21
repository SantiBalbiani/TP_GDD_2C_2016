USE [GD2C2016]
GO

/****** Object:  View [SELECT_GROUP].[ProfMasConsultados]    Script Date: 20/12/2016 13:17:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--=============================================================================================================
--TIPO		: Vista
--NOMBRE	: ProfMasConsultados
--OBJETIVO  : Vista que obtiene los 5 profesionales mas consultados por especialidad.                                     
--=============================================================================================================
ALTER VIEW [SELECT_GROUP].[ProfMasConsultados]
AS

SELECT        TOP (5) P.matricula, P.apellido, P.nombre,  Af.plan_idPlan, COUNT(Af.plan_idPlan) AS 'CantConsultas'
FROM            Select_Group.Profesional AS P INNER JOIN
                         Select_Group.Profesional_Por_Especialidad AS PE ON PE.profesional_idProfesional = P.matricula INNER JOIN
                         Select_Group.Especialidad AS E ON E.idEspecialidad = PE.especialidad_idEspecialidad INNER JOIN
                         Select_Group.Agenda AS Ag ON Ag.profesional_IdProfesional = P.matricula INNER JOIN
                         Select_Group.Turno AS T ON T.idAgenda = Ag.idAgenda INNER JOIN
                         Select_Group.Afiliado AS Af ON Af.idAfiliado = T.afiliado_idAfiliado
WHERE Af.plan_idPlan = 555555
GROUP BY P.matricula, Af.plan_idPlan, P.apellido, P.nombre
ORDER BY COUNT(Af.plan_idPlan) desc;


GO


