using System;
using System.Windows.Forms;
using BLL;
using Model;

namespace GestaoVestuario
{
    public partial class frmSerie : Form
    {
        bool isInsert = false;
        bool isUpdate = false;

        Serie serie = new Serie();

        public frmSerie()
        {
            InitializeComponent();
        }

        private void frmSerie_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PrepararForm();
        }

        //Método que define o estado inicial do Formulário
        private void PrepararForm()
        {
            LimparGeral();
            Selecionar(new Serie());
        }

        //Método Hablitar todoso os controles do formulário
        private void HablitarTextBoxs(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.dtpDataInicio.Enabled = valor;
            this.dtpDataFim.Enabled = valor;
            this.txtDescricao.ReadOnly = !valor;
        }

        //Método Hablitar Botons
        private void HablitarBotons()
        {
            if (isInsert || isUpdate)
            {
                this.HablitarTextBoxs(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.HablitarTextBoxs(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }

        }

        //Método para Ressetar todos os Elementos
        private void LimparGeral()
        {
            LimparSimples();

            isInsert = false;
            isUpdate = false;
            HablitarBotons();
        }

        private void LimparSimples()
        {
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            dtpDataInicio.Value = DateTime.Now;
            dtpDataFim.Value = DateTime.Now;

            serie.ID = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparGeral();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparSimples();
            isInsert = true;
            isUpdate = false;
            HablitarBotons();
        }

        private void Selecionar(Serie serie)
        {
            NSerie nSerie = new NSerie();
            dgvLista.DataSource = nSerie.Select(serie);

            if ((dgvLista.DataSource != null)&&(dgvLista.Columns.Contains("ID")))
            {
                dgvLista.Columns["ID"].Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (serie.ID > 0)
            {
                isUpdate = true;
                isInsert = false;
                HablitarBotons();
            }
            else
            {
                MessageBox.Show("Nenhuma Série foi Selecionada.\r\nTens de Selecionar uma Série para poder Edita-la",
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (isInsert || isUpdate)
            {
                string nome = txtNome.Text.Trim().ToUpper();
                string descricao = txtDescricao.Text.Trim();
                DateTime dataEdicao = DateTime.Now;
                DateTime dataInicio = dtpDataInicio.Value;
                DateTime dataValidade = dtpDataFim.Value;
                bool estado = true;

                if (string.IsNullOrEmpty(nome))
                {
                    errorProvider1.SetError(txtNome, "Insira um Nome para a Série");
                    return;
                }

                if (dataInicio <= DateTime.MinValue)
                {
                    errorProvider1.SetError(dtpDataInicio, "Defina uma Data Válida");
                    return;
                }
                if (dataValidade <= DateTime.MinValue)
                {
                    errorProvider1.SetError(dtpDataFim, "Defina uma Data Válida");
                    return;
                }

                if (dataValidade.Date < DateTime.Now.Date)
                {
                    estado = false;
                }

                NSerie nSerie = new NSerie();
                if (isInsert)
                {
                    string resposta = nSerie.Insert(new Serie(nome, descricao, dataEdicao, dataInicio, dataValidade, estado));
                    int id = 0;
                    if (!int.TryParse(resposta, out id))
                    {
                        MessageBox.Show("Não foi possível Criar a Nova Série.\r\nErro: " + resposta,
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LimparSimples();
                }
                else
                {
                    if (serie.ID <= 0)
                    {
                        MessageBox.Show("Nenhuma Série foi Selecionada.\r\nTens de Selecionar uma Série para poder Edita-la",
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedIndex = 0;
                        return;
                    }
                    string resposta = nSerie.Update(new Serie(serie.ID, nome, descricao, dataEdicao, dataInicio, dataValidade, estado));
                    if (!resposta.Equals("OK"))
                    {
                        MessageBox.Show("Não foi possível Editar a Série.\r\nErro: " + resposta,
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LimparGeral();
                }

                Selecionar(serie);
            }
            else
            {
                MessageBox.Show("Nenhuma acção definida (Novo/Edição).\r\nDefina uma acção a ser executada",
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLista_DoubleClick(object sender, EventArgs e)
        {
            if (dgvLista.SelectedCells.Count > 0)
            {
                serie.ID = Convert.ToInt16(dgvLista.CurrentRow.Cells["ID"].Value);

                txtNome.Text = dgvLista.CurrentRow.Cells["Série"].Value.ToString();
                txtDescricao.Text = dgvLista.CurrentRow.Cells["Descrição"].Value.ToString();
                dtpDataFim.Value = Convert.ToDateTime(dgvLista.CurrentRow.Cells["Data de Validade"].Value);
                dtpDataInicio.Value = Convert.ToDateTime(dgvLista.CurrentRow.Cells["Data Inicial"].Value);

                isInsert = false;
                isUpdate = false;
                HablitarBotons();

                tabControl1.SelectedIndex = 1;
            }
        }

        private void dgvLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvLista.Columns[e.ColumnIndex].Name.Equals("Estado"))
            //{
            //    if (Convert.ToBoolean(e.Value))
            //    {
            //        e.Value = "Activo";
            //    }
            //    else
            //    {
            //        e.Value = "Desativo";
            //    }

            //}
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if (!chkDataInicio.Checked)
            {
                serie = new Serie();
            }
            serie.Nome = txtFiltro.Text;
            Selecionar(serie);
        }

        private void dtpDataInicioFiltro_ValueChanged(object sender, EventArgs e)
        {
            if (!chkDataInicio.Checked)
            {
                serie = new Serie();
            }
            serie.DataInicial = dtpDataInicioFiltro.Value;
            Selecionar(serie);
        }

        private void dtpDataValidadeFiltro_ValueChanged(object sender, EventArgs e)
        {
            if (!chkDataInicio.Checked)
            {
                serie = new Serie();
            }
            serie.DataValidade = dtpDataValidadeFiltro.Value;
            Selecionar(serie);
        }
    }
}
