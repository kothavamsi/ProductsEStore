SET ANSI_PADDING OFF;

USE [ProductsEStore]
GO

/****** Object:  Table [dbo].[PopularTags]    Script Date: 11/26/2016 17:34:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PopularTags]') AND type in (N'U'))
DROP TABLE [dbo].[PopularTags]
GO

USE [ProductsEStore]
GO

/****** Object:  Table [dbo].[[PopularTags]]    Script Date: 11/26/2016 17:34:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PopularTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Keyword] [varchar](50) NOT NULL,
	[Count] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastSearchedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_PopularTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO






USE [ProductsEStore]
GO

/****** Object:  Table [dbo].[PopularAuthorTags]    Script Date: 11/26/2016 17:38:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PopularAuthorTags]') AND type in (N'U'))
DROP TABLE [dbo].[PopularAuthorTags]
GO

USE [ProductsEStore]
GO

/****** Object:  Table [dbo].[PopularAuthorTags]    Script Date: 11/26/2016 17:38:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PopularAuthorTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[Count] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastSearchedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_PopularAuthorTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO







USE [ProductsEStore]
GO

/****** Object:  Table [dbo].[PopularPublisherTags]    Script Date: 11/26/2016 17:40:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PopularPublisherTags]') AND type in (N'U'))
DROP TABLE [dbo].[PopularPublisherTags]
GO

USE [ProductsEStore]
GO

/****** Object:  Table [dbo].[PopularPublisherTags]    Script Date: 11/26/2016 17:40:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PopularPublisherTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Publisher] [varchar](50) NOT NULL,
	[Count] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastSearchedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_PopularPublisherTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO






