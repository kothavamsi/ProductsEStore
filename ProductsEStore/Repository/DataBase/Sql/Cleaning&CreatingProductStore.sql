
/*-------------------- DROP BOOK (SLAVES/DEPENDANTS) ----------------------------*/
USE [ProductStore]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Book_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[Book]'))
ALTER TABLE [dbo].[Book] DROP CONSTRAINT [FK_Book_Category]
GO

USE [ProductStore]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 11/29/2016 18:04:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Book]') AND type in (N'U'))
DROP TABLE [dbo].[Book]
GO



/*-------------------- DROP CATEGORY (MASTER) ----------------------------*/
USE [ProductStore]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 11/29/2016 18:04:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO


USE [ProductStore]
GO

/*---------------------------- CREATE CATEGORY (MASTER) --------------------------*/

USE [ProductStore]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 11/29/2016 16:27:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO

USE [ProductStore]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 11/29/2016 16:27:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SEOFriendlyName] [nvarchar](50) NOT NULL,
	[BackUpName] [nvarchar](50) NOT NULL,
	[Rank] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Weight] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*---------------------------- CREATE BOOK (SLAVE/DEPENDANT) --------------------------*/

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Book_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[Book]'))
ALTER TABLE [dbo].[Book] DROP CONSTRAINT [FK_Book_Category]
GO

USE [ProductStore]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 11/29/2016 17:59:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Book]') AND type in (N'U'))
DROP TABLE [dbo].[Book]
GO

USE [ProductStore]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 11/29/2016 17:59:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](256) NOT NULL,
	[Author] [nvarchar](256) NULL,
	[Length] [int] NULL,
	[Edition] [int] NULL,
	[Language] [nvarchar](256) NULL,
	[Publisher] [nvarchar](256) NULL,
	[PublicationDate] [datetime] NULL,
	[ISBN10] [nvarchar](256) NULL,
	[ISBN13] [nvarchar](256) NULL,
	[CoverPageUrl] [nvarchar](256) NULL,
	[DetailsPageUrl] [nvarchar](256) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Book_ISBN10] UNIQUE NONCLUSTERED 
(
	[ISBN10] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UNIQUE_Book_ISBN13] UNIQUE NONCLUSTERED 
(
	[ISBN13] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Category]
GO


/* -------------------- SORTBYMENUITEMS ----------------*/
/****** Object:  Table [dbo].[SortByMenuItems]    Script Date: 11/29/2016 18:01:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SortByMenuItems]') AND type in (N'U'))
DROP TABLE [dbo].[SortByMenuItems]
GO

USE [ProductStore]
GO

/****** Object:  Table [dbo].[SortByMenuItems]    Script Date: 11/29/2016 18:01:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SortByMenuItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SEOFriendlyName] [nvarchar](50) NOT NULL,
	[BackUpName] [nvarchar](50) NOT NULL,
	[Rank] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Weight] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_SortByMenuItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


