PRESENTATION

BoVoyage est une application intranet qui permet aux commerciaux de se connecter avec leurs identifiants (cf commercial.txt) et d'afficher ou modifier la liste des voyages et des clients.

------------------------------------------------------------------------------

GUIDE D'UTILISATION

Pour vous connecter, veuillez saisir votre identifiant et votre mot de passe.

ID par défaut : Italus.Dylan
Mot de passe par défaut : 458

Les principales fonctionnalités sont scindées en six menus.

Dans le menu dossiers:
- Lister tous les dossiers
- Rechercher un dossier (selon un ID)
- Ajouter un dossier 
- Changer l'état d'un dossier 
- Supprimer un dossier
- Recalculer le prix de tous les voyages (à lancer après ajout de nouveaux dossiers)

Dans le menu voyages :
- Liste de voyages disponibles
- Ajouter les voyages
- Modifier un voyage (selon un critère au choix)
- Supprimer un voyage (nécessite de supprimer les dossiers qui y font référence)

Dans le menu clients :
- Lister tous les clients
- Rechercher un client (selon un ID)
- Ajouter un client 
- Modifier un client (selon un critère au choix)
- Supprimer un client (nécessite de supprimer leurs dossiers)

Dans le menu assurances:
- Lister toutes les assurances
- Rechercher une assurance (selon un ID)
- Ajouter une assurance
- Modifier une assurance (selon un critère au choix)

Dans le menu agences:
- Lister toutes les agences
- Rechercher une agences (selon un ID)
- Ajouter une agence
- Modifier une agence (selon un critère au choix)

Dans le menu destinations
- Lister toutes les destinations
- Rechercher une destination (selon un ID)
- Ajouter une destination
- Modifier une destination (selon un critère au choix)

Les fichiers contenant les informations sont dans le dossier doc.

Principaux fichiers texte :
- commercial.txt = contient les logins

------------------------------------------------------------------------------

STRUCTURE

Le Main (Program.cs) vérifie la connexion via Gestion Login. Si la connexion est validée, il appelle ensuite MenuCommercial. Selon l'option choisie, Menucommercial appelle MenuClient ou MenuVoyage.
Chaque menu appelle son propre gestionnaire. C'est via ces controlleurs puis via la classe AccesBDD que seront manipulés les éléments de la base de données.

------------------------------------------------------------------------------
Contraintes sur les différentes tables :

Table CLIENTS 
- Seul le champ Telephone peut être vide
- DossierID doit faire référence à un dossier existant
- Le champs date doit être de format DD/MM/YYYY (contrainte non encore implémentée)

Table DOSSIERS :
- VoyageID et ClientID doivent faire référence à un voyage et à un client existants
- Etat doit être compris de 0 à 3 (0 = en attente, 1 = en cours, 2 = refusé, 3 = accepté)
- Seul le champ prix total peut être vide, il est calculé à part via une procédure

Table VOYAGES :
- DestinationID et AgenceID doivent faire référence à une destination et à une agence existantes
- Le nombre de places doit être inférieur à 10
- Les champs date sont de format DD/MM/YYYY
- Aucun champ ne doit être vide

Table DESTINATIONS :
- Aucun champ ne peut être vide

Table ASSURANCES :
- Seul le champ type peut être vide

Table AgencesVoyages :
- Aucun champ ne peut être vide