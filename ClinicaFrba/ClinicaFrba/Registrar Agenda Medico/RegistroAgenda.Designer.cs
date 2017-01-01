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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkBoxLunes = new System.Windows.Forms.CheckBox();
            this.cmbLunesDesde = new System.Windows.Forms.ComboBox();
            this.cmbLunesHasta = new System.Windows.Forms.ComboBox();
            this.checkBoxMartes = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMartesHasta = new System.Windows.Forms.ComboBox();
            this.cmbMartesDesde = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxMiercoles = new System.Windows.Forms.CheckBox();
            this.checkBoxJueves = new System.Windows.Forms.CheckBox();
            this.checkBoxViernes = new System.Windows.Forms.CheckBox();
            this.checkBoxSabado = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbViernesDesde = new System.Windows.Forms.ComboBox();
            this.cmbSabadoDesde = new System.Windows.Forms.ComboBox();
            this.cmbJuevesDesde = new System.Windows.Forms.ComboBox();
            this.cmbMiercolesDesde = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbSabadoHasta = new System.Windows.Forms.ComboBox();
            this.cmbViernesHasta = new System.Windows.Forms.ComboBox();
            this.cmbJuevesHasta = new System.Windows.Forms.ComboBox();
            this.cmbMiercolesHasta = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione los Días y Horarios correspondientes para crear la nueva Agenda:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(86, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Horario Desde:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(295, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Horario Hasta:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(35, 325);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnCancelar.Location = new System.Drawing.Point(200, 325);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "ir Atrás";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // checkBoxLunes
            // 
            this.checkBoxLunes.AutoSize = true;
            this.checkBoxLunes.Location = new System.Drawing.Point(14, 54);
            this.checkBoxLunes.Name = "checkBoxLunes";
            this.checkBoxLunes.Size = new System.Drawing.Size(55, 17);
            this.checkBoxLunes.TabIndex = 38;
            this.checkBoxLunes.Text = "Lunes";
            this.checkBoxLunes.UseVisualStyleBackColor = true;
            this.checkBoxLunes.CheckedChanged += new System.EventHandler(this.checkBoxLunes_CheckedChanged);
            // 
            // cmbLunesDesde
            // 
            this.cmbLunesDesde.FormattingEnabled = true;
            this.cmbLunesDesde.Location = new System.Drawing.Point(169, 52);
            this.cmbLunesDesde.Name = "cmbLunesDesde";
            this.cmbLunesDesde.Size = new System.Drawing.Size(121, 21);
            this.cmbLunesDesde.TabIndex = 39;
            // 
            // cmbLunesHasta
            // 
            this.cmbLunesHasta.FormattingEnabled = true;
            this.cmbLunesHasta.Location = new System.Drawing.Point(372, 50);
            this.cmbLunesHasta.Name = "cmbLunesHasta";
            this.cmbLunesHasta.Size = new System.Drawing.Size(121, 21);
            this.cmbLunesHasta.TabIndex = 40;
            // 
            // checkBoxMartes
            // 
            this.checkBoxMartes.AutoSize = true;
            this.checkBoxMartes.Location = new System.Drawing.Point(14, 89);
            this.checkBoxMartes.Name = "checkBoxMartes";
            this.checkBoxMartes.Size = new System.Drawing.Size(58, 17);
            this.checkBoxMartes.TabIndex = 41;
            this.checkBoxMartes.Text = "Martes";
            this.checkBoxMartes.UseVisualStyleBackColor = true;
            this.checkBoxMartes.CheckedChanged += new System.EventHandler(this.checkBoxMartes_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Horario Desde:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbMartesHasta
            // 
            this.cmbMartesHasta.FormattingEnabled = true;
            this.cmbMartesHasta.Location = new System.Drawing.Point(372, 87);
            this.cmbMartesHasta.Name = "cmbMartesHasta";
            this.cmbMartesHasta.Size = new System.Drawing.Size(121, 21);
            this.cmbMartesHasta.TabIndex = 43;
            // 
            // cmbMartesDesde
            // 
            this.cmbMartesDesde.FormattingEnabled = true;
            this.cmbMartesDesde.Location = new System.Drawing.Point(169, 85);
            this.cmbMartesDesde.Name = "cmbMartesDesde";
            this.cmbMartesDesde.Size = new System.Drawing.Size(121, 21);
            this.cmbMartesDesde.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(295, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Horario Hasta:";
            // 
            // checkBoxMiercoles
            // 
            this.checkBoxMiercoles.AutoSize = true;
            this.checkBoxMiercoles.Location = new System.Drawing.Point(14, 124);
            this.checkBoxMiercoles.Name = "checkBoxMiercoles";
            this.checkBoxMiercoles.Size = new System.Drawing.Size(71, 17);
            this.checkBoxMiercoles.TabIndex = 46;
            this.checkBoxMiercoles.Text = "Miercoles";
            this.checkBoxMiercoles.UseVisualStyleBackColor = true;
            this.checkBoxMiercoles.CheckedChanged += new System.EventHandler(this.checkBoxMiercoles_CheckedChanged);
            // 
            // checkBoxJueves
            // 
            this.checkBoxJueves.AutoSize = true;
            this.checkBoxJueves.Location = new System.Drawing.Point(14, 159);
            this.checkBoxJueves.Name = "checkBoxJueves";
            this.checkBoxJueves.Size = new System.Drawing.Size(60, 17);
            this.checkBoxJueves.TabIndex = 47;
            this.checkBoxJueves.Text = "Jueves";
            this.checkBoxJueves.UseVisualStyleBackColor = true;
            this.checkBoxJueves.CheckedChanged += new System.EventHandler(this.checkBoxJueves_CheckedChanged);
            // 
            // checkBoxViernes
            // 
            this.checkBoxViernes.AutoSize = true;
            this.checkBoxViernes.Location = new System.Drawing.Point(14, 198);
            this.checkBoxViernes.Name = "checkBoxViernes";
            this.checkBoxViernes.Size = new System.Drawing.Size(61, 17);
            this.checkBoxViernes.TabIndex = 48;
            this.checkBoxViernes.Text = "Viernes";
            this.checkBoxViernes.UseVisualStyleBackColor = true;
            this.checkBoxViernes.CheckedChanged += new System.EventHandler(this.checkBoxViernes_CheckedChanged);
            // 
            // checkBoxSabado
            // 
            this.checkBoxSabado.AutoSize = true;
            this.checkBoxSabado.Location = new System.Drawing.Point(14, 233);
            this.checkBoxSabado.Name = "checkBoxSabado";
            this.checkBoxSabado.Size = new System.Drawing.Size(63, 17);
            this.checkBoxSabado.TabIndex = 49;
            this.checkBoxSabado.Text = "Sabado";
            this.checkBoxSabado.UseVisualStyleBackColor = true;
            this.checkBoxSabado.CheckedChanged += new System.EventHandler(this.checkBoxSabado_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 234);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Horario Desde:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 199);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Horario Desde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(86, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Horario Desde:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(86, 125);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Horario Desde:";
            // 
            // cmbViernesDesde
            // 
            this.cmbViernesDesde.FormattingEnabled = true;
            this.cmbViernesDesde.Location = new System.Drawing.Point(169, 196);
            this.cmbViernesDesde.Name = "cmbViernesDesde";
            this.cmbViernesDesde.Size = new System.Drawing.Size(121, 21);
            this.cmbViernesDesde.TabIndex = 54;
            // 
            // cmbSabadoDesde
            // 
            this.cmbSabadoDesde.FormattingEnabled = true;
            this.cmbSabadoDesde.Location = new System.Drawing.Point(169, 231);
            this.cmbSabadoDesde.Name = "cmbSabadoDesde";
            this.cmbSabadoDesde.Size = new System.Drawing.Size(121, 21);
            this.cmbSabadoDesde.TabIndex = 55;
            // 
            // cmbJuevesDesde
            // 
            this.cmbJuevesDesde.FormattingEnabled = true;
            this.cmbJuevesDesde.Location = new System.Drawing.Point(169, 157);
            this.cmbJuevesDesde.Name = "cmbJuevesDesde";
            this.cmbJuevesDesde.Size = new System.Drawing.Size(121, 21);
            this.cmbJuevesDesde.TabIndex = 56;
            // 
            // cmbMiercolesDesde
            // 
            this.cmbMiercolesDesde.FormattingEnabled = true;
            this.cmbMiercolesDesde.Location = new System.Drawing.Point(169, 122);
            this.cmbMiercolesDesde.Name = "cmbMiercolesDesde";
            this.cmbMiercolesDesde.Size = new System.Drawing.Size(121, 21);
            this.cmbMiercolesDesde.TabIndex = 57;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(295, 234);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Horario Hasta:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(295, 199);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "Horario Hasta:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(295, 160);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 60;
            this.label12.Text = "Horario Hasta:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(295, 125);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 61;
            this.label13.Text = "Horario Hasta:";
            // 
            // cmbSabadoHasta
            // 
            this.cmbSabadoHasta.FormattingEnabled = true;
            this.cmbSabadoHasta.Location = new System.Drawing.Point(372, 231);
            this.cmbSabadoHasta.Name = "cmbSabadoHasta";
            this.cmbSabadoHasta.Size = new System.Drawing.Size(121, 21);
            this.cmbSabadoHasta.TabIndex = 62;
            // 
            // cmbViernesHasta
            // 
            this.cmbViernesHasta.FormattingEnabled = true;
            this.cmbViernesHasta.Location = new System.Drawing.Point(372, 196);
            this.cmbViernesHasta.Name = "cmbViernesHasta";
            this.cmbViernesHasta.Size = new System.Drawing.Size(121, 21);
            this.cmbViernesHasta.TabIndex = 63;
            // 
            // cmbJuevesHasta
            // 
            this.cmbJuevesHasta.FormattingEnabled = true;
            this.cmbJuevesHasta.Location = new System.Drawing.Point(372, 157);
            this.cmbJuevesHasta.Name = "cmbJuevesHasta";
            this.cmbJuevesHasta.Size = new System.Drawing.Size(121, 21);
            this.cmbJuevesHasta.TabIndex = 64;
            // 
            // cmbMiercolesHasta
            // 
            this.cmbMiercolesHasta.FormattingEnabled = true;
            this.cmbMiercolesHasta.Location = new System.Drawing.Point(372, 122);
            this.cmbMiercolesHasta.Name = "cmbMiercolesHasta";
            this.cmbMiercolesHasta.Size = new System.Drawing.Size(121, 21);
            this.cmbMiercolesHasta.TabIndex = 65;
            // 
            // FrmRegistroAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(539, 376);
            this.Controls.Add(this.cmbMiercolesHasta);
            this.Controls.Add(this.cmbJuevesHasta);
            this.Controls.Add(this.cmbViernesHasta);
            this.Controls.Add(this.cmbSabadoHasta);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbMiercolesDesde);
            this.Controls.Add(this.cmbJuevesDesde);
            this.Controls.Add(this.cmbSabadoDesde);
            this.Controls.Add(this.cmbViernesDesde);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxSabado);
            this.Controls.Add(this.checkBoxViernes);
            this.Controls.Add(this.checkBoxJueves);
            this.Controls.Add(this.checkBoxMiercoles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMartesDesde);
            this.Controls.Add(this.cmbMartesHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxMartes);
            this.Controls.Add(this.cmbLunesHasta);
            this.Controls.Add(this.cmbLunesDesde);
            this.Controls.Add(this.checkBoxLunes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkBoxLunes;
        private System.Windows.Forms.ComboBox cmbLunesDesde;
        private System.Windows.Forms.ComboBox cmbLunesHasta;
        private System.Windows.Forms.CheckBox checkBoxMartes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMartesHasta;
        private System.Windows.Forms.ComboBox cmbMartesDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxMiercoles;
        private System.Windows.Forms.CheckBox checkBoxJueves;
        private System.Windows.Forms.CheckBox checkBoxViernes;
        private System.Windows.Forms.CheckBox checkBoxSabado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbViernesDesde;
        private System.Windows.Forms.ComboBox cmbSabadoDesde;
        private System.Windows.Forms.ComboBox cmbJuevesDesde;
        private System.Windows.Forms.ComboBox cmbMiercolesDesde;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbSabadoHasta;
        private System.Windows.Forms.ComboBox cmbViernesHasta;
        private System.Windows.Forms.ComboBox cmbJuevesHasta;
        private System.Windows.Forms.ComboBox cmbMiercolesHasta;
    }
}