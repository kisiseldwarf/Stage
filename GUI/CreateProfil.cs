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

        List<Rules> rulesList;

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
            return new Profil(nameTextBox.Text,rulesList);
        }

        private void button1_Click_1(object sender, EventArgs e) //Ajouter une regle
        {
            int previous = rulesList.Count - 1;
            TextBox letter = new TextBox();
            NumericUpDown borneH = new NumericUpDown();
            NumericUpDown borneB = new NumericUpDown();
            Point letterLoc = letter.Location;
            Point borneHLoc = letter.Location;
            Point borneBLoc = letter.Location;
            Control[] previousLetter = Controls.Find("rule" + rulesList.Count + "Letter", true);
            Point previousLetLoc = previousLetter[0].Location;

            borneH.Size = new Size(92, 20);
            borneB.Size = new Size(92, 20);
            letterLoc = previousLetLoc;
            borneHLoc = previousLetLoc;
            borneBLoc = previousLetLoc;
            letterLoc.Y += 40;
            borneHLoc.X += 150;
            borneHLoc.Y += 40;
            borneBLoc.X += 275;
            borneBLoc.Y += 40;
            letter.Location = letterLoc;
            borneH.Location = borneHLoc;
            borneB.Location = borneBLoc;


            letter.Name = "rule" + (rulesList.Count + 1) + "Letter";
            borneH.Name = "rule" + (rulesList.Count + 1) + "Int1";
            borneB.Name = "rule" + (rulesList.Count + 1) + "Int2";

            Rules rule = new Rules((float)borneH.Value, (float)borneB.Value, letter.Text);
            rulesList.Add(rule);

            panel1.Controls.Add(letter);
            panel1.Controls.Add(borneH);
            panel1.Controls.Add(borneB);
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
            rulesList = new List<Rules>();
            Rules rule = new Rules((float)rule1Int1.Value, (float)rule1Int2.Value, rule1Letter.Text);
            rulesList.Add(rule);
            panel1.AutoScroll = true;
        }

        private void rules1Int1_ValueChanged(object sender, EventArgs e)
        {
            int id;
            NumericUpDown np;
            np = (NumericUpDown)sender;
            id = Int32.Parse(np.Name.Substring(4, 10 - np.Name.Count()));
            if(np.Name.Substring(8) == "1")
            {
                rulesList[id-1].BorneH = (float)np.Value;
            }
            else
            {
                rulesList[id-1].BorneB = (float)np.Value;
            }
        }
    }
}
