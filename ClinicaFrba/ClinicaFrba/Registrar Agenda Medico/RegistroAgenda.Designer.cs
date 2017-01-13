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
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.checkBoxLunes = new System.Windows.Forms.CheckBox();
            this.checkBoxMartes = new System.Windows.Forms.CheckBox();
            this.checkBoxMiercoles = new System.Windows.Forms.CheckBox();
            this.checkBoxJueves = new System.Windows.Forms.CheckBox();
            this.checkBoxViernes = new System.Windows.Forms.CheckBox();
            this.checkBoxSabado = new System.Windows.Forms.CheckBox();
            this.cmbLunesDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbLunesHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbMartesDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbMartesHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbMiercolesDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbMiercolesHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbJuevesDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbJuevesHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbViernesDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbViernesHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbSabadoDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbSabadoHasta = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(200, 325);
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
            this.btnCancelar.Location = new System.Drawing.Point(294, 325);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // checkBoxLunes
            // 
            this.checkBoxLunes.AutoSize = true;
            this.checkBoxLunes.Location = new System.Drawing.Point(144, 51);
            this.checkBoxLunes.Name = "checkBoxLunes";
            this.checkBoxLunes.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLunes.TabIndex = 38;
            this.checkBoxLunes.UseVisualStyleBackColor = true;
            this.checkBoxLunes.CheckedChanged += new System.EventHandler(this.checkBoxLunes_CheckedChanged);
            // 
            // checkBoxMartes
            // 
            this.checkBoxMartes.AutoSize = true;
            this.checkBoxMartes.Location = new System.Drawing.Point(144, 99);
            this.checkBoxMartes.Name = "checkBoxMartes";
            this.checkBoxMartes.Size = new System.Drawing.Size(15, 14);
            this.checkBoxMartes.TabIndex = 41;
            this.checkBoxMartes.UseVisualStyleBackColor = true;
            this.checkBoxMartes.CheckedChanged += new System.EventHandler(this.checkBoxMartes_CheckedChanged);
            // 
            // checkBoxMiercoles
            // 
            this.checkBoxMiercoles.AutoSize = true;
            this.checkBoxMiercoles.Location = new System.Drawing.Point(144, 146);
            this.checkBoxMiercoles.Name = "checkBoxMiercoles";
            this.checkBoxMiercoles.Size = new System.Drawing.Size(15, 14);
            this.checkBoxMiercoles.TabIndex = 46;
            this.checkBoxMiercoles.UseVisualStyleBackColor = true;
            this.checkBoxMiercoles.CheckedChanged += new System.EventHandler(this.checkBoxMiercoles_CheckedChanged);
            // 
            // checkBoxJueves
            // 
            this.checkBoxJueves.AutoSize = true;
            this.checkBoxJueves.Location = new System.Drawing.Point(144, 194);
            this.checkBoxJueves.Name = "checkBoxJueves";
            this.checkBoxJueves.Size = new System.Drawing.Size(15, 14);
            this.checkBoxJueves.TabIndex = 47;
            this.checkBoxJueves.UseVisualStyleBackColor = true;
            this.checkBoxJueves.CheckedChanged += new System.EventHandler(this.checkBoxJueves_CheckedChanged);
            // 
            // checkBoxViernes
            // 
            this.checkBoxViernes.AutoSize = true;
            this.checkBoxViernes.Location = new System.Drawing.Point(144, 239);
            this.checkBoxViernes.Name = "checkBoxViernes";
            this.checkBoxViernes.Size = new System.Drawing.Size(15, 14);
            this.checkBoxViernes.TabIndex = 48;
            this.checkBoxViernes.UseVisualStyleBackColor = true;
            this.checkBoxViernes.CheckedChanged += new System.EventHandler(this.checkBoxViernes_CheckedChanged);
            // 
            // checkBoxSabado
            // 
            this.checkBoxSabado.AutoSize = true;
            this.checkBoxSabado.Location = new System.Drawing.Point(144, 286);
            this.checkBoxSabado.Name = "checkBoxSabado";
            this.checkBoxSabado.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSabado.TabIndex = 49;
            this.checkBoxSabado.UseVisualStyleBackColor = true;
            this.checkBoxSabado.CheckedChanged += new System.EventHandler(this.checkBoxSabado_CheckedChanged);
            // 
            // cmbLunesDesde
            // 
            this.cmbLunesDesde.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbLunesDesde.CustomFormat = "HH:mm";
            this.cmbLunesDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbLunesDesde.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbLunesDesde.Location = new System.Drawing.Point(215, 51);
            this.cmbLunesDesde.Name = "cmbLunesDesde";
            this.cmbLunesDesde.ShowUpDown = true;
            this.cmbLunesDesde.Size = new System.Drawing.Size(59, 20);
            this.cmbLunesDesde.TabIndex = 66;
            this.cmbLunesDesde.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cmbLunesHasta
            // 
            this.cmbLunesHasta.CustomFormat = "HH:mm";
            this.cmbLunesHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbLunesHasta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbLunesHasta.Location = new System.Drawing.Point(307, 51);
            this.cmbLunesHasta.Name = "cmbLunesHasta";
            this.cmbLunesHasta.ShowUpDown = true;
            this.cmbLunesHasta.Size = new System.Drawing.Size(59, 20);
            this.cmbLunesHasta.TabIndex = 67;
            // 
            // cmbMartesDesde
            // 
            this.cmbMartesDesde.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbMartesDesde.CustomFormat = "HH:mm";
            this.cmbMartesDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbMartesDesde.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbMartesDesde.Location = new System.Drawing.Point(215, 99);
            this.cmbMartesDesde.Name = "cmbMartesDesde";
            this.cmbMartesDesde.ShowUpDown = true;
            this.cmbMartesDesde.Size = new System.Drawing.Size(59, 20);
            this.cmbMartesDesde.TabIndex = 68;
            // 
            // cmbMartesHasta
            // 
            this.cmbMartesHasta.CustomFormat = "HH:mm";
            this.cmbMartesHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbMartesHasta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbMartesHasta.Location = new System.Drawing.Point(307, 99);
            this.cmbMartesHasta.Name = "cmbMartesHasta";
            this.cmbMartesHasta.ShowUpDown = true;
            this.cmbMartesHasta.Size = new System.Drawing.Size(59, 20);
            this.cmbMartesHasta.TabIndex = 69;
            // 
            // cmbMiercolesDesde
            // 
            this.cmbMiercolesDesde.CustomFormat = "HH:mm";
            this.cmbMiercolesDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbMiercolesDesde.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbMiercolesDesde.Location = new System.Drawing.Point(215, 146);
            this.cmbMiercolesDesde.Name = "cmbMiercolesDesde";
            this.cmbMiercolesDesde.ShowUpDown = true;
            this.cmbMiercolesDesde.Size = new System.Drawing.Size(59, 20);
            this.cmbMiercolesDesde.TabIndex = 70;
            // 
            // cmbMiercolesHasta
            // 
            this.cmbMiercolesHasta.CustomFormat = "HH:mm";
            this.cmbMiercolesHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbMiercolesHasta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbMiercolesHasta.Location = new System.Drawing.Point(307, 146);
            this.cmbMiercolesHasta.Name = "cmbMiercolesHasta";
            this.cmbMiercolesHasta.ShowUpDown = true;
            this.cmbMiercolesHasta.Size = new System.Drawing.Size(59, 20);
            this.cmbMiercolesHasta.TabIndex = 71;
            // 
            // cmbJuevesDesde
            // 
            this.cmbJuevesDesde.CustomFormat = "HH:mm";
            this.cmbJuevesDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbJuevesDesde.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbJuevesDesde.Location = new System.Drawing.Point(215, 191);
            this.cmbJuevesDesde.Name = "cmbJuevesDesde";
            this.cmbJuevesDesde.ShowUpDown = true;
            this.cmbJuevesDesde.Size = new System.Drawing.Size(59, 20);
            this.cmbJuevesDesde.TabIndex = 72;
            // 
            // cmbJuevesHasta
            // 
            this.cmbJuevesHasta.CustomFormat = "HH:mm";
            this.cmbJuevesHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbJuevesHasta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbJuevesHasta.Location = new System.Drawing.Point(307, 191);
            this.cmbJuevesHasta.Name = "cmbJuevesHasta";
            this.cmbJuevesHasta.ShowUpDown = true;
            this.cmbJuevesHasta.Size = new System.Drawing.Size(59, 20);
            this.cmbJuevesHasta.TabIndex = 73;
            // 
            // cmbViernesDesde
            // 
            this.cmbViernesDesde.CustomFormat = "HH:mm";
            this.cmbViernesDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbViernesDesde.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbViernesDesde.Location = new System.Drawing.Point(215, 239);
            this.cmbViernesDesde.Name = "cmbViernesDesde";
            this.cmbViernesDesde.ShowUpDown = true;
            this.cmbViernesDesde.Size = new System.Drawing.Size(59, 20);
            this.cmbViernesDesde.TabIndex = 74;
            // 
            // cmbViernesHasta
            // 
            this.cmbViernesHasta.CustomFormat = "HH:mm";
            this.cmbViernesHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbViernesHasta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbViernesHasta.Location = new System.Drawing.Point(307, 239);
            this.cmbViernesHasta.Name = "cmbViernesHasta";
            this.cmbViernesHasta.ShowUpDown = true;
            this.cmbViernesHasta.Size = new System.Drawing.Size(59, 20);
            this.cmbViernesHasta.TabIndex = 75;
            // 
            // cmbSabadoDesde
            // 
            this.cmbSabadoDesde.CustomFormat = "HH:mm";
            this.cmbSabadoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbSabadoDesde.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbSabadoDesde.Location = new System.Drawing.Point(215, 286);
            this.cmbSabadoDesde.Name = "cmbSabadoDesde";
            this.cmbSabadoDesde.ShowUpDown = true;
            this.cmbSabadoDesde.Size = new System.Drawing.Size(59, 20);
            this.cmbSabadoDesde.TabIndex = 76;
            // 
            // cmbSabadoHasta
            // 
            this.cmbSabadoHasta.CustomFormat = "HH:mm";
            this.cmbSabadoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbSabadoHasta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbSabadoHasta.Location = new System.Drawing.Point(307, 286);
            this.cmbSabadoHasta.Name = "cmbSabadoHasta";
            this.cmbSabadoHasta.ShowUpDown = true;
            this.cmbSabadoHasta.Size = new System.Drawing.Size(59, 20);
            this.cmbSabadoHasta.TabIndex = 77;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(385, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 78;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(385, 99);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 79;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(385, 146);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 80;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(385, 191);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 21);
            this.comboBox4.TabIndex = 81;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(385, 238);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 21);
            this.comboBox5.TabIndex = 82;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(385, 286);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 21);
            this.comboBox6.TabIndex = 83;
            // 
            // FrmRegistroAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClinicaFrba.Properties.Resources.Agenda2;
            this.ClientSize = new System.Drawing.Size(524, 355);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmbSabadoHasta);
            this.Controls.Add(this.cmbSabadoDesde);
            this.Controls.Add(this.cmbViernesHasta);
            this.Controls.Add(this.cmbViernesDesde);
            this.Controls.Add(this.cmbJuevesHasta);
            this.Controls.Add(this.cmbJuevesDesde);
            this.Controls.Add(this.cmbMiercolesHasta);
            this.Controls.Add(this.cmbMiercolesDesde);
            this.Controls.Add(this.cmbMartesHasta);
            this.Controls.Add(this.cmbMartesDesde);
            this.Controls.Add(this.cmbLunesHasta);
            this.Controls.Add(this.cmbLunesDesde);
            this.Controls.Add(this.checkBoxSabado);
            this.Controls.Add(this.checkBoxViernes);
            this.Controls.Add(this.checkBoxJueves);
            this.Controls.Add(this.checkBoxMiercoles);
            this.Controls.Add(this.checkBoxMartes);
            this.Controls.Add(this.checkBoxLunes);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "FrmRegistroAgenda";
            this.Text = "Registro de Agenda";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkBoxLunes;
        private System.Windows.Forms.CheckBox checkBoxMartes;
        private System.Windows.Forms.CheckBox checkBoxMiercoles;
        private System.Windows.Forms.CheckBox checkBoxJueves;
        private System.Windows.Forms.CheckBox checkBoxViernes;
        private System.Windows.Forms.CheckBox checkBoxSabado;
        private System.Windows.Forms.DateTimePicker cmbLunesDesde;
        private System.Windows.Forms.DateTimePicker cmbLunesHasta;
        private System.Windows.Forms.DateTimePicker cmbMartesDesde;
        private System.Windows.Forms.DateTimePicker cmbMartesHasta;
        private System.Windows.Forms.DateTimePicker cmbMiercolesDesde;
        private System.Windows.Forms.DateTimePicker cmbMiercolesHasta;
        private System.Windows.Forms.DateTimePicker cmbJuevesDesde;
        private System.Windows.Forms.DateTimePicker cmbJuevesHasta;
        private System.Windows.Forms.DateTimePicker cmbViernesDesde;
        private System.Windows.Forms.DateTimePicker cmbViernesHasta;
        private System.Windows.Forms.DateTimePicker cmbSabadoDesde;
        private System.Windows.Forms.DateTimePicker cmbSabadoHasta;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
    }
}