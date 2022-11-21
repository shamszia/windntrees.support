USE [master]
GO
/****** Object:  Database [tutorials]    Script Date: 11/4/2020 11:12:56 AM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 11/4/2020 11:12:56 AM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 11/4/2020 11:12:56 AM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 11/4/2020 11:12:56 AM ******/
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
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 11/4/2020 11:12:56 AM ******/
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
/****** Object:  Table [dbo].[SkillLevel]    Script Date: 11/4/2020 11:12:56 AM ******/
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
/****** Object:  Table [dbo].[Topic]    Script Date: 11/4/2020 11:12:56 AM ******/
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
/****** Object:  Table [dbo].[TopicRating]    Script Date: 11/4/2020 11:12:56 AM ******/
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
INSERT [dbo].[Category] ([UID], [Title], [Description]) VALUES (N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'Authentication', NULL)
GO
INSERT [dbo].[Category] ([UID], [Title], [Description]) VALUES (N'60add597-9a41-4cff-ad18-d0de32633f92', N'General', NULL)
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'7e707169-12d2-42d7-81ae-13eafff5cb25', N'Product 2', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'8198ccb1-4d42-4fb3-9ef1-1aa40b93e56f', N'Product 14', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'58f4297a-0870-4739-b4dd-21b410ec4846', N'Product 5', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'e2e6b7dc-2417-4415-a414-3793c40f6391', N'Product 10', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'394f9a58-31bc-4f31-ac0b-3a12afe4f267', N'Product 20', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'f11ad322-31ac-4158-ad01-3e874669ca13', N'Product 24', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'256810df-2841-4e4b-9b1c-510ce1268092', N'Product 9', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'9e181063-1ffa-43d0-9be9-59061a96aab9', N'Product 23', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'c1fa7cd6-8034-491b-8bd8-5c2b70f2100e', N'Product 0', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'fa2d085d-a64e-42b0-9e90-7a0035fbf522', N'Product 21', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'7efbe5e1-59b2-448c-a615-7c7a6c64c519', N'Product 18', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'5ddb4706-97d6-4125-afae-87ecad4418b6', N'Product 4', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'62399935-e9a0-41f8-a48c-983a9eac6d2a', N'Product 22', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'7a004400-b8b3-446e-8808-9f2b7f960fa2', N'Product 15', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'5440911e-f460-4cb8-9680-aac62d59e3fe', N'Product 17', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'fcc054f3-1cfb-4d2b-9092-ac057f5cc88a', N'Product 11', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'54613926-bde2-4e7e-95a2-bcfdddc321af', N'Product 19', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'cb6572b8-5215-4cf7-8303-c3daf7f3be7d', N'Product 6', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'8aa9507e-9e14-4ca5-bc8d-c4f6f4b70be4', N'Product 13', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'a88d09ff-3dc3-4574-9385-d4306139bbb4', N'Product 16', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'bab4c260-c913-46f3-9b73-d9411a4ebd43', N'Product 7', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'507adcc4-1b41-4470-bb72-eb3ff2d9fa4a', N'Product 8', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'382d72e0-6d5a-407c-ad2a-f7c2fce5b97d', N'Product 12', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'9e5ee1bd-d68f-48a7-be48-f874f19820bc', N'Product 1', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
GO
INSERT [dbo].[Product] ([UID], [Name], [Description], [Version], [Code], [LegalCode], [ProductYear], [Category], [Manufacturer], [Unit], [Color], [Service], [Picture]) VALUES (N'e6b806e7-c5d5-430d-bf33-fc6a5e346f41', N'Product 3', N'', N'', N'', N'', 2020, N'', N'', N'', N'', 0, N'')
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
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'3ff2f44e-ecf3-47bc-9f27-163f090d10b4', N'60add597-9a41-4cff-ad18-d0de32633f92', N'4aaa255f-b0e7-45dc-be1f-ffe16aa5523f', CAST(N'2019-09-20T11:54:27.797' AS DateTime), N'Application -> Topic', N'New topic subject here', N'Enter description here.', N'Enter description here.', 1, CAST(N'2019-09-20T11:54:27.797' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'6ac089a3-63c4-47bc-9a61-627c6d05f6a2', N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2019-09-21T12:43:10.697' AS DateTime), N'Application -> Authorization', N'Enter authorization subject here.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2019-09-21T12:43:10.697' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'85334e23-3133-4300-9a51-69e4b665abd1', N'e0ef3f90-59fe-4e3e-9edb-0ad3a1db71a1', N'd1da091a-082a-4341-9222-899f81e77043', CAST(N'2019-09-23T09:51:45.097' AS DateTime), N'Application -> Settings', N'Enter subject here.', N'Enter authorization value here.', N'Enter authorization description here.', 1, CAST(N'2019-09-23T09:51:45.097' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'695b2756-6ec0-42bc-ab79-b9ba80e6a106', N'60add597-9a41-4cff-ad18-d0de32633f92', N'4aaa255f-b0e7-45dc-be1f-ffe16aa5523f', CAST(N'2019-09-23T10:05:55.090' AS DateTime), N'Application -> Menu', N'Enter subject here.', N'Enter description 1 here.', N'Enter description 2 here.', 1, CAST(N'2019-09-23T10:05:55.090' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'49e57e40-7223-4184-8f8c-c71155f8884e', N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'4aaa255f-b0e7-45dc-be1f-ffe16aa5523f', CAST(N'2019-09-23T09:50:43.227' AS DateTime), N'Application -> Settings', N'Enter subject here', N'Enter description here.', N'Enter description here.', 1, CAST(N'2019-09-23T09:50:43.227' AS DateTime))
GO
INSERT [dbo].[Topic] ([UID], [CategoryID], [SkillLevelID], [RecordTime], [Menu], [Subject], [Description1], [Description2], [Active], [UpdateTime]) VALUES (N'fbe96943-2d59-49f8-baec-cf2d4fdbb289', N'a6a94c1e-1dec-48ea-907e-97cecc757847', N'4ed3c763-1f78-4229-92e3-86d3db2f4bc8', CAST(N'2019-09-23T09:49:59.260' AS DateTime), N'Application -> Settings', N'Enter subject here.', N'Enter description here.', N'Enter description here.', 1, CAST(N'2019-09-23T09:49:59.260' AS DateTime))
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
