namespace ClinicaFrba.Abm_Afiliado
{
    partial class AltaFamiliar
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
            this.NroAfiliadoPrincipal = new Libreria.errorTextBox();
            this.btnAltaConyuge = new System.Windows.Forms.Button();
            this.btnAltaHijo = new System.Windows.Forms.Button();
            this.errorAlta = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorAlta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingresar Nro Afiliado Principal:";
            // 
            // NroAfiliadoPrincipal
            // 
            this.NroAfiliadoPrincipal.Location = new System.Drawing.Point(167, 31);
            this.NroAfiliadoPrincipal.Name = "NroAfiliadoPrincipal";
            this.NroAfiliadoPrincipal.Size = new System.Drawing.Size(100, 20);
            this.NroAfiliadoPrincipal.TabIndex = 2;
            this.NroAfiliadoPrincipal.Validar = true;
            this.NroAfiliadoPrincipal.TextChanged += new System.EventHandler(this.NroAfiliadoPrincipal_TextChanged);
            // 
            // btnAltaConyuge
            // 
            this.btnAltaConyuge.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAltaConyuge.Location = new System.Drawing.Point(76, 107);
            this.btnAltaConyuge.Name = "btnAltaConyuge";
            this.btnAltaConyuge.Size = new System.Drawing.Size(84, 23);
            this.btnAltaConyuge.TabIndex = 3;
            this.btnAltaConyuge.Text = "Alta Conyuge";
            this.btnAltaConyuge.UseVisualStyleBackColor = true;
            this.btnAltaConyuge.Click += new System.EventHandler(this.btnAltaConyuge_Click);
            // 
            // btnAltaHijo
            // 
            this.btnAltaHijo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAltaHijo.Location = new System.Drawing.Point(192, 107);
            this.btnAltaHijo.Name = "btnAltaHijo";
            this.btnAltaHijo.Size = new System.Drawing.Size(75, 23);
            this.btnAltaHijo.TabIndex = 4;
            this.btnAltaHijo.Text = "Alta Hijo";
            this.btnAltaHijo.UseVisualStyleBackColor = true;
            this.btnAltaHijo.Click += new System.EventHandler(this.btnAltaHijo_Click);
            // 
            // errorAlta
            // 
            this.errorAlta.ContainerControl = this;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(166, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "¿Dar alta Hijos?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(15, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ir Atrás";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AltaFamiliar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(284, 196);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnAltaHijo);
            this.Controls.Add(this.btnAltaConyuge);
            this.Controls.Add(this.NroAfiliadoPrincipal);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "AltaFamiliar";
            this.Text = "AltaFamiliar";
            this.Load += new System.EventHandler(this.AltaFamiliar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorAlta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Libreria.errorTextBox NroAfiliadoPrincipal;
        private System.Windows.Forms.Button btnAltaConyuge;
        private System.Windows.Forms.Button btnAltaHijo;
        private System.Windows.Forms.ErrorProvider errorAlta;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
    }
}