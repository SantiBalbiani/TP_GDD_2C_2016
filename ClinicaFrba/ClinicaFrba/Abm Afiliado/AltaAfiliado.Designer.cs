namespace ClinicaFrba.Abm_Afiliado
{
    partial class frmAltaAfiliado
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEstadoCivil = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkHijos = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCantHijos = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnCargaHijos = new System.Windows.Forms.Button();
            this.btnCargaPareja = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textNombre = new Libreria.errorTextBox();
            this.textApellido = new Libreria.errorTextBox();
            this.textTipoDoc = new Libreria.errorTextBox();
            this.textDni = new Libreria.errorTextBox();
            this.textTelefono = new Libreria.errorTextBox();
            this.textFechaNac = new Libreria.errorTextBox();
            this.textMail = new Libreria.errorTextBox();
            this.textDireccion = new Libreria.errorTextBox();
            this.errorTextBox = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbmPlanMed = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese aqui sus datos:";
            // 
            // cmbEstadoCivil
            // 
            this.cmbEstadoCivil.FormattingEnabled = true;
            this.cmbEstadoCivil.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Concubinato",
            "Divorciado/a",
            "Viudo/a"});
            this.cmbEstadoCivil.Location = new System.Drawing.Point(83, 254);
            this.cmbEstadoCivil.Name = "cmbEstadoCivil";
            this.cmbEstadoCivil.Size = new System.Drawing.Size(130, 21);
            this.cmbEstadoCivil.TabIndex = 8;
            this.cmbEstadoCivil.Tag = "";
            this.cmbEstadoCivil.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoCivil_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "DNI:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dirección:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Teléfono:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 40);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fecha de Nacimiento:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sexo:";
            // 
            // cmbSexo
            // 
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbSexo.Location = new System.Drawing.Point(84, 227);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(130, 21);
            this.cmbSexo.TabIndex = 7;
            this.cmbSexo.SelectedIndexChanged += new System.EventHandler(this.cmbSexo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Estado Civil:";
            // 
            // chkHijos
            // 
            this.chkHijos.AutoSize = true;
            this.chkHijos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHijos.Location = new System.Drawing.Point(11, 287);
            this.chkHijos.Name = "chkHijos";
            this.chkHijos.Size = new System.Drawing.Size(91, 17);
            this.chkHijos.TabIndex = 17;
            this.chkHijos.Text = "¿Tiene Hijos?";
            this.chkHijos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHijos.UseVisualStyleBackColor = true;
            this.chkHijos.CheckedChanged += new System.EventHandler(this.chkHijos_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(108, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Cantidad:";
            // 
            // txtCantHijos
            // 
            this.txtCantHijos.Enabled = false;
            this.txtCantHijos.Location = new System.Drawing.Point(166, 281);
            this.txtCantHijos.Name = "txtCantHijos";
            this.txtCantHijos.Size = new System.Drawing.Size(45, 20);
            this.txtCantHijos.TabIndex = 19;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(296, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(106, 20);
            this.textBox2.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(226, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Afiliado Nro:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(226, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Plan Médico:";
            // 
            // btnCargaHijos
            // 
            this.btnCargaHijos.Enabled = false;
            this.btnCargaHijos.Location = new System.Drawing.Point(241, 288);
            this.btnCargaHijos.Name = "btnCargaHijos";
            this.btnCargaHijos.Size = new System.Drawing.Size(82, 21);
            this.btnCargaHijos.TabIndex = 24;
            this.btnCargaHijos.Text = "Cargar hijos";
            this.btnCargaHijos.UseVisualStyleBackColor = true;
            // 
            // btnCargaPareja
            // 
            this.btnCargaPareja.Enabled = false;
            this.btnCargaPareja.Location = new System.Drawing.Point(241, 254);
            this.btnCargaPareja.Name = "btnCargaPareja";
            this.btnCargaPareja.Size = new System.Drawing.Size(82, 21);
            this.btnCargaPareja.TabIndex = 25;
            this.btnCargaPareja.Text = "Cargar pareja";
            this.btnCargaPareja.UseVisualStyleBackColor = true;
            this.btnCargaPareja.Click += new System.EventHandler(this.btnCargaPareja_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(12, 371);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 23);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label13.Location = new System.Drawing.Point(9, 331);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(347, 28);
            this.label13.TabIndex = 27;
            this.label13.Text = "Una vez haya terminado de cargar todos sus datos y de su grupo,\r\nHaga clic en sig" +
    "uiente para continuar.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(327, 371);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 206);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Mail:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 83);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Tipo Doc:";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(70, 38);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(100, 20);
            this.textNombre.TabIndex = 35;
            this.textNombre.Validar = true;
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(70, 61);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(100, 20);
            this.textApellido.TabIndex = 36;
            this.textApellido.Validar = true;
            // 
            // textTipoDoc
            // 
            this.textTipoDoc.Location = new System.Drawing.Point(70, 83);
            this.textTipoDoc.Name = "textTipoDoc";
            this.textTipoDoc.Size = new System.Drawing.Size(100, 20);
            this.textTipoDoc.TabIndex = 37;
            this.textTipoDoc.Validar = true;
            // 
            // textDni
            // 
            this.textDni.Location = new System.Drawing.Point(70, 105);
            this.textDni.Name = "textDni";
            this.textDni.Size = new System.Drawing.Size(100, 20);
            this.textDni.TabIndex = 38;
            this.textDni.Validar = true;
            // 
            // textTelefono
            // 
            this.textTelefono.Location = new System.Drawing.Point(77, 151);
            this.textTelefono.Name = "textTelefono";
            this.textTelefono.Size = new System.Drawing.Size(100, 20);
            this.textTelefono.TabIndex = 39;
            this.textTelefono.Validar = true;
            // 
            // textFechaNac
            // 
            this.textFechaNac.Location = new System.Drawing.Point(81, 175);
            this.textFechaNac.Name = "textFechaNac";
            this.textFechaNac.Size = new System.Drawing.Size(100, 20);
            this.textFechaNac.TabIndex = 40;
            this.textFechaNac.Validar = true;
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(86, 200);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(100, 20);
            this.textMail.TabIndex = 41;
            this.textMail.Validar = true;
            // 
            // textDireccion
            // 
            this.textDireccion.Location = new System.Drawing.Point(72, 128);
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(100, 20);
            this.textDireccion.TabIndex = 42;
            this.textDireccion.Validar = true;
            // 
            // errorTextBox
            // 
            this.errorTextBox.ContainerControl = this;
            // 
            // cbmPlanMed
            // 
            this.cbmPlanMed.FormattingEnabled = true;
            this.cbmPlanMed.Location = new System.Drawing.Point(296, 73);
            this.cbmPlanMed.Name = "cbmPlanMed";
            this.cbmPlanMed.Size = new System.Drawing.Size(106, 21);
            this.cbmPlanMed.TabIndex = 43;
            // 
            // frmAltaAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 419);
            this.Controls.Add(this.cbmPlanMed);
            this.Controls.Add(this.textDireccion);
            this.Controls.Add(this.textMail);
            this.Controls.Add(this.textFechaNac);
            this.Controls.Add(this.textTelefono);
            this.Controls.Add(this.textDni);
            this.Controls.Add(this.textTipoDoc);
            this.Controls.Add(this.textApellido);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCargaPareja);
            this.Controls.Add(this.btnCargaHijos);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtCantHijos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkHijos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEstadoCivil);
            this.Controls.Add(this.label1);
            this.Name = "frmAltaAfiliado";
            this.Text = "Alta Afiliado";
            this.Load += new System.EventHandler(this.frmAltaAfiliado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEstadoCivil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkHijos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCantHijos;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCargaHijos;
        private System.Windows.Forms.Button btnCargaPareja;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private Libreria.errorTextBox textNombre;
        private Libreria.errorTextBox textApellido;
        private Libreria.errorTextBox textTipoDoc;
        private Libreria.errorTextBox textDni;
        private Libreria.errorTextBox textTelefono;
        private Libreria.errorTextBox textFechaNac;
        private Libreria.errorTextBox textMail;
        private Libreria.errorTextBox textDireccion;
        public System.Windows.Forms.ErrorProvider errorTextBox;
        private System.Windows.Forms.ComboBox cbmPlanMed;
    }
}