namespace PuntoDeVentaJD
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.puntoDeVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarPuntoDeVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moduloDeAdministracionDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelFechaHora = new System.Windows.Forms.Label();
            this.labelCajero = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPuntoVenta = new System.Windows.Forms.Button();
            this.buttonUserAdmin = new System.Windows.Forms.Button();
            this.buttonProductAdmin = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puntoDeVentaToolStripMenuItem,
            this.administraciónToolStripMenuItem,
            this.administracionDeProductosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(459, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // puntoDeVentaToolStripMenuItem
            // 
            this.puntoDeVentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarPuntoDeVentaToolStripMenuItem});
            this.puntoDeVentaToolStripMenuItem.Name = "puntoDeVentaToolStripMenuItem";
            this.puntoDeVentaToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.puntoDeVentaToolStripMenuItem.Text = "Punto de Venta";
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moduloDeAdministracionDeUsuariosToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(164, 20);
            this.administraciónToolStripMenuItem.Text = "Administración de Usuarios";
            // 
            // ejecutarPuntoDeVentaToolStripMenuItem
            // 
            this.ejecutarPuntoDeVentaToolStripMenuItem.Name = "ejecutarPuntoDeVentaToolStripMenuItem";
            this.ejecutarPuntoDeVentaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.ejecutarPuntoDeVentaToolStripMenuItem.Text = "Ejecutar punto de venta";
            this.ejecutarPuntoDeVentaToolStripMenuItem.Click += new System.EventHandler(this.ejecutarPuntoDeVentaToolStripMenuItem_Click);
            // 
            // moduloDeAdministracionDeUsuariosToolStripMenuItem
            // 
            this.moduloDeAdministracionDeUsuariosToolStripMenuItem.Name = "moduloDeAdministracionDeUsuariosToolStripMenuItem";
            this.moduloDeAdministracionDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.moduloDeAdministracionDeUsuariosToolStripMenuItem.Text = "Modulo de Administracion de Usuarios";
            this.moduloDeAdministracionDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.moduloDeAdministracionDeUsuariosToolStripMenuItem_Click);
            // 
            // administracionDeProductosToolStripMenuItem
            // 
            this.administracionDeProductosToolStripMenuItem.Name = "administracionDeProductosToolStripMenuItem";
            this.administracionDeProductosToolStripMenuItem.Size = new System.Drawing.Size(173, 20);
            this.administracionDeProductosToolStripMenuItem.Text = "Administracion de productos";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelFechaHora
            // 
            this.labelFechaHora.AutoSize = true;
            this.labelFechaHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaHora.ForeColor = System.Drawing.Color.Blue;
            this.labelFechaHora.Location = new System.Drawing.Point(3, 62);
            this.labelFechaHora.Name = "labelFechaHora";
            this.labelFechaHora.Size = new System.Drawing.Size(89, 16);
            this.labelFechaHora.TabIndex = 9;
            this.labelFechaHora.Text = "Fecha,Hora";
            // 
            // labelCajero
            // 
            this.labelCajero.AutoSize = true;
            this.labelCajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCajero.ForeColor = System.Drawing.Color.Blue;
            this.labelCajero.Location = new System.Drawing.Point(3, 22);
            this.labelCajero.Name = "labelCajero";
            this.labelCajero.Size = new System.Drawing.Size(70, 16);
            this.labelCajero.TabIndex = 10;
            this.labelCajero.Text = "Usuario: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCajero);
            this.panel1.Controls.Add(this.labelFechaHora);
            this.panel1.Location = new System.Drawing.Point(12, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 100);
            this.panel1.TabIndex = 11;
            // 
            // buttonPuntoVenta
            // 
            this.buttonPuntoVenta.BackgroundImage = global::PuntoDeVentaJD.Properties.Resources.iconfinder_24_Cash_Register_2924837;
            this.buttonPuntoVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPuntoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPuntoVenta.ForeColor = System.Drawing.Color.Blue;
            this.buttonPuntoVenta.Location = new System.Drawing.Point(18, 37);
            this.buttonPuntoVenta.Name = "buttonPuntoVenta";
            this.buttonPuntoVenta.Size = new System.Drawing.Size(110, 165);
            this.buttonPuntoVenta.TabIndex = 12;
            this.buttonPuntoVenta.Text = "Punto de Venta";
            this.buttonPuntoVenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPuntoVenta.UseVisualStyleBackColor = true;
            this.buttonPuntoVenta.Click += new System.EventHandler(this.buttonPuntoVenta_Click);
            // 
            // buttonUserAdmin
            // 
            this.buttonUserAdmin.BackgroundImage = global::PuntoDeVentaJD.Properties.Resources.iconfinder_Facebook_UI_31_2344305;
            this.buttonUserAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUserAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUserAdmin.ForeColor = System.Drawing.Color.Blue;
            this.buttonUserAdmin.Location = new System.Drawing.Point(174, 37);
            this.buttonUserAdmin.Name = "buttonUserAdmin";
            this.buttonUserAdmin.Size = new System.Drawing.Size(110, 165);
            this.buttonUserAdmin.TabIndex = 13;
            this.buttonUserAdmin.Text = "Administracion de Usuarios";
            this.buttonUserAdmin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonUserAdmin.UseVisualStyleBackColor = true;
            this.buttonUserAdmin.Click += new System.EventHandler(this.buttonUserAdmin_Click);
            // 
            // buttonProductAdmin
            // 
            this.buttonProductAdmin.BackgroundImage = global::PuntoDeVentaJD.Properties.Resources.iconfinder_040_95876;
            this.buttonProductAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonProductAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProductAdmin.ForeColor = System.Drawing.Color.Blue;
            this.buttonProductAdmin.Location = new System.Drawing.Point(329, 37);
            this.buttonProductAdmin.Name = "buttonProductAdmin";
            this.buttonProductAdmin.Size = new System.Drawing.Size(110, 165);
            this.buttonProductAdmin.TabIndex = 14;
            this.buttonProductAdmin.Text = "Administracion de Productos";
            this.buttonProductAdmin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonProductAdmin.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(459, 320);
            this.Controls.Add(this.buttonProductAdmin);
            this.Controls.Add(this.buttonUserAdmin);
            this.Controls.Add(this.buttonPuntoVenta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu Principal de Administracion de Punto de  Venta";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem puntoDeVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarPuntoDeVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moduloDeAdministracionDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionDeProductosToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelFechaHora;
        private System.Windows.Forms.Label labelCajero;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPuntoVenta;
        private System.Windows.Forms.Button buttonUserAdmin;
        private System.Windows.Forms.Button buttonProductAdmin;
    }
}