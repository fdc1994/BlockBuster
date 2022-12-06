using CamadaDados;
using CamadaNegocio;
using Ferramenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamadaInterface.Forms.FormUtilizadores.Dialogs
{
    public partial class FormDialogAdicionarUtilizador : Form
    {

        private int Id = 0;
        public FormDialogAdicionarUtilizador(int id)
        {
            InitializeComponent();
            Setup();
            Id = id;
        }

        private void Setup()
        {
            foreach (string status in Enum.GetNames(typeof(EnumUtilizadores)))
            {
              this.comboBoxCargo.Items.Add(status);
              
            }
            this.comboBoxCargo.SelectedIndex = 0;
        }

        private void FormDialogAdicionarUtilizador_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string erro = String.Empty;
            string nome = textBoxNome.Text;
            string pass = textBoxPass.Text;
            int cargo = comboBoxCargo.SelectedIndex;

            if(!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(pass)) {
                Utilizador novoUtilizador = new Utilizador(this.Id, nome, pass, (EnumUtilizadores)cargo);
                novoUtilizador.GravarUtilizador(out erro);
                if (erro != String.Empty)
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
}
