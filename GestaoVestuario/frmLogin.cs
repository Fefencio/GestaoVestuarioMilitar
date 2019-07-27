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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        void Limpar()
        {
            txtUtilizador.Text = string.Empty;
            txtSenha.Text = string.Empty;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja sair do Sistema?", ElementosEstaticos.Unidade.Nome, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit();
            }
            else
            {
                Limpar();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string utilizador = txtUtilizador.Text;
            if (string.IsNullOrWhiteSpace(utilizador))
            {
                errorProvider1.SetError(txtUtilizador, "Insira um nome de utilizador válido.");
                return;
            }
            string senha = txtSenha.Text;
            if (string.IsNullOrWhiteSpace(senha))
            {
                errorProvider1.SetError(txtSenha, "Insira uma senha válida.");
                return;
            }
            Login(utilizador, senha);
        }

        void Login(string utilizador, string senha)
        {
            try
            {
                NUtilizador nUtilizador = new NUtilizador();
                Militar militar = nUtilizador.Login(new Utilizador(utilizador, senha));

                ElementosEstaticos.Militar = militar;

                frmPrincipal frmPrincipal = new frmPrincipal();
                frmPrincipal.Show();
                Limpar();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ElementosEstaticos.Unidade.Nome, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
