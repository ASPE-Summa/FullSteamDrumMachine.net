-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: fullsteamdrummachine
-- ------------------------------------------------------
-- Server version	5.7.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `instrument`
--

DROP TABLE IF EXISTS `instrument`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `instrument` (
  `instrumentId` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `midiNumber` int(3) NOT NULL,
  PRIMARY KEY (`instrumentId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instrument`
--

LOCK TABLES `instrument` WRITE;
/*!40000 ALTER TABLE `instrument` DISABLE KEYS */;
/*!40000 ALTER TABLE `instrument` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `measure`
--

DROP TABLE IF EXISTS `measure`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `measure` (
  `measureId` int(11) NOT NULL AUTO_INCREMENT,
  `beatUnit` int(5) NOT NULL,
  `beatsInMeasure` int(5) NOT NULL,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`measureId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `measure`
--

LOCK TABLES `measure` WRITE;
/*!40000 ALTER TABLE `measure` DISABLE KEYS */;
/*!40000 ALTER TABLE `measure` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `measureinstrument`
--

DROP TABLE IF EXISTS `measureinstrument`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `measureinstrument` (
  `measureId` int(11) NOT NULL,
  `instrumentId` int(11) NOT NULL,
  `beat` varchar(16) NOT NULL,
  KEY `fk_measureinstrument_measureid_idx` (`measureId`),
  KEY `fk_instrument_id_idx` (`instrumentId`),
  CONSTRAINT `fk_instrument_id` FOREIGN KEY (`instrumentId`) REFERENCES `instrument` (`instrumentId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_measureinstrument_measureid` FOREIGN KEY (`measureId`) REFERENCES `measure` (`measureId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `measureinstrument`
--

LOCK TABLES `measureinstrument` WRITE;
/*!40000 ALTER TABLE `measureinstrument` DISABLE KEYS */;
/*!40000 ALTER TABLE `measureinstrument` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `song`
--

DROP TABLE IF EXISTS `song`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `song` (
  `songId` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `bpm` int(3) NOT NULL,
  PRIMARY KEY (`songId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `song`
--

LOCK TABLES `song` WRITE;
/*!40000 ALTER TABLE `song` DISABLE KEYS */;
/*!40000 ALTER TABLE `song` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `songmeasure`
--

DROP TABLE IF EXISTS `songmeasure`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `songmeasure` (
  `songMeasureId` int(11) NOT NULL AUTO_INCREMENT,
  `songId` int(11) NOT NULL,
  `measureId` int(11) NOT NULL,
  `sequence` int(3) NOT NULL,
  PRIMARY KEY (`songMeasureId`),
  KEY `fk_song_id_idx` (`songId`),
  KEY `fk_measure_id_idx` (`measureId`),
  CONSTRAINT `fk_measure_id` FOREIGN KEY (`measureId`) REFERENCES `measure` (`measureId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_song_id` FOREIGN KEY (`songId`) REFERENCES `song` (`songId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `songmeasure`
--

LOCK TABLES `songmeasure` WRITE;
/*!40000 ALTER TABLE `songmeasure` DISABLE KEYS */;
/*!40000 ALTER TABLE `songmeasure` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-07-07 13:00:07
