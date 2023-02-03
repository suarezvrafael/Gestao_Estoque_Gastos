namespace WF_Gestao_Estoque_Gastos.Cadastros
{
    partial class FrmCadUsuario
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
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblid = new System.Windows.Forms.Label();
            this.txtNome = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtUsuario = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.checkBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.txtSenha = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnSalvar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnBuscar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnExcluir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnNovoUsuario = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtConfirmarSenha = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblConfirmarSenha = new System.Windows.Forms.Label();
            this.checkBoxSenha = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnH,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 295);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(453, 240);
            this.listView.TabIndex = 500;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 46;
            // 
            // columnH
            // 
            this.columnH.Text = "Nome";
            this.columnH.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Usuário";
            this.columnHeader3.Width = 133;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Acesso";
            this.columnHeader4.Width = 67;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ativo";
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(9, 70);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(13, 13);
            this.lblid.TabIndex = 32;
            this.lblid.Text = "0";
            // 
            // txtNome
            // 
            this.txtNome.Depth = 0;
            this.txtNome.Hint = "Nome";
            this.txtNome.Location = new System.Drawing.Point(12, 90);
            this.txtNome.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNome.Name = "txtNome";
            this.txtNome.PasswordChar = '\0';
            this.txtNome.SelectedText = "";
            this.txtNome.SelectionLength = 0;
            this.txtNome.SelectionStart = 0;
            this.txtNome.Size = new System.Drawing.Size(449, 23);
            this.txtNome.TabIndex = 0;
            this.txtNome.TabStop = false;
            this.txtNome.UseSystemPasswordChar = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Depth = 0;
            this.txtUsuario.Hint = "Usuário";
            this.txtUsuario.Location = new System.Drawing.Point(12, 132);
            this.txtUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.Size = new System.Drawing.Size(449, 23);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TabStop = false;
            this.txtUsuario.UseSystemPasswordChar = false;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Depth = 0;
            this.checkBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkBox.Location = new System.Drawing.Point(12, 214);
            this.checkBox.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBox.Name = "checkBox";
            this.checkBox.Ripple = true;
            this.checkBox.Size = new System.Drawing.Size(118, 30);
            this.checkBox.TabIndex = 4;
            this.checkBox.TabStop = false;
            this.checkBox.Text = "Ativar/Inativar";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Depth = 0;
            this.txtSenha.Hint = "Senha";
            this.txtSenha.Location = new System.Drawing.Point(12, 176);
            this.txtSenha.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.SelectedText = "";
            this.txtSenha.SelectionLength = 0;
            this.txtSenha.SelectionStart = 0;
            this.txtSenha.Size = new System.Drawing.Size(213, 23);
            this.txtSenha.TabIndex = 800;
            this.txtSenha.TabStop = false;
            this.txtSenha.UseSystemPasswordChar = false;
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Depth = 0;
            this.btnSalvar.Location = new System.Drawing.Point(126, 257);
            this.btnSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Primary = true;
            this.btnSalvar.Size = new System.Drawing.Size(104, 23);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click_1);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Depth = 0;
            this.btnBuscar.Location = new System.Drawing.Point(12, 257);
            this.btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Primary = true;
            this.btnBuscar.Size = new System.Drawing.Size(104, 22);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Depth = 0;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(357, 257);
            this.btnExcluir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Primary = true;
            this.btnExcluir.Size = new System.Drawing.Size(104, 23);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.TabStop = false;
            this.btnExcluir.Text = "Inativar";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovoUsuario
            // 
            this.btnNovoUsuario.Depth = 0;
            this.btnNovoUsuario.Location = new System.Drawing.Point(242, 257);
            this.btnNovoUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNovoUsuario.Name = "btnNovoUsuario";
            this.btnNovoUsuario.Primary = true;
            this.btnNovoUsuario.Size = new System.Drawing.Size(104, 23);
            this.btnNovoUsuario.TabIndex = 7;
            this.btnNovoUsuario.TabStop = false;
            this.btnNovoUsuario.Text = "Novo";
            this.btnNovoUsuario.UseVisualStyleBackColor = true;
            this.btnNovoUsuario.Click += new System.EventHandler(this.btnNovoUsuario_Click);
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.Depth = 0;
            this.txtConfirmarSenha.Hint = "Senha";
            this.txtConfirmarSenha.Location = new System.Drawing.Point(231, 176);
            this.txtConfirmarSenha.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.PasswordChar = '*';
            this.txtConfirmarSenha.SelectedText = "";
            this.txtConfirmarSenha.SelectionLength = 0;
            this.txtConfirmarSenha.SelectionStart = 0;
            this.txtConfirmarSenha.Size = new System.Drawing.Size(230, 23);
            this.txtConfirmarSenha.TabIndex = 501;
            this.txtConfirmarSenha.TabStop = false;
            this.txtConfirmarSenha.UseSystemPasswordChar = false;
            this.txtConfirmarSenha.Leave += new System.EventHandler(this.txtConfirmarSenha_Leave);
            // 
            // lblConfirmarSenha
            // 
            this.lblConfirmarSenha.AutoSize = true;
            this.lblConfirmarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblConfirmarSenha.Location = new System.Drawing.Point(178, 158);
            this.lblConfirmarSenha.Name = "lblConfirmarSenha";
            this.lblConfirmarSenha.Size = new System.Drawing.Size(0, 13);
            this.lblConfirmarSenha.TabIndex = 502;
            // 
            // checkBoxSenha
            // 
            this.checkBoxSenha.AutoSize = true;
            this.checkBoxSenha.Depth = 0;
            this.checkBoxSenha.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkBoxSenha.Location = new System.Drawing.Point(278, 214);
            this.checkBoxSenha.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxSenha.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxSenha.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxSenha.Name = "checkBoxSenha";
            this.checkBoxSenha.Ripple = true;
            this.checkBoxSenha.Size = new System.Drawing.Size(183, 30);
            this.checkBoxSenha.TabIndex = 801;
            this.checkBoxSenha.TabStop = false;
            this.checkBoxSenha.Text = "Mostrar/Esconder Senha";
            this.checkBoxSenha.UseVisualStyleBackColor = true;
            this.checkBoxSenha.CheckedChanged += new System.EventHandler(this.materialCheckBox1_CheckedChanged);
            // 
            // FrmCadUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 544);
            this.Controls.Add(this.checkBoxSenha);
            this.Controls.Add(this.lblConfirmarSenha);
            this.Controls.Add(this.txtConfirmarSenha);
            this.Controls.Add(this.btnNovoUsuario);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.listView);
            this.Name = "FrmCadUsuario";
            this.Text = "Cadastro de Usuário";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnH;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblid;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNome;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsuario;
        private MaterialSkin.Controls.MaterialCheckBox checkBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSenha;
        private MaterialSkin.Controls.MaterialRaisedButton btnSalvar;
        private MaterialSkin.Controls.MaterialRaisedButton btnBuscar;
        private MaterialSkin.Controls.MaterialRaisedButton btnExcluir;
        private MaterialSkin.Controls.MaterialRaisedButton btnNovoUsuario;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtConfirmarSenha;
        private System.Windows.Forms.Label lblConfirmarSenha;
        private MaterialSkin.Controls.MaterialCheckBox checkBoxSenha;
    }
}