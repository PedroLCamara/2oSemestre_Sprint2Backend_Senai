create database Rental; 
go

use Rental;
go

create table Empresa(
	IdEmpresa tinyint primary key identity(1,1),
	NomeEmpresa varchar(50) not null,
);
go

create table Marca(
	IdMarca tinyint primary key identity(1,1),
	NomeMarca varchar(50) not null,
);
go

create table Modelo(
	IdModelo smallint primary key identity(1,1),
	IdMarca tinyint foreign key references Marca(IDMarca),
	NomeModelo varchar(50) not null,
);
go

create table Veiculo(
	IdVeiculo smallint primary key identity(1,1),
	IdEmpresa tinyint foreign key references Empresa(IDEmpresa),
	IdModelo smallint foreign key references Modelo(IDModelo),
	Placa char(7) not null,
);
go

create table Cliente(
	IdCliente int primary key identity(1,1),
	CPF char(11) NOT NULL UNIQUE,
	NomeCliente varchar(35) not null,
	SobrenomeCliente varchar(100)
);
go

create table Locacao(
	IdLocacao int primary key identity(1,1),
	IdCliente int foreign key references Cliente(IDCliente),
	IdVeiculo smallint foreign key references Veiculo(IDVeiculo),
	DataRetirada date not null,
	DataDevolucao date  not null,
	StatusDevolucao varchar(50) not null,
);
go