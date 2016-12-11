namespace ClinicaFrba
{
    partial class HomeAfiliado
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
            this.btnComprar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBonosDisponibles = new System.Windows.Forms.TextBox();
            this.lblBonos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelarDia = new System.Windows.Forms.Button();
            this.btnRegAtencion = new System.Windows.Forms.Button();
            this.btnModifAfil = new System.Windows.Forms.Button();
            this.btnRestituir = new System.Windows.Forms.Button();
            this.btnBajaAfil = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnCambiarPlan = new System.Windows.Forms.Button();
            this.btnAbmRol = new System.Windows.Forms.Button();
            this.btnRegistrarLlegada = new System.Windows.Forms.Button();
            this.btnAltaAfiliado = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(265, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "◉‿◉     Seleccione que desea realizar     ◉‿◉\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnComprar.Location = new System.Drawing.Point(169, 56);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(122, 23);
            this.btnComprar.TabIndex = 2;
            this.btnComprar.Text = "Comprar Bono";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(10, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bienvenido: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtBonosDisponibles
            // 
            this.txtBonosDisponibles.Location = new System.Drawing.Point(112, 58);
            this.txtBonosDisponibles.Name = "txtBonosDisponibles";
            this.txtBonosDisponibles.Size = new System.Drawing.Size(51, 20);
            this.txtBonosDisponibles.TabIndex = 5;
            this.txtBonosDisponibles.TextChanged += new System.EventHandler(this.txtBonosDisponibles_TextChanged);
            // 
            // lblBonos
            // 
            this.lblBonos.AutoSize = true;
            this.lblBonos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblBonos.Location = new System.Drawing.Point(10, 61);
            this.lblBonos.Name = "lblBonos";
            this.lblBonos.Size = new System.Drawing.Size(94, 13);
            this.lblBonos.TabIndex = 6;
            this.lblBonos.Text = "Bonos Disponibles";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(71, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 20);
            this.label3.TabIndex = 7;
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(13, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Solicitar Turno";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button2.Location = new System.Drawing.Point(13, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar Turno";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(488, 293);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(93, 23);
            this.btnCerrar.TabIndex = 26;
            this.btnCerrar.Text = "Cerrar Sesion";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCancelarDia
            // 
            this.btnCancelarDia.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelarDia.Location = new System.Drawing.Point(446, 153);
            this.btnCancelarDia.Name = "btnCancelarDia";
            this.btnCancelarDia.Size = new System.Drawing.Size(136, 23);
            this.btnCancelarDia.TabIndex = 59;
            this.btnCancelarDia.Text = "Cancelar Día";
            this.btnCancelarDia.UseVisualStyleBackColor = true;
            this.btnCancelarDia.Visible = false;
            this.btnCancelarDia.Click += new System.EventHandler(this.btnCancelarDia_Click);
            // 
            // btnRegAtencion
            // 
            this.btnRegAtencion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRegAtencion.Location = new System.Drawing.Point(445, 126);
            this.btnRegAtencion.Name = "btnRegAtencion";
            this.btnRegAtencion.Size = new System.Drawing.Size(136, 23);
            this.btnRegAtencion.TabIndex = 58;
            this.btnRegAtencion.Text = "Registrar Atencion";
            this.btnRegAtencion.UseVisualStyleBackColor = true;
            this.btnRegAtencion.Visible = false;
            this.btnRegAtencion.Click += new System.EventHandler(this.btnRegAtencion_Click);
            // 
            // btnModifAfil
            // 
            this.btnModifAfil.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnModifAfil.Location = new System.Drawing.Point(303, 155);
            this.btnModifAfil.Name = "btnModifAfil";
            this.btnModifAfil.Size = new System.Drawing.Size(136, 23);
            this.btnModifAfil.TabIndex = 57;
            this.btnModifAfil.Text = "Modificar Afiliado";
            this.btnModifAfil.UseVisualStyleBackColor = true;
            this.btnModifAfil.Visible = false;
            this.btnModifAfil.Click += new System.EventHandler(this.btnModifAfil_Click);
            // 
            // btnRestituir
            // 
            this.btnRestituir.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRestituir.Location = new System.Drawing.Point(302, 213);
            this.btnRestituir.Name = "btnRestituir";
            this.btnRestituir.Size = new System.Drawing.Size(136, 23);
            this.btnRestituir.TabIndex = 56;
            this.btnRestituir.Text = "Restituir Afiliado";
            this.btnRestituir.UseVisualStyleBackColor = true;
            this.btnRestituir.Visible = false;
            this.btnRestituir.Click += new System.EventHandler(this.btnRestituir_Click);
            // 
            // btnBajaAfil
            // 
            this.btnBajaAfil.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnBajaAfil.Location = new System.Drawing.Point(303, 184);
            this.btnBajaAfil.Name = "btnBajaAfil";
            this.btnBajaAfil.Size = new System.Drawing.Size(136, 23);
            this.btnBajaAfil.TabIndex = 55;
            this.btnBajaAfil.Text = "Baja Afiliado";
            this.btnBajaAfil.UseVisualStyleBackColor = true;
            this.btnBajaAfil.Visible = false;
            this.btnBajaAfil.Click += new System.EventHandler(this.btnBajaAfil_Click);
            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnEstadisticas.Location = new System.Drawing.Point(302, 97);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Size = new System.Drawing.Size(136, 23);
            this.btnEstadisticas.TabIndex = 52;
            this.btnEstadisticas.Text = "Ver Estadisticas";
            this.btnEstadisticas.UseVisualStyleBackColor = true;
            this.btnEstadisticas.Visible = false;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);
            // 
            // btnCambiarPlan
            // 
            this.btnCambiarPlan.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCambiarPlan.Location = new System.Drawing.Point(155, 97);
            this.btnCambiarPlan.Name = "btnCambiarPlan";
            this.btnCambiarPlan.Size = new System.Drawing.Size(135, 23);
            this.btnCambiarPlan.TabIndex = 50;
            this.btnCambiarPlan.Text = "Cambiar Plan";
            this.btnCambiarPlan.UseVisualStyleBackColor = true;
            this.btnCambiarPlan.Visible = false;
            this.btnCambiarPlan.Click += new System.EventHandler(this.btnCambiarPlan_Click);
            // 
            // btnAbmRol
            // 
            this.btnAbmRol.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAbmRol.Location = new System.Drawing.Point(155, 126);
            this.btnAbmRol.Name = "btnAbmRol";
            this.btnAbmRol.Size = new System.Drawing.Size(136, 23);
            this.btnAbmRol.TabIndex = 48;
            this.btnAbmRol.Text = "Menu Rol";
            this.btnAbmRol.UseVisualStyleBackColor = true;
            this.btnAbmRol.Visible = false;
            this.btnAbmRol.Click += new System.EventHandler(this.btnAbmRol_Click);
            // 
            // btnRegistrarLlegada
            // 
            this.btnRegistrarLlegada.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRegistrarLlegada.Location = new System.Drawing.Point(446, 97);
            this.btnRegistrarLlegada.Name = "btnRegistrarLlegada";
            this.btnRegistrarLlegada.Size = new System.Drawing.Size(136, 23);
            this.btnRegistrarLlegada.TabIndex = 46;
            this.btnRegistrarLlegada.Text = "Registrar Llegada";
            this.btnRegistrarLlegada.UseVisualStyleBackColor = true;
            this.btnRegistrarLlegada.Visible = false;
            this.btnRegistrarLlegada.Click += new System.EventHandler(this.btnRegistrarLlegada_Click);
            // 
            // btnAltaAfiliado
            // 
            this.btnAltaAfiliado.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAltaAfiliado.Location = new System.Drawing.Point(303, 126);
            this.btnAltaAfiliado.Name = "btnAltaAfiliado";
            this.btnAltaAfiliado.Size = new System.Drawing.Size(136, 23);
            this.btnAltaAfiliado.TabIndex = 45;
            this.btnAltaAfiliado.Text = "Alta Nuevo Afiliado";
            this.btnAltaAfiliado.UseVisualStyleBackColor = true;
            this.btnAltaAfiliado.Visible = false;
            this.btnAltaAfiliado.Click += new System.EventHandler(this.btnAltaAfiliado_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRegistrar.Location = new System.Drawing.Point(446, 184);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(136, 23);
            this.btnRegistrar.TabIndex = 76;
            this.btnRegistrar.Text = "Registrar Diagnostico";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Visible = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // HomeAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClinicaFrba.Properties.Resources._39929033_Sillas_de_colores_y_cinco_relojes_diferentes_en_la_sala_de_espera_Foto_de_archivo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(594, 328);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnCancelarDia);
            this.Controls.Add(this.btnRegAtencion);
            this.Controls.Add(this.btnModifAfil);
            this.Controls.Add(this.btnRestituir);
            this.Controls.Add(this.btnBajaAfil);
            this.Controls.Add(this.btnEstadisticas);
            this.Controls.Add(this.btnCambiarPlan);
            this.Controls.Add(this.btnAbmRol);
            this.Controls.Add(this.btnRegistrarLlegada);
            this.Controls.Add(this.btnAltaAfiliado);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBonos);
            this.Controls.Add(this.txtBonosDisponibles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.label1);
            this.Name = "HomeAfiliado";
            this.Text = "Panel de Control Afiliado";
            this.Load += new System.EventHandler(this.HomeAfiliado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBonosDisponibles;
        private System.Windows.Forms.Label lblBonos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCancelarDia;
        private System.Windows.Forms.Button btnRegAtencion;
        private System.Windows.Forms.Button btnModifAfil;
        private System.Windows.Forms.Button btnRestituir;
        private System.Windows.Forms.Button btnBajaAfil;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnCambiarPlan;
        private System.Windows.Forms.Button btnAbmRol;
        private System.Windows.Forms.Button btnRegistrarLlegada;
        private System.Windows.Forms.Button btnAltaAfiliado;
        private System.Windows.Forms.Button btnRegistrar;
    }
}