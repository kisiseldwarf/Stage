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
        List<Rules> rulesList;
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
            rulesList = new List<Rules>();
            panel1.AutoScroll = true;
            loadData();
        }

        private void modifyButton_Click(object sender, EventArgs e) //Bouton modifier
        {
            if (nameTextBox.Text.Replace(" ", "") != "") // On vérifie qu'il y'a un nom
            {
                if(hasSameName() == false)
                {
                    saveData();
                    refreshParent(profil);
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
            res = Controls.Find("rule1Letter", true);
            res[0].Text = profil.RulesList[0].Lettre;
            res = Controls.Find("rule1Int1", true);
            res[0].Text = profil.RulesList[0].BorneH.ToString();
            for (int i = 1; i < profil.RulesList.Count; i++)
            {
                controlID = createRulesControls();
                res = Controls.Find("rule"+ controlID + "Letter", true);
                res[0].Text = profil.RulesList[i].Lettre;
                res = Controls.Find("rule"+ controlID + "Int1Text", true);
                res[0].Text = profil.RulesList[i].BorneH.ToString();
            }
        }

        private int createRulesControls() //Crée l'ensemble de controls pour une regle en dessous des derniers controls de regles à avoir été crée
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
            borneH.Size = new Size(92, 20);
            letterLoc = previousLetLoc;
            borneHLoc = previousLetLoc;
            borneBLoc = previousLetLoc;
            letterLoc.Y += 40;
            borneHLoc.X += 150;
            borneHLoc.Y += 40;
            borneBLoc.X += 300;
            borneBLoc.Y += 40;
            letter.Location = letterLoc;
            borneH.Location = borneHLoc;
            borneB.Location = borneBLoc;
            borneH.ValueChanged += new EventHandler(numericUpDown1_ValueChanged);
            borneB.ValueChanged += new EventHandler(numericUpDown1_ValueChanged);


            letter.Name = "rule" + (rulesList.Count + 1) + "Letter";
            borneH.Name = "rule" + (rulesList.Count + 1) + "Int1";
            borneB.Name = "rule" + (rulesList.Count + 1) + "Int2";

            Rules rule = new Rules((float)borneH.Value, (float)borneB.Value, letter.Text);
            rulesList.Add(rule);

            panel1.Controls.Add(letter);
            panel1.Controls.Add(borneH);
            panel1.Controls.Add(borneB);

            return rulesList.Count;
        }

        private void saveData() //Charge les données écrites par l'utilisateur en mémoire
        {
            profil.changeProfil(rulesList);
        }

        private void refreshParent(Profil pr)
        {
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
            int id;
            NumericUpDown np;
            np = (NumericUpDown)sender;
            id = Int32.Parse(np.Name.Substring(4, 9 - np.Name.Count()));
            if (np.Name.Substring(8) == "1")
            {
                rulesList[id].BorneH = (float)np.Value;
            }
            else
            {
                rulesList[id].BorneB = (float)np.Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createRulesControls();
        }
    }
}
