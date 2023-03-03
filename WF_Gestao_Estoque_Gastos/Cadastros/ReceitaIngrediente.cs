using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    internal class ReceitaIngrediente
    {
        public int Id { get; set; }
        public string NomeIngrediente { get; set; }
        public decimal QuantidadeIngrediente { get; set; }
        public decimal PrecoIngrediente{ get; set; }
        public int IdIngrediente { get; internal set; }
    }
}
