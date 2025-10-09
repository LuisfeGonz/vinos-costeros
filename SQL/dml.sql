USE vinos_costeros;
GO

INSERT INTO rol (nombre, descripcion, estatus) VALUES
('Administrador', 'Gestión total del sistema', '1'),
('Catador', 'Encargado de realizar catas', '1'),
('Operador', 'Usuario de campo', '1');

INSERT INTO usuario (nombre, apellido, email, contrasenia, estatus, idRol) VALUES
('María', 'Pérez', 'maria.perez@vinocostero.cl', '12345', '1', 2),
('Juan', 'García', 'juan.garcia@vinocostero.cl', 'admin123', '1', 1);

INSERT INTO ranking (nombre, descripcion) VALUES
('Alto', 'Alta calidad en aroma, sabor y textura'),
('Medio', 'Calidad aceptable con algunos defectos'),
('Bajo', 'Presencia de defectos notables');

INSERT INTO parcela (nombre, ubicacion, superficie_ha) VALUES
('Parcela Norte', 'Leyda, Región de Valparaíso', 3.5),
('Parcela Sur', 'Leyda, Región de Valparaíso', 2.0);

INSERT INTO produccion (nombre, fecha_inicio, fecha_fin, parcela_id) VALUES
('Producción 2023-A', '2023-01-10', '2023-06-15', 1),
('Producción 2024-B', '2024-01-12', NULL, 2);

INSERT INTO produccion (nombre, fecha_inicio, fecha_fin, parcela_id) VALUES
('Producción 2023-A', '2023-01-10', '2023-06-15', 1),
('Producción 2024-B', '2024-01-12', NULL, 2);

INSERT INTO siembra (parcela_id, variedad_uva, fecha_siembra, estado) VALUES
(1, 'Sauvignon Blanc', '2022-09-01', 'Activa'),
(2, 'Chardonnay', '2023-09-15', 'Activa');

INSERT INTO controlSiembra (siembra_id, fecha, observaciones, temperatura, humedad) VALUES
(1, '2023-10-01', 'Buen estado general', 18.7, 72.5),
(2, '2023-10-02', 'Hojas ligeramente secas', 21.2, 68.3);

INSERT INTO faseProduccion (produccion_id, nombre_fase, fecha_inicio, fecha_fin) VALUES
(1, 'Fermentación', '2023-02-01', '2023-02-20'),
(1, 'Clarificación', '2023-02-21', '2023-03-10'),
(2, 'Fermentación', '2024-02-01', NULL);

INSERT INTO cata (fecha, calificacion, observaciones, idEvaluador, idProduccion, idRanking) VALUES
('2023-06-20 15:30:00', 9, 'Notas florales, buena acidez, excelente cuerpo', 1, 1, 1);


select * from rol;
select * from usuario;
select * from ranking;
select * from parcela;
select * from produccion;
select * from faseProduccion;
select * from siembra;
select * from controlSiembra;
select * from cata;