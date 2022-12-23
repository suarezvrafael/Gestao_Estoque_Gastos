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
            telaCadastroEmpresa.ShowDialog();
           
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var telaCadastroUsuario = new FrmCadUsuario();
            telaCadastroUsuario.ShowDialog();
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var telaCadastroIngrediente = new FrmCadIngrediente();
            telaCadastroIngrediente.ShowDialog();
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var telaCadstroUnidadeMedida = new FrmCadUnidadeMedida();
            telaCadstroUnidadeMedida.ShowDialog();
        }

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            var frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }
    }
}
