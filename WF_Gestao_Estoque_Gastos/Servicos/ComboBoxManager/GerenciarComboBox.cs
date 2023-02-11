using System.Windows.Controls;

namespace WF_Gestao_Estoque_Gastos.Servicos.ComboBoxManager
{
    public static class GerenciarComboBox
    {
        public static bool ExisteItemSelecionadoCombo(ComboBox list)
        {
            return list.SelectedIndex != -1;
        }
        public static object RetornaItemSelecionadoCombo(ComboBox combo)
        {
            if (ExisteItemSelecionadoCombo(combo))
                return combo.SelectedItem;
            return null;
        }
    }
}
