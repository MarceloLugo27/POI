namespace TcpClientProgram
{
    partial class frmPrivateChatClient
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
            this.SendMsgButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serveripTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.userNameTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.messagebodytextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.portTextbox = new System.Windows.Forms.TextBox();
            this.pbReceptor = new System.Windows.Forms.PictureBox();
            this.pbEmisor = new System.Windows.Forms.PictureBox();
            this.btnSeleccionarCamara = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.cbCamaras = new System.Windows.Forms.ComboBox();
            this.timer1_stream = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReceptor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmisor)).BeginInit();
            this.SuspendLayout();
            // 
            // SendMsgButton
            // 
            this.SendMsgButton.Location = new System.Drawing.Point(275, 45);
            this.SendMsgButton.Name = "SendMsgButton";
            this.SendMsgButton.Size = new System.Drawing.Size(75, 23);
            this.SendMsgButton.TabIndex = 0;
            this.SendMsgButton.Text = "Enviar";
            this.SendMsgButton.UseVisualStyleBackColor = true;
            this.SendMsgButton.Click += new System.EventHandler(this.SendMsgButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            this.label1.Visible = false;
            // 
            // serveripTextbox
            // 
            this.serveripTextbox.Location = new System.Drawing.Point(88, 20);
            this.serveripTextbox.Name = "serveripTextbox";
            this.serveripTextbox.Size = new System.Drawing.Size(177, 20);
            this.serveripTextbox.TabIndex = 2;
            this.serveripTextbox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP Chat server";
            this.label2.Visible = false;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(271, 55);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 20);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Conectar";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Visible = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // userNameTextbox
            // 
            this.userNameTextbox.Location = new System.Drawing.Point(88, 55);
            this.userNameTextbox.Name = "userNameTextbox";
            this.userNameTextbox.Size = new System.Drawing.Size(177, 20);
            this.userNameTextbox.TabIndex = 5;
            this.userNameTextbox.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Para:";
            this.label3.Visible = false;
            // 
            // totextbox
            // 
            this.totextbox.Location = new System.Drawing.Point(88, 83);
            this.totextbox.Name = "totextbox";
            this.totextbox.Size = new System.Drawing.Size(283, 20);
            this.totextbox.TabIndex = 7;
            this.totextbox.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.messagebodytextbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SendMsgButton);
            this.groupBox1.Location = new System.Drawing.Point(15, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 78);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ChatBox";
            // 
            // messagebodytextbox
            // 
            this.messagebodytextbox.Location = new System.Drawing.Point(66, 19);
            this.messagebodytextbox.Multiline = true;
            this.messagebodytextbox.Name = "messagebodytextbox";
            this.messagebodytextbox.Size = new System.Drawing.Size(283, 20);
            this.messagebodytextbox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mensaje:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(50, 71);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(330, 121);
            this.listBox1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Historial de chat";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Puerto server";
            this.label6.Visible = false;
            // 
            // portTextbox
            // 
            this.portTextbox.Location = new System.Drawing.Point(347, 21);
            this.portTextbox.Name = "portTextbox";
            this.portTextbox.Size = new System.Drawing.Size(68, 20);
            this.portTextbox.TabIndex = 12;
            this.portTextbox.Visible = false;
            // 
            // pbReceptor
            // 
            this.pbReceptor.Location = new System.Drawing.Point(506, 12);
            this.pbReceptor.Name = "pbReceptor";
            this.pbReceptor.Size = new System.Drawing.Size(266, 183);
            this.pbReceptor.TabIndex = 13;
            this.pbReceptor.TabStop = false;
            // 
            // pbEmisor
            // 
            this.pbEmisor.Location = new System.Drawing.Point(506, 255);
            this.pbEmisor.Name = "pbEmisor";
            this.pbEmisor.Size = new System.Drawing.Size(266, 183);
            this.pbEmisor.TabIndex = 13;
            this.pbEmisor.TabStop = false;
            // 
            // btnSeleccionarCamara
            // 
            this.btnSeleccionarCamara.Location = new System.Drawing.Point(616, 215);
            this.btnSeleccionarCamara.Name = "btnSeleccionarCamara";
            this.btnSeleccionarCamara.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarCamara.TabIndex = 14;
            this.btnSeleccionarCamara.Text = "Seleccionar cámara";
            this.btnSeleccionarCamara.UseVisualStyleBackColor = true;
            this.btnSeleccionarCamara.Click += new System.EventHandler(this.btnSeleccionarCamara_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(697, 215);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 15;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // cbCamaras
            // 
            this.cbCamaras.FormattingEnabled = true;
            this.cbCamaras.Location = new System.Drawing.Point(506, 216);
            this.cbCamaras.Name = "cbCamaras";
            this.cbCamaras.Size = new System.Drawing.Size(104, 21);
            this.cbCamaras.TabIndex = 16;
            // 
            // timer1_stream
            // 
            this.timer1_stream.Interval = 1;
            this.timer1_stream.Tick += new System.EventHandler(this.timer1_stream_Tick);
            // 
            // frmPrivateChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 450);
            this.Controls.Add(this.cbCamaras);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnSeleccionarCamara);
            this.Controls.Add(this.pbEmisor);
            this.Controls.Add(this.pbReceptor);
            this.Controls.Add(this.portTextbox);
            this.Controls.Add(this.totextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.userNameTextbox);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serveripTextbox);
            this.Controls.Add(this.label1);
            this.Name = "frmPrivateChatClient";
            this.Text = "Chat Privado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReceptor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmisor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendMsgButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serveripTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox userNameTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox totextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox messagebodytextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox portTextbox;
        private System.Windows.Forms.PictureBox pbReceptor;
        private System.Windows.Forms.PictureBox pbEmisor;
        private System.Windows.Forms.Button btnSeleccionarCamara;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.ComboBox cbCamaras;
        private System.Windows.Forms.Timer timer1_stream;
    }
}

