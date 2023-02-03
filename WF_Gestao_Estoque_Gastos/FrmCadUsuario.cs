using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_Gestao_Estoque_Gastos.Conexao;


namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public partial class FrmCadUsuario : MaterialForm
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;database=dbLogin;uid=root;pwd=;sslmode=none");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader rd;

        public FrmCadUsuario()
        {
            InitializeComponent();
            checkBox.Checked = true;
            checkBox.Text = "Ativo";
            BuscaDadosUsuario();
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (!VerificaInputs() || !ConfirmarSenha())
            {
                MessageBox.Show("Não foi possível cadastrar o usuário, por favor, verifique as informações!");
                return;
            }

            if (!VerificarNomeDeUsuario())
            {
                MessageBox.Show("Nome de usuário não pode conter espaços");
                return;
            }

            if (!SegurancaDaSenha())
            {
                MessageBox.Show("Senha deve conter ao menos 8 caracteres, um caracter especial, um número e uma letra maiúscula!");
            }

            if (listView.SelectedItems.Count > 0)
            {
                AtualizarUsuario();
            }
            else
            {
                if (checkBox.Checked == false)
                {
                    MessageBox.Show("Não é possível cadastrar usuário inativo!");
                }
                else
                {
                    CadastrarUsuario();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            checkBox.Checked = true;
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.BuscaDadosUsuario();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = "";
            var name = "";
            var username = "";
            var acesso = "";
            var ativo = "";

            if (listView.SelectedIndices.Count <= 0)
            {
                return;
            }

            var indiceItemSelecionado = Convert.ToInt32(listView.SelectedIndices[0]);
            if (indiceItemSelecionado >= 0)
            {

                id = listView.Items[indiceItemSelecionado].Text;
                name = listView.Items[indiceItemSelecionado].SubItems[1].Text;
                username = listView.Items[indiceItemSelecionado].SubItems[2].Text;
                acesso = listView.Items[indiceItemSelecionado].SubItems[3].Text;
                ativo = listView.Items[indiceItemSelecionado].SubItems[4].Text;

                txtNome.Text = name;
                txtUsuario.Text = username;
                lblid.Text = id;
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirUsuario();
        }

        private void CadastrarUsuario()
        {

            try
            {
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = ($@"INSERT INTO dbLogin.tblUsuario(
                    Nome, Username, Senha, Acesso, EmpresaId, ManterLogado, Ativo) VALUES
                    ('{txtNome.Text}','{txtUsuario.Text}', '{txtSenha.Text}','1', '1','0','S')");
                int retorno = cmd.ExecuteNonQuery();

                if (retorno < 1)
                {
                    MessageBox.Show("Não foi possível inserir o usuário!");
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
                LimparCampos();
                con.Close();
            }

            if (!checkBox.Checked)
            {
                MessageBox.Show("Não é possível cadastrar usuário inativo!");
            }
            else

                ///É aqui
                this.BuscaDadosUsuario();
        }

        private void ExcluirUsuario()
        {
            try
            {
                if (listView.SelectedIndices.Count > -1)
                {

                    cmd.CommandText = ($"UPDATE dbLogin.tblUsuario SET Ativo = 'N' WHERE id = {lblid.Text}");

                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário excluído com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro interno");
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                con.Close();
                BuscaDadosUsuario();
                con.Close();
            }
        }

        private void AtualizarUsuario()
        {
            var inserirStatus = "";

            try
            {
                if (listView.SelectedIndices.Count > -1)
                {
                    if (checkBox.Text == "Ativo")
                    {
                        inserirStatus = "S";
                    }
                    else
                    {
                        inserirStatus = "N";
                    }

                    cmd.CommandText = ($@"UPDATE tblUsuario SET Nome = '{txtNome.Text}',
                                       UserName = '{txtUsuario.Text}', 
                                       Senha = '{txtSenha.Text}', 
                                       Acesso = 1, 
                                       ManterLogado = 1, 
                                       EmpresaId = 1, 
                                       Ativo = '{inserirStatus}'    
                                       WHERE id = {lblid.Text}");

                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuário atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro interno");
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                con.Close();
                BuscaDadosUsuario();
                con.Close();
            }
        }

        private void BuscaDadosUsuario()
        {
            List<Usr> usuarios = new List<Usr>();
            cmd.CommandText = ("SELECT * FROM tblUsuario ORDER BY Nome");

            con.Open();
            cmd.Connection = con;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                var user = new Usr()
                {
                    Id = Convert.ToInt32(rd["id"].ToString()),
                    Name = rd["Nome"].ToString(),
                    Username = rd["Username"].ToString(),
                    Acesso = rd["Acesso"].ToString(),
                    Ativo = rd["Ativo"].ToString()

                };
                usuarios.Add(user);
            }
            listView.Items.Clear();

            foreach (Usr u in usuarios)
            {
                listView.Items.Add(new ListViewItem(

                    new String[]
                    {
                            u.Id.ToString(),
                            u.Name.ToString(),
                            u.Username.ToString(),
                            u.Acesso.ToString(),
                            u.Ativo.ToString()

                    })
                );
            }
            rd.Close();
            con.Close();
        }
        public void LimparCampos()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
            txtNome.Text = "";
            lblid.Text = "";
            checkBox.Checked = true;
            listView.SelectedItems.Clear();
        }

        public bool VerificaInputs()
        {
            bool verifica = false;
            if (txtUsuario.Text != "" & txtSenha.Text != "" & txtNome.Text != "")
            {
                verifica = true;
            }

            return verifica;
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        class Usr
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Acesso { get; set; }
            public string Ativo { get; set; }
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                checkBox.Text = "Ativo";
            }
            else
            {
                checkBox.Text = "Inativo";
            }
        }

        private void txtConfirmarSenha_Leave(object sender, EventArgs e)
        {
            ConfirmarSenha();
        }

        private bool ConfirmarSenha()
        {
            var retorno = false;

            if (txtSenha.Text == txtConfirmarSenha.Text && !string.IsNullOrWhiteSpace(txtConfirmarSenha.Text) && !string.IsNullOrEmpty(txtSenha.Text))
            {
                lblConfirmarSenha.BackColor = Color.Green;
                lblConfirmarSenha.Text = "Senhas validadas";
                retorno = true;
            }
            else
            {
                lblConfirmarSenha.BackColor = Color.Red;
                lblConfirmarSenha.Text = "Senhas diferentes";
            }

            if (txtConfirmarSenha.Text == "" && txtSenha.Text == "")
            {
                lblConfirmarSenha.Text = "";
                lblConfirmarSenha.BackColor = Color.White;
            }
            return retorno;
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            ConfirmarSenha();
        }

        public bool VerificarNomeDeUsuario()
        {
            var retorno = true;

            if (txtUsuario.Text.Contains(" "))
            {
                retorno = false;
            }

            return retorno;
        }

        public bool SegurancaDaSenha()
        {
            var regex = new Regex("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])[0-9a-zA-Z$*&@#]{8,}$");

            var senha = regex.Match(txtSenha.Text);
            var confirmarSenha = regex.Match(txtConfirmarSenha.Text);

            return senha == confirmarSenha;

        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSenha.Checked)
            {
                txtSenha.PasswordChar = '\0';
                txtConfirmarSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '*';
                txtConfirmarSenha.PasswordChar = '*';
            }
        }
    }
}
