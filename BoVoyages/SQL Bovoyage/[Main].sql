use Bovoyages;

------------------------
--DESTINATION

--Traduire les pays

/*update Destination set Pays='Etats-Unis' where Pays='United States';
update Destination set Pays='Chine' where Pays='China';
update Destination set Pays='Japon' where Pays='Japan';
update Destination set Pays='Russie' where Pays='Russia';
update Destination set Pays='Pologne' where Pays='Poland';*/

--Mettre à jour les continents des destinations

/*update Destination set Continent='Asie' where Pays='Japon' or Pays='Chine' or Pays='Philippines';
update Destination set Continent='Europe' where Pays='Russie' or Pays='Pologne';
update Destination set Continent='Amérique' where Pays='Canada' or Pays='Etats-Unis';*/

--Mettre du Lorem Ipsum
--update Destination set DescriptionVoyage='Lorem ipsum dolor sit amet, consectetur adipiscing elit. In justo eros, efficitur a placerat eget, scelerisque quis mauris. Proin id ipsum et odio porta tempor. Mauris malesuada faucibus libero, vel finibus augue lacinia ut.' where DescriptionVoyage='';

--Delete
--DELETE FROM Destination WHERE DestinationID >50;

------------------------
--CLIENT

--Mettre à jour aléatoirement les FK par rapport à une PK
/*Begin
DECLARE @FK int = 1;
WHILE @FK <= (SELECT MAX(ClientID) FROM Client)
	Begin
	update Client set DossierID=(SELECT TOP 1 DossierID FROM Dossier ORDER BY NEWID()) where ClientID=@FK;
	SET @FK = @FK + 1;
	End;
End;*/

------------------------
--DOSSIER

--Remplir aléatoirement le champ carte bancaire
/*Begin
DECLARE @FK int = 1;
DECLARE @NumeroTemp bigInt;
WHILE @FK <= (SELECT MAX(DossierID) FROM Dossier)
	Begin
	SET @NumeroTemp = RAND()*1000000000000;
	SET @NumeroTemp = ROUND(@NumeroTemp, 0);
	update Dossier set CarteBancaire = @NumeroTemp where DossierID = @FK;
	SET @FK = @FK + 1;
	End;
End;*/

--Afficher les ID qui n'ont pas de correspondance
--select DossierID, VoyageID from Dossier where VoyageID NOT IN (SELECT VoyageID FROM Voyage);

------------------------
--VOYAGE

--Afficher les ID qui n'ont pas de correspondance
--select VoyageID, DestinationID from Voyage where DestinationID NOT IN (SELECT DestinationID FROM Destination);

------------------------
--REMPLISSAGE AUTO

--Mettre à jour aléatoirement les FK par rapport à une PK, changer noms de colonne
/*Begin
DECLARE @FK int = 1;
WHILE @FK <= (SELECT MAX(ID) FROM Voyages)
	Begin
	update Voyages set AgenceID=(SELECT TOP 1 ID FROM AgencesVoyages ORDER BY NEWID()) where ID=@FK;
	SET @FK = @FK + 1;
	End;
End;*/

------------------------
--ALTER

--Add column
--ALTER TABLE Dossier ADD CarteBancaire nvarchar(16);
--ALTER TABLE Dossier ADD RaisonAnnulation int;

--Alter Null or not null
--ALTER TABLE Destination alter column Continent nvarchar(16) NOT NULL;
--ALTER TABLE Dossier alter column CarteBancaire nvarchar(16) NOT NULL;

--Primary Keys
--ALTER TABLE Voyage ADD CONSTRAINT PK_Voyage_VoyageID PRIMARY Key clustered(VoyageID);

--Foreign Keys
--ALTER TABLE Voyage ADD CONSTRAINT FK_Voyage_DestinationID FOREIGN KEY (DestinationID) REFERENCES dbo.Destination (DestinationID);
--ALTER TABLE Dossier ADD CONSTRAINT FK_Dossier_VoyageID FOREIGN KEY (VoyageID) REFERENCES Voyage (VoyageID);
--ALTER TABLE Client ADD CONSTRAINT FK_Client_DossierID FOREIGN KEY (DossierID) REFERENCES Dossier (DossierID);

------------------------
--RENAME

/*EXEC sp_rename 'Assurance', 'Assurances'
EXEC sp_rename 'AgenceVoyage', 'AgencesVoyages'
EXEC sp_rename 'Client', 'Clients'
EXEC sp_rename 'Destination', 'Destinations'
EXEC sp_rename 'Dossier', 'Dossiers'
EXEC sp_rename 'Voyage', 'Voyages'*/

------------------------
--SELECT

select * from Dossiers;
select * from JointAssurDossier;
select * from Assurances;
select * from Voyages;
select * from AgencesVoyages;
select * from Destinations;
select * from Clients;