using CamadaNegocio;
using FerramentaReservas;
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
    public partial class FormDialogEditarUtilizador : Form
    {
        Utilizador utilizador= new Utilizador();   
        public FormDialogEditarUtilizador(CamadaNegocio.Utilizador utilizador)
        {
            InitializeComponent();
            this.utilizador = utilizador;
            this.DialogResult = DialogResult.OK;
            setupViews();
        }

        private void setupViews()
        {
            foreach(string status in Enum.GetNames(typeof(FerramentaUtilizadores.EnumUtilizadores)))
            {
                comboBoxCargo.Items.Add(status.ToString());
            }
            textBoxNome.Text = utilizador.NomeUtilizador;
            if (utilizador.Status != FerramentaUtilizadores.EnumUtilizadores.Cliente)
            {
                int cargo = (int)utilizador.Status;
                textBoxPass.Text = utilizador.Pass;
                comboBoxCargo.SelectedIndex = cargo;
            } else
            {
                textBoxPass.Enabled = false;    
                comboBoxCargo.Enabled = false;
                comboBoxCargo.SelectedIndex = 3;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string erro = String.Empty;
            string novoNome = textBoxNome.Text;
            string novaPass = textBoxPass.Text;
            int novoCargo = comboBoxCargo.SelectedIndex;
            this.utilizador.GravarUtilizador(novoNome, novaPass, novoCargo,out erro);
            if(erro != String.Empty)
            {
                MessageBox.Show("Erro" + erro);
            }else
            {
                utilizador.NomeUtilizador = novoNome;
                utilizador.Pass= novaPass;
                utilizador.Status = (FerramentaUtilizadores.EnumUtilizadores)novoCargo;
                MessageBox.Show("Sucesso","Utilizador Modificado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void FormDialogEditarUtilizador_Load(object sender, EventArgs e)
        {

        }
    }
}
