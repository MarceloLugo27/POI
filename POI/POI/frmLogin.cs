using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Funciones;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace POI.POI
{
    public partial class frmLogin : Form
    {
        bool loginExitoso = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EvaluarUsuario();

        }

        private void EvaluarUsuario()
        {
            string strqry = "SELECT [IDUsuario], [strNombreUsuario], [intGrupo], [strEmail] FROM [dbPOI].[dbo].[tblUsuarios] WHERE intLogin = '" + tbUsername.Text +
            "' AND strPassword = '" + tbPassword.Text + "' AND intvarcontrolUsuario = 1";
            DataSet dsLogin = cFunciones.LlenarDatasetMiServer(strqry, "Grupo", "Error de conexión");
            if (dsLogin.Tables[0].Rows.Count == 0)
            {
                loginExitoso = false;
                MessageBox.Show("El usuario o la constraseña son inválidos, intente de nuevo.", "Error al iniciar sesión");
                tbUsername.Text = "";
                tbPassword.Text = "";
                tbUsername.Focus();

            }
            else
            {
                loginExitoso = true;

                //CAMBIAR POR ESTA MIENTRAS ESTEMOS EN LA REVISION COMENTAR LA OTRA!!!!!!!!!!!!!!!!!!!!!
                cFunciones.GlobalstrDireccionIPCliente = GetLocalIPv4(NetworkInterfaceType.Wireless80211);

                //cFunciones.GlobalstrDireccionIPCliente = GetLocalIPv4(NetworkInterfaceType.Ethernet);
                cFunciones.GlobalintIDUsuarioCliente = int.Parse(dsLogin.Tables[0].Rows[0][0].ToString());
                cFunciones.GlobalstrNombreUsuarioCliente = dsLogin.Tables[0].Rows[0][1].ToString();
                cFunciones.GlobalintIDGrupo = int.Parse(dsLogin.Tables[0].Rows[0][2].ToString());
                cFunciones.GlobalstrEmailUsuarioCliente = dsLogin.Tables[0].Rows[0][3].ToString();

                string strqryIP = "UPDATE [tblDirecciones] SET [strDireccionIP] = '" + cFunciones.GlobalstrDireccionIPCliente + "'" +
                    "WHERE [IDUsuario] = " + cFunciones.GlobalintIDUsuarioCliente;
                cFunciones.EnviarComandoSQLMIServer(strqryIP, "");
                this.Hide();

                frmSeleccionGrupos FormSeleccionGrupos = new frmSeleccionGrupos();
                FormSeleccionGrupos.ShowDialog();
                
                this.Close();

            }
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

        //Now to get the IPv4 address of your Ethernet network interface call:

        //GetLocalIPv4(NetworkInterfaceType.Ethernet);
        //Or your Wireless interface:

        //GetLocalIPv4(NetworkInterfaceType.Wireless80211);

        private void frmLogin_Load(object sender, EventArgs e)
        {
            tbUsername.Focus();
        }
    }
}
