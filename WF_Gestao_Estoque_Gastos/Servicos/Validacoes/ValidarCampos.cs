using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using WF_Gestao_Estoque_Gastos.Servicos.Excecoes;

namespace WF_Gestao_Estoque_Gastos.Servicos.Validacoes
{
    public static class ValidarCampos
    {
        public static bool CampoStringPreenchido(string entrada)
        {
            return !string.IsNullOrWhiteSpace(entrada);
        }
        public static bool CampoApenasNumerico(string entrada)
        {
            var apenasNumeros = new Regex("^\\d+$");
            return apenasNumeros.Match(entrada).Success;
        }

        public static bool ExisteItemSelecionadoListView(ListView list)
        {
            return list.SelectedIndex != -1;
        }
        public static int RetornaIndiceSelecionadoListView(ListView list)
        {
            return list.SelectedIndex;
        }

        public static object RetornaListViewSelecionado(ListView list)
        {
            if (ExisteItemSelecionadoListView(list))
                return list.SelectedItem;
            Mensagem.Informacao("Não existia item selecionado no listView");
            return null;
        }

        public static bool ExisteItemSelecionadoCombo(ComboBox list)
        {
            return list.SelectedIndex != -1;
        }
        public static object RetornaItemSelecionadoCombo(ComboBox combo)
        {
            if(ExisteItemSelecionadoCombo(combo))   
                return combo.SelectedItem;
            return null;
        }

        public static bool CampoPreenchido(params string[] campos)
        {
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo))
                    return false;
            }
            return true;
        }
    }
}
