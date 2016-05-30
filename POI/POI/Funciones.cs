
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Data;
using System.Net.Sockets;

namespace Funciones
{
    class cFunciones
    {
        public static int GlobalintIDGrupo;
        public static string GlobalstrNombreGrupo;
        public static int GlobalintIDSubGrupo;
        public static string GlobalstrNombreSubGrupo;
        public static string GlobalstrDireccionIPSubGrupo;
        public static int GlobalintPuertoSubGrupo;

        public static int GlobalintIDUsuarioCliente;
        public static string GlobalstrNombreUsuarioCliente;
        public static string GlobalstrDireccionIPCliente;
        public static string GlobalstrEmailUsuarioCliente;

        public static int GlobalintIDUsuarioDestino;
        public static string GlobalstrNombreClienteDestino;
        public static string GlobalstrDireccionIPDestino;
        public static string GlobalstrEmailUsuarioDestino;

        public static string GlobalstrIPChatPrivado;
        public static string GlobalintPuertoPrivado;





        public static string GlobalstrServerDB = @"MSL\MSL";
        public static string GlobalstrNombreDB = @"dbPOI";
        public static string GlobalstrUsernameDB = "sa";
        public static string GlobalstrPasswordDB = "marcelo1234";




        #region Conexiones a la Base de Datos

        //Para este comando, el usuario debe indicar a que servidor, base de datos, su usuario y contraseña
        // Este procedimiento no esta validado

        public static bool EnviarComandoSQL(string strServerDB, string strNombreDB, string strUsernameDB, string strPasswordDB, string strQuery, string strError)
        {
            string strConn;
            try
            {
                strConn = @" User ID = " + GlobalstrUsernameDB + ";" +
                     "Password = " + GlobalstrPasswordDB + "; " +
                     "Data Source =" + GlobalstrServerDB + "; " +
                     "Initial Catalog =" + GlobalstrNombreDB;

                var con = new SqlConnection(strConn);
                var cmdSQL = new SqlCommand();
                cmdSQL.CommandText = strQuery;
                cmdSQL.Connection = con;
                con.Open();
                int t = cmdSQL.ExecuteNonQuery();
                con.Close();
                return true;

            }
            catch (InvalidCastException e)
            {
                MessageBox.Show(e.ToString(), "Error");
                return false;
            }
        }

