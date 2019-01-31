CREATE TABLE [dbo].[Voyage](
	[VoyageID] [int] IDENTITY(1,1) NOT NULL,
	[DestinationID] [int] NOT NULL,
	[DateAller] [date] NOT NULL,
	[DateRetour] [date] NOT NULL,
	[NombreDePlaces] [tinyint] NOT NULL,
	[Prix] [float] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Voyage]  WITH CHECK ADD FOREIGN KEY([DestinationID])
REFERENCES [dbo].[Destination] ([DestinationID])
GO


