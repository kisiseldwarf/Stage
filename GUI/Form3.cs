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
    public partial class Form3 : Form
    {
        Profil profil;
        Form1 parent;
        public Form3(Profil profil, Form1 parent)
        {
            InitializeComponent();
            this.profil = profil;
            this.parent = parent;
            parent.Enabled = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = profil.Name;
            for (int i = 1; i <= 12; i++)
            {
                Control[] cLetter = groupBox2.Controls.Find("rulesLetterText" + i, false);
                Control[] cInt = groupBox2.Controls.Find("rulesIntText" + i, false);      
                if(i <= profil.RulesList.Count())
                {
                    cLetter[0].Text = profil.RulesList[i - 1].Lettre;
                    cInt[0].Text = profil.RulesList[i - 1].Chiffre.ToString();
                }
            }
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Replace(" ", "") != "") // On vérifie qu'il y'a un nom
            {
                List<Rules> listRules = new List<Rules>();
                for (int i = 1; i <= 12; i++)
                {
                    Control[] cLetter = groupBox2.Controls.Find("rulesLetterText" + i, false);
                    Control[] cInt = groupBox2.Controls.Find("rulesIntText" + i, false);
                    if (cLetter[0].Text != "" && cInt[0].Text != "")
                    {
                        Rules r = new Rules(Int32.Parse(cInt[0].Text), cLetter[0].Text);
                        listRules.Add(r);
                    }
                }
                Profil pr = new Profil(nameTextBox.Text, listRules);
                parent.listeProfils[parent.listeProfils.IndexOf(profil)] = pr;
                parent.refreshSelect(null, null);
                parent.selectProfil.SelectedIndex = parent.listeProfils.IndexOf(pr);
                parent.refreshPreview(null, null);
                parent.Enabled = true;
                this.Close();
            }
            else //si aucun nom on renvoie un message d'erreur
            {
                //TODO
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
        }
    }
}
