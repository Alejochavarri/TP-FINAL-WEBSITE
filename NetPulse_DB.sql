CREATE DATABASE BD_NetPulse
Go

USE BD_NetPulse
Go

Create Table Estado_Servicio (
	ID INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	DESCRIPCION VARCHAR(50) NOT NULL
)


Create Table Cliente(
    IdCliente INT PRIMARY KEY not null identity (1, 1),
    Nombre VARCHAR(255) NOT NULL,
    Telefono VARCHAR(20) unique,
    Mail VARCHAR(255) unique,
    Dni VARCHAR(20) NOT NULL unique,
    FechaAlta DATETIME not null,
    Activo bit not null,
)
Go

Create Table Domicilio(
    IdDomicilio int primary key not null identity (1, 1),
    Direccion VARCHAR(255) not null,
    Barrio varchar(255),
    Ciudad varchar(255),
    Comentario varchar(255)
)
Go

Create Table TPlan(
    IdPlan INT PRIMARY KEY not null identity (1, 1),
	Nombre varchar(50) not null,
    CantidadMegas int not null,
    Precio money not null
)
Go

Create Table FormaPago(
    IdFormaPago int primary key not null identity (1, 1),
    Nombre varchar(50) not null
)
Go

Create Table AbonoMensual(
    IdAbonoMensual int primary key not null identity (1, 1),
    IdFormaPago int not null,
    FechaVencimiento1 datetime not null,
    FechaVencimiento2 datetime not null,
    Pagado bit not null,
    -- //////////////////
    FOREIGN KEY (IdFormaPago) REFERENCES FormaPago (IdFormaPago)
)
Go

CREATE TABLE Servicio(
    IdServicio INT PRIMARY KEY not null identity (1, 1),
    IdCliente INT not null,
    IdDomicilio int not null,
    IdPlan int not null,
    IdAbonoMensual int not null,
    FechaAlta datetime not null,
    Estado INT not null,
    --TecnicoResponsable VARCHAR(255),
    Comentarios text,
    FOREIGN KEY (IdCliente) REFERENCES Cliente (IdCliente),
    FOREIGN KEY (IdDomicilio) REFERENCES Domicilio (IdDomicilio),
    FOREIGN KEY (IdPlan) REFERENCES TPlan (IdPlan),
    FOREIGN KEY (IdAbonoMensual) REFERENCES AbonoMensual (IdAbonoMensual),
	FOREIGN KEY (ESTADO) REFERENCES ESTADO_SERVICIO (ID)
)
Go

Create Table Tecnico(
    IdTecnico int PRIMARY KEY not null identity (1, 1),
    Nombre VARCHAR(50) not null,
    Contacto VARCHAR(50) unique,
    FechaIncorporacion datetime not null,
    Estado bit not null
)
Go

Create Table TipoMantenimiento(
    IdTipoMantenimiento int primary key not null identity (1, 1),
    Nombre varchar(50) not null
)
Go

CREATE TABLE Mantenimiento(
    IdMantenimiento int primary key not null identity (1, 1),
    IdServicio int not null,
    Fecha DATETIME not null,
    FechaRealizado DATETIME not null,
    IdTecnico int not null,
    Descripcion text,
    --Costo REVISAR
    IdTipoMantenimiento INT not null,
    --ComponentesCambiados text,
    Comentarios text,
    EstadoRealizacion BIT not null,
    FOREIGN KEY (IdServicio) REFERENCES Servicio (IdServicio),
    FOREIGN KEY (IdTecnico) REFERENCES Tecnico (IdTecnico),
    FOREIGN KEY (IdTipoMantenimiento) REFERENCES TipoMantenimiento (IdTipoMantenimiento)
)

Go
create table Tipo_Cambio_Historial(
    ID int PRIMARY KEY not null identity(1,1),
    Descripcion varchar(50)
)

GO
CREATE TABLE HistorialCliente(
    ID int PRIMARY KEY not NULL identity(1,1),
    IdCliente int not NULL,
    Fecha DATETIME not null,
    IdTipoCambio int not null,
    FOREIGN KEY (IdCliente) REFERENCES Cliente (IdCliente),
    FOREIGN KEY (IdTipoCambio) REFERENCES Tipo_Cambio_Historial (ID),
)

Go
CREATE TABLE HistorialServicio(
    ID int PRIMARY KEY not NULL identity(1,1),
    IdServicio int not null,
    Fecha DATETIME not null,
    IdTipoCambio int not null,
    FOREIGN KEY (IdServicio) REFERENCES Servicio (IdServicio),
    FOREIGN KEY (IdTipoCambio) REFERENCES Tipo_Cambio_Historial (ID)
)


