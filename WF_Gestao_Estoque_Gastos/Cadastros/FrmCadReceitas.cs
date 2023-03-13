using Google.Protobuf.WellKnownTypes;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public partial class FrmCadReceitas : MaterialForm
    {
        bool novaReceita = false;
        public int idReceita;
        bool inseriuReceita = true;

        public MySqlConnection con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;uid=root;pwd=;sslmode=none");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader rd;

        public List<Ingrediente> listaDeIngredientes = new List<Ingrediente>();

        public List<Ingrediente> ingredientesCombo = new List<Ingrediente>();

        public FrmCadReceitas()
        {
            InitializeComponent();
        }

        private void FrmCadReceitas_Load(object sender, EventArgs e)
        {
            PreencheListaReceitas();
            DesabilitarCamposReceita();
            DesabilitarCamposIngrediente();
            PreencheComboIngredientes();
        }

        private void HabilitarCadastroDeReceita()
        {
            novaReceita = true;
            btnAdicionarReceita.Enabled = true;
            txtNome.Enabled = true;
            LimparCamposReceita();
        }

        private void LimparCamposReceita()
        {
            lblReceita.Text = String.Empty;
            lblIngrediente.Text = String.Empty;
            txtNome.Text = String.Empty;
            listViewIngredientes.Items.Clear();
        }

        public void PreencheListaReceitas()
        {
            var list = new List<ListaDeReceitas>();

            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"SELECT * FROM gestao_estoque_gasto.tblReceita");
                var reader = cmd.ExecuteReader();

                listViewReceitas.Items.Clear();

                while (reader.Read())
                {

                    var listaDeReceitas = new ListaDeReceitas();
                    listaDeReceitas.Id = int.Parse(reader["id"].ToString());
                    listaDeReceitas.Receita = reader["nomeReceita"].ToString();

                    var valor = string.IsNullOrEmpty(reader["valorTotalReceita"].ToString()) ? "0" : reader["valorTotalReceita"].ToString();

                    listaDeReceitas.TotalReceita = decimal.Parse(valor);

                    list.Add(listaDeReceitas);

                    var item = new string[] {
                        reader["id"].ToString(),
                        reader["nomeReceita"].ToString(),
                        reader["valorTotalReceita"].ToString()

                    };

                    var itemListView = new ListViewItem(item);

                    listViewReceitas.Items.Add(itemListView);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível buscar as receitas!");
                return;
            }
            finally
            {
                con.Close();
            }


        }

        public void PreencheListaIngredientes(int id)
        {
            try
            {
                var list = new List<ReceitaIngrediente>();
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = ($@"SELECT ri.Id as Id, i.NomeIngrediente as Nome, ri.QuantidadeIngrediente as Quantidade, (ri.QuantidadeIngrediente * i.precoIngrediente) as Custo, ri.IdIngrediente  FROM gestao_estoque_gasto.tblReceitaIngrediente AS ri, gestao_estoque_gasto.tblIngrediente AS i, gestao_estoque_gasto.tblReceita as r WHERE ri.idIngrediente = i.Id and ri.idReceita = r.Id and r.Id = {id};");
                var reader = cmd.ExecuteReader();

                listViewIngredientes.Items.Clear();

                while (reader.Read())
                {

                    var listaIngrediente = new ReceitaIngrediente()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        NomeIngrediente = reader["Nome"].ToString(),
                        QuantidadeIngrediente = decimal.Parse(reader["Quantidade"].ToString()),
                        PrecoIngrediente = decimal.Parse(reader["Custo"].ToString()),
                        IdIngrediente = int.Parse(reader["IdIngrediente"].ToString())
                    };
                    list.Add(listaIngrediente);

                    var item = new string[] {
                        reader["id"].ToString(),
                        reader["Nome"].ToString(),
                        reader["Quantidade"].ToString(),
                        reader["Custo"].ToString(),
                        reader["IdIngrediente"].ToString(),
                    };

                    var itemListView = new ListViewItem(item);

                    listViewIngredientes.Items.Add(itemListView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar ingrediente!");
                return;
            }
            finally
            {
                con.Close();
            }
        }


        public void PreencheComboIngredientes()
        {
            try
            {

                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"select * from gestao_estoque_gasto.tblIngrediente");
                var reader = cmd.ExecuteReader();

                cbbIngrediente.Items.Clear();

                while (reader.Read())
                {

                    var ingredientes = new Ingrediente()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        NomeIngrediente = reader["NomeIngrediente"].ToString(),
                        PrecoIngrediente = decimal.Parse(reader["PrecoIngrediente"].ToString()),
                        UnidadeMedidaId = int.Parse(reader["UnidadeMedidaId"].ToString()),
                        EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                    };
                    ingredientesCombo.Add(ingredientes);
                }
                cbbIngrediente.DataSource = ingredientesCombo;
                cbbIngrediente.DisplayMember = "NomeIngrediente";
                cbbIngrediente.ValueMember = "Id";
                cbbIngrediente.SelectedIndex = -1;
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
        }

        private void PreencheListaIngredientes(List<ListaDeIngredientes> lista)
        {

            cbbIngrediente.ValueMember = "Id";
            cbbIngrediente.DataSource = lista;
            cbbIngrediente.DisplayMember = "nomeIngrediente";
            cbbIngrediente.SelectedIndex = -1;

        }


        public bool ValidarCampos()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo Nome.");
                return false;
            }

            return true;
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            if (novaReceita)
            {
                if (!ValidarCampos())
                    return;

                idReceita = InserirReceita() - 1;
                cbbIngrediente.Enabled = true;
                txtQuantidade.Enabled = true;
                cbbIngrediente.Focus();
            }

            if (idReceita > 0)
            {
                LimparCamposReceita();
                PreencheListaReceitas();

                var quantidadeItens = listViewReceitas.Items.Count;

                for (int pos = 0; pos < quantidadeItens; pos++)
                {
                    if (listViewReceitas.Items[pos].Text == idReceita.ToString())
                    {
                        listViewReceitas.Items[pos].Selected = true;
                        break;
                    }
                }

                HabilitarCamposIngrediente();
            }
        }

        private bool ExisteItemNaLista(ListaDeIngredientes obj)
        {
            var retorno = listaDeIngredientes.Where(e => e.Id == obj.Id).Count();
            return retorno > 0;
        }

        private void DesabilitarCamposReceita()
        {
            txtNome.Enabled = false;

            btnAdicionarReceita.Enabled = false;
        }

        public void DesabilitarCamposIngrediente()
        {
            LimpaCamposIgrediente();
            cbbIngrediente.Enabled = false;
            txtQuantidade.Enabled = false;
        }

        private void LimpaCamposIgrediente()
        {
            cbbIngrediente.SelectedIndex = -1;
            txtQuantidade.Text = String.Empty;
        }

        public void HabilitarCamposIngrediente()
        {
            cbbIngrediente.Enabled = true;
            txtQuantidade.Text = String.Empty;
            txtQuantidade.Enabled = true;
            cbbIngrediente.SelectedIndex = -1;
        }
        private void listViewCadastroReceitas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;

            if (listViewReceitas.Items.Count > 0)
            {
                btnAdicionarReceita.Enabled = true;
            }
            if (listViewReceitas.SelectedIndices.Count == 0)
                return;

            var indiceItemSelecionado = Convert.ToInt32(listViewReceitas.SelectedIndices[0]);
            id = int.Parse(listViewReceitas.Items[indiceItemSelecionado].Text);
            string nomeReceita = listViewReceitas.Items[indiceItemSelecionado].SubItems[1].Text;

            txtNome.Text = nomeReceita;

            lblReceita.Text = id.ToString();

            BuscaIngredientesDaReceita(id);
            PreencheListaIngredientes(id);
            HabilitarCamposIngrediente();

        }

        private int BuscarIdDaReceita()
        {
            try
            {
                int idDaReceita = 0;

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT AUTO_INCREMENT FROM information_schema.tables WHERE table_name = 'tblReceita' AND table_schema = 'gestao_estoque_gasto';";


                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    idDaReceita = int.Parse(reader["AUTO_INCREMENT"].ToString());
                    return idDaReceita;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível obter id da receita!");
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        private void BuscaIngredientesDaReceita(int id)
        {
            try
            {
                List<ReceitaIngrediente> receitaIngredientes = new List<ReceitaIngrediente>();
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"SELECT
                                        idIngrediente,
                                        b.nomeIngrediente,
                                        a.quantidadeIngrediente,
                                        b.PrecoIngrediente
                                    FROM
                                        gestao_estoque_gasto.tblReceitaIngrediente AS a,
                                        tblingrediente AS b
                                    WHERE
                                        a.idIngrediente = b.id AND idReceita = {id}");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReceitaIngrediente ri = new ReceitaIngrediente();
                    ri.Id = Convert.ToInt32(reader["idIngrediente"].ToString());
                    ri.NomeIngrediente = reader["nomeIngrediente"].ToString();
                    ri.QuantidadeIngrediente = Convert.ToDecimal(reader["quantidadeIngrediente"].ToString());
                    ri.PrecoIngrediente = Convert.ToDecimal(reader["PrecoIngrediente"].ToString());

                    receitaIngredientes.Add(ri);
                }

                listViewIngredientes.Items.Clear();
                foreach (var ingredienteReceita in receitaIngredientes)
                {
                    listViewIngredientes.Items.Add(new ListViewItem(

                        new String[] {
                            ingredienteReceita.Id.ToString(),
                            ingredienteReceita.NomeIngrediente.ToString(),
                            ingredienteReceita.QuantidadeIngrediente.ToString(),
                            ingredienteReceita.PrecoIngrediente.ToString(),
                        })
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível buscar os ingredientes da receita!");
            }
            finally
            {
                con.Close();
            }

        }

        private void listViewItens_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;


            if (listViewIngredientes.Items.Count > 0)
            {
                btnAdicionarReceita.Enabled = true;
            }
            if (listViewIngredientes.SelectedIndices.Count == 0)
                return;

            var indiceItemSelecionado = Convert.ToInt32(listViewIngredientes.SelectedIndices[0]);
            id = int.Parse(listViewIngredientes.Items[indiceItemSelecionado].Text);
            var idReceitaIngrediente = listViewIngredientes.Items[indiceItemSelecionado].SubItems[0].Text;
            var nomeIngrediente = listViewIngredientes.Items[indiceItemSelecionado].SubItems[1].Text;
            var quantidadeIngrediente = listViewIngredientes.Items[indiceItemSelecionado].SubItems[2].Text;
            var idIngrediente = listViewIngredientes.Items[indiceItemSelecionado].SubItems[4].Text;

            lblIngrediente.Text = id.ToString();
            lblReceitaIngrediente.Text = idReceitaIngrediente;
            cbbIngrediente.SelectedValue = idIngrediente;
            cbbIngrediente.Text = nomeIngrediente;
            txtQuantidade.Text = quantidadeIngrediente;
        }

        public void InserirIngrediente(int idReceita)
        {
            try
            {
                con.Open();
                var idIngrediente = cbbIngrediente.SelectedValue;
                cmd.Connection = con;
                cmd.CommandText = ($@"INSERT INTO 
                                      gestao_estoque_gasto
                                        .tblReceitaIngrediente
                                      (idIngrediente, idReceita, quantidadeIngrediente, idGastoVariado, qntGastoVariado) 
                                      VALUES 
                                      ({idIngrediente}, '{idReceita}', '{txtQuantidade.Text}', '1', '1')");
                int retorno = cmd.ExecuteNonQuery();

                if (retorno < 1)
                {
                    MessageBox.Show("Não foi possível cadastrar ingrediente!");
                }
                else
                {
                    MessageBox.Show("Ingrediente cadastrado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar ingrediente!");
                return;
            }
            finally
            {
                con.Close();
            }

        }
        public int InserirReceita()
        {
            int idReceita = 0;
            var dadosUsuario = DadosUsuario.GetUsuario();
            var idEmpresa = dadosUsuario.EmpresaId;
            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"INSERT INTO 
                                      gestao_estoque_gasto.tblReceita
                                      (nomeReceita, IdEmpresa)
                                      VALUES
                                      ('{txtNome.Text}', {idEmpresa})");
                int retorno = cmd.ExecuteNonQuery();

                if (retorno < 1)
                {
                    inseriuReceita = false;
                    MessageBox.Show("Não foi possível inserir receita!");
                }
                else
                {
                    MessageBox.Show("Receita cadastrada!");
                }
            }
            catch (Exception)
            {
                inseriuReceita = false;
                MessageBox.Show("Não foi possível inserir receita!");
                return 0;
            }
            finally
            {
                con.Close();
            }

            if (inseriuReceita == true)
            {
                idReceita = BuscarIdDaReceita();
            }
            return idReceita;
        }

        private void cbbIngrediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            var objectWindowComboBox = sender as System.Windows.Forms.ComboBox;

            var igredienteSelecionado = objectWindowComboBox.SelectedItem as WF_Gestao_Estoque_Gastos.Cadastros.Ingrediente;

            lblIngrediente.Text = igredienteSelecionado != null && igredienteSelecionado.Id > 0 ? igredienteSelecionado.Id.ToString() : string.Empty;
        }

        private void btnNovaReceita_Click_1(object sender, EventArgs e)
        {
            HabilitarCadastroDeReceita();
            novaReceita = true;
        }

        public bool ValidarCamposIngrediente()
        {
            if (cbbIngrediente.Text == "")
            {
                MessageBox.Show("Selecione o Ingrediente.");
                return false;
            }
            else if (txtQuantidade.Text == "")
            {
                MessageBox.Show("Preencha o campo Quantidade.");
                return false;
            }

            return true;
        }



        private void btnAdicionarIngrediente_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposIngrediente())
                return;
            try
            {
                var idIngrediente = VerificaIngredienteCadastrado();

                if (idIngrediente <= 0)
                {
                    InserirIngredienteNaReceita();
                }
                else
                {
                    AtualizarIngredienteDaReceita();
                }

            }
            catch (Exception)
            {
                con.Close();
                MessageBox.Show("Não foi possível cadastrar ingrediente!");
                return;
            }
            finally
            {
                con.Close();
            }

            DesabilitarCamposIngrediente();
        }

        private void AtualizarIngredienteDaReceita()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"UPDATE tblreceitaingrediente
                                      SET quantidadeIngrediente = {Convert.ToInt32(txtQuantidade.Text)} WHERE
                                      idIngrediente = {lblIngrediente.Text} AND idReceita = {lblReceita.Text}");
                int retorno = cmd.ExecuteNonQuery();

                if (retorno < 1)
                {
                    MessageBox.Show("Não foi possível cadastrar os ingredientes da receita!");
                }
                else
                {
                    con.Close();
                    PreencheListaIngredientes(int.Parse(lblReceita.Text));
                    MessageBox.Show("Ingrediente atualizado!");

                    AtualizaCustoReceita(lblReceita.Text);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possível atualizar os ingredientes da receita!");
                return;
            }
            finally
            {
                con.Close();
            }
        }

        private void InserirIngredienteNaReceita()
        {

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"INSERT INTO tblreceitaingrediente
                                      (idIngrediente, idReceita, quantidadeIngrediente, idGastoVariado, qntGastoVariado) 
                                      VALUES ({lblIngrediente.Text},{lblReceita.Text},{Convert.ToInt32(txtQuantidade.Text)},1,1)");
                int retorno = cmd.ExecuteNonQuery();


                if (retorno < 1)
                {
                    MessageBox.Show("Não foi possível cadastrar os ingredientes da receita!");
                }
                else
                {
                    con.Close();
                    PreencheListaIngredientes(int.Parse(lblReceita.Text));
                    MessageBox.Show("Ingrediente inserido");

                    AtualizaCustoReceita(lblReceita.Text);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Não foi possível inserir ingrediente na receita!");
                return;
            }
            finally
            {
                con.Close();
            }
        }

        public int VerificaIngredienteCadastrado()
        {

            var idIngrediente = 0;
            
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"SELECT idIngrediente FROM tblReceitaIngrediente WHERE
                                      idIngrediente = {lblIngrediente.Text} AND idReceita = {lblReceita.Text}");

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idIngrediente = int.Parse(reader["idIngrediente"].ToString());
                }

                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Erro interno!");
                return 0;
            }
            finally
            {
                con.Close();
            }

            return idIngrediente;
        }

        private void AtualizaCustoReceita(string idReceita)
        {
            try
            {
                decimal totalCustoReceita = GetTotalCustoReceita(idReceita);

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"UPDATE tblReceita
                                      SET valorTotalReceita = {totalCustoReceita}
                                      WHERE id = {idReceita}");

                int retorno = cmd.ExecuteNonQuery();

                if (retorno < 1)
                {
                    MessageBox.Show("Erro ao atualizar custo!");
                }
                else
                {
                    con.Close();
                    PreencheListaReceitas();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível atualizar o custo da receita!");
                return;
            }
            finally
            {
                con.Close();
            }

        }

        private decimal GetTotalCustoReceita(string idReceita)
        {
            decimal totalCustoReceita = 0;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"SELECT Sum(b.PrecoIngrediente * a.quantidadeIngrediente) as valor FROM gestao_estoque_gasto.tblReceitaIngrediente AS a, tblingrediente AS b WHERE a.idIngrediente = b.id
                                      and a.idReceita = {idReceita};");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    totalCustoReceita = decimal.Parse(reader["valor"].ToString());
                }

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível pegar o custo total da receita!");
                return 0;
            }
            finally
            {
                con.Close();
            }

            return totalCustoReceita;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            const string message = "Realmente deseja excluir a receita?";
            const string caption = "Exclusão";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (lblReceita.Text != string.Empty)
                {
                    DeletarReceita();
                    PreencheListaReceitas();
                    PreencheListaIngredientes(Convert.ToInt32(lblReceita.Text));
                    LimparCamposReceita();
                }
            }
        }

        public void DeletarReceita()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"DELETE FROM tblReceita WHERE id = {lblReceita.Text}");
                int retorno = cmd.ExecuteNonQuery();


                if (retorno < 1)
                {
                    MessageBox.Show("Não foi possível deletar a receita!");
                }
                else
                {
                    MessageBox.Show("Receita excluída com sucesso!");
                    con.Close();
                    DeletarIngredientesDaReceita();
                }
            }
            catch (Exception)
            {
                con.Close();
                MessageBox.Show("Erro ao deletar receita!");
            }
            finally
            {
                con.Close();
            }
        }

        public void DeletarIngredientesDaReceita()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"DELETE FROM tblReceitaIngrediente WHERE idReceita = {lblReceita.Text}");
                int retorno = cmd.ExecuteNonQuery();


                if (retorno < 0)
                {
                    MessageBox.Show("Erro ao deletar ingredientes da receita!");
                }

            }
            catch (Exception)
            {
                con.Close();
                MessageBox.Show("Não foi possível deletar ingrediente da receita!");
            }
            finally
            {
                con.Close();
            }
        }

        private void btnExcluirIngrediente_Click(object sender, EventArgs e)
        {
            const string message = "Realmente deseja excluir o ingrediente da receita?";
            const string caption = "Exclusão";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (lblReceitaIngrediente.Text != string.Empty)
                {
                    DeletarIngrediente();
                    PreencheListaReceitas();
                    PreencheListaIngredientes(int.Parse(lblReceita.Text));
                    txtQuantidade.Text = string.Empty;
                    cbbIngrediente.SelectedIndex = -1;
                    lblIngrediente.Text = string.Empty;
                }
            }
        }

        public void DeletarIngrediente()
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"DELETE FROM tblReceitaIngrediente WHERE id = {lblReceitaIngrediente.Text}");
                int retorno = cmd.ExecuteNonQuery();


                if (retorno < 0)
                {
                    MessageBox.Show("Erro ao deletar ingrediente!");
                    return;
                } else
                {
                    MessageBox.Show("Ingrediente deletado com sucesso!");
                }

            }
            catch (Exception)
            {
                con.Close();
                MessageBox.Show("Não foi possível deletar ingrediente!");
            }
            finally
            {
                con.Close();
            }

        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = '\0';
            }
        }
    }
}
