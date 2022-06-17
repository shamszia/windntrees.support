USE [master]
GO
/****** Object:  Database [tutorials]    Script Date: 6/17/2022 8:10:57 PM ******/
CREATE DATABASE [tutorials]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tutorials', FILENAME = N'D:\projects\documents\windntrees\tutorials\db\tutorials.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'tutorials_log', FILENAME = N'D:\projects\documents\windntrees\tutorials\db\tutorials_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [tutorials] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tutorials].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tutorials] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tutorials] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tutorials] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tutorials] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tutorials] SET ARITHABORT OFF 
GO
ALTER DATABASE [tutorials] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tutorials] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tutorials] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tutorials] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tutorials] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tutorials] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tutorials] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tutorials] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tutorials] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tutorials] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tutorials] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tutorials] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tutorials] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tutorials] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tutorials] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tutorials] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tutorials] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tutorials] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tutorials] SET  MULTI_USER 
GO
ALTER DATABASE [tutorials] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tutorials] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tutorials] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tutorials] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [tutorials] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [tutorials] SET QUERY_STORE = OFF
GO
USE [tutorials]
GO
/****** Object:  User [windntrees]    Script Date: 6/17/2022 8:10:58 PM ******/
CREATE USER [windntrees] FOR LOGIN [windntrees] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [windntrees]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/17/2022 8:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[UID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/17/2022 8:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[UID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Designation] [nvarchar](100) NULL,
	[Salary] [decimal](18, 2) NULL,
	[Allowance] [decimal](18, 2) NULL,
	[Email] [nvarchar](450) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/17/2022 8:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[UID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[Version] [nvarchar](100) NULL,
	[Code] [nvarchar](100) NULL,
	[LegalCode] [nvarchar](100) NULL,
	[ProductYear] [int] NULL,
	[Category] [nvarchar](50) NULL,
	[Manufacturer] [nvarchar](50) NULL,
	[Unit] [nvarchar](50) NULL,
	[Color] [nvarchar](50) NULL,
	[Service] [bit] NULL,
	[Picture] [nvarchar](50) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductFeature]    Script Date: 6/17/2022 8:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductFeature](
	[UID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_ProductFeatures] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 6/17/2022 8:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[UID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkillLevel]    Script Date: 6/17/2022 8:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkillLevel](
	[UID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 6/17/2022 8:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[UID] [uniqueidentifier] NOT NULL,
	[CategoryID] [uniqueidentifier] NOT NULL,
	[SkillLevelID] [uniqueidentifier] NULL,
	[RecordTime] [datetime] NOT NULL,
	[Menu] [nvarchar](100) NULL,
	[Subject] [nvarchar](200) NOT NULL,
	[Description1] [ntext] NULL,
	[Description2] [ntext] NULL,
	[Active] [bit] NULL,
	[UpdateTime] [datetime] NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TopicRating]    Script Date: 6/17/2022 8:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopicRating](
	[UID] [uniqueidentifier] NOT NULL,
	[TopicID] [uniqueidentifier] NULL,
	[RatingID] [uniqueidentifier] NULL,
	[RowVersion] [timestamp] NULL,
 CONSTRAINT [PK_TopicRating] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductFeature]  WITH CHECK ADD  CONSTRAINT [FK_ProductFeature_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([UID])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ProductFeature] CHECK CONSTRAINT [FK_ProductFeature_Product]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([UID])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_Topic_Category]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_Topic_SkillLevel] FOREIGN KEY([SkillLevelID])
REFERENCES [dbo].[SkillLevel] ([UID])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_Topic_SkillLevel]
GO
ALTER TABLE [dbo].[TopicRating]  WITH CHECK ADD  CONSTRAINT [FK_TopicRating_Rating] FOREIGN KEY([RatingID])
REFERENCES [dbo].[Rating] ([UID])
GO
ALTER TABLE [dbo].[TopicRating] CHECK CONSTRAINT [FK_TopicRating_Rating]
GO
ALTER TABLE [dbo].[TopicRating]  WITH CHECK ADD  CONSTRAINT [FK_TopicRating_Topic] FOREIGN KEY([TopicID])
REFERENCES [dbo].[Topic] ([UID])
GO
ALTER TABLE [dbo].[TopicRating] CHECK CONSTRAINT [FK_TopicRating_Topic]
GO
USE [master]
GO
ALTER DATABASE [tutorials] SET  READ_WRITE 
GO
