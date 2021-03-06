-- MySQL Script generated by MySQL Workbench
-- Fri Aug 21 21:11:59 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema veiculosapi
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema veiculosapi
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `veiculosapi` DEFAULT CHARACTER SET utf8 ;
USE `veiculosapi` ;

-- -----------------------------------------------------
-- Table `veiculosapi`.`USUARIO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veiculosapi`.`USUARIO` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(60) NOT NULL,
  `senha` VARCHAR(10) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `veiculosapi`.`MARCA_VEICULO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veiculosapi`.`MARCA_VEICULO` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `veiculosapi`.`MODELO_VEICULO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veiculosapi`.`MODELO_VEICULO` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(30) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `veiculosapi`.`TIPO_COMBUSTIVEL`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veiculosapi`.`TIPO_COMBUSTIVEL` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `veiculosapi`.`TIPO_VEICULO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veiculosapi`.`TIPO_VEICULO` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `veiculosapi`.`VEICULO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veiculosapi`.`VEICULO` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `ano` VARCHAR(4) NOT NULL,
  `placa` VARCHAR(7) NOT NULL,
  `quilometragem` DOUBLE NOT NULL,
  `foto` VARCHAR(60) NULL,
  `modelo_veiculo_id` INT NOT NULL,
  `marca_veiculo_id` INT NOT NULL,
  `usuario_id` INT NOT NULL,
  `tipo_combustivel_id` INT NOT NULL,
  `tipo_veiculo_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `USUARIO_VEICULO_idx` (`usuario_id` ASC),
  INDEX `MARCA_VEICULO_VEICULO_idx` (`marca_veiculo_id` ASC),
  INDEX `MODELO_VEICULO_VEICULO_idx` (`modelo_veiculo_id` ASC),
  INDEX `COMBUSTIVEL_VEICULO_idx` (`tipo_combustivel_id` ASC),
  INDEX `TIPO_VEICULO_VEICULO_idx` (`tipo_veiculo_id` ASC),
  CONSTRAINT `USUARIO_VEICULO`
    FOREIGN KEY (`usuario_id`)
    REFERENCES `veiculosapi`.`USUARIO` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `MARCA_VEICULO_VEICULO`
    FOREIGN KEY (`marca_veiculo_id`)
    REFERENCES `veiculosapi`.`MARCA_VEICULO` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `MODELO_VEICULO_VEICULO`
    FOREIGN KEY (`modelo_veiculo_id`)
    REFERENCES `veiculosapi`.`MODELO_VEICULO` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TIPO_COMBUSTIVEL_VEICULO`
    FOREIGN KEY (`tipo_combustivel_id`)
    REFERENCES `veiculosapi`.`TIPO_COMBUSTIVEL` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TIPO_VEICULO_VEICULO`
    FOREIGN KEY (`tipo_veiculo_id`)
    REFERENCES `veiculosapi`.`TIPO_VEICULO` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `veiculosapi`.`ABASTECIMENTO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `veiculosapi`.`ABASTECIMENTO` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `km` DOUBLE NOT NULL,
  `litro` DOUBLE NOT NULL,
  `valor` DECIMAL(5,2) NOT NULL,
  `data` DATE NOT NULL,
  `posto` VARCHAR(45) NOT NULL,
  `tipo_combustivel_id` INT NOT NULL,
  `veiculo_id` INT NOT NULL,
  `usuario_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `VEICULO_ABASTECIMENTO_idx` (`veiculo_id` ASC),
  INDEX `COMBUSTIVEL_ABASTECIMENTO_idx` (`tipo_combustivel_id` ASC),
  INDEX `USUARIO_ABASTECIMENTO_idx` (`usuario_id` ASC),
  CONSTRAINT `VEICULO_ABASTECIMENTO`
    FOREIGN KEY (`veiculo_id`)
    REFERENCES `veiculosapi`.`VEICULO` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TIPO_COMBUSTIVEL_ABASTECIMENTO`
    FOREIGN KEY (`tipo_combustivel_id`)
    REFERENCES `veiculosapi`.`TIPO_COMBUSTIVEL` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `USUARIO_ABASTECIMENTO`
    FOREIGN KEY (`usuario_id`)
    REFERENCES `veiculosapi`.`USUARIO` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
