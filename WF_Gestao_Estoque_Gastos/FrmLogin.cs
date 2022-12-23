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
            con = new MySqlConnection("server=localhost;database=gestao_estoque_gastos;uid=root;pwd=;");
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
                MensagemErroConexao();
            }
            finally
            {
                con.Close();
                if (usuarioLogou)
                    this.Close();
                else
                    //string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon
                    MessageBox.Show("Usuário e/ou senha incorretos.","Erro",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MensagemErroConexao();
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
        private bool PreencheUsuarioManterLogin()
        {
            var id = 0;
            var sucesso = false;
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

                    sucesso = true;
                }

            }
            catch (Exception)
            {
                MensagemErroConexao();
            }
            finally
            {
                con.Close();
                if(reader != null)
                    reader.Close();
                if (id != 0)
                    PreencheEmpresaDoUsuarioManterLogin(id);
            }

            return sucesso;
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var sucesso = PreencheComboEmpresa();
            if (sucesso == false)
                Application.Exit();

            sucesso = PreencheUsuarioManterLogin();

            if (sucesso == false)
                Application.Exit();
        }
        private bool PreencheComboEmpresa()
        {
            var sucesso = false;
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
                    sucesso = true;
                }

            }
            catch (Exception)
            {
                MensagemErroConexao();
            }
            finally
            {
                con.Close();
            }
            return sucesso;
        }
        private void chxManterLogin_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void MensagemErroConexao()
        {
            MessageBox.Show("Falha na conexão.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
