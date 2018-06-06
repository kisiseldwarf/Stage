using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Etudiant
    {
        //Classe d'un étudiant
        string nomEtudiant;
        List<Examen> listExam;
        float moyenneHaute;
        float moyenneBasse;

        public Etudiant()
        {
            NomEtudiant = null;
            listExam = new List<Examen>();
        }

        public string NomEtudiant { get => nomEtudiant; set => nomEtudiant = value; }

        public float moyenneBorneH()
        {
            float addBorneH = 0;
            int addCoefH = 0;
            foreach (var exam in listExam)
            {
                addBorneH += exam.NoteBorneH * exam.Coef;
                addCoefH += exam.Coef;
            }
            return addBorneH / addCoefH;
        }
        public float moyenneBorneB()
        {
            float addBorneB = 0;
            int addCoefB = 0;
            foreach (var exam in listExam)
            {
                addBorneB += exam.NoteBorneB * exam.Coef;
                addCoefB += exam.Coef;
            }
            return addBorneB / addCoefB;
        }

        public List<Examen> ListExam { get => listExam; set => listExam = value; }

        public void setTheNumbers(Profil profil)
        {
            foreach (var examen in ListExam)
            {
                examen.setNumber(profil);
            }
        } //Lettre -> Notes
    }
}
