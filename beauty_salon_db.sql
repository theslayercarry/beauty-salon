-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: beauty_salon
-- ------------------------------------------------------
-- Server version	8.0.32
create database beauty_salon;
use beauty_salon;


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
-- Table structure for table `beauty_salon`
--

DROP TABLE IF EXISTS `beauty_salon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `beauty_salon` (
  `idbeauty_salon` int NOT NULL AUTO_INCREMENT,
  `title` char(100) NOT NULL,
  `location` char(200) NOT NULL,
  `phone` varchar(16) NOT NULL,
  `email` char(100) NOT NULL,
  `work_schedule_from` time NOT NULL,
  `work_schedule_to` time NOT NULL,
  PRIMARY KEY (`idbeauty_salon`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `beauty_salon`
--

LOCK TABLES `beauty_salon` WRITE;
/*!40000 ALTER TABLE `beauty_salon` DISABLE KEYS */;
INSERT INTO `beauty_salon` VALUES (1,'Curl Bar Beauty Salon','41 Jarvis Street, Toronto,ON M5E 0A1, Canada','4167772875','Info@curlbar.Ca','10:00:00','18:00:00');
/*!40000 ALTER TABLE `beauty_salon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `beauty_salon_to_expenses`
--

DROP TABLE IF EXISTS `beauty_salon_to_expenses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `beauty_salon_to_expenses` (
  `idmonthly_expense` int NOT NULL,
  `idbeauty_salon` int NOT NULL,
  PRIMARY KEY (`idmonthly_expense`,`idbeauty_salon`),
  KEY `idbeauty_salon` (`idbeauty_salon`),
  CONSTRAINT `beauty_salon_to_expenses_ibfk_1` FOREIGN KEY (`idmonthly_expense`) REFERENCES `monthly_expenses` (`idmonthly_expenses`),
  CONSTRAINT `beauty_salon_to_expenses_ibfk_2` FOREIGN KEY (`idbeauty_salon`) REFERENCES `beauty_salon` (`idbeauty_salon`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `beauty_salon_to_expenses`
--

LOCK TABLES `beauty_salon_to_expenses` WRITE;
/*!40000 ALTER TABLE `beauty_salon_to_expenses` DISABLE KEYS */;
INSERT INTO `beauty_salon_to_expenses` VALUES (1,1);
/*!40000 ALTER TABLE `beauty_salon_to_expenses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `idcustomers` int NOT NULL AUTO_INCREMENT,
  `email` char(100) NOT NULL,
  `phone` varchar(16) NOT NULL,
  `name` varchar(100) NOT NULL,
  `date_of_joining` date NOT NULL,
  PRIMARY KEY (`idcustomers`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'anstar@gmail.com','79026581480','Anika Sutton','2023-01-16'),(3,'margaret6@mail.ru','79034567033','Margaret Lindsay','2023-06-27'),(4,'kaycee65@gmail.com','79044395601','Julia Adderiy','2023-06-27'),(5,'sofeeke@gmail.com','79027539134','Miranda Jill','2023-06-27'),(6,'landen45@gmail.com','79025646201','Nicole Evans','2023-06-27'),(7,'miranda01@mail.ru','79024523451','Miranda Adams','2023-06-27'),(8,'vanhaig@mail.ru','79045644150','Vanessa Haig','2023-06-27');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers_to_staff`
--

DROP TABLE IF EXISTS `customers_to_staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers_to_staff` (
  `idcustomers_to_staff` int NOT NULL AUTO_INCREMENT,
  `id_staff` int NOT NULL,
  `id_customer` int NOT NULL,
  `id_service` int NOT NULL,
  `appointment_time` datetime NOT NULL,
  `id_discount_promotions` int DEFAULT NULL,
  PRIMARY KEY (`idcustomers_to_staff`),
  KEY `id_staff` (`id_staff`),
  KEY `id_customer` (`id_customer`),
  KEY `id_service` (`id_service`),
  KEY `id_discount_promotions` (`id_discount_promotions`),
  CONSTRAINT `customers_to_staff_ibfk_1` FOREIGN KEY (`id_staff`) REFERENCES `staff` (`idstaff`),
  CONSTRAINT `customers_to_staff_ibfk_2` FOREIGN KEY (`id_customer`) REFERENCES `customers` (`idcustomers`),
  CONSTRAINT `customers_to_staff_ibfk_3` FOREIGN KEY (`id_service`) REFERENCES `services` (`idservices`),
  CONSTRAINT `customers_to_staff_ibfk_4` FOREIGN KEY (`id_discount_promotions`) REFERENCES `discount_promotions` (`iddiscount_promotions`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers_to_staff`
