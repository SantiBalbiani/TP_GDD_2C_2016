namespace ClinicaFrba.Abm_Afiliado
{
    partial class AltaHijo
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.PlanMedHijo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tipoDocHijo = new Libreria.errorTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nombreHijo = new Libreria.errorTextBox();
            this.apellidoHijo = new Libreria.errorTextBox();
            this.nroDocHijo = new Libreria.errorTextBox();
            this.direccionHijo = new Libreria.errorTextBox();
            this.mailHijo = new Libreria.errorTextBox();
            this.telefonoHijo = new Libreria.errorTextBox();
            this.fechaNacHijo = new Libreria.errorTextBox();
            this.cmbSexoHijo = new System.Windows.Forms.ComboBox();
            this.errorTextBoxHijo = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbEstadoCivilHijo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.otro = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBoxHijo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(327, 336);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 47;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 301);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(234, 28);
            this.label13.TabIndex = 46;
            this.label13.Text = "Una vez haya terminado de cargar su pareja\r\nhaga clic en guardar para volver atrá" +
    "s";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // PlanMedHijo
            // 
            this.PlanMedHijo.Enabled = false;
            this.PlanMedHijo.Location = new System.Drawing.Point(304, 24);
            this.PlanMedHijo.Name = "PlanMedHijo";
            this.PlanMedHijo.Size = new System.Drawing.Size(95, 20);
            this.PlanMedHijo.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Sexo:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(15, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 40);
            this.label7.TabIndex = 42;
            this.label7.Text = "Fecha de Nacimiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Teléfono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Dirección:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "DNI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-21, -15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Ingrese aqui sus datos:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(225, 336);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.TabIndex = 48;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(229, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "Plan Médico:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Tipo Doc:";
            // 
            // tipoDocHijo
            // 
            this.tipoDocHijo.Location = new System.Drawing.Point(82, 88);
            this.tipoDocHijo.Name = "tipoDocHijo";
            this.tipoDocHijo.Size = new System.Drawing.Size(100, 20);
            this.tipoDocHijo.TabIndex = 51;
            this.tipoDocHijo.Validar = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Mail:";
            // 
            // nombreHijo
            // 
            this.nombreHijo.Location = new System.Drawing.Point(82, 29);
            this.nombreHijo.Name = "nombreHijo";
            this.nombreHijo.Size = new System.Drawing.Size(100, 20);
            this.nombreHijo.TabIndex = 53;
            this.nombreHijo.Validar = true;
            // 
            // apellidoHijo
            // 
            this.apellidoHijo.Location = new System.Drawing.Point(82, 58);
            this.apellidoHijo.Name = "apellidoHijo";
            this.apellidoHijo.Size = new System.Drawing.Size(100, 20);
            this.apellidoHijo.TabIndex = 54;
            this.apellidoHijo.Validar = true;
            // 
            // nroDocHijo
            // 
            this.nroDocHijo.Location = new System.Drawing.Point(82, 115);
            this.nroDocHijo.Name = "nroDocHijo";
            this.nroDocHijo.Size = new System.Drawing.Size(100, 20);
            this.nroDocHijo.TabIndex = 55;
            this.nroDocHijo.Validar = true;
            // 
            // direccionHijo
            // 
            this.direccionHijo.Location = new System.Drawing.Point(81, 142);
            this.direccionHijo.Name = "direccionHijo";
            this.direccionHijo.Size = new System.Drawing.Size(100, 20);
            this.direccionHijo.TabIndex = 56;
            this.direccionHijo.Validar = true;
            // 
            // mailHijo
            // 
            this.mailHijo.Location = new System.Drawing.Point(81, 170);
            this.mailHijo.Name = "mailHijo";
            this.mailHijo.Size = new System.Drawing.Size(100, 20);
            this.mailHijo.TabIndex = 57;
            this.mailHijo.Validar = true;
            // 
            // telefonoHijo
            // 
            this.telefonoHijo.Location = new System.Drawing.Point(81, 195);
            this.telefonoHijo.Name = "telefonoHijo";
            this.telefonoHijo.Size = new System.Drawing.Size(100, 20);
            this.telefonoHijo.TabIndex = 58;
            this.telefonoHijo.Validar = true;
            // 
            // fechaNacHijo
            // 
            this.fechaNacHijo.Location = new System.Drawing.Point(81, 222);
            this.fechaNacHijo.Name = "fechaNacHijo";
            this.fechaNacHijo.Size = new System.Drawing.Size(100, 20);
            this.fechaNacHijo.TabIndex = 59;
            this.fechaNacHijo.Validar = true;
            // 
            // cmbSexoHijo
            // 
            this.cmbSexoHijo.FormattingEnabled = true;
            this.cmbSexoHijo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbSexoHijo.Location = new System.Drawing.Point(81, 250);
            this.cmbSexoHijo.Name = "cmbSexoHijo";
            this.cmbSexoHijo.Size = new System.Drawing.Size(130, 21);
            this.cmbSexoHijo.TabIndex = 60;
            // 
            // errorTextBoxHijo
            // 
            this.errorTextBoxHijo.ContainerControl = this;
            // 
            // cmbEstadoCivilHijo
            // 
            this.cmbEstadoCivilHijo.FormattingEnabled = true;
            this.cmbEstadoCivilHijo.Items.AddRange(new object[] {
            "Soltero/a",
            "Casado/a",
            "Concubinato",
            "Divorciado/a",
            "Viudo/a"});
            this.cmbEstadoCivilHijo.Location = new System.Drawing.Point(81, 277);
            this.cmbEstadoCivilHijo.Name = "cmbEstadoCivilHijo";
            this.cmbEstadoCivilHijo.Size = new System.Drawing.Size(130, 21);
            this.cmbEstadoCivilHijo.TabIndex = 61;
            this.cmbEstadoCivilHijo.Tag = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 62;
            this.label11.Text = "Estado Civil:";
            // 
            // otro
            // 
            this.otro.AutoSize = true;
            this.otro.Location = new System.Drawing.Point(67, 341);
            this.otro.Name = "otro";
            this.otro.Size = new System.Drawing.Size(151, 17);
            this.otro.TabIndex = 63;
            this.otro.Text = "¿Desea Agregar otro Hijo?";
            this.otro.UseVisualStyleBackColor = true;
            this.otro.CheckedChanged += new System.EventHandler(this.otro_CheckedChanged);
            // 
            // AltaHijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 373);
            this.Controls.Add(this.otro);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbEstadoCivilHijo);
            this.Controls.Add(this.cmbSexoHijo);
            this.Controls.Add(this.fechaNacHijo);
            this.Controls.Add(this.telefonoHijo);
            this.Controls.Add(this.mailHijo);
            this.Controls.Add(this.direccionHijo);
            this.Controls.Add(this.nroDocHijo);
            this.Controls.Add(this.apellidoHijo);
            this.Controls.Add(this.nombreHijo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tipoDocHijo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.PlanMedHijo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaHijo";
            this.Text = "Alta Familiar";
            this.Load += new System.EventHandler(this.AltaHijo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBoxHijo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox PlanMedHijo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private Libreria.errorTextBox tipoDocHijo;
        private System.Windows.Forms.Label label10;
        private Libreria.errorTextBox nombreHijo;
        private Libreria.errorTextBox apellidoHijo;
        private Libreria.errorTextBox nroDocHijo;
        private Libreria.errorTextBox direccionHijo;
        private Libreria.errorTextBox mailHijo;
        private Libreria.errorTextBox telefonoHijo;
        private Libreria.errorTextBox fechaNacHijo;
        private System.Windows.Forms.ComboBox cmbSexoHijo;
        private System.Windows.Forms.ErrorProvider errorTextBoxHijo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbEstadoCivilHijo;
        private System.Windows.Forms.CheckBox otro;
    }
}