Insert into Tipo_Cambio_Historial(Descripcion)
VALUES
    ('Alta'),
    ('Instalacion'),
	('Modificacion de datos'),
	('Cambio de plan'),
	('Cambio de Forma de Pago'),
	('Cambio de estado de servicio'),
	('Reclamo'),
    ('Mantenimiento Realizado'),
    ('Desinstalacion'),
	('Baja')
Go

INSERT INTO Cliente (Nombre, Telefono, Mail, Dni, FechaAlta, Activo)
VALUES
     ('Juan Pérez', '1123456789', 'jPerez@mail.com', '12345678', '2023-11-05', 1),
    ('María García', '1145678901', 'mGarcia@mail.com', '87654321', '2023-10-15', 1),
    ('Carlos López', '1156789012', 'cLopez@mail.com', '23456789', '2022-12-20', 0),
    ('Laura Martínez', '1167890123', 'lMartinez@mail.com', '34567890', '2022-08-25', 0),
    ('Diego Rodríguez', '1189012345', 'dRodriguez@mail.com', '45678901', '2021-05-12', 1),
    ('Valeria Fernández', '1123456790', 'vFernandez@mail.com', '56789012', '2023-09-07', 1),
    ('Lucas Pérez', '1134567890', 'lPerez@mail.com', '67890123', '2020-07-18', 1),
    ('Sofía López', '1145678902', 'sLopez@mail.com', '78901234', '2022-03-29', 1),
    ('Joaquín González', '1156789013', 'jGonzalez@mail.com', '89012345', '2021-11-14', 1),
    ('Elena Torres', '1190123456', 'eTorres@mail.com', '90123456', '2022-04-03', 0);
GO

INSERT INTO Domicilio (Direccion, Barrio, Ciudad, Comentario)
VALUES
    ('Av. General Paz 123', 'Nueva Córdoba', 'Córdoba', 'No hay timbre'),
    ('Av. Santa Fe 456', 'Palermo', 'Buenos Aires', 'Departamento B'),
    ('Av. Hipólito Yrigoyen 789', 'Güemes', 'Córdoba', ''),
    ('Av. Libertador 1011', 'La Boca', 'Buenos Aires', ''),
    ('Av. Corrientes 1213', 'Centro', 'Buenos Aires', 'La casa de techo marrón y rejas negras'),
    ('Av. Vélez Sársfield 1415', 'Alberdi', 'Córdoba', 'Cuidado con el perro'),
    ('Av. Callao 1617', 'Recoleta', 'Buenos Aires', ''),
    ('Av. Rivadavia 1819', 'Caballito', 'Buenos Aires', 'Avisarme por telefono'),
    ('Av. Maipú 2021', 'Olivos', 'Buenos Aires', ''),
    ('Av. 9 de Julio 2223', 'San Nicolás', 'Buenos Aires', 'Piso 10');
GO

INSERT INTO TPlan (Nombre, CantidadMegas, Precio)
VALUES
    ('Base', 10, 29.99),
    ('Bronce', 25, 69.99),
    ('Plata', 50, 119.99),
    ('Oro', 100, 229.99);
GO

INSERT INTO FormaPago (Nombre)
VALUES
    ('Tarjeta de Crédito'),
    ('Transferencia Bancaria'),
    ('Efectivo');
GO

INSERT INTO AbonoMensual (IdFormaPago, FechaVencimiento1, FechaVencimiento2, Pagado)
VALUES
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 0),
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 1),
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 0),
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 1),
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 0),
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 1),
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 0),
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 1),
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 0),
    (1, DATEADD(MONTH, 1, GETDATE()), DATEADD(MONTH, 2, GETDATE()), 1);
GO

INSERT INTO Tecnico (Nombre, Contacto, FechaIncorporacion, Estado)
VALUES
    ('Tecnico Pepe', '123-456-7890', GETDATE(), 1),
    ('Tecnico Jose', '987-654-3210', GETDATE(), 1),
    ('Tecnico Luis', '555-444-3679', GETDATE(), 1);
GO

INSERT INTO TipoMantenimiento (Nombre)
VALUES
    ('Prioridad Alta'),
    ('Prioridad Media'),
    ('Instalacion'),
    ('Prioridad Baja'),
    ('Desinstalación');
GO

INSERT INTO Estado_Servicio (Descripcion) 
VALUES 
	('Pendiente a Activacion'),
	('Pendiente a Instalacion'),
	('Instalado'),
	('Inhabilitado'),
	('Inactivo'),
	('Desinstalado'),
	('Registra Deuda');
Go

