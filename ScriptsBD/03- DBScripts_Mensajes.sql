USE [CondominosDB]
GO

/****** Objeto: Table [dbo].[Mensajes] Fecha del script: 23/02/2026 23:47:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mensajes] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [Titulo]                  NVARCHAR (111) NOT NULL,
    [Tipo]                    NVARCHAR (29)  NOT NULL,
    [PublicacionFechaInicio]  DATETIME2 (7)  NOT NULL,
    [PublicacionFechaFinal]   DATETIME2 (7)  NOT NULL,
    [Status]                  NVARCHAR (22)  NOT NULL,
    [CreadoPorUsuarioId]      INT            NOT NULL,
    [FechaCreacion]           DATETIME2 (7)  NOT NULL,
    [FechaReunion]            DATETIME2 (7)  NULL,
    [DuracionEstimadaMinutos] INT            NULL,
    [Agenda]                  NVARCHAR (MAX) NULL,
    [LocacionFisica]          NVARCHAR (111) NULL,
    [LinkVirtual]             NVARCHAR (338) NULL,
    [ActividadFechaInicio]    DATETIME2 (7)  NULL,
    [ActividadFechaFinal]     DATETIME2 (7)  NULL,
    [LocacionActividad]       NVARCHAR (222) NULL,
    [FormatoActividad]        NVARCHAR (11)  NULL,
    [Instrucciones]           NVARCHAR (MAX) NULL,
    [DescripcionRecordatorio] NVARCHAR (MAX) NULL
);


