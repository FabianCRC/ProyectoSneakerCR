drop database SneakersCR


create database SneakersCR

use SneakersCR;

create table tiendas(
id_tienda numeric identity,
nombre_tienda varchar(50) not null,
descripcion_tienda varchar(255) not null,
primary key(id_tienda)
)

create table marca_productos(
id_marca numeric identity,
marca_producto varchar(20) not null,
primary key(id_marca)
)


create table categoria_productos(
id_categoria numeric identity,
categoria varchar(20) not null,
primary key(id_categoria)
)

create table productos(
id_producto numeric identity,
nombre_producto varchar(50) not null,
descripcion_pproducto varchar(255) not null,
anno numeric(4) not null,
valor decimal(10,2) not null,
id_marca_producto numeric not null,
id_tienda numeric not null,
id_categoria numeric not null,
primary key(id_producto),
foreign key(id_tienda) references tiendas(id_tienda),
foreign key(id_marca_producto) references marca_productos(id_marca),
foreign key(id_categoria) references categoria_productos(id_categoria)

)


create table ubicacion_tienda(
id_ubicacion numeric identity,
provincia varchar(255) not null,
canton varchar(255) not null,
direccion varchar(255) not null,
id_tienda numeric not null,
primary key(id_ubicacion),
foreign key(id_tienda) references tiendas(id_tienda)
)


create table telefono_tienda(
id_telefono numeric identity,
descripcion varchar(255) not null,
numero varchar(25) not null,
id_tienda numeric not null,
primary key(id_telefono),
foreign key(id_tienda) references tiendas(id_tienda)
)


create table roles(
id_rol numeric,
descripcion_rol varchar(255) not null,
primary key(id_rol)
)

create table usuarios(
id_usuario numeric identity,
nombre_usuario varchar(255) not null,
correo_usuario varchar(255) not null,
contrasena varchar(255) not null,
id_rol numeric not null,
primary key(id_usuario),
foreign key(id_rol) references roles(id_rol)
)

create table valoracion_tienda(
id_valoracion numeric identity,
valoracion numeric(3,1) not null,
comentario varchar(255) not null,
id_usuario numeric not null ,
id_tienda numeric not null,
primary key(id_valoracion),
foreign key(id_usuario) references usuarios(id_usuario),
foreign key(id_tienda) references tiendas(id_tienda)
)


create table correo_tienda(
id_correo numeric identity,
correo varchar(255) not null,
descripcion varchar(255) not null,
id_tienda numeric not null,
primary key(id_correo),
foreign key(id_tienda) references tiendas(id_tienda)
)


create table usuario_tienda(
id_usuario_tienda numeric identity not null,
id_usuario numeric not null,
id_tienda numeric not null,
primary key(id_usuario_tienda),
foreign key(id_usuario) references usuarios(id_usuario),
foreign key(id_tienda) references tiendas(id_tienda)
)