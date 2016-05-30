namespace TcpClientProgram
{
    partial class frmChatPrivadoCliente
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
            this.btnZumbido = new System.Windows.Forms.Button();
            this.messagebodytextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.portTextbox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnRecibirVideo = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbCamaras = new System.Windows.Forms.ComboBox();
            this.btnEncender = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btnEnviarVideo = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // SendMsgButton
            // 
            this.SendMsgButton.Location = new System.Drawing.Point(267, 315);
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
            this.label1.Location = new System.Drawing.Point(7, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName";
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
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chat Server i.p";
            this.label2.Visible = false;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(272, 53);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
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
            this.label3.Location = new System.Drawing.Point(21, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Para:";
            // 
            // totextbox
            // 
            this.totextbox.Location = new System.Drawing.Point(59, 175);
            this.totextbox.Name = "totextbox";
            this.totextbox.Size = new System.Drawing.Size(139, 20);
            this.totextbox.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnZumbido);
            this.groupBox1.Controls.Add(this.messagebodytextbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.SendMsgButton);
            this.groupBox1.Controls.Add(this.totextbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(24, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 373);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ChatBox";
            // 
            // btnZumbido
            // 
            this.btnZumbido.Location = new System.Drawing.Point(186, 315);
            this.btnZumbido.Name = "btnZumbido";
            this.btnZumbido.Size = new System.Drawing.Size(75, 23);
            this.btnZumbido.TabIndex = 11;
            this.btnZumbido.Text = "Zumbido";
            this.btnZumbido.UseVisualStyleBackColor = true;
            this.btnZumbido.Click += new System.EventHandler(this.btnZumbido_Click);
            // 
            // messagebodytextbox
            // 
            this.messagebodytextbox.Location = new System.Drawing.Point(59, 201);
            this.messagebodytextbox.Multiline = true;
            this.messagebodytextbox.Name = "messagebodytextbox";
            this.messagebodytextbox.Size = new System.Drawing.Size(283, 108);
            this.messagebodytextbox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mensaje:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Conversación:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(330, 121);
            this.listBox1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Server Port";
            this.label6.Visible = false;
            // 
            // portTextbox
            // 
            this.portTextbox.Location = new System.Drawing.Point(337, 21);
            this.portTextbox.Name = "portTextbox";
            this.portTextbox.Size = new System.Drawing.Size(68, 20);
            this.portTextbox.TabIndex = 12;
            this.portTextbox.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(411, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(411, 288);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(303, 176);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // btnRecibirVideo
            // 
            this.btnRecibirVideo.Location = new System.Drawing.Point(423, 199);
            this.btnRecibirVideo.Name = "btnRecibirVideo";
            this.btnRecibirVideo.Size = new System.Drawing.Size(75, 51);
            this.btnRecibirVideo.TabIndex = 15;
            this.btnRecibirVideo.Text = "Recibir Video";
            this.btnRecibirVideo.UseVisualStyleBackColor = true;
            this.btnRecibirVideo.Click += new System.EventHandler(this.btnRecibirVideo_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // cbCamaras
            // 
            this.cbCamaras.FormattingEnabled = true;
            this.cbCamaras.Location = new System.Drawing.Point(505, 199);
            this.cbCamaras.Name = "cbCamaras";
            this.cbCamaras.Size = new System.Drawing.Size(121, 21);
            this.cbCamaras.TabIndex = 16;
            // 
            // btnEncender
            // 
            this.btnEncender.Location = new System.Drawing.Point(505, 227);
            this.btnEncender.Name = "btnEncender";
            this.btnEncender.Size = new System.Drawing.Size(63, 23);
            this.btnEncender.TabIndex = 17;
            this.btnEncender.Text = "Encender";
            this.btnEncender.UseVisualStyleBackColor = true;
            this.btnEncender.Click += new System.EventHandler(this.btnEncender_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(505, 257);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(121, 20);
            this.tbIP.TabIndex = 18;
            this.tbIP.Visible = false;
            // 
            // btnEnviarVideo
            // 
            this.btnEnviarVideo.Location = new System.Drawing.Point(632, 199);
            this.btnEnviarVideo.Name = "btnEnviarVideo";
            this.btnEnviarVideo.Size = new System.Drawing.Size(74, 51);
            this.btnEnviarVideo.TabIndex = 19;
            this.btnEnviarVideo.Text = "Enviar Video";
            this.btnEnviarVideo.UseVisualStyleBackColor = true;
            this.btnEnviarVideo.Click += new System.EventHandler(this.btnEnviarVideo_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(574, 226);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(52, 23);
            this.btnDetener.TabIndex = 20;
            this.btnDetener.Text = "Parar";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmChatPrivadoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 476);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnEnviarVideo);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.btnEncender);
            this.Controls.Add(this.cbCamaras);
            this.Controls.Add(this.btnRecibirVideo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.portTextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.userNameTextbox);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serveripTextbox);
            this.Controls.Add(this.label1);
            this.Name = "frmChatPrivadoCliente";
            this.Text = "Tcp Client";
            this.Load += new System.EventHandler(this.frmChatPrivadoCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.Button btnZumbido;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnRecibirVideo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbCamaras;
        private System.Windows.Forms.Button btnEncender;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button btnEnviarVideo;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Timer timer1;
    }
}

