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
using Ferramenta;
using Microsoft.VisualBasic.ApplicationServices;
using CamadaDados;
using CamadaInterface.Forms.FormUtilizadores.Dialogs;
using BlockBuster;

namespace CamadaInterface.Forms
{
    public partial class FormUtilizador : Form
    {
        DataTable dataTableUtilizadores = new DataTable();
        List<Utilizador> utilizadores = new List<Utilizador>();
        int currentSelectedIndex = 0;
        
        public FormUtilizador()
        {
            InitializeComponent();
        }
        private void FormUtilizadores_Load(object sender, EventArgs e)
        {
            setup();
        }

        private void setup() {

            string erro = String.Empty;
            dataTableUtilizadores = Utilizador.ObterTodosOsUtilizadores(out erro);
            Ferramenta.Ferramenta.ResolverEnumsUtilizadores(dataTableUtilizadores);
            dataTableUtilizadores.Columns[2].ColumnMapping = MappingType.Hidden;
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
            dataGridView1.DataSource = dataTableUtilizadores;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
        }

        private void setupData()
        {
            utilizadores.Clear();
           foreach(DataRow row in dataTableUtilizadores.Rows)
            {
                Utilizador utilizador = new Utilizador((int)row[0], (string)row[1], (string)row[2], (EnumUtilizadores)row[3]);
                utilizadores.Add(utilizador);
            }
        }


        private void buttonEditar_Click(object sender, EventArgs e)
        {
            FormDialogEditarUtilizador formEditarUtilizador = new FormDialogEditarUtilizador(returnUtilizadorEscolhido()); 
            var result = formEditarUtilizador.ShowDialog();

            if(result == DialogResult.Cancel)
            {
                setup();
            }
            
        }

        private Utilizador returnUtilizadorEscolhido()
        {
            return utilizadores[currentSelectedIndex];
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
           currentSelectedIndex = dataGridView1.CurrentRow.Index;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            FormDialogAdicionarUtilizador formAdicionarUtilizador = new FormDialogAdicionarUtilizador(utilizadores.Count+1);  
            var result = formAdicionarUtilizador.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                setup();
            }
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            int selectedUserId = returnUtilizadorEscolhido().IdUtilizador;
            if (selectedUserId != Program.GetUtilizador().IdUtilizador)
            {
                FormDialogConfirmarApagar formApagarUtilizador = new FormDialogConfirmarApagar();
                var result = formApagarUtilizador.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string erro = String.Empty;
                    bool resultDelete = CamadaDados.Utilizadores.ApagarUtilizador(selectedUserId, out erro);

                    if (erro == String.Empty && resultDelete)
                    {
                        setup();
                        MessageBox.Show("Sucesso", "Utilizador Apagado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            } else
            {
                MessageBox.Show("Não pode apagar o utilizador com sessão iniciada. Por favor mude de sessão e tente de novo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
