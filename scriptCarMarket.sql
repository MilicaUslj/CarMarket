USE [master]
GO
/****** Object:  Database [CarMarket]    Script Date: 1/30/2022 1:10:07 PM ******/
CREATE DATABASE [CarMarket]
GO

USE [CarMarket]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/30/2022 1:10:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] NOT NULL,
	[CetgoryName] [nvarchar](50) NULL,
	[CategoryDescription] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Offer]    Script Date: 1/30/2022 1:10:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Model] [nvarchar](50) NULL,
	[Year] [int] NULL,
	[Distance] [int] NULL,
	[Power(KW)] [int] NULL,
	[Power(HP)] [int] NULL,
	[Price] [int] NULL,
	[Desription] [nvarchar](500) NULL,
	[Notice] [nvarchar](500) NULL,
	[Contact] [nvarchar](50) NULL,
	[Category] [int] NULL,
	[Picture] [nvarchar](max) NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Category] ([ID], [CetgoryName], [CategoryDescription]) VALUES (1, N'Cars', NULL)
INSERT [dbo].[Category] ([ID], [CetgoryName], [CategoryDescription]) VALUES (2, N'Motorcycles i ATW', NULL)
INSERT [dbo].[Category] ([ID], [CetgoryName], [CategoryDescription]) VALUES (3, N'Carriage vehicles', NULL)
SET IDENTITY_INSERT [dbo].[Offer] ON 

INSERT [dbo].[Offer] ([ID], [Model], [Year], [Distance], [Power(KW)], [Power(HP)], [Price], [Desription], [Notice], [Contact], [Category], [Picture]) VALUES (2, N'lexux', 5678, 45678, 567, 567, 456789, N'dfghjk', N'rtyui', N'45678', 1, N'~/Images/corsa22213027791.jpg')
INSERT [dbo].[Offer] ([ID], [Model], [Year], [Distance], [Power(KW)], [Power(HP)], [Price], [Desription], [Notice], [Contact], [Category], [Picture]) VALUES (3, N'novi', 5678, 56789, 567, 5678, 56789, N'fghj', N'rtyu', N'56789', 1, N'~/Images/NoImage.png')
SET IDENTITY_INSERT [dbo].[Offer] OFF
ALTER TABLE [dbo].[Offer]  WITH CHECK ADD  CONSTRAINT [FK_Offer_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Offer] CHECK CONSTRAINT [FK_Offer_Category]
GO
USE [master]
GO
ALTER DATABASE [CarMarket] SET  READ_WRITE 
GO
