# Postulka.Franco.PrimerParcial

**Titulo:** CRUD-SistemasOperativos

**Sobre Mi:** Soy Franco Postulka, estudiante de la Tecnicatura en Programación en la UTN. Como desarrollador, domino Python, Django, JavaScript, HTML, CSS, Git y GitHub. Este proyecto es parte de mi incursión en C# y el entorno .NET

**Resumen:** Esta aplicación consta de distintos formulario que le permiten al usuario agregar a su listado de sistemas operativos, sistemas MacOS, Linux y Windows. Los sistemas tienen características en común y propias de cada uno, impidiendo la existencia de dos sistemas iguales en el listado. Los mismos pueden modificarse y eliminarse. El listado y los cambios en el mismo son guardados en un archivo de tipo xml, el cual el usuario puede elegir su ubicación o usar la ubicación que la aplicación brinda por defecto. La lista de SO se puede ordenar alfabéticamente y según la cantidad de GB que ocupa el mismo, de manera ascendente y descendente. 

## Diagrama de clases de los Sistemas Operativos.
### Clase padre Sistema Operativo.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/3fbea71f-8498-476e-abd8-1dbfe910255b)
### Clase hija Linux.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/22120933-9e85-4c6d-94a2-01f6d80c2df9)
### Clase hija Windows.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/c69043b6-208b-4b90-b0b9-18859f18c592)
### Clase hija MacOS.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/0931d471-1019-4740-9d65-c141966f51b2)


## Clase Computadora (objeto utilzado como contenedor de sistemas operativos)
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/622016ec-f17e-42a1-b1b0-38e36f1f3f45)

## Digrama de los enumerados.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/9e06792a-8b49-49d5-abfa-d01ffdbb86ae)

## Interfaces.
# Interfaz genérica implementada en la clase SistemaOperativo.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/b7ca429b-983e-4cb1-a205-8440a7f4d0e5)

# Interfaz implementada en los formularios de instalación.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/20cce99c-3aaf-42a7-8a07-3cd77f0a1c72)

## Excepción propia lanzada cuando el usuario ingresa mal los campos al momento de instalar o modificar un SO.
![image](https://github.com/Franco-Postulka/Postulka.Franco.PrimerParcial/assets/128150248/3899d756-fe94-48d7-a713-3d41bf8d3c66)

# Script para generar la base de datos.
```
USE [master]
GO
/****** Object:  Database [sistemas_operativos]    Script Date: 02/07/2024 12:29:38 ******/
CREATE DATABASE [sistemas_operativos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sistemas_operativos', FILENAME = N'C:\SQLData\sistemas_operativos.mdf' , SIZE = 8192KB , MAXSIZE = 102400KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sistemas_operativos_log', FILENAME = N'C:\SQLData\sistemas_operativos_log.ldf' , SIZE = 1024KB , MAXSIZE = 102400KB , FILEGROWTH = 1024KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [sistemas_operativos] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sistemas_operativos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sistemas_operativos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sistemas_operativos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sistemas_operativos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sistemas_operativos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sistemas_operativos] SET ARITHABORT OFF 
GO
ALTER DATABASE [sistemas_operativos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sistemas_operativos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sistemas_operativos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sistemas_operativos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sistemas_operativos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sistemas_operativos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sistemas_operativos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sistemas_operativos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sistemas_operativos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sistemas_operativos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sistemas_operativos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sistemas_operativos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sistemas_operativos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sistemas_operativos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sistemas_operativos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sistemas_operativos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sistemas_operativos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sistemas_operativos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sistemas_operativos] SET  MULTI_USER 
GO
ALTER DATABASE [sistemas_operativos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sistemas_operativos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sistemas_operativos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sistemas_operativos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sistemas_operativos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [sistemas_operativos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [sistemas_operativos] SET QUERY_STORE = ON
GO
ALTER DATABASE [sistemas_operativos] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [sistemas_operativos]
GO
/****** Object:  Table [dbo].[tabla]    Script Date: 02/07/2024 12:29:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tabla](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[version] [varchar](50) NOT NULL,
	[espacioGB] [float] NOT NULL,
	[estadoSoporte] [int] NOT NULL,
	[tipo] [int] NOT NULL,
	[edicion] [int] NULL,
	[virtualizacionPermitida] [bit] NULL,
	[distribucion] [int] NULL,
	[interfazGrafica] [bit] NULL,
	[integracionIcloud] [bit] NULL,
	[compatibleConProcesadorApple] [bit] NULL,
 CONSTRAINT [PK_tabla] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tabla] ON 

INSERT [dbo].[tabla] ([id], [nombre], [version], [espacioGB], [estadoSoporte], [tipo], [edicion], [virtualizacionPermitida], [distribucion], [interfazGrafica], [integracionIcloud], [compatibleConProcesadorApple]) VALUES (2, N'Sonoma', N'2.5', 5, 2, 1, NULL, NULL, NULL, NULL, 0, 0)
INSERT [dbo].[tabla] ([id], [nombre], [version], [espacioGB], [estadoSoporte], [tipo], [edicion], [virtualizacionPermitida], [distribucion], [interfazGrafica], [integracionIcloud], [compatibleConProcesadorApple]) VALUES (3, N'Windows', N'11', 6.6, 0, 0, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[tabla] ([id], [nombre], [version], [espacioGB], [estadoSoporte], [tipo], [edicion], [virtualizacionPermitida], [distribucion], [interfazGrafica], [integracionIcloud], [compatibleConProcesadorApple]) VALUES (8, N'Monterrey', N'4.1', 3.8, 0, 1, NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[tabla] ([id], [nombre], [version], [espacioGB], [estadoSoporte], [tipo], [edicion], [virtualizacionPermitida], [distribucion], [interfazGrafica], [integracionIcloud], [compatibleConProcesadorApple]) VALUES (9, N'Windows', N'XP', 3.6, 0, 0, 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[tabla] ([id], [nombre], [version], [espacioGB], [estadoSoporte], [tipo], [edicion], [virtualizacionPermitida], [distribucion], [interfazGrafica], [integracionIcloud], [compatibleConProcesadorApple]) VALUES (10, N'Linux', N'2.77', 3.3, 1, 2, NULL, NULL, 4, 1, NULL, NULL)
INSERT [dbo].[tabla] ([id], [nombre], [version], [espacioGB], [estadoSoporte], [tipo], [edicion], [virtualizacionPermitida], [distribucion], [interfazGrafica], [integracionIcloud], [compatibleConProcesadorApple]) VALUES (11, N'Windows', N'7', 2, 1, 0, 2, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[tabla] ([id], [nombre], [version], [espacioGB], [estadoSoporte], [tipo], [edicion], [virtualizacionPermitida], [distribucion], [interfazGrafica], [integracionIcloud], [compatibleConProcesadorApple]) VALUES (15, N'Sonoma', N'2.5.9', 4, 0, 1, NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[tabla] ([id], [nombre], [version], [espacioGB], [estadoSoporte], [tipo], [edicion], [virtualizacionPermitida], [distribucion], [interfazGrafica], [integracionIcloud], [compatibleConProcesadorApple]) VALUES (19, N'Windows', N'7', 2.2, 2, 0, 0, 1, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tabla] OFF
GO
USE [master]
GO
ALTER DATABASE [sistemas_operativos] SET  READ_WRITE 
GO
```
