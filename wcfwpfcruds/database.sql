USE [master]
GO
/****** Object:  Database [tutorials]    Script Date: 6/7/2022 3:05:26 PM ******/
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
/****** Object:  User [windntrees]    Script Date: 6/7/2022 3:05:27 PM ******/
CREATE USER [windntrees] FOR LOGIN [windntrees] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [windntrees]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/7/2022 3:05:28 PM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 6/7/2022 3:05:28 PM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 6/7/2022 3:05:28 PM ******/
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
/****** Object:  Table [dbo].[ProductFeature]    Script Date: 6/7/2022 3:05:28 PM ******/
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
/****** Object:  Table [dbo].[Rating]    Script Date: 6/7/2022 3:05:28 PM ******/
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
/****** Object:  Table [dbo].[SkillLevel]    Script Date: 6/7/2022 3:05:28 PM ******/
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
/****** Object:  Table [dbo].[Topic]    Script Date: 6/7/2022 3:05:28 PM ******/
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
/****** Object:  Table [dbo].[TopicRating]    Script Date: 6/7/2022 3:05:28 PM ******/
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
INSERT [dbo].[Category] ([UID], [Title], [Description]) VALUES (N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'Authorization', N'')
GO
INSERT [dbo].[Category] ([UID], [Title], [Description]) VALUES (N'3aac09d8-8fc1-411a-b46a-2067818de1c3', N'Engineering', NULL)
GO
INSERT [dbo].[Category] ([UID], [Title], [Description]) VALUES (N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'Authentication', NULL)
GO
INSERT [dbo].[Category] ([UID], [Title], [Description]) VALUES (N'60add597-9a41-4cff-ad18-d0de32633f92', N'General', NULL)
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'617f759c-5c56-4641-9cf6-1a0b03783478', NULL, N'Feature 3', N'Description 3')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'ec4ad9dd-2a86-4bb2-b9d0-374f153cb1a0', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'2a5c4cce-154f-488e-a2df-395b6da310f1', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'0408dc93-2f63-4571-b91e-3b67b089fa0e', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'bf49d6c0-ad53-408b-b36a-3c9e6e19b7b7', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'9d359d78-23f8-406a-aeb8-3ccec16371b4', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'e4d54f58-38ce-4988-8d86-402040e997fe', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'9bcb333b-ef82-4b15-ba0c-47865472bbbe', NULL, N'Feature 01', N'Description 01')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'ceb0db27-aee5-4c8a-863c-49d38324cfbf', NULL, N'Feature 1', N'Descriptin 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'7c9fdd6b-5531-46fe-aed0-4cc4ae6a9d10', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'097c7ecf-5836-4e09-b7b0-4fbb8083fd41', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'4b13b851-0800-41a8-9f4f-52662a1bc665', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'27beb45b-8ac2-419a-a0bb-5d462ec5f9fb', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'c92f8d10-5065-41d8-aa18-6a10c6433bad', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'acdc9167-cdb2-4174-8ba4-6dd7c942c487', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'40f7cfa8-ed05-416e-a019-70c737539391', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'ab6925b3-fe71-430b-91a6-929828a37ea0', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'a81decd2-01fe-4d1b-a6d9-9b7171945726', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'4ef30d1d-2765-4e47-9914-a2b8f334b7ea', NULL, N'Feature 00', N'Description 00')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'd6c0e7af-f2fb-4482-8cd4-a895ae7212aa', NULL, N'Feature 01', N'Description 01')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'c728c030-f768-4a87-a266-a9faecc60fe9', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'021099bb-fef5-4460-8630-aa987a20d17b', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'54355307-87d4-4d55-a529-abc3a0dd8a14', NULL, N'Feature 3', N'Description 3')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'53adf0fe-f6bf-4609-8ad0-ad7f12b859ff', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'b6d24122-1f7c-429b-a31c-b3394807723d', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'611b018d-cca4-483c-b7d2-b3a9048ae3cb', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'7d3f7a17-181d-4c24-8d26-b4bb769d12f8', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'e4fb3f2e-bd5a-47cf-901a-b6a7d013f141', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'def6e9f3-d82b-4061-9ab5-ba2a67c95e0a', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'fb3e75fa-2fde-47c5-85de-bc720b1268ff', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'b4fef809-e105-4fd7-9cf9-da2deca59ff2', NULL, N'Feature 3', N'Description 3')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'34f215ab-eb75-4980-ae98-ebe4f267553f', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'54500e1e-b3e2-4f64-8ae5-ec14ebc3d97c', NULL, N'Feature 2', N'Description 2')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'dc6cf840-a617-4095-9672-edf442b2b7a5', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[ProductFeature] ([UID], [ProductID], [Name], [Description]) VALUES (N'3d7fccad-abad-46fa-ba52-f9ef6ffe5d24', NULL, N'Feature 1', N'Description 1')
GO
INSERT [dbo].[Rating] ([UID], [Title], [Description]) VALUES (N'99d657b3-f734-453a-95b0-1b93fc326d9b', N'Average', NULL)
GO
INSERT [dbo].[Rating] ([UID], [Title], [Description]) VALUES (N'c5b906b5-408a-461e-8456-1faa7c01b358', N'Good', NULL)
GO
INSERT [dbo].[Rating] ([UID], [Title], [Description]) VALUES (N'ae7cfe8c-1a3d-47af-ad55-d4b3ddeda2c1', N'Poor', NULL)
GO
INSERT [dbo].[SkillLevel] ([UID], [Title], [Description]) VALUES (N'4ed3c763-1f78-4229-92e3-86d3db2f4bc8', N'Advance', NULL)
GO
INSERT [dbo].[SkillLevel] ([UID], [Title], [Description]) VALUES (N'd1da091a-082a-4341-9222-899f81e77043', N'Intermediate', NULL)
GO
INSERT [dbo].[SkillLevel] ([UID], [Title], [Description]) VALUES (N'4aaa255f-b0e7-45dc-be1f-ffe16aa5523f', N'Beginner', NULL)
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'6d88a27b-3277-490c-abd8-01845120657d', N'60add597-9a41-4cff-ad18-d0de32633f92', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2019-09-21T12:33:32.293' AS DateTime), N'Application -> Settings', N'Enter subject here.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2019-09-21T12:33:32.293' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'08bfe806-cb12-4338-a24c-2436efc3f1a7', N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'4ed3c763-1f78-4229-92e3-86d3db2f4bc8', CAST(N'2022-01-20T13:53:52.413' AS DateTime), N'Application-Menu', N'New Subject 0 update', N'Description 1', N'Description 2', 1, CAST(N'2022-01-20T13:59:14.857' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'615f534e-7dc0-4cdd-b2b3-49accd7b48d4', N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'4ed3c763-1f78-4229-92e3-86d3db2f4bc8', CAST(N'2022-01-20T16:20:36.823' AS DateTime), N'application->menu', N'New Subject 0 update', N'Description 1', N'Description 2', 1, CAST(N'2022-01-20T16:20:36.823' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'd61c3b20-b82b-4934-83e5-53159e9fd026', N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'4ed3c763-1f78-4229-92e3-86d3db2f4bc8', CAST(N'2020-11-07T09:20:43.440' AS DateTime), N'Application -> Authentication', N'Subject here', N'Description 1', N'Description 2', 1, CAST(N'2020-11-07T09:20:43.440' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'85334e23-3133-4300-9a51-69e4b665abd1', N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2019-09-23T09:51:45.097' AS DateTime), N'Application -> Settings', N'Enter subject here.', N'Enter authorization value here.', N'Enter authorization description here.', 1, CAST(N'2019-09-23T09:51:45.097' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'f2dc4fb7-40ca-444f-81de-7deec18a1780', N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2020-11-07T09:31:15.857' AS DateTime), N'Application -> Authorization', N'Enter authorization subject here.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2022-01-20T09:05:22.783' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'dc8a08a9-3a32-4ac5-8d74-a65b714fa328', N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2020-11-07T09:21:42.030' AS DateTime), N'Application -> Authorization', N'Enter authorization subject here. update.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2020-11-07T09:21:42.030' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'd8a0c997-0666-4539-85ad-a6b324b3dcaa', N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2022-01-20T10:43:13.267' AS DateTime), N'Application -> Authorization', N'Enter authorization subject here.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2022-01-20T10:43:13.267' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'695b2756-6ec0-42bc-ab79-b9ba80e6a106', N'60add597-9a41-4cff-ad18-d0de32633f92', N'4aaa255f-b0e7-45dc-be1f-ffe16aa5523f', CAST(N'2019-09-23T10:05:55.090' AS DateTime), N'Application -> Menu', N'Enter subject here.', N'Enter description 1 here.', N'Enter description 2 here.', 1, CAST(N'2019-09-23T10:05:55.090' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'20428048-20f9-4321-9fd7-bbfa5acbabb3', N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'4ed3c763-1f78-4229-92e3-86d3db2f4bc8', CAST(N'2020-11-07T09:30:38.333' AS DateTime), N'Application -> Topics', N'Topic subject here', N'Description 1', N'Description 2', 1, CAST(N'2020-11-07T09:30:38.333' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'49e57e40-7223-4184-8f8c-c71155f8884e', N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'4aaa255f-b0e7-45dc-be1f-ffe16aa5523f', CAST(N'2019-09-23T09:50:43.227' AS DateTime), N'Application -> Settings', N'Enter subject here update', N'Enter description here.', N'Enter description here.', 1, CAST(N'2022-01-20T13:58:47.680' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'fbe96943-2d59-49f8-baec-cf2d4fdbb289', N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'4ed3c763-1f78-4229-92e3-86d3db2f4bc8', CAST(N'2019-09-23T09:49:59.260' AS DateTime), N'Application -> Settings', N'Enter subject here.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2019-09-23T09:49:59.260' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'c459ec2d-3fde-400a-adc6-dd2c0faee547', N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2020-11-07T09:21:13.593' AS DateTime), N'Application -> Authorization', N'Enter authorization subject here. update.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2020-11-07T09:21:13.593' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'3f83bd3d-ea94-4d4c-8012-edb58e14cc32', N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2020-11-07T09:30:52.747' AS DateTime), N'Application -> Authorization', N'Enter authorization subject here.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2020-11-07T09:30:52.747' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'c474d0b5-6dd8-4f13-b1c0-f8592f83bef0', N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2020-11-07T09:44:43.780' AS DateTime), N'Application -> Authorization', N'Enter authorization subject here.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2020-11-07T09:44:43.780' AS DateTime))
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
