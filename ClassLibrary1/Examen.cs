using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Examen
    {
        string lettre; //La lettre de l'examen
        float chiffre; //La note chiffrée de l'examen

        int coef = 1; //Le coef de l'examen
        int id; //L'id est unique à un examen. Il permet de faire correspondre deux examens identique chez plusieurs étudiants.

        public override string ToString()
        {
            return "Examen "+Id.ToString();
        }

        /// <summary>
        /// Constructeur par recopie
        /// </summary>
        /// <param name="exam">L'objet Examen à recopier</param>
        public Examen(Examen exam)
        {
            chiffre = exam.chiffre;
            lettre = exam.lettre;
            coef = exam.Coef;
            id = exam.id;
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Examen()
        {
            lettre = "";
            chiffre = 0;
            id = 0;
        }

        public string Lettre { get => lettre; set => lettre = value; }
        public float Chiffre { get => chiffre; set => chiffre = value; }
        public int Coef { get => coef; set => coef = value; }
        public int Id { get => id; set => id = value; }
    }
}
