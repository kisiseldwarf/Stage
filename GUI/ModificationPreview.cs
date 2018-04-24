using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ModificationPreview : Form
    {
        private List<Etudiant> etudiants;
        private List<Examen> examens;
        private Main parent;
        private List<Control> controls;
        bool hasLoadedData = false; //Pour éviter des bugs
        public ModificationPreview(List<Etudiant> etudiants, Main parent)
        {
            InitializeComponent();
            this.etudiants = etudiants;
            this.parent = parent;
            examens = new List<Examen>();
            controls = new List<Control>();
            controls.Add(EtudiantTextBox1);
            controls.Add(NoteTextBox1);
            panel1.AutoScroll = true;

            //Fonctions mettant la form dans un état cohérent
            loadExam(); 
            initSelect();
            initPrint();
            //Affichage des données tampons
            printData();

            parent.Enabled = false;
        }
        
        private void initSelect()//Met le select dans un état cohérent
        {
            selectExamen.Items.AddRange(examens.ToArray());
            selectExamen.SelectedIndex = 0;
        }

        public void loadExam()//Crée la mémoire tampon contenant les examens
        {
            //On prend un étudiant au pif (ils ont tous le même nombre d'examens)
            foreach(var exam in etudiants[0].ListExam)
            {
                Examen ex = new Examen(exam); //ON FAIT CELA POUR EVITER DE CREER UNE REFERENCE (on crée une mémoire tampon plutôt)
                examens.Add(ex);
            }
        }

        private void printData()//Affichage des données tampons
        {
            Examen ex = (Examen) selectExamen.SelectedItem;
            coefficientExam.Value = ex.Coef;

            int controlID = 0;
            Control[] res;

            res = Controls.Find("EtudiantTextBox1", true);
            res[0].Text = etudiants[0].NomEtudiant;
            res = Controls.Find("NoteTextBox1", true);
            res[0].Text = etudiants[0].ListExam.Find(x => x.Id == ex.Id).Chiffre.ToString();
            for (int i = 1; i < etudiants.Count; i++)
            {
                controlID = i + 1;
                res = Controls.Find("EtudiantTextBox" + controlID, true);
                res[0].Text = etudiants[i].NomEtudiant;
                res = Controls.Find("NoteTextBox" + controlID, true);
                res[0].Text = etudiants[i].ListExam.Find(x => x.Id == ex.Id).Chiffre.ToString();
            }
        }

        private void initPrint() //Prépare le terrain pour print (charge les différents controls au runtime)
        {
            for (int i = 1; i < etudiants.Count; i++)
            {
                createRulesControls();
            }
            hasLoadedData = true;
        }
        private int createRulesControls() //Crée une paire de controls en dessous de la dernière paire crée et les met dans un état cohérent à la form
        {
            int previous = controls.Count - 1; //Il en faut toujours au moins un
            TextBox etud = new TextBox();
            NumericUpDown note = new NumericUpDown();

            //Localisation des deux controllers en fonction de la paire précédente
            Point etudLoc = etud.Location;
            Point noteLoc = note.Location;
            Point previousNoteLoc = controls[previous].Location; //On reçoit toujours la note
            etudLoc = previousNoteLoc;
            noteLoc = previousNoteLoc;
            etudLoc.Y += 40;
            etudLoc.X -= 162;
            noteLoc.Y += 40;
            etud.Location = etudLoc;
            note.Location = noteLoc;
            //Ajout de l'id des controllers (par paire, donc ils ont le même)
            int previousNumberName = Int32.Parse(controls[previous].Name.Substring(11));
            previousNumberName++;
            etud.Name = "EtudiantTextBox" + previousNumberName;
            note.Name = "NoteTextBox" + previousNumberName;
            //Ajout dans le panel (pour avoir la scrollbar)
            panel1.Controls.Add(etud);
            panel1.Controls.Add(note);
            //Ajout dans la liste de controls (pour un accés simplifié si on en a besoin)
            controls.Add(etud);
            controls.Add(note);
            //On les lie à l'evenement pour enregistrer dans la mémoire tampon
            etud.TextChanged += new EventHandler(etudNameChanged);
            note.Enabled = false;

            return previousNumberName;
        }

        private void selectExamen_SelectedIndexChanged(object sender, EventArgs e)//Event quand on change d'index pour selectExam
        {
            if(hasLoadedData == true) //Si on a bien chargé les données
                printData();
        }

        private void ModificationPreview_FormClosing(object sender, FormClosingEventArgs e)//Event quand on ferme la form
        {
            parent.Enabled = true;
            parent.refreshPreview(null,null);
        }

        private void etudNameChanged(object sender, EventArgs e) //Event pour enregistrer les modifications de noms et de notes dans la mémoire tampon
        {
            Control sen = (Control)sender;
            if (sen.Name.Contains("EtudiantTextBox")) //Si on a modifié le nom d'un étudiant
            {
                TextBox send = (TextBox)sen;
                int id = Int32.Parse(sen.Name.Substring(15)); //On prend l'id des controls (il est correspondant à l'étudiant modifié)
                etudiants[id - 1].NomEtudiant = sen.Text; //Et on change son nom
            }
            /*if (sen.Name.Contains("NoteTextBox")) //Si on a modifié la note d'un étudiant
            {
                NumericUpDown send = (NumericUpDown)sen;
                int id = Int32.Parse(sen.Name.Substring(11)); //On prend l'id des controls (il est correspondant à l'étudiant modifié)
                Examen exSelectionne = (Examen) selectExamen.SelectedItem;
                etudiants[id - 1].ListExam.Find(x => x.Id == exSelectionne.Id).Chiffre = Int32.Parse(sen.Text); //Et on modifie sa note à l'exam selectionné
            }*/ //NE MARCHE PAS A CAUSE DU SYSTEME DE PROFILS
        }

        private void button1_Click(object sender, EventArgs e) //Bouton valider event click 
        {
            saveData();
            Close();
        }

        private void saveData()//On enregistre les données modifiées
        {
            //Cela marche car les références dans étudiant sont les mêmes références que sur l'original, donc on modifie l'original directement en faisant cela
            //on change les coefs des examens sur tous les étudiants
            foreach (var etudiant in etudiants) //Liste des étudiants tampons
            {
                foreach (var examEtud in etudiant.ListExam) //liste des examens par étudiant
                {
                    foreach (var examen in examens) //Liste des examens tampon
                    {
                        if (examen.Id == examEtud.Id)
                            examEtud.Coef = examen.Coef;
                    }
                }
            }
            parent.list = etudiants; //On sauvegarde les étudiants avec :  leurs nom modifiés

        }

        private void coefficientExam_ValueChanged(object sender, EventArgs e)//Event quand on change le coefficient d'un examen
        {
            examens.Find(x => x == selectExamen.SelectedItem).Coef = (int)coefficientExam.Value;
            //On change le coefficient de l'exam selectionné
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
