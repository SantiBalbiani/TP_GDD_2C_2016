USE [GD2C2016]
GO

/****** Object:  Table [Select_Group].[Afiliado]    Script Date: 30/10/2016 21:04:52 ******/

DROP TABLE [Select_Group].[Usuario_Por_Rol]
DROP TABLE [Select_Group].[Afiliado]
DROP TABLE [Select_Group].[Agenda]
DROP TABLE [Select_Group].[Bono]
DROP TABLE [Select_Group].[Diagnostico]
DROP TABLE [Select_Group].[Agenda_detalle]
DROP TABLE [Select_Group].[Cancelacion]
DROP TABLE [Select_Group].[Compras]
DROP TABLE [Select_Group].[Especialidad]
DROP TABLE [Select_Group].[Estado_Turno]
DROP TABLE [Select_Group].[Funcionalidad]
DROP TABLE [Select_Group].[Funcionalidad_Por_Rol]
DROP TABLE [Select_Group].[Plan_Historico]
DROP TABLE [Select_Group].[Plann]
DROP TABLE [Select_Group].[Profesional]
DROP TABLE [Select_Group].[Profesional_Por_Especialidad]
DROP TABLE [Select_Group].[Rol]
DROP TABLE [Select_Group].[Tipo_Cancelacion]
DROP TABLE [Select_Group].[Tipo_Especialidad]
DROP TABLE [Select_Group].[Turno]
DROP TABLE [Select_Group].[Usuario]
DROP TABLE [Select_Group].[Plan_Med]
DROP PROCEDURE [Select_Group].[sp_InsertarRolAfiliado];
DROP PROCEDURE [Select_Group].[BAJA_ROL];
DROP PROCEDURE Select_Group.ComprarBono;
DROP PROCEDURE Select_Group.CrearRol;
DROP PROCEDURE Select_Group.Habilitar_Rol;
DROP PROCEDURE Select_Group.ModificarRol;
DROP PROCEDURE Select_Group.ObtenerEspecialidades;
DROP PROCEDURE Select_Group.sp_AltaAfiliado;
DROP PROCEDURE Select_Group.sp_cancelacionProfesional;
DROP PROCEDURE Select_Group.sp_CrearUsuario;
DROP PROCEDURE Select_Group.sp_getDiasDisponibles;
DROP PROCEDURE Select_Group.sp_guardarDiagnostico;
DROP PROCEDURE Select_Group.sp_registrar_llegada;
DROP PROCEDURE Select_Group.sp_registrarCancelacion;
DROP PROCEDURE Select_Group.sp_Reservar_Turno;
DROP PROCEDURE Select_Group.ActualizarPlan;
DROP PROCEDURE Select_Group.AltaAfiliado;
DROP PROCEDURE SELECT_GROUP.AltaAgenda
DROP VIEW [Select_Group].[ProfMasConsultados];
DROP VIEW [Select_Group].[V_Las5EspConMasBonos];
DROP VIEW [Select_Group].[V_Las5EspConMasCancelaciones];
DROP TYPE [Select_Group].[dt_Afiliados];
DROP TYPE [Select_Group].[dt_Agenda];
DROP VIEW [Select_Group].[5AfiliadosConMasCompraDeBonos];
DROP SCHEMA [Select_Group];

GO


