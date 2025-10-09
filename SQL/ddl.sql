create database vinos_costeros;

go

use vinos_costeros;

go

create table usuario(
	id bigint identity(1,1) primary key,
	nombre varchar(50) not null,
	apellido varchar(50) not null,
	email varchar(50) not null,
	contrasenia varchar(25) not null,
	estatus char not null default 1
	idRol integer not null,
);

create table rol(
	id integer identity(1, 1) primary key,
	nombre varchar(50) not null,
	descripcion varchar(50),
	estatus char not null default 1
)

--alto, medio, bajo
create table ranking(
	id integer identity(1, 1) primary key,
	nombre varchar(50) not null,
	descripcion varchar(50)
)

create table cata(
	id integer identity(1, 1) primary key,
	fecha datetime not null,
	observaciones varchar(250),
	idEvaluador bigint not null,
	idProduccion integer not null,
	idRanking integer not null
);
