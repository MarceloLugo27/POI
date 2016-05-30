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
using Funciones;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace TcpClientProgram

{
    public partial class frmPrivateChatClient : Form
    {
        TcpClient tcpClient;
        bool isConnectedToServer = false;
        private StreamWriter strWritter;
        private StreamReader strReader;
        private Thread incomingMessageHandler;
        Hashtable emoticons;

        private IPAddress ipa;
        private IPEndPoint ipep, ipe;

        private FilterInfoCollection DispositivoDeVideo;
        private bool haystreaming = false;
        private VideoCaptureDevice FuenteDeVideo;
        private Bitmap imgstream;
        private bool ExisteDispositivo = false;
        private bool startstream = false;
        private Thread Recibir;
        private bool isAliveThread = false;
        private Image imgchat;
        private Image imageIn;
        private UdpClient socketrecibevideo;
        private Thread mListenThread;
        private Socket mServer;
        private WaveIn wavein;
        private WaveOut waveout;
        private static BufferedWaveProvider wavProv;

        public Byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }       //CONVIERTE LA IMAGEN A BYTE[]


        //void CreateEmoticons()
        //{
        //    emoticons = new Hashtable(1);
        //    emoticons =
        //}

        public frmPrivateChatClient()
        {
            InitializeComponent();
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

            

            message = "SEND_MSG;" + totextbox.Text+";"+messagebodytextbox.Text;
            
            strWritter.WriteLine(message);
            strWritter.Flush();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            string strqry = "SELECT strDireccionIP, intPuerto FROM tblSubGrupo WHERE IDGrupo = 7";
            DataSet dsChatPrivado = cFunciones.LlenarDatasetMiServer(strqry, "Chat", "");
            cFunciones.GlobalstrIPChatPrivado = dsChatPrivado.Tables[0].Rows[0][0].ToString();
            cFunciones.GlobalintPuertoPrivado = dsChatPrivado.Tables[0].Rows[0][1].ToString();

            serveripTextbox.Text = cFunciones.GlobalstrIPChatPrivado;
            portTextbox.Text = cFunciones.GlobalintPuertoPrivado;
            userNameTextbox.Text = cFunciones.GlobalstrNombreUsuarioCliente;
            totextbox.Text = cFunciones.GlobalstrIdNombreClienteDestino;

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

                if (data[0].Equals("INCOMING_MSG;"))
                {
                    string source = data[1];
                    string message = data[2];
                    setClientMessage(source+" dice:"+" "+message);
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;

            string strqry = "SELECT strDireccionIP, intPuerto FROM tblSubGrupo WHERE IDGrupo = 7";
            DataSet dsChatPrivado = cFunciones.LlenarDatasetMiServer(strqry, "Chat", "");
            cFunciones.GlobalstrIPChatPrivado = dsChatPrivado.Tables[0].Rows[0][0].ToString();
            cFunciones.GlobalintPuertoPrivado = dsChatPrivado.Tables[0].Rows[0][1].ToString();

            serveripTextbox.Text = cFunciones.GlobalstrIPChatPrivado;
            portTextbox.Text = cFunciones.GlobalintPuertoPrivado;
            userNameTextbox.Text = cFunciones.GlobalstrNombreUsuarioCliente;
            totextbox.Text = cFunciones.GlobalstrIdNombreClienteDestino;

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

        public void Video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            pbEmisor.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEmisor.Image = Imagen;
            imgstream = Imagen;
        }

        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo = null;
                }
        }

        private void btnSeleccionarCamara_Click(object sender, EventArgs e)
        {
            if (btnSeleccionarCamara.Text == "Seleccionar")
            {
                if (ExisteDispositivo)
                {
                    FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbCamaras.SelectedIndex].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                    FuenteDeVideo.Start();
                    btnSeleccionarCamara.Text = "X";
                    cbCamaras.Enabled = false;
                    btnIniciar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error: No se encuenta el Dispositivo");
                }
            }
            else
            {
                if (FuenteDeVideo.IsRunning)
                {
                    TerminarFuenteDeVideo();
                    btnSeleccionarCamara.Text = "Seleccionar";
                    btnIniciar.Enabled = false;
                    cbCamaras.Enabled = true;
                    pbEmisor.Image = null;
                }
            }
        }

        private void Recorded(object sender, WaveInEventArgs e)
        {
            try
            {
                IPEndPoint cIpEnd = new IPEndPoint(ipa, 12131);
                mServer.SendTo(e.Buffer, cIpEnd);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void startListen(object sender)
        {
            //MessageBox.Show("Thread Start");
            // UDP Start
            IPEndPoint sIpEnd = new IPEndPoint(IPAddress.Any, 12131);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(sIpEnd);

            IPEndPoint remoteIpEnd = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)remoteIpEnd;


            waveout.Play();
            int offset = 0;
            while (true)
            {
                byte[] data = new byte[65535];
                int recv = sock.ReceiveFrom(data, ref Remote);
                wavProv.AddSamples(data, offset, recv);

            }
        }


        public void SendStream(Image img)
        {
            UdpClient tempSocket = new UdpClient();
            Byte[] sendBytes = imageToByteArray(img);
            IPEndPoint tempipep = new IPEndPoint(ipa, 12447);
            tempSocket.Send(sendBytes, sendBytes.Length, tempipep);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (haystreaming == false)
            {
                timer1_stream.Enabled = true;
                haystreaming = true;

                wavein = new WaveIn();
                wavein.WaveFormat = new WaveFormat(8000, 16, 1);

                wavein.DataAvailable += new EventHandler<WaveInEventArgs>(Recorded);
                waveout = new WaveOut();
                wavProv = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));

                waveout.Init(wavProv);

                mListenThread = new Thread(new ParameterizedThreadStart(startListen));
                mListenThread.Start();
                mServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                wavein.StartRecording();
            }
            else
            {
                timer1_stream.Enabled = false;
                haystreaming = false;
                pbReceptor.Image = null;
                mListenThread.Abort();
            }
        }

        private void timer1_stream_Tick(object sender, EventArgs e)
        {
            if (haystreaming == true)
            {
                startstream = true;
                SendStream(imgstream);
            }
            else
            {
                startstream = false;
            }
        }
    }
}
