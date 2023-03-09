using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static MaterialSkin.Controls.MaterialForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;uid=root;pwd=;sslmode=none");
            cmd = new MySqlCommand();
            cmd.Connection = con;

            AlterarNomeForm(true);
        }

        private void FrmCadIngrediente_Load(object sender, EventArgs e)
        {

            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            PreencherListViewIngredientes();
            PreencherComboUnidadeMedida();
        }
        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            var ingrediente = txtIngrediente.Text.Trim();
            var quantidade = txtQuantidade.Text;
            var preco = txtPreco.Text;
            var unidadeMedida = cbxUnidMedida.SelectedIndex;

            var count = 0;

            for (int i = 0; i < ingrediente.Length; i++)
            {
                if (ingrediente[i] == '-')
                    count += 1;

                if (count > 2)
                {
                    MessageBox.Show("Digite um ingrediente válido.");
                    return;
                }
            }

            var retornoValidacao = ValidarCampos(ingrediente, quantidade, preco, unidadeMedida);

            preco = preco.Replace(".", "");
            preco = preco.Replace(",", ".");

            if (retornoValidacao == false)
                return;

            try
            {
                con.Open();

                cmd = con.CreateCommand();

                cmd.CommandText = $"SELECT nomeingrediente FROM tblingrediente WHERE nomeingrediente = '{ingrediente}'";

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Remove os acento e o ç das strings
                    var ingredienteBd = reader["nomeingrediente"].ToString();

                    string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
                    string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

                    for (int i = 0; i < comAcentos.Length; i++)
                    {
                        ingrediente = ingrediente.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
                        ingredienteBd = ingredienteBd.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
                    }

                    if (ingredienteBd.ToLower() == ingrediente.ToLower())
                    {
                        MessageBox.Show("O ingrediente já existe");
                        con.Close();
                        return;
                    }
                }

                con.Close();

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
                    btnLimpar_Click(sender, e);
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
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                var id = lblid.Text;
                var ingrediente = txtIngrediente.Text.Trim();
                var preco = txtPreco.Text;
                var uniMedida = cbxUnidMedida.SelectedIndex;
                var quantidade = txtQuantidade.Text;

                var retornoValidacao = ValidarCampos(ingrediente, quantidade, preco, uniMedida);

                preco = preco.Replace(".", "");
                preco = preco.Replace(",", ".");

                if (retornoValidacao == false)
                    return;

                con.Open();

                cmd = con.CreateCommand();

                var a = cmd.CommandText = $"UPDATE tblingrediente SET nomeIngrediente = '{ingrediente}', precoingrediente = {preco}, " +
                    $"unidademedidaid = {uniMedida}, quantidadeunidade = {quantidade} WHERE id = {id}";

                cmd.Parameters.AddWithValue("nomeIngrediente", ingrediente);
                cmd.Parameters.AddWithValue("precoingrediente", preco);
                cmd.Parameters.AddWithValue("unidademedidaid", uniMedida);
                cmd.Parameters.AddWithValue("quantidadeunidade", quantidade);

                var retorno = cmd.ExecuteNonQuery();

                if (retorno > 0)
                    MessageBox.Show("Ingrediente alterado com sucesso.");

                con.Close();
                PreencherListViewIngredientes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema");
            }
        }
        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            var itemId = Convert.ToInt32(lsvIngredientes.Items[lsvIngredientes.FocusedItem.Index].SubItems[4].Text);
            ExcluirIngredientePorId(itemId);
            PreencherListViewIngredientes();

            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
        }
        private void ExcluirIngredientePorId(int id)
        {
            var message = MessageBox.Show("Deseja excluir o ingrediente?", "", MessageBoxButtons.YesNo);

            if (message != DialogResult.Yes)
            {
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = true;
                return;
            }

            this.ResetText();
            this.Text = "Cadastro de Ingrediente";

            try
            {
                con.Open();

                cmd.CommandText = $"delete from tblingrediente where id = {id}";

                var numLinhasAfetadas = cmd.ExecuteNonQuery();

                if (numLinhasAfetadas > 0)
                    MessageBox.Show("Ingrediente excluído com sucesso.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                MessageBox.Show("Ocorreu um erro no sistema");
            }
            finally
            {
                con.Close();
            }

            txtIngrediente.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtPreco.Text = string.Empty;

            cbxUnidMedida.SelectedIndex = 0;

            btnCadastrar.Enabled = true;

            return;
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            AlterarNomeForm(true);

            txtIngrediente.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            txtPreco.Text = string.Empty;

            cbxUnidMedida.SelectedIndex = 0;

            btnCadastrar.Enabled = true;
            btnSalvar.Enabled = false;
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void lsvIngredientes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            AlterarNomeForm(false);

            try
            {
                if (lsvIngredientes.SelectedIndices.Count <= 0)
                {
                    return;
                }
                var indiceItemSelecionado = Convert.ToInt32(lsvIngredientes.SelectedIndices[0]);
                if (indiceItemSelecionado >= 0)
                {
                    var ingrediente = lsvIngredientes.Items[indiceItemSelecionado].Text;
                    var quantUnidade = lsvIngredientes.Items[indiceItemSelecionado].SubItems[1].Text;
                    var uniMedida = lsvIngredientes.Items[indiceItemSelecionado].SubItems[2].Text;
                    var preco = lsvIngredientes.Items[indiceItemSelecionado].SubItems[3].Text;
                    var id = Convert.ToInt32(lsvIngredientes.Items[indiceItemSelecionado].SubItems[4].Text);

                    txtIngrediente.Text = ingrediente;
                    txtQuantidade.Text = quantUnidade;
                    cbxUnidMedida.Text = uniMedida;
                    txtPreco.Text = preco;
                    lblid.Text = id.ToString();

                    btnSalvar.Enabled = true;
                    btnCadastrar.Enabled = false;
                }


                var indice = Convert.ToInt32(lsvIngredientes.FocusedItem.Index);
                if (indice != -1)
                {
                    btnExcluir.Enabled = true;
                }
                else
                {
                    btnExcluir.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtBuscaIngrediente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var nomeIngrediente = txtBuscaIngrediente.Text;
                lsvIngredientes.Items.Clear();


                List<Ingredientes> ingrediente = new List<Ingredientes>();

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = $@"SELECT i.id, i.NomeIngrediente, i.PrecoIngrediente, u.Descricao, i.QuantidadeUnidade, i.ReceitaId, i.PedidoId, i.EmpresaId FROM tblingrediente i, tblunidademedidaingrediente u WHERE i.UnidadeMedidaId = u.Id AND i.NomeIngrediente LIKE '%{nomeIngrediente}%' ORDER BY i.NomeIngrediente ASC";
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
                            ingr.PrecoIngrediente.ToString().Length >= 7 ? ingr.PrecoIngrediente.ToString().Insert(1, ".") : ingr.PrecoIngrediente.ToString(),
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

        private void PreencherComboUnidadeMedida()
        {
            try
            {
                cbxUnidMedida.Items.Clear();
                cbxUnidMedida.Items.Insert(0, "");

                List<UnidadeMedida> unidMedida = new List<UnidadeMedida>();

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT * FROM tblunidademedidaingrediente";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var unidadeMedida = new UnidadeMedida()
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Descricao = reader["descUnidMedIngrediente"].ToString(),
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
                cmd.CommandText = @"SELECT i.id, i.NomeIngrediente, i.PrecoIngrediente, u.Descricao, i.QuantidadeUnidade, i.ReceitaId, i.PedidoId, 
                                    i.EmpresaId FROM tblingrediente i, tblunidademedidaingrediente u WHERE i.UnidadeMedidaId = u.Id ORDER BY i.NomeIngrediente ASC";
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
                        ingr.QuantidadeUnidade.ToString(),
                        ingr.Descricao.ToString(),
                        ingr.PrecoIngrediente.ToString().Length >= 7 ? ingr.PrecoIngrediente.ToString().Insert(1, ".") : ingr.PrecoIngrediente.ToString(),
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
        private bool ValidarCampos(string ingrediente, string quantidade, string preco, int unidadeMedida)
        {
            var isOk = true;

            if (ingrediente.Equals(string.Empty) || !Regex.IsMatch(ingrediente, @"^[a-zA-Z\s(ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç\-)]+$"))
            {
                MessageBox.Show("Digite um ingrediente válido.");
                this.ActiveControl = txtIngrediente;
                isOk = false;
            }
            else if (!Regex.IsMatch(quantidade, "^[0-9]+$") || quantidade.Length > 10)
            {
                MessageBox.Show("Digite uma quantidade válida com até 10 dígitos.");
                txtQuantidade.Focus();
                isOk = false;
            }
            else if (!Regex.IsMatch(preco, "^(\\d{1,3}(\\.\\d{3})*|\\d+)(\\,\\d{1,2})?$"))
            {
                MessageBox.Show("Digite um preço válido.");
                txtPreco.Focus();
                isOk = false;
            }
            else if (unidadeMedida <= 0)
            {
                MessageBox.Show("Selecione uma unidade de medida.");
                cbxUnidMedida.Focus();
                isOk = false;
            }

            return isOk;
        }
        private void AlterarNomeForm(bool edit)
        {
            // Altera o nome text do form
            this.ResetText();
            this.Text = edit ? "Cadastro de Ingrediente" : "Editar Ingrediente";
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
