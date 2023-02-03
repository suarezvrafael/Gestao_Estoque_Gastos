using System.Windows.Forms;

namespace WF_Gestao_Estoque_Gastos.Servicos
{
    public static class GerenciarTela
    {
        public static void AbrirTela(Form form, bool dialog = false)
        {
            if (dialog)
                form.ShowDialog();
            else
                form.Show();
        }
    }
}
