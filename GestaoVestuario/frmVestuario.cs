using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace GestaoVestuario
{
    public partial class frmVestuario : Form
    {
        bool isInsert = false;
        bool isUpdate = false;

        Vestuario vestuario = new Vestuario();

        public frmVestuario(int index)
        {
            InitializeComponent();
            this.tabControl1.SelectedIndex = index;
        }

        private void frmVestuario_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PrepararForm();
        }

        //Método que define o estado inicial do Formulário
        private void PrepararForm()
        {
            LimparGeral();
            Selecionar(new Vestuario());
        }

        //Método Hablitar todoso os controles do formulário
        private void HablitarTextBoxs(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
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

            vestuario.ID = 0;
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

        private void Selecionar(Vestuario vestuario)
        {
            NVestuario nVestuario = new NVestuario();
            dgvLista.DataSource = nVestuario.Select(vestuario);

            if ((dgvLista.DataSource != null) && (dgvLista.Columns.Contains("ID")))
            {
                dgvLista.Columns["ID"].Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (vestuario.ID > 0)
            {
                isUpdate = true;
                isInsert = false;
                HablitarBotons();
            }
            else
            {
                MessageBox.Show("Nenhuma Vestuario foi Selecionada.\r\nTens de Selecionar uma Vestuario para poder Edita-la",
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

                if (string.IsNullOrEmpty(nome))
                {
                    errorProvider1.SetError(txtNome, "Insira um Nome para a Vestuario");
                    return;
                }

                NVestuario nVestuario = new NVestuario();
                if (isInsert)
                {
                    string resposta = nVestuario.Insert(new Vestuario(nome, descricao));
                    int id = 0;
                    if (!int.TryParse(resposta, out id))
                    {
                        MessageBox.Show("Não foi possível Criar a Nova Vestuario.\r\nErro: " + resposta,
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LimparSimples();
                }
                else
                {
                    if (vestuario.ID <= 0)
                    {
                        MessageBox.Show("Nenhuma Vestuario foi Selecionada.\r\nTens de Selecionar uma Vestuario para poder Edita-la",
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedIndex = 0;
                        return;
                    }
                    string resposta = nVestuario.Update(new Vestuario(vestuario.ID, nome, descricao));
                    if (!resposta.Equals("OK"))
                    {
                        MessageBox.Show("Não foi possível Editar a Vestuario.\r\nErro: " + resposta,
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LimparGeral();
                }

                Selecionar(vestuario);
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
                vestuario.ID = Convert.ToInt16(dgvLista.CurrentRow.Cells["ID"].Value);

                txtNome.Text = dgvLista.CurrentRow.Cells["Vestuario"].Value.ToString();
                txtDescricao.Text = dgvLista.CurrentRow.Cells["Descrição"].Value.ToString();

                isInsert = false;
                isUpdate = false;
                HablitarBotons();

                tabControl1.SelectedIndex = 1;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            vestuario.Nome = txtFiltro.Text;
            Selecionar(vestuario);
        }
    }
}
