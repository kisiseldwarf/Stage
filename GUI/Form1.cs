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

namespace GUI
{
    public partial class Form1 : Form
    {
        public List<NotesEtudiant> list;
        public List<Profil> listeProfils;
        public Form1()
        {
            InitializeComponent();
            listeProfils = new List<Profil>();
            charger();
            refreshSelect(null, null);
            if (listeProfils.Count > 0)
                selectProfil.SelectedIndex = 0;
            refreshPreview(null,null);
        }

        private void button1_Click(object sender, EventArgs e) //Source changed
        {
            textBox1.Text = textBox1.Text.Replace("\\", "/");
            if (textBox1.Text.EndsWith("csv"))
                list = Functions.ReadCSV(textBox1.Text);
            else
                list = Functions.ReadExcel(textBox1.Text);

            refreshPreview(null, null);
        }

        private void button2_Click(object sender, EventArgs e) //Browse button
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Importer un fichier source";
            dialog.Filter = "CSV|*.csv|Fichier Excel (.xlsx)|*.xlsx";
            DialogResult res;
            res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                textBox1.Text = dialog.FileName;
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
                    Functions.exportCSV(list, dialog.FileName);
            }
            else
            {
                MessageBox.Show(this, "Veuillez selectionner une source", "Erreur");
            }
        }

        private void button4_Click(object sender, EventArgs e) //Create Profil Button
        {
            Form2 fr = new Form2(this);
            fr.Show(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) 
        {
        }

        public void refreshSelect(object sender, EventArgs e) //Appellée pour refresh la liste de profils
        {
            selectProfil.Items.Clear();
            selectProfil.Items.AddRange(listeProfils.ToArray());
        }

        public void refreshPreview(object sender, EventArgs e)//Pour refresh les différentes previews(profil et fichier)
        {
            profilPreview.Clear(); //Preview du profil
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


            bool errorFlag = false;
            if (list != null && selectProfil.SelectedItem != null)
            {
                richTextBox1.Clear(); //Preview du fichier

                foreach (var item in list)
                {
                    item.ListeNotesChiffre.Clear(); //Rafraichissement
                    Functions.setTheNumbers(item, (Profil)selectProfil.SelectedItem);
                }

                richTextBox1.Text += "===BEFORE===\n";
                foreach (var item in list)
                {
                    richTextBox1.Text += item.NomEtudiant + "\n";
                    foreach (var item2 in item.ListeNotesLettre)
                    {
                        richTextBox1.Text += item2 + " | ";
                    }
                    richTextBox1.Text += "\n";
                }
                richTextBox1.Text += "===AFTER===\n";
                foreach (var item in list)
                {
                    richTextBox1.Text += item.NomEtudiant + "\n";
                    foreach (var item2 in item.ListeNotesChiffre)
                    {
                        richTextBox1.Text += item2 + " | ";
                    }
                    try
                    {
                        richTextBox1.Text += item.Moyenne + "\n";
                    }
                    catch(Exception ex)
                    {
                        errorFlag = true;
                    }
                }



                if(errorFlag == true)
                {
                    richTextBox1.Clear();
                    richTextBox1.Text += "===BEFORE===\n";
                    foreach (var item in list)
                    {
                        richTextBox1.Text += item.NomEtudiant + "\n";
                        foreach (var item2 in item.ListeNotesLettre)
                        {
                            richTextBox1.Text += item2 + " | ";
                        }
                        richTextBox1.Text += "\n";
                    }
                    richTextBox1.Text += "\n Ce fichier n'est pas adapté aux regles du profil";
                }
            }
            else
            {
                richTextBox1.Clear();
            }
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
            System.IO.File.WriteAllLines(@"C:\Users\hadikk\profils.txt", buffer.Split('\n'));
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)//Evenement quand le programme est fermé
        {
            save();
        }

        private void charger()//Pour charger les profils
        {
            StreamReader tr = new StreamReader(@"C:\Users\hadikk\profils.txt");
            while(!tr.EndOfStream)
            {
                string line = tr.ReadLine();
                string[] values = line.Split(';');
                if(values[0] != "")
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
            Form3 fr = new Form3((Profil)selectProfil.SelectedItem,this);
            fr.Show(this);
        }
    }


}
