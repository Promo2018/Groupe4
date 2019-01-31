﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoVoyages.Model;

namespace BoVoyages.Controlleur
{
    //Récupère le tableau généré par Commercial puis vérifie ligne par ligne si les attributs entrés (login et mdp) correspondent à une des lignes du fichier

    class GestionLogin
    {
        public GestionLogin()
        {
        }

        //Méthode de vérification du login et du mot de passe

        public static bool Login(string login, string mdp)
        {
            bool loginOk = false;
            string[] listecommerciaux = Commercial.getCommerciaux();
            string[] commercial;

            //Vérification ligne par ligne
            foreach (string line in listecommerciaux)
            {
                commercial = line.Split(',');
                if (commercial[4] == login && commercial[5] == mdp)
                {
                    loginOk = true;
                }
            }
            return loginOk;
        }
    }
}