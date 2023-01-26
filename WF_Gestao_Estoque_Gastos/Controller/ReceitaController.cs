using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WF_Gestao_Estoque_Gastos.Controller
{
    public class ReceitaController
    {
        MySqlConnection con;
        MySqlDataReader reader;
        MySqlCommand command;
        public ReceitaController()
        {
            command = new MySqlCommand();
            //con = new MySqlConnection("Server=localhost;Database=gestao_estoque_gasto;user=root;Pwd=;SslMode=none");
            con = new MySqlConnection("server=localhost;database=dblogin;uid=root;=pwd=;"); 
            //AtualizarLista();
        }

        public List<Ingrediente> GetIngredientes()
        {
            con.Open();
            var query = "Select * from tblingrediente";
            command.CommandText = query;
            command.Connection = con;
            reader =  command.ExecuteReader();

            var lista = new List<Ingrediente>();    
            while (reader.Read())
            {
                var Ingrediente = new Ingrediente()
                {
                    Nome  = reader["Nome"].ToString(),
                    Preco = Convert.ToDecimal(reader["Preco"].ToString()),
                    QuantidadeUnidade = Convert.ToInt32( reader["QuantidadeUnidade"].ToString())
                };

                lista.Add(Ingrediente);
            }

            con.Close();
            return lista;
        }

        public List<Receita> GetReceitas()
        {
            var lista = new List<Receita>();

            con.Open();
            var query = "Select * from tblingrediente";
            command.CommandText = query;
            command.Connection = con;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                var receita = new Receita()
                {
                    Id         = Convert.ToInt32(reader["Id"].ToString()),
                    Descricao  = reader["Descricao"].ToString(),
                    ValorLucro = Convert.ToDecimal(reader["ValorLucro"].ToString()),
                    ValorTotal = Convert.ToInt32(reader["ValorTotal"].ToString()),
                    ValorVenda = Convert.ToDecimal(reader["ValorVenda"].ToString()),
                };

                lista.Add(receita);
            }

            con.Close();

            return lista;
        }

        public void InserirReceita(TextBox descricao,decimal valorVenda, List<Ingrediente> ingredientes)
        {
            var valorTotal = 0m;
            var valorLucro = 0m;
            foreach (var ingrediente in ingredientes)
            {
                valorTotal += ingrediente.Preco;
            }
            valorLucro = valorVenda - valorTotal;

            con.Open();
            command.CommandText = $"INSERT INTO tblreceita(descricao, valorTotal, valorLucro, valorVenda) VALUES('{descricao.Text}' , {valorTotal}, {valorLucro},{valorVenda});";
            command.Connection  = con;

            command.ExecuteNonQuery();    
            con.Close();
        }
        public void DeleteReceita(int id)
        {
            con.Open();
            command.CommandText = $"DELETE FROM tblreceita where {id} = id";
            command.Connection = con;

            command.ExecuteNonQuery();
            con.Close();
        }

    }
}
