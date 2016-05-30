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

namespace TcpClientProgram

{
    public partial class frmChatPrivadoCliente : Form
    {
        TcpClient tcpClient;
        bool isConnectedToServer = false;
        private StreamWriter strWritter;
        private StreamReader strReader;
        private Thread incomingMessageHandler;

        public frmChatPrivadoCliente()
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
            listBox1.Items.Add("Tu: "+messagebodytextbox.Text.ToString());

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

                connectionEstablish = "CONNECT_REQUEST;"+userNameTextbox.Text;


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
                    setClientMessage(source+" dice:"+" "+message);
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
    }
}
