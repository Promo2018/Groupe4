PRESENTATION

BoVoyage est une application intranet qui permet aux commerciaux de se connecter avec leurs identifiants (cf commercial.txt) et d'afficher ou modifier la liste des voyages et des clients.

------------------------------------------------------------------------------

GUIDE D'UTILISATION

Pour vous connecter, veuillez saisir votre identifiant et votre mot de passe.

ID par d�faut : Italus.Dylan
Mot de passe par d�faut : 458

Les principales fonctionnalit�s sont scind�es en six menus.

Dans le menu dossiers:
- Lister tous les dossiers
- Rechercher un dossier (selon un ID)
- Ajouter un dossier 
- Changer l'�tat d'un dossier 
- Supprimer un dossier
- Recalculer le prix de tous les voyages (� lancer apr�s ajout de nouveaux dossiers)

Dans le menu voyages :
- Liste de voyages disponibles
- Ajouter les voyages
- Modifier un voyage (selon un crit�re au choix)
- Supprimer un voyage (n�cessite de supprimer les dossiers qui y font r�f�rence)

Dans le menu clients :
- Lister tous les clients
- Rechercher un client (selon un ID)
- Ajouter un client 
- Modifier un client (selon un crit�re au choix)
- Supprimer un client (n�cessite de supprimer leurs dossiers)

Dans le menu assurances:
- Lister toutes les assurances
- Rechercher une assurance (selon un ID)
- Ajouter une assurance
- Modifier une assurance (selon un crit�re au choix)

Dans le menu agences:
- Lister toutes les agences
- Rechercher une agences (selon un ID)
- Ajouter une agence
- Modifier une agence (selon un crit�re au choix)

Dans le menu destinations
- Lister toutes les destinations
- Rechercher une destination (selon un ID)
- Ajouter une destination
- Modifier une destination (selon un crit�re au choix)

Les fichiers contenant les informations sont dans le dossier doc.

Principaux fichiers texte :
- commercial.txt = contient les logins

------------------------------------------------------------------------------

STRUCTURE

Le Main (Program.cs) v�rifie la connexion via Gestion Login. Si la connexion est valid�e, il appelle ensuite MenuCommercial. Selon l'option choisie, Menucommercial appelle MenuClient ou MenuVoyage.
Chaque menu appelle son propre gestionnaire. C'est via ces controlleurs puis via la classe AccesBDD que seront manipul�s les �l�ments de la base de donn�es.

------------------------------------------------------------------------------
Contraintes sur les diff�rentes tables :

Table CLIENTS 
- Seul le champ Telephone peut �tre vide
- DossierID doit faire r�f�rence � un dossier existant
- Le champs date doit �tre de format DD/MM/YYYY (contrainte non encore impl�ment�e)

Table DOSSIERS :
- VoyageID et ClientID doivent faire r�f�rence � un voyage et � un client existants
- Etat doit �tre compris de 0 � 3 (0 = en attente, 1 = en cours, 2 = refus�, 3 = accept�)
- Seul le champ prix total peut �tre vide, il est calcul� � part via une proc�dure

Table VOYAGES :
- DestinationID et AgenceID doivent faire r�f�rence � une destination et � une agence existantes
- Le nombre de places doit �tre inf�rieur � 10
- Les champs date sont de format DD/MM/YYYY
- Aucun champ ne doit �tre vide

Table DESTINATIONS :
- Aucun champ ne peut �tre vide

Table ASSURANCES :
- Seul le champ type peut �tre vide

Table AgencesVoyages :
- Aucun champ ne peut �tre vide