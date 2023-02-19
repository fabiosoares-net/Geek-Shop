create database Geek;
use Geek;

CREATE TABLE Produto (
  IdProduto        uniqueidentifier NOT NULL, 
  NomeCategoria    varchar(255) NOT NULL, 
  Nome             varchar(255) NOT NULL UNIQUE, 
  Descricao        varchar(255) NULL, 
  Preco            decimal(10, 2) NOT NULL, 
  ImageURL         varchar(255) NOT NULL, 
  DataHoraCadastro datetime NOT NULL, 
  PRIMARY KEY (IdProduto));

