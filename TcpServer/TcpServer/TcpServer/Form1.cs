using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Funciones;

namespace TcpServer
{
    public partial class Form1 : Form
    {
        Server server;

        public Form1()
        {
            InitializeComponent();
            label3.Text = "Server is Not Running";
        }

        private void startListnerButton_Click(object sender, EventArgs e)
        {
            string strqry = "UPDATE tblSubGrupo SET [strDireccionIP] = '" + ipAddressTextbox.Text + "', [intPuerto] = " + portTextBox.Text + " WHERE IDGrupo = 7";
            cFunciones.EnviarComandoSQLMIServer(strqry, "");

             server = new Server(ipAddressTextbox.Text,int.Parse(portTextBox.Text));
             server.startListener();

             server.OnclientConnected += new Server.PropertyChangeHandler(server_OnclientConnected);


                
             label3.Text = "Server is Up and Running";


        }

        void server_OnclientConnected(object sender, EventArgs args)
        {
            User usr = (User)sender;
            CheckForIllegalCrossThreadCalls = false;
            listBox1.Items.Add(usr.UserName + " Joined to The Server");



        }



        private void stopListnerButton_Click(object sender, EventArgs e)
        {
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           ipAddressTextbox.Text = GetLocalIPv4(NetworkInterfaceType.Ethernet);

        }

        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

       
    }
}
