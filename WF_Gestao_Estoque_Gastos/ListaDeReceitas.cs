using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Gestao_Estoque_Gastos
{
    public class ListaDeReceitas
    {
        public int Id { get; set; }
        public string Receita { get; set; }
        public int IdEmpresa { get; set; }
        public decimal TotalReceita { get; set; }
    }
}
