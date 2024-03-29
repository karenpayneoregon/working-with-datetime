USE [master]
GO
/****** Object:  Database [TimeOnlyDatabase]    Script Date: 1/1/2023 3:56:25 AM ******/
CREATE DATABASE [TimeOnlyDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TimeOnlyDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TimeOnlyDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TimeOnlyDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TimeOnlyDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TimeOnlyDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TimeOnlyDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TimeOnlyDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TimeOnlyDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TimeOnlyDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TimeOnlyDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TimeOnlyDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TimeOnlyDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [TimeOnlyDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TimeOnlyDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TimeOnlyDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TimeOnlyDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TimeOnlyDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TimeOnlyDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TimeOnlyDatabase] SET QUERY_STORE = OFF
GO
USE [TimeOnlyDatabase]
GO
/****** Object:  Table [dbo].[Visitor]    Script Date: 1/1/2023 3:56:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitor](
	[VisitorIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[EmailAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Visitor] PRIMARY KEY CLUSTERED 
(
	[VisitorIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisitorLog]    Script Date: 1/1/2023 3:56:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitorLog](
	[VistorLogIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[VisitorIdentifier] [int] NULL,
	[VisitOn] [date] NULL,
	[EnteredTime] [time](7) NULL,
	[ExitedTime] [time](7) NULL,
 CONSTRAINT [PK_VisitorLog] PRIMARY KEY CLUSTERED 
(
	[VistorLogIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Visitor] ON 

INSERT [dbo].[Visitor] ([VisitorIdentifier], [FirstName], [LastName], [EmailAddress]) VALUES (1, N'Karen', N'Payne', N'payne@somedomain.com')
INSERT [dbo].[Visitor] ([VisitorIdentifier], [FirstName], [LastName], [EmailAddress]) VALUES (2, N'Jim', N'Gallagher', N'jim@comcast.net')
INSERT [dbo].[Visitor] ([VisitorIdentifier], [FirstName], [LastName], [EmailAddress]) VALUES (3, N'Mary', N'Jones', N'jones@gmail.com')
SET IDENTITY_INSERT [dbo].[Visitor] OFF
GO
SET IDENTITY_INSERT [dbo].[VisitorLog] ON 

INSERT [dbo].[VisitorLog] ([VistorLogIdentifier], [VisitorIdentifier], [VisitOn], [EnteredTime], [ExitedTime]) VALUES (1, 2, CAST(N'2018-06-23' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time))
INSERT [dbo].[VisitorLog] ([VistorLogIdentifier], [VisitorIdentifier], [VisitOn], [EnteredTime], [ExitedTime]) VALUES (2, 3, CAST(N'2022-01-01' AS Date), CAST(N'11:00:00' AS Time), CAST(N'13:00:00' AS Time))
INSERT [dbo].[VisitorLog] ([VistorLogIdentifier], [VisitorIdentifier], [VisitOn], [EnteredTime], [ExitedTime]) VALUES (3, 3, CAST(N'2020-07-09' AS Date), CAST(N'15:00:00' AS Time), CAST(N'15:45:00' AS Time))
INSERT [dbo].[VisitorLog] ([VistorLogIdentifier], [VisitorIdentifier], [VisitOn], [EnteredTime], [ExitedTime]) VALUES (4, 3, CAST(N'2020-07-10' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:05:00' AS Time))
INSERT [dbo].[VisitorLog] ([VistorLogIdentifier], [VisitorIdentifier], [VisitOn], [EnteredTime], [ExitedTime]) VALUES (5, 1, CAST(N'2022-08-08' AS Date), CAST(N'09:00:00' AS Time), CAST(N'10:10:10' AS Time))
SET IDENTITY_INSERT [dbo].[VisitorLog] OFF
GO
ALTER TABLE [dbo].[VisitorLog]  WITH CHECK ADD  CONSTRAINT [FK_VisitorLog_Visitor] FOREIGN KEY([VisitorIdentifier])
REFERENCES [dbo].[Visitor] ([VisitorIdentifier])
GO
ALTER TABLE [dbo].[VisitorLog] CHECK CONSTRAINT [FK_VisitorLog_Visitor]
GO
/****** Object:  StoredProcedure [dbo].[generalSelect]    Script Date: 1/1/2023 3:56:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[generalSelect] AS
BEGIN
SELECT VL.VistorLogIdentifier AS [Log id],
       VL.VisitorIdentifier AS [Visitor Id],
       FORMAT(VL.VisitOn, 'MM-dd-yy') AS [Visit on],
       FORMAT(CAST(VL.EnteredTime AS DATETIME), 'hh:mm tt') AS [Entered],
       FORMAT(CAST(VL.ExitedTime AS DATETIME), 'hh:mm tt') AS [Exited],
       V.FirstName + ' ' + V.LastName AS [Full Name]
FROM dbo.VisitorLog AS VL
    INNER JOIN dbo.Visitor AS V
        ON VL.VisitorIdentifier = V.VisitorIdentifier
ORDER BY VL.VisitOn DESC;
END

GO
USE [master]
GO
ALTER DATABASE [TimeOnlyDatabase] SET  READ_WRITE 
GO
