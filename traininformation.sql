-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Host: studmysql01.fhict.local
-- Generation Time: Mar 24, 2018 at 04:08 PM
-- Server version: 5.7.13-log
-- PHP Version: 5.6.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbi367789`
--

-- --------------------------------------------------------

--
-- Table structure for table `traininformation`
--

CREATE TABLE `traininformation` (
  `FromStationName` text NOT NULL,
  `ToNearStationName` text NOT NULL,
  `Distance` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `traininformation`
--

INSERT INTO `traininformation` (`FromStationName`, `ToNearStationName`, `Distance`) VALUES
('s-Hertogenbosch', 'Oss', 19),
('s-Hertogenbosch', 'Tilburg', 22),
('s-Hertogenbosch', 'Eindhoven', 32),
('Breda', 'Etten-Leur', 11),
('Breda', 'Tilburg', 21),
('Den Haag', 'Roosendaal', 60),
('Den Haag', 'Breda', 73),
('Eindhoven', 'Tilburg', 37),
('Eindhoven', 's-Hertogenbosch', 32),
('Etten-Leur', 'Roosendaal', 13),
('Etten-Leur', 'Breda', 11),
('Oss', 's-Hertogenbosch', 19),
('Roosendaal', 'Vlissingen', 75),
('Roosendaal', 'Etten-Leur', 13),
('Tilburg', 'Breda', 21),
('Tilburg', 's-Hertogenbosch', 22),
('Tilburg', 'Eindhoven ', 37),
('Vlissingen', 'Roosendaal', 75);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
