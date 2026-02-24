USE [CondominosDB]
GO
SET IDENTITY_INSERT [dbo].[Condominos] ON
INSERT INTO [dbo].[Condominos] ([Id], [IdTipo], [Identificacion], [Nombre], [Apellidos], [FechaNacimiento], [NumeroFilial], [TieneConstruccion], [Email], [Password], [TipoUsuario]) VALUES (1, N'Física', N'112345678', N'Admin', N'Condominos', N'1996-03-09', N'8', 1, N'admin@condominos.com', N'a1b2c3', 1)
SET IDENTITY_INSERT [dbo].[Condominos] OFF

SET IDENTITY_INSERT [dbo].[Condominos] ON
INSERT INTO [dbo].[Condominos] ([Id], [IdTipo], [Identificacion], [Nombre], [Apellidos], [FechaNacimiento], [NumeroFilial], [TieneConstruccion], [Email], [Password], [TipoUsuario]) VALUES (1, N'Pasaporte', N'987654321', N'Esteban', N'Corrales', N'1985-03-08', N'11', 1, N'esteban.corrales11@gmail.com', N'c3b2a1', 1)
SET IDENTITY_INSERT [dbo].[Condominos] OFF
