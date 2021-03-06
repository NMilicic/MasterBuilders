USE [master]
GO
/****** Object:  Database [MasterBuilders]    Script Date: 29.1.2017. 16:07:37 ******/
CREATE DATABASE [MasterBuilders]
 CONTAINMENT = NONE
 
GO
ALTER DATABASE [MasterBuilders] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MasterBuilders].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MasterBuilders] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MasterBuilders] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MasterBuilders] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MasterBuilders] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MasterBuilders] SET ARITHABORT OFF 
GO
ALTER DATABASE [MasterBuilders] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MasterBuilders] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MasterBuilders] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MasterBuilders] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MasterBuilders] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MasterBuilders] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MasterBuilders] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MasterBuilders] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MasterBuilders] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MasterBuilders] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MasterBuilders] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MasterBuilders] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MasterBuilders] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MasterBuilders] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MasterBuilders] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MasterBuilders] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MasterBuilders] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MasterBuilders] SET RECOVERY FULL 
GO
ALTER DATABASE [MasterBuilders] SET  MULTI_USER 
GO
ALTER DATABASE [MasterBuilders] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MasterBuilders] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MasterBuilders] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MasterBuilders] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MasterBuilders] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MasterBuilders]
GO
/****** Object:  Table [dbo].[boja]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[boja](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kategorija]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kategorija](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](400) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kockica]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kockica](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](100) NULL,
	[sifra] [varchar](150) NULL,
	[kategorija] [int] NULL,
	[slika] [varchar](400) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[zaporka] [nvarchar](50) NOT NULL,
	[ime] [nvarchar](max) NOT NULL,
	[prezime] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lset]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lset](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](100) NOT NULL,
	[god_pro] [int] NULL,
	[dijelovi_broj] [int] NULL,
	[opis] [varchar](200) NULL,
	[id_tema] [int] NULL,
	[sifra] [varchar](50) NULL,
	[slika] [varchar](500) NULL,
	[upute] [varchar](400) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MOC]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MOC](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ime] [varchar](100) NOT NULL,
	[god_pro] [int] NULL,
	[dijelovi_broj] [int] NULL,
	[tema1] [varchar](100) NULL,
	[tema2] [varchar](100) NULL,
	[tema3] [varchar](100) NULL,
	[opis] [varchar](200) NULL,
	[id_autor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MOC_dijelovi]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MOC_dijelovi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_boja] [int] NOT NULL,
	[id_koc] [int] NOT NULL,
	[id_set] [int] NOT NULL,
	[broj] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[setovi_dijelovi]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[setovi_dijelovi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_boja] [int] NOT NULL,
	[id_koc] [int] NOT NULL,
	[id_set] [int] NOT NULL,
	[broj] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tema]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tema](
	[id_tema] [int] IDENTITY(1,1) NOT NULL,
	[id_nadtema] [int] NULL,
	[ime_tema] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tema] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user_kockica]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_kockica](
	[Korisnik_id] [int] NOT NULL,
	[Kockica_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user_MOC]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_MOC](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Korisnik_id] [int] NOT NULL,
	[id_moc] [int] NOT NULL,
	[slozeno] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user_set]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_set](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Korisnik_id] [int] NOT NULL,
	[LSet_id] [int] NOT NULL,
	[slozeno] [int] NULL,
	[Komada] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[wishlist]    Script Date: 29.1.2017. 16:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wishlist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Korisnik_id] [int] NOT NULL,
	[LSet_id] [int] NOT NULL,
	[Komada] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[kockica]  WITH CHECK ADD FOREIGN KEY([kategorija])
REFERENCES [dbo].[kategorija] ([id])
GO
ALTER TABLE [dbo].[Lset]  WITH CHECK ADD FOREIGN KEY([id_tema])
REFERENCES [dbo].[tema] ([id_tema])
GO
ALTER TABLE [dbo].[MOC_dijelovi]  WITH CHECK ADD FOREIGN KEY([id_boja])
REFERENCES [dbo].[boja] ([id])
GO
ALTER TABLE [dbo].[MOC_dijelovi]  WITH CHECK ADD FOREIGN KEY([id_koc])
REFERENCES [dbo].[kockica] ([id])
GO
ALTER TABLE [dbo].[MOC_dijelovi]  WITH CHECK ADD FOREIGN KEY([id_set])
REFERENCES [dbo].[MOC] ([id])
GO
ALTER TABLE [dbo].[setovi_dijelovi]  WITH CHECK ADD FOREIGN KEY([id_boja])
REFERENCES [dbo].[boja] ([id])
GO
ALTER TABLE [dbo].[setovi_dijelovi]  WITH CHECK ADD FOREIGN KEY([id_koc])
REFERENCES [dbo].[kockica] ([id])
GO
ALTER TABLE [dbo].[setovi_dijelovi]  WITH CHECK ADD FOREIGN KEY([id_set])
REFERENCES [dbo].[Lset] ([id])
GO
ALTER TABLE [dbo].[tema]  WITH CHECK ADD FOREIGN KEY([id_nadtema])
REFERENCES [dbo].[tema] ([id_tema])
GO
ALTER TABLE [dbo].[user_kockica]  WITH CHECK ADD FOREIGN KEY([Kockica_id])
REFERENCES [dbo].[kockica] ([id])
GO
ALTER TABLE [dbo].[user_kockica]  WITH CHECK ADD FOREIGN KEY([Korisnik_id])
REFERENCES [dbo].[Korisnik] ([id])
GO
ALTER TABLE [dbo].[user_MOC]  WITH CHECK ADD FOREIGN KEY([id_moc])
REFERENCES [dbo].[MOC] ([id])
GO
ALTER TABLE [dbo].[user_MOC]  WITH CHECK ADD FOREIGN KEY([Korisnik_id])
REFERENCES [dbo].[Korisnik] ([id])
GO
ALTER TABLE [dbo].[user_set]  WITH CHECK ADD FOREIGN KEY([Korisnik_id])
REFERENCES [dbo].[Korisnik] ([id])
GO
ALTER TABLE [dbo].[user_set]  WITH CHECK ADD FOREIGN KEY([LSet_id])
REFERENCES [dbo].[Lset] ([id])
GO
ALTER TABLE [dbo].[wishlist]  WITH CHECK ADD FOREIGN KEY([Korisnik_id])
REFERENCES [dbo].[Korisnik] ([id])
GO
ALTER TABLE [dbo].[wishlist]  WITH CHECK ADD FOREIGN KEY([LSet_id])
REFERENCES [dbo].[Lset] ([id])
GO
USE [master]
GO
ALTER DATABASE [MasterBuilders] SET  READ_WRITE 
GO
