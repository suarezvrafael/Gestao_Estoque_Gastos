using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
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

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public FrmCadEmpresa()
        {
            con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;pwd=;uid=root;");
            //cmd.Connection = con;

            InitializeComponent();
        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
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
            string rua = mtxtRua.Text;

            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO tblempresa (CNPJ,razaoSocial,rua,bairro,numeroEndereco,complemento,email,telefone,nomeFantasia,cidade) VALUES (@CNPJ,@razaoSocial,@rua,@bairro,@numeroResidencia,@complemento,@email,@telefone,@nomeFantasia,@cidade)";

                cmd.Parameters.AddWithValue("CNPJ", CNPJ);
                cmd.Parameters.AddWithValue("razaoSocial", razaoSocial);
                cmd.Parameters.AddWithValue("rua", rua);
                cmd.Parameters.AddWithValue("bairro", bairro);
                cmd.Parameters.AddWithValue("numeroResidencia", numeroResidencia);
                cmd.Parameters.AddWithValue("complemento", complemento);
                cmd.Parameters.AddWithValue("email",email);
                cmd.Parameters.AddWithValue("telefone", telefone);
                cmd.Parameters.AddWithValue("nomeFantasia",nomeFantasia);
                cmd.Parameters.AddWithValue("cidade", cidade);

                int retornoDoInsert = cmd.ExecuteNonQuery();

                if (retornoDoInsert > 0)
                {
                    MessageBox.Show("Empresa cadastrada com sucesso!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, contate o suporte técnico para verificar!");
            }
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
