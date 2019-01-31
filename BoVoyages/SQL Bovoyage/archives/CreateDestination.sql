CREATE TABLE [dbo].[Destination](
	[DestinationID] [int] IDENTITY(1,1) NOT NULL,
	[Region] [nvarchar](32) NOT NULL,
	[Pays] [nvarchar](32) NOT NULL,
	[Continent] [nvarchar](32) NOT NULL,
	[DescriptionVoyage] [nvarchar](512) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DestinationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


