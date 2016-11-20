namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelacionAfiliado
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
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.TextBox();
            this.lbltipo = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(201, 216);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(192, 79);
            this.txtMotivo.TabIndex = 11;
            // 
            // lblMotivo
            // 
            this.lblMotivo.BackColor = System.Drawing.SystemColors.Control;
            this.lblMotivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMotivo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lblMotivo.Location = new System.Drawing.Point(7, 219);
            this.lblMotivo.Multiline = true;
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(183, 24);
            this.lblMotivo.TabIndex = 10;
            this.lblMotivo.Text = "Indique el motivo de la cancelación:";
            // 
            // lbltipo
            // 
            this.lbltipo.BackColor = System.Drawing.SystemColors.Control;
            this.lbltipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbltipo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lbltipo.Location = new System.Drawing.Point(26, 177);
            this.lbltipo.Multiline = true;
            this.lbltipo.Name = "lbltipo";
            this.lbltipo.Size = new System.Drawing.Size(160, 24);
            this.lbltipo.TabIndex = 9;
            this.lbltipo.Text = "Seleccione tipo de cancelación:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(201, 174);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(192, 21);
            this.cmbTipo.TabIndex = 8;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(268, 316);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Confirmar cancelación";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // CancelacionAfiliado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 373);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lbltipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.btnCancelar);
            this.Name = "CancelacionAfiliado";
            this.Text = "Cancelar Atención";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.TextBox lblMotivo;
        private System.Windows.Forms.TextBox lbltipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnCancelar;
    }
}