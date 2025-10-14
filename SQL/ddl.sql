CREATE DATABASE vinos_costeros;
GO


USE vinos_costeros;
GO


CREATE TABLE rol (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(50),
    estatus CHAR(1) NOT NULL DEFAULT '1'
);
GO


CREATE TABLE usuario (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    contrasenia VARCHAR(25) NOT NULL,
    estatus CHAR(1) NOT NULL DEFAULT '1',
    idRol INT NOT NULL,

    CONSTRAINT FK_usuario_rol FOREIGN KEY (idRol) REFERENCES rol(id)
);
GO


--CREATE TABLE ranking (
--    id INT IDENTITY(1,1) PRIMARY KEY,
--    nombre VARCHAR(50) NOT NULL,
--    descripcion VARCHAR(50)
--);
--GO


CREATE TABLE parcela (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    ubicacion VARCHAR(200),
    superficie_ha DECIMAL(5,2)
);
GO


CREATE TABLE produccion (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE,
    parcela_id INT NOT NULL,

    CONSTRAINT FK_produccion_parcela FOREIGN KEY (parcela_id) REFERENCES parcela(id)
);
GO


CREATE TABLE siembra (
    id INT IDENTITY(1,1) PRIMARY KEY,
    parcela_id INT NOT NULL,
    variedad_uva VARCHAR(100) NOT NULL,
    fecha_siembra DATE NOT NULL,
    estado VARCHAR(50),

    CONSTRAINT FK_siembra_parcela FOREIGN KEY (parcela_id) REFERENCES parcela(id)
);
GO


CREATE TABLE controlSiembra (
    id INT IDENTITY(1,1) PRIMARY KEY,
    siembra_id INT NOT NULL,
    fecha DATE NOT NULL,
    observaciones VARCHAR(255),
    --temperatura DECIMAL(4,1),
    --humedad DECIMAL(5,2),

    CONSTRAINT FK_controlSiembra_siembra FOREIGN KEY (siembra_id) REFERENCES siembra(id)
);
GO


CREATE TABLE faseProduccion (
    id INT IDENTITY(1,1) PRIMARY KEY,
    produccion_id INT NOT NULL,
    nombre_fase VARCHAR(100) NOT NULL,
    descripcion VARCHAR(100) NOT NULL,
    --fecha_inicio DATE NOT NULL,
    --fecha_fin DATE,

    CONSTRAINT FK_faseProduccion_produccion FOREIGN KEY (produccion_id) REFERENCES produccion(id)
);
GO


CREATE TABLE cata (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fecha DATETIME NOT NULL,
    calificacion INT NOT NULL,
    observaciones VARCHAR(250),
    idEvaluador BIGINT NOT NULL,
    idProduccion INT NOT NULL,
    --idRanking INT NOT NULL,

    CONSTRAINT FK_cata_usuario FOREIGN KEY (idEvaluador) REFERENCES usuario(id),
    CONSTRAINT FK_cata_produccion FOREIGN KEY (idProduccion) REFERENCES produccion(id),
    --CONSTRAINT FK_cata_ranking FOREIGN KEY (idRanking) REFERENCES ranking(id)
);
GO
