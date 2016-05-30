namespace POI
{
    partial class frmListaPendientes
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
            this.DGVPendientes = new System.Windows.Forms.DataGridView();
            this.btnAñadirPendiente = new System.Windows.Forms.Button();
            this.tbPendiente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVPendientes
            // 
            this.DGVPendientes.AllowUserToAddRows = false;
            this.DGVPendientes.AllowUserToDeleteRows = false;
            this.DGVPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPendientes.Location = new System.Drawing.Point(12, 50);
            this.DGVPendientes.Name = "DGVPendientes";
            this.DGVPendientes.ReadOnly = true;
            this.DGVPendientes.Size = new System.Drawing.Size(407, 255);
            this.DGVPendientes.TabIndex = 0;
            this.DGVPendientes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPendientes_CellContentDoubleClick);
            // 
            // btnAñadirPendiente
            // 
            this.btnAñadirPendiente.Location = new System.Drawing.Point(304, 311);
            this.btnAñadirPendiente.Name = "btnAñadirPendiente";
            this.btnAñadirPendiente.Size = new System.Drawing.Size(115, 21);
            this.btnAñadirPendiente.TabIndex = 1;
            this.btnAñadirPendiente.Text = "Añadir Pendiente";
            this.btnAñadirPendiente.UseVisualStyleBackColor = true;
            this.btnAñadirPendiente.Click += new System.EventHandler(this.btnAñadirPendiente_Click);
            // 
            // tbPendiente
            // 
            this.tbPendiente.Location = new System.Drawing.Point(13, 312);
            this.tbPendiente.Name = "tbPendiente";
            this.tbPendiente.Size = new System.Drawing.Size(285, 20);
            this.tbPendiente.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "De doble clic a un pendiente de la lista para cambiar su status.";
            // 
            // frmListaPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 347);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPendiente);
            this.Controls.Add(this.btnAñadirPendiente);
            this.Controls.Add(this.DGVPendientes);
            this.Name = "frmListaPendientes";
            this.Text = "Lista de pendientes y tareas";
            this.Load += new System.EventHandler(this.frmListaPendientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVPendientes;
        private System.Windows.Forms.Button btnAñadirPendiente;
        private System.Windows.Forms.TextBox tbPendiente;
        private System.Windows.Forms.Label label1;
    }
}