namespace ClinicaFrba.Abm_Afiliado
{
    partial class AltaPareja
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PlanMedPareja = new System.Windows.Forms.TextBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbSexoPareja = new System.Windows.Forms.ComboBox();
            this.nombrePareja = new Libreria.errorTextBox();
            this.apellidoPareja = new Libreria.errorTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tipoDocPareja = new Libreria.errorTextBox();
            this.nroDocPareja = new Libreria.errorTextBox();
            this.direccionPareja = new Libreria.errorTextBox();
            this.telefonoPareja = new Libreria.errorTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mailPareja = new Libreria.errorTextBox();
            this.errorTextBoxPareja = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBoxPareja)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese aqui sus datos:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Apellido:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(47, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "DNI:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dirección:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(24, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Teléfono:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(13, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 40);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fecha de Nacimiento:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(42, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sexo:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(230, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Plan Médico:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // PlanMedPareja
            // 
            this.PlanMedPareja.Enabled = false;
            this.PlanMedPareja.Location = new System.Drawing.Point(305, 42);
            this.PlanMedPareja.Name = "PlanMedPareja";
            this.PlanMedPareja.Size = new System.Drawing.Size(95, 20);
            this.PlanMedPareja.TabIndex = 23;
            this.PlanMedPareja.TextChanged += new System.EventHandler(this.PlanMedPareja_TextChanged);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSiguiente.Location = new System.Drawing.Point(82, 336);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(90, 23);
            this.btnSiguiente.TabIndex = 26;
            this.btnSiguiente.Text = "Ir Atrás";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(9, 298);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(234, 28);
            this.label13.TabIndex = 27;
            this.label13.Text = "Una vez haya terminado de cargar su pareja\r\nhaga clic para volver atrás";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelar.Location = new System.Drawing.Point(328, 336);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbSexoPareja
            // 
            this.cmbSexoPareja.FormattingEnabled = true;
            this.cmbSexoPareja.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbSexoPareja.Location = new System.Drawing.Point(82, 267);
            this.cmbSexoPareja.Name = "cmbSexoPareja";
            this.cmbSexoPareja.Size = new System.Drawing.Size(130, 21);
            this.cmbSexoPareja.TabIndex = 7;
            this.cmbSexoPareja.SelectedIndexChanged += new System.EventHandler(this.cmbSexoPareja_SelectedIndexChanged);
            // 
            // nombrePareja
            // 
            this.nombrePareja.Location = new System.Drawing.Point(83, 49);
            this.nombrePareja.Name = "nombrePareja";
            this.nombrePareja.Size = new System.Drawing.Size(100, 20);
            this.nombrePareja.TabIndex = 29;
            this.nombrePareja.Validar = true;
            this.nombrePareja.TextChanged += new System.EventHandler(this.nombrePareja_TextChanged);
            // 
            // apellidoPareja
            // 
            this.apellidoPareja.Location = new System.Drawing.Point(83, 76);
            this.apellidoPareja.Name = "apellidoPareja";
            this.apellidoPareja.Size = new System.Drawing.Size(100, 20);
            this.apellidoPareja.TabIndex = 30;
            this.apellidoPareja.Validar = true;
            this.apellidoPareja.TextChanged += new System.EventHandler(this.apellidoPareja_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(22, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Tipo Doc:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // tipoDocPareja
            // 
            this.tipoDocPareja.Location = new System.Drawing.Point(82, 103);
            this.tipoDocPareja.Name = "tipoDocPareja";
            this.tipoDocPareja.Size = new System.Drawing.Size(100, 20);
            this.tipoDocPareja.TabIndex = 32;
            this.tipoDocPareja.Validar = true;
            this.tipoDocPareja.TextChanged += new System.EventHandler(this.tipoDocPareja_TextChanged);
            // 
            // nroDocPareja
            // 
            this.nroDocPareja.Location = new System.Drawing.Point(82, 129);
            this.nroDocPareja.Name = "nroDocPareja";
            this.nroDocPareja.Size = new System.Drawing.Size(100, 20);
            this.nroDocPareja.TabIndex = 33;
            this.nroDocPareja.Validar = true;
            this.nroDocPareja.TextChanged += new System.EventHandler(this.nroDocPareja_TextChanged);
            // 
            // direccionPareja
            // 
            this.direccionPareja.Location = new System.Drawing.Point(82, 154);
            this.direccionPareja.Name = "direccionPareja";
            this.direccionPareja.Size = new System.Drawing.Size(100, 20);
            this.direccionPareja.TabIndex = 34;
            this.direccionPareja.Validar = true;
            this.direccionPareja.TextChanged += new System.EventHandler(this.direccionPareja_TextChanged);
            // 
            // telefonoPareja
            // 
            this.telefonoPareja.Location = new System.Drawing.Point(82, 185);
            this.telefonoPareja.Name = "telefonoPareja";
            this.telefonoPareja.Size = new System.Drawing.Size(100, 20);
            this.telefonoPareja.TabIndex = 35;
            this.telefonoPareja.Validar = true;
            this.telefonoPareja.TextChanged += new System.EventHandler(this.telefonoPareja_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(47, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Mail:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // mailPareja
            // 
            this.mailPareja.Location = new System.Drawing.Point(82, 210);
            this.mailPareja.Name = "mailPareja";
            this.mailPareja.Size = new System.Drawing.Size(100, 20);
            this.mailPareja.TabIndex = 39;
            this.mailPareja.Validar = true;
            this.mailPareja.TextChanged += new System.EventHandler(this.mailPareja_TextChanged);
            // 
            // errorTextBoxPareja
            // 
            this.errorTextBoxPareja.ContainerControl = this;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(82, 241);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 65;
            this.dateTimePicker1.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // AltaPareja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(415, 373);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.mailPareja);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.telefonoPareja);
            this.Controls.Add(this.direccionPareja);
            this.Controls.Add(this.nroDocPareja);
            this.Controls.Add(this.tipoDocPareja);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.apellidoPareja);
            this.Controls.Add(this.nombrePareja);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.PlanMedPareja);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbSexoPareja);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaPareja";
            this.Text = "Alta Pareja del Afiliado";
            this.Load += new System.EventHandler(this.AltaPareja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBoxPareja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox PlanMedPareja;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbSexoPareja;
        private Libreria.errorTextBox nombrePareja;
        private Libreria.errorTextBox apellidoPareja;
        private System.Windows.Forms.Label label9;
        private Libreria.errorTextBox tipoDocPareja;
        private Libreria.errorTextBox nroDocPareja;
        private Libreria.errorTextBox direccionPareja;
        private Libreria.errorTextBox telefonoPareja;
        private System.Windows.Forms.Label label10;
        private Libreria.errorTextBox mailPareja;
        private System.Windows.Forms.ErrorProvider errorTextBoxPareja;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}