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
    public partial class Form2 : Form
    {
        Form1 parent; //On crée une référence sur la form père
        public Form2(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //function Create Profil
        {
            List<Rules> listRules = new List<Rules>();
            for (int i = 1; i <= 12; i++)
            {
                Control[] cLetter = groupBox2.Controls.Find("rulesLetterText" + i, false);
                Control[] cInt = groupBox2.Controls.Find("rulesIntText" + i, false);
                if(cLetter[0].Text != "" && cInt[0].Text != "")
                {
                    Rules r = new Rules(Int32.Parse(cInt[0].Text), cLetter[0].Text);
                    listRules.Add(r);
                }
            }
            Profil pr = new Profil(nameTextBox.Text, listRules);
            parent.listeProfils.Add(pr);
            this.Close();
        }


        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
