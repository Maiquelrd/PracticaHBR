USE [master]
GO
/****** Object:  Database [HBR]    Script Date: 17/9/2020 8:58:12 p. m. ******/
CREATE DATABASE [HBR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HBR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HBR.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HBR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HBR_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HBR] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HBR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HBR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HBR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HBR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HBR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HBR] SET ARITHABORT OFF 
GO
ALTER DATABASE [HBR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HBR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HBR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HBR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HBR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HBR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HBR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HBR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HBR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HBR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HBR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HBR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HBR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HBR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HBR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HBR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HBR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HBR] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HBR] SET  MULTI_USER 
GO
ALTER DATABASE [HBR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HBR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HBR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HBR] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HBR] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HBR] SET QUERY_STORE = OFF
GO
USE [HBR]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Categoria] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](200) NULL,
	[Precio] [float] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](30) NOT NULL,
	[Contraseña] [varchar](30) NOT NULL,
	[EsAdmin] [bit] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY([ID_Categoria])
REFERENCES [dbo].[Categorias] ([ID])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias]
GO
/****** Object:  StoredProcedure [dbo].[CRUDCategoria]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CRUDCategoria] (@id            INTEGER = null,  
                                          @Nombre   VARCHAR(50) = null,  
                                          @Descripcion     VARCHAR(200)= null,
                                          @Tipo NVARCHAR(20) = '')  
AS  
  BEGIN  
      IF @Tipo = 'Insert'  
        BEGIN  
            INSERT INTO dbo.Categorias  
                        (Nombre,  
                         Descripcion) 
            VALUES     ( @Nombre,  
                         @Descripcion) 
        END  
  
      IF @Tipo = 'Select'  
        BEGIN  
            SELECT *  
            FROM   dbo.Categorias  
        END  
  
      IF @Tipo = 'Update'  
        BEGIN  
            UPDATE dbo.Categorias  
            SET    Nombre = @Nombre,  
                   Descripcion = @Descripcion 
            WHERE  id = @id  
        END  
      ELSE IF @Tipo = 'Delete'  
        BEGIN  
            DELETE FROM dbo.Categorias  
            WHERE  id = @id  
        END  
  END   
GO
/****** Object:  StoredProcedure [dbo].[CRUDProducto]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CRUDProducto] (@id            INTEGER = null,
										@idCat         INTEGER = null,  
                                          @Nombre   VARCHAR(50) = null,  
                                          @Descripcion     VARCHAR(200)= null,
										  @Precio         FLOAT = null,
                                          @Tipo NVARCHAR(20) = '')  
AS  
  BEGIN  
      IF @Tipo = 'Insert'  
        BEGIN  
            INSERT INTO dbo.Productos  
                        (ID_Categoria,
						Nombre,  
                         Descripcion,
						 Precio) 
            VALUES     ( @idCat,
						@Nombre,  
                         @Descripcion,
						 @Precio) 
        END  
  
      IF @Tipo = 'Select'  
        BEGIN  
            SELECT *  
            FROM   dbo.Productos  
        END  

		IF @Tipo = 'SelectCat'  
        BEGIN  
            select Productos.ID, Productos.ID_Categoria, Categorias.Nombre AS Categoria, Productos.Nombre, Productos.Descripcion, Productos.Precio
			from dbo.Productos
			inner join Categorias ON Productos.ID_Categoria=Categorias.ID;
        END  
  
      IF @Tipo = 'Update'  
        BEGIN  
            UPDATE dbo.Productos  
            SET    ID_Categoria = @idCat,
					Nombre = @Nombre,  
                   Descripcion = @Descripcion,
				   Precio = @Precio
            WHERE  id = @id  
        END  
      ELSE IF @Tipo = 'Delete'  
        BEGIN  
            DELETE FROM dbo.Productos  
            WHERE  id = @id  
        END  
  END   
GO
/****** Object:  StoredProcedure [dbo].[CRUDUsuario]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CRUDUsuario] (@id            INTEGER = null,  
                                          @Usuario   VARCHAR(30) = null,  
                                          @Contraseña     VARCHAR(30)= null,
										  @Admin  bit = null,
                                          @Tipo NVARCHAR(20) = '')  
AS  
  BEGIN  
      IF @Tipo = 'Insert'  
        BEGIN  
            INSERT INTO dbo.Usuarios  
                        (Usuario,  
                         Contraseña,  
                         EsAdmin)  
            VALUES     ( @Usuario,  
                         @Contraseña,  
                         @Admin)  
        END  
  
      IF @Tipo = 'Select'  
        BEGIN  
            SELECT *  
            FROM   dbo.Usuarios  
        END  
  
      IF @Tipo = 'Update'  
        BEGIN  
            UPDATE dbo.Usuarios  
            SET    Usuario = @Usuario,  
                   Contraseña = @Contraseña,  
                   EsAdmin = @Admin 
            WHERE  id = @id  
        END  
      ELSE IF @Tipo = 'Delete'  
        BEGIN  
            DELETE FROM dbo.Usuarios  
            WHERE  id = @id  
        END  
  END   
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCategoriasID]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[ObtenerCategoriasID]
as
Begin
select ID from dbo.Categorias;
End
GO
/****** Object:  StoredProcedure [dbo].[ProcLoguear]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ProcLoguear]
(
@usuario nvarchar(30),
@password nvarchar(30)
)
as
Begin
select count(*) from dbo.Usuarios where lower(Usuario)= ''+@usuario+'' and Contraseña = ''+@password+''
End
GO
/****** Object:  StoredProcedure [dbo].[ValidarAdmin]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[ValidarAdmin]
(
@usuario nvarchar(30),
@password nvarchar(30)
)
as
Begin
select EsAdmin from dbo.Usuarios where Usuario= ''+@usuario+'' and Contraseña = ''+@password+''
End
GO
/****** Object:  StoredProcedure [dbo].[ValidarUsuario]    Script Date: 17/9/2020 8:58:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[ValidarUsuario]
(
@usuario nvarchar(30)
)
as
Begin
select count(*) from dbo.Usuarios where Usuario= ''+@usuario+''
End
GO
USE [master]
GO
ALTER DATABASE [HBR] SET  READ_WRITE 
GO
