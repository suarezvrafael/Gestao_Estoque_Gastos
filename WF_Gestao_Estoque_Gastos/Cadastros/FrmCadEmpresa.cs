using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{


    public partial class FrmCadEmpresa : MaterialForm
    {




        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;
        public FrmCadEmpresa()
        {
            con = new MySqlConnection("server=localhost;database=gestao_estoque_gasto;pwd=;uid=root;");

            InitializeComponent();
            atualizar_lista();
        }

        

        private void LimpaCampos()
        {
            mtxtRazaoSocial.Text = String.Empty;
            mtxtNomeFantasia.Text = String.Empty;
            mtxtCnpj.Text = String.Empty;
            mtxtTelefone.Text = String.Empty;
            mtxtEmail.Text = String.Empty;
            mtxtCidade.Text = String.Empty;
            mtxtBairro.Text = String.Empty;
            mtxtComplemento.Text = String.Empty;
            mtxtNumero.Text = String.Empty;
            mtxtRua.Text = String.Empty;


        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e) // btnSalvar
        {

            decimal retornoCnpj = 0;

            string razaoSocial = mtxtRazaoSocial.Text;
            string nomeFantasia = mtxtNomeFantasia.Text;

            
            string CNPJ = mtxtCnpj.Text;

            if (!ContemNumeros(CNPJ))
            {
                MessageBox.Show("Digite apenas Numeros") ;
                return;
            }
            else
            {
                 CNPJ = FormatCNPJ(mtxtCnpj.Text);
            }

            decimal telefone = Convert.ToDecimal(mtxtTelefone.Text);


            string email = mtxtEmail.Text;
            string cidade = mtxtCidade.Text;
            string bairro = mtxtBairro.Text;
            string complemento = mtxtComplemento.Text;
            int numeroResidencia = Convert.ToInt32(mtxtNumero.Text);
            string rua = mtxtRua.Text;


            try
            { 


                con.Open();
                cmd = con.CreateCommand();

                cmd.CommandText = "SELECT CNPJ FROM tblempresa WHERE CNPJ = @CNPJ";
                cmd.Parameters.AddWithValue("CNPJ", CNPJ);
                reader = cmd.ExecuteReader();



                /*Modificar validação pra usar ID e CNPJ criar campo na tela mostrando ID 
                 * mascara de campos telefone e CNPJ
                 * metodo para transformar os numeros em formatação CNPJ e TELEFONE
                 * verificar documentaçao php my admin questoes de update tbl empresa
                 * alterações no banco 
                 * mexer no agrupamento das tabelas apenas a tblEmpresa esta certa
                 * 
                 * 06/02/2023
                 * 
                 * rever os campos do banco pois foi modificado e o codigo precisa ser mudado
                 * olhar regex 
                 * metodos de mascara para material skin se nao achar pesquisar como fazer na mão 
                 * as mascaras
                 * 
                 * 
                */




                while (reader.Read())
                {
                     retornoCnpj = Convert.ToDecimal(reader["CNPJ"].ToString());
                };
                con.Close();
                if (retornoCnpj == 1)
                {
                    con.Open();

                    cmd = con.CreateCommand();

                    cmd.CommandText = "UPDATE tblempresa SET CNPJ = @CNPJ, razaoSocial = @razaoSocial, rua = @rua, bairro = @bairro, numeroEndereco = @numeroResidencia, complemento = @complemento, email = @email, telefone = @telefone, nomeFantasia = @nomeFantasia, cidade = @cidade WHERE CNPJ = @CNPJ";

                    cmd.Parameters.AddWithValue("CNPJ", CNPJ);
                    cmd.Parameters.AddWithValue("razaoSocial", razaoSocial);
                    cmd.Parameters.AddWithValue("rua", rua);
                    cmd.Parameters.AddWithValue("bairro", bairro);
                    cmd.Parameters.AddWithValue("numeroResidencia", numeroResidencia);
                    cmd.Parameters.AddWithValue("complemento", complemento);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("telefone", telefone);
                    cmd.Parameters.AddWithValue("nomeFantasia", nomeFantasia);
                    cmd.Parameters.AddWithValue("cidade", cidade);

                    int retornoDoUpdate = cmd.ExecuteNonQuery();

                    if (retornoDoUpdate > 0)
                    {
                        MessageBox.Show("Empresa alterada com sucesso!");
                        LimpaCampos();
                        atualizar_lista();
                    }
                    con.Close();
                }
                else
                {
                    con.Open();

                    cmd = con.CreateCommand();

                    cmd.CommandText = "INSERT INTO tblempresa (CNPJ,razaoSocial,rua,bairro,numeroEndereco,complemento,email,telefone,nomeFantasia,cidade) VALUES (@CNPJ,@razaoSocial,@rua,@bairro,@numeroResidencia,@complemento,@email,@telefone,@nomeFantasia,@cidade)";

                    cmd.Parameters.AddWithValue("CNPJ", CNPJ);
                    cmd.Parameters.AddWithValue("razaoSocial", razaoSocial);
                    cmd.Parameters.AddWithValue("rua", rua);
                    cmd.Parameters.AddWithValue("bairro", bairro);
                    cmd.Parameters.AddWithValue("numeroResidencia", numeroResidencia);
                    cmd.Parameters.AddWithValue("complemento", complemento);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("telefone", telefone);
                    cmd.Parameters.AddWithValue("nomeFantasia", nomeFantasia);
                    cmd.Parameters.AddWithValue("cidade", cidade);

                    int retornoDoInsert = cmd.ExecuteNonQuery();

                    if (retornoDoInsert > 0)
                    {
                        MessageBox.Show("Empresa cadastrada com sucesso!");
                        LimpaCampos();
                        atualizar_lista();
                    }
                    con.Close();
                }                                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro, contate o suporte técnico para verificar!");
            }


        }

        private void materialRaisedButton2_Click(object sender, EventArgs e) // btnExcluir
        {
            Excluir_empresa();
        }

       

        public void Excluir_empresa()
        {
            var CNPJEmpresa = Convert.ToDecimal(mtxtCnpj.Text);


            if (listViewEmpresa.SelectedIndices.Count <= 0)
            {
                return;
            }
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=gestao_estoque_gasto;user=root;Pwd=;SslMode=none");
            try
            {

                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM `tblempresa` WHERE CNPJ = @CNPJ";
                cmd.Parameters.AddWithValue("@CNPJ",CNPJEmpresa);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ops. Erro: " + e.Message);
            }
            atualizar_lista();
            LimpaCampos();
        }

        public void atualizar_lista()
        {
            //cria uma lista do tipo Empresas
            List<Empresa> listaEmpresas = new List<Empresa>();

            con = new MySqlConnection("Server=localhost;Database=gestao_estoque_gasto;user=root;Pwd=;SslMode=none");
            con.Open();

            //seta a conexão para o comando
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT `id`, `CNPJ`, `razaoSocial`, `rua`, `bairro`, `numeroEndereco`, `complemento`, `email`, `telefone`, `nomeFantasia`, `cidade` FROM `tblempresa`";


            /*SELECT tblempresa.id, CNPJ, razaoSocial, rua, bairro, numeroEndereco, complemento, tblcidade.descricaoCidade, email, telefone, nomeFantasia, createEmpresa, updateEmpresa, idUsername
              FROM tblempresa
              INNER JOIN tblcidade ON tblempresa.idcidade = tblcidade.id
              INNER JOIN tblestado ON tblcidade.id = tblestado.id
              INNER JOIN tblpais ON tblestado.id = tblpais.id            
            */

            //executa o comando
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var id = Convert.ToInt32(reader["id"].ToString());
                var cpnj = Convert.ToDecimal(reader["CNPJ"].ToString());
                var nomeFantasia = reader["nomeFantasia"].ToString();
                var email = reader["email"].ToString();
                var telefone = Convert.ToDecimal(reader["telefone"].ToString());
                var numeroResidencia = Convert.ToInt32(reader["numeroEndereco"].ToString());

                var complemento = reader["complemento"].ToString();
                var cidade = reader["cidade"].ToString();
                var rua = reader["rua"].ToString();
                var bairro = reader["bairro"].ToString();
                var razaoSocial = reader["razaoSocial"].ToString();

                Empresa empresa = new Empresa()
                {
                    id = id,
                    CNPJ = cpnj,
                    nomeFantasia = nomeFantasia,
                    email = email,
                    telefone = telefone,
                    numeroResidencia = numeroResidencia,
                    complemento = complemento,
                    cidade = cidade,
                    rua = rua,
                    bairro = bairro,
                    razaoSocial = razaoSocial,
                };
                listaEmpresas.Add(empresa);
            }
            listViewEmpresa.Items.Clear();
            //adiciona no ListBox os nomes da lista
            foreach (Empresa empresa in listaEmpresas)
            {
                listViewEmpresa.Items.Add(new ListViewItem(new String[]
                {
                    empresa.id.ToString(),                   
                    empresa.nomeFantasia,
                    empresa.CNPJ.ToString(),                   
                    empresa.telefone.ToString(),
                    empresa.email,
                    empresa.razaoSocial,
                    empresa.rua,
                    empresa.bairro,
                    empresa.numeroResidencia.ToString(),
                    empresa.complemento,
                    empresa.cidade,
                }
                ));
            }
            con.Close();

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (listViewEmpresa.SelectedIndices.Count <= 0)
            {
                return;
            }
            else
            {
                btnCancelar.Visible = true;
                mtxtId.Visible = true;
                lblCodigo.Visible = true;
            }

            var itemSelecionado = Convert.ToInt32(listViewEmpresa.SelectedIndices[0]);

            var id = Convert.ToInt32(listViewEmpresa.Items[itemSelecionado].SubItems[0].Text);

            var nomeFantasia = (listViewEmpresa.Items[itemSelecionado].SubItems[1].Text);

            var cnpj = Convert.ToDecimal(listViewEmpresa.Items[itemSelecionado].SubItems[2].Text);

            var telefone = Convert.ToDecimal(listViewEmpresa.Items[itemSelecionado].SubItems[3].Text);

            var email = (listViewEmpresa.Items[itemSelecionado].SubItems[4].Text);

            var razaoSocial = (listViewEmpresa.Items[itemSelecionado].SubItems[5].Text);

            var rua = (listViewEmpresa.Items[itemSelecionado].SubItems[6].Text);

            var bairro = (listViewEmpresa.Items[itemSelecionado].SubItems[7].Text);

            var numeroEndereco = Convert.ToInt32(listViewEmpresa.Items[itemSelecionado].SubItems[8].Text);

            var complemento = (listViewEmpresa.Items[itemSelecionado].SubItems[9].Text);
                                 
            var cidade = (listViewEmpresa.Items[itemSelecionado].SubItems[10].Text);





            mtxtRazaoSocial.Text = razaoSocial.ToString();
            mtxtNomeFantasia.Text = nomeFantasia.ToString();
            mtxtCnpj.Text = FormatCNPJ(cnpj.ToString());
            mtxtTelefone.Text = FormatTelefone(telefone.ToString());
            mtxtEmail.Text = email.ToString();
            mtxtCidade.Text = cidade.ToString();
            mtxtBairro.Text = bairro.ToString();
            mtxtComplemento.Text = complemento.ToString();
            mtxtNumero.Text = numeroEndereco.ToString();
            mtxtRua.Text = rua.ToString();
            mtxtId.Text = id.ToString();    

        }

        private void materialLabel11_Click(object sender, EventArgs e)
        {

        }

        class Empresa
        {
            public int id { get; set; }
            public string razaoSocial { get; set; }
            public string rua { get; set; }
            public string nomeFantasia { get; set; }
            public decimal CNPJ  { get; set; }
            public decimal telefone { get; set; }
            public string email { get; set; }
            public string cidade { get; set; }
            public string bairro { get; set; }
            public string complemento { get; set; }

            public int numeroResidencia { get; set; }

        }

        private void btnCancelar_Click(object sender, EventArgs e) // cancelar
        {
            LimpaCampos();
            btnCancelar.Visible = false;
            lblCodigo.Visible = false;
            mtxtId.Visible = false;
            atualizar_lista();
        }

        private static string FormataIntParaStringCNPJ(int cnpj)
        {
            string cnpjAsString = cnpj.ToString();
            var qtdCarcteres = cnpjAsString.Length;

            if(qtdCarcteres < 13)
                return cnpjAsString.PadLeft(13 - qtdCarcteres, '0');
            return cnpjAsString.Substring(0, 13);
        }

        private static string AdicionaCaracteresMaskara(int i)
        {
            var ponto = ".";
            var barra = "/";
            var hifen = "-";
            switch (i)
            {
                case 2 : return ponto;
                case 5 : return ponto;
                case 8 : return ponto + barra;
                case 12: return hifen;
                    
                default: return "";
            }
        }
        private static string AdicionaMascaraCNPJ(string cnpj)
        {
            var saida = "";
            for(var i =0; i < cnpj.Length; i++)
            {
                saida += AdicionaCaracteresMaskara(i) + cnpj[i];
            }

            return saida;
        }
        private static string FormatCNPJ(string CNPJ)
        {
            var cnpjFormatado = AdicionaMascaraCNPJ(CNPJ);

            return cnpjFormatado;
        }

        private static string FormatTelefone(string telefone)
        {
            return
                Convert.ToUInt64(telefone).ToString(@"\(00\) 0000\-0000");
        }

        public bool ContemNumeros(string verifica)
        {
            bool ok = false;
            ok = Regex.IsMatch(verifica, "^[0-9]+$");
            //var regex = new Regex(@"[^\d]");
            //return regex.Match(verifica).Success;
            return ok;
        }
    }
}
