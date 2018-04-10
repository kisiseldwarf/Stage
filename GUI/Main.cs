using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.IO;
using ExcelDataReader;

namespace GUI
{
    public partial class Main : Form
    {
        public List<Etudiant> list; //Liste d'étudiants
        public List<Profil> listeProfils;
        public Main()
        {
            InitializeComponent();
            listeProfils = new List<Profil>();
            button3.Enabled = false;
            charger();
            refreshSelect(null, null);
            if (listeProfils.Count > 0)
                selectProfil.SelectedIndex = 0;
            refreshPreview(null,null);
        }

        private void button1_Click(object sender, EventArgs e) //Source changed
        {
            if (textBox1.Text.EndsWith("csv"))
            {
                try
                {
                    list = ReadCSV(textBox1.Text);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Le fichier n'est pas accessible, erreur : " + ex.Message,"Erreur source");
                    list = null;
                }
            }
            else
            {
                try
                {
                    list = ReadExcel(textBox1.Text);
                }
                catch(IOException ex)
                {
                    MessageBox.Show("Le fichier n'est pas accessible, erreur : " + ex.Message, "Erreur source");
                    list = null;
                }
            }
            refreshPreview(null, null);
        }

        public List<Etudiant> ReadCSV(string path)
        {
            List<Etudiant> res = new List<Etudiant>();
            try
            {
                StreamReader tr = new StreamReader(path);
                while (!tr.EndOfStream)
                {
                    string line = tr.ReadLine(); //UN étudiant
                    string[] values = line.Split(';'); //UNE série d'examens (ici en lettre)
                    Etudiant ne = new Etudiant();
                    int index = 0;
                    foreach (var item in values) //On parcourt la ligne de l'étudiant
                    {
                        Examen ex = new Examen();
                        if (index == 0)
                            ne.NomEtudiant = item; //La première donnée est toujours le nom de l'étudiant
                        else
                        {
                            //NEW
                            ex.Lettre = item;
                            ex.Id = index;
                            ne.ListExam.Add(ex);
                            //OLD
                            //ne.ListeNotesLettre.Add(item);
                        }
                        index++; //Représente la colonne sur laquelle on se situe
                    }
                    res.Add(ne);
                }
                tr.Close();
                return res;
            }
            catch (IOException)
            {
                throw new IOException("Fichier inaccessible");
            }
        } //Lire CSV

        public List<Etudiant> ReadExcel(string path)
        {
            try
            {
                var stream = File.Open(path, FileMode.Open, FileAccess.Read);
                var excelReader = ExcelReaderFactory.CreateReader(stream);
                List<Etudiant> res = new List<Etudiant>();
                while (excelReader.Read())
                {
                    Etudiant ne = new Etudiant();
                    for (int i = 0; i < excelReader.FieldCount; i++)
                    {
                        if (i == 0)
                            ne.NomEtudiant = excelReader.GetString(i);
                        else
                        {
                            //NEW
                            Examen ex = new Examen();
                            ex.Lettre = excelReader.GetString(i);
                            ex.Id = i;
                            ne.ListExam.Add(ex);
                        }
                    }
                    res.Add(ne);
                }
                excelReader.Close();
                return res;
            }
            catch (System.IO.IOException)
            {
                throw new IOException("Fichier inaccessible");
            }
        } //Lire XLSX / XL..

        private void button2_Click(object sender, EventArgs e) //Browse button
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Importer un fichier source";
            dialog.Filter = "CSV|*.csv|Fichier Excel (.xlsx)|*.xlsx";
            DialogResult res;
            res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                textBox1.Text = dialog.FileName.Replace("/","//");
        }

        private void button3_Click(object sender, EventArgs e) //Export CSV button
        {
            if(textBox1.Text != "")
            {
                SaveFileDialog dialog = new SaveFileDialog();
                DialogResult res;
                dialog.Title = "Exporter en CSV";
                dialog.Filter = "CSV|*.csv";
                res = dialog.ShowDialog();
                if (res == DialogResult.OK)
                    exportCSV(list, dialog.FileName);
            }
            else
            {
                MessageBox.Show(this, "Veuillez selectionner une source", "Erreur");
            }
        }

