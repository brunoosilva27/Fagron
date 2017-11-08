CREATE DATABASE Fagron
GO
USE Fagron
GO


CREATE TABLE Profissao(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Descricao varchar(30) NOT NULL,
)

CREATE TABLE Cliente(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nome varchar(40),
	Sobrenome varchar(60),
	DataNascimento datetime,
	Idade int,
	ProfissaoId int,
	FOREIGN KEY (ProfissaoId) REFERENCES Profissao(Id)
)


-- CARGA DE DADOS
INSERT INTO Profissao VALUES ('Analista de Sistemas')
INSERT INTO Profissao VALUES ('Programador Jr')
INSERT INTO Profissao VALUES ('Programador Pl')
INSERT INTO Profissao VALUES ('Programador Sr')


