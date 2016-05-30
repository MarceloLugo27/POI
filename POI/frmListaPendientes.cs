using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Funciones;

namespace POI
{
    public partial class frmListaPendientes : Form
    {
        public frmListaPendientes()
        {
            InitializeComponent();
        }

        private void ActualizarListado()
        {
            cFunciones.LimpiarDataGrid(DGVPendientes);
            string strqry = "SELECT IDPendiente, strPendiente, strStatusPendiente FROM vstPendientes WHERE IDUsuario = " + cFunciones.GlobalintIDUsuarioCliente;
            DataSet dsPendientes = cFunciones.LlenarDatasetMiServer(strqry, "Pendientes", "Error de conexión");
            cFunciones.LlenarDataGrid(strqry, DGVPendientes);
        }

        private void frmListaPendientes_Load(object sender, EventArgs e)
        {
            ActualizarListado();
            DGVPendientes.Columns[0].Visible = false;
            DGVPendientes.Columns[1].Visible = false;
        }

        private void btnAñadirPendiente_Click(object sender, EventArgs e)
        {
            cFunciones.LimpiarDataGrid(DGVPendientes);
            string strInsertarPendiente = "INSERT INTO tblPendientes (IDGrupo, IDSubGrupo, IDUsuario, strPendiente, strStatusPendiente, intvarcontrolPendiente) VALUES" +
                "(1, 4, " + cFunciones.GlobalintIDUsuarioCliente + ", '" + tbPendiente.Text + "', 'Pendiente', 1)";
            cFunciones.EnviarComandoSQLMIServer(strInsertarPendiente, "Error de conexión");
            ActualizarListado();
        }

        private void DGVPendientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strActualizarListado;
            int intIndexPendiente = int.Parse(DGVPendientes.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (DGVPendientes.Rows[e.RowIndex].Cells[2].Value.ToString() == "Pendiente")
            {
                strActualizarListado = "UPDATE tblPendientes SET strStatusPendiente = 'Completado' WHERE IDUsuario = " + cFunciones.GlobalintIDUsuarioCliente + " AND " +
                    "IDPendiente = " + intIndexPendiente;
                cFunciones.EnviarComandoSQLMIServer(strActualizarListado, "");
            }

            if (DGVPendientes.Rows[e.RowIndex].Cells[2].Value.ToString() == "Completado")
            {
                strActualizarListado = "UPDATE tblPendientes SET strStatusPendiente = 'Pendiente' WHERE IDUsuario = " + cFunciones.GlobalintIDUsuarioCliente + " AND " +
                    "IDPendiente = " + intIndexPendiente;
                cFunciones.EnviarComandoSQLMIServer(strActualizarListado, "");
            }
            ActualizarListado();   
            
        }
    }
}
