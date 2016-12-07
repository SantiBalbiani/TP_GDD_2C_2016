USE [GD2C2016]
GO

/****** Object:  View [Select_Group].[ProfMasConsultados]    Script Date: 07/12/2016 10:12:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--=============================================================================================================
--TIPO		: Vista
--NOMBRE	: 5AfiliadosConMasCompraDeBonos
--OBJETIVO  : Vista que obtiene los 5 afiliados que mas bonos compraron.                                     
--=============================================================================================================
CREATE VIEW [Select_Group].[5AfiliadosConMasCompraDeBonos]
AS

SELECT TOP 5 A.nroAfiliado, A.nombre, A.apellido, COUNT(*) AS 'Cantidad Comprada' 
FROM Select_Group.Afiliado A 
JOIN Select_Group.Bono B ON A.idAfiliado = B.idAfiliado AND B.estado = 1 
GROUP BY A.nroAfiliado, A.nombre, A.apellido ORDER BY COUNT(*) DESC

GO


