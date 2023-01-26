namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    partial class FrmCadReceita
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
<<<<<<< HEAD
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nomeReceita = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valorTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lucro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valorCobrado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCadastrarReceita = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCancelarReceita = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ingredienteReceita = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cbxIngredientes = new System.Windows.Forms.ComboBox();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.materialRaisedButton2);
            this.groupBox1.Controls.Add(this.materialSingleLineTextField2);
            this.groupBox1.Controls.Add(this.materialSingleLineTextField1);
            this.groupBox1.Controls.Add(this.cbxIngredientes);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.btnCancelarReceita);
            this.groupBox1.Controls.Add(this.btnCadastrarReceita);
            this.groupBox1.Controls.Add(this.nomeReceita);
            this.groupBox1.Location = new System.Drawing.Point(13, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro";
            // 
            // nomeReceita
            // 
            this.nomeReceita.Depth = 0;
            this.nomeReceita.Hint = "Nome da receita";
            this.nomeReceita.Location = new System.Drawing.Point(6, 36);
            this.nomeReceita.MouseState = MaterialSkin.MouseState.HOVER;
            this.nomeReceita.Name = "nomeReceita";
            this.nomeReceita.PasswordChar = '\0';
            this.nomeReceita.SelectedText = "";
            this.nomeReceita.SelectionLength = 0;
            this.nomeReceita.SelectionStart = 0;
            this.nomeReceita.Size = new System.Drawing.Size(304, 23);
            this.nomeReceita.TabIndex = 0;
            this.nomeReceita.UseSystemPasswordChar = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.materialRaisedButton1);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(337, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 244);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadastro";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nome,
            this.ingredienteReceita,
            this.valorTotal,
            this.valorCobrado,
            this.lucro});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(7, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(431, 189);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // nome
            // 
            this.nome.Text = "Nome";
            // 
            // valorTotal
            // 
            this.valorTotal.DisplayIndex = 1;
            this.valorTotal.Text = "Valor Total";
            this.valorTotal.Width = 91;
            // 
            // lucro
            // 
            this.lucro.DisplayIndex = 3;
            this.lucro.Text = "Lucro";
            this.lucro.Width = 63;
            // 
            // valorCobrado
            // 
            this.valorCobrado.DisplayIndex = 2;
            this.valorCobrado.Text = "Valor cobrado";
            this.valorCobrado.Width = 85;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(342, 215);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(96, 23);
            this.materialRaisedButton1.TabIndex = 1;
            this.materialRaisedButton1.Text = "Excluir";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            // 
            // btnCadastrarReceita
            // 
            this.btnCadastrarReceita.Depth = 0;
            this.btnCadastrarReceita.Location = new System.Drawing.Point(210, 215);
            this.btnCadastrarReceita.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCadastrarReceita.Name = "btnCadastrarReceita";
            this.btnCadastrarReceita.Primary = true;
            this.btnCadastrarReceita.Size = new System.Drawing.Size(100, 23);
            this.btnCadastrarReceita.TabIndex = 1;
            this.btnCadastrarReceita.Text = "Cadastrar";
            this.btnCadastrarReceita.UseVisualStyleBackColor = true;
            // 
            // btnCancelarReceita
            // 
            this.btnCancelarReceita.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancelarReceita.Depth = 0;
            this.btnCancelarReceita.Location = new System.Drawing.Point(104, 215);
            this.btnCancelarReceita.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelarReceita.Name = "btnCancelarReceita";
            this.btnCancelarReceita.Primary = true;
            this.btnCancelarReceita.Size = new System.Drawing.Size(100, 23);
            this.btnCancelarReceita.TabIndex = 2;
            this.btnCancelarReceita.Text = "Cancelar";
            this.btnCancelarReceita.UseVisualStyleBackColor = false;
            // 
            // ingredienteReceita
            // 
            this.ingredienteReceita.DisplayIndex = 4;
            this.ingredienteReceita.Text = "Ingredientes";
            this.ingredienteReceita.Width = 127;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(2, 86);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(186, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Selecione os ingredientes:";
            // 
            // cbxIngredientes
            // 
            this.cbxIngredientes.BackColor = System.Drawing.Color.LightGray;
            this.cbxIngredientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIngredientes.FormattingEnabled = true;
            this.cbxIngredientes.Location = new System.Drawing.Point(6, 108);
            this.cbxIngredientes.Name = "cbxIngredientes";
            this.cbxIngredientes.Size = new System.Drawing.Size(170, 21);
            this.cbxIngredientes.TabIndex = 4;
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "Quantidade";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(182, 108);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(97, 23);
            this.materialSingleLineTextField1.TabIndex = 5;
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // materialSingleLineTextField2
            // 
            this.materialSingleLineTextField2.Depth = 0;
            this.materialSingleLineTextField2.Hint = "Preço da receita";
            this.materialSingleLineTextField2.Location = new System.Drawing.Point(6, 159);
            this.materialSingleLineTextField2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField2.Name = "materialSingleLineTextField2";
            this.materialSingleLineTextField2.PasswordChar = '\0';
            this.materialSingleLineTextField2.SelectedText = "";
            this.materialSingleLineTextField2.SelectionLength = 0;
            this.materialSingleLineTextField2.SelectionStart = 0;
            this.materialSingleLineTextField2.Size = new System.Drawing.Size(170, 23);
            this.materialSingleLineTextField2.TabIndex = 6;
            this.materialSingleLineTextField2.UseSystemPasswordChar = false;
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(285, 108);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(25, 23);
            this.materialRaisedButton2.TabIndex = 7;
            this.materialRaisedButton2.Text = "+";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            // 
            // FrmCadReceita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 328);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCadReceita";
            this.Text = "Cadastro de Receitas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField nomeReceita;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader nome;
        private System.Windows.Forms.ColumnHeader valorTotal;
        private System.Windows.Forms.ColumnHeader valorCobrado;
        private System.Windows.Forms.ColumnHeader lucro;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton btnCadastrarReceita;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancelarReceita;
        private System.Windows.Forms.ColumnHeader ingredienteReceita;
        private System.Windows.Forms.ComboBox cbxIngredientes;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
=======
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "FrmCadReceita";
        }

        #endregion
>>>>>>> cdfda5d3e1b8d37fd8e61632a4dd728e7639cf86
    }
}