﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Controller;
using BoVoyages.Model;
using System.Data;

using System.IO;

namespace BoVoyages.View
{
    public class MenuDossier : Menu
    {
        private GestionDossier gestionDossier = new GestionDossier();
        public Menu previousMenu;
        private AccesBDD accesBDD = new AccesBDD();
        bool succes;

        private int id;

        //Il est possible d'ajouter, de supprimer ou de modifier les éléments des énumérations sans risque
        enum EtatDossierReservation : byte { EnAttente, EnCours, Refusee, Acceptee }
        enum RaisonAnnulationDossier : byte { client, placeInsufffisante }

        public MenuDossier(Menu previousMenu)
        {
            this.previousMenu = previousMenu;
            nombreOptions = 6;
        }

        public override void Afficher()
        {
            System.Console.WriteLine("\n\n*********************************************************************");
            System.Console.WriteLine("******   Menu Dossier   **********************************************");
            System.Console.WriteLine("BoVoyages : Sélectionnez une option dans la liste ci-dessous :");
            System.Console.WriteLine("BoVoyages :\t 1 - Lister tous les dossiers");
            System.Console.WriteLine("BoVoyages :\t 2 - Rechercher un dossier");
            System.Console.WriteLine("BoVoyages :\t 3 - Ajouter un dossier");
            System.Console.WriteLine("BoVoyages :\t 4 - Changer l'état d'un dossier");
            System.Console.WriteLine("BoVoyages :\t 5 - Supprimer un dossier");
            System.Console.WriteLine("BoVoyages :\t 6 - Recalculer le prix de tous les voyages");
            System.Console.WriteLine("BoVoyages :\t 0 - Quitter");
        }


        public override Menu Executer(int selection)
        {
            Menu menu = this;

            if (selection == 1)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Lister tous les dossiers \n");
                
                gestionDossier.ListerDossiers();
            }

            
            if (selection == 2)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Rechercher un dossier \n");
                Console.WriteLine("Entrez un ID de dossier");
                id = SaisirEtVerifierID();

                gestionDossier.ChercherDossier(id);
            }

            else if (selection == 3)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Ajouter un dossier");

                string[] nouveauDossier = SaisirNouvelleLigne(accesBDD.RecupererNomsColonnes("Dossiers"));

