namespace ClinicaFrba.Registro_Llegada
{
    partial class Llegada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Llegada));
            this.btnTurnoProf = new System.Windows.Forms.Button();
            this.txtProfesional = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnCargarProfesionales = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnVerTurnosEspecialidad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNumeroAfiliado = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTurnoProf
            // 
            this.btnTurnoProf.Location = new System.Drawing.Point(511, 91);
            this.btnTurnoProf.Name = "btnTurnoProf";
            this.btnTurnoProf.Size = new System.Drawing.Size(138, 23);
            this.btnTurnoProf.TabIndex = 0;
            this.btnTurnoProf.Text = "Buscar Turnos";
            this.btnTurnoProf.UseVisualStyleBackColor = true;
            this.btnTurnoProf.Click += new System.EventHandler(this.btnTurno_Click);
            // 
            // txtProfesional
            // 
            this.txtProfesional.Location = new System.Drawing.Point(263, 94);
            this.txtProfesional.Name = "txtProfesional";
            this.txtProfesional.Size = new System.Drawing.Size(230, 20);
            this.txtProfesional.TabIndex = 1;
            this.txtProfesional.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Profesional por nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(258, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Buscar Profesional por especialidad";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(263, 151);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(230, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnCargarProfesionales
            // 
            this.btnCargarProfesionales.Location = new System.Drawing.Point(511, 149);
            this.btnCargarProfesionales.Name = "btnCargarProfesionales";
            this.btnCargarProfesionales.Size = new System.Drawing.Size(138, 23);
            this.btnCargarProfesionales.TabIndex = 5;
            this.btnCargarProfesionales.Text = "Cargar Profesionales";
            this.btnCargarProfesionales.UseVisualStyleBackColor = true;
            this.btnCargarProfesionales.Click += new System.EventHandler(this.btnCargarProfesionales_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(263, 209);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(230, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // btnVerTurnosEspecialidad
            // 
            this.btnVerTurnosEspecialidad.Location = new System.Drawing.Point(511, 207);
            this.btnVerTurnosEspecialidad.Name = "btnVerTurnosEspecialidad";
            this.btnVerTurnosEspecialidad.Size = new System.Drawing.Size(138, 23);
            this.btnVerTurnosEspecialidad.TabIndex = 7;
            this.btnVerTurnosEspecialidad.Text = "Buscar Turno";
            this.btnVerTurnosEspecialidad.UseVisualStyleBackColor = true;
            this.btnVerTurnosEspecialidad.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Profesionales Disponibles:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Location = new System.Drawing.Point(15, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(133, 13);
            this.txtNombre.TabIndex = 9;
            this.txtNombre.Text = "NUMERO DE AFILIADO:";
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtNumeroAfiliado
            // 
            this.txtNumeroAfiliado.Location = new System.Drawing.Point(140, 24);
            this.txtNumeroAfiliado.Name = "txtNumeroAfiliado";
            this.txtNumeroAfiliado.Size = new System.Drawing.Size(105, 20);
            this.txtNumeroAfiliado.TabIndex = 10;
            this.txtNumeroAfiliado.TextChanged += new System.EventHandler(this.txtNumeroAfiliado_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(263, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Verificar Bono Disponible";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(263, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Registrar Llegada";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(230, 199);
            this.listBox1.TabIndex = 13;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ok.png");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Verificacion OK";
            this.label4.Visible = false;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "No tiene Bonos Disponibles";
            this.label5.Visible = false;
            // 
            // Llegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 350);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNumeroAfiliado);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnVerTurnosEspecialidad);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.btnCargarProfesionales);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProfesional);
            this.Controls.Add(this.btnTurnoProf);
            this.Name = "Llegada";
            this.Text = "Registrar Llegada";
            this.Load += new System.EventHandler(this.Llegada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTurnoProf;
        private System.Windows.Forms.TextBox txtProfesional;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnCargarProfesionales;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnVerTurnosEspecialidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNumeroAfiliado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}