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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FerramentaReservas;
using Microsoft.VisualBasic.ApplicationServices;
using CamadaDados;
using CamadaInterface.Forms.FormUtilizadores.Dialogs;
using BlockBuster;

namespace CamadaInterface.Forms
{
    public partial class FormReservas : Form
    {
        DataTable dataTableReservas = new DataTable();
        List<Reserva> reservas = new List<Reserva>();
        int currentSelectedIndex = 0;

        public FormReservas()
        {
            InitializeComponent();
        }
        private void FormUtilizadores_Load(object sender, EventArgs e)
        {
            setup();
        }

        private void setup()
        {

            string erro = String.Empty;
            dataTableReservas = Reserva.ObterTodasAsReservas(out erro);
            FerramentaReservas.FerramentaReservas.ResolverEnumsEncomendas(dataTableReservas);
            if (erro != String.Empty)
            {
                MessageBox.Show("Erro: " + erro);
                this.Close();
            }
            else
            {
                setupData();
                setupViews();
            }
        }

        private void setupViews()
        {
            dataGridView1.DataSource = dataTableReservas;
            dataGridView1.ReadOnly = true;
            dataGridView1.StandardTab = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if(reservas.Count == 0) {
                //desativar botões para evitar erros e dar uma ajuda visual ao utilizador
                addEditDelete1.buttonApagar.Enabled = false;
                addEditDelete1.buttonEditar.Enabled = false;
            }
            else
            {
                addEditDelete1.buttonApagar.Enabled = true;
                addEditDelete1.buttonEditar.Enabled = true;
            }
        }

        private void setupData()
        {

            reservas.Clear();
            foreach (DataRow row in dataTableReservas.Rows)
            {
                if (row[2] == DBNull.Value)
                {
                    row[2] = new DateTime();
                }
                Reserva reserva = new Reserva((int)row[0], (DateTime)row[1], (Nullable<DateTime>)row[2] ?? new DateTime(), (int)row[3], (string)row[4], (int)row[5], (string)row[6], (EnumEncomendas)row[7]);
                reservas.Add(reserva);
            }
        }


        private void buttonTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                Reserva reserva = returnReservaEscolhida();
                int idReserva = reserva.IDReserva;
                String nomeFilme = reserva.NomeFilme;
                FormDialogConfirmarApagar formApagarReserva = new FormDialogConfirmarApagar("Reserva", "terminar");
                if(reserva.Estado != EnumEncomendas.Terminada)
                {
                    var result = formApagarReserva.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string erro = String.Empty;
                        bool resultUpdateFilme = CamadaDados.Filmes.AtualizarFilme(idReserva, 1, nomeFilme, out erro);

                        if (erro == String.Empty && resultUpdateFilme)
                        {
                            bool resultDelete = CamadaDados.Reservas.TerminarReserva(idReserva, out erro);
                            if (erro == String.Empty && resultUpdateFilme)
                            {
                                setup();
                            }
                            else
                            {
                                MessageBox.Show("Erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }

                    }
                } else
                {
                    MessageBox.Show("Esta encomenda já se encontra terminada" ,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private Reserva returnReservaEscolhida()
        {
            if (currentSelectedIndex != -1)
            {
                return reservas[currentSelectedIndex];
            }
            else
            {
                return null;
            }

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try { currentSelectedIndex = dataGridView1.CurrentRow.Index; }
            catch (Exception ex)
            {
                currentSelectedIndex = -1;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            FormDialogAdicionarReserva formAdicionarReserva = new FormDialogAdicionarReserva();
            if(!formAdicionarReserva.IsDisposed)
            {
                var result = formAdicionarReserva.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    setup();
                }
            } else
            {
                MessageBox.Show("Por favor verifique os stocks de filmes e utilizadores disponíveis", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            try
            {
                int idReserva = returnReservaEscolhida().IDReserva;
                String nomeFilme = returnReservaEscolhida().NomeFilme;

                FormDialogConfirmarApagar formApagarReserva = new FormDialogConfirmarApagar("Reserva", null);
                var result = formApagarReserva.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string erro = String.Empty;
                    bool resultUpdateFilme = CamadaDados.Filmes.AtualizarFilme(idReserva, 1, nomeFilme, out erro);

                    if (erro == String.Empty && resultUpdateFilme)
                    {
                        bool resultDelete = CamadaDados.Reservas.ApagarReserva(idReserva, out erro);
                        if (erro == String.Empty && resultUpdateFilme)
                        {
                            setup();
                        }
                        else
                        {
                            MessageBox.Show("Erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dataGridView1_onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                int row = dataGridView1.CurrentRow.Index;
                int col = dataGridView1.CurrentCell.ColumnIndex;
                try { currentSelectedIndex = dataGridView1.CurrentRow.Index; }
                catch (Exception ex)
                {
                    currentSelectedIndex = -1;
                }
            }
        }
    }

    
}
