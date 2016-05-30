using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Funciones;
using System.Net.NetworkInformation;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        private delegate void UpdateStatusCallback(string strMessage);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            ChatServer.intPuerto = int.Parse(tbPuerto.Text);
            string strqry = "UPDATE [dbPOI].[dbo].[tblSubGrupo] SET[strDireccionIP] = '" + tbDireccionIP.Text + "', [intPuerto] = " + tbPuerto.Text + " WHERE IDGrupo = " + numericUpDown1.Value;
            cFunciones.EnviarComandoSQLMIServer(strqry, "");

            // Parse the server's IP address out of the TextBox
        IPAddress ipAddr = IPAddress.Parse(tbDireccionIP.Text);
            // Create a new instance of the ChatServer object
            ChatServer mainServer = new ChatServer(ipAddr);
            // Hook the StatusChanged event handler to mainServer_StatusChanged
            ChatServer.StatusChanged += new StatusChangedEventHandler(mainServer_StatusChanged);
            // Start listening for connections
            mainServer.StartListening();
            // Show that we started to listen for connections
            txtLog.AppendText("Monitoreando conexion...\r\n");
        }

        public void mainServer_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Call the method that updates the form
            this.Invoke(new UpdateStatusCallback(this.UpdateStatus), new object[] { e.EventMessage });
        }

        private void UpdateStatus(string strMessage)
        {
            // Updates the log with the message1
            txtLog.AppendText(strMessage + "\r\n");
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

        private void Form1_Load(object sender, EventArgs e)
        {

            //tbDireccionIP.Text = GetLocalIPv4(NetworkInterfaceType.Ethernet);
            tbDireccionIP.Text = GetLocalIPv4(NetworkInterfaceType.Wireless80211);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}