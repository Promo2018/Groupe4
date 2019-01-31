PRESENTATION

BoVoyage est une application intranet qui permet aux commerciaux de se connecter avec leurs identifiants (cf commercial.txt) et d'afficher ou modifier la liste des voyages et des clients.

------------------------------------------------------------------------------

GUIDE D'UTILISATION

Pour vous connecter, veuillez saisir votre identifiant et votre mot de passe.

ID par d�faut : Italus.Dylan
Mot de passe par d�faut : 458

Les principales fonctionnalit�s sont scind�es en deux menus.

Dans le menu voyages :
- Afficher les voyage
- Supprimer les voyages expir�s (dont la date de d�part est d�pass�e)
- Ajouter un voyage
- Enregistrer

Dans le menu clients :
- Afficher les clients
- Afficher une liste de clients (selon un crit�re au choix)
- Envoyer un questionnaire (non impl�ment�)
- Promouvoir des voyages (non impl�ment�)

Les fichiers contenant les informations sont dans le dossier doc.

Principaux fichiers :
- voyages.txt = contient les informations des voyages, peut �tre modifi�
- client.txt = contient les informations des clients (avec titre des colonnes)
- commercial.txt = contient les logins

------------------------------------------------------------------------------

STRUCTURE

Le Main (Program.cs) v�rifie la connexion via Gestion Login. Si la connexion est valid�e, il appelle ensuite MenuCommercial. Selon l'option choisie, Menucommercial appelle MenuClient ou MenuVoyage.
MenuVoyage appelle GestionVoyage et MenuClient appelle GestionClient. C'est via ces controlleurs que seront manipul�s les �l�ments de la base de donn�es.
Cette base de donn�e est constitu�e de tableaux construits par les classes du package Model � partir de fichiers .txt.