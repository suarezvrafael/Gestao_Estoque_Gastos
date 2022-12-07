-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 07-Dez-2022 às 01:20
-- Versão do servidor: 10.4.24-MariaDB
-- versão do PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `gestao_estoque_gasto`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblempresa`
--

CREATE TABLE `tblempresa` (
  `id` int(11) NOT NULL,
  `CNPJ` decimal(10,0) NOT NULL,
  `razaoSocial` varchar(150) NOT NULL,
  `rua` varchar(150) DEFAULT NULL,
  `bairro` varchar(150) DEFAULT NULL,
  `numeroEndereco` int(11) DEFAULT NULL,
  `complemento` varchar(200) DEFAULT NULL,
  `email` varchar(200) DEFAULT NULL,
  `telefone` decimal(10,0) DEFAULT NULL,
  `nomeFantasia` varchar(150) NOT NULL,
  `cidade` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblgastovariado`
--

CREATE TABLE `tblgastovariado` (
  `id` int(11) DEFAULT NULL,
  `descricaoGasto` varchar(140) NOT NULL,
  `valorGasto` decimal(10,0) NOT NULL,
  `idUnidadeMedidaGasto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblingrediente`
--

CREATE TABLE `tblingrediente` (
  `id` int(11) NOT NULL,
  `nomeIngrediente` varchar(150) NOT NULL,
  `precoIngrediente` decimal(10,0) NOT NULL,
  `unidadeMedidaId` int(11) NOT NULL,
  `quantidadeUnidade` decimal(10,0) NOT NULL,
  `empresaId` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblparametros`
--

CREATE TABLE `tblparametros` (
  `percentualLucro` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblpedido`
--

CREATE TABLE `tblpedido` (
  `id` int(11) NOT NULL,
  `idEmpresa` int(11) NOT NULL,
  `dataPedido` datetime NOT NULL,
  `obsPedido` varchar(300) NOT NULL,
  `idUsuario` int(11) NOT NULL,
  `valorTotalReceita` decimal(10,0) NOT NULL,
  `valorMaoDeObra` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblpedidoreceita`
--

CREATE TABLE `tblpedidoreceita` (
  `id` int(11) NOT NULL,
  `idPedido` int(11) NOT NULL,
  `idReceita` int(11) NOT NULL,
  `quantidadeReceita` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblreceita`
--

CREATE TABLE `tblreceita` (
  `id` int(11) NOT NULL,
  `nomeReceita` varchar(140) NOT NULL,
  `idEmpresa` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblreceitaingrediente`
--

CREATE TABLE `tblreceitaingrediente` (
  `id` int(11) NOT NULL,
  `idIngrediente` int(11) NOT NULL,
  `idReceita` int(11) NOT NULL,
  `quantidadeIngrediente` int(11) NOT NULL,
  `idGastoVariado` int(11) NOT NULL,
  `quantidadeGastoVariado` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblunidademedidagastovariado`
--

CREATE TABLE `tblunidademedidagastovariado` (
  `id` int(11) NOT NULL,
  `descricaoUnidadeMedidaGastoVariado` varchar(140) NOT NULL,
  `sigla` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblunidademedidaingrediente`
--

CREATE TABLE `tblunidademedidaingrediente` (
  `id` int(11) NOT NULL,
  `descricaoUnidadeMedidaIngrediente` varchar(200) NOT NULL,
  `sigla` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblusuario`
--

CREATE TABLE `tblusuario` (
  `id` int(11) NOT NULL,
  `nome` varchar(200) DEFAULT NULL,
  `username` varchar(150) NOT NULL,
  `senha` varchar(200) DEFAULT NULL,
  `acesso` enum('1','2') NOT NULL,
  `manterLogado` tinyint(4) NOT NULL,
  `empresaId` int(10) NOT NULL,
  `ativo` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `tblempresa`
--
ALTER TABLE `tblempresa`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblingrediente`
--
ALTER TABLE `tblingrediente`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblpedido`
--
ALTER TABLE `tblpedido`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblpedidoreceita`
--
ALTER TABLE `tblpedidoreceita`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblreceita`
--
ALTER TABLE `tblreceita`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblreceitaingrediente`
--
ALTER TABLE `tblreceitaingrediente`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblunidademedidagastovariado`
--
ALTER TABLE `tblunidademedidagastovariado`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblunidademedidaingrediente`
--
ALTER TABLE `tblunidademedidaingrediente`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblusuario`
--
ALTER TABLE `tblusuario`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tblempresa`
--
ALTER TABLE `tblempresa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblingrediente`
--
ALTER TABLE `tblingrediente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblpedido`
--
ALTER TABLE `tblpedido`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblpedidoreceita`
--
ALTER TABLE `tblpedidoreceita`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblreceitaingrediente`
--
ALTER TABLE `tblreceitaingrediente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblunidademedidagastovariado`
--
ALTER TABLE `tblunidademedidagastovariado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblunidademedidaingrediente`
--
ALTER TABLE `tblunidademedidaingrediente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tblusuario`
--
ALTER TABLE `tblusuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
