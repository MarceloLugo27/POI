using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace TcpClientProgram

{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        bool isConnectedToServer = false;
        private StreamWriter strWritter;
        private StreamReader strReader;
        private Thread incomingMessageHandler;

        public Form1()
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
                    setClientMessage(source+" Says:"+" "+message);
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

    }
}
