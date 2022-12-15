﻿using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public partial class FrmCadUnidadeMedida : MaterialForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public FrmCadUnidadeMedida()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=gestao_estoque_gasto;user=root;Pwd=;SslMode=none");
            atualizar_lista();
        }



        private void btnConfirmar_Click(object sender, System.EventArgs e)
        {
            if (lblId.Text.Equals(String.Empty))
                InserirUnidade();                
            else
                AlterarUnidade();

            atualizar_lista();
            limparCampos();
        }

        public void InserirUnidade()
        {
            var descricao = txtDescricao.Text;
            var sigla = txtSigla.Text;

            if (descricao.Equals(String.Empty))
            {
                //msg
                MessageBox.Show("Digite o campo usuário!");
                txtDescricao.Focus();
                return;
            }
            else if (sigla.Equals(string.Empty))
            {
                //msg
                MessageBox.Show("Digite o campo sigla!");
                txtSigla.Focus();
                return;
            }
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO tblunidademedidaingrediente (descricaoUnidadeMedidaIngrediente, sigla) VALUES(@descricao , @sigla);";

                cmd.Parameters.AddWithValue("descricao", descricao);
                cmd.Parameters.AddWithValue("sigla", sigla);

                int retornoDoInsert = cmd.ExecuteNonQuery();
                if (retornoDoInsert > 0)
                {             
                    MessageBox.Show("Unidade de medida cadastrado com sucesso.");
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ops. Erro: " + e.Message);
            }            
        }

        public void AlterarUnidade()
        {

            var descricao = txtDescricao.Text;
            var sigla = txtSigla.Text;
           //var id = lblId.Text;
            try
            {
                con.Open();

                cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE tblunidademedidaingrediente SET descricaoUnidadeMedidaIngrediente = @descricao, sigla = @sigla WHERE descricao = @descricao;";

                cmd.Parameters.AddWithValue("descricao", descricao);
                cmd.Parameters.AddWithValue("sigla", sigla);
                //cmd.Parameters.AddWithValue("id", id);

                int retornoDoUpdate = cmd.ExecuteNonQuery();

                if (retornoDoUpdate > 0)
                {
                     MessageBox.Show("Unidade de medida alterado com sucesso.");
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Ops. Erro: " + e.Message);
            }   
        }

        public void ExcluirUnidade()
        {
            
            var descricao = "";
            var sigla = "";

            // verifica se não existe um item na lista selecionado
            if (listViewUnidade.SelectedIndices.Count <= 0)
            {
                return;
            }
            // pega o indice da linha selecionada ( -1 significa nenhum selecionado)
            var indiceItemSelecionado = Convert.ToInt32(listViewUnidade.SelectedIndices[0]);
            if (indiceItemSelecionado >= 0)
            {
                // obtem o codigo da primeira coluna do listView
               
                descricao = listViewUnidade.Items[indiceItemSelecionado].SubItems[0].Text;
                sigla = listViewUnidade.Items[indiceItemSelecionado].SubItems[1].Text;

                txtDescricao.Text = descricao;
                txtSigla.Text = sigla;
                lblId.Text = descricao;
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=gestao_estoque_gasto;user=root;Pwd=;SslMode=none");
                try
                {

                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM tblunidademedidaingrediente WHERE descricaoUnidadeMedidaIngrediente = @descricao";
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ops. Erro: " + e.Message);
                }
                atualizar_lista();
                limparCampos();
            }
        }
        
        public void limparCampos()
        {
            txtDescricao.Text = String.Empty;
            txtSigla.Text = String.Empty;
            lblId.Text = String.Empty;
        }
        public void atualizar_lista()
        {
            //cria uma lista do tipo Unidade
            List<Unidade> listaUnidades = new List<Unidade>();

            con = new MySqlConnection("Server=localhost;Database=gestao_estoque_gasto;user=root;Pwd=;SslMode=none");
            con.Open();

            //seta a conexão para o comando
            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT descricaoUnidadeMedidaIngrediente, sigla FROM tblunidademedidaingrediente";

            //executa o comando
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Unidade unidade = new Unidade()

                {
                    //id = Convert.ToInt32(dr["id"].ToString()),
                    descricao = dr["descricaoUnidadeMedidaIngrediente"].ToString(),
                    sigla = dr["sigla"].ToString(),

                };
                listaUnidades.Add(unidade);
            }
            listViewUnidade.Items.Clear();
            //adiciona no ListBox os nomes da lista
            foreach (Unidade unidade in listaUnidades)
            {
                listViewUnidade.Items.Add(new ListViewItem(new String[]
                {
                   // unidade.id.ToString(),
                    unidade.descricao,
                    unidade.sigla,

                }
                ));
            }
            con.Close();

        }

        private void listViewUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = "";
            var descricao = "";
            var sigla = "";
 

            // verifica se não existe um item na lista selecionado
            if (listViewUnidade.SelectedIndices.Count <= 0)
            {
                return;
            }
            // pega o indice da linha selecionada ( -1 significa nenhum selecionado)
            var indiceItemSelecionado = Convert.ToInt32(listViewUnidade.SelectedIndices[0]);
            if (indiceItemSelecionado >= 0)
            {
                // obtem o codigo da primeira coluna do listView
                id = listViewUnidade.Items[indiceItemSelecionado].Text;
                descricao = listViewUnidade.Items[indiceItemSelecionado].SubItems[0].Text;
                sigla = listViewUnidade.Items[indiceItemSelecionado].SubItems[1].Text;


                txtDescricao.Text = descricao;
                txtSigla.Text = sigla;
                lblId.Text = descricao;
                groupBox1.Text = "Editar";
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirUnidade();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            groupBox1.Text = "Cadastro";
        }
    }


}
class Unidade
{
    public int id { get; set; }
    public string descricao { get; set; }
    public string sigla { get; set; }
}