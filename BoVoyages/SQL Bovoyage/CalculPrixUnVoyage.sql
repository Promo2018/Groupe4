use BoVoyages
go


DROP PROCEDURE CalculPrixVoyage
go

CREATE PROCEDURE CalculPrixUnVoyage @ID int as
	Begin

	DECLARE @Prix int = 0;
	DECLARE @Assurance int = 0;
	DECLARE @PrixVoyage int = 0;
	DECLARE @NombreVoyageurs int =0;
	DECLARE @VoyageursRemise int = 0;
	DECLARE @PrixAvecRemise int = 0;
	DECLARE @VoyageursSansRemise int = 0;

	DECLARE @PrixTOTAL int = 0;
	DECLARE @PrixTotalAvecRemise int = 0;
	DECLARE @PrixTotalSansRemise int = 0;

	SET @NombreVoyageurs = (select distinct count(*) from Clients C, Dossiers D where D.ID = @ID AND C.DossierID = D.ID);

	SET @Prix = (select Prix from Voyages V, Dossiers D where D.VoyageID=V.ID and D.ID=@ID);
		
	IF (select A.Cout from Assurances A, Dossiers D, JointAssurDossier J where A.ID=J.AssuranceID and D.ID=J.DossierID and D.ID=@ID) IS NOT NULL 
		SET @Assurance = (select A.Cout from Assurances A, Dossiers D, JointAssurDossier J where A.ID=J.AssuranceID and D.ID=J.DossierID and D.ID=@ID);

	ELSE SET @Assurance = 0;

	SET @VoyageursRemise = (select distinct count(*) from Clients C, Dossiers D where D.ID = @ID AND C.DossierID = D.ID and (select datediff(year, DateDeNaissance, '01/02/2019')) < 12);
	SET @VoyageursSansRemise = (select distinct count(*) from Clients C, Dossiers D where D.ID = @ID AND C.DossierID = D.ID and (select datediff(year, DateDeNaissance, '01/02/2019')) > 12);

	SET @PrixAvecRemise = @Prix*0.6;
		
	SET @PrixTotalAvecRemise = @VoyageursRemise*(@PrixAvecRemise+@Assurance);
	SET @PrixTotalSansRemise = @VoyageursSansRemise*(@Prix+@Assurance);

	update Dossiers SET PrixTOTAL = @PrixTotalAvecRemise+@PrixTotalSansRemise WHERE Dossiers.ID=@ID;

	End;
Go

execute CalculPrixUnVoyage 1



select VoyageID, Nom, Prenom, PrixTotal, Prix, Statut from Dossiers D, Clients C, Voyages V where ClientID=102 and C.ID = D.ClientID and V.ID=D.VoyageID; 
select * from Dossiers
select * from Clients
select * from Voyages
select * from Destinations
select Nom, Prenom, D.ID from Dossiers D, Clients C where ClientID=73 and C.ID = D.ClientID;


--select max(ID) from Dossiers



/*
select * from AgencesVoyages
select * from Clients
select * from Dossiers
select * from Voyages
select * from Assurances
select * from JointAssurDossier
*/