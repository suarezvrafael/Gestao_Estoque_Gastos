using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos
{
    public partial class FrmLogin : MaterialForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public FrmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
            con = new MySqlConnection("server=localhost;database=gestaogastronomiaturma;uid=root;pwd=;");
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var usuarioLogou = false;
            try
            {
                var usuario = txtUsuario.Text;
                var senha = txtSenha.Text;

                con.Open();
                var id = 0;
                cmd.CommandText = "select * from tblUsuario;";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var rdrUsuario = reader["username"].ToString();
                    var rdrSenha = reader["senha"].ToString();

                    if (rdrUsuario == usuario && rdrSenha == senha)
                    {
                        id = int.Parse(reader["id"].ToString());
                        usuarioLogou = true;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Falha na conexão.");
            }
            finally
            {
                con.Close();
                if (usuarioLogou)
                    this.Close();
                else
                    MessageBox.Show("m e/ou senha incorretos.");
            }

        }

        private Empresa BuscaEmpresaPorId(int id) 
        {
            try
            {
                con.Open();
                cmd.CommandText = $"select * from tblempresa where id = {id}";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var empresa = new Empresa()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Bairro = reader["bairro"].ToString(),
                        Cidade = reader["cidade"].ToString(),
                        Complemento = reader["Complemento"].ToString(),
                        CNPJ = reader["CNPJ"].ToString(),
                        Email = reader["Email"].ToString(),
                        NomeFantasia = reader["NomeFantasia"].ToString(),
                        NumeroEndereco = int.Parse(reader["NumeroEndereco"].ToString()),
                        RazaoSocial = reader["RazaoSocial"].ToString(),
                        Rua = reader["Rua"].ToString(),
                        Telefone = reader["Telefone"].ToString()
                    };

                    return empresa;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Falha na conexão.");
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        private void PreencheEmpresaDoUsuarioManterLogin(int id)
        {
            var empresa = BuscaEmpresaPorId(id);
            cbxEmpresa.SelectedIndex = cbxEmpresa.FindStringExact(empresa.NomeFantasia);
        }
        private void PreencheUsuarioManterLogin()
        {
            var id = 0;
            try
            {
                con.Open();
                cmd.CommandText = $"select * from tblUsuario where manterlogado = 1";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtUsuario.Text = reader["username"].ToString();
                    txtSenha.Text = reader["senha"].ToString();
                    //cbxEmpresa.SelectedValue = reader["nomeFantasia"].ToString();
                    chxManterLogin.Checked = int.Parse(reader["manterlogado"].ToString()) == 1;
                    id = int.Parse(reader["empresaId"].ToString());
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Falha na conexão.");
            }
            finally
            {
                con.Close();
                reader.Close();
                if (id != 0)
                    PreencheEmpresaDoUsuarioManterLogin(id);
            }
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            PreencheComboEmpresa();
            PreencheUsuarioManterLogin();
        }
        private void PreencheComboEmpresa()
        {
            try
            {
                con.Open();
                cmd.CommandText = $"select * from tblempresa";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbxEmpresa.Items.Add(
                        reader["nomeFantasia"].ToString()
                    );
                    
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Falha na conexão.");
            }
            finally
            {
                con.Close();
            }
            
        }
        private void chxManterLogin_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