INSERT INTO Servicio (IdCliente, IdDomicilio, IdPlan, IdAbonoMensual, FechaAlta, Estado, Comentarios)
VALUES
    (1, 1, 1, 1, GETDATE(), 1, ''),
    (2, 2, 2, 2, GETDATE(), 1, ''),
    (3, 3, 3, 3, GETDATE(), 2, ''),
    (4, 4, 4, 4, GETDATE(), 3, ''),
    (5, 5, 1, 5, GETDATE(), 4, ''),
    (6, 6, 2, 6, GETDATE(), 5, ''),
    (7, 7, 3, 7, GETDATE(), 6, ''),
    (8, 8, 4, 8, GETDATE(), 3, ''),
    (9, 9, 1, 9, GETDATE(), 2, ''),
    (10, 10, 2, 10, GETDATE(), 4, '');
GO

Insert into HistorialCliente(IdCliente, Fecha, IdTipoCambio)
Values
(1,'2023-11-05',1),
(2,'2023-10-15',3),
(2,'2023-10-15',1),
(1,'2023-12-02',10);
Go

INSERT INTO Mantenimiento (IdServicio, Fecha, FechaRealizado, IdTecnico, Descripcion, IdTipoMantenimiento, Comentarios, EstadoRealizacion)
VALUES
    (1, GETDATE(),GETDATE(), 1, 'Mantenimiento Correctivo', 2, 'Estaba todo sucio', 1),
    (2, GETDATE(),GETDATE(), 2, 'Mantenimiento Emergencia', 1, 'Antena caida', 0),
    (3, GETDATE(),GETDATE(), 1, 'Instalacion', 3, '', 1),
    (4, GETDATE(),GETDATE(), 3, 'Mantenimiento Preventivo', 4, 'Antena movida', 0),
    (5, GETDATE(),GETDATE(), 2, 'Mantenimiento Emergencia', 1, 'Router quemado', 1),
    (6, GETDATE(),GETDATE(), 1, 'Mantenimiento Correctivo', 2, 'Antena movida', 0),
    (7, GETDATE(),GETDATE(), 3, 'Instalacion', 3, '', 1),
    (8, GETDATE(),GETDATE(), 2, 'Mantenimiento Preventivo', 4, 'Cambio de contraseña', 0),
    (9, GETDATE(),GETDATE(), 1, 'Mantenimiento Emergencia', 1, 'Cable router cortado', 1),
    (10, GETDATE(),GETDATE(), 3, 'Mantenimiento Correctivo', 2, 'Antena movida', 0);
GO

Insert into HistorialServicio(IdServicio, Fecha, IdTipoCambio)
Values
(1,'2023-11-05',1),
(1,'2023-11-10',2),
(1,'2023-11-11',4),
(1,'2023-11-18',6),
(1,'2023-11-20',7),
(1,'2023-11-22',8),
(1,'2023-11-24',7),
(1,'2023-11-25',8),
(1,'2023-11-30',9),
(1,'2023-12-02',10)
Go


Create View VistaServicios as (
select IdServicio,C.IdCliente ,C.Nombre as NombreCliente ,C.Telefono, C.Mail , C.Dni, C.FechaAlta as FACliente, C.Activo as ActivoCliente, 
Am.IdAbonoMensual, Am.IdFormaPago as IdFormaPagoAm, Am.FechaVencimiento1, Am.FechaVencimiento2, Am.Pagado,
Fp.IdFormaPago, Fp.Nombre as FormaPago, 
P.IdPlan,P.CantidadMegas, P.Precio,P.Nombre as NombrePlan,
D.IdDomicilio,D.Direccion, D.Barrio, D.Ciudad, D.Comentario as DireccionComentarios,
S.FechaAlta as FechaAltaServicio,E_S.ID as ID_Estado,E_S.DESCRIPCION as Estado,S.Comentarios as ComentarioServicios from Servicio S
inner join Cliente as C on C.IdCliente = S.IdCliente
inner join AbonoMensual as Am on Am.IdAbonoMensual = S.IdAbonoMensual
inner join FormaPago as Fp on Fp.IdFormaPago = Am.IdFormaPago
inner join TPlan as P on P.IdPlan = S.IdPlan
inner join Domicilio as D on D.IdDomicilio = S.IdDomicilio
inner join ESTADO_SERVICIO as E_S on E_S.ID = S.Estado
)

/*select IdServicio, IdCliente, NombreCliente, Telefono, Mail, Dni, FACliente, ActivoCliente, 
IdAbonoMensual, IdFormaPagoAm,FechaVencimiento1, FechaVencimiento2, Pagado, 
IdFormaPago, FormaPago, 
IdPlan, CantidadMegas, Precio, 
IdDomicilio, Direccion,Barrio, Ciudad, DireccionComentarios,
FechaAltaServicio, Estado, ComentarioServicios from VistaServicios*/
