using BlockBuster;
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
    public partial class FormDialogAdicionarUtilizador : Form
    {
        private bool novoUtilizadorECliente = false;
        public FormDialogAdicionarUtilizador()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            foreach (string status in Enum.GetNames(typeof(FerramentaUtilizadores.EnumUtilizadores)))
            {
                this.comboBoxCargo.Items.Add(status);

            }
            if (Program.GetUtilizador().UtilizadorEAdmin())
            {   
                this.comboBoxCargo.SelectedIndex = 0;
            }else
            {
                //colaboradores só podem adicionar clientes
                this.comboBoxCargo.SelectedIndex = 3;
                this.comboBoxCargo.Enabled = false;
            }
                
        }

        private void FormDialogAdicionarUtilizador_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
      
            string nome = textBoxNome.Text;
            string pass = textBoxPass.Text;
            int cargo = comboBoxCargo.SelectedIndex;

            if(!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(pass)) {
                guardarUtilizador(nome, pass, cargo);
            } else if(novoUtilizadorECliente && !string.IsNullOrEmpty(nome))
            {
                guardarUtilizador(nome, String.Empty, cargo);
            }
        }

        private void comboBoxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxCargo.SelectedIndex == 3)
            {
                novoUtilizadorECliente = true;
                textBoxPass.Text = String.Empty;
                textBoxPass.Enabled = false;
            } else
            {
                novoUtilizadorECliente = false;
                textBoxPass.Enabled = true;
            }
        }

        private void guardarUtilizador(string nome, string pass, int cargo)
        {
            string erro = String.Empty;
            Utilizador novoUtilizador = new Utilizador(nome, pass, (FerramentaUtilizadores.EnumUtilizadores)cargo);
            bool result = novoUtilizador.GravarNovoUtilizador(out erro);
            if (erro != String.Empty && result)
            {
                MessageBox.Show("Erro" + erro);
            }
            else
            {
                MessageBox.Show("Sucesso", "Utilizador Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
