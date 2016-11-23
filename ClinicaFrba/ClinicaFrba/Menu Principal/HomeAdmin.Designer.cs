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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAltaAfiliado = new System.Windows.Forms.Button();
            this.btnAgregarParejaAfiliado = new System.Windows.Forms.Button();
            this.btnAgregarFamiliar = new System.Windows.Forms.Button();
            this.btnRegistrarLlegada = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAbmRol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bienvenido";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(180, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "◉‿◉     Seleccione que desea realizar     ◉‿◉\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAltaAfiliado
            // 
            this.btnAltaAfiliado.Location = new System.Drawing.Point(12, 87);
            this.btnAltaAfiliado.Name = "btnAltaAfiliado";
            this.btnAltaAfiliado.Size = new System.Drawing.Size(145, 23);
            this.btnAltaAfiliado.TabIndex = 11;
            this.btnAltaAfiliado.Text = "Alta Nuevo Afiliado";
            this.btnAltaAfiliado.UseVisualStyleBackColor = true;
            this.btnAltaAfiliado.Click += new System.EventHandler(this.btnAltaAfiliado_Click);
            // 
            // btnAgregarParejaAfiliado
            // 
            this.btnAgregarParejaAfiliado.Location = new System.Drawing.Point(163, 87);
            this.btnAgregarParejaAfiliado.Name = "btnAgregarParejaAfiliado";
            this.btnAgregarParejaAfiliado.Size = new System.Drawing.Size(145, 23);
            this.btnAgregarParejaAfiliado.TabIndex = 12;
            this.btnAgregarParejaAfiliado.Text = "Alta Conyugue de Afiliado ";
            this.btnAgregarParejaAfiliado.UseVisualStyleBackColor = true;
            this.btnAgregarParejaAfiliado.Click += new System.EventHandler(this.btnAgregarParejaAfiliado_Click);
            // 
            // btnAgregarFamiliar
            // 
            this.btnAgregarFamiliar.Location = new System.Drawing.Point(163, 116);
            this.btnAgregarFamiliar.Name = "btnAgregarFamiliar";
            this.btnAgregarFamiliar.Size = new System.Drawing.Size(145, 23);
            this.btnAgregarFamiliar.TabIndex = 13;
            this.btnAgregarFamiliar.Text = "Alta Familiar de Afiliado ";
            this.btnAgregarFamiliar.UseVisualStyleBackColor = true;
            this.btnAgregarFamiliar.Click += new System.EventHandler(this.btnAgregarFamiliar_Click);
            // 
            // btnRegistrarLlegada
            // 
            this.btnRegistrarLlegada.Location = new System.Drawing.Point(12, 152);
            this.btnRegistrarLlegada.Name = "btnRegistrarLlegada";
            this.btnRegistrarLlegada.Size = new System.Drawing.Size(145, 23);
            this.btnRegistrarLlegada.TabIndex = 14;
            this.btnRegistrarLlegada.Text = "Registrar Llegada";
            this.btnRegistrarLlegada.UseVisualStyleBackColor = true;
            this.btnRegistrarLlegada.Click += new System.EventHandler(this.btnRegistrarLlegada_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Comprar Bono";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAbmRol
            // 
            this.btnAbmRol.Location = new System.Drawing.Point(15, 194);
            this.btnAbmRol.Name = "btnAbmRol";
            this.btnAbmRol.Size = new System.Drawing.Size(145, 23);
            this.btnAbmRol.TabIndex = 16;
            this.btnAbmRol.Text = "Menu Rol";
            this.btnAbmRol.UseVisualStyleBackColor = true;
            this.btnAbmRol.Click += new System.EventHandler(this.btnAbmRol_Click);
            // 
            // HomeAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 328);
            this.Controls.Add(this.btnAbmRol);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRegistrarLlegada);
            this.Controls.Add(this.btnAgregarFamiliar);
            this.Controls.Add(this.btnAgregarParejaAfiliado);
            this.Controls.Add(this.btnAltaAfiliado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HomeAdmin";
            this.Text = "HomeAdmin";
            this.Load += new System.EventHandler(this.HomeAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAltaAfiliado;
        private System.Windows.Forms.Button btnAgregarParejaAfiliado;
        private System.Windows.Forms.Button btnAgregarFamiliar;
        private System.Windows.Forms.Button btnRegistrarLlegada;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAbmRol;
    }
}