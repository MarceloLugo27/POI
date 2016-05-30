using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using Funciones;
using System.Drawing.Imaging;
using System.Net.Mail;

namespace TcpClientProgram

{
    public partial class frmChatPrivadoCliente : Form
    {
        TcpClient tcpClient;
        bool isConnectedToServer = false;
        private StreamWriter strWritter;
        private StreamReader strReader;
        private Thread incomingMessageHandler;

        UdpClient vcliente;
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        //UdpClient sckRecive = new UdpClient(9050);
        Byte[] recives;
        Image imagen, imagen2;
        string path = string.Empty;

        public frmChatPrivadoCliente()
        {
            InitializeComponent();
        }

        public Image byteArrayToImage(Byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }   //CONVIERTE EL BYTE[] A IMAGEN

        public Byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        void getResponse()
        {
            Stream stm = tcpClient.GetStream();
            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            string msg = "";

            for (int i = 0; i < k; i++)
            {
                msg += Convert.ToChar(bb[i]).ToString();

            }

            setClientMessage(msg);
        }


        void setClientMessage(string msg)
        {

            if (!InvokeRequired)
            {
                listBox1.Items.Add(msg.ToString());

            }
            else
            {
                Invoke(new Action<string>(setClientMessage), msg);
            }
        }

        private void SendMsgButton_Click(object sender, EventArgs e)
        {
            string message;



            message = "SEND_MSG;" + totextbox.Text + ";" + messagebodytextbox.Text;
            listBox1.Items.Add("Tu: " + messagebodytextbox.Text.ToString());

            strWritter.WriteLine(message);
            strWritter.Flush();

            messagebodytextbox.Text = "";
            messagebodytextbox.Focus();

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            if (!isConnectedToServer)
            {
                string connectionEstablish;

                connectionEstablish = "CONNECT_REQUEST;" + userNameTextbox.Text;


                tcpClient = new TcpClient();
                tcpClient.Connect(serveripTextbox.Text, int.Parse(portTextbox.Text));
                this.isConnectedToServer = true;

                strWritter = new StreamWriter(tcpClient.GetStream());
                strWritter.WriteLine(connectionEstablish);
                strWritter.Flush();

                incomingMessageHandler = new Thread(() => ReceiveMessages());
                incomingMessageHandler.IsBackground = true;
                incomingMessageHandler.Start();


            }
            if (isConnectedToServer)
            {

            }



        }


        private void ReceiveMessages()
        {


            strReader = new StreamReader(this.tcpClient.GetStream());

            // While we are successfully connected, read incoming lines from the server
            while (this.isConnectedToServer)
            {
                string serverResponse = strReader.ReadLine();
                string[] data = serverResponse.Split(';');

                if (data[0].Equals("INCOMING_MSG"))
                {
                    string source = data[1];
                    string message = data[2];
                    setClientMessage(source + " dice:" + " " + message);
                }

                if (data[0].Equals("INCOMING_BUZZ"))
                {
                    Point WinLoc = default(Point);
                    Point WinLocDef = default(Point);

                    WinLocDef = this.Location;
                    WinLoc = this.Location;

                    for (int i = 0; i <= 50; i++)
                    {
                        for (int x = 0; x <= 4; x++)
                        {
                            switch (x)
                            {
                                case 0:
                                    WinLoc.X = WinLocDef.X + 10;
                                    break;
                                case 1:
                                    WinLoc.X = WinLocDef.X - 10;
                                    break;
                                case 2:
                                    WinLoc.Y = WinLocDef.Y - 10;
                                    break;
                                case 3:
                                    WinLoc.Y = WinLocDef.Y + 10;
                                    break;
                                case 4:
                                    WinLoc = WinLocDef;
                                    break;
                            }
                            this.Location = WinLoc;
                        }
                        //Me.Refresh() // if needed for more form refresh event
                    }
                    this.Location = WinLocDef;
                    this.Refresh();
                }

            }
        }

        private void frmChatPrivadoCliente_Load(object sender, EventArgs e)
        {


            CheckForIllegalCrossThreadCalls = false;

            string strqry = "SELECT strDireccionIP, intPuerto FROM tblSubGrupo WHERE IDGrupo = 7";
            DataSet dsChatPrivado = cFunciones.LlenarDatasetMiServer(strqry, "Chat", "");
            cFunciones.GlobalstrIPChatPrivado = dsChatPrivado.Tables[0].Rows[0][0].ToString();
            cFunciones.GlobalintPuertoPrivado = dsChatPrivado.Tables[0].Rows[0][1].ToString();

            serveripTextbox.Text = cFunciones.GlobalstrIPChatPrivado;
            portTextbox.Text = cFunciones.GlobalintPuertoPrivado;
            userNameTextbox.Text = cFunciones.GlobalstrNombreUsuarioCliente;
            totextbox.Text = cFunciones.GlobalstrNombreClienteDestino;
            tbIP.Text = cFunciones.GlobalstrDireccionIPDestino;

            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo videocapturedevice in webcam)
            {

                cbCamaras.Items.Add(videocapturedevice.MonikerString);
            }

