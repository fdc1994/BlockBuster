using CamadaDados;
using CamadaNegocio;
using Ferramenta;
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
    public partial class FormDialogEditarReserva : Form
    {
        Utilizador cliente= new Utilizador();
        List<Utilizador> clientes = new List<Utilizador>();
        List<Filme> filmes = new List<Filme>();
        Reserva reserva= new Reserva();
        public FormDialogEditarReserva(CamadaNegocio.Reserva reserva)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.DialogResult = DialogResult.OK;
            setupData();
            setupViews();
        }

        private void setupViews()
        {
            string erro = String.Empty;
            DataTable todosOsClientes = Utilizador.ObterTodosOsClientes(out erro);
         
            int i = 0;
            foreach (Utilizador utilizador in clientes)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = utilizador.NomeUtilizador;
                item.Value = utilizador.IdUtilizador;

                comboBoxCliente.Items.Add(item);
                if (utilizador.IdUtilizador == this.cliente.IdUtilizador)
                {
                    comboBoxCliente.SelectedIndex = i;
                }
                i++;
            }

            i = 0;
            foreach (Filme filme in filmes)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = filme.NomeFilme;
                item.Value = filme.IdFilme;

                comboBoxFilme.Items.Add(item);
                if (filme.IdFilme == reserva.IDFilme)
                {
                    comboBoxFilme.SelectedIndex = i;
                }
                i++;
            }

            List<KeyValuePair<string,int>> list = FerramentaReservas.FerramentaReservas.GetEnumValuesAndDescriptions();
            for (int i1 = 0; i1 < list.Count; i1++)
            {
                string status = list[i].Key;
                this.comboBoxEstado.Items.Add(status);
                if(reserva.Estado.Equals(status)) { 
                    comboBoxEstado.SelectedIndex = i;
                }
            }

        }

        private void setupData()
        {
            string erro = String.Empty;
            cliente = cliente.ObterUtilizador(reserva.IDCliente, out erro);
            foreach (DataRow row in Utilizador.ObterTodosOsClientes(out erro).Rows)
            {
                Utilizador utilizador = new Utilizador((int)row[0], (string)row[1], (string)row[2], (FerramentaUtilizadores.EnumUtilizadores)row[3]);
                clientes.Add(utilizador);
            }
            checkErro(erro);
            foreach (DataRow row in Filme.ObterTodosOsFilmes(out erro).Rows)
            {
                Filme filme = new Filme((int)row[0], (string)row[1], (int)row[2]);
                filmes.Add(filme);
            }
            checkErro(erro);

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string erro = String.Empty;
            //string novoNome = textBoxNome.Text;
            string novaPass = textBoxIdCliente.Text;
            int novoCargo = comboBoxCliente.SelectedIndex;
           // this.utilizador.GravarUtilizador(novoNome, novaPass, novoCargo,out erro);
            if(erro != String.Empty)
            {
                MessageBox.Show("Erro" + erro);
            }else
            {
             //  utilizador.NomeUtilizador = novoNome;
                //utilizador.Pass= novaPass;
               // utilizador.Status = (FerramentaUtilizadores.EnumUtilizadores)novoCargo;
                MessageBox.Show("Sucesso","Utilizador Modificado",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void FormDialogEditarUtilizador_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem utilizadorCombo = (ComboboxItem)comboBoxCliente.SelectedItem;
            
            textBoxIdCliente.Text = utilizadorCombo.Value.ToString();

            foreach(Utilizador user in clientes)
            {
                if(user.IdUtilizador == utilizadorCombo.Value) {
                    cliente = user; break;
                }
            }
        }

        private void checkErro(string erro)
        {
            if (erro != String.Empty)
            {
                MessageBox.Show("Erro");
                this.Close();
            }
        } 
    }
}
