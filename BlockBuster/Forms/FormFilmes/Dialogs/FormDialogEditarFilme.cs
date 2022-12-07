using CamadaNegocio;
using Ferramenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamadaInterface
{
    public partial class FormDialogEditarFilme : Form
    {
        Filme filme = new Filme();
        public FormDialogEditarFilme(CamadaNegocio.Filme filme)
        {
            InitializeComponent();
            this.filme = filme;
            this.DialogResult = DialogResult.OK;
            setupViews();
        }

        private void setupViews()
        {
            textBoxNome.Text = filme.NomeFilme;
            numericUpDown1.Value = filme.Quantidade;
            numericUpDown1.Minimum = 0;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string erro = String.Empty;
            string novoNome = textBoxNome.Text;
            int novaQuantidade = (int)numericUpDown1.Value;

            this.filme.GravarFilme(filme.IdFilme, novoNome, novaQuantidade, out erro);
            if(erro != String.Empty)
            {
                MessageBox.Show("Erro" + erro);
            }else
            {
                filme.NomeFilme = novoNome;
                filme.Quantidade= novaQuantidade;
                MessageBox.Show("Sucesso","Filme Modificado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void FormDialogEditarUtilizador_Load(object sender, EventArgs e)
        {

        }
    }
}
