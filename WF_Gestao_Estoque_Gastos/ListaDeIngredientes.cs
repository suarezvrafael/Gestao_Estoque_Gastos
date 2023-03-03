using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Gestao_Estoque_Gastos
{


//id
//idIngrediente
//IdReceita
//quantidadeIngrediente
//idGastoVariado
//qntGastoVariado

    public class ListaDeIngredientes
    {
        public int Id { get; set; }
        public int IdIngrediente { get; set; }
        public int IdReceita { get; set; }
        public decimal QuantidadeIngrediente { get; set; }
        public int IdGastoVariado { get; set; }
        public decimal QuantidadeGastoVariado { get; set; }
    }
}
