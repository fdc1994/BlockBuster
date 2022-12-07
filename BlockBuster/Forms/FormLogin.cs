using BlockBuster;
using CamadaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamadaInterface
{
    public partial class FormLogin : Form
    {

        private FormGestao childForm;

        public FormLogin()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            attemptLogin();
        }

        private void FormLogin_EnterDown(object sender, KeyEventArgs e)
        {
            attemptLogin(); 
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void attemptLogin()
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            string erro = String.Empty;

            Utilizador novoUtilizador = Utilizador.ObterUtilizadorLogin(user, password, out erro);

            if (erro == String.Empty && novoUtilizador != null)
            {
                Program.SetupNewLoggedInUser(novoUtilizador);
                childForm = new FormGestao(this);
                childForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Erro: " + erro, "Utilizador não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
