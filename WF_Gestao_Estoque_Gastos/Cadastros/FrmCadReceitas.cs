using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public partial class FrmCadReceitas : MaterialForm
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;database=dbLogin;uid=root;pwd=;sslmode=none");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader rd;

        public FrmCadReceitas()
        {
            InitializeComponent();
        }

        private void FrmCadReceitas_Load(object sender, EventArgs e)
        {
            BuscarUltimoIdReceita();
            BuscarListaIngredientes();
            Console.ReadLine();
        }

        private void btnNovaReceita_Click(object sender, EventArgs e)
        {
            LimparCamposReceita();
        }

        private void LimparCamposReceita()
        {
            txtNome.Text = String.Empty;
            txtCusto.Text = String.Empty;
            txtPreco.Text = String.Empty;
        }

        private void CadastrarReceita()
        {
            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"INSERT INTO 
                                      gestao_estoque_gastos.tblreceita (nomeReceita, idEmpresa) 
                                      VALUES ('{txtNome.Text}', 1)");
                int retorno = cmd.ExecuteNonQuery();

                if (retorno < 1)
                {
                    MessageBox.Show("Não foi possível cadastrar receita!");
                }
                else
                {
                    MessageBox.Show("Usuário inserido com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro interno!");
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                //LimparCampos();
                con.Close();
            }

            //if (!checkBox.Checked)
            //{
            //    MessageBox.Show("Não é possível cadastrar usuário inativo!");
            //}
            //else

            //    this.BuscarDadosUsuario();
        }

        public string BuscarUltimoIdReceita()
        {
            var id = "";
            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"select id from gestao_estoque_gastos.tblReceita ORDER by id DESC;");
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    id = reader["id"].ToString();
                }

                return id;
            }
            catch (Exception)
            {
                return "";
            } finally
            {
                con.Close();
            }
        }

        public void PreencherListaIngredientes()
        {
            var id = "";
            try
            {
                var list = new List<Ingrediente>();
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"select * from gestao_estoque_gastos.tblReceitaIngrediente ORDER by id DESC;");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //listViewItensReceita
                }
                PreencheComboIngredientes(list);
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
        }

        private void BuscarListaIngredientes()
        {
            // continuar aqui, tem q preencher o list com os ingredientes
            var id = "";
            try
            {
                var list = new List<Ingrediente>();
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"select * from gestao_estoque_gastos.tblIngrediente ORDER by id DESC;");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var ingrediente = new Ingrediente()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        NomeIngrediente = reader["NomeIngrediente"].ToString(),
                        UnidadeMedidaId = int.Parse(reader["UnidadeMedidaId"].ToString()),
                        QuantidadeUnidade = decimal.Parse(reader["QuantidadeUnidade"].ToString()),
                        EmpresaId = int.Parse(reader["EmpresaId"].ToString()),
                    };
                    list.Add(ingrediente);
                }
                PreencheComboIngredientes(list);
            }
            catch (Exception)
            {

            } finally
            {
                con.Close();
            }
        }

        private void PreencheComboIngredientes(List<Ingrediente> lista)
        {
            cbbIngrediente.DataSource = lista;
            cbbIngrediente.DisplayMember = "nomeIngrediente";
            cbbIngrediente.ValueMember = "Id";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CadastrarReceita();
            CadastrarIngredientesReceita();
        }

        private void CadastrarIngredientesReceita()
        {
            try
            {
                var IdDaReceita = BuscarUltimoIdReceita();

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = ($@"INSERT INTO 
                                      gestao_estoque_gastos.tblReceitaIngrediente 
                                      (idIngrediente, idReceita, quantidadeIngrediente, idGastoVariado, qntGastoVariado) 
                                      VALUES ({cbbIngrediente.SelectedIndex + 1}, {IdDaReceita}, {txtQuantidade.Text}, '1', {txtCusto.Text.ToString()})");
                int retorno = cmd.ExecuteNonQuery();


                if (retorno < 1)
                {
                    MessageBox.Show("Não foi possível cadastrar receita!");
                }
                else
                {
                    MessageBox.Show("Usuário inserido com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro interno!");
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                //LimparCampos();
                con.Close();
            }
        }

        private void cbbIngrediente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            CadastrarReceita();
            CadastrarIngredientesReceita();
            BuscarListaIngredientes();
        }
    }

}
