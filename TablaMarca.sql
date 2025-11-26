use tallercore2;

create table Marcas(
	id int IDENTITY(1,1),
	nombre varchar(100) not null,
	xurl varchar(100),
	constraint pk_marcar primary key (id)
);

Alter table Productos Add Marca int;

Alter table Productos Add constraint fk_productos_marca foreign key (Marca) references Marcas(id);

insert into Marcas Values ('MediaMark','https://www.mediamarkt.es/es/');
insert into Marcas Values ('Declathon','https://www.decathlon.es/es');
insert into Marcas Values ('Carrefour','https://www.carrefour.es/');
insert into Marcas Values ('Corte Ingles','https://www.elcorteingles.es/');
insert into Marcas Values ('Primark','https://www.primark.com/es-es');