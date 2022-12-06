using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            cbxEmpresa.DataSource = new List<string>()
            {
                "COMPUMAX",
                "IDEAL",
                "AFUBRA"
            };
            cbxEmpresa.SelectedIndex = -1;
        }
    }
}
