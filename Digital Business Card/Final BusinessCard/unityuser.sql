-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 31, 2021 at 09:54 AM
-- Server version: 5.7.24
-- PHP Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `unityuser`
--

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(10) NOT NULL,
  `mandarin_name` varchar(5) NOT NULL,
  `english_name` varchar(20) NOT NULL,
  `job` varchar(50) NOT NULL,
  `phone_number` varchar(15) NOT NULL,
  `fixed_number` varchar(15) NOT NULL,
  `mobile_number` varchar(15) NOT NULL,
  `address` varchar(60) NOT NULL,
  `email` varchar(60) NOT NULL,
  `hash` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `mandarin_name`, `english_name`, `job`, `phone_number`, `fixed_number`, `mobile_number`, `address`, `email`, `hash`) VALUES
(10, 'a', 'david', 'student', '000', '111', '222', '333', '444', '$5$rounds=1000$guiddavid$PqfkY4VR0zszMdPiXRvIUChNMolWieB7.bca2N9EJi/'),
(11, '啊', 'amar', 'studnet', '08133333', '1111', '22222', 'somewhere far', 'amar@gmail.com', '$5$rounds=1000$guidamar$6akgmjop15juUiKqzmGspYtF4wCjdG4KBNtsnbWlAR6'),
(14, '裏', 'maserati', 'doctor', '111', '111', '111', '111', '111', '$5$rounds=1000$guidmaserati$HLk0Ct.uiu/SHxiqjKTWF5FM2ed5HBL/6A31zco2b7A'),
(15, 'aaaa', 'vvvvasdf', 'asdf', 'asdf', 'asdf', 'asdf', 'asdf', 'asdf', '$5$rounds=1000$guidvvvvasdf$3/j8DWCn4QtLWR2XpNvMNclOqwdkW5rYr6ILGURMKR7'),
(22, 'aaa', 'aaaa', 'aaa', 'aaa', 'aaa', 'aaa', 'aaa', 'aaa', '$5$rounds=1000$guidaaaa$kwQdy5TTcDgDBd8HUfGxRgzpXvuSFVuS7MA9mivfD0B'),
(26, '林', 'jackson', 'aaa', '999', 'aaa', 'aaa', 'aaa', 'aaa', '$5$rounds=1000$guidjackson$PDsJzUsHXoreF39zHyo.H1ciE0dru1.8RIxRYOCKsa2'),
(27, '用', 'michigan', 'cleaning service', '3645678', '12345', '55555', 'somewhere far', 'michigan@gmail.com', '$5$rounds=1000$guidmichigan$tWGjiHZAHnMenumQj6z8vQltwiugFCLAJ9PAqyf9dT/'),
(28, '陳', 'chen', 'dancer', '08123333654', '1234', '1234', 'asdf', 'asdf', '$5$rounds=1000$guidchen$bqzgmEbAzH/TEKT57PL426he3tonid77YiJOchwtO49'),
(29, '哦', 'obbbb', 'aaaa', '3654566', '123123', '123123', 'taipei', 'obb@gmail.com', '$5$rounds=1000$guidobbbb$IiSh28fp9pPzKdW94HNekjU4C4Vqcj/Gh60iVfyihD6'),
(30, '發', 'fa', 'aaasadf', '01923891', '000', '111', 'aaaa', 'fggg', '$5$rounds=1000$guidfa$CpCQnNb.i.Wi0eARrKcxuuHPkJ4HK9EfUQ35VaAC6r4'),
(32, '大大', 'da', 'aaasadf', '0322155', '000', '111', 'aaaa', 'fggg', '$5$rounds=1000$guidda$qrNXX6gDZK82JpONFI5v1V6YS7bjyQYZn4WLVH7xEo2'),
(33, '黎', 'jeriel', 'student', '012356456456', '111', '111', 'jeriel', 'jeriel', '$5$rounds=1000$guidjeriel$yaW1o0YWOHt6StIWWvsNHQYkohl5BUZkxr7j.ImUOt/');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `phone_number` (`phone_number`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
