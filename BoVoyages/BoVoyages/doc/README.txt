PRESENTATION

BoVoyage est une application intranet qui permet aux commerciaux de se connecter avec leurs identifiants (cf commercial.txt) et d'afficher ou modifier la liste des voyages et des clients.

------------------------------------------------------------------------------

GUIDE D'UTILISATION

Pour vous connecter, veuillez saisir votre identifiant et votre mot de passe.

ID par défaut : Italus.Dylan
Mot de passe par défaut : 458

Les principales fonctionnalités sont scindées en deux menus.

Dans le menu voyages :
- Afficher les voyage
- Supprimer les voyages expirés (dont la date de départ est dépassée)
- Ajouter un voyage
- Enregistrer

Dans le menu clients :
- Afficher les clients
- Afficher une liste de clients (selon un critère au choix)
- Envoyer un questionnaire (non implémenté)
- Promouvoir des voyages (non implémenté)

Les fichiers contenant les informations sont dans le dossier doc.

Principaux fichiers :
- voyages.txt = contient les informations des voyages, peut être modifié
- client.txt = contient les informations des clients (avec titre des colonnes)
- commercial.txt = contient les logins

------------------------------------------------------------------------------

STRUCTURE

Le Main (Program.cs) vérifie la connexion via Gestion Login. Si la connexion est validée, il appelle ensuite MenuCommercial. Selon l'option choisie, Menucommercial appelle MenuClient ou MenuVoyage.
MenuVoyage appelle GestionVoyage et MenuClient appelle GestionClient. C'est via ces controlleurs que seront manipulés les éléments de la base de données.
Cette base de donnée est constituée de tableaux construits par les classes du package Model à partir de fichiers .txt.