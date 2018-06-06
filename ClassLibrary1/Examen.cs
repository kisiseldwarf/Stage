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
        float noteBorneH; //La note chiffrée de l'examen
        float noteBorneB; //La note chiffrée de l'examen

        int coef = 1; //Le coef de l'examen, à 1 au départ
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
            NoteBorneH = exam.NoteBorneH;
            NoteBorneB = exam.NoteBorneB;
            lettre = exam.lettre;
            coef = exam.Coef;
            id = exam.id;
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Examen(string letter, Profil profile)
        {
            lettre = letter;
            setNumber(profile);
            id = 0;
        }
        public Examen()
        {
            lettre = "";
            id = 0;
            NoteBorneB = 0;
            NoteBorneH = 0;
        }

        public void setNumber(Profil profile)
        {
            bool notFound = true;
            if(profile == null)
            {
                throw new Exception("profile can't be null. Please put a profile.");
            }
            foreach (var rule in profile.RulesList)
            {
                if(rule.Lettre == lettre)
                {
                    NoteBorneB = rule.BorneB; 
                    NoteBorneH = rule.BorneH;
                }
                notFound = false;
            }
            if(notFound == true)
            {
                throw new Exception("profile doesn't match with this letter.");
            }
        }

        public string Lettre { get => lettre; set => lettre = value; }
        public int Coef { get => coef; set => coef = value; }
        public int Id { get => id; set => id = value; }
        public float NoteBorneH { get => noteBorneH; set => noteBorneH = value; }
        public float NoteBorneB { get => noteBorneB; set => noteBorneB = value; }
    }
}
