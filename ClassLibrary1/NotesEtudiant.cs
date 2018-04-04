using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class NotesEtudiant
    {
        string nomEtudiant;
        List<string> listeNotesLettre;
        List<float> listeNotesChiffre;
        float moyenne;

        public NotesEtudiant()
        {
            NomEtudiant = null;
            listeNotesLettre = new List<string>();
            listeNotesChiffre = new List<float>();
        }

        public string NomEtudiant { get => nomEtudiant; set => nomEtudiant = value; }
        public List<string> ListeNotesLettre { get => listeNotesLettre; set => listeNotesLettre = value; }
        public List<float> ListeNotesChiffre { get => listeNotesChiffre; set => listeNotesChiffre = value; }
        public float Moyenne {
            get
            {
                if (listeNotesChiffre.Count > 0)
                    return listeNotesChiffre.Average();
                else
                    throw new Exception("ListeNoteChiffre est vide");
            }
        }
    }
}
