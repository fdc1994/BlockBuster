using BlockBuster;
using CamadaInterface.Forms.FormUtilizadores.Dialogs;
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

namespace CamadaInterface.Forms.FormFilmes
{
    public partial class FormFilmes : Form
    {

        DataTable dataTableFilmes = new DataTable();
        List<Filme> filmes = new List<Filme>();
        int currentSelectedIndex = 0;
        public FormFilmes()
        {
            InitializeComponent();
        }

        private void FormFilmes_Load(object sender, EventArgs e)
        {
            setup();
        }

        private void setup()
        {

            string erro = String.Empty;
            dataTableFilmes = Filme.ObterTodosOsFilmes(out erro);
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
            this.dataGridView1.DataSource = dataTableFilmes;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void setupData()
        {
            filmes.Clear();
            foreach (DataRow row in dataTableFilmes.Rows)
            {
                Filme filme = new Filme((int)row[0], (string)row[1], (int)row[2]);
                filmes.Add(filme);
            }
        }
        private Filme returnFilmeEscolhido()
        {
            return filmes[currentSelectedIndex];
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            currentSelectedIndex = dataGridView1.CurrentRow.Index;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            FormDialogEditarFilme formEditarFilme = new FormDialogEditarFilme(returnFilmeEscolhido());
            var result = formEditarFilme.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                setup();
            }
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedMovieId = returnFilmeEscolhido().IdFilme;
                FormDialogConfirmarApagar formApagarFilme = new FormDialogConfirmarApagar("Filme");
                    var result = formApagarFilme.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string erro = String.Empty;
                        bool resultDelete = CamadaDados.Filmes.ApagarFilme(selectedMovieId, out erro);

                        if (erro == String.Empty && resultDelete)
                        {
                            setup();
                            MessageBox.Show("Sucesso", "Filme Apagado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

            }catch(Exception ex) {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }
    }
}
