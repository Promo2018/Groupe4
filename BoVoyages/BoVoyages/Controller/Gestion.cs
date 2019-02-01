using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BoVoyages.View;
using BoVoyages.Model;

namespace BoVoyages.Controller
{
    public  abstract class Gestion
    {
        //Permet de lister les colonnes avant de lister une table
        protected static void ListerColonnes(AccesBDD accesBDD, string nomDeTable)
        {
            DataSet dataset = accesBDD.RecupererNomsColonnes(nomDeTable);

            if (dataset != null)
            {
                Menu.ImpressionColonnes(dataset);
            }
        }
    }


}
