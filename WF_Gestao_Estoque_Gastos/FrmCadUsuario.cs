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
using WF_Gestao_Estoque_Gastos.Conexao;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public partial class FrmCadUsuario : MaterialForm
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;uid=root;pwd=;sslmode=none");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader rd;

        public FrmCadUsuario()
        {
            InitializeComponent();
            checkBox.Checked = true;
            checkBox.Text = "Ativo";
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

        }
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (VerificaInputs())
            {
                try
                {
                    con.Open();

                    var id = BuscarUltimoId();
                    id += id;
                    cmd.Connection = con;
                    cmd.CommandText = ($@"INSERT INTO tblUsuario(
                    Id, Nome, Username, Senha, Acesso, EmpresaId, ManterLogado, Ativo) VALUES
                    ('{id}', '{txtNome.Text}','{txtUsuario.Text}', '{txtSenha.Text}','1', '1','0','True')");
                    int retorno = cmd.ExecuteNonQuery();

                    if (retorno < 1)
                    {
                        MessageBox.Show("Não foi possível inserir o usuário");
                    }
                    else
                    {
                        MessageBox.Show("Usuário inserido com sucesso");
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
                    LimparCampos();
                    con.Close();
                }
            }
            else
            {
                if (checkBox.Checked)
                {
                    MessageBox.Show("Preencha ambos os campos!");
                }
                else
                {
                    MessageBox.Show("Marque a caixa para cadastrar o usuário como ativo!");
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            checkBox.Checked = true;
        }

        public bool VerificaInputs()
        {
            bool verifica = false;
            if (txtUsuario.Text != "" & txtSenha.Text != "" && checkBox.Checked)
            {
                verifica = true;
            }
            else
            {
                verifica = false;
            }

            return verifica;
        }

        public void LimparCampos()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtNome.Text = "";
            checkBox.Checked = true;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
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

        public int BuscarUltimoId()
        {
            var retorno = 0;
            cmd.CommandText = ("SELECT id FROM tblUsuario ORDER BY id");
            cmd.Connection = con;
            rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                retorno = int.Parse(rd["id"].ToString());
            }
            rd.Close();
            return retorno;
        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            List<Usr> usuarios = new List<Usr>();
            cmd.CommandText = ("SELECT * FROM tblUsuario");

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

        class Usr
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Acesso { get; set; }
            public string Ativo { get; set; }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = "";
            var name = "";
            var username = "";
            var acesso = "";
            var ativo = "";

            if(listView.SelectedIndices.Count <= 0)
            {
                return;
            }

            var indiceItemSelecionado = Convert.ToInt32(listView.SelectedIndices[0]);
            if(indiceItemSelecionado >= 0)
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
    }
}
