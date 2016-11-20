namespace ClinicaFrba.Cancelar_Atencion
{
    partial class CancelacionProfesional
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
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lbltipo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(167, 18);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            this.Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // txt1
            // 
            this.txt1.BackColor = System.Drawing.SystemColors.Control;
            this.txt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt1.Location = new System.Drawing.Point(13, 18);
            this.txt1.Multiline = true;
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(143, 55);
            this.txt1.TabIndex = 1;
            this.txt1.Text = "Seleccione el día o el perído \r\nen que desea cancelar su atención médica";
            this.txt1.TextChanged += new System.EventHandler(this.txt1_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(269, 334);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Confirmar cancelación";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(202, 192);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(192, 21);
            this.cmbTipo.TabIndex = 3;
            // 
            // lbltipo
            // 
            this.lbltipo.BackColor = System.Drawing.SystemColors.Control;
            this.lbltipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbltipo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lbltipo.Location = new System.Drawing.Point(27, 195);
            this.lbltipo.Multiline = true;
            this.lbltipo.Name = "lbltipo";
            this.lbltipo.Size = new System.Drawing.Size(160, 24);
            this.lbltipo.TabIndex = 4;
            this.lbltipo.Text = "Seleccione tipo de cancelación:";
            // 
            // lblMotivo
            // 
            this.lblMotivo.BackColor = System.Drawing.SystemColors.Control;
            this.lblMotivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMotivo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lblMotivo.Location = new System.Drawing.Point(8, 237);
            this.lblMotivo.Multiline = true;
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(183, 24);
            this.lblMotivo.TabIndex = 5;
            this.lblMotivo.Text = "Indique el motivo de la cancelación:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(202, 234);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(192, 79);
            this.txtMotivo.TabIndex = 6;
            // 
            // CancelacionProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 385);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lbltipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.Calendar);
            this.Name = "CancelacionProfesional";
            this.Text = "Cancelar Atención";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox lbltipo;
        private System.Windows.Forms.TextBox lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
    }
}