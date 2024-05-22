-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Tempo de geração: 23/05/2024 às 00:26
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `api`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `Days`
--

CREATE TABLE IF NOT EXISTS `Days` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `Days`
--

INSERT INTO `Days` (`Id`, `Name`) VALUES
(1, 'Domingo'),
(2, 'Segunda-feira'),
(3, 'Terça-feira'),
(4, 'Quarta-feira'),
(5, 'Quinta-feira'),
(6, 'Sexta-feira'),
(7, 'Sábado');

-- --------------------------------------------------------

--
-- Estrutura para tabela `Tasks`
--

CREATE TABLE IF NOT EXISTS `Tasks` (
  `Id` char(36) NOT NULL,
  `Description` varchar(250) DEFAULT NULL,
  `IdDay` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Tasks_X_Days` (`IdDay`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `Tasks`
--
ALTER TABLE `Tasks`
  ADD CONSTRAINT `FK_Tasks_X_Days` FOREIGN KEY (`IdDay`) REFERENCES `Days` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
