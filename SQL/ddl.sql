create database vinos_costeros;

go

use vinos_costeros;

go

create table usuario (
	id bigint identity(1,1) primary key,
	nombre varchar(50) not null,
	apellido varchar(50) not null,
	rol integer not null,
	email varchar(50) not null,
	contrasenia varchar(25) not null,
	estatus char not null
);