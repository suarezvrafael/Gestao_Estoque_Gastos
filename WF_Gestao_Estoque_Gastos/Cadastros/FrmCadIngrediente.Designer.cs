namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    partial class FrmCadIngrediente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBuscaIngrediente = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblid = new System.Windows.Forms.Label();
            this.btnCancelar = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnLimpar = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtPreco = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cbxUnidMedida = new System.Windows.Forms.ComboBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.btnExcluir = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnSalvar = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtQuantidade = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lsvIngredientes = new System.Windows.Forms.ListView();
            this.Ingrediente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantidadeUnidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unidMedidaId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.precoIngrediente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCadastrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtIngrediente = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(427, 82);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(133, 19);
            this.materialLabel5.TabIndex = 52;
            this.materialLabel5.Text = "Buscar Ingrediente";
            // 
            // txtBuscaIngrediente
            // 
            this.txtBuscaIngrediente.Depth = 0;
            this.txtBuscaIngrediente.Hint = "";
            this.txtBuscaIngrediente.Location = new System.Drawing.Point(566, 80);
            this.txtBuscaIngrediente.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscaIngrediente.Name = "txtBuscaIngrediente";
            this.txtBuscaIngrediente.PasswordChar = '\0';
            this.txtBuscaIngrediente.SelectedText = "";
            this.txtBuscaIngrediente.SelectionLength = 0;
            this.txtBuscaIngrediente.SelectionStart = 0;
            this.txtBuscaIngrediente.Size = new System.Drawing.Size(506, 23);
            this.txtBuscaIngrediente.TabIndex = 51;
            this.txtBuscaIngrediente.UseSystemPasswordChar = false;
            this.txtBuscaIngrediente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscaIngrediente_KeyUp);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(121, 82);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(0, 13);
            this.lblid.TabIndex = 50;
            this.lblid.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.Location = new System.Drawing.Point(331, 378);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Primary = false;
            this.btnCancelar.Size = new System.Drawing.Size(82, 36);
            this.btnCancelar.TabIndex = 49;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnLimpar
            // 
            this.btnLimpar.AutoSize = true;
            this.btnLimpar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpar.Depth = 0;
            this.btnLimpar.Location = new System.Drawing.Point(261, 378);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLimpar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Primary = false;
            this.btnLimpar.Size = new System.Drawing.Size(62, 36);
            this.btnLimpar.TabIndex = 48;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(22, 302);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(48, 19);
            this.materialLabel4.TabIndex = 47;
            this.materialLabel4.Text = "Preço";
            // 
            // txtPreco
            // 
            this.txtPreco.Depth = 0;
            this.txtPreco.Hint = "Ex: 9.999,99";
            this.txtPreco.Location = new System.Drawing.Point(21, 337);
            this.txtPreco.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.PasswordChar = '\0';
            this.txtPreco.SelectedText = "";
            this.txtPreco.SelectionLength = 0;
            this.txtPreco.SelectionStart = 0;
            this.txtPreco.Size = new System.Drawing.Size(152, 23);
            this.txtPreco.TabIndex = 46;
            this.txtPreco.UseSystemPasswordChar = false;
            // 
            // cbxUnidMedida
            // 
            this.cbxUnidMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidMedida.FormattingEnabled = true;
            this.cbxUnidMedida.Location = new System.Drawing.Point(24, 268);
            this.cbxUnidMedida.Name = "cbxUnidMedida";
            this.cbxUnidMedida.Size = new System.Drawing.Size(149, 21);
            this.cbxUnidMedida.TabIndex = 45;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(20, 235);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(136, 19);
            this.materialLabel3.TabIndex = 44;
            this.materialLabel3.Text = "Unidade de medida";
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExcluir.Depth = 0;
            this.btnExcluir.Location = new System.Drawing.Point(187, 378);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExcluir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Primary = false;
            this.btnExcluir.Size = new System.Drawing.Size(66, 36);
            this.btnExcluir.TabIndex = 43;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click_1);
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvar.Depth = 0;
            this.btnSalvar.Location = new System.Drawing.Point(116, 378);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Primary = false;
            this.btnSalvar.Size = new System.Drawing.Size(63, 36);
            this.btnSalvar.TabIndex = 42;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click_1);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(20, 161);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(84, 19);
            this.materialLabel2.TabIndex = 41;
            this.materialLabel2.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Depth = 0;
            this.txtQuantidade.Hint = "";
            this.txtQuantidade.Location = new System.Drawing.Point(19, 196);
            this.txtQuantidade.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.PasswordChar = '\0';
            this.txtQuantidade.SelectedText = "";
            this.txtQuantidade.SelectionLength = 0;
            this.txtQuantidade.SelectionStart = 0;
            this.txtQuantidade.Size = new System.Drawing.Size(160, 23);
            this.txtQuantidade.TabIndex = 40;
            this.txtQuantidade.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(20, 82);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(83, 19);
            this.materialLabel1.TabIndex = 39;
            this.materialLabel1.Text = "Ingrediente";
            // 
            // lsvIngredientes
            // 
            this.lsvIngredientes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ingrediente,
            this.quantidadeUnidade,
            this.unidMedidaId,
            this.precoIngrediente,
            this.id});
            this.lsvIngredientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvIngredientes.FullRowSelect = true;
            this.lsvIngredientes.GridLines = true;
            this.lsvIngredientes.HideSelection = false;
            this.lsvIngredientes.Location = new System.Drawing.Point(431, 114);
            this.lsvIngredientes.Name = "lsvIngredientes";
            this.lsvIngredientes.Size = new System.Drawing.Size(661, 300);
            this.lsvIngredientes.TabIndex = 38;
            this.lsvIngredientes.UseCompatibleStateImageBehavior = false;
            this.lsvIngredientes.View = System.Windows.Forms.View.Details;
            this.lsvIngredientes.SelectedIndexChanged += new System.EventHandler(this.lsvIngredientes_SelectedIndexChanged_1);
            // 
            // Ingrediente
            // 
            this.Ingrediente.Text = "Ingrediente";
            this.Ingrediente.Width = 184;
            // 
            // quantidadeUnidade
            // 
            this.quantidadeUnidade.Text = "Quantidade Un.";
            this.quantidadeUnidade.Width = 147;
            // 
            // unidMedidaId
            // 
            this.unidMedidaId.Text = "Un. Medida";
            this.unidMedidaId.Width = 109;
            // 
            // precoIngrediente
            // 
            this.precoIngrediente.Text = "Preço Ingrediente (R$)";
            this.precoIngrediente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.precoIngrediente.Width = 209;
            // 
            // id
            // 
            this.id.Text = "Id";
            this.id.Width = 0;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.AutoSize = true;
            this.btnCadastrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCadastrar.Depth = 0;
            this.btnCadastrar.Location = new System.Drawing.Point(17, 378);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCadastrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Primary = false;
            this.btnCadastrar.Size = new System.Drawing.Size(91, 36);
            this.btnCadastrar.TabIndex = 37;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click_1);
            // 
            // txtIngrediente
            // 
            this.txtIngrediente.Depth = 0;
            this.txtIngrediente.Hint = "";
            this.txtIngrediente.Location = new System.Drawing.Point(19, 114);
            this.txtIngrediente.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIngrediente.Name = "txtIngrediente";
            this.txtIngrediente.PasswordChar = '\0';
            this.txtIngrediente.SelectedText = "";
            this.txtIngrediente.SelectionLength = 0;
            this.txtIngrediente.SelectionStart = 0;
            this.txtIngrediente.Size = new System.Drawing.Size(363, 23);
            this.txtIngrediente.TabIndex = 36;
            this.txtIngrediente.UseSystemPasswordChar = false;
            // 
            // FrmCadIngrediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 432);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.txtBuscaIngrediente);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.cbxUnidMedida);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.lsvIngredientes);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtIngrediente);
            this.Name = "FrmCadIngrediente";
            this.Load += new System.EventHandler(this.FrmCadIngrediente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscaIngrediente;
        private System.Windows.Forms.Label lblid;
        private MaterialSkin.Controls.MaterialFlatButton btnCancelar;
        private MaterialSkin.Controls.MaterialFlatButton btnLimpar;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPreco;
        private System.Windows.Forms.ComboBox cbxUnidMedida;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialFlatButton btnExcluir;
        private MaterialSkin.Controls.MaterialFlatButton btnSalvar;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtQuantidade;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ListView lsvIngredientes;
        private System.Windows.Forms.ColumnHeader Ingrediente;
        private System.Windows.Forms.ColumnHeader precoIngrediente;
        private System.Windows.Forms.ColumnHeader unidMedidaId;
        private System.Windows.Forms.ColumnHeader quantidadeUnidade;
        private System.Windows.Forms.ColumnHeader id;
        private MaterialSkin.Controls.MaterialFlatButton btnCadastrar;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIngrediente;
    }
}