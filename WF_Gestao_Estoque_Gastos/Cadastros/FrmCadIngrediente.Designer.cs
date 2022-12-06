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
            this.txtIngrediente = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnCadastrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.lsvIngredientes = new System.Windows.Forms.ListView();
            this.ingrediente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtQuantidade = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnEditar = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnExcluir = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cbxUnidMedida = new System.Windows.Forms.ComboBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtPreco = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnCancelar = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnLimpar = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // txtIngrediente
            // 
            this.txtIngrediente.Depth = 0;
            this.txtIngrediente.Hint = "";
            this.txtIngrediente.Location = new System.Drawing.Point(22, 125);
            this.txtIngrediente.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIngrediente.Name = "txtIngrediente";
            this.txtIngrediente.PasswordChar = '\0';
            this.txtIngrediente.SelectedText = "";
            this.txtIngrediente.SelectionLength = 0;
            this.txtIngrediente.SelectionStart = 0;
            this.txtIngrediente.Size = new System.Drawing.Size(363, 23);
            this.txtIngrediente.TabIndex = 1;
            this.txtIngrediente.UseSystemPasswordChar = false;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.AutoSize = true;
            this.btnCadastrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCadastrar.Depth = 0;
            this.btnCadastrar.Location = new System.Drawing.Point(20, 416);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCadastrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Primary = false;
            this.btnCadastrar.Size = new System.Drawing.Size(91, 36);
            this.btnCadastrar.TabIndex = 2;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // lsvIngredientes
            // 
            this.lsvIngredientes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ingrediente,
            this.quantidade});
            this.lsvIngredientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvIngredientes.FullRowSelect = true;
            this.lsvIngredientes.GridLines = true;
            this.lsvIngredientes.HideSelection = false;
            this.lsvIngredientes.Location = new System.Drawing.Point(435, 90);
            this.lsvIngredientes.Name = "lsvIngredientes";
            this.lsvIngredientes.Size = new System.Drawing.Size(411, 362);
            this.lsvIngredientes.TabIndex = 3;
            this.lsvIngredientes.UseCompatibleStateImageBehavior = false;
            this.lsvIngredientes.View = System.Windows.Forms.View.Details;
            // 
            // ingrediente
            // 
            this.ingrediente.Text = "Ingrediente";
            this.ingrediente.Width = 244;
            // 
            // quantidade
            // 
            this.quantidade.Text = "Quantidade";
            this.quantidade.Width = 163;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(23, 90);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(83, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Ingrediente";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(23, 169);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(84, 19);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Depth = 0;
            this.txtQuantidade.Hint = "";
            this.txtQuantidade.Location = new System.Drawing.Point(22, 204);
            this.txtQuantidade.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.PasswordChar = '\0';
            this.txtQuantidade.SelectedText = "";
            this.txtQuantidade.SelectionLength = 0;
            this.txtQuantidade.SelectionStart = 0;
            this.txtQuantidade.Size = new System.Drawing.Size(363, 23);
            this.txtQuantidade.TabIndex = 5;
            this.txtQuantidade.UseSystemPasswordChar = false;
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = true;
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.Depth = 0;
            this.btnEditar.Location = new System.Drawing.Point(119, 416);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Primary = false;
            this.btnEditar.Size = new System.Drawing.Size(59, 36);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExcluir.Depth = 0;
            this.btnExcluir.Location = new System.Drawing.Point(186, 416);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExcluir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Primary = false;
            this.btnExcluir.Size = new System.Drawing.Size(66, 36);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(23, 243);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(136, 19);
            this.materialLabel3.TabIndex = 10;
            this.materialLabel3.Text = "Unidade de medida";
            // 
            // cbxUnidMedida
            // 
            this.cbxUnidMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidMedida.FormattingEnabled = true;
            this.cbxUnidMedida.Items.AddRange(new object[] {
            "Quilos",
            "Gramas",
            "Litros"});
            this.cbxUnidMedida.Location = new System.Drawing.Point(27, 276);
            this.cbxUnidMedida.Name = "cbxUnidMedida";
            this.cbxUnidMedida.Size = new System.Drawing.Size(149, 21);
            this.cbxUnidMedida.TabIndex = 11;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(25, 310);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(48, 19);
            this.materialLabel4.TabIndex = 13;
            this.materialLabel4.Text = "Preço";
            // 
            // txtPreco
            // 
            this.txtPreco.Depth = 0;
            this.txtPreco.Hint = "";
            this.txtPreco.Location = new System.Drawing.Point(24, 345);
            this.txtPreco.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.PasswordChar = '\0';
            this.txtPreco.SelectedText = "";
            this.txtPreco.SelectionLength = 0;
            this.txtPreco.SelectionStart = 0;
            this.txtPreco.Size = new System.Drawing.Size(152, 23);
            this.txtPreco.TabIndex = 12;
            this.txtPreco.UseSystemPasswordChar = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.Location = new System.Drawing.Point(327, 416);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Primary = false;
            this.btnCancelar.Size = new System.Drawing.Size(82, 36);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.AutoSize = true;
            this.btnLimpar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpar.Depth = 0;
            this.btnLimpar.Location = new System.Drawing.Point(260, 416);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLimpar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Primary = false;
            this.btnLimpar.Size = new System.Drawing.Size(62, 36);
            this.btnLimpar.TabIndex = 14;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // FrmCadIngrediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 479);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.cbxUnidMedida);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.lsvIngredientes);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtIngrediente);
            this.Name = "FrmCadIngrediente";
            this.Text = "Cadastro de Ingrediente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIngrediente;
        private MaterialSkin.Controls.MaterialFlatButton btnCadastrar;
        private System.Windows.Forms.ListView lsvIngredientes;
        private System.Windows.Forms.ColumnHeader ingrediente;
        private System.Windows.Forms.ColumnHeader quantidade;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtQuantidade;
        private MaterialSkin.Controls.MaterialFlatButton btnEditar;
        private MaterialSkin.Controls.MaterialFlatButton btnExcluir;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.ComboBox cbxUnidMedida;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPreco;
        private MaterialSkin.Controls.MaterialFlatButton btnCancelar;
        private MaterialSkin.Controls.MaterialFlatButton btnLimpar;
    }
}