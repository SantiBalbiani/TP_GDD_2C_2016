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
            this.SuspendLayout();
            // 
            // btnCancelaciones
            // 
            this.btnCancelaciones.Location = new System.Drawing.Point(52, 79);
            this.btnCancelaciones.Name = "btnCancelaciones";
            this.btnCancelaciones.Size = new System.Drawing.Size(275, 23);
            this.btnCancelaciones.TabIndex = 0;
            this.btnCancelaciones.Text = "Especialidades con más cancelaciones";
            this.btnCancelaciones.UseVisualStyleBackColor = true;
            this.btnCancelaciones.Click += new System.EventHandler(this.btnCancelaciones_Click);
            // 
            // btnConsultados
            // 
            this.btnConsultados.Location = new System.Drawing.Point(52, 108);
            this.btnConsultados.Name = "btnConsultados";
            this.btnConsultados.Size = new System.Drawing.Size(275, 23);
            this.btnConsultados.TabIndex = 1;
            this.btnConsultados.Text = "Profesionales más consultados por Plan";
            this.btnConsultados.UseVisualStyleBackColor = true;
            this.btnConsultados.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(51, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(276, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Profesionales con menos horas trabajadas";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(52, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(275, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Afiliados con mayor cantidad de bonos comprados";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(52, 198);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(275, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Especialidades con más bonos consulta utilizados";
            this.button5.UseVisualStyleBackColor = true;
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
            this.listView1.Location = new System.Drawing.Point(345, 79);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(330, 142);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(577, 255);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(98, 23);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cbmPlanMed
            // 
            this.cbmPlanMed.FormattingEnabled = true;
            this.cbmPlanMed.Location = new System.Drawing.Point(251, 255);
            this.cbmPlanMed.Name = "cbmPlanMed";
            this.cbmPlanMed.Size = new System.Drawing.Size(121, 21);
            this.cbmPlanMed.TabIndex = 8;
            this.cbmPlanMed.Text = "Seleccione Plan";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(52, 255);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "Seleccione Especialidad";
            this.comboBox1.Visible = false;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(723, 306);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cbmPlanMed);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnConsultados);
            this.Controls.Add(this.btnCancelaciones);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
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
    }
}