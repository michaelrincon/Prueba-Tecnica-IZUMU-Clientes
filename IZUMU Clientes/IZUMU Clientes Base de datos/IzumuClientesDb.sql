
IF DB_ID('IzumuClientesDb') IS NULL
BEGIN
    CREATE DATABASE IzumuClientesDb;
END
GO

USE IzumuClientesDb;
GO

IF OBJECT_ID('dbo.Clientes', 'U') IS NOT NULL DROP TABLE dbo.Clientes;
IF OBJECT_ID('dbo.Planes', 'U') IS NOT NULL DROP TABLE dbo.Planes;
IF OBJECT_ID('dbo.TiposDocumento', 'U') IS NOT NULL DROP TABLE dbo.TiposDocumento;
GO

CREATE TABLE dbo.TiposDocumento
(
    TipoDocumentoId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre          NVARCHAR(100) NOT NULL,
);
GO

CREATE TABLE dbo.Planes
(
    PlanId      INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre      NVARCHAR(120) NOT NULL,
);
GO

CREATE TABLE dbo.Clientes
(
    ClienteId         INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    TipoDocumentoId   INT NOT NULL,
    NumeroDocumento   NVARCHAR(50) NOT NULL,
    FechaNacimiento   DATE NOT NULL,
    PrimerNombre      NVARCHAR(80) NOT NULL,
    SegundoNombre     NVARCHAR(80) NULL,
    PrimerApellido    NVARCHAR(80) NOT NULL,
    SegundoApellido   NVARCHAR(80) NULL,
    Direccion         NVARCHAR(200) NOT NULL,
    NumeroCelular     NVARCHAR(20) NOT NULL,
    Email             NVARCHAR(200) NOT NULL,
    PlanId            INT NOT NULL,

    CONSTRAINT FK_Clientes_TiposDocumento
        FOREIGN KEY (TipoDocumentoId)
        REFERENCES dbo.TiposDocumento(TipoDocumentoId),

    CONSTRAINT FK_Clientes_Planes
        FOREIGN KEY (PlanId)
        REFERENCES dbo.Planes(PlanId),
);
GO

INSERT INTO dbo.TiposDocumento (Nombre)
VALUES
('CC-Cédula de ciudadanía'),
('CE-Cédula de extranjería'),
('TI-Tarjeta de identidad'),
('PA-Pasaporte'),
('NIT');

INSERT INTO dbo.Planes (Nombre)
VALUES
('Plan Básico'),
('Plan Estándar'),
('Plan Premium');
GO


