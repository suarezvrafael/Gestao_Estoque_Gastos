using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
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
            con = new MySqlConnection("server=localhost;database=gastronomia;uid=root;pwd=;");
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

                cmd.CommandText = "select * from tblUsuario;";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var rdrUsuario = reader["username"].ToString();
                    var rdrSenha = reader["senha"].ToString();

                    if (rdrUsuario == usuario && rdrSenha == senha)
                    {
                        //usuario válido
                        usuarioLogou = true;
                    }
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Falha na conexão.");
            }
            finally
            {
                con.Close();
                if (usuarioLogou)
                    this.Close();
                else
                    MessageBox.Show("Usuário e/ou senha incorretos.");
            }

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var usuarioDoBanco = new Usuario()
            {
                Username = "empresa@gmail.com",
                ManterLogado = true,
                Senha = "123"
            };
            cbxEmpresa.DataSource = new List<string>()
            {
                "COMPUMAX",
                "IDEAL",
                "AFUBRA"
            };
            cbxEmpresa.SelectedIndex = -1;

            if (usuarioDoBanco.ManterLogado)
            {
                chxManterLogin.Checked = usuarioDoBanco.ManterLogado;
                txtUsuario.Text = usuarioDoBanco.Username;
                txtSenha.Text = usuarioDoBanco.Senha;

                Empresa empresa = RetornaEmpresaById(usuarioDoBanco.EmpresaId);

                cbxEmpresa.SelectedIndex =  cbxEmpresa.FindStringExact(empresa.NomeFantasia);
            }
        }

        private Empresa RetornaEmpresaById(int empresaId)
        {
            return new Empresa()
            {
                NomeFantasia = "COMPUMAX"
            };
        }

        private void chxManterLogin_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
