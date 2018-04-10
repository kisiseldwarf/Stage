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
        int chiffre; //La note chiffrée de l'examen

        int Coef = 1; //Le coef de l'examen
        int id;

        public override string ToString()
        {
            return "Examen "+Id.ToString();
        }

        public Examen(Examen exam)
        {
            chiffre = exam.chiffre;
            lettre = exam.lettre;
            Coef = exam.Coef1;
            id = exam.id;
        }

        public Examen()
        {
        }

        public string Lettre { get => lettre; set => lettre = value; }
        public int Chiffre { get => chiffre; set => chiffre = value; }
        public int Coef1 { get => Coef; set => Coef = value; }
        public int Id { get => id; set => id = value; }
    }
}
