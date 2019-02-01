USE [BoVoyages]
GO

--DROP PROCEDURE ListerColonnes;
--GO

/*Create procedure ListerColonnes @NomTable nvarchar(32) AS 
	SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @NomTable;
Go*/

EXEC dbo.ListerColonnes @nomTable = 'Dossiers'

--------------------------------
--SELECT

select * from Dossiers;
--select * from JointAssurDossier;
select * from Assurances;
select * from Voyages;
select * from AgencesVoyages;
select * from Destinations;
select * from Clients;