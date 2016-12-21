namespace ClinicaFrba.Listados
{
    partial class ListadoEstadistico
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
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cmbsemestre = new System.Windows.Forms.ComboBox();
            this.cmbmes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txboxanio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbEspQuery2 = new System.Windows.Forms.ComboBox();
            this.cmbPlanQuery2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(162, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione una opción para ver las estadisticas deseadas";
            // 
            // listView1
            // 
            this.listView1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.listView1.Location = new System.Drawing.Point(429, 126);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(333, 127);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnVolver.Location = new System.Drawing.Point(664, 268);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(98, 23);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbsemestre
            // 
            this.cmbsemestre.FormattingEnabled = true;
            this.cmbsemestre.Location = new System.Drawing.Point(544, 93);
            this.cmbsemestre.Name = "cmbsemestre";
            this.cmbsemestre.Size = new System.Drawing.Size(103, 21);
            this.cmbsemestre.TabIndex = 12;
            this.cmbsemestre.SelectedIndexChanged += new System.EventHandler(this.cmbsemestre_SelectedIndexChanged);
            // 
            // cmbmes
            // 
            this.cmbmes.FormattingEnabled = true;
            this.cmbmes.Location = new System.Drawing.Point(660, 93);
            this.cmbmes.Name = "cmbmes";
            this.cmbmes.Size = new System.Drawing.Size(102, 21);
            this.cmbmes.TabIndex = 13;
            this.cmbmes.SelectedIndexChanged += new System.EventHandler(this.cmbmes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(429, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Año:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(544, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Semestre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(658, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mes:";
            // 
            // txboxanio
            // 
            this.txboxanio.Location = new System.Drawing.Point(429, 93);
            this.txboxanio.MaxLength = 4;
            this.txboxanio.Name = "txboxanio";
            this.txboxanio.Size = new System.Drawing.Size(100, 20);
            this.txboxanio.TabIndex = 17;
            this.txboxanio.TextChanged += new System.EventHandler(this.txboxanio_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButton1.Location = new System.Drawing.Point(40, 90);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(240, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Las 5 Especialidades con más cancelaciones";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButton2.Location = new System.Drawing.Point(40, 113);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(199, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Los 5 Profesionales más consultados";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButton3.Location = new System.Drawing.Point(40, 157);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(291, 17);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Los 5 Afiliados con mayor cantidad de bonos comprados";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButton4.Location = new System.Drawing.Point(40, 180);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(289, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Las 5 Especialidades con más bonos consulta utilizados";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButton5.Location = new System.Drawing.Point(40, 203);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(253, 17);
            this.radioButton5.TabIndex = 18;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Los 5 Profesionales con menos horas trabajadas";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged_1);
            // 
            // comboBox1
            // 
            this.comboBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 226);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Text = "Seleccione Especialidad";
            this.comboBox1.Visible = false;
            // 
            // cmbEspQuery2
            // 
            this.cmbEspQuery2.FormattingEnabled = true;
            this.cmbEspQuery2.Location = new System.Drawing.Point(204, 137);
            this.cmbEspQuery2.Name = "cmbEspQuery2";
            this.cmbEspQuery2.Size = new System.Drawing.Size(146, 21);
            this.cmbEspQuery2.TabIndex = 20;
            this.cmbEspQuery2.Text = "Seleccione Especialidad";
            // 
            // cmbPlanQuery2
            // 
            this.cmbPlanQuery2.FormattingEnabled = true;
            this.cmbPlanQuery2.Location = new System.Drawing.Point(59, 137);
            this.cmbPlanQuery2.Name = "cmbPlanQuery2";
            this.cmbPlanQuery2.Size = new System.Drawing.Size(139, 21);
            this.cmbPlanQuery2.TabIndex = 21;
            this.cmbPlanQuery2.Text = "Seleccione Plan";
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(780, 340);
            this.Controls.Add(this.cmbPlanQuery2);
            this.Controls.Add(this.cmbEspQuery2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txboxanio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbmes);
            this.Controls.Add(this.cmbsemestre);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cmbsemestre;
        private System.Windows.Forms.ComboBox cmbmes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txboxanio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbEspQuery2;
        private System.Windows.Forms.ComboBox cmbPlanQuery2;
    }
}