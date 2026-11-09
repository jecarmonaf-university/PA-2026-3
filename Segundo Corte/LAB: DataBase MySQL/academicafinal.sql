-- Crear y usar la base de datos
CREATE DATABASE IF NOT EXISTS academica;
USE academica;

-- ==========================================
-- 1. TABLAS INDEPENDIENTES (CATÁLOGOS)
-- ==========================================

CREATE TABLE programas (
    cod_prog INT NOT NULL PRIMARY KEY,
    descr_prog VARCHAR(50) NOT NULL,
    cred_prog INT NOT NULL
);

CREATE TABLE Tipo_Identificacion (
    tipo_identi VARCHAR(10) NOT NULL PRIMARY KEY,
    descr_tipo_identi VARCHAR(50) NOT NULL
);

CREATE TABLE Estado_Estudiante (
    cos_estado_estudiante VARCHAR(20) NOT NULL PRIMARY KEY,
    des_estado_estudiante VARCHAR(50) NOT NULL
);

CREATE TABLE Asignatura (
    cod_asignatura INT NOT NULL PRIMARY KEY,
    des_asignatura VARCHAR(100) NOT NULL,
    cred_asignatura INT NOT NULL
);

-- ==========================================
-- 2. TABLAS DEPENDIENTES DE NIVEL 1
-- ==========================================

CREATE TABLE docente (
    cod_docente INT NOT NULL PRIMARY KEY,
    identi_docente VARCHAR(20) NOT NULL,
    cod_tipo_identi VARCHAR(10) NOT NULL,
    Nomb_Docente VARCHAR(50) NOT NULL,
    Apell_Docente VARCHAR(50) NOT NULL,
    cod_prog INT NOT NULL,
    FOREIGN KEY (cod_prog) REFERENCES programas(cod_prog),
    FOREIGN KEY (cod_tipo_identi) REFERENCES Tipo_Identificacion(tipo_identi)
);

CREATE TABLE estudiantes (
    cod_estudiante INT NOT NULL PRIMARY KEY,
    identi_estudiante VARCHAR(20) NOT NULL,
    cod_tipo_identi VARCHAR(10) NOT NULL,
    Nomb_Estudiante VARCHAR(50) NOT NULL,
    Apell_estudiante VARCHAR(50) NOT NULL,
    cod_prog INT NOT NULL,
    cos_estado_estudiante VARCHAR(20) NOT NULL,
    FOREIGN KEY (cod_prog) REFERENCES programas(cod_prog),
    FOREIGN KEY (cod_tipo_identi) REFERENCES Tipo_Identificacion(tipo_identi),
    FOREIGN KEY (cos_estado_estudiante) REFERENCES Estado_Estudiante(cos_estado_estudiante)
);

CREATE TABLE carga_academica (
    cod_carga_aca INT NOT NULL PRIMARY KEY,
    cod_asignatura INT NOT NULL,
    cod_docente INT NOT NULL,
    FOREIGN KEY (cod_asignatura) REFERENCES Asignatura(cod_asignatura),
    FOREIGN KEY (cod_docente) REFERENCES docente(cod_docente)
);

-- ==========================================
-- 3. TABLAS DEPENDIENTES DE NIVEL 2 (INTERMEDIAS)
-- ==========================================

CREATE TABLE detalle_matricula (
    cod_estudiante INT NOT NULL,
    cod_carga_aca INT NOT NULL,
    id_matricula INT NOT NULL,
    fec_matricula DATE NOT NULL,
    PRIMARY KEY (cod_estudiante, cod_carga_aca),
    FOREIGN KEY (cod_estudiante) REFERENCES estudiantes(cod_estudiante),
    FOREIGN KEY (cod_carga_aca) REFERENCES carga_academica(cod_carga_aca)
);

CREATE TABLE notas (
    cod_estudiante INT NOT NULL,
    cod_carga_aca INT NOT NULL,
    n1 DECIMAL(4,2),
    n2 DECIMAL(4,2),
    n3 DECIMAL(4,2),
    PRIMARY KEY (cod_estudiante, cod_carga_aca),
    FOREIGN KEY (cod_estudiante) REFERENCES estudiantes(cod_estudiante),
    FOREIGN KEY (cod_carga_aca) REFERENCES carga_academica(cod_carga_aca)
);


-- ==========================================
-- 4. INSERCIÓN DE 3 REGISTROS POR CADA TABLA
-- ==========================================

-- 1. Programas (Incluyendo tus ingenierías reales)
INSERT INTO programas(cod_prog, descr_prog, cred_prog) VALUES
(1, 'Ing. de sistemas', 180), 
(2, 'Ing. Industrial', 163), 
(5, 'Ing. Electronica', 164);

-- 2. Tipo de Identificación
INSERT INTO Tipo_Identificacion (tipo_identi, descr_tipo_identi) VALUES 
('CC', 'Cédula de Ciudadanía'), 
('TI', 'Tarjeta de Identidad'), 
('CE', 'Cédula de Extranjería');

-- 3. Estado Estudiante
INSERT INTO Estado_Estudiante (cos_estado_estudiante, des_estado_estudiante) VALUES 
('ACT', 'Activo'), 
('INA', 'Inactivo'), 
('GRA', 'Graduado');

-- 4. Asignatura
INSERT INTO Asignatura (cod_asignatura, des_asignatura, cred_asignatura) VALUES
(201, 'Bases de Datos I', 4),
(202, 'Circuitos Electrónicos', 3),
(203, 'Investigación de Operaciones', 4);

-- 5. Docente
INSERT INTO docente (cod_docente, identi_docente, cod_tipo_identi, Nomb_Docente, Apell_Docente, cod_prog) VALUES
(301, '79123456', 'CC', 'Alberto', 'Gutiérrez', 5),
(302, '52987654', 'CC', 'Claudia', 'Mendoza', 1),
(303, '80111222', 'CC', 'Hernán', 'Rojas', 2);

-- 6. Estudiantes (Incluyendo tu registro de Juan Carmona)
INSERT INTO estudiantes (cod_estudiante, identi_estudiante, cod_tipo_identi, Nomb_Estudiante, Apell_estudiante, cod_prog, cos_estado_estudiante) VALUES 
(5004, '1013160653', 'CC', 'Juan', 'Carmona', 5, 'ACT'),
(5005, '1023456789', 'TI', 'Laura', 'Jiménez', 1, 'ACT'),
(5006, '1039876541', 'CC', 'Mateo', 'Silva', 2, 'INA');

-- 7. Carga Académica
INSERT INTO carga_academica (cod_carga_aca, cod_asignatura, cod_docente) VALUES
(401, 201, 301),
(402, 202, 302),
(403, 203, 303);

-- 8. Detalle Matrícula
INSERT INTO detalle_matricula (cod_estudiante, cod_carga_aca, id_matricula, fec_matricula) VALUES
(5004, 401, 901, '2026-02-01'),
(5005, 402, 902, '2026-02-01'),
(5006, 403, 903, '2026-02-02');

-- 9. Notas
INSERT INTO notas (cod_estudiante, cod_carga_aca, n1, n2, n3) VALUES
(5004, 401, 4.50, 4.00, 4.80),
(5005, 402, 3.50, 3.20, 4.00),
(5006, 403, 2.80, 3.00, 2.90);
