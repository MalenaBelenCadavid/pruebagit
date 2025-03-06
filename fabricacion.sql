#PRACTICA FABRICA
create database fabrica;
use fabrica;

create table articulos(
codigo int ,
nombre nvarchar(100),
precio int ,
fabricante int,
primary key (codigo),
foreign key (fabricante ) references fabricantes(codigo)
);

create table fabricantes (
codigo int ,
nombre nvarchar(100),
primary key(codigo)

);



insert into fabricantes values

(11,'lux'),
(22,'tucci'),
(33,'sancor');


insert into articulos values
# codigo , nombre ,precio , fabricante

(1,'leches',200,33),
(2,'perfume',30200,22),
(3,'jabon ' ,12300,11),
(4,'queso' , 7700,33),
(5,'champu',400,11),
(6,'remero ' ,5000,22),
(7,'buzo',40220,22),
(8,'crema',200,22),
(9,'rolon',100,11),
(10,'desodorante' , 260,11);

#1.	Traer todos los artículos de las fábricas.
select * from producto ;

#2.	Traer el nombre y el precio de todos los artículos.
select p.nombre , p.precio from articulos as p;


#1.	Traer el nombre de los productos sin repetir.
select distinct nombre from articulos;

#4.	Suponiendo que el precio está en dólares, traer el nombre y 
#el precio en pesos formateando la salida “Precio en dólares”.
select p.nombre ,p.precio ,p.fabricante , (p.precio * 1200) as precio_dolar from articulos as p ;


#5.	Traer el nombre de los artículos cuyo precio es mayor a $ 100.
select p.nombre from articulos as p 
where (p.precio > 100);


#6.	Traer el nombre de los artículos cuyo precio rondan entre los $150 y $350.
select p.nombre from articulos as p 
where ((p.precio >150 )and(p.precio<350));

#7.	Calcular el precio promedio de todos los artículos.
select  count(*) / sum(p.precio) as promedio from articulos as p;


#8.	¿Cual es el artículo más barato?  Obtener el nombre y precio.
select * from articulos as p 
order by (p.precio)asc
limit 1;



#9.	Armar un listado completo de artículos, incluyendo todos los datos del artículo y del fabricante. 
select * from articulos as p 
inner join fabricantes as f on f.codigo= p.fabricante ;

#10.	Obtener un listado de artículos, incluyendo su nombre, su precio y el nombre del fabricante.
select a.nombre , a.precio , f.nombre from articulos as a 
inner join fabricantes as f on f.codigo = a.fabricante;


#11.	¿Cual es el precio promedio de los fabricantes de código 02?

insert into fabricantes values
(02,'martin');

insert into articulos values
(11,'papel',200,02),
(12,'lapiz',100,02),
(13,'mina',50,02);




#Cuántos son los productos que cuestan más de $1000?
select count(*) as total  from articulos as p
where(p.precio >1000);


#13.	Traer el nombre y el precio de los artículos cuyo precio sea mayor a $1500. 
# Ordenados descendentemente por precio y ascendentemente por nombre

select p.nombre ,p.precio from articulos as p
where(p.precio> 1500)
order by (p.nombre )asc,(p.precio)desc;

#14.	Calcular el precio promedio de los artículos de cada fabricante, 
# mostrando el nombre de cada fabricante.
select f.nombre ,count(*)/sum(p.precio) as promedio   from articulos as p 
inner join fabricantes as f on f.codigo= p.fabricante 
group by (f.nombre);

#15.	Armar un reporte con el nombre y
#  precio del más caro de cada proveedor (con el nombre del fabricante).

SELECT e.nombre AS fabricante, 
       a.nombre AS articulo, 
       a.precio
FROM articulos AS a
INNER JOIN fabricantes AS e ON e.codigo = a.fabricante
WHERE a.precio = (
    SELECT MAX(a2.precio)
    FROM articulos AS a2
    WHERE a2.fabricante = a.fabricante
);



#los 5 productos mas caros de cada proveedor
SELECT e.nombre AS fabricante, 
       a.nombre AS articulo, 
       a.precio
FROM articulos AS a
INNER JOIN fabricantes AS e ON e.codigo = a.fabricante
WHERE (SELECT COUNT(*) 
       FROM articulos AS a2 
       WHERE a2.fabricante = a.fabricante AND a2.precio > a.precio) < 5
ORDER BY e.nombre, a.precio DESC;
