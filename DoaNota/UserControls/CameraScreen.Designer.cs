namespace DoaNotaPR
{
    partial class CameraScreen
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
            this.QRReaderPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbManualInput = new System.Windows.Forms.TextBox();
            this.btnAdicionarNota = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUltimaNotaDataEmitida = new System.Windows.Forms.Label();
            this.lblUltimaValorNota = new System.Windows.Forms.Label();
            this.lblUltimaChave = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEntidadeEscolhida = new System.Windows.Forms.Label();
            this.lblUltimaNotaStatus = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btnInvertY = new System.Windows.Forms.Button();
            this.cameraconfigbtn = new System.Windows.Forms.Button();
            this.btnInvertX = new System.Windows.Forms.Button();
            this.panelMenuCamera = new System.Windows.Forms.Panel();
            this.EscolhaCameraPanel = new System.Windows.Forms.Panel();
            this.btnRefreshCamera = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbResolutions = new System.Windows.Forms.ComboBox();
            this.Start = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxCameraSource = new System.Windows.Forms.ComboBox();
            this.Oklabel = new System.Windows.Forms.Label();
            this.pictureBoxSource = new System.Windows.Forms.PictureBox();
            this.QRReaderPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelMenuCamera.SuspendLayout();
            this.EscolhaCameraPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).BeginInit();
            this.SuspendLayout();
            // 
            // QRReaderPanel
            // 
            this.QRReaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(232)))), ((int)(((byte)(236)))));
            this.QRReaderPanel.Controls.Add(this.panel1);
            this.QRReaderPanel.Controls.Add(this.groupBox3);
            this.QRReaderPanel.Controls.Add(this.groupBox1);
            this.QRReaderPanel.Controls.Add(this.groupBox2);
            this.QRReaderPanel.Controls.Add(this.lblUltimaNotaStatus);
            this.QRReaderPanel.Controls.Add(this.panelMenuCamera);
            this.QRReaderPanel.Controls.Add(this.pictureBoxSource);
            this.QRReaderPanel.Location = new System.Drawing.Point(3, 3);
            this.QRReaderPanel.Name = "QRReaderPanel";
            this.QRReaderPanel.Size = new System.Drawing.Size(756, 350);
            this.QRReaderPanel.TabIndex = 24;
            this.QRReaderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.QRReaderPanel_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(66)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnInvertY);
            this.panel1.Controls.Add(this.cameraconfigbtn);
            this.panel1.Controls.Add(this.btnInvertX);
            this.panel1.Location = new System.Drawing.Point(13, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 24);
            this.panel1.TabIndex = 40;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbManualInput);
            this.groupBox3.Controls.Add(this.btnAdicionarNota);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Location = new System.Drawing.Point(365, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 86);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Digite a chave da nota";
            // 
            // tbManualInput
            // 
            this.tbManualInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbManualInput.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbManualInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbManualInput.Location = new System.Drawing.Point(11, 25);
            this.tbManualInput.Name = "tbManualInput";
            this.tbManualInput.Size = new System.Drawing.Size(355, 23);
            this.tbManualInput.TabIndex = 17;
            this.tbManualInput.TextChanged += new System.EventHandler(this.tbManualInput_TextChanged);
            this.tbManualInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbManualInput_KeyDown);
            this.tbManualInput.MouseEnter += new System.EventHandler(this.tbManualInput_MouseEnter);
            // 
            // btnAdicionarNota
            // 
            this.btnAdicionarNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(91)))), ((int)(((byte)(199)))));
            this.btnAdicionarNota.FlatAppearance.BorderSize = 0;
            this.btnAdicionarNota.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnAdicionarNota.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnAdicionarNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarNota.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarNota.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarNota.Location = new System.Drawing.Point(288, 52);
            this.btnAdicionarNota.Name = "btnAdicionarNota";
            this.btnAdicionarNota.Size = new System.Drawing.Size(78, 25);
            this.btnAdicionarNota.TabIndex = 18;
            this.btnAdicionarNota.Text = "Adicionar";
            this.btnAdicionarNota.UseVisualStyleBackColor = false;
            this.btnAdicionarNota.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUltimaNotaDataEmitida);
            this.groupBox1.Controls.Add(this.lblUltimaValorNota);
            this.groupBox1.Controls.Add(this.lblUltimaChave);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(365, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 113);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Última Nota";
            // 
            // lblUltimaNotaDataEmitida
            // 
            this.lblUltimaNotaDataEmitida.AutoSize = true;
            this.lblUltimaNotaDataEmitida.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimaNotaDataEmitida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUltimaNotaDataEmitida.Location = new System.Drawing.Point(207, 65);
            this.lblUltimaNotaDataEmitida.Name = "lblUltimaNotaDataEmitida";
            this.lblUltimaNotaDataEmitida.Size = new System.Drawing.Size(167, 40);
            this.lblUltimaNotaDataEmitida.TabIndex = 2;
            this.lblUltimaNotaDataEmitida.Text = "12/10/2017";
            this.lblUltimaNotaDataEmitida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUltimaValorNota
            // 
            this.lblUltimaValorNota.AutoSize = true;
            this.lblUltimaValorNota.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimaValorNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUltimaValorNota.Location = new System.Drawing.Point(4, 65);
            this.lblUltimaValorNota.Name = "lblUltimaValorNota";
            this.lblUltimaValorNota.Size = new System.Drawing.Size(168, 40);
            this.lblUltimaValorNota.TabIndex = 1;
            this.lblUltimaValorNota.Text = "R$10012.50";
            this.lblUltimaValorNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUltimaChave
            // 
            this.lblUltimaChave.AutoSize = true;
            this.lblUltimaChave.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimaChave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUltimaChave.Location = new System.Drawing.Point(7, 31);
            this.lblUltimaChave.Name = "lblUltimaChave";
            this.lblUltimaChave.Size = new System.Drawing.Size(361, 19);
            this.lblUltimaChave.TabIndex = 0;
            this.lblUltimaChave.Text = "41170377374411000171650010002731361040420590";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEntidadeEscolhida);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(365, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 50);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Você está doando para";
            // 
            // lblEntidadeEscolhida
            // 
            this.lblEntidadeEscolhida.AutoSize = true;
            this.lblEntidadeEscolhida.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntidadeEscolhida.Location = new System.Drawing.Point(6, 21);
            this.lblEntidadeEscolhida.Name = "lblEntidadeEscolhida";
            this.lblEntidadeEscolhida.Size = new System.Drawing.Size(88, 17);
            this.lblEntidadeEscolhida.TabIndex = 0;
            this.lblEntidadeEscolhida.Text = "Amigo animal";
            // 
            // lblUltimaNotaStatus
            // 
            this.lblUltimaNotaStatus.AutoSize = true;
            this.lblUltimaNotaStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblUltimaNotaStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimaNotaStatus.ForeColor = System.Drawing.Color.Red;
            this.lblUltimaNotaStatus.Location = new System.Drawing.Point(15, 327);
            this.lblUltimaNotaStatus.Name = "lblUltimaNotaStatus";
            this.lblUltimaNotaStatus.Size = new System.Drawing.Size(148, 16);
            this.lblUltimaNotaStatus.TabIndex = 8;
            this.lblUltimaNotaStatus.Text = "Mensagem de aviso";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_volume_muted_3x;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(5, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 38;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInvertY
            // 
            this.btnInvertY.BackColor = System.Drawing.Color.Transparent;
            this.btnInvertY.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_updown_4x1;
            this.btnInvertY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInvertY.FlatAppearance.BorderSize = 0;
            this.btnInvertY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvertY.Location = new System.Drawing.Point(294, 1);
            this.btnInvertY.Name = "btnInvertY";
            this.btnInvertY.Size = new System.Drawing.Size(20, 20);
            this.btnInvertY.TabIndex = 21;
            this.btnInvertY.UseVisualStyleBackColor = false;
            this.btnInvertY.Click += new System.EventHandler(this.btnInvertY_Click);
            // 
            // cameraconfigbtn
            // 
            this.cameraconfigbtn.BackColor = System.Drawing.Color.Transparent;
            this.cameraconfigbtn.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_camera_4x;
            this.cameraconfigbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cameraconfigbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cameraconfigbtn.FlatAppearance.BorderSize = 0;
            this.cameraconfigbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cameraconfigbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cameraconfigbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cameraconfigbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraconfigbtn.ForeColor = System.Drawing.Color.White;
            this.cameraconfigbtn.Location = new System.Drawing.Point(320, 4);
            this.cameraconfigbtn.Name = "cameraconfigbtn";
            this.cameraconfigbtn.Size = new System.Drawing.Size(15, 15);
            this.cameraconfigbtn.TabIndex = 37;
            this.cameraconfigbtn.UseVisualStyleBackColor = false;
            this.cameraconfigbtn.Click += new System.EventHandler(this.cameraconfigbtn_Click);
            // 
            // btnInvertX
            // 
            this.btnInvertX.BackColor = System.Drawing.Color.Transparent;
            this.btnInvertX.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_leftright_4x1;
            this.btnInvertX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInvertX.FlatAppearance.BorderSize = 0;
            this.btnInvertX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvertX.Location = new System.Drawing.Point(266, 1);
            this.btnInvertX.Name = "btnInvertX";
            this.btnInvertX.Size = new System.Drawing.Size(20, 20);
            this.btnInvertX.TabIndex = 20;
            this.btnInvertX.UseVisualStyleBackColor = false;
            this.btnInvertX.Click += new System.EventHandler(this.btnInvertX_Click);
            // 
            // panelMenuCamera
            // 
            this.panelMenuCamera.BackColor = System.Drawing.Color.Black;
            this.panelMenuCamera.BackgroundImage = global::DoaNotaPR.Properties.Resources.carregando;
            this.panelMenuCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMenuCamera.Controls.Add(this.EscolhaCameraPanel);
            this.panelMenuCamera.Controls.Add(this.Oklabel);
            this.panelMenuCamera.Location = new System.Drawing.Point(13, 24);
            this.panelMenuCamera.Name = "panelMenuCamera";
            this.panelMenuCamera.Size = new System.Drawing.Size(342, 302);
            this.panelMenuCamera.TabIndex = 16;
            // 
            // EscolhaCameraPanel
            // 
            this.EscolhaCameraPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(223)))));
            this.EscolhaCameraPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EscolhaCameraPanel.Controls.Add(this.btnRefreshCamera);
            this.EscolhaCameraPanel.Controls.Add(this.label1);
            this.EscolhaCameraPanel.Controls.Add(this.cbResolutions);
            this.EscolhaCameraPanel.Controls.Add(this.Start);
            this.EscolhaCameraPanel.Controls.Add(this.label8);
            this.EscolhaCameraPanel.Controls.Add(this.comboBoxCameraSource);
            this.EscolhaCameraPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EscolhaCameraPanel.Location = new System.Drawing.Point(58, 75);
            this.EscolhaCameraPanel.Name = "EscolhaCameraPanel";
            this.EscolhaCameraPanel.Size = new System.Drawing.Size(227, 146);
            this.EscolhaCameraPanel.TabIndex = 7;
            // 
            // btnRefreshCamera
            // 
            this.btnRefreshCamera.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshCamera.BackgroundImage = global::DoaNotaPR.Properties.Resources.icon_refresh_4x;
            this.btnRefreshCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshCamera.FlatAppearance.BorderSize = 0;
            this.btnRefreshCamera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshCamera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshCamera.Location = new System.Drawing.Point(193, 15);
            this.btnRefreshCamera.Name = "btnRefreshCamera";
            this.btnRefreshCamera.Size = new System.Drawing.Size(14, 14);
            this.btnRefreshCamera.TabIndex = 9;
            this.btnRefreshCamera.UseVisualStyleBackColor = false;
            this.btnRefreshCamera.Click += new System.EventHandler(this.btnRefreshCamera_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Configuração:";
            // 
            // cbResolutions
            // 
            this.cbResolutions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbResolutions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbResolutions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbResolutions.FormattingEnabled = true;
            this.cbResolutions.Location = new System.Drawing.Point(17, 75);
            this.cbResolutions.Name = "cbResolutions";
            this.cbResolutions.Size = new System.Drawing.Size(194, 21);
            this.cbResolutions.TabIndex = 7;
            this.cbResolutions.SelectedIndexChanged += new System.EventHandler(this.cbResolutions_SelectedIndexChanged);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(91)))), ((int)(((byte)(199)))));
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.Color.White;
            this.Start.Location = new System.Drawing.Point(136, 105);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 25);
            this.Start.TabIndex = 5;
            this.Start.Text = "Iniciar";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Escolha a camera:";
            // 
            // comboBoxCameraSource
            // 
            this.comboBoxCameraSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCameraSource.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCameraSource.FormattingEnabled = true;
            this.comboBoxCameraSource.Location = new System.Drawing.Point(17, 35);
            this.comboBoxCameraSource.Name = "comboBoxCameraSource";
            this.comboBoxCameraSource.Size = new System.Drawing.Size(194, 21);
            this.comboBoxCameraSource.TabIndex = 3;
            this.comboBoxCameraSource.SelectedIndexChanged += new System.EventHandler(this.comboBoxCameraSource_SelectedIndexChanged);
            // 
            // Oklabel
            // 
            this.Oklabel.AutoSize = true;
            this.Oklabel.BackColor = System.Drawing.Color.Transparent;
            this.Oklabel.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Oklabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(199)))), ((int)(((byte)(42)))));
            this.Oklabel.Location = new System.Drawing.Point(12, 224);
            this.Oklabel.Name = "Oklabel";
            this.Oklabel.Size = new System.Drawing.Size(128, 86);
            this.Oklabel.TabIndex = 14;
            this.Oklabel.Text = "OK";
            this.Oklabel.Visible = false;
            // 
            // pictureBoxSource
            // 
            this.pictureBoxSource.BackColor = System.Drawing.Color.Black;
            this.pictureBoxSource.Location = new System.Drawing.Point(13, 24);
            this.pictureBoxSource.Name = "pictureBoxSource";
            this.pictureBoxSource.Size = new System.Drawing.Size(342, 303);
            this.pictureBoxSource.TabIndex = 4;
            this.pictureBoxSource.TabStop = false;
            this.pictureBoxSource.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxSource_Paint);
            // 
            // CameraScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.QRReaderPanel);
            this.Name = "CameraScreen";
            this.Size = new System.Drawing.Size(761, 356);
            this.Load += new System.EventHandler(this.CameraScreen_Load);
            this.QRReaderPanel.ResumeLayout(false);
            this.QRReaderPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelMenuCamera.ResumeLayout(false);
            this.panelMenuCamera.PerformLayout();
            this.EscolhaCameraPanel.ResumeLayout(false);
            this.EscolhaCameraPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel QRReaderPanel;
        private System.Windows.Forms.Label lblUltimaNotaStatus;
        private System.Windows.Forms.Label lblUltimaNotaDataEmitida;
        private System.Windows.Forms.Label lblUltimaValorNota;
        private System.Windows.Forms.Label lblUltimaChave;
        private System.Windows.Forms.Label Oklabel;
        private System.Windows.Forms.Panel EscolhaCameraPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbResolutions;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCameraSource;
        private System.Windows.Forms.Button btnAdicionarNota;
        private System.Windows.Forms.TextBox tbManualInput;
        private System.Windows.Forms.PictureBox pictureBoxSource;
        private System.Windows.Forms.Button btnInvertY;
        private System.Windows.Forms.Button btnInvertX;
        private System.Windows.Forms.Button cameraconfigbtn;
        private System.Windows.Forms.Panel panelMenuCamera;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblEntidadeEscolhida;
        private System.Windows.Forms.Button btnRefreshCamera;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}
