namespace GUI
{
    partial class Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.selectProfil = new System.Windows.Forms.ComboBox();
            this.profilPreview = new System.Windows.Forms.RichTextBox();
            this.removeProfilBut = new System.Windows.Forms.Button();
            this.modifyProfilBut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(232, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(294, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(327, 198);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Preview";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::GUI.Properties.Resources.Files_View_File_icon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(265, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 22);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(507, 228);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Exporter CSV";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(213, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Creer Profil";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Profil";
            // 
            // selectProfil
            // 
            this.selectProfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectProfil.FormattingEnabled = true;
            this.selectProfil.Location = new System.Drawing.Point(53, 50);
            this.selectProfil.MaxDropDownItems = 15;
            this.selectProfil.Name = "selectProfil";
            this.selectProfil.Size = new System.Drawing.Size(154, 21);
            this.selectProfil.TabIndex = 9;
            this.selectProfil.SelectionChangeCommitted += new System.EventHandler(this.refreshPreview);
            // 
            // profilPreview
            // 
            this.profilPreview.Location = new System.Drawing.Point(12, 77);
            this.profilPreview.Name = "profilPreview";
            this.profilPreview.ReadOnly = true;
            this.profilPreview.Size = new System.Drawing.Size(273, 145);
            this.profilPreview.TabIndex = 10;
            this.profilPreview.Text = "";
            // 
            // removeProfilBut
            // 
            this.removeProfilBut.Location = new System.Drawing.Point(15, 228);
            this.removeProfilBut.Name = "removeProfilBut";
            this.removeProfilBut.Size = new System.Drawing.Size(75, 23);
            this.removeProfilBut.TabIndex = 12;
            this.removeProfilBut.Text = "Supprimer";
            this.removeProfilBut.UseVisualStyleBackColor = true;
            this.removeProfilBut.Click += new System.EventHandler(this.removeProfilBut_Click);
            // 
            // modifyProfilBut
            // 
            this.modifyProfilBut.Location = new System.Drawing.Point(96, 228);
            this.modifyProfilBut.Name = "modifyProfilBut";
            this.modifyProfilBut.Size = new System.Drawing.Size(75, 23);
            this.modifyProfilBut.TabIndex = 13;
            this.modifyProfilBut.Text = "Modifier";
            this.modifyProfilBut.UseVisualStyleBackColor = true;
            this.modifyProfilBut.Click += new System.EventHandler(this.modifyProfilBut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Modifier";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 260);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.modifyProfilBut);
            this.Controls.Add(this.removeProfilBut);
            this.Controls.Add(this.profilPreview);
            this.Controls.Add(this.selectProfil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox profilPreview;
        private System.Windows.Forms.Button removeProfilBut;
        private System.Windows.Forms.Button modifyProfilBut;
        public System.Windows.Forms.ComboBox selectProfil;
        private System.Windows.Forms.Button button1;
    }
}

