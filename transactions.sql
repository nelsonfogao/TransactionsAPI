USE [RefactorDatabase]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 19/09/2023 03:18:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions](
	[TransactionId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NULL,
	[SellerId] [uniqueidentifier] NULL,
	[Value] [float] NULL,
	[TransactionStatus] [nvarchar](255) NULL,
	[Timestamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([AccountId])
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_AccountId]
GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_SellerId] FOREIGN KEY([SellerId])
REFERENCES [dbo].[Sellers] ([SellerId])
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_SellerId]
GO


