USE [RefactorDatabase]
GO

/****** Object:  Table [dbo].[Sellers]    Script Date: 19/09/2023 03:18:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sellers](
	[SellerId] [uniqueidentifier] NOT NULL,
	[SellerName] [nvarchar](255) NULL,
	[SellerAddress] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[SellerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


