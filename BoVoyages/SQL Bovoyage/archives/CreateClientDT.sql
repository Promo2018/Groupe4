USE [Bovoyages]
GO

/****** Object:  Table [dbo].[Client]    Script Date: 18/01/2019 10:20:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Civilite] [nvarchar](32) NOT NULL,
	[Nom] [nvarchar](32) NOT NULL,
	[Prenom] [nvarchar](32) NOT NULL,
	[Adresse] [nvarchar](128) NOT NULL,
	[CodePostal] [nvarchar](32) NOT NULL,
	[Ville] [nvarchar](64) NOT NULL,
	[DateDeNaissance] [date] NOT NULL,
	[Telephone] [nvarchar](16) NULL,
	[Email] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

