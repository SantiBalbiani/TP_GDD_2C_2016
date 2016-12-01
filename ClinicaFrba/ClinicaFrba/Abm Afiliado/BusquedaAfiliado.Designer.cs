namespace ClinicaFrba.Abm_Afiliado
{
    partial class BusquedaAfiliado
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
            this.button1 = new System.Windows.Forms.Button();
            this.nroAfiliadoPrincipal = new System.Windows.Forms.TextBox();
            this.checkHijos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresar Nro Afiliado Principal:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(168, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nroAfiliadoPrincipal
            // 
            this.nroAfiliadoPrincipal.Location = new System.Drawing.Point(168, 25);
            this.nroAfiliadoPrincipal.Name = "nroAfiliadoPrincipal";
            this.nroAfiliadoPrincipal.Size = new System.Drawing.Size(100, 20);
            this.nroAfiliadoPrincipal.TabIndex = 2;
            // 
            // checkHijos
            // 
            this.checkHijos.AutoSize = true;
            this.checkHijos.Location = new System.Drawing.Point(168, 52);
            this.checkHijos.Name = "checkHijos";
            this.checkHijos.Size = new System.Drawing.Size(49, 17);
            this.checkHijos.TabIndex = 3;
            this.checkHijos.Text = "Hijos";
            this.checkHijos.UseVisualStyleBackColor = true;
            this.checkHijos.CheckedChanged += new System.EventHandler(this.checkHijos_CheckedChanged);
            // 
            // BusquedaAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(296, 141);
            this.Controls.Add(this.checkHijos);
            this.Controls.Add(this.nroAfiliadoPrincipal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "BusquedaAfiliado";
            this.Text = "BusquedaAfiliado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nroAfiliadoPrincipal;
        private System.Windows.Forms.CheckBox checkHijos;
    }
}