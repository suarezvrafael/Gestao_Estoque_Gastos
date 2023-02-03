using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WF_Gestao_Estoque_Gastos.Cadastros;
using WF_Gestao_Estoque_Gastos.Servicos;
using WF_Gestao_Estoque_Gastos.Servicos.Excecoes;

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
            con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;uid=root;pwd=;");
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

            DesmarcarUsuariosManterLogin();
            var id = 0;
            try
            {
                var usuario = txtUsuario.Text;
                var senha = txtSenha.Text;

                con.Open();
                cmd.CommandText = "select * from tblUsuario;";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var rdrUsuario = reader["username"].ToString();
                    var rdrSenha   = reader["senha"].ToString();

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
                {
                    if(chxManterLogin.Checked)
                        LoginAutomatico(id);
                    this.Close();
                }
                else
                    MessageBox.Show("Usuário e/ou senha incorretos.","Erro",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoginAutomatico(int id = 0)
        {
            try
            {
                con.Open();
                if(id == 0)
                    cmd.CommandText = $"update tblusuario set manterlogado = 0";
                else
                    cmd.CommandText = $"update tblusuario set manterlogado = 1 where id = {id}";
                cmd.ExecuteNonQuery();
            }
            catch (Exception errou)
            {
                Debug.WriteLine(errou.Message);
            }
            finally
            {
                con.Close();
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
            if (empresa != null)
                cbxEmpresa.SelectedIndex = cbxEmpresa.FindStringExact(empresa.NomeFantasia);
        }

        private void DesmarcarUsuariosManterLogin()
        {
            try
            {
                con.Open();

                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE tblusuario SET manterlogado = 0";

                int retornoDoUpdate = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show("Ops. Erro: " + e.Message);
            }
            finally
            {
                con.Close();
            }
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
                if (id != 0)
                    PreencheEmpresaDoUsuarioManterLogin(id);
                else
                {
                    if (cbxEmpresa.Items.Count > 0)
                        cbxEmpresa.SelectedIndex = 0;
                }
            }

            return sucesso;
        }
        private void DesabilitarCampos()
        {
            cbxEmpresa.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled   = false;
            btnEntrar.Enabled  = false;  
            Mensagem.Informacao("Tenha certeza de ter empresa e usuário cadastrados");
        }
        private void HabilitarCampos()
        {
            cbxEmpresa.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled   = true;
            btnEntrar.Enabled  = true;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var sucesso = PreencheComboEmpresa();
            if (sucesso == false)
                DesabilitarCampos();
            else
                HabilitarCampos();

            PreencheUsuarioManterLogin();
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

        private void cadastrarUsuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GerenciarTela.AbrirTela(new FrmCadUsuario(), true);
        }

        private void cadastrarEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciarTela.AbrirTela(new FrmCadEmpresa(), true);
        }

        private void deslogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        public void Deslogar()
        {
            LoginAutomatico();
            Application.Exit();
        }

        private void deslogarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Deslogar();
        }
    }
}
