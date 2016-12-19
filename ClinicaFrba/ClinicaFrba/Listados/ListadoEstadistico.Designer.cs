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
            this.btnCancelaciones = new System.Windows.Forms.Button();
            this.btnConsultados = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cbmPlanMed = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbsemestre = new System.Windows.Forms.ComboBox();
            this.cmbmes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txboxanio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelaciones
            // 
            this.btnCancelaciones.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelaciones.Location = new System.Drawing.Point(49, 79);
            this.btnCancelaciones.Name = "btnCancelaciones";
            this.btnCancelaciones.Size = new System.Drawing.Size(275, 23);
            this.btnCancelaciones.TabIndex = 0;
            this.btnCancelaciones.Text = "Especialidades con más cancelaciones";
            this.btnCancelaciones.UseVisualStyleBackColor = true;
            this.btnCancelaciones.Click += new System.EventHandler(this.btnCancelaciones_Click);
            // 
            // btnConsultados
            // 
            this.btnConsultados.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnConsultados.Location = new System.Drawing.Point(49, 108);
            this.btnConsultados.Name = "btnConsultados";
            this.btnConsultados.Size = new System.Drawing.Size(275, 23);
            this.btnConsultados.TabIndex = 1;
            this.btnConsultados.Text = "Profesionales más consultados por Plan";
            this.btnConsultados.UseVisualStyleBackColor = true;
            this.btnConsultados.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button3.Location = new System.Drawing.Point(10, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(273, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Profesionales con menos horas trabajadas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button4.Location = new System.Drawing.Point(49, 137);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(275, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Afiliados con mayor cantidad de bonos comprados";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button5.Location = new System.Drawing.Point(49, 167);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(275, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Especialidades con más bonos consulta utilizados";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
            this.listView1.Location = new System.Drawing.Point(345, 126);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(333, 127);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnVolver.Location = new System.Drawing.Point(577, 271);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(98, 23);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cbmPlanMed
            // 
            this.cbmPlanMed.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cbmPlanMed.FormattingEnabled = true;
            this.cbmPlanMed.Location = new System.Drawing.Point(161, 15);
            this.cbmPlanMed.Name = "cbmPlanMed";
            this.cbmPlanMed.Size = new System.Drawing.Size(121, 21);
            this.cbmPlanMed.TabIndex = 8;
            this.cbmPlanMed.Text = "Seleccione Plan";
            // 
            // comboBox1
            // 
            this.comboBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "Seleccione Especialidad";
            this.comboBox1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbmPlanMed);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(41, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 71);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // cmbsemestre
            // 
            this.cmbsemestre.FormattingEnabled = true;
            this.cmbsemestre.Location = new System.Drawing.Point(460, 93);
            this.cmbsemestre.Name = "cmbsemestre";
            this.cmbsemestre.Size = new System.Drawing.Size(103, 21);
            this.cmbsemestre.TabIndex = 12;
            this.cmbsemestre.SelectedIndexChanged += new System.EventHandler(this.cmbsemestre_SelectedIndexChanged);
            // 
            // cmbmes
            // 
            this.cmbmes.FormattingEnabled = true;
            this.cmbmes.Location = new System.Drawing.Point(576, 93);
            this.cmbmes.Name = "cmbmes";
            this.cmbmes.Size = new System.Drawing.Size(102, 21);
            this.cmbmes.TabIndex = 13;
            this.cmbmes.SelectedIndexChanged += new System.EventHandler(this.cmbmes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(345, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Año:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(460, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Semestre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(574, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mes:";
            // 
            // txboxanio
            // 
            this.txboxanio.Location = new System.Drawing.Point(345, 93);
            this.txboxanio.Name = "txboxanio";
            this.txboxanio.Size = new System.Drawing.Size(100, 20);
            this.txboxanio.TabIndex = 17;
            this.txboxanio.TextChanged += new System.EventHandler(this.txboxanio_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(723, 306);
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
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnConsultados);
            this.Controls.Add(this.btnCancelaciones);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelaciones;
        private System.Windows.Forms.Button btnConsultados;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cbmPlanMed;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbsemestre;
        private System.Windows.Forms.ComboBox cmbmes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txboxanio;
        private System.Windows.Forms.Button button1;
    }
}