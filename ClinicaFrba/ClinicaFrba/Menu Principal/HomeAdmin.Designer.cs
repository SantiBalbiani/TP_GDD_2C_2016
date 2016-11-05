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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAltaAfiliado = new System.Windows.Forms.Button();
            this.btnAgregarParejaAfiliado = new System.Windows.Forms.Button();
            this.btnAgregarFamiliar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(73, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 20);
            this.label3.TabIndex = 10;
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bienvenido: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(267, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "◉‿◉     Seleccione que desea realizar     ◉‿◉\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAltaAfiliado
            // 
            this.btnAltaAfiliado.Location = new System.Drawing.Point(15, 58);
            this.btnAltaAfiliado.Name = "btnAltaAfiliado";
            this.btnAltaAfiliado.Size = new System.Drawing.Size(145, 23);
            this.btnAltaAfiliado.TabIndex = 11;
            this.btnAltaAfiliado.Text = "Alta Nuevo Afiliado";
            this.btnAltaAfiliado.UseVisualStyleBackColor = true;
            this.btnAltaAfiliado.Click += new System.EventHandler(this.btnAltaAfiliado_Click);
            // 
            // btnAgregarParejaAfiliado
            // 
            this.btnAgregarParejaAfiliado.Location = new System.Drawing.Point(15, 87);
            this.btnAgregarParejaAfiliado.Name = "btnAgregarParejaAfiliado";
            this.btnAgregarParejaAfiliado.Size = new System.Drawing.Size(145, 23);
            this.btnAgregarParejaAfiliado.TabIndex = 12;
            this.btnAgregarParejaAfiliado.Text = "Alta Pareja de Afiliado ";
            this.btnAgregarParejaAfiliado.UseVisualStyleBackColor = true;
            this.btnAgregarParejaAfiliado.Click += new System.EventHandler(this.btnAgregarParejaAfiliado_Click);
            // 
            // btnAgregarFamiliar
            // 
            this.btnAgregarFamiliar.Location = new System.Drawing.Point(15, 116);
            this.btnAgregarFamiliar.Name = "btnAgregarFamiliar";
            this.btnAgregarFamiliar.Size = new System.Drawing.Size(145, 23);
            this.btnAgregarFamiliar.TabIndex = 13;
            this.btnAgregarFamiliar.Text = "Alta Familiar de Afiliado ";
            this.btnAgregarFamiliar.UseVisualStyleBackColor = true;
            this.btnAgregarFamiliar.Click += new System.EventHandler(this.btnAgregarFamiliar_Click);
            // 
            // HomeAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 328);
            this.Controls.Add(this.btnAgregarFamiliar);
            this.Controls.Add(this.btnAgregarParejaAfiliado);
            this.Controls.Add(this.btnAltaAfiliado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HomeAdmin";
            this.Text = "HomeAdmin";
            this.Load += new System.EventHandler(this.HomeAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAltaAfiliado;
        private System.Windows.Forms.Button btnAgregarParejaAfiliado;
        private System.Windows.Forms.Button btnAgregarFamiliar;
    }
}