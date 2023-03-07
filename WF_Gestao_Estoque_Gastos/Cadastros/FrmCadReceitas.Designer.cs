namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    partial class FrmCadReceitas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNovaReceita = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblReceita = new MaterialSkin.Controls.MaterialLabel();
            this.btnAdicionarReceita = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.lblNome = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnExcluir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listViewReceitas = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtCusto = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNome = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblReceitaIngrediente = new MaterialSkin.Controls.MaterialLabel();
            this.btnAdicionarIngrediente = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblIngrediente = new MaterialSkin.Controls.MaterialLabel();
            this.btnExcluirIngrediente = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtQuantidade = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cbbIngrediente = new System.Windows.Forms.ComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.listViewIngredientes = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNovaReceita);
            this.groupBox1.Controls.Add(this.lblReceita);
            this.groupBox1.Controls.Add(this.btnAdicionarReceita);
            this.groupBox1.Controls.Add(this.materialLabel6);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.listViewReceitas);
            this.groupBox1.Controls.Add(this.txtCusto);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Location = new System.Drawing.Point(25, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnNovaReceita
            // 
            this.btnNovaReceita.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNovaReceita.Depth = 0;
            this.btnNovaReceita.Location = new System.Drawing.Point(26, 29);
            this.btnNovaReceita.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNovaReceita.Name = "btnNovaReceita";
            this.btnNovaReceita.Primary = true;
            this.btnNovaReceita.Size = new System.Drawing.Size(196, 23);
            this.btnNovaReceita.TabIndex = 14;
            this.btnNovaReceita.Text = " Nova Receita";
            this.btnNovaReceita.UseVisualStyleBackColor = false;
            this.btnNovaReceita.Click += new System.EventHandler(this.btnNovaReceita_Click_1);
            // 
            // lblReceita
            // 
            this.lblReceita.AutoSize = true;
            this.lblReceita.Depth = 0;
            this.lblReceita.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblReceita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReceita.Location = new System.Drawing.Point(26, 63);
            this.lblReceita.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblReceita.Name = "lblReceita";
            this.lblReceita.Size = new System.Drawing.Size(151, 19);
            this.lblReceita.TabIndex = 13;
            this.lblReceita.Text = "remover texto depois";
            this.lblReceita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdicionarReceita
            // 
            this.btnAdicionarReceita.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdicionarReceita.Depth = 0;
            this.btnAdicionarReceita.Location = new System.Drawing.Point(25, 256);
            this.btnAdicionarReceita.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdicionarReceita.Name = "btnAdicionarReceita";
            this.btnAdicionarReceita.Primary = true;
            this.btnAdicionarReceita.Size = new System.Drawing.Size(196, 23);
            this.btnAdicionarReceita.TabIndex = 7;
            this.btnAdicionarReceita.Text = " Adicionar Receita";
            this.btnAdicionarReceita.UseVisualStyleBackColor = false;
            this.btnAdicionarReceita.Click += new System.EventHandler(this.btnAdicionar_Click_1);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(22, 133);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(49, 19);
            this.materialLabel6.TabIndex = 10;
            this.materialLabel6.Text = "Custo";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Depth = 0;
            this.lblNome.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNome.Location = new System.Drawing.Point(22, 82);
            this.lblNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(50, 19);
            this.lblNome.TabIndex = 9;
            this.lblNome.Text = "Nome";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(323, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(152, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Cadastro de Receitas";
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExcluir.Depth = 0;
            this.btnExcluir.Location = new System.Drawing.Point(539, 256);
            this.btnExcluir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Primary = true;
            this.btnExcluir.Size = new System.Drawing.Size(196, 26);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // listViewReceitas
            // 
            this.listViewReceitas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewReceitas.FullRowSelect = true;
            this.listViewReceitas.GridLines = true;
            this.listViewReceitas.HideSelection = false;
            this.listViewReceitas.Location = new System.Drawing.Point(254, 72);
            this.listViewReceitas.MultiSelect = false;
            this.listViewReceitas.Name = "listViewReceitas";
            this.listViewReceitas.Size = new System.Drawing.Size(481, 175);
            this.listViewReceitas.TabIndex = 4;
            this.listViewReceitas.UseCompatibleStateImageBehavior = false;
            this.listViewReceitas.View = System.Windows.Forms.View.Details;
            this.listViewReceitas.SelectedIndexChanged += new System.EventHandler(this.listViewCadastroReceitas_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Receita";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome da Receita";
            this.columnHeader2.Width = 228;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total da Receita";
            this.columnHeader3.Width = 98;
            // 
            // txtCusto
            // 
            this.txtCusto.Depth = 0;
            this.txtCusto.Hint = "";
            this.txtCusto.Location = new System.Drawing.Point(25, 160);
            this.txtCusto.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.PasswordChar = '\0';
            this.txtCusto.SelectedText = "";
            this.txtCusto.SelectionLength = 0;
            this.txtCusto.SelectionStart = 0;
            this.txtCusto.Size = new System.Drawing.Size(196, 23);
            this.txtCusto.TabIndex = 1;
            this.txtCusto.UseSystemPasswordChar = false;
            this.txtCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCusto_KeyPress);
            // 
            // txtNome
            // 
            this.txtNome.Depth = 0;
            this.txtNome.Hint = "";
            this.txtNome.Location = new System.Drawing.Point(25, 107);
            this.txtNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNome.Name = "txtNome";
            this.txtNome.PasswordChar = '\0';
            this.txtNome.SelectedText = "";
            this.txtNome.SelectionLength = 0;
            this.txtNome.SelectionStart = 0;
            this.txtNome.Size = new System.Drawing.Size(196, 23);
            this.txtNome.TabIndex = 0;
            this.txtNome.UseSystemPasswordChar = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblReceitaIngrediente);
            this.groupBox2.Controls.Add(this.btnAdicionarIngrediente);
            this.groupBox2.Controls.Add(this.lblIngrediente);
            this.groupBox2.Controls.Add(this.btnExcluirIngrediente);
            this.groupBox2.Controls.Add(this.materialLabel4);
            this.groupBox2.Controls.Add(this.txtQuantidade);
            this.groupBox2.Controls.Add(this.materialLabel3);
            this.groupBox2.Controls.Add(this.cbbIngrediente);
            this.groupBox2.Controls.Add(this.materialLabel2);
            this.groupBox2.Controls.Add(this.listViewIngredientes);
            this.groupBox2.Location = new System.Drawing.Point(25, 400);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(751, 243);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // lblReceitaIngrediente
            // 
            this.lblReceitaIngrediente.AutoSize = true;
            this.lblReceitaIngrediente.Depth = 0;
            this.lblReceitaIngrediente.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblReceitaIngrediente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReceitaIngrediente.Location = new System.Drawing.Point(117, 16);
            this.lblReceitaIngrediente.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblReceitaIngrediente.Name = "lblReceitaIngrediente";
            this.lblReceitaIngrediente.Size = new System.Drawing.Size(85, 19);
            this.lblReceitaIngrediente.TabIndex = 16;
            this.lblReceitaIngrediente.Text = "tirar depois";
            this.lblReceitaIngrediente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdicionarIngrediente
            // 
            this.btnAdicionarIngrediente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdicionarIngrediente.Depth = 0;
            this.btnAdicionarIngrediente.Location = new System.Drawing.Point(25, 208);
            this.btnAdicionarIngrediente.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdicionarIngrediente.Name = "btnAdicionarIngrediente";
            this.btnAdicionarIngrediente.Primary = true;
            this.btnAdicionarIngrediente.Size = new System.Drawing.Size(196, 23);
            this.btnAdicionarIngrediente.TabIndex = 15;
            this.btnAdicionarIngrediente.Text = " Adicionar Ingrediente";
            this.btnAdicionarIngrediente.UseVisualStyleBackColor = false;
            this.btnAdicionarIngrediente.Click += new System.EventHandler(this.btnAdicionarIngrediente_Click);
            // 
            // lblIngrediente
            // 
            this.lblIngrediente.AutoSize = true;
            this.lblIngrediente.Depth = 0;
            this.lblIngrediente.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblIngrediente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblIngrediente.Location = new System.Drawing.Point(26, 16);
            this.lblIngrediente.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblIngrediente.Name = "lblIngrediente";
            this.lblIngrediente.Size = new System.Drawing.Size(85, 19);
            this.lblIngrediente.TabIndex = 14;
            this.lblIngrediente.Text = "tirar depois";
            this.lblIngrediente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExcluirIngrediente
            // 
            this.btnExcluirIngrediente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExcluirIngrediente.Depth = 0;
            this.btnExcluirIngrediente.Location = new System.Drawing.Point(539, 208);
            this.btnExcluirIngrediente.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExcluirIngrediente.Name = "btnExcluirIngrediente";
            this.btnExcluirIngrediente.Primary = true;
            this.btnExcluirIngrediente.Size = new System.Drawing.Size(196, 23);
            this.btnExcluirIngrediente.TabIndex = 12;
            this.btnExcluirIngrediente.Text = "Excluir";
            this.btnExcluirIngrediente.UseVisualStyleBackColor = false;
            this.btnExcluirIngrediente.Click += new System.EventHandler(this.btnExcluirIngrediente_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(22, 99);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(84, 19);
            this.materialLabel4.TabIndex = 8;
            this.materialLabel4.Text = "Quantidade";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Depth = 0;
            this.txtQuantidade.Hint = "";
            this.txtQuantidade.Location = new System.Drawing.Point(26, 121);
            this.txtQuantidade.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.PasswordChar = '\0';
            this.txtQuantidade.SelectedText = "";
            this.txtQuantidade.SelectionLength = 0;
            this.txtQuantidade.SelectionStart = 0;
            this.txtQuantidade.Size = new System.Drawing.Size(196, 23);
            this.txtQuantidade.TabIndex = 7;
            this.txtQuantidade.UseSystemPasswordChar = false;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(22, 40);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(83, 19);
            this.materialLabel3.TabIndex = 7;
            this.materialLabel3.Text = "Ingrediente";
            // 
            // cbbIngrediente
            // 
            this.cbbIngrediente.FormattingEnabled = true;
            this.cbbIngrediente.Location = new System.Drawing.Point(26, 62);
            this.cbbIngrediente.Name = "cbbIngrediente";
            this.cbbIngrediente.Size = new System.Drawing.Size(196, 21);
            this.cbbIngrediente.TabIndex = 7;
            this.cbbIngrediente.SelectedIndexChanged += new System.EventHandler(this.cbbIngrediente_SelectedIndexChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(340, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(165, 19);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "Ingredientes da Receita";
            // 
            // listViewIngredientes
            // 
            this.listViewIngredientes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewIngredientes.FullRowSelect = true;
            this.listViewIngredientes.GridLines = true;
            this.listViewIngredientes.HideSelection = false;
            this.listViewIngredientes.Location = new System.Drawing.Point(254, 28);
            this.listViewIngredientes.MultiSelect = false;
            this.listViewIngredientes.Name = "listViewIngredientes";
            this.listViewIngredientes.Size = new System.Drawing.Size(481, 172);
            this.listViewIngredientes.TabIndex = 4;
            this.listViewIngredientes.UseCompatibleStateImageBehavior = false;
            this.listViewIngredientes.View = System.Windows.Forms.View.Details;
            this.listViewIngredientes.SelectedIndexChanged += new System.EventHandler(this.listViewItens_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ingrediente";
            this.columnHeader4.Width = 71;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nome";
            this.columnHeader5.Width = 210;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Quantidade";
            this.columnHeader6.Width = 126;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Custo";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Width = 0;
            // 
            // FrmCadReceitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 677);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCadReceitas";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmCadReceitas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNome;
        private MaterialSkin.Controls.MaterialRaisedButton btnExcluir;
        private System.Windows.Forms.ListView listViewReceitas;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ListView listViewIngredientes;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtQuantidade;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.ComboBox cbbIngrediente;
        private MaterialSkin.Controls.MaterialLabel lblNome;
        private MaterialSkin.Controls.MaterialRaisedButton btnAdicionarReceita;
        private MaterialSkin.Controls.MaterialRaisedButton btnExcluirIngrediente;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCusto;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private MaterialSkin.Controls.MaterialLabel lblReceita;
        private MaterialSkin.Controls.MaterialLabel lblIngrediente;
        private MaterialSkin.Controls.MaterialRaisedButton btnNovaReceita;
        private MaterialSkin.Controls.MaterialRaisedButton btnAdicionarIngrediente;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private MaterialSkin.Controls.MaterialLabel lblReceitaIngrediente;
    }
}