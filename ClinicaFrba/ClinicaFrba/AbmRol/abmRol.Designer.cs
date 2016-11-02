namespace ClinicaFrba.AbmRol
{
    partial class abmRol
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
            this.asignarRol = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Rol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarUnaFuncionalidadAUnRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaciònDeRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarFuncionalidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarFuncionalidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Rol.SuspendLayout();
            this.SuspendLayout();
            // 
            // asignarRol
            // 
            this.asignarRol.AutoSize = true;
            this.asignarRol.Location = new System.Drawing.Point(27, 31);
            this.asignarRol.Name = "asignarRol";
            this.asignarRol.Size = new System.Drawing.Size(183, 13);
            this.asignarRol.TabIndex = 0;
            this.asignarRol.Text = "Presione la accion que desea realizar";
            this.asignarRol.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(57, 93);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 72);
            this.btnCrear.TabIndex = 5;
            this.btnCrear.Text = "Crear Nuevo Rol";
            this.btnCrear.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 7;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 72);
            this.button1.TabIndex = 11;
            this.button1.Text = "Modificar Rol Existentes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(297, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 72);
            this.button2.TabIndex = 12;
            this.button2.Text = "Eliminar Rol";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Rol
            // 
            this.Rol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem,
            this.bajaToolStripMenuItem,
            this.modificaciònDeRolToolStripMenuItem});
            this.Rol.Name = "Rol";
            this.Rol.Size = new System.Drawing.Size(181, 70);
            // 
            // altaToolStripMenuItem
            // 
            this.altaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearRolToolStripMenuItem,
            this.asignarUnaFuncionalidadAUnRolToolStripMenuItem});
            this.altaToolStripMenuItem.Name = "altaToolStripMenuItem";
            this.altaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.altaToolStripMenuItem.Text = "Alta de Rol";
            // 
            // crearRolToolStripMenuItem
            // 
            this.crearRolToolStripMenuItem.Name = "crearRolToolStripMenuItem";
            this.crearRolToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.crearRolToolStripMenuItem.Text = "Crear Rol";
            // 
            // asignarUnaFuncionalidadAUnRolToolStripMenuItem
            // 
            this.asignarUnaFuncionalidadAUnRolToolStripMenuItem.Name = "asignarUnaFuncionalidadAUnRolToolStripMenuItem";
            this.asignarUnaFuncionalidadAUnRolToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.asignarUnaFuncionalidadAUnRolToolStripMenuItem.Text = "Asignar una funcionalidad a un Rol";
            // 
            // bajaToolStripMenuItem
            // 
            this.bajaToolStripMenuItem.Name = "bajaToolStripMenuItem";
            this.bajaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bajaToolStripMenuItem.Text = "Baja de Rol";
            // 
            // modificaciònDeRolToolStripMenuItem
            // 
            this.modificaciònDeRolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarFuncionalidadToolStripMenuItem,
            this.quitarFuncionalidadToolStripMenuItem});
            this.modificaciònDeRolToolStripMenuItem.Name = "modificaciònDeRolToolStripMenuItem";
            this.modificaciònDeRolToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificaciònDeRolToolStripMenuItem.Text = "Modificaciòn de Rol";
            // 
            // agregarFuncionalidadToolStripMenuItem
            // 
            this.agregarFuncionalidadToolStripMenuItem.Name = "agregarFuncionalidadToolStripMenuItem";
            this.agregarFuncionalidadToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.agregarFuncionalidadToolStripMenuItem.Text = "Agregar Funcionalidad";
            // 
            // quitarFuncionalidadToolStripMenuItem
            // 
            this.quitarFuncionalidadToolStripMenuItem.Name = "quitarFuncionalidadToolStripMenuItem";
            this.quitarFuncionalidadToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.quitarFuncionalidadToolStripMenuItem.Text = "Quitar Funcionalidad";
            // 
            // abmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 310);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.asignarRol);
            this.Name = "abmRol";
            this.Text = "ABM Rol";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Rol.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label asignarRol;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip Rol;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarUnaFuncionalidadAUnRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaciònDeRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarFuncionalidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitarFuncionalidadToolStripMenuItem;
    }
}