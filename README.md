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

