USE master;
GO

--REMOVE BD {
IF EXISTS(SELECT * FROM sys.databases  WHERE name like 'GestionPruebas')  
DROP DATABASE GestionPruebas;


 
--REMOVE TABLE {
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'AspirantePruebaSeleccion')  
DROP TABLE dbo.AspirantePruebaSeleccion;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'PreguntasPruebaSeleccion')  
DROP TABLE dbo.PreguntasPruebaSeleccion;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'PruebaSeleccion')  
DROP TABLE dbo.PruebaSeleccion;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'TipoDocumentos')  
DROP TABLE dbo.TipoDocumentos;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'EstadoPruebas')  
DROP TABLE dbo.EstadoPruebas;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Aspirantes')  
DROP TABLE dbo.Aspirantes;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'TipoPruebas')  
DROP TABLE dbo.TipoPruebas;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'LenguajeProgramacion')  
DROP TABLE dbo.LenguajeProgramacion;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Nivel')  
DROP TABLE dbo.Nivel;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Preguntas')  
DROP TABLE dbo.Preguntas;
IF EXISTS(SELECT * FROM sys.tables WHERE SCHEMA_NAME(schema_id) LIKE 'dbo' AND name like 'Usuarios')  
DROP TABLE dbo.Usuarios;
GO

CREATE DATABASE GestionPruebas;
GO

USE GestionPruebas;
GO



CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(256) NOT NULL,
    Email NVARCHAR(256) NOT NULL,
    PasswordHash NVARCHAR(MAX) NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id)
);

CREATE TABLE TipoDocumentos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(256) NOT NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id)
);

CREATE TABLE EstadoPruebas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(256) NOT NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id)
);

CREATE TABLE Aspirantes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdTipoDocumento INT NOT NULL,
    NumeroDocumento VARCHAR(20) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
	Apellido VARCHAR(100) NOT NULL,
    Direccion VARCHAR(200) NULL,
    Telefono VARCHAR(20) NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	FOREIGN KEY (IdTipoDocumento) REFERENCES TipoDocumentos (Id),
	FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id)
);

CREATE TABLE TipoPruebas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(256) NOT NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id)
);

CREATE TABLE LenguajeProgramacion (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(256) NOT NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id)
);

CREATE TABLE Nivel (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(256) NOT NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id)
);


CREATE TABLE PruebaSeleccion (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreDescripcion VARCHAR(100) NOT NULL,
    IdTipoPrueba INT NOT NULL,
    IdLenguajeProgramacion INT NOT NULL,
    CantidadPreguntas INT NOT NULL,
    IdNivel INT NOT NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
    FOREIGN KEY (IdTipoPrueba) REFERENCES TipoPruebas(Id),
	FOREIGN KEY (IdLenguajeProgramacion) REFERENCES LenguajeProgramacion(Id),
	FOREIGN KEY (IdNivel) REFERENCES Nivel(Id),
	FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id)
);

CREATE TABLE Preguntas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(200) NOT NULL,
	IdLenguajeProgramacion INT NOT NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	FOREIGN KEY (IdLenguajeProgramacion) REFERENCES LenguajeProgramacion(Id),
    FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id)
);

CREATE TABLE AspirantePruebaSeleccion (
    Id INT IDENTITY(1,1),
	IdAspirante INT NOT NULL,
	IdPruebaSeleccion INT NOT NULL,
	Calificacion DECIMAL(5,2) NULL,
	IdEstadoPrueba INT NOT NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	PRIMARY KEY (Id, IdAspirante, IdPruebaSeleccion),
	FOREIGN KEY (IdAspirante) REFERENCES Aspirantes (Id),
	FOREIGN KEY (IdPruebaSeleccion) REFERENCES PruebaSeleccion (Id),
    FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id),
	FOREIGN KEY (IdEstadoPrueba) REFERENCES EstadoPruebas (Id),
);

CREATE TABLE PreguntasPruebaSeleccion (
    Id INT IDENTITY(1,1),
	IdPregunta INT NOT NULL,
	IdPruebaSeleccion INT NOT NULL,
	Estado BIT NOT NULL,
    IdUsuarioActualizacion INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
	PRIMARY KEY (Id, IdPregunta, IdPruebaSeleccion),
	FOREIGN KEY (IdPregunta) REFERENCES Preguntas (Id),
	FOREIGN KEY (IdPruebaSeleccion) REFERENCES PruebaSeleccion (Id),
    FOREIGN KEY (IdUsuarioActualizacion) REFERENCES Usuarios (Id),
);