            cbCamaras.SelectedIndex = 0;

            this.Text = "Chat de " + cFunciones.GlobalstrNombreUsuarioCliente + " a " + cFunciones.GlobalstrNombreClienteDestino;

            if (!isConnectedToServer)
            {
                string connectionEstablish;

                connectionEstablish = "CONNECT_REQUEST;" + userNameTextbox.Text;


                tcpClient = new TcpClient();
                tcpClient.Connect(serveripTextbox.Text, int.Parse(portTextbox.Text));
                this.isConnectedToServer = true;

                strWritter = new StreamWriter(tcpClient.GetStream());
                strWritter.WriteLine(connectionEstablish);
                strWritter.Flush();

                incomingMessageHandler = new Thread(() => ReceiveMessages());
                incomingMessageHandler.IsBackground = true;
                incomingMessageHandler.Start();


            }
            if (isConnectedToServer)
            {

            }

        }

        private void btnZumbido_Click(object sender, EventArgs e)
        {
            string message;
            message = "SEND_BUZZ;" + totextbox.Text + ";" + messagebodytextbox.Text;

            strWritter.WriteLine(message);
            strWritter.Flush();


        }

        void cam_NewFrame(object sender, NewFrameEventArgs eventargs)
        {

            Bitmap bit = (Bitmap)eventargs.Frame.Clone();
            pictureBox2.Image = bit;

            if (pictureBox2.Image != null)
            {
                imagen = bit;

            }
        }

        private void btnRecibirVideo_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[cbCamaras.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            UdpClient tempSocket = new UdpClient();


            if (tbIP.Text != "")
            {


                Byte[] sendBytes = imageToByteArray(imagen);
                IPEndPoint tempipep = new IPEndPoint(IPAddress.Parse(tbIP.Text), 12446);
                tempSocket.Connect(tempipep);
                tempSocket.Send(sendBytes, sendBytes.Length);

            }
        }

        private void btnEnviarVideo_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            backgroundWorker2.CancelAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UdpClient tempSocket = new UdpClient();

            if (tbIP.Text != "")
            {
                Byte[] sendBytes = imageToByteArray(imagen);
                IPEndPoint tempipep = new IPEndPoint(IPAddress.Parse(tbIP.Text), 12446);
                tempSocket.Connect(tempipep);
                tempSocket.Send(sendBytes, sendBytes.Length);
            }
        }

        public void sendMail(string destinatario, string asunto, string adj)
        {
            MailMessage msg = new MailMessage();
            //Quien escribe al correo
            msg.From = new MailAddress("proyectos.lmad@gmail.com");
            //A quien va dirigido
            msg.To.Add(new MailAddress(destinatario));
            //Asunto
            msg.Subject = asunto;
            //Contenido del correo
            msg.Body = "holas";
            //Adjuntamos archivo
            msg.Attachments.Add(new Attachment(adj, System.Net.Mime.MediaTypeNames.Image.Jpeg));
            //Servidor smtp de hotmail
            msg.IsBodyHtml = true;

            SmtpClient clienteSmtp = new SmtpClient();
            clienteSmtp.Host = "smtp.gmail.com";
            clienteSmtp.Port = 587;
            clienteSmtp.EnableSsl = true;
            clienteSmtp.UseDefaultCredentials = true;
            //Se envia el correo
            clienteSmtp.Credentials = new NetworkCredential("proyectos.lmad@gmail.com", "holas123");

            try
            {
                clienteSmtp.Send(msg);
                MessageBox.Show("Correo enviado");
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Error al enviar el correo " + ex.Message);
            }
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;



            lblArchivoAdjunto.Text = "Archivo:" + path;

            sendMail("d_r_dedoverde@hotmail.com", "Proyecto POI", path);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            UdpClient tempSocket2 = new UdpClient(12446);

            while (true)
            {
                IPEndPoint tempipep = new IPEndPoint(IPAddress.Any, 12446);

                EndPoint temip = (EndPoint)tempipep;


                byte[] recivesImage = tempSocket2.Receive(ref tempipep);

                imagen2 = byteArrayToImage(recivesImage);

                pictureBox1.Image = imagen2;
            }
        }
    }
}