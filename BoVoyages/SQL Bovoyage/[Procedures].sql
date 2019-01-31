USE [BoVoyages]

------------------------
--DOSSIER

/*DROP PROCEDURE CalculPrixDossier;

Create procedure CalculPrixDossier as
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
Go

execute CalculPrixDossier
*/

------------------------
--DESTINATION

/*DROP PROCEDURE [dbo].[AjouterDestination]
GO
CREATE PROCEDURE [dbo].[AjouterDestination](@Region nvarchar(32), @Pays nvarchar(32), @Continent nvarchar(32), @DescriptionVoyage nvarchar(512)) AS
	BEGIN
	Insert into dbo.Destinations values (@Region, @Pays, @Continent, @DescriptionVoyage);
	END
GO*/

--execute [dbo].[AjouterDestination] 'titi','toto','Chine','Lorem ipsum etc'

------------------------
--DESTINATION

/*DROP PROCEDURE [dbo].[AjouterVoyage]
GO

CREATE PROCEDURE [dbo].[AjouterVoyage](@DestinationID int, @DateAller date, @DateRetour date, @NombreDePlaces tinyint, @Prix float, @AgenceID int) AS
	BEGIN
	if @NombreDePlaces < 9
		Insert into dbo.Voyages values (@DestinationID, @DateAller, @DateRetour, @NombreDePlaces, @Prix, @AgenceID);
	END
GO*/

--execute [dbo].[AjouterVoyage] 9, '2019-01-02','2020-01-02', 3, 655, 1
------------------------

--CLIENT


--drop procedure DeleteClient	
/*
CREATE PROCEDURE DeleteClient
(
@ClientID int
)
AS 
	BEGIN
        DELETE FROM Clients
        Where ClientID = @ClientID
    END
*/

--execute DeleteClient 116
------------------------
--SELECT

select * from dbo.Destinations
select * from Voyages;
select * from Clients;
select * from Dossiers;

-------------------------


