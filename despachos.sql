
CREATE DATABASE empresa;
USE empresa;

-- Crear la tabla despacho
CREATE TABLE despacho (
    capacidad INT,    -- Capacidad del despacho
    numero INT,       -- Número del despacho
    PRIMARY KEY (numero)   -- Clave primaria es el número de despacho
);

-- Crear la tabla directores
CREATE TABLE directores (
    NomApels NVARCHAR(255),  -- Nombres y Apellidos del director
    DNI VARCHAR(8) NOT NULL,  -- DNI del director (clave principal)
    DNIJefe VARCHAR(8),       -- DNI del jefe (otro director)
    Despacho INT,             -- Número del despacho (relacionado con despacho)
    PRIMARY KEY (DNI),        -- La clave primaria es el DNI
    FOREIGN KEY (DNIJefe) REFERENCES directores(DNI),  -- Relación recursiva para jefe
    FOREIGN KEY (Despacho) REFERENCES despacho(numero)  -- Relación con la tabla despacho
);


select * from directores;


insert into directores values
('lolo perez ' , 88888888 , null ,4),
('joel lolo ', 22222222 , null ,5);

 insert into directores values
('mariana franck ',11111111,22222222,4),
('laura martines ll ' , 33333333,22222222,4),
('mirian saul ' , 44444444 , 88888888 ,6),
('lautaro perez ' , 55555555 , 22222222 , 4),
('almas ll ' ,66666666 , 88888888 , 5); 

select * from directores as d
inner join despacho as a On a.numero =d.despacho;

#Traer el DNI, nombre y apellido de todos los directores.

select dni , NomApels from directores;

#Traer los datos de los directores que no tienen jefe.

select * from directores where DNIJefe is null ;

#Traer el apellido de aquellos directores que tengan como nombre “arturo”.

insert into directores values 
('arturo alejo ',99999999 , 22222222 , 5);

select NomApels from directores where NomApels like '%arturo%';

#Traer el número de directores que hay en cada despacho.
select a.numero ,count(*) as cantidad from directores as s 
inner join despacho as a on a.numero=s.Despacho
group by a.numero;


#Traer los datos de los directores cuyos jefes no tienen jefes.

select s.DNIJefe , s.NomApels ,s.Despacho, s.dni, count(*) as total from  directores as s
inner  join directores as d on d.DNIJefe=s.dni
group by s.DNIJefe ,s.NomApels ,s.Despacho ,s.dni ;

#Traer la información de los directores cuyos DNI están entre el 30.000.000 y el
#32.000.000.

SELECT 
    *
FROM
    directores
WHERE
    dni >= 30000000 AND dni <= 32000000;

#Traer los despachos que están sobre-utilizados.

select p.numero ,p.capacidad ,count(*) as total from directores as s
inner join despacho as p on p.numero=s.despacho
group by(p.numero)
having(total > p.capacidad);



#Traer el nombre y apellido de los directores que no tienen ningún empleado a cargo.




SELECT d.dni, d.NomApels, COUNT(p.dni) AS cantidad_subordinados
FROM directores AS d
LEFT JOIN directores AS p ON p.DNIJefe = d.dni
where(d.DNIJefe is null)
GROUP BY d.dni, d.NomApels
HAVING COUNT(p.dni) = 0;


#Traer el despacho con el mayor número de directores.


SELECT numero ,COUNT(*) AS cantidad 
FROM despacho AS a
INNER JOIN directores AS d ON a.numero = d.Despacho
GROUP BY a.numero 
ORDER BY cantidad desc 
LIMIT 1;


#Cual es el jefe que tiene mas empleados a cargo?

select a.NomApels ,count(*) as total from directores as a 
inner join directores as e on e.DNIJefe = a.dni 
group by(a.NomApels )
order by(total) desc 
limit 1;

#Traer solo los jefes con mas de 1 empleado a cargo

SELECT d.NomApels, d.DNI, COUNT(e.DNI) AS cantidad_empleados
FROM directores AS d
LEFT JOIN directores AS e ON d.DNI = e.DNIJefe
GROUP BY d.NomApels, d.DNI
having count(e.DNI) > 1;


#Borrar de la base de datos a todos los directores, con excepción de los que no tienen
#jefe.

delete  from directores where directores.DNIJefe is not null;

select * from directores;
