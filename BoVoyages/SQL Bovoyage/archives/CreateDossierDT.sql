USE [Bovoyages]
GO

/****** Object:  Table [dbo].[Dossier]    Script Date: 18/01/2019 10:20:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dossier](
	[DossierID] [int] IDENTITY(1,1) NOT NULL,
	[VoyageID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[Etat] [tinyint] NOT NULL,
	[PrixTotal] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DossierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Dossier]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO

