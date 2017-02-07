namespace ClinicaFrba.Abm_Afiliado
{
    partial class BajaAfiliado
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnDarBaja = new System.Windows.Forms.Button();
            this.nroAfiliadoTxtBox = new Libreria.errorTextBox();
            this.errorTextBox = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese el numero de Afiliado a dar de baja:";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button2.Location = new System.Drawing.Point(309, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Ir Atrás";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDarBaja
            // 
            this.btnDarBaja.Location = new System.Drawing.Point(12, 204);
            this.btnDarBaja.Name = "btnDarBaja";
            this.btnDarBaja.Size = new System.Drawing.Size(90, 24);
            this.btnDarBaja.TabIndex = 19;
            this.btnDarBaja.Text = "Baja";
            this.btnDarBaja.UseVisualStyleBackColor = true;
            this.btnDarBaja.Click += new System.EventHandler(this.btnDarBaja_Click);
            // 
            // nroAfiliadoTxtBox
            // 
            this.nroAfiliadoTxtBox.Location = new System.Drawing.Point(227, 80);
            this.nroAfiliadoTxtBox.Name = "nroAfiliadoTxtBox";
            this.nroAfiliadoTxtBox.Size = new System.Drawing.Size(100, 20);
            this.nroAfiliadoTxtBox.TabIndex = 20;
            this.nroAfiliadoTxtBox.Validar = true;
            this.nroAfiliadoTxtBox.TextChanged += new System.EventHandler(this.nroAfiliadoTxtBox_TextChanged);
            this.nroAfiliadoTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nroAfiliadoTxtBox_KeyPress);
            // 
            // errorTextBox
            // 
            this.errorTextBox.ContainerControl = this;
            // 
            // BajaAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(399, 242);
            this.Controls.Add(this.nroAfiliadoTxtBox);
            this.Controls.Add(this.btnDarBaja);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Name = "BajaAfiliado";
            this.Text = "BajaAfiliado";
            this.Load += new System.EventHandler(this.BajaAfiliado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void nroAfiliadoTxtBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (System.Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (System.Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (System.Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDarBaja;
        private Libreria.errorTextBox nroAfiliadoTxtBox;
        private System.Windows.Forms.ErrorProvider errorTextBox;
    }
}