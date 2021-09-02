USE Rental;
GO

INSERT INTO Empresa (NomeEmpresa)
VALUES ('Rental');
GO

INSERT INTO Marca (NomeMarca)
VALUES ('Volkswgaen'), ('Fiat');
GO

INSERT INTO Modelo (IdMarca, NomeModelo)
VALUES (1 ,'Gol'), (2, 'Pálio');
GO

INSERT INTO Veiculo (IdEmpresa, IdModelo, Placa)
VALUES (1, 1, 'ABC1234'), (1, 2, 'DEF5678');
GO

INSERT INTO Cliente (CPF, NomeCliente, SobrenomeCliente)
VALUES ('01010101010', 'Maria', 'Da Paz'), ('02020202020', 'Ednaldo', 'Pereira'), ('03030303030', '	Chapolin', 'Colorado');
GO

INSERT INTO Locacao (IdCliente, IdVeiculo, DataRetirada, DataDevolucao, StatusDevolucao)
VALUES (1, 2, '01/01/2020', '05/01/2020', 'Devolvido'), (2, 2, '02/02/2021', '06/02/2021', 'Devolvido'), (3, 3, '03/03/2021', '07/03/2021', 'Devolvido');
GO