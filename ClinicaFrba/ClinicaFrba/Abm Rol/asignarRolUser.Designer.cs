namespace ClinicaFrba.AbmRol
{
    partial class asignarRolUser
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
            this.btnRolAsignar = new System.Windows.Forms.Button();
            this.btnRolDesasignar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rolDesasignar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.rolAsignar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRolAsignar
            // 
            this.btnRolAsignar.Location = new System.Drawing.Point(68, 273);
            this.btnRolAsignar.Name = "btnRolAsignar";
            this.btnRolAsignar.Size = new System.Drawing.Size(80, 31);
            this.btnRolAsignar.TabIndex = 14;
            this.btnRolAsignar.Text = "Asignar Rol";
            this.btnRolAsignar.UseVisualStyleBackColor = true;
            this.btnRolAsignar.Click += new System.EventHandler(this.btnRolAsignar_Click);
            // 
            // btnRolDesasignar
            // 
            this.btnRolDesasignar.Location = new System.Drawing.Point(338, 273);
            this.btnRolDesasignar.Name = "btnRolDesasignar";
            this.btnRolDesasignar.Size = new System.Drawing.Size(104, 31);
            this.btnRolDesasignar.TabIndex = 15;
            this.btnRolDesasignar.Text = "Desasignar Rol";
            this.btnRolDesasignar.UseVisualStyleBackColor = true;
            this.btnRolDesasignar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Seleccione el Usuario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Complete los campos segun corresponda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Escriba el Rol a Desasignar";
            // 
            // rolDesasignar
            // 
            this.rolDesasignar.Location = new System.Drawing.Point(338, 206);
            this.rolDesasignar.Name = "rolDesasignar";
            this.rolDesasignar.Size = new System.Drawing.Size(100, 20);
            this.rolDesasignar.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Escriba el Rol a Asignar";
            this.label6.Click += new System.EventHandler(this.label3_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(248, 91);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 20);
            this.username.TabIndex = 21;
            this.username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // rolAsignar
            // 
            this.rolAsignar.Location = new System.Drawing.Point(58, 206);
            this.rolAsignar.Name = "rolAsignar";
            this.rolAsignar.Size = new System.Drawing.Size(100, 20);
            this.rolAsignar.TabIndex = 22;
            this.rolAsignar.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "o";
            this.label7.Click += new System.EventHandler(this.label4_Click);
            // 
            // asignarRolUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 374);
            this.Controls.Add(this.rolDesasignar);
            this.Controls.Add(this.rolAsignar);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRolDesasignar);
            this.Controls.Add(this.btnRolAsignar);
            this.Name = "asignarRolUser";
            this.Text = "Asignar/Desasignar un Rol a un Usuario";
            this.Load += new System.EventHandler(this.asignarRolUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRolAsignar;
        private System.Windows.Forms.Button btnRolDesasignar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rolDesasignar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox rolAsignar;
        private System.Windows.Forms.Label label7;

    }
}