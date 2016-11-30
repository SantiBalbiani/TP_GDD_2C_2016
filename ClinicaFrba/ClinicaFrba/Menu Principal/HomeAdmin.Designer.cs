namespace ClinicaFrba.Menu_Principal
{
    partial class HomeAdmin
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
            this.btnAltaAfiliado = new System.Windows.Forms.Button();
            this.btnAgregarFamiliar = new System.Windows.Forms.Button();
            this.btnRegistrarLlegada = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAbmRol = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCambiarPlan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAltaAfiliado
            // 
            this.btnAltaAfiliado.Location = new System.Drawing.Point(446, 190);
            this.btnAltaAfiliado.Name = "btnAltaAfiliado";
            this.btnAltaAfiliado.Size = new System.Drawing.Size(136, 23);
            this.btnAltaAfiliado.TabIndex = 11;
            this.btnAltaAfiliado.Text = "Alta Nuevo Afiliado";
            this.btnAltaAfiliado.UseVisualStyleBackColor = true;
            this.btnAltaAfiliado.Click += new System.EventHandler(this.btnAltaAfiliado_Click);
            // 
            // btnAgregarFamiliar
            // 
            this.btnAgregarFamiliar.Location = new System.Drawing.Point(446, 224);
            this.btnAgregarFamiliar.Name = "btnAgregarFamiliar";
            this.btnAgregarFamiliar.Size = new System.Drawing.Size(136, 23);
            this.btnAgregarFamiliar.TabIndex = 13;
            this.btnAgregarFamiliar.Text = "Alta Familiar de Afiliado ";
            this.btnAgregarFamiliar.UseVisualStyleBackColor = true;
            this.btnAgregarFamiliar.Click += new System.EventHandler(this.btnAgregarFamiliar_Click);
            // 
            // btnRegistrarLlegada
            // 
            this.btnRegistrarLlegada.Location = new System.Drawing.Point(304, 190);
            this.btnRegistrarLlegada.Name = "btnRegistrarLlegada";
            this.btnRegistrarLlegada.Size = new System.Drawing.Size(136, 23);
            this.btnRegistrarLlegada.TabIndex = 14;
            this.btnRegistrarLlegada.Text = "Registrar Llegada";
            this.btnRegistrarLlegada.UseVisualStyleBackColor = true;
            this.btnRegistrarLlegada.Click += new System.EventHandler(this.btnRegistrarLlegada_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Comprar Bono";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAbmRol
            // 
            this.btnAbmRol.Location = new System.Drawing.Point(446, 64);
            this.btnAbmRol.Name = "btnAbmRol";
            this.btnAbmRol.Size = new System.Drawing.Size(136, 23);
            this.btnAbmRol.TabIndex = 16;
            this.btnAbmRol.Text = "Menu Rol";
            this.btnAbmRol.UseVisualStyleBackColor = true;
            this.btnAbmRol.Click += new System.EventHandler(this.btnAbmRol_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 221);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Operaciones por Afiliado";
            // 
            // btnCambiarPlan
            // 
            this.btnCambiarPlan.Location = new System.Drawing.Point(155, 276);
            this.btnCambiarPlan.Name = "btnCambiarPlan";
            this.btnCambiarPlan.Size = new System.Drawing.Size(135, 23);
            this.btnCambiarPlan.TabIndex = 19;
            this.btnCambiarPlan.Text = "Cambiar Plan";
            this.btnCambiarPlan.UseVisualStyleBackColor = true;
            this.btnCambiarPlan.Click += new System.EventHandler(this.btnCambiarPlan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ingrese Numero de Afiliado:\r\n";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(265, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "◉‿◉     Seleccione que desea realizar     ◉‿◉\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(71, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 20);
            this.label2.TabIndex = 22;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Bienvenido: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Location = new System.Drawing.Point(446, 93);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(136, 23);
            this.btnEstadisticas.TabIndex = 24;
            this.btnEstadisticas.Text = "Ver Estadisticas";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(489, 293);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(93, 23);
            this.btnCerrar.TabIndex = 25;
            this.btnCerrar.Text = "Cerrar Sesion";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // HomeAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClinicaFrba.Properties.Resources.clinica_la_arruzafa_doctores;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(594, 328);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEstadisticas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCambiarPlan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAbmRol);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRegistrarLlegada);
            this.Controls.Add(this.btnAgregarFamiliar);
            this.Controls.Add(this.btnAltaAfiliado);
            this.DoubleBuffered = true;
            this.Name = "HomeAdmin";
            this.Text = "Panel de Control Administrativo";
            this.Load += new System.EventHandler(this.HomeAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAltaAfiliado;
        private System.Windows.Forms.Button btnAgregarFamiliar;
        private System.Windows.Forms.Button btnRegistrarLlegada;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAbmRol;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCambiarPlan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnCerrar;
    }
}