                Console.WriteLine(gestionDossier.AjouterDossier(nouveauDossier));
            }

            else if (selection == 4)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Modifier l'état d'un dossier");

                Console.WriteLine("Entrez un ID de dossier :");
                id = SaisirEtVerifierID();

                ListerEtatsDossier();

                Console.WriteLine("\nVeuillez saisir l'une de ces valeurs.");
                string etatString = SaisirEtatDossier(id);

                //Envoyer les données saisies et afficher la réponse renvoyée
                Console.WriteLine(gestionDossier.ModifierEtatDossier(etatString, id));
            }

            else if (selection == 5)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Supprimer un dossier");
                Console.WriteLine("Entrez un ID de dossier :");
                int id = SaisirEtVerifierID();
                gestionDossier.SupprimerDossier(id);
            }

            else if (selection == 6)
            {
                System.Console.WriteLine("BoVoyages >>>>>>>>> - Recalculer le prix de tous les voyages");
                int nombreLignes = gestionDossier.CalculerPrixTousVoyages();
                Console.WriteLine("Vous avez modifiée " + nombreLignes + " lignes");
            }

            else if (selection == 0)
            {
                menu = previousMenu;
            }

            return menu;
        }

        //Affiche tous les états possibles de dossier
        private void ListerEtatsDossier()
        {
            Console.WriteLine("\nLes valeurs possibles pour les états de réservation sont :");
            foreach (string EtatNom in Enum.GetNames(typeof(EtatDossierReservation)))
            {
                Console.WriteLine("{0} = {1:D}", EtatNom, Enum.Parse(typeof(EtatDossierReservation), EtatNom));
            }
        }

        //Affiche tous les états possibles d'annulation
        public void ListerRaisonsAnnulation()
        {
            Console.WriteLine("\nLes valeurs possibles pour les états de dossier sont :");
            foreach (string colorName in Enum.GetNames(typeof(RaisonAnnulationDossier)))
            {
                Console.WriteLine("{0} = {1:D}", colorName,
                                             Enum.Parse(typeof(RaisonAnnulationDossier), colorName));
            }
        }

        //Vérifie si le chiffre saisie fait partie de la liste des états possibles de dossier et s'il suit le chemin logique des états de dossiers
        private string SaisirEtatDossier(int id)
        {
            succes = false;
            string etatString = "";
            do
            {
                etatString = Console.ReadLine();
                EtatDossierReservation etatDossierReservation;

                if (Enum.TryParse(etatString, out etatDossierReservation))
                {
                    if (Enum.IsDefined(typeof(EtatDossierReservation), etatDossierReservation) | etatDossierReservation.ToString().Contains(","))
                    {
                        Console.WriteLine("Le statut de réservation du dossier " + id + " va être changé en : '{0}'.", etatDossierReservation.ToString());
                        if (etatDossierReservation == EtatDossierReservation.Refusee)
                        {
                            Console.WriteLine("Vous avez demandé à refuser un dossier.");
                            ListerRaisonsAnnulation();
                            Console.WriteLine("\nVeuillez saisir le motif d'annulation.");
                            SaisirRaisonAnnulation(id);
                        }
                        succes = true;
                    }
                    else
                    {
                        Console.WriteLine("{0} n'est pas une valeur de réservation. Rentrez une valeur de réservation.", etatString);
                    }
                }
                else
                {
                    Console.WriteLine("{0} n'est pas une valeur de réservation. Rentrez une valeur de réservation.", etatString);
                }
            } while (succes == false);
            return etatString;
        }

        //Vérifie si le chiffre saisi fait partie de la liste des raisons d'annulation
        private string SaisirRaisonAnnulation(int id)
        {
            succes = false;
            string raisonString = "";
            do
            {
                raisonString = Console.ReadLine();
                RaisonAnnulationDossier raisonAnnulationDossier;

                if (Enum.TryParse(raisonString, out raisonAnnulationDossier))
                {
                    if (Enum.IsDefined(typeof(RaisonAnnulationDossier), raisonAnnulationDossier) | raisonAnnulationDossier.ToString().Contains(","))
                    {
                        Console.WriteLine("La raison d'annulation du dossier " + id + " va être enregistrée en tant que : '{0}'.", raisonAnnulationDossier.ToString());
                        int enumInt = Convert.ToInt32(raisonAnnulationDossier);
                        gestionDossier.ModifierRaisonAnnulation(enumInt.ToString(), id);
                        succes = true;
                    }
                    else
                    {
                        Console.WriteLine("{0} n'est pas une raison d'annulation. Rentrez une valeur de raison d'annulation.", raisonString);
                    }
                }
                else
                {
                    Console.WriteLine("{0} n'est pas une raison d'annulation. Rentrez une valeur de raison d'annulation.", raisonString);
                }
            } while (succes == false);
            return raisonString;
        }

        //Surcharger la méthode d'ajout de ligne pour ignorer certaines colonnes et en remplir automatiquement d'autres
        public new static string[] SaisirNouvelleLigne(DataSet dataColumn)
        {
            List<string> listeSaisies = new List<string>();

            if (dataColumn.Tables["Colonnes"].Rows.Count > 0)
            {
                foreach (DataRow ligne in dataColumn.Tables["Colonnes"].Rows)
                {
                    for (int i = 0; i < ligne.ItemArray.Length; i++)
                    {
                        //Ne rien ajouter pour l'ID (auto increment)
                        if (ligne[i].ToString() == "ID")
                        {
                            listeSaisies.Add("");
                        }
                        //Ajouter une valeur nulle pour le prix total et la raison d'annulation
                        else if (ligne[i].ToString() == "PrixTotal" || ligne[i].ToString() == "RaisonAnnulation")
                        {
                            listeSaisies.Add("");
                        }
                        //Fixer l'état à "en attente"
                        else if (ligne[i].ToString() == "Etat")
                        {
                            listeSaisies.Add("0");
                        }
                        else
                        {
                            Console.Write(ligne[i] + " : ");
                            listeSaisies.Add(Console.ReadLine());
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Erreur, pas de colonne trouvée dans la table.");
            }
            return listeSaisies.ToArray();
        }
    }
}
