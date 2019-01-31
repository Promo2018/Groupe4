USE [BoVoyages]

------------------------
--DOSSIER

/*Create procedure CalculPrixDossier as
	Begin
	DECLARE @DossierID int = 1;
	WHILE @DossierID <= 300
		Begin
		DECLARE @NombreVoyageurs int = (select distinct count(*) from Client C, Dossier D where D.DossierID = @DossierID AND C.DossierID = D.DossierID);
		DECLARE @Prix int = (select Prix from Voyage V, Dossier D where D.DossierID=@DossierID AND D.VoyageID=V.VoyageID);
		update Dossier set PrixTotal = @Prix*@NombreVoyageurs where DossierID=@DossierID;
		SET @DossierID = @DossierID + 1;
		End;
	End;
Go*/

------------------------
--DESTINATION

/*DROP PROCEDURE [dbo].[AjouterDestination]
GO
CREATE PROCEDURE [dbo].[AjouterDestination](@Region nvarchar(32), @Pays nvarchar(32), @Continent nvarchar(32), @DescriptionVoyage nvarchar(512)) AS
	BEGIN
	Insert into dbo.Destination values (@Region, @Pays, @Continent, @DescriptionVoyage);
	END
GO*/

------------------------
--DESTINATION

/*DROP PROCEDURE [dbo].[AjouterVoyage]
GO

CREATE PROCEDURE [dbo].[AjouterVoyage](@DestinationID int, @DateAller date, @DateRetour date, @NombreDePlaces tinyint) AS
	BEGIN
	if @NombreDePlaces < 9
		Insert into dbo.Voyage values (@DestinationID, @DateAller, @DateRetour, @NombreDePlaces);
	END
GO*/

------------------------
--SELECT

select * from Destination
select * from Voyage;
select * from Client;
select * from Dossier;

-------------------------

--CLIENT

CREATE PROCEDURE DeleteClient
(
@ClientID int
)
AS 
        BEGIN
            DELETE FROM Client
            Where ClientID = @ClientID
        END

	--drop procedure DeleteClient	

		execute DeleteClient 116
