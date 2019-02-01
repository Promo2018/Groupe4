use BoVoyages
go


DROP PROCEDURE CalculPrixVoyage
go

CREATE PROCEDURE CalculPrixVoyage as
	Begin

	DECLARE @ID int = 1;
	DECLARE @Prix int = 0;
	DECLARE @Assurance int = 0;
	DECLARE @PrixVoyage int = 0;
	DECLARE @NombreVoyageurs int =0;
	DECLARE @VoyageursRemise int = 0;
	DECLARE @PrixAvecRemise int = 0;

	WHILE @ID <= 300
		
		BEGIN

		SET @NombreVoyageurs = (select distinct count(*) from Clients C, Dossiers D where D.ID = 82 AND C.DossierID = D.ID);

		SET @Prix = (select Prix from Voyages V, Dossiers D where D.VoyageID=V.ID and D.ID=@ID);
		
		IF (select A.Cout from Assurances A, Dossiers D, JointAssurDossier J where A.ID=J.AssuranceID and D.ID=J.DossierID and D.ID=@ID) IS NOT NULL 

		SET @Assurance = (select A.Cout from Assurances A, Dossiers D, JointAssurDossier J where A.ID=J.AssuranceID and D.ID=J.DossierID and D.ID=@ID);

		ELSE SET @Assurance = 0;

		SET @VoyageursRemise = (select distinct count(*) from Clients C, Dossiers D where D.ID = 82 AND C.DossierID = D.ID and (select datediff(year, DateDeNaissance, '01/02/2019')) < 12) 
		SET @PrixAvecRemise = @Prix*0.6;
		
		update Dossiers SET PrixTotal = (@Prix + @Assurance)*@NombreVoyageurs + @PrixAvecRemise*@VoyageursRemise WHERE Dossiers.ID=@ID 
			

		SET @ID = @ID + 1;
		End;
	End;
Go

execute CalculPrixVoyage

select * from Dossiers



--select max(ID) from Dossiers



/*
select * from AgencesVoyages
select * from Clients
select * from Dossiers
select * from Voyages
select * from Assurances
select * from JointAssurDossier
*/

/*
update Clients SET DateDeNaissance = '28/10/1936' where  ID=112;
select * from Clients
*/