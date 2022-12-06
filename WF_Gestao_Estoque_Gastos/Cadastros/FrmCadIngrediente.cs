using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public partial class FrmCadIngrediente : MaterialForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;

        public FrmCadIngrediente()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=gestao_de_estoque;Uid=root;Pwd=;SslMode=none");
        }

        private void btnLimpar_Click(object sender, System.EventArgs e)
        {
            txtIngrediente.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtPreco.Text = string.Empty;

            txtIngrediente.Focus();

            cbxUnidMedida.Items.Clear();
        }

        private void btnCadastrar_Click(object sender, System.EventArgs e)
        {
            var ingrediente = txtIngrediente.Text;
            var quantidade = txtQuantidade.Text;
            var preco = txtPreco.Text;
            var unidade = cbxUnidMedida.Items;

            if (ingrediente.Equals(string.Empty))
            {
                MessageBox.Show("Digite um ingrediente");
                this.ActiveControl = txtIngrediente;
                return;
            }
            else if (quantidade.Equals(string.Empty))
            {
                MessageBox.Show("Digite a quantidade");
                txtQuantidade.Focus();
                return;
            }
            else if (preco.Equals(string.Empty))
            {
                MessageBox.Show("Digite o preço");
                txtPreco.Focus();
                return;
            }
            else
            {
                MessageBox.Show("Selecione a unidade de medida");
                cbxUnidMedida.Focus();
                return;
            }

            try
            {
                con.Open();

                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO gestao_de_estoque (nomeingrediente, precoingrediente, unidademedidaid, quantidadeunidade, receitaid, pedidoid, empresaid) " +
                    "VALUES (@nomeingrediente, @precoingrediente, @unidademedidaid, @quantidadeunidade, @receitaid, @pedidoid, @empresaid)";

                cmd.Parameters.AddWithValue("nomeingrediente", ingrediente);
                cmd.Parameters.AddWithValue("quantidadeunidade", quantidade);
                cmd.Parameters.AddWithValue("precoingrediente", preco);
                cmd.Parameters.AddWithValue("unidademedidaid", unidade);

                var retornoInsert = cmd.ExecuteNonQuery();

                if (retornoInsert > 0)
                {
                    MessageBox.Show("Ingrediente cadastrado com sucesso");
                }

                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema");
            }
        }
    }
}
