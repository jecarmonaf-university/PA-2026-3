CREATE DATABASE IF NOT EXISTS invernadero;

USE invernadero;

CREATE TABLE IF NOT EXISTS usuarios (
    id int unsigned NOT NULL AUTO_INCREMENT,
    nombre varchar(100) NOT NULL,
    nombre_acceso varchar(50) NOT NULL,
    contrasena varchar(255) NOT NULL,
    rol enum('admin', 'usuario') NOT NULL DEFAULT 'usuario',
    activo tinyint(1) NOT NULL DEFAULT '1',
    fecha_creacion datetime(3) NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
    PRIMARY KEY (id),
    UNIQUE KEY uq_usuarios_nombre_acceso (nombre_acceso),
    CONSTRAINT chk_usuarios_activo CHECK ((activo in (0, 1)))
);

SHOW TABLES;

INSERT INTO usuarios (nombre, nombre_acceso, contrasena, rol, activo) VALUES
('Administrador', 'admin', 'admin123', 'admin', 1), 
('Usuario Normal', 'usuario', 'usuario123', 'usuario', 1);

SELECT * FROM usuarios;
