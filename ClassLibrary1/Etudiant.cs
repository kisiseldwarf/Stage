using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Etudiant
    {
        //Classe d'un étudiant
        string nomEtudiant;
        List<Examen> listExam;
        float moyenne;

        public Etudiant()
        {
            NomEtudiant = null;
            listExam = new List<Examen>();
        }

        public string NomEtudiant { get => nomEtudiant; set => nomEtudiant = value; }
        public float Moyenne {
            get
            {
                int buffer = 0;
                int nbItemBuffer=0;
                foreach (var exam in listExam)
                {
                    buffer += exam.Chiffre*exam.Coef1;
                    nbItemBuffer += exam.Coef1;
                }
                return buffer / nbItemBuffer;
            }
        }

        public List<Examen> ListExam { get => listExam; set => listExam = value; }

        public void setTheNumbers(Profil profil)
        {
            if (profil == null)
                throw new Exception("Profil est null");
            //NEW
            foreach (var exam in ListExam)
            {
                bool notFound = true;
                foreach (var rule in profil.RulesList)
                {
                    if (rule.Lettre == exam.Lettre)
                    {
                        exam.Chiffre = rule.Chiffre;
                        notFound = false;
                    }
                }
                if (notFound == true)
                {
                    throw new Exception();
                }
            }
            //OLD
            /*foreach (var letter in ListeNotesLettre)
            {
                bool notFound = true;
                foreach (var rule in profil.RulesList)
                {
                    if (rule.Lettre == letter)
                    {
                        ListeNotesChiffre.Add(rule.Chiffre);
                        notFound = false;
                    }
                }
                if (notFound == true)
                {
                    // TO DO : Mettre une exception ici
                }
            }*/
        } //Lettre -> Notes
    }
}
