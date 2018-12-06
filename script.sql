USE [master]
GO
/****** Object:  Database [DBPodrska]    Script Date: 04-Dec-18 12:15:37 ******/
CREATE DATABASE [DBPodrska] ON  PRIMARY 
( NAME = N'DBPodrska', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DBPodrska.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBPodrska_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DBPodrska_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DBPodrska] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBPodrska].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBPodrska] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBPodrska] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBPodrska] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBPodrska] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBPodrska] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBPodrska] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBPodrska] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBPodrska] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBPodrska] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBPodrska] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBPodrska] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBPodrska] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBPodrska] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBPodrska] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBPodrska] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBPodrska] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBPodrska] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBPodrska] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBPodrska] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBPodrska] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBPodrska] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBPodrska] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBPodrska] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBPodrska] SET  MULTI_USER 
GO
ALTER DATABASE [DBPodrska] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBPodrska] SET DB_CHAINING OFF 
GO
USE [DBPodrska]
GO
/****** Object:  Table [dbo].[CategoryList]    Script Date: 04-Dec-18 12:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_CategoryList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriorityList]    Script Date: 04-Dec-18 12:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriorityList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PriorityName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Priority] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SectionsList]    Script Date: 04-Dec-18 12:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SectionsList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SectionName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SectionsList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SeverityList]    Script Date: 04-Dec-18 12:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeverityList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SeverityName] [nvarchar](50) NULL,
 CONSTRAINT [PK_SeverityList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusesList]    Script Date: 04-Dec-18 12:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusesList](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_StatusesList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupportList]    Script Date: 04-Dec-18 12:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupportList](
	[TicketNo] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[Category] [int] NOT NULL,
	[Severity] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[RaisedBy] [int] NOT NULL,
	[RaisedOn] [date] NOT NULL,
	[DueOn] [date] NOT NULL,
	[ResolvedOn] [date] NULL,
	[IDSectionList] [int] NULL,
 CONSTRAINT [PK_SupportList] PRIMARY KEY CLUSTERED 
(
	[TicketNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserList]    Script Date: 04-Dec-18 12:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Activ] [bit] NOT NULL,
 CONSTRAINT [PK_UserList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryList] ON 

INSERT [dbo].[CategoryList] ([ID], [CategoryName]) VALUES (1, N'Suggestion')
INSERT [dbo].[CategoryList] ([ID], [CategoryName]) VALUES (2, N'Required')
SET IDENTITY_INSERT [dbo].[CategoryList] OFF
SET IDENTITY_INSERT [dbo].[PriorityList] ON 

INSERT [dbo].[PriorityList] ([ID], [PriorityName]) VALUES (1, N'End of week')
INSERT [dbo].[PriorityList] ([ID], [PriorityName]) VALUES (2, N'Low priority')
INSERT [dbo].[PriorityList] ([ID], [PriorityName]) VALUES (3, N'Tomorrow')
SET IDENTITY_INSERT [dbo].[PriorityList] OFF
SET IDENTITY_INSERT [dbo].[SectionsList] ON 

INSERT [dbo].[SectionsList] ([ID], [SectionName], [Description]) VALUES (1, N'Project Page', N'issues on project section')
INSERT [dbo].[SectionsList] ([ID], [SectionName], [Description]) VALUES (2, N'Jobs Page', N'issues on jobs section')
INSERT [dbo].[SectionsList] ([ID], [SectionName], [Description]) VALUES (3, N'Brower issue', N'Browser issues')
SET IDENTITY_INSERT [dbo].[SectionsList] OFF
SET IDENTITY_INSERT [dbo].[SeverityList] ON 

INSERT [dbo].[SeverityList] ([ID], [SeverityName]) VALUES (1, N'Nice to have')
INSERT [dbo].[SeverityList] ([ID], [SeverityName]) VALUES (2, N'Standard ( can wait)')
INSERT [dbo].[SeverityList] ([ID], [SeverityName]) VALUES (3, N'Critical ( showstopper)')
SET IDENTITY_INSERT [dbo].[SeverityList] OFF
INSERT [dbo].[StatusesList] ([ID], [Name], [Description]) VALUES (1, N'In process', NULL)
INSERT [dbo].[StatusesList] ([ID], [Name], [Description]) VALUES (2, N'Closed', NULL)
INSERT [dbo].[StatusesList] ([ID], [Name], [Description]) VALUES (3, N'Resolved', NULL)
INSERT [dbo].[StatusesList] ([ID], [Name], [Description]) VALUES (4, N'Submited', NULL)
SET IDENTITY_INSERT [dbo].[SupportList] ON 

INSERT [dbo].[SupportList] ([TicketNo], [Title], [Status], [Category], [Severity], [Priority], [RaisedBy], [RaisedOn], [DueOn], [ResolvedOn], [IDSectionList]) VALUES (1, N'Ticket 001', 4, 1, 1, 1, 1, CAST(N'2018-11-27' AS Date), CAST(N'2018-12-05' AS Date), NULL, 1)
INSERT [dbo].[SupportList] ([TicketNo], [Title], [Status], [Category], [Severity], [Priority], [RaisedBy], [RaisedOn], [DueOn], [ResolvedOn], [IDSectionList]) VALUES (2, N'Ticket 002', 1, 1, 2, 2, 1, CAST(N'2018-11-27' AS Date), CAST(N'2018-12-05' AS Date), NULL, 2)
INSERT [dbo].[SupportList] ([TicketNo], [Title], [Status], [Category], [Severity], [Priority], [RaisedBy], [RaisedOn], [DueOn], [ResolvedOn], [IDSectionList]) VALUES (3, N'Ticket 003', 2, 2, 3, 3, 1, CAST(N'2018-11-27' AS Date), CAST(N'2018-11-28' AS Date), CAST(N'2018-11-28' AS Date), 3)
SET IDENTITY_INSERT [dbo].[SupportList] OFF
SET IDENTITY_INSERT [dbo].[UserList] ON 

INSERT [dbo].[UserList] ([ID], [Name], [Address], [City], [Country], [Phone], [Role], [Activ]) VALUES (1, N'Jon Doe', N'Stepe Step 49', N'Banja Luka', N'BiH', N'38765111222', N'Admin', 1)
INSERT [dbo].[UserList] ([ID], [Name], [Address], [City], [Country], [Phone], [Role], [Activ]) VALUES (2, N'Jane Doe', N'Stepe Step 94', N'Gradiska', N'BiH', N'38765333444', N'User', 0)
INSERT [dbo].[UserList] ([ID], [Name], [Address], [City], [Country], [Phone], [Role], [Activ]) VALUES (3, N'Test Die', N'Stepe Step 94', N'Prijedor', N'BiH', N'38765555666', N'Admin', 1)
SET IDENTITY_INSERT [dbo].[UserList] OFF
ALTER TABLE [dbo].[SupportList]  WITH CHECK ADD  CONSTRAINT [FK_SupportList_CategoryList] FOREIGN KEY([Category])
REFERENCES [dbo].[CategoryList] ([ID])
GO
ALTER TABLE [dbo].[SupportList] CHECK CONSTRAINT [FK_SupportList_CategoryList]
GO
ALTER TABLE [dbo].[SupportList]  WITH CHECK ADD  CONSTRAINT [FK_SupportList_PriorityList] FOREIGN KEY([Priority])
REFERENCES [dbo].[PriorityList] ([ID])
GO
ALTER TABLE [dbo].[SupportList] CHECK CONSTRAINT [FK_SupportList_PriorityList]
GO
ALTER TABLE [dbo].[SupportList]  WITH CHECK ADD  CONSTRAINT [FK_SupportList_SectionsList] FOREIGN KEY([IDSectionList])
REFERENCES [dbo].[SectionsList] ([ID])
GO
ALTER TABLE [dbo].[SupportList] CHECK CONSTRAINT [FK_SupportList_SectionsList]
GO
ALTER TABLE [dbo].[SupportList]  WITH CHECK ADD  CONSTRAINT [FK_SupportList_SeverityList] FOREIGN KEY([Severity])
REFERENCES [dbo].[SeverityList] ([ID])
GO
ALTER TABLE [dbo].[SupportList] CHECK CONSTRAINT [FK_SupportList_SeverityList]
GO
ALTER TABLE [dbo].[SupportList]  WITH CHECK ADD  CONSTRAINT [FK_SupportList_StatusesList] FOREIGN KEY([Status])
REFERENCES [dbo].[StatusesList] ([ID])
GO
ALTER TABLE [dbo].[SupportList] CHECK CONSTRAINT [FK_SupportList_StatusesList]
GO
ALTER TABLE [dbo].[SupportList]  WITH CHECK ADD  CONSTRAINT [FK_SupportList_UserList] FOREIGN KEY([RaisedBy])
REFERENCES [dbo].[UserList] ([ID])
GO
ALTER TABLE [dbo].[SupportList] CHECK CONSTRAINT [FK_SupportList_UserList]
GO
USE [master]
GO
ALTER DATABASE [DBPodrska] SET  READ_WRITE 
GO