        //OK
        public static bool EnviarComandoSQLMIServer(string strQuery, string MiError)
        {
            string strConn;
            try
            {
                strConn = @" User ID = " + GlobalstrUsernameDB + ";" +
                    "Password = " + GlobalstrPasswordDB + "; " +
                    "Data Source =" + GlobalstrServerDB + "; " +
                    "Initial Catalog =" + GlobalstrNombreDB;

                var con = new SqlConnection(strConn);
                var cmdSQL = new SqlCommand();
                cmdSQL.CommandText = strQuery;
                cmdSQL.Connection = con;
                con.Open();
                int t = cmdSQL.ExecuteNonQuery();
                con.Close();
                if (t == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (InvalidCastException e)
            {
                MessageBox.Show(e.ToString(), MiError);
                return false;
            }
        }

        // Este procedimiento no esta validado
        public static long EnviarComandoSQLReturnID(string strServerDB, string strNombreDB, string strUsernameDB, string strPasswordDB, string strQuery, string strError)
        {
            string strConn;
            try
            {
                strConn = @" User ID = " + GlobalstrUsernameDB + ";" +
                   "Password = " + GlobalstrPasswordDB + "; " +
                   "Data Source =" + GlobalstrServerDB + "; " +
                   "Initial Catalog =" + GlobalstrNombreDB;

                var con = new SqlConnection(strConn);
                var cmdSQL = new SqlCommand();
                cmdSQL.CommandText = strQuery + " select @@IDENTITY";
                cmdSQL.Connection = con;
                con.Open();
                // este procedimiento debe modificarse, genera errores
                int t = (int)cmdSQL.ExecuteScalar();

                con.Close();
                return t;
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show(e.ToString(), "Error");
                return 0;
            }
        }

        //OK
        public static Int32 EnviarComandoSQLMIServerReturnID(string strQuery, string MiError)
        {
            string strConn;
            try
            {
                Int32 t = 0;
                strConn = @" User ID = " + GlobalstrUsernameDB + ";" +
                   "Password = " + GlobalstrPasswordDB + "; " +
                   "Data Source =" + GlobalstrServerDB + "; " +
                   "Initial Catalog =" + GlobalstrNombreDB;

                var con = new SqlConnection(strConn);
                var cmdSQL = new SqlCommand();
                cmdSQL.CommandText = strQuery + " select @@IDENTITY";
                cmdSQL.Connection = con;
                con.Open();
                object k = cmdSQL.ExecuteScalar();
                t = Convert.ToInt32(k);
                //t = (Int32)k;

                con.Close();
                return t;
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show(e.ToString(), MiError);
                return 0;
            }
        }

        //OK
        public static DataSet LlenarDatasetMiServer(string strQuery, string strTabla, string MiError)
        {
            string strConn;
            try
            {
                //strConn = @"Data Source = " + GlobalstrServerDB + "; Database = " + GlobalstrNombreDB +
                //    "; User ID = " + GlobalstrUsernameDB + "; Password = " + GlobalstrPasswordDB;

                //strConn = @"Data Source=" + GlobalstrServerDB + ";Initial Catalog=" + GlobalstrNombreDB +
                //"; User ID=" + GlobalstrUsernameDB + ";password=" + GlobalstrPasswordDB + "; MultipleActiveResultSets=True;";

                strConn = @" User ID = " + GlobalstrUsernameDB + ";" +
                    "Password = " + GlobalstrPasswordDB + "; " +
                    "Data Source =" + GlobalstrServerDB + "; " +
                    "Initial Catalog =" + GlobalstrNombreDB;

                //Persist Security Info=False;

                //strConn = @"Persist Security Info=False; Data Source=" + GlobalstrServerDB + ";Initial Catalog=" + GlobalstrNombreDB +
                //"; Integrated Security=SSPI;User ID = " + GlobalstrUsernameDB + "; Password = " + GlobalstrPasswordDB + "; ";

                var con = new SqlConnection(strConn);
                var cmdSQL = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter(strQuery, con);
                DataSet ds = new DataSet();
                da.Fill(ds, strTabla);
                con.Close();
                return ds;
            }
            catch (InvalidCastException e)
            {
                DataSet dsVacio = new DataSet();
                MessageBox.Show(e.ToString(), MiError);
                return dsVacio;
            }
        }

        #endregion

        #region Limpieza y llenado de combos

        public static void LimpiarCombo(ComboBox cmbCombo)
        {
            cmbCombo.DataSource = null;
            cmbCombo.Items.Clear();
        }

        public static void LlenarCombo(string strQry, ComboBox cmbCombo, string ValueMbr, string DisplayMbr)
        {
            LimpiarCombo(cmbCombo);
            DataSet dsCombo = new DataSet();
            dsCombo = LlenarDatasetMiServer(strQry, "Combo", "Error al llenar ComboBox " + cmbCombo.Name);
            cmbCombo.DataSource = dsCombo.Tables[0].DefaultView;
            cmbCombo.DisplayMember = DisplayMbr;
        }

        #endregion

        #region Limpieza y llenado de DataGrid

        public static void LimpiarDataGrid(DataGridView x)
        {
            x.DataSource = null;
            x.AllowUserToAddRows = false;
            x.AllowUserToDeleteRows = false;
            x.AllowUserToOrderColumns = true;
            x.AllowUserToResizeColumns = true;
            x.AllowUserToResizeRows = false;
            x.RowHeadersVisible = false;
            x.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            x.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            x.Rows.Clear();
            x.Columns.Clear();
        }

        public static void LlenarDataGrid(string strQry, DataGridView x)
        {
            DataSet dsGrid = new DataSet();
            dsGrid = LlenarDatasetMiServer(strQry, "Grid", "Error al llenar GridView " + x.Name);
            x.DataSource = dsGrid.Tables[0];
        }

        #endregion

        //public static IPAddress ObtenerDireccionIP()
        //{
        //    var host = Dns.GetHostEntry(Dns.GetHostName());
        //    System.Net.NetworkInformation.Ping ping = new Ping();
        //    var replay = ping.Send(host.ToString());

        //    if (replay.Status == System.Net.NetworkInformation.IPStatus.Success)
        //    {
        //        return replay.Address;
        //    }
        //    return null;
        //}

    }
}

// Para obtener el nombre del Host:

//  var host = Dns.GetHostEntry(Dns.GetHostName());

//Checa con esta a ver si obtienes la Ip v4
// de un adaoptador u otro

//public string GetLocalIPv4(NetworkInterfaceType _type)
//{
//    string output = "";
//    foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
//    {
//        if (item.NetworkInterfaceType == _type ++ item.OperationalStatus == OperationalStatus.Up)
//        {
//            foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
//            {
//                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
//                {
//                    output = ip.Address.ToString();
//                }
//            }
//        }
//    }
//    return output;
//}
//Now to get the IPv4 address of your Ethernet network interface call:

//GetLocalIPv4(NetworkInterfaceType.Ethernet);
//Or your Wireless interface:

//GetLocalIPv4(NetworkInterfaceType.Wireless80211);
