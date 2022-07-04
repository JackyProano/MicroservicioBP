USE [master]
GO

/****** Object:  Database [BaseDatosBP]    Script Date: 29/5/2022 19:06:45 ******/
if exists(select * from sys.databases where name='BaseDatosBP')
	DROP DATABASE [BaseDatosBP]
GO

/****** Object:  Database [BaseDatosBP]    Script Date: 29/5/2022 19:06:45 ******/
CREATE DATABASE [BaseDatosBP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseDatosBP', FILENAME = N'C:\DATA\BaseDatosBP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BaseDatosBP_log', FILENAME = N'C:\DATA\BaseDatosBP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseDatosBP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BaseDatosBP] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BaseDatosBP] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BaseDatosBP] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BaseDatosBP] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BaseDatosBP] SET ARITHABORT OFF 
GO

ALTER DATABASE [BaseDatosBP] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BaseDatosBP] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BaseDatosBP] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BaseDatosBP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BaseDatosBP] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BaseDatosBP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BaseDatosBP] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BaseDatosBP] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BaseDatosBP] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BaseDatosBP] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BaseDatosBP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BaseDatosBP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BaseDatosBP] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BaseDatosBP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BaseDatosBP] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BaseDatosBP] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BaseDatosBP] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BaseDatosBP] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [BaseDatosBP] SET  MULTI_USER 
GO

ALTER DATABASE [BaseDatosBP] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BaseDatosBP] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BaseDatosBP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BaseDatosBP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BaseDatosBP] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BaseDatosBP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [BaseDatosBP] SET QUERY_STORE = OFF
GO

ALTER DATABASE [BaseDatosBP] SET  READ_WRITE 
GO




/*Persona 
? Implementar la clase persona con los siguientes datos: nombre, genero, 
edad, identificación, dirección, teléfono 
? Debe manera su clave primaria (PK) 
Cliente 
? Cliente debe manejar una entidad, que herede de la clase persona. 
? Un cliente tiene: clienteid, contraseña, estado. 
? El cliente debe tener una clave única. (PK) 
*/

USE [BaseDatosBP]
GO

/****** Object:  Table [dbo].[movimiento]    Script Date: 29/5/2022 19:11:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[movimiento]') AND type in (N'U'))
DROP TABLE [dbo].[movimiento]
GO

/****** Object:  Table [dbo].[cuenta]    Script Date: 29/5/2022 19:11:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cuenta]') AND type in (N'U'))
DROP TABLE [dbo].[cuenta]
GO

/****** Object:  Table [dbo].[cliente]    Script Date: 29/5/2022 19:09:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cliente]') AND type in (N'U'))
DROP TABLE [dbo].[cliente]
GO

/****** Object:  Table [dbo].[cliente]    Script Date: 29/5/2022 19:09:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cliente](
	[cl_id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[cl_identificacion] [varchar](20) NOT NULL,
	[cl_nombre] [varchar](100) NOT NULL,
	[cl_genero] [varchar](10) NOT NULL,
	[cl_edad] [int] NOT NULL,
	[cl_direccion] [varchar](100) NULL,
	[cl_telefono] [varchar](20) NULL,
	[cl_contrasenia] [varchar](50) NOT NULL,
	[cl_estado] [bit] NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[cl_id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





/*Cuenta. 
? Cuenta debe manejar una entidad 
? Una cuenta tiene: número cuenta, tipo cuenta, saldo Inicial, estado. 
? Debe manejar su Clave única 
*/

USE [BaseDatosBP]
GO

/****** Object:  Table [dbo].[cuenta]    Script Date: 29/5/2022 19:11:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[cuenta]') AND type in (N'U'))
DROP TABLE [dbo].[cuenta]
GO

/****** Object:  Table [dbo].[cuenta]    Script Date: 29/5/2022 19:11:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cuenta](
	[cu_numero] [varchar](30) NOT NULL,
	[cu_id_cliente] [int] NOT NULL,
	[cu_tipo] [varchar](20) NOT NULL,
	[cu_saldo] [money] NOT NULL,
	[cu_estado] [bit] NOT NULL,
 CONSTRAINT [PK_cuenta] PRIMARY KEY CLUSTERED 
(
	[cu_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cuenta]  WITH CHECK ADD  CONSTRAINT [FK_cliente_cuenta] FOREIGN KEY([cu_id_cliente])
REFERENCES [dbo].[cliente] ([cl_id_cliente])
GO

ALTER TABLE [dbo].[cuenta] CHECK CONSTRAINT [FK_cliente_cuenta]
GO





/*Movimientos 
? Movimientos debe manejar una entidad 
? Un movimiento tiene: Fecha, tipo movimiento, valor, saldo 
? Debe manejar su Clave única 
*/

USE [BaseDatosBP]
GO

/****** Object:  Table [dbo].[movimiento]    Script Date: 29/5/2022 19:11:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[movimiento]') AND type in (N'U'))
DROP TABLE [dbo].[movimiento]
GO

/****** Object:  Table [dbo].[movimiento]    Script Date: 29/5/2022 19:11:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[movimiento](
	[mo_id_movimiento] [int] IDENTITY(1,1) NOT NULL,
	[mo_numero_cuenta] [varchar](30) NOT NULL,
	[mo_fecha] [datetime] NOT NULL,
	[mo_tipo] [varchar](20) NOT NULL,
	[mo_saldo_inicial] [money] NOT NULL,
	[mo_valor] [money] NOT NULL,
	[mo_saldo] [money] NOT NULL,
 CONSTRAINT [PK_movimiento] PRIMARY KEY CLUSTERED 
(
	[mo_id_movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[movimiento]  WITH CHECK ADD  CONSTRAINT [FK_movimiento_cuenta] FOREIGN KEY([mo_numero_cuenta])
REFERENCES [dbo].[cuenta] ([cu_numero])
GO

ALTER TABLE [dbo].[movimiento] CHECK CONSTRAINT [FK_movimiento_cuenta]
GO




