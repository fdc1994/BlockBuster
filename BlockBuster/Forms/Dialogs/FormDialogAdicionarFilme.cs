using CamadaDados;
using CamadaNegocio;
using FerramentaReservas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CamadaInterface.Forms.FormUtilizadores.Dialogs
{
    public partial class FormDialogAdicionarFilme : Form
    {
        private bool novoUtilizadorECliente = false;
        public FormDialogAdicionarFilme()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
           
        }

        private void FormDialogAdicionarUtilizador_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
      
            string nome = textBoxNome.Text;
            int quantidade = (int)numericUpDown1.Value;

            if(!string.IsNullOrEmpty(nome) && quantidade >= 0) {
                guardarUtilizador(nome, quantidade);
            } else if(novoUtilizadorECliente && !string.IsNullOrEmpty(nome))
            {
                guardarUtilizador(nome, quantidade);
            }
        }

        private void guardarUtilizador(string nome, int quantidade)
        {
            string erro = String.Empty;
            Filme novoFilme = new Filme(nome, quantidade);
            bool result = novoFilme.GravarNovoFilme(nome, quantidade, out erro);
            if (erro != String.Empty && result)
            {
                MessageBox.Show("Erro" + erro);
            }
            else
            {
                MessageBox.Show("Sucesso", "Filme Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
