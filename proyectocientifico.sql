create database segundo;
use segundo;

create table cientifico(
codigo int ,nombre  Varchar(100) , apellido varchar(100),
Primary key(codigo)
);

create table Proyecto_cientifico(
codigo int ,CodigoProyecto int , CodigoCientifico int ,horas int ,
primary key(codigo),
foreign key(codigocientifico ) references cientifico (codigo),
foreign  key( CodigoProyecto) references proyecto (codigo)
);

create table proyecto(
codigo int ,nombre  varchar(100) , 
primary key(codigo)
);

insert into cientifico value
(23,"Echeverria","juan Carlos"),
(12 , "Sanchez","oscar"),
(24, "vicunia ","Maria"),
(59, "Rosales" ,"pedro");

insert into Proyecto_cientifico value
(1,392 ,24,32),
(2,817,24,14),
(3,817,59,21),
(4,392,23,28),
(5,392,59,39);

insert into proyecto value
(392 ,"SIstem integral de ticket(GIT)"),
(817 , "Sistema Gestion Comercial (SIGECO)");

#Consultas 

#Obtener todos los datos de los cientificos incluyendo el 
#nombre de los proyectos asignados a cada uno de los cientificos
select c.nombre ,c.apellido ,c.codigo  from cientifico as c 
inner join Proyecto_cientifico as pc on pc.CodigoCientifico = c.codigo 
inner join proyecto as p on p.codigo = pc.CodigoProyecto ;

#cual es o son los proyectos asignados al cientifico 24  informando codigo y nombre de cada proyecto
select * from cientifico as c
inner join proyecto_Cientifico as pc on pc.CodigoCientifico = c.codigo
inner join proyecto as p on p.codigo= pc.CodigoProyecto
where (c.codigo = 24);

#obtener la cantidad de datos de los cientifico y la cantidad de proyectos asignados 
select c.nombre ,c.apellido ,c.codigo , count(*) as cant from cientifico as c
inner join Proyecto_cientifico as pc on pc.CodigoCientifico = c.codigo
group by c.nombre ,c.apellido ,c.codigo ;

#obtener numero de horas totales por cientifico 
select c.codigo ,SUM(pc.horas) as totales from cientifico as c
inner join Proyecto_cientifico as pc on pc.CodigoCientifico = c.codigo
group by c.codigo;

#obtener datos de los cientificos asignados a mas de un proyecto 
select c.nombre ,c.apellido ,c.codigo , count(*) as total from cientifico as c
inner join proyecto_cientifico as pc on pc.CodigoCientifico = c.codigo
group by c.nombre ,c.apellido ,c.codigo
having(total > 1);


#informar de los proyectos de los cientificos que empieze su apellido con la letra s
select p.nombre , p.codigo ,c.codigo from cientifico as c 
inner join proyecto_cientifico as pc on pc.CodigoCientifico = c.codigo 
inner join proyecto as p on p.codigo = pc.CodigoProyecto
where( c.apellido like 'M%');


#cual es el cientifico  con mayor cantidad de proyectos 
 select c.nombre , c.apellido ,c.codigo , count(*) as total from cientifico as c
 inner join Proyecto_cientifico as pc on pc.CodigoCientifico = c.codigo
 group by c.nombre , c.apellido ,c.codigo
 order by(total)desc
 limit 1 ;
 
 
 #cual es el proyecto con menor cantidad de horas 
 
 select p.nombre , p.codigo , sum(pc.horas ) as total from proyecto as p
 inner join Proyecto_cientifico as pc on pc.CodigoProyecto = p.codigo 
 group by p.nombre , p.codigo 
 order by(total)asc
 limit 1 ;