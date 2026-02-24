CREATE TABLE Condominos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdTipo NVARCHAR(11) NOT NULL,
    Identificacion NVARCHAR(40) NOT NULL,
    Nombre NVARCHAR(40) NOT NULL,
    Apellidos NVARCHAR(44) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    NumeroFilial NVARCHAR(11) NOT NULL,
    TieneConstruccion BIT NOT NULL,
    Email NVARCHAR(111) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
	TipoUsuario INT NOT NULL DEFAULT 1
);