--

LOCK TABLES `customers_to_staff` WRITE;
/*!40000 ALTER TABLE `customers_to_staff` DISABLE KEYS */;
INSERT INTO `customers_to_staff` VALUES (1,1,1,1,'2023-03-21 11:30:00',1),(3,6,3,18,'2023-06-27 12:00:00',NULL),(4,6,4,19,'2023-06-27 12:00:00',NULL),(5,2,5,6,'2023-06-27 18:30:00',NULL),(6,3,6,8,'2023-06-27 10:00:00',NULL),(7,2,7,2,'2023-06-27 17:00:00',NULL),(8,3,8,7,'2023-06-27 12:00:00',NULL),(9,2,6,2,'2023-05-12 09:30:00',NULL),(10,2,6,3,'2023-05-14 12:00:00',NULL),(11,2,6,4,'2023-06-01 17:30:00',NULL),(12,4,3,9,'2022-01-09 11:00:00',NULL),(13,4,3,12,'2022-01-11 13:30:00',NULL),(14,4,3,13,'2022-01-15 14:00:00',NULL),(15,4,3,14,'2022-01-21 09:30:00',NULL),(16,5,7,11,'2022-03-28 16:30:00',NULL),(17,5,7,12,'2022-04-02 17:00:00',NULL),(18,5,7,13,'2022-04-04 17:00:00',NULL),(25,2,5,5,'2023-02-16 12:00:00',NULL),(26,4,5,14,'2023-03-11 13:30:00',NULL),(27,1,5,1,'2023-03-15 17:00:00',NULL),(28,4,1,9,'2023-05-04 11:00:00',NULL),(29,3,1,8,'2023-05-06 08:30:00',NULL),(30,6,1,19,'2023-05-20 18:30:00',NULL),(31,5,4,12,'2023-05-18 15:30:00',NULL),(32,6,4,18,'2023-05-19 16:00:00',NULL);
/*!40000 ALTER TABLE `customers_to_staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `discount_promotions`
--

DROP TABLE IF EXISTS `discount_promotions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `discount_promotions` (
  `iddiscount_promotions` int NOT NULL AUTO_INCREMENT,
  `title` char(100) NOT NULL,
  `condition` text NOT NULL,
  `discount_amount` float NOT NULL,
  `time_of_action_from` datetime DEFAULT NULL,
  `time_of_action_to` datetime DEFAULT NULL,
  PRIMARY KEY (`iddiscount_promotions`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `discount_promotions`
--

LOCK TABLES `discount_promotions` WRITE;
/*!40000 ALTER TABLE `discount_promotions` DISABLE KEYS */;
INSERT INTO `discount_promotions` VALUES (1,'Birthday discount','One of the benefits of joining the \"Curl Bar Beauty Salon\" includes getting a treat on your birthday.',25,NULL,NULL);
/*!40000 ALTER TABLE `discount_promotions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `monthly_expenses`
--

DROP TABLE IF EXISTS `monthly_expenses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `monthly_expenses` (
  `idmonthly_expenses` int NOT NULL AUTO_INCREMENT,
  `title` char(100) NOT NULL,
  `expenses` float NOT NULL,
  `description` text,
  PRIMARY KEY (`idmonthly_expenses`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `monthly_expenses`
--

LOCK TABLES `monthly_expenses` WRITE;
/*!40000 ALTER TABLE `monthly_expenses` DISABLE KEYS */;
INSERT INTO `monthly_expenses` VALUES (1,'Rent of premises',600,NULL);
/*!40000 ALTER TABLE `monthly_expenses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `positions` (
  `idpositions` int NOT NULL AUTO_INCREMENT,
  `title` char(100) NOT NULL,
  `salary` float NOT NULL,
  PRIMARY KEY (`idpositions`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
INSERT INTO `positions` VALUES (1,'Hair Stylist',1543),(2,'Nail technician',3059),(3,'Pedicure Master',4166),(4,'Lash Master',3826);
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `services` (
  `idservices` int NOT NULL AUTO_INCREMENT,
  `title` char(100) NOT NULL,
  `description` text NOT NULL,
  `cost` float NOT NULL,
  PRIMARY KEY (`idservices`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services` VALUES (1,'Hair Cutting & Styling','Hair Cutting & Styling has evolved over the years, gone are the days of getting your hair “wetted down” and having a quick trim! Lots of us now look to the latest hair trends in magazines, on celebrities and on the big screen leaving us all wanting to stay ahead of the game. ',94),(2,'Vanity Signature Manicure','File, soak, complete cuticle care, relaxing luxurious lotion massage, hot towel and polish finish.',25),(3,'The Ultimate Manicure','File, soak, complete cuticle care, exfoliation, extended relaxing luxurious lotion massage, hydrating mask, hot towel and polish finish.',45),(4,'Vanity Signature Shellac Color Manicure','File, soak, complete cuticle care, shellac polish, relaxing luxurious lotion/scented oil massage and hot towel. (Removal is free of charge if shellac color is being reapplied).',40),(5,'Polish Change (Manicure)','File to desire shape and polish finish.',15),(6,'Shellac Color Polish Change - Hands','File to desire shape and shellac/ gel polish finish.  (Removal is free of charge if shellac/ gel color is being reapplied)',32),(7,'Organic Dipping Powder Nails','Organic nail dipping powder feel and look natural, last long along with no chemical fumes.  It also contains five different vitamins and calcium which actually work together to strengthen and nourish the nails. ',55),(8,'Organic Dipping Powder Nails with Extension','Same as the Organic Dipping Powder Nails but with extension.',60),(9,'Express Pedicure','Therapeutic sea salt softening soak, file, cuticle tidy, lotion and polish finish.',30),(10,'Vanity Signature Pedicure','Therapeutic sea salt softening soak, file, complete cuticle care, callus removal and heel refining, exfoliating sugar scrub, relaxing luxurious lotion/ scented oil massage, hot towel and polish finish.',37),(11,'The Ultimate Pedicure','  Service for women infused with rose petal, therapeutic sea salt softening soak, file, complete cuticle care, callus and heel refining, exfoliating sugar scrub, hydrating mask, extended relaxing  luxurious lotion/ scented oil massage, hot towel and polish finish. ',68),(12,'Spa Jelly Pedicure','The Spa Jelly Pedicure is lemon infused jelly, therapeutic sea salt softening soak, file, complete cuticle care, callus and heel refining, exfoliating sugar scrub, hydrating mask, extended relaxing luxurious lotion/ scented oil massage, hot towel and polish finish and comes in 5 different flavours.',65),(13,'Vanity Signature Shellac Pedicure','Therapeutic sea salt softening soak, file, complete cuticle care, callus removal and heel refining, exfoliating sugar scrub, relaxing luxurious lotion massage, hot towel and shellac polish finish.',52),(14,'Shellac Color Polish Change - Feet','File to desire shape and shellac polish finish. (Removal is free of charge if shellac color is being reapplied).',35),(15,'Classic Full Set (Classic Eyelashh)','When it comes to enhancing your eyelashes, our most subtle set goes a long way with the look of 1-2 coats of mascara.',125),(16,'Hybrid Full Set (Classic Eyelash)','With the Hybrid eyelash extension technique, we use a perfect 50/50 blend of our “Classic “lashes and our “Volume” fans. This new “Hybrid” set combines the premium single lash application technique with the volume application technique. The result is a fuller, and more textured look.',165),(17,'Volume Full Set (Volume Eyelash)','Step into the spotlight with a with a full eye- defining set of lashes, 3D to 6D lashes for a more wow factor.',185),(18,'Mega Volume Full Set (Volume Eyelash)','Instantly stand out with these 6D to 14D lashes for the ultimate fullness.',220),(19,'Lash Lift (Volume Eyelash)','Lash lift is a great alternative to eyelash extensions or for clients with sensitivities. It is a low maintenance lash solution for clients as results lasts up to 12 weeks. Using your own lashes, it is permed against a silicon pad to give it a natural looking \"lift\". ',75);
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `idstaff` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `id_position` int NOT NULL,
  `factor_of_utility` float NOT NULL DEFAULT '1',
  `number_of_working_days` int NOT NULL,
  `date_of_admission` datetime NOT NULL,
  `date_of_dismissal` datetime DEFAULT NULL,
  `work_schedule_to` time NOT NULL,
  `work_schedule_from` time NOT NULL,
  `gender` char(100) NOT NULL,
  PRIMARY KEY (`idstaff`),
  KEY `fk_id_position_1_idx` (`id_position`),
  CONSTRAINT `fk_id_position_1` FOREIGN KEY (`id_position`) REFERENCES `positions` (`idpositions`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,'Alissa Marks',1,1.13,24,'2021-11-16 14:42:31',NULL,'09:00:00','18:30:00','female'),(2,'Lillian Dean',2,1,26,'2021-06-25 02:36:08',NULL,'09:00:00','17:30:00','female'),(3,'Ellison Elmers',2,1.1,25,'2021-05-01 10:00:32',NULL,'09:30:00','16:30:00','female'),(4,'Lorraine Allford',3,1.06,27,'2022-05-29 13:21:01',NULL,'09:30:00','17:00:00','female'),(5,'Delia Durham',3,1,25,'2023-01-07 13:21:01',NULL,'10:00:00','17:30:00','female'),(6,'Laura Campbell',4,1.3,26,'2020-08-04 09:38:15',NULL,'11:00:00','18:30:00','female');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff_to_beauty_salon`
--

DROP TABLE IF EXISTS `staff_to_beauty_salon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff_to_beauty_salon` (
  `idbeauty_salon` int NOT NULL,
  `idstaff` int NOT NULL,
  PRIMARY KEY (`idbeauty_salon`,`idstaff`),
  KEY `idstaff` (`idstaff`),
  CONSTRAINT `staff_to_beauty_salon_ibfk_1` FOREIGN KEY (`idbeauty_salon`) REFERENCES `beauty_salon` (`idbeauty_salon`),
  CONSTRAINT `staff_to_beauty_salon_ibfk_2` FOREIGN KEY (`idstaff`) REFERENCES `staff` (`idstaff`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff_to_beauty_salon`
--

LOCK TABLES `staff_to_beauty_salon` WRITE;
/*!40000 ALTER TABLE `staff_to_beauty_salon` DISABLE KEYS */;
INSERT INTO `staff_to_beauty_salon` VALUES (1,1);
/*!40000 ALTER TABLE `staff_to_beauty_salon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff_to_services`
--

DROP TABLE IF EXISTS `staff_to_services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff_to_services` (
  `id_staff` int NOT NULL,
  `id_service` int NOT NULL,
  PRIMARY KEY (`id_staff`,`id_service`),
  KEY `id_service` (`id_service`),
  CONSTRAINT `staff_to_services_ibfk_1` FOREIGN KEY (`id_staff`) REFERENCES `staff` (`idstaff`),
  CONSTRAINT `staff_to_services_ibfk_2` FOREIGN KEY (`id_service`) REFERENCES `services` (`idservices`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff_to_services`
--

LOCK TABLES `staff_to_services` WRITE;
/*!40000 ALTER TABLE `staff_to_services` DISABLE KEYS */;
INSERT INTO `staff_to_services` VALUES (1,1),(2,2),(2,3),(2,4),(2,5),(2,6),(3,7),(3,8),(4,9),(5,9),(4,10),(5,10),(4,11),(5,11),(4,12),(5,12),(4,13),(5,13),(4,14),(5,14),(6,15),(6,16),(6,17),(6,18),(6,19);
/*!40000 ALTER TABLE `staff_to_services` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-27  1:42:06
