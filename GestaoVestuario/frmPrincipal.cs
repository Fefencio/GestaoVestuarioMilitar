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
        public frmPrincipal()
        {
            InitializeComponent();
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
            MessageBox.Show(this.Width.ToString() + "     " + this.Height.ToString());
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
    }
}
