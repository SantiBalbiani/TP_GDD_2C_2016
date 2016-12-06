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
            this.btnAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Calendar.Location = new System.Drawing.Point(183, 18);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            this.Calendar.TitleForeColor = System.Drawing.Color.MidnightBlue;
            this.Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // txt1
            // 
            this.txt1.BackColor = System.Drawing.Color.MidnightBlue;
            this.txt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.ForeColor = System.Drawing.Color.White;
            this.txt1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt1.Location = new System.Drawing.Point(12, 18);
            this.txt1.Multiline = true;
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(171, 82);
            this.txt1.TabIndex = 1;
            this.txt1.Text = "Seleccione el día o el perído \r\nen que desea cancelar su atención médica";
            this.txt1.TextChanged += new System.EventHandler(this.txt1_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelar.Location = new System.Drawing.Point(285, 337);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Confirmar cancelación";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(218, 204);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(192, 21);
            this.cmbTipo.TabIndex = 3;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // lbltipo
            // 
            this.lbltipo.BackColor = System.Drawing.Color.MidnightBlue;
            this.lbltipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbltipo.ForeColor = System.Drawing.Color.White;
            this.lbltipo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lbltipo.Location = new System.Drawing.Point(35, 204);
            this.lbltipo.Multiline = true;
            this.lbltipo.Name = "lbltipo";
            this.lbltipo.Size = new System.Drawing.Size(160, 24);
            this.lbltipo.TabIndex = 4;
            this.lbltipo.Text = "Seleccione tipo de cancelación:";
            // 
            // lblMotivo
            // 
            this.lblMotivo.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblMotivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMotivo.ForeColor = System.Drawing.Color.White;
            this.lblMotivo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.lblMotivo.Location = new System.Drawing.Point(17, 237);
            this.lblMotivo.Multiline = true;
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(183, 24);
            this.lblMotivo.TabIndex = 5;
            this.lblMotivo.Text = "Indique el motivo de la cancelación:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMotivo.Location = new System.Drawing.Point(218, 237);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(192, 79);
            this.txtMotivo.TabIndex = 6;
            this.txtMotivo.TextChanged += new System.EventHandler(this.txtMotivo_TextChanged);
            // 
            // btnAtras
            // 
            this.btnAtras.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAtras.Location = new System.Drawing.Point(17, 337);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 7;
            this.btnAtras.Text = "Ir Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // CancelacionProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(437, 385);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lbltipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.txt1);
            this.Name = "CancelacionProfesional";
            this.Text = "Cancelar Atención";
            this.Load += new System.EventHandler(this.CancelacionProfesional_Load);
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
        private System.Windows.Forms.Button btnAtras;
    }
}