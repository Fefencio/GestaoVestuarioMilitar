using BLL;
using ImpressaoRelatorio;
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
    public partial class frmEncomenda : Form
    {
        Dictionary<string, int> LFardas = new Dictionary<string, int>();
        Dictionary<string, int> LSeries = new Dictionary<string, int>();


        public frmEncomenda()
        {
            InitializeComponent();
        }

        private void frmEncomenda_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PrepararForm();
        }
        private void PrepararForm()
        {
            LFardas = new NFarda().ListarNomeID();
            LSeries = new NSerie().ListarNomeID();

            cbFarda.Items.AddRange(LFardas.Keys.ToArray());
            cbSerie.Items.AddRange(LSeries.Keys.ToArray());
        }

        void Limpar()
        {
            cbFarda.SelectedIndex = -1;
            cbSerie.SelectedIndex = -1;
            nudQuantidade.Value = nudQuantidade.Minimum;
            txtDescricao.Text = string.Empty;
            lbVestuario.Items.Clear();
            dgvLista.Rows.Clear();
        }

        private void cbFarda_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idFarda = 0;
            if (LFardas.TryGetValue(cbFarda.Text, out idFarda))
            {
                var lVestuario = new NFarda().ListarVestuarioNomeID(new Farda(idFarda));

                lbVestuario.Items.Clear();
                foreach (string item in lVestuario.Keys)
                {
                    
                    lbVestuario.Items.Add(item, true);
                }
            } 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                List<EcomendaItens> LItensEcomenda = new List<EcomendaItens>();
                int idFarda = 0;
                int idSerie = 0;
                if ((LFardas.TryGetValue(cbFarda.Text, out idFarda)) && (LSeries.TryGetValue(cbSerie.Text, out idSerie))
                    && (lbVestuario.CheckedItems.Count > 0))
                {
                    var lVestuario = new NFarda().ListarVestuarioNomeID(new Farda(idFarda));
                    foreach (string item in lbVestuario.CheckedItems)
                    {
                        int idVestuario = 0;
                        if (lVestuario.TryGetValue(item, out idVestuario))
                        {
                            EcomendaItens ecomendaItens = new EcomendaItens()
                            {
                                Farda = new Farda(idFarda),
                                NumeroVestuario = new NumeroVestuario() { Vestuario = new Vestuario(idVestuario) }
                            };

                            LItensEcomenda.AddRange(new NEcomenda().SelectTotalEncomendar(ecomendaItens));
                        }
                    }
                    foreach (EcomendaItens itemEcomenda in LItensEcomenda)
                    {
                        object[] listaItems = {idSerie, cbSerie.Text, itemEcomenda.Farda.ID, itemEcomenda.Farda.Nome, itemEcomenda.NumeroVestuario.ID,
                itemEcomenda.NumeroVestuario.Vestuario.Nome, itemEcomenda.NumeroVestuario.Numero, (itemEcomenda.Quantidade * (int)nudQuantidade.Value)};
                        dgvLista.Rows.Add(listaItems);
                    }
                    nudQuantidade.Value = nudQuantidade.Minimum;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro impedio a execução da operação.\r\nErro: " + ex.Message, ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dgvLista.Rows.Count > 0)
            dgvLista.Rows.Remove(dgvLista.CurrentRow);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                List<EcomendaItens> ecomendaItens = new List<EcomendaItens>();
                foreach (DataGridViewRow row in dgvLista.Rows)
                {
                    var farda = new Farda((int)row.Cells["IdFarda"].Value);
                    var serie = new Serie((int)row.Cells["IdSerie"].Value);
                    var numeroVestuario = new NumeroVestuario((int)row.Cells["IdNumero"].Value);
                    int quantidade = (int)row.Cells["Quantidade"].Value;
                    var itens = new EcomendaItens(farda, serie, numeroVestuario, quantidade);

                    ecomendaItens.Add(itens);
                }

                Ecomenda ecomenda = new Ecomenda()
                {
                    Descricao = txtDescricao.Text,
                    DataCriacao = DateTime.Now,
                    DataChegada = DateTime.Now,
                    EcomendaItens = ecomendaItens,
                    Militar = ElementosEstaticos.Militar
                };

                NEcomenda nEcomenda = new NEcomenda();
                string resposta = nEcomenda.Insert(ecomenda);

                int id = 0;
                if (!int.TryParse(resposta, out id))
                {
                    throw new InvalidOperationException(resposta);
                }
                //Imprimir
                DGVPrinter printer = new DGVPrinter();

                printer.ListColumns = new List<string>() { "Serie", "Farda", "Vestuario", "Numero", "Quantidade"};
                printer.Title = "Ecomenda de Vestuário";
                printer.SubTitle = string.Format("Ecomenda nº E{0}    {1}", id.ToString("00000"), DateTime.Now.ToString("dd-MMMM-yyyy hh:mm"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = ElementosEstaticos.Unidade.Nome;
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvLista);

                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro impedio a execução da operação.\r\nErro: " + ex.Message, ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
