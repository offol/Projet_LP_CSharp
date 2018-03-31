using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLPExempleConsole
{
    public class MonObjet
    {
        public string nom;

        public string adresse;

        public string telephone;

        public double nombre;

        public MonObjet(string Nom, string Adresse, string Telephone, double Nombre)
        {
            this.nom = Nom;
            this.adresse = Adresse;
            this.telephone = Telephone;
            this.nombre = Nombre;
        }
    }
}
