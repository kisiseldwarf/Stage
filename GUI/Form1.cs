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

namespace GUI
{
    public partial class Form1 : Form
    {
        public List<NotesEtudiant> list;
        public List<Profil> listeProfils;
        public Form1()
        {
            InitializeComponent();
            listeProfils = new List<Profil>(); //A remplacer par le chargement des fichiers PROFILS
        }

        private void button1_Click(object sender, EventArgs e) //Import button
        {
            textBox1.Text = textBox1.Text.Replace("\\","/");
            if (textBox1.Text.EndsWith("csv"))
                list = Functions.ReadCSV(textBox1.Text);
            else
                list = Functions.ReadExcel(textBox1.Text);

            richTextBox1.Clear();

            foreach (var item in list)
            {
                Functions.setTheNumbers(item);
            }
            richTextBox1.Text += "===BEFORE===\n";
            foreach (var item in list)
            {
                richTextBox1.Text += item.NomEtudiant+"\n";
                foreach (var item2 in item.ListeNotesLettre)
                {
                    richTextBox1.Text += item2+" | ";
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
                richTextBox1.Text += item.Moyenne + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e) //Browse button
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult res;
            res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                textBox1.Text = dialog.FileName;
        }

        private void button3_Click(object sender, EventArgs e) //Export CSV button
        {
            SaveFileDialog dialog = new SaveFileDialog();
            DialogResult res;
            dialog.Title = "Exporter en CSV";
            dialog.Filter = "CSV|*.csv";
            res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                Functions.exportCSV(list,dialog.FileName);
        }

        private void button4_Click(object sender, EventArgs e) //Create Profil Button
        {
            Form2 fr = new Form2(this);
            fr.Show();
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

        private void button5_Click(object sender, EventArgs e) //Refresh Profil Button
        {
            richTextBox2.Clear();
            foreach (var item in listeProfils)
            {
                richTextBox2.Text += "Profil : " + item.Name +" Regles : "+item.RulesList.Count()+"\n";
                foreach (var item2 in item.RulesList)
                {
                    richTextBox2.Text += item2.Lettre + " en " + item2.Chiffre+"\n";
                }
            }
        }
    }
}
