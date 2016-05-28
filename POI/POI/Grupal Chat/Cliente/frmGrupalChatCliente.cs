using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Funciones;

namespace frmGrupalChatCliente
{
    public partial class frmGrupalChatCliente : Form
    {
        string strStatus;
        // Will hold the user name
        private string UserName = "Desconocido";
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private TcpClient tcpServer;
        // Needed to update the form with messages from another thread
        private delegate void UpdateLogCallback(string strMessage);
        // Needed to set the form to a "disconnected" state from another thread
        private delegate void CloseConnectionCallback(string strReason);
        private Thread thrMessaging;
        private IPAddress ipAddr;
        private bool Connected;

        private int ChatGrupalPuerto = cFunciones.GlobalintPuertoSubGrupo;

        public frmGrupalChatCliente()
        {
            // On application exit, don't forget to disconnect first
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
        }

        // The event handler for application exit
        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Connected == true)
            {
                // Closes the connections, streams, etc.
                Connected = false;
                swSender.Close();
                srReceiver.Close();
                tcpServer.Close();
            }
        }

        private void ActualizarStatus()
        {
            string strqryStatus = "UPDATE [tblStatus] SET [strStatus] = '" + strStatus + "'" +
                    "WHERE [IDUsuario] = '" + cFunciones.GlobalintIDUsuarioCliente + "'";
            cFunciones.EnviarComandoSQLMIServer(strqryStatus, "");
        }

        private void ActualizarConectados()
        {
            cFunciones.LimpiarDataGrid(DGVUsuariosConectados);
            string strqry = "SELECT [strNombreUsuario], [strStatus], [strDireccionIP], [strEmail] FROM vstStatus WHERE strStatus <> 'Desconectado'" +
                "AND IDSubGrupo = " + cFunciones.GlobalintIDSubGrupo;
            cFunciones.LlenarDataGrid(strqry, DGVUsuariosConectados);

        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            // If we are not currently connected but awaiting to connect
            if (Connected == false)
            {
                // Initialize the connection
                InitializeConnection();
                ActualizarConectados();
                

            }
            else // We are connected, thus disconnect
            {
                CloseConnection("Desconectado bajo solicitud.");
            }
        }

        private void InitializeConnection()
        {
            // Parse the IP address from the TextBox into an IPAddress object
            ipAddr = IPAddress.Parse(txtIp.Text);
            // Start a new TCP connections to the chat server
            tcpServer = new TcpClient();
            tcpServer.Connect(ipAddr, ChatGrupalPuerto);

            // Helps us track whether we're connected or not
            Connected = true;
            // Prepare the form
             cFunciones.GlobalstrNombreUsuarioCliente = txtUser.Text;

            // Disable and enable the appropriate fields
            txtIp.Enabled = false;
            txtUser.Enabled = false;
            txtMessage.Enabled = true;
            btnSend.Enabled = true;
            btnConnect.Enabled = false;

            // Send the desired username to the server
            swSender = new StreamWriter(tcpServer.GetStream());
            swSender.WriteLine(txtUser.Text);
            swSender.Flush();

            // Start the thread for receiving messages and further communication
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();
        }

        private void ReceiveMessages()
        {
            // Receive the response from the server
            srReceiver = new StreamReader(tcpServer.GetStream());
            // If the first character of the response is 1, connection was successful
            string ConResponse = srReceiver.ReadLine();
            // If the first character is a 1, connection was successful
            if (ConResponse[0] == '1')
            {
                // Update the form to tell it we are now connected
                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Conectado!" });
            }
            else // If the first character is not a 1 (probably a 0), the connection was unsuccessful
            {
                string Reason = "No conectado: ";
                // Extract the reason out of the response message. The reason starts at the 3rd character
                Reason += ConResponse.Substring(2, ConResponse.Length - 2);
                // Update the form with the reason why we couldn't connect
                this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { Reason });
                // Exit the method
                return;
            }
            // While we are successfully connected, read incoming lines from the server
            while (Connected)
            {
                // Show the messages in the log TextBox
                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { srReceiver.ReadLine() });
            }
        }

        // This method is called from a different thread in order to update the log TextBox
        private void UpdateLog(string strMessage)
        {
            // Append text also scrolls the TextBox to the bottom each time
            txtLog.AppendText(strMessage + "\r\n");
        }

        // Closes a current connection
        private void CloseConnection(string Reason)
        {
            // Show the reason why the connection is ending
            txtLog.AppendText(Reason + "\r\n");
            // Enable and disable the appropriate controls on the form
            txtIp.Enabled = true;
            txtUser.Enabled = true;
            txtMessage.Enabled = false;
            btnSend.Enabled = false;
            btnConnect.Text = "Conectar";

            // Close the objects
            Connected = false;
            swSender.Close();
            srReceiver.Close();
            tcpServer.Close();
        }

        // Sends the message typed in to the server
        private void SendMessage()
        {
            if (txtMessage.Lines.Length >= 1)
            {
                string strqry = "INSERT INTO [dbPOI].[dbo].[tblMensajeChat]([IDSubGrupo],[IDUsuario],[strContenidoMensaje]) VALUES(" + cFunciones.GlobalintIDSubGrupo + ", " + cFunciones.GlobalintIDUsuarioCliente + ", '" + txtMessage.Text + "')";
                cFunciones.EnviarComandoSQLMIServer(strqry, "");
                swSender.WriteLine(txtMessage.Text);
                swSender.Flush();
                txtMessage.Lines = null;
            }
            txtMessage.Text = "";
        }

        // We want to send the message when the Send button is clicked
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
            
            txtMessage.Text = "";
        }

        // But we also want to send the message once Enter is pressed
        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the key is Enter
            if (e.KeyChar == (char)13)
            {
                SendMessage();
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {

            
            this.Text = "Chat Grupal: " + cFunciones.GlobalstrNombreSubGrupo;
            txtIp.Text = cFunciones.GlobalstrDireccionIPSubGrupo;
            lblServer.Visible = false;
            txtIp.Visible = false;
            txtUser.Text = cFunciones.GlobalstrNombreUsuarioCliente;
            txtUser.Enabled = false;

            // If we are not currently connected but awaiting to connect
            if (Connected == false)
            {
                // Initialize the connection
                InitializeConnection();
                ActualizarConectados();


            }
            else // We are connected, thus disconnect
            {
                CloseConnection("Desconectado bajo solicitud.");
            }

        }

        private void DGVUsuariosConectados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkbStatus_CheckedChanged(object sender, EventArgs e)
        {
            DGVUsuariosConectados.Columns[2].Visible = false;
            DGVUsuariosConectados.Columns[3].Visible = false;

            if (chkbStatus.Checked == true)
            {
                chkbStatus.Text = "Conectado";
                strStatus = "Conectado";
                ActualizarStatus();
                ActualizarConectados();
            } 
            if (chkbStatus.Checked == false)
            {
                chkbStatus.Text = "Ausente";
                strStatus = "Ausente";
                ActualizarStatus();
                ActualizarConectados();

            }
        }

        private void DGVUsuariosConectados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cFunciones.GlobalstrIdNombreClienteDestino = DGVUsuariosConectados.Rows[e.RowIndex].Cells[0].Value.ToString();
            cFunciones.GlobalstrDireccionIPDestino = DGVUsuariosConectados.Rows[e.RowIndex].Cells[2].Value.ToString();
            cFunciones.GlobalstrEmailUsuarioDestino = DGVUsuariosConectados.Rows[e.RowIndex].Cells[3].Value.ToString();
            DGVUsuariosConectados.Columns[2].Visible = false;
            DGVUsuariosConectados.Columns[3].Visible = false;

            //frmGrupalChatCliente.frmGrupalChatCliente FormChatGrupal = new frmGrupalChatCliente.frmGrupalChatCliente();
            //FormChatGrupal.ShowDialog();

            TcpClientProgram.frmPrivateChatClient FormCharPrivado = new TcpClientProgram.frmPrivateChatClient();
            FormCharPrivado.ShowDialog();

        }

        private void frmGrupalChatCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            string strqryStatus = "UPDATE [tblStatus] SET [strStatus] = '" + "Desconectado" + "'" +
                   "WHERE [IDUsuario] = '" + cFunciones.GlobalintIDUsuarioCliente + "'";
            cFunciones.EnviarComandoSQLMIServer(strqryStatus, "");
        }
    }
}