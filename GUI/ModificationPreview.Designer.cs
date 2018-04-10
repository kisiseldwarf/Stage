namespace GUI
{
    partial class ModificationPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectExamen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NoteTextBox1 = new System.Windows.Forms.TextBox();
            this.EtudiantTextBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.coefficientExam = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coefficientExam)).BeginInit();
            this.SuspendLayout();
            // 
            // selectExamen
            // 
            this.selectExamen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectExamen.FormattingEnabled = true;
            this.selectExamen.Location = new System.Drawing.Point(63, 12);
            this.selectExamen.Name = "selectExamen";
            this.selectExamen.Size = new System.Drawing.Size(121, 21);
            this.selectExamen.TabIndex = 0;
            this.selectExamen.SelectedIndexChanged += new System.EventHandler(this.selectExamen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Examen";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 173);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Etudiants";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Note";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Etudiant";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NoteTextBox1);
            this.panel1.Controls.Add(this.EtudiantTextBox1);
            this.panel1.Location = new System.Drawing.Point(6, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 118);
            this.panel1.TabIndex = 0;
            // 
            // NoteTextBox1
            // 
            this.NoteTextBox1.Location = new System.Drawing.Point(177, 14);
            this.NoteTextBox1.Name = "NoteTextBox1";
            this.NoteTextBox1.Size = new System.Drawing.Size(100, 20);
            this.NoteTextBox1.TabIndex = 1;
            this.NoteTextBox1.TextChanged += new System.EventHandler(this.etudNameChanged);
            // 
            // EtudiantTextBox1
            // 
            this.EtudiantTextBox1.Location = new System.Drawing.Point(15, 14);
            this.EtudiantTextBox1.Name = "EtudiantTextBox1";
            this.EtudiantTextBox1.Size = new System.Drawing.Size(100, 20);
            this.EtudiantTextBox1.TabIndex = 0;
            this.EtudiantTextBox1.TextChanged += new System.EventHandler(this.etudNameChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Coefficient";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Annuler";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // coefficientExam
            // 
            this.coefficientExam.Location = new System.Drawing.Point(253, 12);
            this.coefficientExam.Name = "coefficientExam";
            this.coefficientExam.Size = new System.Drawing.Size(101, 20);
            this.coefficientExam.TabIndex = 7;
            this.coefficientExam.ValueChanged += new System.EventHandler(this.coefficientExam_ValueChanged);
            // 
            // ModificationPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 262);
            this.Controls.Add(this.coefficientExam);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectExamen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModificationPreview";
            this.Text = "ModificationPreview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModificationPreview_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coefficientExam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectExamen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox NoteTextBox1;
        private System.Windows.Forms.TextBox EtudiantTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown coefficientExam;
    }
}