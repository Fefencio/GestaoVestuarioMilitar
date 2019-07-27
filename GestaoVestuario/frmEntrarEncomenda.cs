using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;
using ImpressaoRelatorio;

namespace GestaoVestuario
{
    public partial class frmEntrarEncomenda : Form
    {
        public frmEntrarEncomenda()
        {
            InitializeComponent();
        }

        private void frmEntrarEncomenda_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PrepararForm();
        }

        private void PrepararForm()
        {
            Selecionar("");
        }

        private void Limpar()
        {
            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtFiltro.Text = string.Empty;
            dgvListaItems.Rows.Clear();
            dtpDataCriacao.Value = DateTime.Now;
        }


        private void Selecionar(string codigo)
        {
            NEcomenda nEcomenda = new NEcomenda();
            dgvLista.DataSource = nEcomenda.Select(new Ecomenda() { Codigo=codigo});
        }

        private void dgvLista_DoubleClick(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                Limpar();
                txtCodigo.Text = dgvLista.CurrentRow.Cells["Codigo"].Value.ToString();
                txtDescricao.Text = dgvLista.CurrentRow.Cells["Descrição"].Value.ToString();
                dtpDataCriacao.Value = Convert.ToDateTime(dgvLista.CurrentRow.Cells["Data de Criação"].Value.ToString());

                int id = (int)dgvLista.CurrentRow.Cells["ID"].Value;
                Ecomenda ecomenda = new Ecomenda(id);
                NEcomenda nEcomenda = new NEcomenda();
                var lEcomendaItems = nEcomenda.SelectItemsEncomenda(ecomenda);

                foreach (EcomendaItens itemEcomenda in lEcomendaItems)
                {
                    object[] listaItems = {itemEcomenda.Serie.ID, itemEcomenda.Serie.Nome, itemEcomenda.Farda.ID, itemEcomenda.Farda.Nome, itemEcomenda.NumeroVestuario.ID,
                itemEcomenda.NumeroVestuario.Vestuario.Nome, itemEcomenda.NumeroVestuario.Numero, itemEcomenda.Quantidade};
                    dgvListaItems.Rows.Add(listaItems);
                }
                tabControl1.SelectedIndex = 1;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            Selecionar(txtFiltro.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                List<StockVestuarioFarda> Lstock = new List<StockVestuarioFarda>();
                foreach (DataGridViewRow row in dgvListaItems.Rows)
                {
                    var farda = new Farda((int)row.Cells["IdFarda"].Value);
                    var serie = new Serie((int)row.Cells["IdSerie"].Value);
                    var numeroVestuario = new NumeroVestuario((int)row.Cells["IdNumero"].Value);
                    int quantidade = (int)row.Cells["Quantidade"].Value;
                    var itens = new StockVestuarioFarda(serie, farda, numeroVestuario, quantidade);

                    Lstock.Add(itens);
                }

                MovimentoStock movimento = new MovimentoStock()
                {
                    Descricao = "Entrada de Ecomenda nº " + txtCodigo.Text,
                    DataMovimento = DateTime.Now,
                    Militar = ElementosEstaticos.Militar,
                    TipoMovimento = EnumList.TipoMovimento.Entrada

                };

                foreach (var item in Lstock)
                {
                    NStock nStock = new NStock();
                    string resposta = nStock.Insert(item, movimento);
                }
                //Imprimir
                DGVPrinter printer = new DGVPrinter();

                printer.ListColumns = new List<string>() { "Serie", "Farda", "Vestuario", "Numero", "Quantidade" };
                printer.Title = "Ecomenda de Vestuário";
                printer.SubTitle = string.Format("{0}  -  {1}", movimento.Descricao, DateTime.Now.ToString("dd-MMMM-yyyy hh:mm"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = ElementosEstaticos.Unidade.Nome;
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvListaItems);

                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro impedio a execução da operação.\r\nErro: " + ex.Message, ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
