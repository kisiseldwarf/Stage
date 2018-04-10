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
    public partial class CreateProfil : Form
    {
        Main parent; //On crée une référence sur la form père
        public CreateProfil(Main parent)
        {
            InitializeComponent();
            this.parent = parent;
            parent.Enabled = false;
        }

        List<Control> rulesList;

        private void button1_Click(object sender, EventArgs e) //function Create Profil
        {
            if(nameTextBox.Text.Replace(" ","") != "") 
            {
                if(hasSameName() == false)
                {
                   Profil pr = retrieveData();

                    refreshParent(pr);

                    Close();
                }
                else
                {
                    MessageBox.Show(this, "Ce nom a déjà été pris", "Erreur");
                }
 
            }
            else //si aucun nom on renvoie un message d'erreur
            {
                MessageBox.Show(this,"Veuillez rentrer un nom pour le profil","Erreur");
            }
        }


        private void cancelButton_Click(object sender, EventArgs e) //Button Cancel
        {
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }

        private void refreshParent(Profil pr)
        {
            parent.listeProfils.Add(pr);
            parent.refreshSelect(null, null);
            parent.selectProfil.SelectedIndex = parent.listeProfils.IndexOf(pr);
            parent.refreshPreview(null, null);
            parent.Enabled = true;
        }

        private Profil retrieveData()
        {
            List<Rules> listRules = new List<Rules>();

            for (int i = 0; i < rulesList.Count / 2; i++) //Algo de parcours de tableau de deux à deux
            {
                if (rulesList[i * 2].Text != "" && rulesList[i * 2 + 1].Text != "") // Pour pas avoir des regles vides
                {
                    Rules r = new Rules(Int32.Parse(rulesList[i * 2].Text), rulesList[i * 2 + 1].Text);
                    listRules.Add(r);
                }
            }

            Profil pr = new Profil(nameTextBox.Text, listRules);
            return pr;
        }

        private void button1_Click_1(object sender, EventArgs e) //Ajouter une regle
        {
            int previous = rulesList.Count - 1;
            TextBox letter = new TextBox();
            NumericUpDown chiffre = new NumericUpDown();
            Point letterLoc = letter.Location;
            Point chiffreLoc = letter.Location;
            Point previousLetLoc = rulesList[previous].Location; //On reçoit toujours la lettre

            chiffre.Size = new Size(92, 20);
            letterLoc = previousLetLoc;
            chiffreLoc = previousLetLoc;
            letterLoc.Y += 40;
            chiffreLoc.X += 132;
            chiffreLoc.Y += 40;
            letter.Location = letterLoc;
            chiffre.Location = chiffreLoc;


            letter.Name = "rulesLetterText" + rulesList.Count / 2 + 1;
            chiffre.Name = "rulesChiffreText" + Math.Round((decimal)rulesList.Count / 2);

            panel1.Controls.Add(letter);
            panel1.Controls.Add(chiffre);

            rulesList.Add(chiffre);
            rulesList.Add(letter);

        }

        private bool hasSameName() //Pour empêcher que deux profils ai le même nom
        {
            if (parent.listeProfils.Find(x => x.Name == nameTextBox.Text) != null)
                return true;
            else
                return false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            rulesList = new List<Control>();
            rulesList.Add(rulesIntText1);
            rulesList.Add(rulesLetterText1); //TOUJOURS mettre la lettre à la fin pour que les regles se placent au bon endroit
            panel1.AutoScroll = true;
        }
    }
}
