USE [RefactorDatabase]
GO

/****** Object:  Table [dbo].[Accounts]    Script Date: 19/09/2023 03:17:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Accounts](
	[AccountId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[AvailableLimit] [float] NULL,
	[ActiveCard] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


