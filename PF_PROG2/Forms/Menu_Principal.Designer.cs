
namespace PF_PROG2
{
    partial class Menu_Principal
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
            this.label2 = new System.Windows.Forms.Label();
            this.departamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sLAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sLAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.incidenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.historialIncidentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dGvincidentes = new System.Windows.Forms.DataGridView();
            this.bntUpdtDgv = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGvincidentes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SkyBlue;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(157, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido al sistema de Tickets ServiceDesk";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Incidentes activos";
            // 
            // departamentosToolStripMenuItem
            // 
            this.departamentosToolStripMenuItem.Name = "departamentosToolStripMenuItem";
            this.departamentosToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            this.departamentosToolStripMenuItem.Click += new System.EventHandler(this.departamentosToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
            this.usuariosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.usuariosToolStripMenuItem.Text = "Departamentos";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // puestosToolStripMenuItem
            // 
            this.puestosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puestosToolStripMenuItem.Name = "puestosToolStripMenuItem";
            this.puestosToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.puestosToolStripMenuItem.Text = "Puestos";
            this.puestosToolStripMenuItem.Click += new System.EventHandler(this.puestosToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem1
            // 
            this.usuariosToolStripMenuItem1.BackColor = System.Drawing.Color.Azure;
            this.usuariosToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuariosToolStripMenuItem1.Name = "usuariosToolStripMenuItem1";
            this.usuariosToolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
            this.usuariosToolStripMenuItem1.Text = "Usuarios";
            this.usuariosToolStripMenuItem1.Click += new System.EventHandler(this.usuariosToolStripMenuItem1_Click);
            // 
            // sLAToolStripMenuItem
            // 
            this.sLAToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
            this.sLAToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLAToolStripMenuItem.Name = "sLAToolStripMenuItem";
            this.sLAToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.sLAToolStripMenuItem.Text = "Prioridad";
            this.sLAToolStripMenuItem.Click += new System.EventHandler(this.sLAToolStripMenuItem_Click);
            // 
            // sLAToolStripMenuItem1
            // 
            this.sLAToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLAToolStripMenuItem1.Name = "sLAToolStripMenuItem1";
            this.sLAToolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.sLAToolStripMenuItem1.Text = "SLA";
            this.sLAToolStripMenuItem1.Click += new System.EventHandler(this.sLAToolStripMenuItem1_Click);
            // 
            // incidenteToolStripMenuItem
            // 
            this.incidenteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incidenteToolStripMenuItem.Name = "incidenteToolStripMenuItem";
            this.incidenteToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.incidenteToolStripMenuItem.Text = "Incidentes";
            this.incidenteToolStripMenuItem.Click += new System.EventHandler(this.incidenteToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departamentosToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.puestosToolStripMenuItem,
            this.usuariosToolStripMenuItem1,
            this.sLAToolStripMenuItem1,
            this.sLAToolStripMenuItem,
            this.incidenteToolStripMenuItem,
            this.historialIncidentesToolStripMenuItem,
            this.salirXToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // historialIncidentesToolStripMenuItem
            // 
            this.historialIncidentesToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
            this.historialIncidentesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historialIncidentesToolStripMenuItem.Name = "historialIncidentesToolStripMenuItem";
            this.historialIncidentesToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.historialIncidentesToolStripMenuItem.Text = "Historial Incidentes";
            this.historialIncidentesToolStripMenuItem.Click += new System.EventHandler(this.historialIncidentesToolStripMenuItem_Click);
            // 
            // salirXToolStripMenuItem
            // 
            this.salirXToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirXToolStripMenuItem.Name = "salirXToolStripMenuItem";
            this.salirXToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.salirXToolStripMenuItem.Text = "Salir X";
            this.salirXToolStripMenuItem.Click += new System.EventHandler(this.salirXToolStripMenuItem_Click);
            // 
            // dGvincidentes
            // 
            this.dGvincidentes.BackgroundColor = System.Drawing.Color.Beige;
            this.dGvincidentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGvincidentes.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dGvincidentes.Location = new System.Drawing.Point(21, 214);
            this.dGvincidentes.Name = "dGvincidentes";
            this.dGvincidentes.Size = new System.Drawing.Size(781, 176);
            this.dGvincidentes.TabIndex = 3;
            this.dGvincidentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGvincidentes_CellContentClick);
            // 
            // bntUpdtDgv
            // 
            this.bntUpdtDgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bntUpdtDgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntUpdtDgv.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bntUpdtDgv.Location = new System.Drawing.Point(745, 396);
            this.bntUpdtDgv.Name = "bntUpdtDgv";
            this.bntUpdtDgv.Size = new System.Drawing.Size(48, 47);
            this.bntUpdtDgv.TabIndex = 9;
            this.bntUpdtDgv.Text = "⟲";
            this.bntUpdtDgv.UseVisualStyleBackColor = false;
            this.bntUpdtDgv.Click += new System.EventHandler(this.bntUpdtDgv_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PF_PROG2.Properties.Resources.en_todas;
            this.pictureBox1.Location = new System.Drawing.Point(12, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(830, 444);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bntUpdtDgv);
            this.Controls.Add(this.dGvincidentes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu_Principal";
            this.RightToLeftLayout = true;
            this.Text = "Sistema de Tickets ServiceDesk";
            this.Load += new System.EventHandler(this.Menu_Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGvincidentes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem departamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sLAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sLAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem incidenteToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dGvincidentes;
        private System.Windows.Forms.ToolStripMenuItem salirXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialIncidentesToolStripMenuItem;
        private System.Windows.Forms.Button bntUpdtDgv;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}