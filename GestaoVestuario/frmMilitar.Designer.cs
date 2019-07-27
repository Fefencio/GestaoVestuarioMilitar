namespace GestaoVestuario
{
    partial class frmMilitar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMilitar));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSelecionarNumero = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBIFiltro = new System.Windows.Forms.TextBox();
            this.dtpDataNascimentoFiltro = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeFiltro = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.txtBI = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cbNumero = new System.Windows.Forms.ComboBox();
            this.btnCancelarNumero = new System.Windows.Forms.Button();
            this.btnSalvarNumero = new System.Windows.Forms.Button();
            this.dgvListaNumero = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Farda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vestuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.cbVestuario = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbFarda = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbMilitar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditarNumero = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumero)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalvar.Location = new System.Drawing.Point(283, 1);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 32);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSelecionarNumero);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.dgvLista);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(744, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lista de Militares";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSelecionarNumero
            // 
            this.btnSelecionarNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelecionarNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionarNumero.Location = new System.Drawing.Point(532, 67);
            this.btnSelecionarNumero.Name = "btnSelecionarNumero";
            this.btnSelecionarNumero.Size = new System.Drawing.Size(94, 30);
            this.btnSelecionarNumero.TabIndex = 3;
            this.btnSelecionarNumero.Text = "Números";
            this.btnSelecionarNumero.UseVisualStyleBackColor = true;
            this.btnSelecionarNumero.Click += new System.EventHandler(this.btnSelecionarNumero_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.txtBIFiltro);
            this.groupBox1.Controls.Add(this.dtpDataNascimentoFiltro);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNomeFiltro);
            this.groupBox1.Location = new System.Drawing.Point(32, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Conteúdo";
            // 
            // txtBIFiltro
            // 
            this.txtBIFiltro.Location = new System.Drawing.Point(297, 24);
            this.txtBIFiltro.Name = "txtBIFiltro";
            this.txtBIFiltro.Size = new System.Drawing.Size(152, 25);
            this.txtBIFiltro.TabIndex = 8;
            this.txtBIFiltro.TextChanged += new System.EventHandler(this.txtBIFiltro_TextChanged);
            // 
            // dtpDataNascimentoFiltro
            // 
            this.dtpDataNascimentoFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNascimentoFiltro.Location = new System.Drawing.Point(570, 24);
            this.dtpDataNascimentoFiltro.Name = "dtpDataNascimentoFiltro";
            this.dtpDataNascimentoFiltro.Size = new System.Drawing.Size(102, 25);
            this.dtpDataNascimentoFiltro.TabIndex = 5;
            this.dtpDataNascimentoFiltro.ValueChanged += new System.EventHandler(this.dtpDataNascimentoFiltro_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data de Nasc.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "B.I. nº";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome";
            // 
            // txtNomeFiltro
            // 
            this.txtNomeFiltro.Location = new System.Drawing.Point(74, 24);
            this.txtNomeFiltro.Name = "txtNomeFiltro";
            this.txtNomeFiltro.Size = new System.Drawing.Size(152, 25);
            this.txtNomeFiltro.TabIndex = 0;
            this.txtNomeFiltro.TextChanged += new System.EventHandler(this.txtNomeFiltro_TextChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(644, 67);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(94, 30);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir Lista";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(6, 103);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.Size = new System.Drawing.Size(732, 247);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.DoubleClick += new System.EventHandler(this.dgvLista_DoubleClick);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditar.Location = new System.Drawing.Point(142, 1);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 32);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(424, 1);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 32);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Data de Nasc.";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "B.I. nº";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nome";
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNascimento.Location = new System.Drawing.Point(197, 110);
            this.dtpDataNascimento.Name = "dtpDataNascimento";
            this.dtpDataNascimento.Size = new System.Drawing.Size(133, 25);
            this.dtpDataNascimento.TabIndex = 7;
            // 
            // txtBI
            // 
            this.txtBI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBI.Location = new System.Drawing.Point(390, 109);
            this.txtBI.MaxLength = 256;
            this.txtBI.Name = "txtBI";
            this.txtBI.Size = new System.Drawing.Size(189, 25);
            this.txtBI.TabIndex = 6;
            // 
            // txtNome
            // 
            this.txtNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNome.Location = new System.Drawing.Point(195, 67);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(384, 25);
            this.txtNome.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnNovo);
            this.panel1.Location = new System.Drawing.Point(113, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 34);
            this.panel1.TabIndex = 4;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNovo.Location = new System.Drawing.Point(2, 1);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 32);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtEmail);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtMorada);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtTelefone);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dtpDataNascimento);
            this.tabPage2.Controls.Add(this.txtBI);
            this.tabPage2.Controls.Add(this.txtNome);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(744, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manutenção de Militares";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(336, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Location = new System.Drawing.Point(390, 152);
            this.txtEmail.MaxLength = 256;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(189, 25);
            this.txtEmail.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(121, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Endereço";
            // 
            // txtMorada
            // 
            this.txtMorada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMorada.Location = new System.Drawing.Point(195, 195);
            this.txtMorada.MaxLength = 256;
            this.txtMorada.Multiline = true;
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(384, 56);
            this.txtMorada.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(126, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Telefone";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTelefone.Location = new System.Drawing.Point(195, 152);
            this.txtTelefone.MaxLength = 256;
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(135, 25);
            this.txtTelefone.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(8, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(752, 387);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnEditarNumero);
            this.tabPage3.Controls.Add(this.btnRemove);
            this.tabPage3.Controls.Add(this.btnAdd);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.cbNumero);
            this.tabPage3.Controls.Add(this.btnCancelarNumero);
            this.tabPage3.Controls.Add(this.btnSalvarNumero);
            this.tabPage3.Controls.Add(this.dgvListaNumero);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.cbVestuario);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.cbFarda);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.cbMilitar);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(744, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Núméros de Vestuarios";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRemove.Location = new System.Drawing.Point(586, 144);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(49, 26);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Rem";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.Location = new System.Drawing.Point(476, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 26);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(219, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 19);
            this.label14.TabIndex = 10;
            this.label14.Text = "Número";
            // 
            // cbNumero
            // 
            this.cbNumero.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbNumero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNumero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNumero.Enabled = false;
            this.cbNumero.FormattingEnabled = true;
            this.cbNumero.Location = new System.Drawing.Point(284, 145);
            this.cbNumero.Name = "cbNumero";
            this.cbNumero.Size = new System.Drawing.Size(184, 26);
            this.cbNumero.Sorted = true;
            this.cbNumero.TabIndex = 9;
            // 
            // btnCancelarNumero
            // 
            this.btnCancelarNumero.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelarNumero.Location = new System.Drawing.Point(387, 298);
            this.btnCancelarNumero.Name = "btnCancelarNumero";
            this.btnCancelarNumero.Size = new System.Drawing.Size(100, 32);
            this.btnCancelarNumero.TabIndex = 8;
            this.btnCancelarNumero.Text = "Cancelar";
            this.btnCancelarNumero.UseVisualStyleBackColor = true;
            // 
            // btnSalvarNumero
            // 
            this.btnSalvarNumero.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalvarNumero.Location = new System.Drawing.Point(246, 298);
            this.btnSalvarNumero.Name = "btnSalvarNumero";
            this.btnSalvarNumero.Size = new System.Drawing.Size(100, 32);
            this.btnSalvarNumero.TabIndex = 7;
            this.btnSalvarNumero.Text = "Salvar";
            this.btnSalvarNumero.UseVisualStyleBackColor = true;
            // 
            // dgvListaNumero
            // 
            this.dgvListaNumero.AllowUserToAddRows = false;
            this.dgvListaNumero.AllowUserToDeleteRows = false;
            this.dgvListaNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvListaNumero.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaNumero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaNumero.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Farda,
            this.Vestuario,
            this.Numero});
            this.dgvListaNumero.Location = new System.Drawing.Point(87, 191);
            this.dgvListaNumero.Name = "dgvListaNumero";
            this.dgvListaNumero.ReadOnly = true;
            this.dgvListaNumero.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaNumero.Size = new System.Drawing.Size(579, 64);
            this.dgvListaNumero.TabIndex = 6;
            this.dgvListaNumero.DoubleClick += new System.EventHandler(this.dgvListaNumero_DoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Farda
            // 
            this.Farda.HeaderText = "Farda";
            this.Farda.Name = "Farda";
            this.Farda.ReadOnly = true;
            // 
            // Vestuario
            // 
            this.Vestuario.HeaderText = "Vestuario";
            this.Vestuario.Name = "Vestuario";
            this.Vestuario.ReadOnly = true;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(356, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 19);
            this.label13.TabIndex = 5;
            this.label13.Text = "Vestuario";
            // 
            // cbVestuario
            // 
            this.cbVestuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbVestuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbVestuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbVestuario.Enabled = false;
            this.cbVestuario.FormattingEnabled = true;
            this.cbVestuario.Location = new System.Drawing.Point(431, 100);
            this.cbVestuario.Name = "cbVestuario";
            this.cbVestuario.Size = new System.Drawing.Size(184, 26);
            this.cbVestuario.Sorted = true;
            this.cbVestuario.TabIndex = 4;
            this.cbVestuario.SelectedIndexChanged += new System.EventHandler(this.cbVestuario_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(92, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 19);
            this.label12.TabIndex = 3;
            this.label12.Text = "Farda";
            // 
            // cbFarda
            // 
            this.cbFarda.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbFarda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFarda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFarda.Enabled = false;
            this.cbFarda.FormattingEnabled = true;
            this.cbFarda.Location = new System.Drawing.Point(145, 100);
            this.cbFarda.Name = "cbFarda";
            this.cbFarda.Size = new System.Drawing.Size(184, 26);
            this.cbFarda.Sorted = true;
            this.cbFarda.TabIndex = 2;
            this.cbFarda.SelectedIndexChanged += new System.EventHandler(this.cbFarda_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(212, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "Militar";
            // 
            // cbMilitar
            // 
            this.cbMilitar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbMilitar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMilitar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMilitar.FormattingEnabled = true;
            this.cbMilitar.Location = new System.Drawing.Point(265, 40);
            this.cbMilitar.Name = "cbMilitar";
            this.cbMilitar.Size = new System.Drawing.Size(222, 26);
            this.cbMilitar.Sorted = true;
            this.cbMilitar.TabIndex = 0;
            this.cbMilitar.SelectedIndexChanged += new System.EventHandler(this.cbMilitar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestão de Militares";
            // 
            // btnEditarNumero
            // 
            this.btnEditarNumero.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditarNumero.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnEditarNumero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarNumero.Font = new System.Drawing.Font("Arial Unicode MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarNumero.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnEditarNumero.Location = new System.Drawing.Point(531, 144);
            this.btnEditarNumero.Name = "btnEditarNumero";
            this.btnEditarNumero.Size = new System.Drawing.Size(49, 26);
            this.btnEditarNumero.TabIndex = 17;
            this.btnEditarNumero.Text = "Edit";
            this.btnEditarNumero.UseVisualStyleBackColor = true;
            this.btnEditarNumero.Click += new System.EventHandler(this.btnEditarNumero_Click);
            // 
            // frmMilitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMilitar";
            this.ShowIcon = false;
            this.Text = "frmMilitar";
            this.Shown += new System.EventHandler(this.frmMilitar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaNumero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDataNascimentoFiltro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeFiltro;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDataNascimento;
        private System.Windows.Forms.TextBox txtBI;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtBIFiltro;
        private System.Windows.Forms.Button btnSelecionarNumero;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnCancelarNumero;
        private System.Windows.Forms.Button btnSalvarNumero;
        private System.Windows.Forms.DataGridView dgvListaNumero;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbVestuario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbFarda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbMilitar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbNumero;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Farda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vestuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.Button btnEditarNumero;
    }
}