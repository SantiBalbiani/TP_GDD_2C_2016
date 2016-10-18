namespace ClinicaFrba
{
    partial class ElegirRol
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.comboRoles = new System.Windows.Forms.ComboBox();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(74, 27);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(166, 20);
            this.txtUsuario.TabIndex = 5;
            // 
            // comboRoles
            // 
            this.comboRoles.FormattingEnabled = true;
            this.comboRoles.Items.AddRange(new object[] {
            "Afiliado",
            "Profesional",
            "Administrativo"});
            this.comboRoles.Location = new System.Drawing.Point(74, 53);
            this.comboRoles.Name = "comboRoles";
            this.comboRoles.Size = new System.Drawing.Size(166, 21);
            this.comboRoles.TabIndex = 10;
 //           this.comboRoles.SelectedIndexChanged += new System.EventHandler(this.comboRoles_SelectedIndexChanged);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnContinuar.Location = new System.Drawing.Point(149, 80);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(91, 23);
            this.btnContinuar.TabIndex = 11;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Usuario";
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(28, 60);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(23, 13);
            this.lblRol.TabIndex = 13;
            this.lblRol.Text = "Rol";
            // 
            // ElegirRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 120);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.comboRoles);
            this.Controls.Add(this.txtUsuario);
            this.Name = "ElegirRol";
            this.Text = "Selecionar Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ComboBox comboRoles;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRol;
    }
}