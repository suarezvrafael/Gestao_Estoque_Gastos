﻿namespace WF_Gestao_Estoque_Gastos
{
    public class Empresa
    {
        public int Id { get; set; }
        public decimal CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int NumeroEndereco { get; set; }
        public string Complemento { get; set; }
        public string Email { get; set; }
        public decimal Telefone { get; set; }
        public string NomeFantasia { get; set; }
        public string Cidade { get; set; }
    }
}