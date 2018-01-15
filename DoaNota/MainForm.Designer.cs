namespace DoaNotaPR
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMostrarGrid = new System.Windows.Forms.Button();
            this.lblNotasPendentes = new System.Windows.Forms.Label();
            this.btnLigarDesligarEnvio = new System.Windows.Forms.Button();
            this.lblPendentesTxt = new System.Windows.Forms.Label();
            this.lblNotasEnviadas = new System.Windows.Forms.Label();
            this.lblSucessoTxt = new System.Windows.Forms.Label();
            this.lblTotalNotas = new System.Windows.Forms.Label();
            this.lblQtdTotalTxt = new System.Windows.Forms.Label();
            this.configbtn = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gridScreen1 = new DoaNotaPR.UserControls.GridScreen();
            this.settings1 = new DoaNotaPR.Settings();
            this.cameraScreen1 = new DoaNotaPR.CameraScreen();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMostrarGrid);
            this.panel2.Controls.Add(this.lblNotasPendentes);
            this.panel2.Controls.Add(this.btnLigarDesligarEnvio);
            this.panel2.Controls.Add(this.lblPendentesTxt);
            this.panel2.Controls.Add(this.lblNotasEnviadas);
            this.panel2.Controls.Add(this.lblSucessoTxt);
            this.panel2.Controls.Add(this.lblTotalNotas);
            this.panel2.Controls.Add(this.lblQtdTotalTxt);
            this.panel2.Location = new System.Drawing.Point(4, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(761, 41);
            this.panel2.TabIndex = 31;
            // 
            // btnMostrarGrid
            // 
            this.btnMostrarGrid.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarGrid.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_spreadsheet_4x;
            this.btnMostrarGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMostrarGrid.FlatAppearance.BorderSize = 0;
            this.btnMostrarGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarGrid.Location = new System.Drawing.Point(662, 5);
            this.btnMostrarGrid.Name = "btnMostrarGrid";
            this.btnMostrarGrid.Size = new System.Drawing.Size(33, 32);
            this.btnMostrarGrid.TabIndex = 30;
            this.btnMostrarGrid.UseVisualStyleBackColor = false;
            this.btnMostrarGrid.Click += new System.EventHandler(this.btnMostrarGrid_Click);
            // 
            // lblNotasPendentes
            // 
            this.lblNotasPendentes.AutoSize = true;
            this.lblNotasPendentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotasPendentes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblNotasPendentes.Location = new System.Drawing.Point(561, 7);
            this.lblNotasPendentes.Name = "lblNotasPendentes";
            this.lblNotasPendentes.Size = new System.Drawing.Size(70, 24);
            this.lblNotasPendentes.TabIndex = 5;
            this.lblNotasPendentes.Text = "100000";
            // 
            // btnLigarDesligarEnvio
            // 
            this.btnLigarDesligarEnvio.BackColor = System.Drawing.Color.Transparent;
            this.btnLigarDesligarEnvio.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_cloud_disconnect_4x;
            this.btnLigarDesligarEnvio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLigarDesligarEnvio.FlatAppearance.BorderSize = 0;
            this.btnLigarDesligarEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLigarDesligarEnvio.ForeColor = System.Drawing.Color.Transparent;
            this.btnLigarDesligarEnvio.Location = new System.Drawing.Point(709, 5);
            this.btnLigarDesligarEnvio.Name = "btnLigarDesligarEnvio";
            this.btnLigarDesligarEnvio.Size = new System.Drawing.Size(37, 32);
            this.btnLigarDesligarEnvio.TabIndex = 29;
            this.btnLigarDesligarEnvio.UseVisualStyleBackColor = false;
            this.btnLigarDesligarEnvio.Click += new System.EventHandler(this.btnLigarDesligarEnvio_Click);
            // 
            // lblPendentesTxt
            // 
            this.lblPendentesTxt.AutoSize = true;
            this.lblPendentesTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendentesTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblPendentesTxt.Location = new System.Drawing.Point(451, 7);
            this.lblPendentesTxt.Name = "lblPendentesTxt";
            this.lblPendentesTxt.Size = new System.Drawing.Size(106, 24);
            this.lblPendentesTxt.TabIndex = 4;
            this.lblPendentesTxt.Text = "Pendentes:";
            // 
            // lblNotasEnviadas
            // 
            this.lblNotasEnviadas.AutoSize = true;
            this.lblNotasEnviadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotasEnviadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.lblNotasEnviadas.Location = new System.Drawing.Point(336, 7);
            this.lblNotasEnviadas.Name = "lblNotasEnviadas";
            this.lblNotasEnviadas.Size = new System.Drawing.Size(70, 24);
            this.lblNotasEnviadas.TabIndex = 3;
            this.lblNotasEnviadas.Text = "100000";
            // 
            // lblSucessoTxt
            // 
            this.lblSucessoTxt.AutoSize = true;
            this.lblSucessoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucessoTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.lblSucessoTxt.Location = new System.Drawing.Point(237, 7);
            this.lblSucessoTxt.Name = "lblSucessoTxt";
            this.lblSucessoTxt.Size = new System.Drawing.Size(79, 24);
            this.lblSucessoTxt.TabIndex = 2;
            this.lblSucessoTxt.Text = "Doadas:";
            // 
            // lblTotalNotas
            // 
            this.lblTotalNotas.AutoSize = true;
            this.lblTotalNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            this.lblTotalNotas.Location = new System.Drawing.Point(106, 7);
            this.lblTotalNotas.Name = "lblTotalNotas";
            this.lblTotalNotas.Size = new System.Drawing.Size(70, 24);
            this.lblTotalNotas.TabIndex = 1;
            this.lblTotalNotas.Text = "100000";
            // 
            // lblQtdTotalTxt
            // 
            this.lblQtdTotalTxt.AutoSize = true;
            this.lblQtdTotalTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdTotalTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(40)))));
            this.lblQtdTotalTxt.Location = new System.Drawing.Point(12, 7);
            this.lblQtdTotalTxt.Name = "lblQtdTotalTxt";
            this.lblQtdTotalTxt.Size = new System.Drawing.Size(91, 24);
            this.lblQtdTotalTxt.TabIndex = 0;
            this.lblQtdTotalTxt.Text = "Qtd Total:";
            // 
            // configbtn
            // 
            this.configbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(66)))), ((int)(((byte)(79)))));
            this.configbtn.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_setting_4x;
            this.configbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.configbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.configbtn.FlatAppearance.BorderSize = 0;
            this.configbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.configbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.configbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.configbtn.ForeColor = System.Drawing.Color.White;
            this.configbtn.Location = new System.Drawing.Point(710, 12);
            this.configbtn.Name = "configbtn";
            this.configbtn.Size = new System.Drawing.Size(15, 15);
            this.configbtn.TabIndex = 35;
            this.configbtn.UseVisualStyleBackColor = false;
            this.configbtn.Click += new System.EventHandler(this.configbtn_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_close_4x;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(735, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(15, 15);
            this.btnClose.TabIndex = 34;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::DoaNotaPR.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(4, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 45);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // gridScreen1
            // 
            this.gridScreen1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridScreen1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridScreen1.Location = new System.Drawing.Point(4, 57);
            this.gridScreen1.Name = "gridScreen1";
            this.gridScreen1.Size = new System.Drawing.Size(761, 405);
            this.gridScreen1.TabIndex = 38;
            this.gridScreen1.Visible = false;
            this.gridScreen1.Load += new System.EventHandler(this.gridScreen1_Load);
            this.gridScreen1.DoubleClick += new System.EventHandler(this.gridScreen1_DoubleClick);
            // 
            // settings1
            // 
            this.settings1.Location = new System.Drawing.Point(4, 102);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(761, 356);
            this.settings1.TabIndex = 37;
            this.settings1.Visible = false;
            this.settings1.VisibleChanged += new System.EventHandler(this.settings1_VisibleChanged);
            // 
            // cameraScreen1
            // 
            this.cameraScreen1.Location = new System.Drawing.Point(4, 102);
            this.cameraScreen1.Name = "cameraScreen1";
            this.cameraScreen1.Size = new System.Drawing.Size(761, 356);
            this.cameraScreen1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoaNotaPR.Properties.Resources.doa_nota2;
            this.ClientSize = new System.Drawing.Size(770, 467);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gridScreen1);
            this.Controls.Add(this.settings1);
            this.Controls.Add(this.configbtn);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cameraScreen1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doa Nota Paraná";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CameraScreen cameraScreen1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMostrarGrid;
        private System.Windows.Forms.Label lblNotasPendentes;
        private System.Windows.Forms.Button btnLigarDesligarEnvio;
        private System.Windows.Forms.Label lblPendentesTxt;
        private System.Windows.Forms.Label lblNotasEnviadas;
        private System.Windows.Forms.Label lblSucessoTxt;
        private System.Windows.Forms.Label lblTotalNotas;
        private System.Windows.Forms.Label lblQtdTotalTxt;
    
        private System.Windows.Forms.Button configbtn;
        private System.Windows.Forms.Button btnClose;
        private Settings settings1;
        private UserControls.GridScreen gridScreen1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}