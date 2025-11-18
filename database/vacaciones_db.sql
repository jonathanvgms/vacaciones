-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema vacaciones_db
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema vacaciones_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `vacaciones_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `vacaciones_db` ;

-- -----------------------------------------------------
-- Table `vacaciones_db`.`ambito_feriado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`ambito_feriado` (
  `id_ambito` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificaion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_ambito`),
  UNIQUE INDEX `nombre` (`nombre` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`departamento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`departamento` (
  `id_departamento` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NOT NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_departamento`),
  UNIQUE INDEX `nombre` (`nombre` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`rol`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`rol` (
  `id_rol` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_rol`),
  UNIQUE INDEX `nombre` (`nombre` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`usuario` (
  `id_usuario` INT NOT NULL AUTO_INCREMENT,
  `email` VARCHAR(120) NOT NULL,
  `password_hash` VARCHAR(255) NOT NULL,
  `nombre` VARCHAR(80) NOT NULL,
  `apellido` VARCHAR(80) NOT NULL,
  `id_rol` INT NOT NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_usuario`),
  UNIQUE INDEX `email` (`email` ASC) VISIBLE,
  INDEX `id_rol` (`id_rol` ASC) VISIBLE,
  CONSTRAINT `usuario_ibfk_1`
    FOREIGN KEY (`id_rol`)
    REFERENCES `vacaciones_db`.`rol` (`id_rol`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`empleado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`empleado` (
  `id_empleado` INT NOT NULL AUTO_INCREMENT,
  `id_usuario` INT NOT NULL,
  `id_departamento` INT NOT NULL,
  `cargo` VARCHAR(120) NOT NULL,
  `fecha_ingreso` DATETIME NOT NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificaion:usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_empleado`),
  INDEX `fk_emp_usuario` (`id_usuario` ASC) VISIBLE,
  INDEX `fk_emp_departamento` (`id_departamento` ASC) VISIBLE,
  CONSTRAINT `fk_emp_departamento`
    FOREIGN KEY (`id_departamento`)
    REFERENCES `vacaciones_db`.`departamento` (`id_departamento`),
  CONSTRAINT `fk_emp_usuario`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `vacaciones_db`.`usuario` (`id_usuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`estado_solicitud`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`estado_solicitud` (
  `id_estado` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  `fecha_creacion` DATETIME NULL,
  `fecha_usuario` VARCHAR(120) NULL,
  `estado_solicitudcol` VARCHAR(45) NULL,
  PRIMARY KEY (`id_estado`),
  UNIQUE INDEX `nombre` (`nombre` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`solicitud`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`solicitud` (
  `id_solicitud` INT NOT NULL AUTO_INCREMENT,
  `id_empleado` INT NOT NULL,
  `fecha_inicio` DATE NOT NULL,
  `fecha_fin` DATE NOT NULL,
  `dias_solicitados` INT NULL DEFAULT NULL,
  `id_estado` INT NOT NULL,
  `motivo` VARCHAR(255) NULL DEFAULT NULL,
  `fecha_creacion` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `creacion_usuario` VARCHAR(120) NOT NULL,
  PRIMARY KEY (`id_solicitud`),
  INDEX `id_empleado` (`id_empleado` ASC) VISIBLE,
  INDEX `id_estado` (`id_estado` ASC) VISIBLE,
  CONSTRAINT `solicitud_ibfk_1`
    FOREIGN KEY (`id_empleado`)
    REFERENCES `vacaciones_db`.`empleado` (`id_empleado`),
  CONSTRAINT `solicitud_ibfk_2`
    FOREIGN KEY (`id_estado`)
    REFERENCES `vacaciones_db`.`estado_solicitud` (`id_estado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`aprobacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`aprobacion` (
  `id_aprobacion` INT NOT NULL AUTO_INCREMENT,
  `id_solicitud` INT NOT NULL,
  `id_aprobador` INT NOT NULL,
  `comentario` VARCHAR(500) NULL DEFAULT NULL,
  `creacion_fecha` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `creacion_usaurio` VARCHAR(120) NOT NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_aprobacion`),
  INDEX `id_solicitud` (`id_solicitud` ASC) VISIBLE,
  INDEX `id_aprobador` (`id_aprobador` ASC) VISIBLE,
  CONSTRAINT `aprobacion_ibfk_1`
    FOREIGN KEY (`id_solicitud`)
    REFERENCES `vacaciones_db`.`solicitud` (`id_solicitud`),
  CONSTRAINT `aprobacion_ibfk_2`
    FOREIGN KEY (`id_aprobador`)
    REFERENCES `vacaciones_db`.`empleado` (`id_empleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`feriado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`feriado` (
  `id_feriado` INT NOT NULL AUTO_INCREMENT,
  `fecha` DATE NOT NULL,
  `id_ambito` INT NOT NULL,
  `descripcion` VARCHAR(150) NULL DEFAULT NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  `Pais` CHAR(1) NULL,
  PRIMARY KEY (`id_feriado`),
  UNIQUE INDEX `uq_feriado` (`fecha` ASC, `id_ambito` ASC) VISIBLE,
  INDEX `id_ambito` (`id_ambito` ASC) VISIBLE,
  CONSTRAINT `feriado_ibfk_1`
    FOREIGN KEY (`id_ambito`)
    REFERENCES `vacaciones_db`.`ambito_feriado` (`id_ambito`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`notificacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`notificacion` (
  `id_notificacion` INT NOT NULL AUTO_INCREMENT,
  `id_usuario` INT NOT NULL,
  `asunto` VARCHAR(120) NOT NULL,
  `mensaje` VARCHAR(500) NOT NULL,
  `fecha` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `leido` TINYINT(1) NOT NULL DEFAULT '0',
  `creacion_fecha` DATETIME NOT NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_notificacion`),
  INDEX `id_usuario` (`id_usuario` ASC) VISIBLE,
  CONSTRAINT `notificacion_ibfk_1`
    FOREIGN KEY (`id_usuario`)
    REFERENCES `vacaciones_db`.`usuario` (`id_usuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `vacaciones_db`.`saldo_vacaciones`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vacaciones_db`.`saldo_vacaciones` (
  `id_saldo` INT NOT NULL AUTO_INCREMENT,
  `id_empleado` INT NOT NULL,
  `anio` YEAR NOT NULL,
  `dias_asignados` DECIMAL(5,2) NOT NULL DEFAULT '0.00',
  `dias_tomados` DECIMAL(5,2) NOT NULL DEFAULT '0.00',
  `dias_pendientes` DECIMAL(5,2) NOT NULL DEFAULT '0.00',
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_saldo`),
  UNIQUE INDEX `id_empleado` (`id_empleado` ASC, `anio` ASC) VISIBLE,
  CONSTRAINT `saldo_vacaciones_ibfk_1`
    FOREIGN KEY (`id_empleado`)
    REFERENCES `vacaciones_db`.`empleado` (`id_empleado`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
