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
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamadaInterface
{
    public partial class FormDialogAdicionarReserva : Form
    {
        Utilizador cliente= new Utilizador();
        List<Utilizador> clientes = new List<Utilizador>();
        List<Filme> filmes = new List<Filme>();
        Filme filmeSelecionado = new Filme();
        Reserva reserva= new Reserva();
        public FormDialogAdicionarReserva()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            setupData();
            setupViews();
        }

        private void setupViews()
        {
            try
            {
                string erro = String.Empty;
                DataTable todosOsClientes = Utilizador.ObterTodosOsClientes(out erro);


                foreach (Utilizador utilizador in clientes)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = utilizador.NomeUtilizador;
                    item.Value = utilizador.IdUtilizador;

                    comboBoxCliente.Items.Add(item);

                }
                comboBoxCliente.SelectedIndex = 0;


                foreach (Filme filme in filmes)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = filme.NomeFilme;
                    item.Value = filme.IdFilme;

                    comboBoxFilme.Items.Add(item);
                }
                comboBoxFilme.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                checkErro(ex.Message);
            }

        }

        private void setupData()
        {
            try
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
                if(filme.Quantidade >0)
                {
                    filmes.Add(filme);
                }
            }
            checkErro(erro);
            }
            catch (Exception ex)
            {
                checkErro(ex.Message);
                this.Close();
            }

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string erro = String.Empty;
                int idCliente = int.Parse(textBoxIdCliente.Text);
                string nomeCliente = comboBoxCliente.Text;
                int idFilme = filmeSelecionado.IdFilme;
                string nomeFilme = comboBoxFilme.Text;
                this.reserva = new Reserva(idCliente,idFilme);
                this.reserva.GravarReserva(idCliente, nomeCliente, idFilme, nomeFilme, out erro);
                if (erro != String.Empty)
                {
                    MessageBox.Show("Erro" + erro, "Erro I/O", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    filmeSelecionado.GravarNovaQuantidade(-1, out erro);

                    if (erro != String.Empty)
                    {

                        checkErro(erro);
                    }
                    else {
                        MessageBox.Show("Reserva Iniciada \n\nClique Ok para voltar ao ecrã de reservas", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    
                }
            }
            catch(Exception ex) {
                checkErro(ex.Message);
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
                MessageBox.Show("Erro: " + erro, "Erro I/O", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                this.Close();
            }
        }

        private void comboBoxFilme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem filmeCombo = (ComboboxItem)comboBoxFilme.SelectedItem;


            foreach (Filme filme in filmes)
            {
                if (filme.IdFilme == filmeCombo.Value)
                {
                    filmeSelecionado = filme; break;
                }
            }
        }
    }
}
