namespace ClinicaFrba.Registrar_Agenta_Medico
{
    partial class FrmRegistroAgenda
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.matriculaText = new System.Windows.Forms.TextBox();
            this.diaSemanaText = new System.Windows.Forms.TextBox();
            this.horaDesdeText = new System.Windows.Forms.TextBox();
            this.horaHastaText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese los datos para crear una nueva agenda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nº de Matricula";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Dia de la semana en numeros:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(54, 216);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Horario Desde";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(57, 259);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Horario Hasta";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // matriculaText
            // 
            this.matriculaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.matriculaText.Location = new System.Drawing.Point(128, 74);
            this.matriculaText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.matriculaText.Name = "matriculaText";
            this.matriculaText.Size = new System.Drawing.Size(104, 20);
            this.matriculaText.TabIndex = 11;
            // 
            // diaSemanaText
            // 
            this.diaSemanaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.diaSemanaText.Location = new System.Drawing.Point(268, 147);
            this.diaSemanaText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.diaSemanaText.Name = "diaSemanaText";
            this.diaSemanaText.Size = new System.Drawing.Size(75, 20);
            this.diaSemanaText.TabIndex = 12;
            // 
            // horaDesdeText
            // 
            this.horaDesdeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.horaDesdeText.Location = new System.Drawing.Point(153, 213);
            this.horaDesdeText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.horaDesdeText.Name = "horaDesdeText";
            this.horaDesdeText.Size = new System.Drawing.Size(75, 20);
            this.horaDesdeText.TabIndex = 13;
            // 
            // horaHastaText
            // 
            this.horaHastaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.horaHastaText.Location = new System.Drawing.Point(153, 252);
            this.horaHastaText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.horaHastaText.Name = "horaHastaText";
            this.horaHastaText.Size = new System.Drawing.Size(75, 20);
            this.horaHastaText.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(35, 325);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Crear Agenda";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelar.Location = new System.Drawing.Point(290, 325);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "ir Atrás";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "0: Domingo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "1: Lunes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(58, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "2: Martes";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(125, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "3: Miercoles";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(125, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "4: Jueves";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(125, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "5: Viernes";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(196, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "6: Sabado";
            // 
            // FrmRegistroAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(404, 382);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.horaHastaText);
            this.Controls.Add(this.horaDesdeText);
            this.Controls.Add(this.diaSemanaText);
            this.Controls.Add(this.matriculaText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "FrmRegistroAgenda";
            this.Text = "Registro de Agenda";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox matriculaText;
        private System.Windows.Forms.TextBox diaSemanaText;
        private System.Windows.Forms.TextBox horaDesdeText;
        private System.Windows.Forms.TextBox horaHastaText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}