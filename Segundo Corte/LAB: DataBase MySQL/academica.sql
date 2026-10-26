create database academica;
use academica;

create table programas
(
    cod_prog integer not null primary key,
    descr_prog varchar (50) not null,
    cred_prog int not null
);

create table estudiantes
(
    cod_estudiante integer not null,
    identi_estudiante varchar (20) not null,
    cod_tipo_identi varchar (10) not null,
    Nomb_Estudiante varchar (50) not null,
    Apell_estudiante varchar (50) not null,
    cod_prog integer not null,
    primary key (cod_estudiante),
    foreign key (cod_prog) references programas(cod_prog),
    foreign key (tipo_identi) references Tipo_Identificacion(tipo_identi)
);
create table Tipo_Identificacion
(
	tipo_identi varchar (10) not null
);

create table Estado_Estudiante
(
	cos_estado_estudiante varchar (20) not null,
    des_estado_estudiante varchar (20) not null
);

create table docente
(
    cod_docente integer not null,
    identi_docente varchar (20) not null,
    cod_tipo_identi varchar (10) not null,
    Nomb_Docente varchar (50) not null,
    Apell_Docente varchar (50) not null,
    cod_prog integer not null,
    primary key (cod_estudiante),
    foreign key (cod_prog) references programas(cod_prog)
);

insert into programas(cod_prog,descr_prog,cred_prog) values(1,"Ing. de sistemas",180), (2,"Ing. Industrital",163), (3,"Ing. Catastral y Geodesia",173), (4,"Ing. Electrica",150), (5,"Ing. Electronica",164);
insert into programas(cod_prog,descr_prog, cred_prog) values(6, "Ing. Civil",178),(7, "Ing. Mecatronica",180),(8, "Ing. Aeroespacial",194);

insert into estudiantes(cod_estudiante,identi_estudiante,Nomb_Estudiante,Apell_estudiante,cod_prog) values(5004,"1013160653","Juan" ,"Carmona",5);

select * from programas
select descr_prog as Programas
from programas
select * from estudiantes


SELECT 
	e.cod_estudiante,
    e.identi_estudiante,
    e.Nomb_Estudiante,
    e.Apell_estudiante,
    p.descr_prog
FROM estudiantes AS e, programas AS p
WHERE e.cod_prog = p.cod_prog
AND p.descr_prog = "Ing. Electronica";




