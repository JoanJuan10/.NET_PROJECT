# .NET PROJECT
Proyecto final del curso de .NET de Fundació Esplai

#### 1. Description
```
API REST creada con .NET Core 3.1 utilizando varias entidades ER y conectada con base de datos 
MS Sql Virtualizada sobre Fedora 32.
```

#### 2. Componentes del Equipo
```
Joan Baza - Back end Developer
Iago Gonzalez - Back end y Front end Developer
Viksen Senkov - Front end Developer
```

#### 3. Lista con los pasos mínimos que se necesitan para clonar exitosamente el proyecto

###### Install
```
IDE               Visual Studio 2019 Community Version
Core              C# 
Framework         NET Core 3.1
DataBase          Microsoft Sql Server 
Virtual           VMWare Workstation / Virtual Box
SO                Fedora 32
```
###### packages Nuget 
```
Install-Package System.IdentityModel.Tokens.Jwt                       -Version 5.6.0
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer         -Version 3.1.8
Install-Package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore  -Version 3.1.10
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore     -Version 3.1.12
Install-Package Microsoft.AspNetCore.Identity.UI                      -Version 3.1.12 
Install-Package Microsoft.EntityFrameworkCore.SqlServer               -Version 3.1.12
Install-Package Microsoft.EntityFrameworkCore.Tools                   -Version 3.1.12 
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design      -Version 3.1.5 
```
###### Cadena de Conexión Base de datos en los diferentes proyectos
appsettings.json (API)
```
"AllowedHosts": "*",
  "ConnectionStrings": {
    "NetflixDatabase": "Server=<IP LOCAL>;Database=DBBootcamp;User ID=<DB USER>;Password=<DB PASSWORD>"
    }
```
appsettings.json (FRONT END)
```
"AllowedHosts": "*",
  "ConnectionStrings": {
    "NetflixDatabase": "Server=<IP LOCAL>;Database=DBBootcamp;User ID=<DB USER>;Password=<DB PASSWORD>"
    }
```
* Substituir los valores entre <> por los suyos locales *
#### 4. URLs endpoints.

```
Categorias
GET       /api/Categorias
POST      /api/Categorias
GET       /api/Categorias/{id}
PUT       /api/Categorias/{id}
DELETE    /api/Categorias/{id}

ClasePers
GET       /api/ClasePers
POST      /api/ClasePers
GET       /api/ClasePers/{id}
PUT       /api/ClasePers/{id}
DELETE    /api/ClasePers/{id}

Cuerpos
GET       /api/Cuerpos
POST      /api/Cuerpos
GET       /api/Cuerpos/{id}
PUT       /api/Cuerpos/{id}
DELETE    /api/Cuerpos/{id}

Empresas
GET       /api/Empresas
POST      /api/Empresas
GET       /api/Empresas/{id}
PUT       /api/Empresas/{id}
DELETE    /api/Empresas/{id}

Escalas
GET       /api/Escalas
POST      /api/Escalas
GET       /api/Escalas/{id}
PUT       /api/Escalas/{id}
DELETE    /api/Escalas/{id}

Grupos
GET       /api/Grupos
POST      /api/Grupos
GET       /api/Grupos/{id}
PUT       /api/Grupos/{id}
DELETE    /api/Grupos/{id}

NivOrgs
GET       /api/NivOrgs
POST      /api/NivOrgs
GET       /api/NivOrgs/{id}
PUT       /api/NivOrgs/{id}
DELETE    /api/NivOrgs/{id}

Organigs
GET       /api/Organigs
POST      /api/Organigs
GET       /api/Organigs/{id}
PUT       /api/Organigs/{id}
DELETE    /api/Organigs/{id}

Poblacs
GET       /api/Poblacs
POST      /api/Poblacs
GET       /api/Poblacs/{id}
PUT       /api/Poblacs/{id}
DELETE    /api/Poblacs/{id}

Provincias
GET       /api/Provincias
POST      /api/Provincias
GET       /api/Provincias/{id}
PUT       /api/Provincias/{id}
DELETE    /api/Provincias/{id}

Siglas
GET       /api/Siglas
POST      /api/Siglas
GET       /api/Siglas/{id}
PUT       /api/Siglas/{id}
DELETE    /api/Siglas/{id}

SitAdmvs
GET       /api/SitAdmvs
POST      /api/SitAdmvs
GET       /api/SitAdmvs/{id}
PUT       /api/SitAdmvs/{id}
DELETE    /api/SitAdmvs/{id}

Subescalas
GET       /api/Subescalas
POST      /api/Subescalas
GET       /api/Subescalas/{id}
PUT       /api/Subescalas/{id}
DELETE    /api/Subescalas/{id}

TProvis
GET       /api/TProvis
POST      /api/TProvis
GET       /api/TProvis/{id}
PUT       /api/TProvis/{id}
DELETE    /api/TProvis/{id}

Trabajadores
GET       /api/Trabajadores
POST      /api/Trabajadores
GET       /api/Trabajadores/{id}
PUT       /api/Trabajadores/{id}
DELETE    /api/Trabajadores/{id}

VNivOrgs
GET       /api/VNivOrgs
POST      /api/VNivOrgs
GET       /api/VNivOrgs/{id}
PUT       /api/VNivOrgs/{id}
DELETE    /api/VNivOrgs/{id}

VTrabajadores
GET       /api/VTrabajadores
POST      /api/VTrabajadores
GET       /api/VTrabajadores/{id}
PUT       /api/VTrabajadores/{id}
DELETE    /api/VTrabajadores/{id}

Token
POST      /api/Token
```
* Todas las rutas requiren de un Token obtenido en la ultima ruta para poder acceder.
