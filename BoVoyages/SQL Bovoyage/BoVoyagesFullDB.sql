USE [master]
GO
/****** Object:  Database [BoVoyages]    Script Date: 31/01/2019 18:42:56 ******/
CREATE DATABASE [BoVoyages]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BoVoyages', FILENAME = N'S:\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BoVoyages.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BoVoyages_log', FILENAME = N'S:\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BoVoyages_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BoVoyages] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BoVoyages].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BoVoyages] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BoVoyages] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BoVoyages] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BoVoyages] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BoVoyages] SET ARITHABORT OFF 
GO
ALTER DATABASE [BoVoyages] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BoVoyages] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BoVoyages] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BoVoyages] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BoVoyages] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BoVoyages] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BoVoyages] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BoVoyages] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BoVoyages] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BoVoyages] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BoVoyages] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BoVoyages] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BoVoyages] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BoVoyages] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BoVoyages] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BoVoyages] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BoVoyages] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BoVoyages] SET RECOVERY FULL 
GO
ALTER DATABASE [BoVoyages] SET  MULTI_USER 
GO
ALTER DATABASE [BoVoyages] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BoVoyages] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BoVoyages] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BoVoyages] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BoVoyages] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BoVoyages', N'ON'
GO
ALTER DATABASE [BoVoyages] SET QUERY_STORE = OFF
GO
USE [BoVoyages]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BoVoyages]
GO
/****** Object:  Table [dbo].[AgencesVoyages]    Script Date: 31/01/2019 18:42:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgencesVoyages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NomAgence] [nvarchar](32) NOT NULL,
	[VoyageID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assurances]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assurances](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](32) NOT NULL,
	[Cout] [int] NOT NULL,
	[Type] [nvarchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Civilite] [nvarchar](32) NOT NULL,
	[Nom] [nvarchar](32) NOT NULL,
	[Prenom] [nvarchar](32) NOT NULL,
	[Adresse] [nvarchar](128) NOT NULL,
	[Ville] [nvarchar](64) NOT NULL,
	[DateDeNaissance] [nvarchar](32) NULL,
	[Telephone] [nvarchar](16) NULL,
	[Email] [nvarchar](64) NOT NULL,
	[Statut] [nvarchar](32) NULL,
	[DossierID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destinations]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Region] [nvarchar](32) NOT NULL,
	[Pays] [nvarchar](32) NOT NULL,
	[Continent] [nvarchar](16) NOT NULL,
	[DescriptionVoyage] [nvarchar](512) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dossiers]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dossiers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VoyageID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[Etat] [tinyint] NOT NULL,
	[PrixTotal] [int] NULL,
	[CarteBancaire] [nvarchar](16) NOT NULL,
	[RaisonAnnulation] [nvarchar](32) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JointAssurDossier]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JointAssurDossier](
	[AssuranceID] [int] NOT NULL,
	[DossierID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voyages]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voyages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DestinationID] [int] NOT NULL,
	[DateAller] [date] NOT NULL,
	[DateRetour] [date] NOT NULL,
	[NombreDePlaces] [tinyint] NOT NULL,
	[Prix] [float] NULL,
	[AgenceID] [int] NULL,
 CONSTRAINT [PK_Voyage_VoyageID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AgencesVoyages] ON 
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (1, N'Havas Voyages Loisirs', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (2, N'Selectour', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (3, N'Monde Authentique', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (4, N'Voyages Antillais', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (5, N'Salaun Holidays', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (6, N'Voyages Rive Gauche', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (7, N'Verdie Voyages ', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (8, N'La Case Depart', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (9, N'Sol Latino', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (10, N'Ultramarina', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (11, N'Soltours France', NULL)
GO
INSERT [dbo].[AgencesVoyages] ([ID], [NomAgence], [VoyageID]) VALUES (12, N'Charna Voyages', NULL)
GO
SET IDENTITY_INSERT [dbo].[AgencesVoyages] OFF
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (1, N'Mme', N'Kaleva', N'Meggy', N'4 rue Sycamore', N'Paris', N'1979-04-23', N'0690080878', N'meggyisok@something.com', N'Client', 82)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (2, N'M.', N'Dupont', N'Jean', N'15 rue du lieu commun', N'Paris', N'1965-03-01', N'0607695812', N'jd@something.com', N'Participant', 80)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (3, N'Mlle', N'Ricohard', N'Chazael', N'25 rue Deercove', N'Lyon', N'2000-03-21', N'0471252110', N'rico666@gmail.com', N'Client', 78)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (4, N'M.', N'Dwyn', N'Felix', N'26 rue Devils Hill', N'Paris', N'1999-10-21', N'0345252091', N'ro677@gmail.com', N'Participant', 82)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (5, N'M.', N'Ragnvald', N'Evelin', N'3 rue Jennifer Lane', N'Paris', N'1955-01-16', N'0789289591', N'rragna7@gmail.com', N'Client', 84)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (73, N'M.', N'Campelli', N'Bear', N'9872 Pennsylvania Alley', N'Mutsu', N'22/1/2018', N'(133) 7783124', N'bcampelli0@woothemes.com', N'Client', 72)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (74, N'Mme', N'Borell', N'Jany', N'71494 Del Sol Drive', N'Gaoshi', N'22/1/2018', N'(278) 3443995', N'jborell1@vistaprint.com', N'Client', 2)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (75, N'M.', N'Minghi', N'Al', N'2094 Grayhawk Trail', N'Naples', N'22/1/2018', N'(941) 1619407', N'aminghi2@businessinsider.com', N'Client', 73)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (76, N'Mme', N'McGenis', N'Ninon', N'8568 Calypso Hill', N'Duque de Caxias', N'22/1/2018', N'(406) 1492107', N'nmcgenis3@rambler.ru', N'Participant', 93)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (77, N'Mme', N'Gergolet', N'Basia', N'6160 Buell Road', N'Pysznica', N'22/1/2018', N'(643) 1092039', N'bgergolet4@mediafire.com', N'Client', 2)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (78, N'M.', N'Benninger', N'Burgess', N'422 Hintze Park', N'Fuyong', N'22/1/2018', N'(332) 1613149', N'bbenninger5@plala.or.jp', N'Client', 82)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (79, N'Female', N'Whitland', N'Myranda', N'3167 Forest Plaza', N'Iturama', N'22/1/2018', N'(561) 7427269', N'mwhitland6@auda.org.au', N'Client', 72)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (80, N'M.', N'Clousley', N'Gradey', N'1449 Mallory Road', N'Jinshan', N'22/1/2018', N'(313) 3273792', N'gclousley7@dropbox.com', N'Participant', 2)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (81, N'M.', N'Milington', N'Rollins', N'81 Carioca Junction', N'Luchingu', N'22/1/2018', N'(654) 6019104', N'rmilington8@addthis.com', N'Client', 95)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (82, N'Female', N'Faber', N'Roxie', N'03 Rowland Center', N'Kharlu', N'22/1/2018', N'(982) 1232302', N'rfaber9@newsvine.com', N'Participant', 76)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (83, N'M.', N'Iwanczyk', N'Stacy', N'2 Hermina Center', N'Kushnarënkovo', N'22/1/2018', N'(446) 1175441', N'siwanczyka@xinhuanet.com', N'Client', 95)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (84, N'M.', N'Monteaux', N'Aldo', N'8748 Warrior Avenue', N'Chongju', N'22/1/2018', N'(907) 8817174', N'amonteauxb@va.gov', N'Client', 84)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (85, N'Female', N'Caccavale', N'Dael', N'83 Chive Avenue', N'Margorejo', N'22/1/2018', N'(790) 2952709', N'dcaccavalec@vimeo.com', N'Client', 74)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (86, N'Female', N'Rosenblath', N'Cori', N'1 Blue Bill Park Alley', N'Osieczna', N'22/1/2018', N'(581) 6926116', N'crosenblathd@harvard.edu', N'Client', 82)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (87, N'Female', N'Wherton', N'Serene', N'35 Londonderry Parkway', N'El Cerrito', N'22/1/2018', N'(198) 4499883', N'swhertone@irs.gov', N'Participant', 78)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (88, N'M.', N'Cohane', N'Nicko', N'58174 Oxford Place', N'Tiantang', N'22/1/2018', N'(475) 9565611', N'ncohanef@behance.net', N'Client', 98)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (89, N'M.', N'Gopsell', N'Skipper', N'78 Crowley Lane', N'Hougaoshizhuang', N'22/1/2018', N'(847) 3832808', N'sgopsellg@princeton.edu', N'Client', 95)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (90, N'M.', N'Hissie', N'Bax', N'381 Drewry Court', N'Warugunung', N'22/1/2018', N'(576) 5404784', N'bhissieh@barnesandnoble.com', N'Client', 76)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (91, N'Female', N'Verner', N'Gabrielle', N'4466 Judy Avenue', N'Orerokpe', N'22/1/2018', N'(155) 1633678', N'gverneri@simplemachines.org', N'Client', 2)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (92, N'M.', N'Gillard', N'Tadio', N'815 Sachs Hill', N'Nizui', N'22/1/2018', N'(824) 2629563', N'tgillardj@wufoo.com', N'Client', 80)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (93, N'Female', N'Oleszkiewicz', N'Mia', N'3462 Maywood Junction', N'Xinwu', N'22/1/2018', N'(565) 9364533', N'moleszkiewiczk@usnews.com', N'Client', 73)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (94, N'Female', N'O''Connolly', N'Rosa', N'45139 Clyde Gallagher Street', N'Jönköping', N'22/1/2018', N'(946) 6613347', N'roconnollyl@over-blog.com', N'Participant', 2)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (95, N'Female', N'Vidgeon', N'Violetta', N'9 Sheridan Road', N'Baracatan', N'22/1/2018', N'(409) 3250089', N'vvidgeonm@usnews.com', N'Client', 95)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (96, N'Female', N'Flowerdew', N'Petunia', N'2206 Hooker Place', N'Yangjiaping', N'22/1/2018', N'(403) 1818336', N'pflowerdewn@digg.com', N'Client', 93)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (97, N'M.', N'Carillo', N'Orlando', N'86236 4th Crossing', N'Bajos de Haina', N'22/1/2018', N'(483) 5960488', N'ocarilloo@aol.com', N'Participant', 1)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (98, N'M.', N'Strafen', N'Ichabod', N'1039 Arkansas Center', N'Uralets', N'22/1/2018', N'(567) 6777674', N'istrafenp@china.com.cn', N'Client', 84)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (99, N'Female', N'Alyonov', N'Gisella', N'78 Chinook Court', N'Balboa', N'22/1/2018', N'(827) 5031899', N'galyonovq@reddit.com', N'Client', 89)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (100, N'Mme', N'Martlew', N'Mathilde', N'1 Knutson Court', N'Dianshui', N'22/1/2018', N'(436) 7910400', N'mmartlewr@homestead.com', N'Participant', 72)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (102, N'M.', N'Norledge', N'Randal', N'392 Everett Park', N'Maquiapo', N'22/1/2018', N'(277) 9544182', N'rnorledget@ucla.edu', N'Client', 98)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (109, N'mr', N'Donald', N'Duck', N'here', N'there', N'23/4/1975', N'222', N'donduck@ok.com', N'part', NULL)
GO
INSERT [dbo].[Clients] ([ID], [Civilite], [Nom], [Prenom], [Adresse], [Ville], [DateDeNaissance], [Telephone], [Email], [Statut], [DossierID]) VALUES (112, N'mr', N'Mickey', N'Mouse', N'here', N'there', N'23/4/1900', N'888', N'mickm@ok.com', N'part', 98)
GO
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Destinations] ON 
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (2, N'Souss-Massa', N'Maroc', N'Afrique', N'Douceur du climat, variété et beauté des paysages naturels, richesse patrimoniale... autant d’atouts faisant du Souss Massa une destination touristique d’excellence.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (3, N'Tanger-Tétouan', N'Maroc', N'Afrique', N'Qualifiée de Jet-Set international, la Région de Tanger-Tétouan bénéficie d’une situation géographique stratégique. C’est l’une de régions balnéaires les plus fréquentées du royaume.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (4, N'Marrakech', N'Maroc', N'Afrique', N'La région de Marrakech-Safi demeure la capitale touristique du pays. Plus qu’une région, Marrakech-Safi est une perle polie par l’histoire et le goût de l’accueil, sachant accueillir ses invités à bras ouverts depuis des siècles et englobe une partie du Haut Atlas.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (5, N'Addis-Abeba', N'Ethiopie', N'Afrique', N'Cœur économique du pays, Addis-Abeba offre un bel aperçu de l’histoire et de la culture éthiopienne. Celle-ci regorge d’églises et de musées aussi intéressants que beaux à découvrir.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (6, N'Région Est', N'Ethiopie', N'Afrique', N'À l’est de l’Éthiopie, impossible de passer à côté d’une des villes les plus emblématiques du pays, Harar. Considérée comme la quatrième ville sainte de l’Islam, Harar est surtout une ville à part entière, contrastant ainsi avec le reste du pays.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (7, N'La  vallée du Rift', N'Ethiopie', N'Afrique', N'Au sud de l’Éthiopie on retrouve l’une des plus jolies villes du pays, Awasa située sur les bords du lac du même nom. Située à 1708 mètres d’altitude dans la vallée du rift, cette ville se présente pour les habitants d’Addis-Abeba comme le lieu parfait pour se détendre le week-end.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (8, N'Tibet', N'Chine', N'Asie', N'Bien que difficile d’accès, la capitale du Tibet attire toujours de nombreux étrangers. Situé à une altitude de 3700 mètres et avec plus de 3000 heures d’ensoleillement par an, Lhassa est célèbre pour le surnom que l’on lui porte « ville du soleil ».')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (9, N'Beijing', N'Chine', N'Asie', N'Capitale chinoise depuis plus de 700 ans, Pékin est la première destination chinoise convoitée par les touristes. Riche d’une longue histoire, cette mégalopole fascine par la diversité de ses monuments historiques et modernes. Beijing est la ville qui renferme certains des plus beaux vestiges du passé impérial : la Grande Muraille de Chine, la Cité Interdite et la grande place Tiananmen, le Temple du Ciel et le fabuleux palais d’été.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (10, N'Guangdong', N'Chine', N'Asie', N'Le Guangdong n’est pas la province la plus touristique de Chine, loin s’en faut. Pourtant, elle regorge de sites touristiques qui méritent qu’on s’y intéresse. De Guangzhou à Shenzhen en passant par Zhuhai, les visites ne manquent pas et valent assurément le détour. Suivez le guide !')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (41, N'Kariya', N'Japon', N'Asie', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (42, N'Tambac', N'Philippines', N'Asie', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (43, N'Carson City', N'Etats-Unis', N'Amérique', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (44, N'Guangming', N'Chine', N'Asie', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (45, N'Usol’ye', N'Russie', N'Europe', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (46, N'Lloydminster', N'Canada', N'Amérique', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (47, N'Tanshan', N'Chine', N'Asie', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (48, N'Valencia', N'Philippines', N'Asie', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (49, N'Lelkowo', N'Pologne', N'Europe', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (50, N'Las Vegas', N'Etats-Unis', N'Amérique', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.')
GO
INSERT [dbo].[Destinations] ([ID], [Region], [Pays], [Continent], [DescriptionVoyage]) VALUES (51, N'titi', N'toto', N'Chine', N'Lorem ipsum etc')
GO
SET IDENTITY_INSERT [dbo].[Destinations] OFF
GO
SET IDENTITY_INSERT [dbo].[Dossiers] ON 
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (1, 1, 1, 2, 786, N'473245300678', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (2, 9, 1, 0, 6105, N'239549189815', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (72, 44, 97, 0, 4479, N'188942004488', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (73, 22, 85, 2, 1012, N'845707021887', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (74, 47, 75, 2, 714, N'380777617119', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (76, 7, 95, 1, 1694, N'625033369560', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (78, 9, 89, 3, 2442, N'147043809577', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (80, 22, 73, 0, 1012, N'615845335669', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (82, 30, 102, 2, 1408, N'38269478939', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (83, 46, 77, 1, 0, N'451844133179', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (84, 23, 84, 3, 3696, N'570991034350', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (87, 44, 77, 0, 0, N'581120735041', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (89, 40, 75, 3, 1187, N'948391007963', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (90, 30, 83, 3, 0, N'722816713297', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (93, 8, 77, 3, 3276, N'207072852701', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (95, 7, 78, 0, 3388, N'20821880651', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (98, 30, 86, 0, 1056, N'806698741492', NULL)
GO
INSERT [dbo].[Dossiers] ([ID], [VoyageID], [ClientID], [Etat], [PrixTotal], [CarteBancaire], [RaisonAnnulation]) VALUES (99, 8, 81, 3, 0, N'993907083373', NULL)
GO
SET IDENTITY_INSERT [dbo].[Dossiers] OFF
GO
SET IDENTITY_INSERT [dbo].[Voyages] ON 
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (1, 9, CAST(N'2019-02-03' AS Date), CAST(N'2019-02-07' AS Date), 3, 786, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (2, 8, CAST(N'2019-02-11' AS Date), CAST(N'2019-02-17' AS Date), 8, 1425, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (3, 8, CAST(N'2019-02-12' AS Date), CAST(N'2019-02-25' AS Date), 2, 1389, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (5, 41, CAST(N'2019-02-04' AS Date), CAST(N'2019-02-09' AS Date), 4, 390, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (6, 41, CAST(N'2019-02-07' AS Date), CAST(N'2019-02-20' AS Date), 1, 488, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (7, 2, CAST(N'2019-02-06' AS Date), CAST(N'2019-02-22' AS Date), 2, 847, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (8, 9, CAST(N'2019-02-08' AS Date), CAST(N'2019-02-23' AS Date), 5, 1638, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (9, 3, CAST(N'2019-02-01' AS Date), CAST(N'2019-02-19' AS Date), 6, 1221, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (10, 2, CAST(N'2019-02-01' AS Date), CAST(N'2019-02-15' AS Date), 6, 1794, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (11, 41, CAST(N'2019-02-03' AS Date), CAST(N'2019-02-06' AS Date), 2, 604, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (13, 49, CAST(N'2019-02-06' AS Date), CAST(N'2019-02-26' AS Date), 8, 1181, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (22, 42, CAST(N'2018-12-26' AS Date), CAST(N'2019-02-24' AS Date), 4, 506, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (23, 47, CAST(N'2018-11-01' AS Date), CAST(N'2018-11-06' AS Date), 5, 1232, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (30, 42, CAST(N'2018-06-03' AS Date), CAST(N'2018-06-19' AS Date), 8, 352, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (34, 41, CAST(N'2018-02-24' AS Date), CAST(N'2019-01-27' AS Date), 1, 895, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (36, 41, CAST(N'2018-05-01' AS Date), CAST(N'2018-08-24' AS Date), 5, 979, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (38, 44, CAST(N'2018-09-16' AS Date), CAST(N'2019-02-08' AS Date), 3, 474, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (40, 46, CAST(N'2018-07-03' AS Date), CAST(N'2018-07-30' AS Date), 1, 1187, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (42, 43, CAST(N'2018-07-28' AS Date), CAST(N'2018-07-24' AS Date), 3, 894, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (44, 48, CAST(N'2018-12-31' AS Date), CAST(N'2019-02-13' AS Date), 6, 1493, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (45, 41, CAST(N'2018-05-03' AS Date), CAST(N'2019-01-18' AS Date), 1, 316, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (46, 49, CAST(N'2019-01-27' AS Date), CAST(N'2019-01-25' AS Date), 7, 309, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (47, 48, CAST(N'2018-02-09' AS Date), CAST(N'2018-12-23' AS Date), 5, 714, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (48, 42, CAST(N'2018-05-04' AS Date), CAST(N'2018-05-21' AS Date), 1, 1378, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (49, 46, CAST(N'2019-02-12' AS Date), CAST(N'2019-01-28' AS Date), 6, 511, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (50, 43, CAST(N'2018-03-25' AS Date), CAST(N'2018-04-24' AS Date), 2, 671, NULL)
GO
INSERT [dbo].[Voyages] ([ID], [DestinationID], [DateAller], [DateRetour], [NombreDePlaces], [Prix], [AgenceID]) VALUES (54, 9, CAST(N'2019-01-02' AS Date), CAST(N'2020-01-02' AS Date), 3, 655, 1)
GO
SET IDENTITY_INSERT [dbo].[Voyages] OFF
GO
ALTER TABLE [dbo].[AgencesVoyages]  WITH CHECK ADD FOREIGN KEY([VoyageID])
REFERENCES [dbo].[Voyages] ([ID])
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Client_DossierID] FOREIGN KEY([DossierID])
REFERENCES [dbo].[Dossiers] ([ID])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Client_DossierID]
GO
ALTER TABLE [dbo].[Dossiers]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Dossiers]  WITH CHECK ADD  CONSTRAINT [FK_Dossier_VoyageID] FOREIGN KEY([VoyageID])
REFERENCES [dbo].[Voyages] ([ID])
GO
ALTER TABLE [dbo].[Dossiers] CHECK CONSTRAINT [FK_Dossier_VoyageID]
GO
ALTER TABLE [dbo].[JointAssurDossier]  WITH CHECK ADD FOREIGN KEY([AssuranceID])
REFERENCES [dbo].[Assurances] ([ID])
GO
ALTER TABLE [dbo].[JointAssurDossier]  WITH CHECK ADD FOREIGN KEY([DossierID])
REFERENCES [dbo].[Dossiers] ([ID])
GO
ALTER TABLE [dbo].[Voyages]  WITH CHECK ADD FOREIGN KEY([AgenceID])
REFERENCES [dbo].[AgencesVoyages] ([ID])
GO
ALTER TABLE [dbo].[Voyages]  WITH CHECK ADD  CONSTRAINT [FK_Voyage_DestinationID] FOREIGN KEY([DestinationID])
REFERENCES [dbo].[Destinations] ([ID])
GO
ALTER TABLE [dbo].[Voyages] CHECK CONSTRAINT [FK_Voyage_DestinationID]
GO
/****** Object:  StoredProcedure [dbo].[AjouterDestination]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AjouterDestination](@Region nvarchar(32), @Pays nvarchar(32), @Continent nvarchar(32), @DescriptionVoyage nvarchar(512)) AS
	BEGIN
	Insert into dbo.Destinations values (@Region, @Pays, @Continent, @DescriptionVoyage);
	END
GO
/****** Object:  StoredProcedure [dbo].[AjouterVoyage]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AjouterVoyage](@DestinationID int, @DateAller date, @DateRetour date, @NombreDePlaces tinyint, @Prix float, @AgenceID int) AS
	BEGIN
	if @NombreDePlaces < 9
		Insert into dbo.Voyages values (@DestinationID, @DateAller, @DateRetour, @NombreDePlaces, @Prix, @AgenceID);
	END
GO
/****** Object:  StoredProcedure [dbo].[CalculPrixDossier]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[CalculPrixDossier] as
	Begin
	DECLARE @DossierID int = 1;
	WHILE @DossierID <= 300
		Begin
		DECLARE @NombreVoyageurs int = (select distinct count(*) from Clients C, Dossiers D where D.DossierID = @DossierID AND C.DossierID = D.DossierID);
		DECLARE @Prix int = (select Prix from Voyages V, Dossiers D where D.DossierID=@DossierID AND D.VoyageID=V.VoyageID);
		update Dossiers set PrixTotal = @Prix*@NombreVoyageurs where DossierID=@DossierID;
		SET @DossierID = @DossierID + 1;
		End;
	End;
GO
/****** Object:  StoredProcedure [dbo].[CalculPrixVoyage]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CalculPrixVoyage] as
	Begin
	DECLARE @VoyageID int = 1;
	WHILE @VoyageID <= 300
		
		BEGIN
		
		DECLARE @Prix int = (select Prix from Voyages V, Dossiers D where D.ID=V.ID);
		
		DECLARE @Assurance int = (select A.Cout from Assurances A, Dossiers D, JointAssurDossier J where A.ID=J.AssuranceID and D.ID=J.DossierID);

		--IF (select DateDeNaissance from Clients) > 2007 { DECLARE @Reduction = @Prix - (@Prix*0.6)}		

		DECLARE @PrixVoyage int = (@Prix + @Assurance) -- - @Reduction)		-- UPDATE into a new table	
		
		SET @VoyageID = @VoyageID + 1;
		End;
	End;
GO
/****** Object:  StoredProcedure [dbo].[DeleteClient]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteClient]
(
@ClientID int
)
AS 
        BEGIN
            DELETE FROM Clients
            Where ClientID = @ClientID
        END
GO
/****** Object:  StoredProcedure [dbo].[InsertClient]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertClient]

@Civ nvarchar(32),
@Nom nvarchar(32),
@Prenom nvarchar(32),
@Adresse nvarchar(128),
@Ville nvarchar(64), 
@DateDeNaissance nvarchar(32),
@Telephone nvarchar(16),
@Email nvarchar(64),
@Statut nvarchar(32),
@DossierID int
AS
	BEGIN
		INSERT INTO Client( Civilite, Nom, Prenom, Adresse, Ville, DateDeNaissance, Telephone, Email, Statut, DossierID) values (@Civ, @Nom, @Prenom, @Adresse, @Ville, @DateDeNaissance, @Telephone, @Email, @Statut, @DossierID);
	END
GO
/****** Object:  StoredProcedure [dbo].[PrixAleatoires]    Script Date: 31/01/2019 18:42:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PrixAleatoires] AS
Begin
	DECLARE @VoyageID int = 0;
	while @VoyageID<14
	Begin
		UPDATE  Voyage set Prix=CAST(RAND()*2000 AS INT) where VoyageID=@VoyageID;
		SET @VoyageID = @VoyageID +1;
	End
End
GO
USE [master]
GO
ALTER DATABASE [BoVoyages] SET  READ_WRITE 
GO
