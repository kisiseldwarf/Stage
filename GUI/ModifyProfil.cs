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
    public partial class ModifyProfil : Form
    {
        Profil profil;
        Main parent;
        List<Control> rulesList;
        string originalName;
        public ModifyProfil(Profil profil, Main parent)
        {
            InitializeComponent();
            this.profil = profil;
            this.parent = parent;
            originalName = profil.Name; //Le nom de base du profil
            parent.Enabled = false;
        }

        private bool hasSameName() //Pour empêcher que deux profils ai le même nom
        {
            Profil res = parent.listeProfils.Find(x => x.Name == nameTextBox.Text);
            if (res != null && res.Name != originalName) //Pour éviter qu'on ne puisse pas enregistrer le profil sous son nom originel
                return true;
            else
                return false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            rulesList = new List<Control>();
            rulesList.Add(rulesIntText1);
            rulesList.Add(rulesLetterText1); //TOUJOURS mettre la lettre à la fin pour que les regles se placent au bon endroit
            panel1.AutoScroll = true;
            loadData();
        }

        private void modifyButton_Click(object sender, EventArgs e) //Bouton modifier
        {
            if (nameTextBox.Text.Replace(" ", "") != "") // On vérifie qu'il y'a un nom
            {
                if(hasSameName() == false)
                {
                    Profil pr = retrieveData();
                    refreshParent(pr);
                    Close();
                }
                else
                {
                    MessageBox.Show(this, "Ce nom est déjà pris", "Erreur");
                }

            }
            else //si aucun nom on renvoie un message d'erreur
            {
                MessageBox.Show(this, "Veuillez rentrer un nom pour le profil", "Erreur");
            }
        }

        private void loadData() //Charge les données du profil et les mets dans des textbox
        {
            nameTextBox.Text = profil.Name;
            int controlID = 0;
            Control[] res;
            res = Controls.Find("rulesLetterText1", true);
            res[0].Text = profil.RulesList[0].Lettre;
            res = Controls.Find("rulesIntText1", true);
            res[0].Text = profil.RulesList[0].Chiffre.ToString();
            for (int i = 1; i < profil.RulesList.Count; i++)
            {
                controlID = createRulesControls();
                res = Controls.Find("rulesLetterText" + controlID, true);
                res[0].Text = profil.RulesList[i].Lettre;
                res = Controls.Find("rulesIntText" + controlID, true);
                res[0].Text = profil.RulesList[i].Chiffre.ToString();
            }
        }

        private int createRulesControls() //Crée l'ensemble de controls pour une regle en dessous des derniers controls de regles à avoir été crée
        {
            int previous = rulesList.Count - 1; //Il en faut toujours au moins un
            TextBox letter = new TextBox();
            NumericUpDown chiffre = new NumericUpDown();
            Point letterLoc = letter.Location;
            Point chiffreLoc = letter.Location;
            Point previousLetLoc = rulesList[previous].Location; //On reçoit toujours la lettre

            chiffre.Size = new Size(83, 20);
            letter.Size = new Size(78, 20);
            letterLoc = previousLetLoc;
            chiffreLoc = previousLetLoc;
            letterLoc.Y += 40;
            chiffreLoc.X += 130;
            chiffreLoc.Y += 40;
            letter.Location = letterLoc;
            chiffre.Location = chiffreLoc;
            int previousNumberName = Int32.Parse(rulesList[previous].Name.Substring(15));
            previousNumberName++;

            letter.Name = "rulesLetterText" + previousNumberName;
            chiffre.Name = "rulesIntText" + previousNumberName;

            panel1.Controls.Add(letter);
            panel1.Controls.Add(chiffre);

            rulesList.Add(chiffre);
            rulesList.Add(letter);

            return previousNumberName;
        }

        private Profil retrieveData() //Charge les données écrites par l'utilisateur en mémoire
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

        private void refreshParent(Profil pr)
        {
            parent.listeProfils[parent.listeProfils.IndexOf(profil)] = pr;
            parent.refreshSelect(null, null);
            parent.selectProfil.SelectedIndex = parent.listeProfils.IndexOf(pr);
            parent.refreshPreview(null, null);
            parent.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
