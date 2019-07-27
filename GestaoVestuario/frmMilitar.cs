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
    public partial class frmMilitar : Form
    {
        bool isInsert = false;
        bool isUpdate = false;

        Militar militar = new Militar();

        private int IdNumeroEditar = 0;

        Dictionary<string, int> LMilitar = new Dictionary<string, int>();
        Dictionary<string, int> LFarda = new Dictionary<string, int>();
        Dictionary<string, int> LVestuario = new Dictionary<string, int>();
        Dictionary<string, int> LNumero = new Dictionary<string, int>();
        

        public frmMilitar(int index)
        {
            InitializeComponent();
            tabControl1.SelectedIndex = index;
        }

        private void frmMilitar_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PrepararForm();
        }

        //Método que define o estado inicial do Formulário
        private void PrepararForm()
        {
            LimparGeral();
            Selecionar(new Militar());


            cbFarda.Items.Clear();
            LFarda = new NFarda().ListarNomeID();
            cbFarda.Items.AddRange(LFarda.Keys.ToArray());
        }

        //Método Hablitar todoso os controles do formulário
        private void HablitarTextBoxs(bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.dtpDataNascimento.Enabled = valor;
            this.txtBI.ReadOnly = !valor;
            this.txtTelefone.ReadOnly = !valor;
            this.txtMorada.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
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

            LimparMilitar();
            
            isInsert = false;
            isUpdate = false;
            HablitarBotons();
        }

        private void LimparSimples()
        {
            txtNome.Text = string.Empty;
            txtBI.Text = string.Empty;
            dtpDataNascimento.Value = DateTime.Now;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMorada.Text = string.Empty;

            militar.ID = 0;
        }

        private void LimparNumero()
        {
            cbNumero.Items.Clear();
            cbNumero.Text = null;
            cbNumero.Enabled = false;

            btnEditarNumero.Enabled = false;
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
            IdNumeroEditar = 0;
        }
        private void LimparVestuario()
        {
            cbVestuario.Items.Clear();
            cbVestuario.Enabled = false;
            LimparNumero();
        }
        private void LimparFarda()
        {
            cbFarda.Text = null;
            cbFarda.Enabled = false;
            LimparVestuario();

            dgvListaNumero.Rows.Clear();
        }
        private void LimparMilitar()
        {
            cbMilitar.Items.Clear();
            LMilitar = new NMilitar().ListarNomeID();
            cbMilitar.Items.AddRange(LMilitar.Keys.ToArray());
            LimparFarda();
        }
        private void Selecionar(Militar militar)
        {
            NMilitar nMilitar = new NMilitar();
            dgvLista.DataSource = nMilitar.Select(militar);

            if ((dgvLista.DataSource != null) && (dgvLista.Columns.Contains("ID")))
            {
                dgvLista.Columns["ID"].Visible = false;
            }
        }

        private void txtNomeFiltro_TextChanged(object sender, EventArgs e)
        {
            militar = new Militar();
            militar.Nome = txtNomeFiltro.Text;
            Selecionar(militar);
        }

        private void txtBIFiltro_TextChanged(object sender, EventArgs e)
        {
            militar = new Militar();
            militar.BI = txtBIFiltro.Text;
            Selecionar(militar);
        }

        private void dtpDataNascimentoFiltro_ValueChanged(object sender, EventArgs e)
        {
            militar = new Militar();
            militar.DataNascimento = dtpDataNascimentoFiltro.Value;
            Selecionar(militar);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparSimples();
            isInsert = true;
            isUpdate = false;
            HablitarBotons();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (militar.ID > 0)
            {
                isUpdate = true;
                isInsert = false;
                HablitarBotons();
            }
            else
            {
                MessageBox.Show("Nenhum Militar foi Selecionada.\r\nTens de Selecionar um Militar para poder Edita-lo",
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = 0;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (isInsert || isUpdate)
            {
                string nome = txtNome.Text.Trim().ToUpper();
                string bi = txtBI.Text.Trim();
                string telefone = txtTelefone.Text.Trim();
                string email = txtEmail.Text;
                string endereco = txtMorada.Text;
                DateTime dataNascimento = dtpDataNascimento.Value;
                bool estado = true;

                if (string.IsNullOrEmpty(nome))
                {
                    errorProvider1.SetError(txtNome, "Insira um Nome para o Militar");
                    return;
                }

                NMilitar nMilitar = new NMilitar();
                if (isInsert)
                {
                    string resposta = nMilitar.Insert(new Militar(nome, dataNascimento, bi, telefone, email, endereco, estado));
                    int id = 0;
                    if (!int.TryParse(resposta, out id))
                    {
                        MessageBox.Show("Não foi possível Criar o Novo Militar.\r\nErro: " + resposta,
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LimparSimples();
                    LimparMilitar();
                }
                else
                {
                    if (militar.ID <= 0)
                    {
                        MessageBox.Show("Nenhum Militar foi Selecionado.\r\nTens de Selecionar um Militar para poder Edita-lo",
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tabControl1.SelectedIndex = 0;
                        return;
                    }
                    string resposta = nMilitar.Update(new Militar(militar.ID, nome, dataNascimento, bi, telefone, email, endereco, estado));
                    if (!resposta.Equals("OK"))
                    {
                        MessageBox.Show("Não foi possível Editar o Militar.\r\nErro: " + resposta,
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LimparGeral();
                }

                Selecionar(militar);
            }
            else
            {
                MessageBox.Show("Nenhuma acção definida (Novo/Edição).\r\nDefina uma acção a ser executada",
                    ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparGeral();
        }

        private void dgvLista_DoubleClick(object sender, EventArgs e)
        {
            if (dgvLista.SelectedCells.Count > 0)
            {
                militar.ID = Convert.ToInt16(dgvLista.CurrentRow.Cells["ID"].Value);

                txtNome.Text = dgvLista.CurrentRow.Cells["Militar"].Value.ToString();
                txtBI.Text = dgvLista.CurrentRow.Cells["B.I. nº"].Value.ToString();
                dtpDataNascimento.Value = Convert.ToDateTime(dgvLista.CurrentRow.Cells["Data de Nascimento"].Value);
                txtTelefone.Text = dgvLista.CurrentRow.Cells["Telefone"].Value.ToString();
                txtEmail.Text = dgvLista.CurrentRow.Cells["Email"].Value.ToString();
                txtMorada.Text = dgvLista.CurrentRow.Cells["Morada"].Value.ToString();

                isInsert = false;
                isUpdate = false;
                HablitarBotons();

                tabControl1.SelectedIndex = 1;
            }
        }

        private void cbMilitar_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparFarda();
            cbFarda.Enabled = true;

            int id = 0;
            if (LMilitar.TryGetValue(cbMilitar.Text, out id))
            {
                var numerosMilitar = new NMilitar().ListarNumeroMilitar(new Militar(id));

                foreach (var item in numerosMilitar)
                {
                    object[] row = { item.ID, item.Farda.Nome, item.NumeroVestuario.Vestuario.Nome, item.NumeroVestuario.Numero};
                    dgvListaNumero.Rows.Add(row);
                }
            }
        }

        private void cbFarda_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelecionarFarda();
        }
        private void SelecionarFarda()
        {
            LimparVestuario();
            int id = 0;
            if (LFarda.TryGetValue(cbFarda.Text, out id))
            {
                LVestuario = new NFarda().ListarVestuarioNomeID(new Farda(id));

                foreach (string item in LVestuario.Keys)
                {
                    bool inserir = true;
                    foreach (DataGridViewRow dgvrows in dgvListaNumero.Rows)
                    {
                        if ((dgvrows.Cells["Farda"].Value.ToString().Equals(cbFarda.Text))
                            && dgvrows.Cells["Vestuario"].Value.ToString().Equals(item))
                        {
                            inserir = false;
                            break;
                        }
                    }
                    if (inserir)
                        cbVestuario.Items.Add(item);
                }



                cbVestuario.Enabled = true;
            }
        }

        private void cbVestuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparNumero();
            int id = 0;
            if (LVestuario.TryGetValue(cbVestuario.Text, out id))
            {
                LNumero = new NVestuario().ListarNumerosNomeID(new Vestuario(id));
                cbNumero.Items.AddRange(LNumero.Keys.ToArray());
                cbNumero.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int idNumero = 0;
            int idVestuario = 0;
            int idFarda = 0;
            int idMilitar = 0;
            if ((LNumero.TryGetValue(cbNumero.Text, out idNumero))&&(LVestuario.TryGetValue(cbVestuario.Text, out idVestuario))
                &&(LFarda.TryGetValue(cbFarda.Text, out idFarda)) &&(LMilitar.TryGetValue(cbMilitar.Text, out idMilitar)))
            {
                string resposta = new NMilitar().InsertNumero(new NumeroMilitar(new Militar(idMilitar), new NumeroVestuario(idNumero), new Farda(idFarda)));

                int idNumeroMilitar = 0;
                if (!int.TryParse(resposta, out idNumeroMilitar))
                {
                    MessageBox.Show("Não foi possível gravar o Número do Militar.\r\n" + resposta, ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    object[] items = { idNumeroMilitar, cbFarda.Text, cbVestuario.Text, cbNumero.Text };
                    dgvListaNumero.Rows.Add(items);
                    cbVestuario.Items.Remove(cbVestuario.Text);
                    cbVestuario.Text = null;
                    LimparNumero();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = (int)dgvListaNumero.CurrentRow.Cells["ID"].Value;
            string resposta = new NNumeroMilitar().Delete(new NumeroMilitar(id));
            if (resposta.Equals("OK"))
            {
                dgvListaNumero.Rows.Remove(dgvListaNumero.CurrentRow);
                SelecionarFarda();
            }
            else
            {
                MessageBox.Show("Não foi possível Eliminar o Número do Militar.\r\n" + resposta, ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelecionarNumero_Click(object sender, EventArgs e)
        {
            cbMilitar.Text = dgvLista.CurrentRow.Cells["Militar"].Value.ToString();
            tabControl1.SelectedIndex = 2;
        }

        private void dgvListaNumero_DoubleClick(object sender, EventArgs e)
        {
            int idmiliatar = 0;
            if (LMilitar.TryGetValue(cbMilitar.Text, out idmiliatar))
            {
                LimparNumero();
                IdNumeroEditar = (int)dgvListaNumero.CurrentRow.Cells["Farda"].Value;
                cbFarda.Text = dgvListaNumero.CurrentRow.Cells["Farda"].Value.ToString();
                cbVestuario.Text = dgvListaNumero.CurrentRow.Cells["Vestuario"].Value.ToString();
                cbNumero.Text = dgvListaNumero.CurrentRow.Cells["Numero"].Value.ToString();

                btnAdd.Enabled = false;
                btnRemove.Enabled = true;
                btnEditarNumero.Enabled = true;
            }
        }

        private void btnEditarNumero_Click(object sender, EventArgs e)
        {
            if (true)
            {

            }
        }
    }
}
