using MaterialSkin.Controls;
using System;
using WF_Gestao_Estoque_Gastos.Cadastros;

namespace WF_Gestao_Estoque_Gastos
{
    public partial class FrmPrincipal : MaterialForm
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var telaCadastroEmpresa = new FrmCadEmpresa();
            telaCadastroEmpresa.Show();
           
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var telaCadastroUsuario = new FrmCadUsuario();
            telaCadastroUsuario.Show();
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var telaCadastroIngrediente = new FrmCadIngrediente();
            telaCadastroIngrediente.Show();
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var telaCadstroUnidadeMedida = new FrmCadUnidadeMedida();
            telaCadstroUnidadeMedida.Show();
        }

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            var frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }
    }
}
