namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string NomeIngrediente { get; set; }
        public decimal PrecoIngrediente { get; set; }
        public int UnidadeMedidaId { get; set; }
        public decimal QuantidadeUnidade { get; set; }
        public int EmpresaId { get; set; }

    }
}