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
    public partial class frmPrincipal : Form
    {
        private bool Fechar = true;
        public frmPrincipal()
        {
            InitializeComponent();
            tsFuncionario.Text = Model.ElementosEstaticos.Militar.Nome;
            lbEmpresa.Text = Model.ElementosEstaticos.Unidade.Nome;
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Fechar)
            {
                Application.Exit();
            }
        }

        private void ChamarForm(Form frmChamar)
        {
            while(this.MdiChildren.Length > 0)
            {
                this.MdiChildren[0].Close();
            }
            frmChamar.MdiParent = this;
            frmChamar.Show();
        }
        private void tsmSeries_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmSerie());
        }

        private void tsUser_ButtonClick(object sender, EventArgs e)
        {
        }

        private void cadastrarMilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmMilitar(1));
        }

        private void listarMilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmMilitar(0));
        }

        private void cadastrarFardaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmFarda(1));
        }

        private void listaDeFardasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmFarda(0));
        }

        private void cadastrarVestuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmVestuario(1));
        }

        private void listarVestuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmVestuario(0));
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tsDistribuirVestuario_Click(object sender, EventArgs e)
        {
        }

        private void tsEncomenda_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmEncomenda());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsData.Text = DateTime.Now.ToLongDateString();
            tsHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void ecomendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmEntrarEncomenda());
        }

        private void fecharAplicaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void terminarSessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms.Cast<Form>().Where(x => x.Name.Equals("frmLogin")).First().Visible=true;
            Fechar = false;
            this.Close();
        }
    }
}
