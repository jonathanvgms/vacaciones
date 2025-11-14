# 🌴 Vacaciones API

API REST desarrollada en **.NET 8** con **Entity Framework Core** y base de datos **MySQL**, diseñada para gestionar las solicitudes de vacaciones de empleados, sus departamentos y los procesos de aprobación correspondientes.

---

## 🚀 Tecnologías utilizadas

- **.NET 8 Web API**
- **C#**
- **Entity Framework Core (Code First)**
- **MySQL**
- **Swagger / OpenAPI** para documentación
- **Inyección de dependencias**
- **DTOs (Data Transfer Objects)** para separación de lógica y validación

---

## 🧩 Arquitectura

El proyecto sigue una estructura organizada por capas:

```
📁 VacacionesApi
│
├── Controllers/
│ Controladores que exponen los endpoints de la API:
│ - AprobacionController.cs
│ - DepartamentoController.cs
│ - EmpleadoController.cs
│ - FeriadoController.cs
│ - NotificacionController.cs
│ - RolController.cs
│ - SaldoVacacionesController.cs
│ - SolicitudController.cs
│ - UsuarioController.cs
│
├── Data/
│ Clases relacionadas con la base de datos y la inicialización:
│ - ApplicationDbContext.cs → Configura Entity Framework Core, DbSets y conexión.
│ - SeedData.cs → Carga de datos iniciales (roles, usuarios, etc.).
│
├── DTOs/
│ Objetos de transferencia de datos usados entre API y servicios:
│ - AprobacionDTO.cs
│ - DepartamentoDTO.cs
│ - EmpleadoDTO.cs
│ - FeriadoDTO.cs
│ - NotificacionDTO.cs
│ - RolDTO.cs
│ - SaldoVacacionesDTO.cs
│ - SolicitudDTO.cs
│ - SolicitudCreateDTO.cs
│ - SolicitudUpdateDTO.cs
│ - UsuarioDTO.cs
│ - UsuarioLoginDTO.cs
│ - UsuarioRegisterDTO.cs
│ - UsuarioUpdateDTO.cs
│
├── Models/
│ Entidades del dominio (tablas del sistema de vacaciones):
│ - Aprobacion.cs
│ - Departamento.cs
│ - Empleado.cs
│ - Feriado.cs
│ - Notificacion.cs
│ - Rol.cs
│ - SaldoVacaciones.cs
│ - Solicitud.cs
│ - Usuario.cs
│ - VacacionesContext.cs
│
├── Services/
│ Lógica de negocio de cada módulo:
│ - AprobacionService.cs
│ - DepartamentoService.cs
│ - EmpleadoService.cs
│ - FeriadoService.cs
│ - NotificacionService.cs
│ - RolService.cs
│ - SaldoVacacionesService.cs
│ - SolicitudService.cs
│ - UsuarioService.cs
│
├── Properties/
│ - launchSettings.json → Configuración de perfiles de ejecución del proyecto.
│
├── Program.cs → Punto de entrada de la API, configuración de servicios y middlewares.
├── appsettings.json → Configuración general (cadena de conexión, JWT, etc.).
├── VacacionesApi.csproj → Definición del proyecto y dependencias.
├── .gitignore → Archivos y carpetas ignoradas por Git.
└── README.md → Documentación general del proyecto.
```
👨‍💻 Autor

René Terrazas
Proyecto académico - Gestión de vacaciones de empleados
📅 Año: 2025
🔗 Repositorio: GitHub - VacacionesApi

🏁 Cómo ejecutar

✔️ Primero tenés que crear toda la base de datos en MySQL
✔️ Usar MySQL Workbench (Forward Engineering o Run SQL Script)
✔️ Pegar el siguiente script COMPLETO:

```
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema vacaciones_db
-- -----------------------------------------------------

CREATE SCHEMA IF NOT EXISTS `vacaciones_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `vacaciones_db`;

