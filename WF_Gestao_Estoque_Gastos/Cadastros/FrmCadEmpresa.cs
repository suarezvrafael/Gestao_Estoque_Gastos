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

            InitializeComponent();
            atualizar_lista();
        }

        private void LimpaCampos()
        {
            mtxtRazaoSocial.Text = String.Empty;
            mtxtNomeFantasia.Text = String.Empty;
            mtxtCnpj.Text = String.Empty;
            mtxtTelefone.Text = String.Empty;
            mtxtEmail.Text = String.Empty;
            mtxtCidade.Text = String.Empty;
            mtxtBairro.Text = String.Empty;
            mtxtComplemento.Text = String.Empty;
            mtxtNumero.Text = String.Empty;
            mtxtRua.Text = String.Empty;


        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) // btnSalvar
        {
            string razaoSocial = mtxtRazaoSocial.Text;
            string nomeFantasia = mtxtNomeFantasia.Text;
            decimal CNPJ = Convert.ToDecimal(mtxtCnpj.Text);
            decimal telefone = Convert.ToDecimal(mtxtTelefone.Text);
            string email = mtxtEmail.Text;
            string cidade = mtxtCidade.Text;
            string bairro = mtxtBairro.Text;
            string complemento = mtxtComplemento.Text;
            int numeroResidencia = Convert.ToInt32(mtxtNumero.Text);
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
                    LimpaCampos();
                    atualizar_lista();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, contate o suporte técnico para verificar!");
            }


        }

        private void materialRaisedButton2_Click(object sender, EventArgs e) // btnExcluir
        {
            if (listViewEmpresa.SelectedIndices.Count <= 0)
            {
                return;
            }
        }

        private void materialRaisedButton1_Click_1(object sender, EventArgs e)  //btnEditar
        {
            string razaoSocial = mtxtRazaoSocial.Text;
            string nomeFantasia = mtxtNomeFantasia.Text;
            decimal CNPJ = Convert.ToDecimal(mtxtCnpj.Text);
            decimal telefone = Convert.ToDecimal(mtxtTelefone.Text);
            string email = mtxtEmail.Text;
            string cidade = mtxtCidade.Text;
            string bairro = mtxtBairro.Text;
            string complemento = mtxtComplemento.Text;
            int numeroResidencia = Convert.ToInt32(mtxtNumero.Text);
            string rua = mtxtRua.Text;


        }

        public void atualizar_lista()
        {
            //cria uma lista do tipo Empresas
            List<Empresa> listaEmpresas = new List<Empresa>();

            con = new MySqlConnection("Server=localhost;Database=gestao_estoque_gasto;user=root;Pwd=;SslMode=none");
            con.Open();

            //seta a conexão para o comando
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT `id`, `CNPJ`, `razaoSocial`, `rua`, `bairro`, `numeroEndereco`, `complemento`, `email`, `telefone`, `nomeFantasia`, `cidade` FROM `tblempresa`";

            //executa o comando
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Empresa empresa = new Empresa()

                {
                    id = Convert.ToInt32(reader["id"].ToString()),
                    CNPJ = Convert.ToDecimal(reader["CNPJ"].ToString()),
                    nomeFantasia = reader["nomeFantasia"].ToString(),
                    email = reader["email"].ToString(),
                    telefone = Convert.ToDecimal(reader["telefone"].ToString()),
                    numeroResidencia = Convert.ToInt32(reader["numeroEndereco"].ToString()),
                    complemento = reader["complemento"].ToString(),
                    cidade = reader["cidade"].ToString(),
                    rua = reader["rua"].ToString(),
                    razaoSocial = reader["razaoSocial"].ToString(),


                };
                listaEmpresas.Add(empresa);
            }
            listViewEmpresa.Items.Clear();
            //adiciona no ListBox os nomes da lista
            foreach (Empresa empresa in listaEmpresas)
            {
                listViewEmpresa.Items.Add(new ListViewItem(new String[]
                {
                    empresa.id.ToString(),                   
                    empresa.nomeFantasia,
                    empresa.CNPJ.ToString(),                   
                    empresa.telefone.ToString(),
                    empresa.email,

                }
                ));
            }
            con.Close();

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var itemSelecionado = Convert.ToInt32(listViewEmpresa.SelectedIndices[0]);
            var cnpj = Convert.ToDecimal(listViewEmpresa.Items[itemSelecionado].SubItems[0].Text);

            mtxtRazaoSocial.Text = String.Empty;
            mtxtNomeFantasia.Text = String.Empty;
            mtxtCnpj.Text = cnpj.ToString();
            mtxtTelefone.Text = String.Empty;
            mtxtEmail.Text = String.Empty;
            mtxtCidade.Text = String.Empty;
            mtxtBairro.Text = String.Empty;
            mtxtComplemento.Text = String.Empty;
            mtxtNumero.Text = String.Empty;
            mtxtRua.Text = String.Empty;


        }

        private void materialLabel11_Click(object sender, EventArgs e)
        {

        }

        class Empresa
        {
            public int id { get; set; }
            public string razaoSocial { get; set; }

            public string rua { get; set; }
            public string nomeFantasia { get; set; }
            public decimal CNPJ  { get; set; }
            public decimal telefone { get; set; }
            public string email { get; set; }
            public string cidade { get; set; }
            public string bairro { get; set; }
            public string complemento { get; set; }

            public int numeroResidencia { get; set; }

        }
    }
}
