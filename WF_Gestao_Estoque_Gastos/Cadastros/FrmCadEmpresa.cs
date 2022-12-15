using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public partial class FrmCadEmpresa : MaterialForm
    {
        public FrmCadEmpresa()
        {
            InitializeComponent();
        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click_1(object sender, EventArgs e)
        {
            string razaoSocial = mtxtRazaoSocial.Text;
            string nomeFantasia = mtxtNomeFantasia.Text;
            var CNPJ = mtxtCnpj.Text;
            var telefone = mtxtTelefone.Text;
            string email = mtxtEmail.Text;
            string cidade = mtxtCidade.Text;
            string bairro = mtxtBairro.Text;
            string complemento = mtxtComplemento.Text;
            var numeroResidencia = mtxtNumero;


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void materialLabel11_Click(object sender, EventArgs e)
        {

        }
    }
}
