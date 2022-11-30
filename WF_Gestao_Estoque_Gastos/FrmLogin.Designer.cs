namespace WF_Gestao_Estoque_Gastos
{
    partial class FrmLogin
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
            this.txtUsuario = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtSenha = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnEntrar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Depth = 0;
            this.txtUsuario.Hint = "Usuário";
            this.txtUsuario.Location = new System.Drawing.Point(121, 165);
            this.txtUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.Size = new System.Drawing.Size(281, 23);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.UseSystemPasswordChar = false;
            // 
            // txtSenha
            // 
            this.txtSenha.Depth = 0;
            this.txtSenha.Hint = "************************";
            this.txtSenha.Location = new System.Drawing.Point(121, 219);
            this.txtSenha.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '\0';
            this.txtSenha.SelectedText = "";
            this.txtSenha.SelectionLength = 0;
            this.txtSenha.SelectionStart = 0;
            this.txtSenha.Size = new System.Drawing.Size(281, 23);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.UseSystemPasswordChar = false;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Depth = 0;
            this.btnEntrar.Location = new System.Drawing.Point(327, 259);
            this.btnEntrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Primary = true;
            this.btnEntrar.Size = new System.Drawing.Size(75, 23);
            this.btnEntrar.TabIndex = 2;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Depth = 0;
            this.btnCancelar.Location = new System.Drawing.Point(237, 259);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Primary = true;
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsuario;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSenha;
        private MaterialSkin.Controls.MaterialRaisedButton btnEntrar;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancelar;
    }
}