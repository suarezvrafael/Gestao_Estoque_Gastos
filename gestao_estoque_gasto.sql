-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 14-Mar-2023 às 00:36
-- Versão do servidor: 10.4.27-MariaDB
-- versão do PHP: 8.2.0

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
-- Estrutura da tabela `tblcidade`
--

CREATE TABLE `tblcidade` (
  `id` int(11) NOT NULL,
  `descricaoCidade` varchar(100) NOT NULL,
  `idEstado` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Extraindo dados da tabela `tblcidade`
--

INSERT INTO `tblcidade` (`id`, `descricaoCidade`, `idEstado`) VALUES
(1, 'Santa Cruz do Sul', 1),
(2, 'Rio Pardo', 1),
(3, 'Vera Cruz', 1),
(4, 'Venancio Aires', 1),
(5, 'Porto Alegre', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblempresa`
--

CREATE TABLE `tblempresa` (
  `id` int(11) NOT NULL,
  `CNPJ` varchar(18) NOT NULL,
  `razaoSocial` varchar(150) NOT NULL,
  `rua` varchar(150) DEFAULT NULL,
  `bairro` varchar(150) DEFAULT NULL,
  `numeroEndereco` int(11) DEFAULT NULL,
  `complemento` varchar(200) DEFAULT NULL,
  `email` varchar(90) DEFAULT NULL,
  `telefone` varchar(15) DEFAULT NULL,
  `nomeFantasia` varchar(150) NOT NULL,
  `idcidade` int(11) NOT NULL,
  `createEmpresa` timestamp NOT NULL DEFAULT current_timestamp(),
  `updateEmpresa` timestamp NULL DEFAULT NULL,
  `idUsername` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Extraindo dados da tabela `tblempresa`
--

INSERT INTO `tblempresa` (`id`, `CNPJ`, `razaoSocial`, `rua`, `bairro`, `numeroEndereco`, `complemento`, `email`, `telefone`, `nomeFantasia`, `idcidade`, `createEmpresa`, `updateEmpresa`, `idUsername`) VALUES
(7, '00099862000222', 'Chocolandia Filial', 'marechal', 'centro', 12, 'ao lado da sorveteria', 'chocolandia@choco.com.br', '51999999999', 'Chocolandia', 1, '2023-02-04 00:02:07', NULL, 0),
(18, '92402542000109', 'Senac Confeitaria', 'Paixao flores', 'Centro', 2509, 'ao lado do banco ', 'senacConfeitaria@senac.com.br', '51998592475', 'Confeitaria da NoNo', 2, '2023-03-13 23:06:44', NULL, 0),
(19, '65721209000190', 'Churrasco Do farias', 'Pleno Pinho', 'centro', 925, 'ao lado da igreja', 'churrascoFEito@farias.com', '51989896567', 'Farias Ou nao ', 4, '2023-03-13 23:11:43', NULL, 0);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblestado`
--

CREATE TABLE `tblestado` (
  `id` int(11) NOT NULL,
  `descricaoEstado` varchar(100) NOT NULL,
  `idPais` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Extraindo dados da tabela `tblestado`
--

INSERT INTO `tblestado` (`id`, `descricaoEstado`, `idPais`) VALUES
(1, 'Rio Grande do Sul', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblgastovariado`
--

CREATE TABLE `tblgastovariado` (
  `id` int(11) DEFAULT NULL,
  `descricaoGasto` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `valorGasto` float(10,0) NOT NULL,
  `idUnidadeMedidaGasto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblingrediente`
--

CREATE TABLE `tblingrediente` (
  `id` int(11) NOT NULL,
  `nomeIngrediente` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `precoIngrediente` float(10,2) NOT NULL,
  `unidadeMedidaId` int(11) NOT NULL,
  `quantidadeUnidade` float(10,3) NOT NULL,
  `empresaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `tblingrediente`
--

INSERT INTO `tblingrediente` (`id`, `nomeIngrediente`, `precoIngrediente`, `unidadeMedidaId`, `quantidadeUnidade`, `empresaId`) VALUES
(1, 'Milho', 4.00, 1, 5.000, 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblpais`
--

CREATE TABLE `tblpais` (
  `id` int(11) NOT NULL,
  `descricaoPais` varchar(140) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Extraindo dados da tabela `tblpais`
--

INSERT INTO `tblpais` (`id`, `descricaoPais`) VALUES
(1, 'Brasil');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblparametros`
--

CREATE TABLE `tblparametros` (
  `percentualLucro` float(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblpedido`
--

CREATE TABLE `tblpedido` (
  `id` int(11) NOT NULL,
  `idEmpresa` int(11) NOT NULL,
  `dataPedido` datetime NOT NULL,
  `obsPedido` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `idUsuario` int(11) NOT NULL,
  `valorTotalReceita` float(10,0) NOT NULL,
  `valorMaoDeObra` float(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblpedidoreceita`
--

CREATE TABLE `tblpedidoreceita` (
  `id` int(11) NOT NULL,
  `idPedido` int(11) NOT NULL,
  `idReceita` int(11) NOT NULL,
  `quantidadeReceita` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblreceita`
--

CREATE TABLE `tblreceita` (
  `id` int(11) NOT NULL,
  `nomeReceita` varchar(140) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `idEmpresa` int(11) NOT NULL,
  `valorTotalReceita` float(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  `qntGastoVariado` float(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblunidademedidagastovariado`
--

CREATE TABLE `tblunidademedidagastovariado` (
  `id` int(11) NOT NULL,
  `descUnidMedGastoVariado` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `sigla` varchar(5) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tblunidademedidaingrediente`
--

CREATE TABLE `tblunidademedidaingrediente` (
  `id` int(11) NOT NULL,
  `descUnidMedIngrediente` varchar(200) NOT NULL,
  `sigla` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Extraindo dados da tabela `tblunidademedidaingrediente`
--

INSERT INTO `tblunidademedidaingrediente` (`id`, `descUnidMedIngrediente`, `sigla`) VALUES
(2, 'Quilos', 'Kg'),
(4, 'Gramas', 'g'),
(5, 'Litros', 'l'),
(6, 'Mililitros', 'ml');

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
  `manterLogado` enum('1','2') NOT NULL,
  `empresaId` int(10) NOT NULL,
  `ativo` enum('1','2') NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Extraindo dados da tabela `tblusuario`
--

INSERT INTO `tblusuario` (`id`, `nome`, `username`, `senha`, `acesso`, `manterLogado`, `empresaId`, `ativo`) VALUES
(1, 'm', 'm', 'm', '1', '1', 18, '1'),
(3, 'Juari de Consuelo', 'juarizinho', 'Senacrs123/*-', '1', '', 7, '1'),
(4, 'Francisca Lucia Mara', 'chiquina', 'Senacrs123/*-', '1', '', 7, '1'),
(5, 'Francieli Da Silva Pereira', 'ciele', 'Senacrs123/*-', '1', '', 7, '1');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `tblcidade`
--
ALTER TABLE `tblcidade`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idEstado` (`idEstado`);

--
-- Índices para tabela `tblempresa`
--
ALTER TABLE `tblempresa`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idcidade` (`idcidade`),
  ADD KEY `idUsername` (`idUsername`);

--
-- Índices para tabela `tblestado`
--
ALTER TABLE `tblestado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idPais` (`idPais`);

--
-- Índices para tabela `tblgastovariado`
--
ALTER TABLE `tblgastovariado`
  ADD KEY `idUnidadeMedidaGasto` (`idUnidadeMedidaGasto`);

--
-- Índices para tabela `tblingrediente`
--
ALTER TABLE `tblingrediente`
  ADD PRIMARY KEY (`id`),
  ADD KEY `empresaId` (`empresaId`),
  ADD KEY `unidadeMedidaId` (`unidadeMedidaId`);

--
-- Índices para tabela `tblpais`
--
ALTER TABLE `tblpais`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `tblpedido`
--
ALTER TABLE `tblpedido`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idUsuario` (`idUsuario`),
  ADD KEY `idEmpresa` (`idEmpresa`);

--
-- Índices para tabela `tblpedidoreceita`
--
ALTER TABLE `tblpedidoreceita`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idPedido` (`idPedido`),
  ADD KEY `idReceita` (`idReceita`);

--
-- Índices para tabela `tblreceita`
--
ALTER TABLE `tblreceita`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idEmpresa` (`idEmpresa`);

--
-- Índices para tabela `tblreceitaingrediente`
--
ALTER TABLE `tblreceitaingrediente`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idIngrediente` (`idIngrediente`),
  ADD KEY `idReceita` (`idReceita`),
  ADD KEY `idGastoVariado` (`idGastoVariado`);

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
  ADD PRIMARY KEY (`id`),
  ADD KEY `empresaId` (`empresaId`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `tblcidade`
--
ALTER TABLE `tblcidade`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `tblempresa`
--
ALTER TABLE `tblempresa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de tabela `tblestado`
--
ALTER TABLE `tblestado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `tblingrediente`
--
ALTER TABLE `tblingrediente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `tblpais`
--
ALTER TABLE `tblpais`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
-- AUTO_INCREMENT de tabela `tblreceita`
--
ALTER TABLE `tblreceita`
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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de tabela `tblusuario`
--
ALTER TABLE `tblusuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `tblempresa`
--
ALTER TABLE `tblempresa`
  ADD CONSTRAINT `tblempresa_ibfk_1` FOREIGN KEY (`idcidade`) REFERENCES `tblcidade` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
