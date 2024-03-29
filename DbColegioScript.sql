USE [master]
GO
/****** Object:  Database [DBColegio]    Script Date: 20/10/2019 11:45:27 a.m. ******/
CREATE DATABASE [DBColegio] ON  PRIMARY 
( NAME = N'DBColegio', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DBColegio.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBColegio_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DBColegio_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBColegio] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBColegio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBColegio] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBColegio] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBColegio] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBColegio] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBColegio] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBColegio] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBColegio] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBColegio] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBColegio] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBColegio] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBColegio] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBColegio] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBColegio] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBColegio] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBColegio] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBColegio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBColegio] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBColegio] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBColegio] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBColegio] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBColegio] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBColegio] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBColegio] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBColegio] SET  MULTI_USER 
GO
ALTER DATABASE [DBColegio] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBColegio] SET DB_CHAINING OFF 
GO
USE [DBColegio]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 20/10/2019 11:45:27 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estudiante](
	[Nuip] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[edad] [tinyint] NULL,
	[grado] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Nuip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grado]    Script Date: 20/10/2019 11:45:27 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grado](
	[idgrado] [tinyint] NOT NULL,
	[nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idgrado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Estudiante] ([Nuip], [Nombre], [Apellido], [edad], [grado]) VALUES (1, N'Jesus', N'Castilla', 5, 1)
INSERT [dbo].[Estudiante] ([Nuip], [Nombre], [Apellido], [edad], [grado]) VALUES (2, N'Andres', N'marulanda', 8, 3)
INSERT [dbo].[Estudiante] ([Nuip], [Nombre], [Apellido], [edad], [grado]) VALUES (4, N'asdf', N'wer', 5, 1)
INSERT [dbo].[Estudiante] ([Nuip], [Nombre], [Apellido], [edad], [grado]) VALUES (5, N'Carlos', N'Monterry', 5, 5)
INSERT [dbo].[Estudiante] ([Nuip], [Nombre], [Apellido], [edad], [grado]) VALUES (20, N'andres', N'mercedez', 8, 3)
INSERT [dbo].[Grado] ([idgrado], [nombre]) VALUES (1, N'Primero')
INSERT [dbo].[Grado] ([idgrado], [nombre]) VALUES (2, N'Segundo')
INSERT [dbo].[Grado] ([idgrado], [nombre]) VALUES (3, N'Tercero')
INSERT [dbo].[Grado] ([idgrado], [nombre]) VALUES (4, N'Cuarto')
INSERT [dbo].[Grado] ([idgrado], [nombre]) VALUES (5, N'Quinto')
ALTER TABLE [dbo].[Estudiante]  WITH CHECK ADD FOREIGN KEY([grado])
REFERENCES [dbo].[Grado] ([idgrado])
GO
/****** Object:  StoredProcedure [dbo].[opcionesCrud]    Script Date: 20/10/2019 11:45:27 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[opcionesCrud] 
@opc int,
@Nuip tinyint = null,
@Nombre varchar(50) = null,
@Apellido varchar(50) = null,
@edad tinyint = null,
@grado tinyint = null
As

IF @opc = 1
BEGIN 
Select e.Nuip,e.Nombre,e.Apellido,e.Edad,g.nombre as Grado from dbo.Estudiante as e join dbo.Grado as g on e.grado = g.idgrado
END

IF @opc = 2
BEGIN
	INSERT INTO dbo.Estudiante(Nuip,Nombre,Apellido,edad,grado) VALUES
	(@Nuip,@Nombre,@Apellido,@edad,@grado)
END

IF @Opc = 3
BEGIN
	DELETE FROM dbo.Estudiante Where Nuip = @Nuip
END

/*IF @opc = 1
BEGIN
	SELECT * FROM TblContacto
END

IF @opc = 2
BEGIN
	INSERT INTO DBO.TblContacto(Id,Nombre,Telefono)
	VALUES(@Id, @Nombre, @Telefono)
END

IF @opc = 3
BEGIN
	UPDATE dbo.TblContacto SET
	Nombre = @Nombre,Telefono = @Telefono
	WHERE Id = @Id

END

IF @opc = 4
BEGIN
	DELETE FROM dbo.TblContacto 
	WHERE Id = @Id
END-*/
GO
USE [master]
GO
ALTER DATABASE [DBColegio] SET  READ_WRITE 
GO
