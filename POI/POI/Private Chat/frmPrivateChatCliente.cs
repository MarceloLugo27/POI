using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Funciones;

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
        }
    }
}
