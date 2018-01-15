namespace DoaNotaPR
{
    partial class Settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.cbSalvarSenha = new System.Windows.Forms.CheckBox();
            this.tbCPF = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCNPJEntidade = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.gbBuscaEntidade = new System.Windows.Forms.GroupBox();
            this.pbCarregando = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbEntidades = new System.Windows.Forms.ListBox();
            this.btnBuscarInstituicao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBuscaInstituicao = new System.Windows.Forms.TextBox();
            this.gbConfiguracoes = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbNomeEntidade = new System.Windows.Forms.TextBox();
            this.gbEntidade = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pbCarregandoLogin = new System.Windows.Forms.PictureBox();
            this.pnlEspera = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.gbLogin.SuspendLayout();
            this.gbBuscaEntidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarregando)).BeginInit();
            this.gbConfiguracoes.SuspendLayout();
            this.gbEntidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarregandoLogin)).BeginInit();
            this.pnlEspera.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.tbPass);
            this.gbLogin.Controls.Add(this.cbSalvarSenha);
            this.gbLogin.Controls.Add(this.tbCPF);
            this.gbLogin.Controls.Add(this.label5);
            this.gbLogin.Controls.Add(this.label6);
            this.gbLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbLogin.Location = new System.Drawing.Point(284, 191);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(223, 109);
            this.gbLogin.TabIndex = 29;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Login Nota Paraná";
            // 
            // tbPass
            // 
            this.tbPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbPass.Location = new System.Drawing.Point(71, 53);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(136, 22);
            this.tbPass.TabIndex = 19;
            this.tbPass.TextChanged += new System.EventHandler(this.tbPass_TextChanged);
            // 
            // cbSalvarSenha
            // 
            this.cbSalvarSenha.AutoSize = true;
            this.cbSalvarSenha.Checked = true;
            this.cbSalvarSenha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSalvarSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSalvarSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSalvarSenha.Location = new System.Drawing.Point(120, 81);
            this.cbSalvarSenha.Name = "cbSalvarSenha";
            this.cbSalvarSenha.Size = new System.Drawing.Size(87, 17);
            this.cbSalvarSenha.TabIndex = 25;
            this.cbSalvarSenha.Text = "Salvar senha";
            this.cbSalvarSenha.UseVisualStyleBackColor = true;
            this.cbSalvarSenha.CheckedChanged += new System.EventHandler(this.cbSalvarSenha_CheckedChanged);
            // 
            // tbCPF
            // 
            this.tbCPF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCPF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbCPF.Location = new System.Drawing.Point(71, 26);
            this.tbCPF.Name = "tbCPF";
            this.tbCPF.Size = new System.Drawing.Size(136, 22);
            this.tbCPF.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(15, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Usuário:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(23, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Senha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(14, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "CNPJ:";
            this.label7.DoubleClick += new System.EventHandler(this.label7_DoubleClick);
            // 
            // tbCNPJEntidade
            // 
            this.tbCNPJEntidade.BackColor = System.Drawing.SystemColors.Control;
            this.tbCNPJEntidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCNPJEntidade.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCNPJEntidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbCNPJEntidade.Location = new System.Drawing.Point(57, 26);
            this.tbCNPJEntidade.Name = "tbCNPJEntidade";
            this.tbCNPJEntidade.ReadOnly = true;
            this.tbCNPJEntidade.Size = new System.Drawing.Size(189, 22);
            this.tbCNPJEntidade.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(91)))), ((int)(((byte)(199)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(658, 312);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(89, 25);
            this.btnSalvar.TabIndex = 30;
            this.btnSalvar.Text = "Ok";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.button13_Click);
            // 
            // gbBuscaEntidade
            // 
            this.gbBuscaEntidade.Controls.Add(this.pbCarregando);
            this.gbBuscaEntidade.Controls.Add(this.groupBox3);
            this.gbBuscaEntidade.Controls.Add(this.lbEntidades);
            this.gbBuscaEntidade.Controls.Add(this.btnBuscarInstituicao);
            this.gbBuscaEntidade.Controls.Add(this.label1);
            this.gbBuscaEntidade.Controls.Add(this.tbBuscaInstituicao);
            this.gbBuscaEntidade.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBuscaEntidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbBuscaEntidade.Location = new System.Drawing.Point(18, 10);
            this.gbBuscaEntidade.Name = "gbBuscaEntidade";
            this.gbBuscaEntidade.Size = new System.Drawing.Size(729, 175);
            this.gbBuscaEntidade.TabIndex = 31;
            this.gbBuscaEntidade.TabStop = false;
            this.gbBuscaEntidade.Text = "Busca Entidade";
            // 
            // pbCarregando
            // 
            this.pbCarregando.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbCarregando.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCarregando.Location = new System.Drawing.Point(327, 76);
            this.pbCarregando.Name = "pbCarregando";
            this.pbCarregando.Size = new System.Drawing.Size(48, 51);
            this.pbCarregando.TabIndex = 34;
            this.pbCarregando.TabStop = false;
            this.pbCarregando.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(207, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // lbEntidades
            // 
            this.lbEntidades.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbEntidades.FormattingEnabled = true;
            this.lbEntidades.Location = new System.Drawing.Point(24, 48);
            this.lbEntidades.Name = "lbEntidades";
            this.lbEntidades.Size = new System.Drawing.Size(685, 108);
            this.lbEntidades.TabIndex = 3;
            this.lbEntidades.SelectedIndexChanged += new System.EventHandler(this.lbEntidades_SelectedIndexChanged);
            this.lbEntidades.SelectedValueChanged += new System.EventHandler(this.lbEntidades_SelectedValueChanged);
            this.lbEntidades.Enter += new System.EventHandler(this.lbEntidades_Enter);
            this.lbEntidades.MouseEnter += new System.EventHandler(this.lbEntidades_MouseEnter);
            // 
            // btnBuscarInstituicao
            // 
            this.btnBuscarInstituicao.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarInstituicao.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_magnifying_glass_4x;
            this.btnBuscarInstituicao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarInstituicao.FlatAppearance.BorderSize = 0;
            this.btnBuscarInstituicao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBuscarInstituicao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBuscarInstituicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarInstituicao.Location = new System.Drawing.Point(300, 22);
            this.btnBuscarInstituicao.Name = "btnBuscarInstituicao";
            this.btnBuscarInstituicao.Size = new System.Drawing.Size(18, 18);
            this.btnBuscarInstituicao.TabIndex = 2;
            this.btnBuscarInstituicao.UseVisualStyleBackColor = false;
            this.btnBuscarInstituicao.Click += new System.EventHandler(this.btnBuscarInstituicao_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Busca:";
            // 
            // tbBuscaInstituicao
            // 
            this.tbBuscaInstituicao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbBuscaInstituicao.Location = new System.Drawing.Point(65, 22);
            this.tbBuscaInstituicao.Name = "tbBuscaInstituicao";
            this.tbBuscaInstituicao.Size = new System.Drawing.Size(229, 22);
            this.tbBuscaInstituicao.TabIndex = 0;
            this.tbBuscaInstituicao.Enter += new System.EventHandler(this.tbBuscaInstituicao_Enter);
            this.tbBuscaInstituicao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBuscaInstituicao_KeyDown);
            this.tbBuscaInstituicao.MouseEnter += new System.EventHandler(this.tbBuscaInstituicao_MouseEnter);
            // 
            // gbConfiguracoes
            // 
            this.gbConfiguracoes.Controls.Add(this.comboBox1);
            this.gbConfiguracoes.Location = new System.Drawing.Point(513, 191);
            this.gbConfiguracoes.Name = "gbConfiguracoes";
            this.gbConfiguracoes.Size = new System.Drawing.Size(234, 109);
            this.gbConfiguracoes.TabIndex = 37;
            this.gbConfiguracoes.TabStop = false;
            this.gbConfiguracoes.Text = "Configurações de envio";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Enviar todas as notas. (Recomendado)",
            "Não enviar notas expiradas."});
            this.comboBox1.Location = new System.Drawing.Point(13, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Não enviar notas com mais de 30 dias.";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tbNomeEntidade
            // 
            this.tbNomeEntidade.BackColor = System.Drawing.SystemColors.Control;
            this.tbNomeEntidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNomeEntidade.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNomeEntidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbNomeEntidade.Location = new System.Drawing.Point(57, 52);
            this.tbNomeEntidade.Name = "tbNomeEntidade";
            this.tbNomeEntidade.ReadOnly = true;
            this.tbNomeEntidade.Size = new System.Drawing.Size(189, 22);
            this.tbNomeEntidade.TabIndex = 32;
            // 
            // gbEntidade
            // 
            this.gbEntidade.Controls.Add(this.label2);
            this.gbEntidade.Controls.Add(this.tbNomeEntidade);
            this.gbEntidade.Controls.Add(this.label7);
            this.gbEntidade.Controls.Add(this.tbCNPJEntidade);
            this.gbEntidade.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEntidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbEntidade.Location = new System.Drawing.Point(18, 191);
            this.gbEntidade.Name = "gbEntidade";
            this.gbEntidade.Size = new System.Drawing.Size(260, 109);
            this.gbEntidade.TabIndex = 33;
            this.gbEntidade.TabStop = false;
            this.gbEntidade.Text = "Entidade Configurada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Nome:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(28)))), ((int)(((byte)(95)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(562, 312);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pbCarregandoLogin
            // 
            this.pbCarregandoLogin.BackColor = System.Drawing.Color.Transparent;
            this.pbCarregandoLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCarregandoLogin.Location = new System.Drawing.Point(76, 12);
            this.pbCarregandoLogin.Name = "pbCarregandoLogin";
            this.pbCarregandoLogin.Size = new System.Drawing.Size(48, 51);
            this.pbCarregandoLogin.TabIndex = 35;
            this.pbCarregandoLogin.TabStop = false;
            // 
            // pnlEspera
            // 
            this.pnlEspera.BackColor = System.Drawing.Color.White;
            this.pnlEspera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEspera.Controls.Add(this.label3);
            this.pnlEspera.Controls.Add(this.pbCarregandoLogin);
            this.pnlEspera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlEspera.Location = new System.Drawing.Point(268, 127);
            this.pnlEspera.Name = "pnlEspera";
            this.pnlEspera.Size = new System.Drawing.Size(200, 100);
            this.pnlEspera.TabIndex = 39;
            this.pnlEspera.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "Aguarde....";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlEspera);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gbConfiguracoes);
            this.Controls.Add(this.gbEntidade);
            this.Controls.Add(this.gbBuscaEntidade);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gbLogin);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(761, 356);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.VisibleChanged += new System.EventHandler(this.Settings_VisibleChanged);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbBuscaEntidade.ResumeLayout(false);
            this.gbBuscaEntidade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarregando)).EndInit();
            this.gbConfiguracoes.ResumeLayout(false);
            this.gbEntidade.ResumeLayout(false);
            this.gbEntidade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarregandoLogin)).EndInit();
            this.pnlEspera.ResumeLayout(false);
            this.pnlEspera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCNPJEntidade;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.CheckBox cbSalvarSenha;
        private System.Windows.Forms.TextBox tbCPF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox gbBuscaEntidade;
        private System.Windows.Forms.Button btnBuscarInstituicao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBuscaInstituicao;
        private System.Windows.Forms.ListBox lbEntidades;
        private System.Windows.Forms.TextBox tbNomeEntidade;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbEntidade;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbCarregando;
        private System.Windows.Forms.GroupBox gbConfiguracoes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pbCarregandoLogin;
        private System.Windows.Forms.Panel pnlEspera;
        private System.Windows.Forms.Label label3;
    }
}
