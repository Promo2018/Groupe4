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

	WHILE @ID <= 300
		
		BEGIN
		
		SET @Prix = (select Prix from Voyages V, Dossiers D where D.VoyageID=V.ID and D.ID=@ID);
		
		IF (select A.Cout from Assurances A, Dossiers D, JointAssurDossier J where A.ID=J.AssuranceID and D.ID=J.DossierID and D.ID=@ID) IS NOT NULL 

		SET @Assurance = (select A.Cout from Assurances A, Dossiers D, JointAssurDossier J where A.ID=J.AssuranceID and D.ID=J.DossierID and D.ID=@ID);

		ELSE SET @Assurance = 0;

		--IF (select DateDeNaissance from Clients) > 2007 { DECLARE @Reduction = @Prix - (@Prix*0.6)}		

		update Dossiers SET PrixTotal = (@Prix + @Assurance) WHERE Dossiers.ID=@ID -- - @Reduction)		-- UPDATE into a new table	(...update XXX set PrixVoyage = @PrixVoyage...)
			

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