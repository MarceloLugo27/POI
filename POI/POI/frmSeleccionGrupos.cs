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
    public partial class frmSeleccionGrupos : Form
    {
        public frmSeleccionGrupos()
        {
            InitializeComponent();
        }

        private void SeleccionGrupo(int IDGrupo)
        {
            cFunciones.GlobalintIDGrupo = IDGrupo;
            string strqry = "SELECT strNombreGrupo from tblGrupo WHERE IDGrupo = " + IDGrupo;
            DataSet dsGrupo = cFunciones.LlenarDatasetMiServer(strqry, "Grupo", "Error de conexión");
            cFunciones.GlobalstrNombreGrupo = dsGrupo.Tables[0].Rows[0][0].ToString();
            label1.Text = cFunciones.GlobalstrNombreGrupo;

            cFunciones.LimpiarDataGrid(DGVSubGrupos);
            string strDGVqry = "SELECT strNombreGrupo AS [Grupo], IDSubGrupo, strDireccionIP, intPuerto FROM tblSubGrupo WHERE IDGrupo = " + IDGrupo;
            cFunciones.LlenarDataGrid(strDGVqry, DGVSubGrupos);
            DGVSubGrupos.Columns[1].Visible = false;
            DGVSubGrupos.Columns[2].Visible = false;
            DGVSubGrupos.Columns[3].Visible = false;
        }

        private void frmSeleccionGrupos_Load(object sender, EventArgs e)
        {
            


            label2.Text = cFunciones.GlobalstrNombreUsuarioCliente;
            switch (cFunciones.GlobalintIDGrupo)
            {
                case 0:
                    btnGrupoLF.Enabled = true; btnGrupoLM.Enabled = true; btnGrupoLA.Enabled = true;
                    btnGrupoLCC.Enabled = true; btnGrupoLMAD.Enabled = true; btnGrupoLSTI.Enabled = true;
                    break;
                case 1:
                    btnGrupoLF.Enabled = true; btnGrupoLM.Enabled = false; btnGrupoLA.Enabled = false;
                    btnGrupoLCC.Enabled = false; btnGrupoLMAD.Enabled = false; btnGrupoLSTI.Enabled = false;
                    break;
                case 2:
                    btnGrupoLF.Enabled = false; btnGrupoLM.Enabled = true; btnGrupoLA.Enabled = false;
                    btnGrupoLCC.Enabled = false; btnGrupoLMAD.Enabled = false; btnGrupoLSTI.Enabled = false;
                    break;
                case 3:
                    btnGrupoLF.Enabled = false; btnGrupoLM.Enabled = false; btnGrupoLA.Enabled = true;
                    btnGrupoLCC.Enabled = false; btnGrupoLMAD.Enabled = false; btnGrupoLSTI.Enabled = false;
                    break;
                case 4:
                    btnGrupoLF.Enabled = false; btnGrupoLM.Enabled = false; btnGrupoLA.Enabled = false;
                    btnGrupoLCC.Enabled = true; btnGrupoLMAD.Enabled = false; btnGrupoLSTI.Enabled = false;
                    break;
                case 5:
                    btnGrupoLF.Enabled = false; btnGrupoLM.Enabled = false; btnGrupoLA.Enabled = false;
                    btnGrupoLCC.Enabled = false; btnGrupoLMAD.Enabled = true; btnGrupoLSTI.Enabled = false;
                    break;
                case 6:
                    btnGrupoLF.Enabled = false; btnGrupoLM.Enabled = false; btnGrupoLA.Enabled = false;
                    btnGrupoLCC.Enabled = false; btnGrupoLMAD.Enabled = false; btnGrupoLSTI.Enabled = true;
                    break;

            }
        }

        private void bntGrupoLF_Click(object sender, EventArgs e)
        {
            SeleccionGrupo(1);
        }

        private void btnGrupoLM_Click(object sender, EventArgs e)
        {

            SeleccionGrupo(2);
        }

        private void btnGrupoLA_Click(object sender, EventArgs e)
        {
            SeleccionGrupo(3);
        }

        private void btnGrupoLCC_Click(object sender, EventArgs e)
        {
            SeleccionGrupo(4);
            
        }

        private void btnGrupoLMAD_Click(object sender, EventArgs e)
        {
            SeleccionGrupo(5);
        }

        private void btnGrupoLSTI_Click(object sender, EventArgs e)
        {
            SeleccionGrupo(6);
        }

        private void DGVSubGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cFunciones.GlobalstrNombreSubGrupo = DGVSubGrupos.Rows[e.RowIndex].Cells["Grupo"].Value.ToString();
            cFunciones.GlobalintIDSubGrupo = int.Parse(DGVSubGrupos.Rows[e.RowIndex].Cells["IDSubGrupo"].Value.ToString());
            cFunciones.GlobalstrDireccionIPSubGrupo = DGVSubGrupos.Rows[e.RowIndex].Cells["strDireccionIP"].Value.ToString();
            cFunciones.GlobalintPuertoSubGrupo = int.Parse(DGVSubGrupos.Rows[e.RowIndex].Cells["intPuerto"].Value.ToString());




            this.Hide();
            //ChatClient FormChatClient = new ChatClient();
            //FormChatClient.ShowDialog();
            //frmSeleccionGrupos FormChatGrupal = new  frmSeleccionGrupos();
            //FormChatGrupal.ShowDialog();
            //this.Close();

            frmGrupalChatCliente.frmGrupalChatCliente FormChatGrupal = new frmGrupalChatCliente.frmGrupalChatCliente();
            FormChatGrupal.ShowDialog();

        }

        private void pendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaPendientes FormListaPendientes = new frmListaPendientes();
            FormListaPendientes.ShowDialog();
        }
    }
}