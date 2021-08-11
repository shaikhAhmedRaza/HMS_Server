USE [hms_db]
GO

/****** Object:  Table [dbo].[DishCategory]    Script Date: 11-08-2021 11:48:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DishCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[Name] [varchar](100) NULL,
	[HotelId] [int] NULL,
	[GSTcompliance] [int] NULL
) ON [PRIMARY]
GO


