namespace POI
{
    partial class frmSeleccionGrupos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGrupoLF = new System.Windows.Forms.Button();
            this.btnGrupoLM = new System.Windows.Forms.Button();
            this.btnGrupoLCC = new System.Windows.Forms.Button();
            this.btnGrupoLA = new System.Windows.Forms.Button();
            this.btnGrupoLMAD = new System.Windows.Forms.Button();
            this.btnGrupoLSTI = new System.Windows.Forms.Button();
            this.DGVSubGrupos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pendientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSubGrupos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrupoLF
            // 
            this.btnGrupoLF.Location = new System.Drawing.Point(39, 37);
            this.btnGrupoLF.Name = "btnGrupoLF";
            this.btnGrupoLF.Size = new System.Drawing.Size(200, 75);
            this.btnGrupoLF.TabIndex = 0;
            this.btnGrupoLF.Text = "Chat LF";
            this.btnGrupoLF.UseVisualStyleBackColor = true;
            this.btnGrupoLF.Click += new System.EventHandler(this.bntGrupoLF_Click);
            // 
            // btnGrupoLM
            // 
            this.btnGrupoLM.Location = new System.Drawing.Point(39, 118);
            this.btnGrupoLM.Name = "btnGrupoLM";
            this.btnGrupoLM.Size = new System.Drawing.Size(200, 75);
            this.btnGrupoLM.TabIndex = 0;
            this.btnGrupoLM.Text = "Chat LM";
            this.btnGrupoLM.UseVisualStyleBackColor = true;
            this.btnGrupoLM.Click += new System.EventHandler(this.btnGrupoLM_Click);
            // 
            // btnGrupoLCC
            // 
            this.btnGrupoLCC.Location = new System.Drawing.Point(39, 280);
            this.btnGrupoLCC.Name = "btnGrupoLCC";
            this.btnGrupoLCC.Size = new System.Drawing.Size(200, 75);
            this.btnGrupoLCC.TabIndex = 0;
            this.btnGrupoLCC.Text = "Chat LCC";
            this.btnGrupoLCC.UseVisualStyleBackColor = true;
            this.btnGrupoLCC.Click += new System.EventHandler(this.btnGrupoLCC_Click);
            // 
            // btnGrupoLA
            // 
            this.btnGrupoLA.Location = new System.Drawing.Point(39, 199);
            this.btnGrupoLA.Name = "btnGrupoLA";
            this.btnGrupoLA.Size = new System.Drawing.Size(200, 75);
            this.btnGrupoLA.TabIndex = 0;
            this.btnGrupoLA.Text = "Chat LA";
            this.btnGrupoLA.UseVisualStyleBackColor = true;
            this.btnGrupoLA.Click += new System.EventHandler(this.btnGrupoLA_Click);
            // 
            // btnGrupoLMAD
            // 
            this.btnGrupoLMAD.Location = new System.Drawing.Point(39, 361);
            this.btnGrupoLMAD.Name = "btnGrupoLMAD";
            this.btnGrupoLMAD.Size = new System.Drawing.Size(200, 75);
            this.btnGrupoLMAD.TabIndex = 0;
            this.btnGrupoLMAD.Text = "Chat LMAD";
            this.btnGrupoLMAD.UseVisualStyleBackColor = true;
            this.btnGrupoLMAD.Click += new System.EventHandler(this.btnGrupoLMAD_Click);
            // 
            // btnGrupoLSTI
            // 
            this.btnGrupoLSTI.Location = new System.Drawing.Point(39, 442);
            this.btnGrupoLSTI.Name = "btnGrupoLSTI";
            this.btnGrupoLSTI.Size = new System.Drawing.Size(200, 75);
            this.btnGrupoLSTI.TabIndex = 0;
            this.btnGrupoLSTI.Text = "Chat LSTI";
            this.btnGrupoLSTI.UseVisualStyleBackColor = true;
            this.btnGrupoLSTI.Click += new System.EventHandler(this.btnGrupoLSTI_Click);
            // 
            // DGVSubGrupos
            // 
            this.DGVSubGrupos.AllowUserToAddRows = false;
            this.DGVSubGrupos.AllowUserToDeleteRows = false;
            this.DGVSubGrupos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DGVSubGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSubGrupos.Location = new System.Drawing.Point(345, 37);
            this.DGVSubGrupos.Name = "DGVSubGrupos";
            this.DGVSubGrupos.ReadOnly = true;
            this.DGVSubGrupos.RowHeadersVisible = false;
            this.DGVSubGrupos.Size = new System.Drawing.Size(200, 480);
            this.DGVSubGrupos.TabIndex = 1;
            this.DGVSubGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSubGrupos_CellClick);
            this.DGVSubGrupos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSubGrupos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendientesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pendientesToolStripMenuItem
            // 
            this.pendientesToolStripMenuItem.Name = "pendientesToolStripMenuItem";
            this.pendientesToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.pendientesToolStripMenuItem.Text = "Pendientes y tareas";
            // 
            // frmSeleccionGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVSubGrupos);
            this.Controls.Add(this.btnGrupoLSTI);
            this.Controls.Add(this.btnGrupoLMAD);
            this.Controls.Add(this.btnGrupoLA);
            this.Controls.Add(this.btnGrupoLCC);
            this.Controls.Add(this.btnGrupoLM);
            this.Controls.Add(this.btnGrupoLF);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSeleccionGrupos";
            this.Text = "Seleccione un chat para acceder";
            this.Load += new System.EventHandler(this.frmSeleccionGrupos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSubGrupos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrupoLF;
        private System.Windows.Forms.Button btnGrupoLM;
        private System.Windows.Forms.Button btnGrupoLCC;
        private System.Windows.Forms.Button btnGrupoLA;
        private System.Windows.Forms.Button btnGrupoLMAD;
        private System.Windows.Forms.Button btnGrupoLSTI;
        private System.Windows.Forms.DataGridView DGVSubGrupos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pendientesToolStripMenuItem;
    }
}