        public void exportCSV(List<Etudiant> lne, string path)//
        {
            string[] res = new string[lne.Count()];
            for (int i = 0; i < lne.Count(); i++) //On parcours tous les étudiants
            {
                res[i] += lne[i].NomEtudiant + ";"; //Le nom en premier (toujours)
                //NEW
                foreach (var exam in lne[i].ListExam)
                {
                    res[i] += exam.Chiffre + ";";
                }
                //OLD
                /*foreach (var item in lne[i].ListeNotesChiffre)
                {
                    res[i] += item + ";";
                }*/
                res[i] += lne[i].Moyenne;
            }
            File.WriteAllLines(path, res);
        } //Enregistrer dans un fichier .csv

        private void button4_Click(object sender, EventArgs e) //Create Profil Button
        {
            CreateProfil fr = new CreateProfil(this);
            fr.Show(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void refreshSelect(object sender, EventArgs e) //Affichage de la selection des profils
        {
            selectProfil.Items.Clear();
            selectProfil.Items.AddRange(listeProfils.ToArray());
        }

        public void refreshPreview(object sender, EventArgs e)//Affichage des deux previews(profil et fichier)
        {
            profilPreview.Clear(); //Preview du profil
            setBaseStyle(profilPreview);
            if(selectProfil.SelectedItem != null)
            {
                Profil selectedProfil = (Profil)selectProfil.SelectedItem;
                string res = "PROFIL : " + selectedProfil.Name + "\n";
                res += "Regles : " + selectedProfil.RulesList.Count() + "\n";
                foreach (var item in selectedProfil.RulesList)
                {
                    res += item.Lettre + " => " + item.Chiffre + "\n";
                }
                profilPreview.Text = res;
                modifyProfilBut.Enabled = true;
                removeProfilBut.Enabled = true;
            }
            else
            {
                modifyProfilBut.Enabled = false;
                removeProfilBut.Enabled = false;
            }

            int startSelect = 0;
            bool errorFlag = false;
            if (list != null && selectProfil.SelectedItem != null)
            {
                //Preview du fichier
                richTextBox1.Clear();
                setBaseStyle(richTextBox1);

                foreach (var etud in list)
                {

                    //OLD
                    //item.ListeNotesChiffre.Clear(); //Rafraichissement des données
                    try
                    {
                        etud.setTheNumbers((Profil)selectProfil.SelectedItem);

                    }
                    catch(Exception) // Si une lettre d'un examen n'a pas trouvé chiffre correspondant
                    {
                        errorFlag = true;
                    }
                }

                //Ecriture des données
                ////Ecriture du bloc BEFORE
                richTextBox1.Text += "===BEFORE===\n";

                foreach (var etud in list)
                {
                    richTextBox1.Text += etud.NomEtudiant + " => ";
                    for (int i = 0; i < etud.ListExam.Count; i++)
                    {
                        if (i != etud.ListExam.Count - 1)
                        {
                            //OLD
                            //richTextBox1.Text += etud.ListeNotesLettre[i] + ", ";
                            //NEW
                            richTextBox1.Text += etud.ListExam[i].Lettre + ", ";
                        }
                        else
                        {
                            //OLD
                            //richTextBox1.Text += etud.ListeNotesLettre[i];
                            //NEW
                            richTextBox1.Text += etud.ListExam[i].Lettre;
                        }
                    }
                    richTextBox1.Text += "\n";
                }

                richTextBox1.Text += "===AFTER===\n";
                int startIndex;
                string moyenne;
                foreach (var etud in list)
                {
                    richTextBox1.Text += etud.NomEtudiant + " => ";
                    for (int i = 0; i < etud.ListExam.Count; i++)
                    {
                        richTextBox1.Text += etud.ListExam[i].Chiffre + " , ";
                    }
                    try
                    {
                        startIndex = richTextBox1.Text.Length;
                        moyenne = "Moyenne : " + etud.Moyenne + "\n";
                        richTextBox1.Text += moyenne;
                    }
                    catch(Exception ex)
                    {
                        errorFlag = true;
                    }
                }

                //Si y a eu une erreur, on change le texte.
                if(errorFlag == true)
                {
                    richTextBox1.Clear();
                    richTextBox1.Text += "===BEFORE===\n";
                    foreach (var etud in list)
                    {
                        richTextBox1.Text += etud.NomEtudiant + " => ";
                        for (int i = 0; i < etud.ListExam.Count; i++)
                        {
                            if (i != etud.ListExam.Count - 1)
                                richTextBox1.Text += etud.ListExam[i].Lettre + " , ";
                            else
                                richTextBox1.Text += etud.ListExam[i].Lettre;
                        }
                        richTextBox1.Text += "\n";
                    }
                    richTextBox1.Text += "\n Ce fichier n'est pas adapté aux regles du profil";
                    button1.Enabled = false; // Si fichier non adapté, alors modifier la preview n'est pas accessible.
                    button3.Enabled = false; //On ne peux pas l'exporter
                }
                else
                {
                    button1.Enabled = true; //Si aucune erreur sur le fichier, on peut modifier
                    button3.Enabled = true; //On peut aussi l'exporter
                }
            }
            else
            {
                richTextBox1.Clear();
                button1.Enabled = false; // Si aucun fichier, alors modifier la preview n'est pas accessible.
                button3.Enabled = false; //Idem
            }

            setFilePreviewColors();
        }

        private void save()//Pour sauvegarder un profil
        {
            string buffer ="";
            foreach (var profil in listeProfils)
            {
                buffer += profil.Name;
                buffer += ";";
                foreach (var rule in profil.RulesList)
                {
                    buffer += rule.Lettre;
                    buffer += ":";
                    buffer += rule.Chiffre;
                    buffer += ";";
                }
                buffer += "\n";
            }
            System.IO.File.WriteAllLines(@"profils.txt", buffer.Split('\n'));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)//Evenement quand le programme est fermé
        {
            save();
        }

        private void charger()//Pour charger les profils
        {
            try
            {
                StreamReader tr = new StreamReader(@"profils.txt");
                while (!tr.EndOfStream)
                {
                    string line = tr.ReadLine();
                    string[] values = line.Split(';');
                    if (values[0] != "")
                    {
                        List<Rules> bufferListRules = new List<Rules>();
                        Profil buffer = new Profil(values[0], bufferListRules);
                        for (int i = 1; i < values.Length - 1; i++)
                        {
                            string[] rules = values[i].Split(':');
                            Rules bufferRules = new Rules(Int32.Parse(rules[1]), rules[0]);
                            buffer.RulesList.Add(bufferRules);
                        }
                        listeProfils.Add(buffer);
                    }
                }
                tr.Close();
            }
            catch(Exception) //si on trouve pas le fichier
            {
                MessageBox.Show("Aucun fichier de profil n'a été trouvé", "Information"); //On en informe l'utilisateur
            }            
        }

        private void removeProfilBut_Click(object sender, EventArgs e)//Supprimer un profil
        {
            listeProfils.Remove((Profil)selectProfil.SelectedItem);
            refreshSelect(null,null);
            if (listeProfils.Count != 0)
                selectProfil.SelectedIndex = 0;
            refreshPreview(null,null);
        }

        private void modifyProfilBut_Click(object sender, EventArgs e)
        {
            ModifyProfil fr = new ModifyProfil((Profil)selectProfil.SelectedItem,this);
            fr.Show(this);
        }

        private void setBaseStyle(RichTextBox rb) //Style de base pour les richTextBox du projet
        {
            rb.Font = new Font("Arial", 9, FontStyle.Regular);
        }
        private void setFilePreviewColors() //Couleurs personnalisées pour la file preview
        {
            if(richTextBox1.Text.Contains("===BEFORE==="))
            {
                richTextBox1.Select(richTextBox1.Text.IndexOf("===BEFORE==="), 12);
                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.SelectionFont = new Font("Arial", 10, FontStyle.Bold);
            }
            if (richTextBox1.Text.Contains("===AFTER==="))
            {
                richTextBox1.Select(richTextBox1.Text.IndexOf("===AFTER==="), 11);
                richTextBox1.SelectionColor = Color.Green;
                richTextBox1.SelectionFont = new Font("Arial", 10, FontStyle.Bold);
            }
            if (richTextBox1.Text.Contains("Ce fichier n'est pas adapté aux regles du profil"))
            {
                richTextBox1.Select(richTextBox1.Text.IndexOf("Ce fichier n'est pas adapté aux regles du profil"), 48);
                richTextBox1.SelectionColor = Color.DarkRed;
                richTextBox1.SelectionFont = new Font("Arial", 10, FontStyle.Bold);
            }

        }
        private void setProfilPreviewColor()//Couleurs perso. pour la profil preview
        {
            if(profilPreview.Text.Contains("PROFIL :"))
            {
                profilPreview.Select(profilPreview.Text.IndexOf("PROFIL :"), 12);
                profilPreview.SelectionColor = Color.Red;
                profilPreview.SelectionFont = new Font("Arial", 10, FontStyle.Bold);
            }
        }

        private void button1_Click_1(object sender, EventArgs e) //Event button modifier la filepreview
        {
            ModificationPreview fr = new ModificationPreview(list,this);
            fr.Show(this);
        }
    }


}
