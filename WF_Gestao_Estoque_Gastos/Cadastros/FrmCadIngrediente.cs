using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
            con = new MySqlConnection("Server=localhost;Database=gestao_estoque_gasto;Uid=root;Pwd=;SslMode=none");
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        private void btnLimpar_Click(object sender, System.EventArgs e)
        {
            txtIngrediente.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtPreco.Text = string.Empty;

            cbxUnidMedida.Items.Clear();

        }

        private bool ExcluirIngredientePorId(int id)
        {
            var excluiu = false;
            try
            {
                con.Open();

                cmd.CommandText = $"delete from tblingrediente where id = {id}";

                var numLinhasAfetadas = cmd.ExecuteNonQuery();

                if (numLinhasAfetadas > 0)
                    excluiu = true;
            }
            catch (Exception)
            {
                excluiu = false;
            }
            finally
            {
                con.Close();
            }

            return excluiu;
        }

        private void btnCadastrar_Click(object sender, System.EventArgs e)
        {
            var ingrediente = txtIngrediente.Text;
            var quantidade = txtQuantidade.Text;
            var preco = Convert.ToDecimal(txtPreco.Text);
            var unidadeMedida = cbxUnidMedida.SelectedIndex;
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
            else if (preco < 0)
            {
                MessageBox.Show("Digite o preço");
                txtPreco.Focus();
                return;
            }
            else if(unidadeMedida <= 0)
            {
                MessageBox.Show("Selecione a unidade de medida");
                cbxUnidMedida.Focus();
                return;
            }

            try
            {
                con.Open();

                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO tblingrediente (nomeingrediente, precoingrediente, unidademedidaid, quantidadeunidade, receitaid, pedidoid, empresaid) " +
                    "VALUES (@nomeingrediente, @precoingrediente, @unidademedidaid, @quantidadeunidade, @receitaid, @pedidoid, @empresaid)";

                cmd.Parameters.AddWithValue("nomeingrediente", ingrediente);
                cmd.Parameters.AddWithValue("quantidadeunidade", quantidade);
                cmd.Parameters.AddWithValue("precoingrediente", preco);
                cmd.Parameters.AddWithValue("unidademedidaid", unidadeMedida);
                cmd.Parameters.AddWithValue("receitaid", 2);
                cmd.Parameters.AddWithValue("pedidoid", 2);
                cmd.Parameters.AddWithValue("empresaid", 2);

                var retornoInsert = cmd.ExecuteNonQuery();

                if (retornoInsert > 0)
                {
                    MessageBox.Show("Ingrediente cadastrado com sucesso");
                }

                con.Close();
                PreencherListViewIngredientes();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema // " + ex.Message);
            }
        }

        private void FrmCadIngrediente_Load(object sender, EventArgs e)
        {

            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
            PreencherListViewIngredientes();
            PreencherComboUnidadeMedida();
        }

        private void PreencherComboUnidadeMedida()
        {
            try
            {
                cbxUnidMedida.Items.Clear();
                cbxUnidMedida.Items.Insert(0, "");

                List<UnidadeMedida> unidMedida = new List<UnidadeMedida>();

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT * FROM tblunidademedida";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var unidadeMedida = new UnidadeMedida()
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Descricao = reader["descricao"].ToString(),
                        Sigla = reader["sigla"].ToString(),
                    };

                    unidMedida.Add(unidadeMedida);
                }

                foreach (var unMedida in unidMedida)
                {
                    cbxUnidMedida.Items.Insert((int)unMedida.Id, unMedida.Descricao);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema");
            }
        }

        private void PreencherListViewIngredientes()
        {
            try
            {
                lsvIngredientes.Items.Clear();

                List<Ingredientes> ingrediente = new List<Ingredientes>();

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT i.id, i.NomeIngrediente, i.PrecoIngrediente, u.Descricao, i.QuantidadeUnidade, i.ReceitaId, i.PedidoId, i.EmpresaId FROM tblingrediente i, tblunidademedida u WHERE i.UnidadeMedidaId = u.Id";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var ingredientes = new Ingredientes()
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        NomeIngrediente = reader["nomeingrediente"].ToString(),
                        PrecoIngrediente = Convert.ToDecimal(reader["precoingrediente"].ToString()),
                        Descricao = reader["descricao"].ToString(),
                        QuantidadeUnidade = Convert.ToInt32(reader["quantidadeunidade"].ToString()),
                        ReceitaId = Convert.ToInt32(reader["receitaid"].ToString()),
                        PedidoId = Convert.ToInt32(reader["pedidoid"].ToString()),
                        EmpresaId = Convert.ToInt32(reader["empresaid"].ToString()),
                    };

                    ingrediente.Add(ingredientes);
                }

                foreach (var ingr in ingrediente)
                {
                    lsvIngredientes.Items.Add(new ListViewItem(new string[]
                    {
                         ingr.NomeIngrediente,
                         ingr.PrecoIngrediente.ToString(),
                         ingr.Descricao.ToString(),
                         ingr.QuantidadeUnidade.ToString(),
                         ingr.Id.ToString(),
                    }));
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema");
            }
        }

        private void lsvIngredientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var indice = Convert.ToInt32(lsvIngredientes.FocusedItem.Index);
                if (indice != -1)
                {
                    btnExcluir.Enabled = true;
                }
                else
                {
                    btnExcluir.Enabled = false;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var itemId = Convert.ToInt32(lsvIngredientes.Items[lsvIngredientes.FocusedItem.Index].SubItems[4].Text);
            ExcluirIngredientePorId(itemId);
            PreencherListViewIngredientes();

            btnExcluir.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    class Ingredientes
    {
        public int Id { get; set; }
        public string NomeIngrediente { get; set; }
        public decimal PrecoIngrediente { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeUnidade { get; set; }
        public int ReceitaId { get; set; }
        public int PedidoId { get; set; }
        public int EmpresaId { get; set; }
    }

}
