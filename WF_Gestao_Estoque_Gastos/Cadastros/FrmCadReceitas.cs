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

        public MySqlConnection con = new MySqlConnection("server=localhost;database=gestao_estoque_gastos;uid=root;pwd=;sslmode=none");
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
            txtCusto.Enabled = true;
            LimparCamposReceita();
        }

        private void LimparCamposReceita()
        {
            lblReceita.Text = String.Empty;
            lblIngrediente.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtCusto.Text = String.Empty;
            listViewIngredientes.Items.Clear();
        }

        public void PreencheListaReceitas()
        {
            var list = new List<ListaDeReceitas>();

            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"SELECT * FROM gestao_estoque_gastos.tblReceita");
                var reader = cmd.ExecuteReader();

                listViewReceitas.Items.Clear();

                while (reader.Read())
                {
                    var listaDeReceitas = new ListaDeReceitas()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Receita = reader["NomeReceita"].ToString(),
                        TotalReceita = decimal.Parse(reader["ValorTotalReceita"].ToString())
                    };
                    list.Add(listaDeReceitas);

                    var item = new string[] {
                        reader["id"].ToString(),
                        reader["NomeReceita"].ToString(),
                        reader["ValorTotalReceita"].ToString()

                    };

                    var itemListView = new ListViewItem(item);

                    listViewReceitas.Items.Add(itemListView);
                }
            }
            catch (Exception)
            {


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

                cmd.CommandText = ($@"SELECT ri.Id as Id, i.NomeIngrediente as Nome, ri.QuantidadeIngrediente as Quantidade, r.valorTotalReceita as Custo, ri.IdIngrediente  FROM gestao_estoque_gastos.tblReceitaIngrediente AS ri, gestao_estoque_gastos.tblIngrediente AS i, gestao_estoque_gastos.tblReceita as r WHERE ri.idIngrediente = i.Id and ri.idReceita = r.Id and r.Id = {id};");
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
                cmd.CommandText = ($@"select * from gestao_estoque_gastos.tblIngrediente");
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

        private void CadastrarIngredientesReceita(int id)
        {
            try
            {

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"INSERT INTO 
                                      gestao_estoque_gastos.tblReceitaIngrediente 
                                      (idIngrediente, idReceita, quantidadeIngrediente, idGastoVariado, qntGastoVariado) 
                                      VALUES ({cbbIngrediente.SelectedIndex + 1}, {id}, {txtQuantidade.Text}, '1', {txtCusto.Text.ToString()})");
                int retorno = cmd.ExecuteNonQuery();


                if (retorno < 1)
                {
                    MessageBox.Show("Não foi possível cadastrar os ingredientes da receita!");
                }
                else
                {
                    MessageBox.Show("Usuário inserido com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar ingrediente!");
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                con.Close();
            }
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            if (novaReceita)
            {
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

            txtCusto.Enabled = false;
            btnAdicionarReceita.Enabled = false;
        }

        public void DesabilitarCamposIngrediente()
        {
            cbbIngrediente.SelectedIndex = -1;
            txtQuantidade.Text = String.Empty;
            cbbIngrediente.Enabled = false;
        }

        public void HabilitarCamposIngrediente()
        {
            cbbIngrediente.Enabled = true;
            txtQuantidade.Text = String.Empty;
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
            string quantidadeReceita = listViewReceitas.Items[indiceItemSelecionado].SubItems[2].Text;

            txtNome.Text = nomeReceita;
            txtCusto.Text = quantidadeReceita;

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
                cmd.CommandText = "SELECT AUTO_INCREMENT FROM information_schema.tables WHERE table_name = 'tblReceita' AND table_schema = 'gestao_estoque_gastos';";


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
                MessageBox.Show("Não foi possível obter id!");
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        private void BuscarListaDeIngredientesReceita(int id)
        {
            try
            {
                var list = new List<ListaDeIngredientes>();
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"select * from gestao_estoque_gastos.tblIngrediente WHERE id = {id};");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var listaDeIngredientes = new ListaDeIngredientes()
                    {

                    };
                    list.Add(listaDeIngredientes);
                }
                listViewIngredientes.Items.Clear();

                foreach (var ingrediente in list)
                {
                    listViewIngredientes.Items.Add(new ListViewItem(

                        new String[]
                        {

                            ingrediente.Id.ToString(),
                            ingrediente.IdIngrediente.ToString(),
                            ingrediente.IdReceita.ToString(),
                            ingrediente.QuantidadeIngrediente.ToString(),
                            ingrediente.IdGastoVariado.ToString(),
                            ingrediente.QuantidadeGastoVariado.ToString()
                        })
                     );
                }
                PreencheListaIngredientes(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível obter lista de ingredientes da receita!");
                Console.WriteLine(ex.Message);
                return;
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
                                        gestao_estoque_gastos.tblReceitaIngrediente AS a,
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
                Console.WriteLine(ex.Message);
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
                                      gestao_estoque_gastos.tblReceitaIngrediente 
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
                Console.WriteLine(ex.Message);
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
            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"INSERT INTO 
                                      gestao_estoque_gastos.tblReceita
                                      (nomeReceita, IdEmpresa, ValorTotalReceita)
                                      VALUES
                                      ('{txtNome.Text}', '1', {txtCusto.Text})");
                int retorno = cmd.ExecuteNonQuery();

                if (retorno < 1)
                {
                    inseriuReceita = false;
                    MessageBox.Show("Não foi possível cadastrar Receita(inserirReceita)!");
                }
                else
                {
                    MessageBox.Show("Receita cadastrada!");
                }
            }
            catch (Exception ex)
            {
                inseriuReceita = false;
                MessageBox.Show("Não foi possível Inserir receita (INSERIRRECEITA)!");
                Console.WriteLine(ex.Message);
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

        private void btnAdicionarIngrediente_Click(object sender, EventArgs e)
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
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Não foi possível cadastrar ingrediente!");
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                con.Close();
            }
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
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Erro ao deletar receita!");
                Console.WriteLine(ex.Message);
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
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Não foi possível cadastrar ingrediente!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnExcluirIngrediente_Click(object sender, EventArgs e)
        {
            const string message = "Realmente deseja excluir a receita?";
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
                }

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Não foi possível deletar ingrediente!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
