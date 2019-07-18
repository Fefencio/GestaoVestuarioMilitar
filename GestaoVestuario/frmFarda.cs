using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoVestuario
{
    public partial class frmFarda : Form
    {
        bool isInsert = false;
        bool isUpdate = false;

        Farda farda = new Farda();
        Dictionary<string, int> LVestuario = new Dictionary<string, int>();

        public frmFarda(int index)
        {
            InitializeComponent();
            this.tabControl1.SelectedIndex = index;
        }

        private void frmFarda_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PrepararForm();
        }

        //Método que define o estado inicial do Formulário
        private void PrepararForm()
        {
            LimparGeral();
            Selecionar(new Farda());
        }

        private void PreencherComboBoxVestuario()
        {
            NVestuario nVestuario = new NVestuario();
            LVestuario = nVestuario.ListarNomeID();
            cbVestuario.Items.Clear();
            lbVestuario.Items.Clear();
            cbVestuario.Items.AddRange(LVestuario.Keys.ToArray());
        }

        //Método Hablitar todoso os controles do formulário
        private void HablitarTextBoxs(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.txtDescricao.ReadOnly = !valor;
            cbVestuario.Enabled = valor;
            lbVestuario.Enabled = valor;
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
            PreencherComboBoxVestuario();
            cbVestuario.Text = null;

            farda.ID = 0;
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

        private void Selecionar(Farda farda)
        {
            NFarda nFarda = new NFarda();
            dgvLista.DataSource = nFarda.Select(farda);

            if ((dgvLista.DataSource != null) && (dgvLista.Columns.Contains("ID")))
            {
                dgvLista.Columns["ID"].Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (farda.ID > 0)
            {
                isUpdate = true;
                isInsert = false;
                HablitarBotons();
            }
            else
            {
                MessageBox.Show("Nenhuma Farda foi Selecionada.\r\nTens de Selecionar uma Farda para poder Edita-la",
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

                List<Vestuario> vestuarios = new List<Vestuario>();
                foreach (string item in lbVestuario.Items)
                {
                    vestuarios.Add(new Vestuario(LVestuario[item]));
                }

                if (string.IsNullOrEmpty(nome))
                {
                    errorProvider1.SetError(txtNome, "Insira um Nome para a Farda");
                    return;
                }

                NFarda nFarda = new NFarda();
                if (isInsert)
                {
                    string resposta = nFarda.Insert(new Farda(nome, descricao, vestuarios));
                    int id = 0;
                    if (!int.TryParse(resposta, out id))
                    {
                        MessageBox.Show("Não foi possível Criar a Nova Farda.\r\nErro: " + resposta,
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LimparSimples();
                }
                else
                {
                    if (farda.ID <= 0)
                    {
                        MessageBox.Show("Nenhuma Farda foi Selecionada.\r\nTens de Selecionar uma Farda para poder Edita-la",
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedIndex = 0;
                        return;
                    }
                    string resposta = nFarda.Update(new Farda(farda.ID, nome, descricao, vestuarios));
                    if (!resposta.Equals("OK"))
                    {
                        MessageBox.Show("Não foi possível Editar a Farda.\r\nErro: " + resposta,
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LimparGeral();
                }

                Selecionar(farda);
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
                farda.ID = Convert.ToInt16(dgvLista.CurrentRow.Cells["ID"].Value);

                txtNome.Text = dgvLista.CurrentRow.Cells["Farda"].Value.ToString();
                txtDescricao.Text = dgvLista.CurrentRow.Cells["Descrição"].Value.ToString();

                string[] vestuarios = dgvLista.CurrentRow.Cells["Vestuarios"].Value.ToString().Split(',');
                cbVestuario.Items.Clear();
                lbVestuario.Items.Clear();

                lbVestuario.Items.AddRange(LVestuario.Keys.Where(i => vestuarios.Contains(i)).ToArray());
                cbVestuario.Items.AddRange(LVestuario.Keys.Where(i => !vestuarios.Contains(i)).ToArray());

                isInsert = false;
                isUpdate = false;
                HablitarBotons();

                tabControl1.SelectedIndex = 1;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            farda.Nome = txtFiltro.Text;
            Selecionar(farda);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (LVestuario.TryGetValue(cbVestuario.Text, out id))
            {
                lbVestuario.Items.Add(cbVestuario.Text);
                cbVestuario.Items.Remove(cbVestuario.Text);
                cbVestuario.Text = null;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (LVestuario.TryGetValue(lbVestuario.Text, out id))
            {
                cbVestuario.Items.Add(lbVestuario.Text);
                lbVestuario.Items.Remove(lbVestuario.Text);
            }
        }
    }
}