-- -----------------------------------------------------
-- Table: ambito_feriado
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ambito_feriado` (
  `id_ambito` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificaion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_ambito`),
  UNIQUE INDEX `nombre` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: departamento
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `departamento` (
  `id_departamento` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NOT NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_departamento`),
  UNIQUE INDEX `nombre` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: rol
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `rol` (
  `id_rol` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_rol`),
  UNIQUE INDEX `nombre` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: usuario
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `usuario` (
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
  UNIQUE INDEX `email` (`email`),
  INDEX `id_rol` (`id_rol`),
  FOREIGN KEY (`id_rol`) REFERENCES `rol` (`id_rol`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: empleado
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `empleado` (
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
  INDEX `fk_emp_usuario` (`id_usuario`),
  INDEX `fk_emp_departamento` (`id_departamento`),
  FOREIGN KEY (`id_departamento`) REFERENCES `departamento` (`id_departamento`),
  FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: estado_solicitud
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `estado_solicitud` (
  `id_estado` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(50) NOT NULL,
  `fecha_creacion` DATETIME NULL,
  `fecha_usuario` VARCHAR(120) NULL,
  `estado_solicitudcol` VARCHAR(45) NULL,
  PRIMARY KEY (`id_estado`),
  UNIQUE INDEX `nombre` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: solicitud
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `solicitud` (
  `id_solicitud` INT NOT NULL AUTO_INCREMENT,
  `id_empleado` INT NOT NULL,
  `fecha_inicio` DATE NOT NULL,
  `fecha_fin` DATE NOT NULL,
  `dias_solicitados` INT NULL,
  `id_estado` INT NOT NULL,
  `motivo` VARCHAR(255) NULL,
  `fecha_creacion` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `creacion_usuario` VARCHAR(120) NOT NULL,
  PRIMARY KEY (`id_solicitud`),
  INDEX (`id_empleado`),
  INDEX (`id_estado`),
  FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`),
  FOREIGN KEY (`id_estado`) REFERENCES `estado_solicitud` (`id_estado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: aprobacion
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `aprobacion` (
  `id_aprobacion` INT NOT NULL AUTO_INCREMENT,
  `id_solicitud` INT NOT NULL,
  `id_aprobador` INT NOT NULL,
  `comentario` VARCHAR(500) NULL,
  `creacion_fecha` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `creacion_usaurio` VARCHAR(120) NOT NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  PRIMARY KEY (`id_aprobacion`),
  INDEX (`id_solicitud`),
  INDEX (`id_aprobador`),
  FOREIGN KEY (`id_solicitud`) REFERENCES `solicitud` (`id_solicitud`),
  FOREIGN KEY (`id_aprobador`) REFERENCES `empleado` (`id_empleado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: feriado
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `feriado` (
  `id_feriado` INT NOT NULL AUTO_INCREMENT,
  `fecha` DATE NOT NULL,
  `id_ambito` INT NOT NULL,
  `descripcion` VARCHAR(150) NULL,
  `creacion_fecha` DATETIME NULL,
  `creacion_usuario` VARCHAR(120) NULL,
  `modificacion_fecha` DATETIME NULL,
  `modificacion_usuario` VARCHAR(120) NULL,
  `Pais` CHAR(1) NULL,
  PRIMARY KEY (`id_feriado`),
  UNIQUE INDEX `uq_feriado` (`fecha`, `id_ambito`),
  FOREIGN KEY (`id_ambito`) REFERENCES `ambito_feriado` (`id_ambito`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: notificacion
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `notificacion` (
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
  INDEX (`id_usuario`),
  FOREIGN KEY (`id_usuario`) REFERENCES `usuario` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- -----------------------------------------------------
-- Table: saldo_vacaciones
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `saldo_vacaciones` (
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
  UNIQUE INDEX (`id_empleado`,`anio`),
  FOREIGN KEY (`id_empleado`) REFERENCES `empleado` (`id_empleado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

```

1.Clonar el repositorio:
git clone https://github.com/usuario/VacacionesApi.git
cd VacacionesApi

2.Configurar la cadena de conexión en appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=VacacionesDB;user=root;password=;"
}

3.Ejecutar las migraciones:
dotnet ef database update

4.Iniciar el servidor:
dotnet run

5.Abrir Swagger en tu navegador:
https://localhost:7100/swagger

✨ API lista para gestionar las vacaciones de tus empleados de forma eficiente.
```

