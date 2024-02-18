CREATE TABLE LocalidadRecogida
(
Id int identity(1,1),
Recogida varchar(100) not null,
CONSTRAINT  PK_LocalidadRecogida_id PRIMARY KEY (Id),
CONSTRAINT UQ_Recogida UNIQUE (Recogida)
)

CREATE TABLE LocalidadDevolucion
(
Id int identity(1,1),
Devolucion varchar(100),
CONSTRAINT  PK_LocalidadDevolucion_id PRIMARY KEY (Id),
CONSTRAINT UQ_Devolucion UNIQUE (Devolucion)
)

CREATE TABLE TipoVehiculo
(
Id int identity(1,1),
Tipo varchar(100)
CONSTRAINT  PK_TipoVehiculo_id PRIMARY KEY (Id),
CONSTRAINT UQ_TipoCarro UNIQUE (Tipo)
)


CREATE TABLE Vehiculo
(
Id int identity(1,1),
Id_LocalidadRecogida int,
Id_LocalidadDevolucion int,
Id_TipoVehiculo int,
Marca varchar(30),
Modelo int,
Color char(15)
CONSTRAINT  PK_Vehiculo_id PRIMARY KEY (Id),
FOREIGN KEY  (Id_LocalidadRecogida) REFERENCES  LocalidadRecogida(Id),
FOREIGN KEY  (Id_LocalidadDevolucion) REFERENCES  LocalidadDevolucion(Id),
FOREIGN KEY  (Id_TipoVehiculo) REFERENCES  TipoVehiculo(Id),
)

--drop table Vehiculo
--drop table TipoVehiculo
--drop table LocalidadDevolucion
--drop table LocalidadRecogida