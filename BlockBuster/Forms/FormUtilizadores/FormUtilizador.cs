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
            utilizadores.Clear();
            dataTableUtilizadores = Utilizador.ObterTodosOsUtilizadores(out erro);
            FerramentaUtilizadores.FerramentaUtilizadores.ResolverEnumsUtilizadores(dataTableUtilizadores);
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
            dataGridView1.StandardTab = true;
            dataGridView1.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
            if(!Program.GetUtilizador().UtilizadorEAdmin() || utilizadores.Count == 0)
            {
                //só admins e gerentes podem editar ou apagar utilizadores
                //colaboradores só podem adicionar clientes
                buttonApagar.Enabled = false;
                buttonEditar.Enabled = false;
            }
            else
            {
                buttonApagar.Enabled = true;
                buttonEditar.Enabled = true;
            }
        }

        private void setupData()
        {
           foreach(DataRow row in dataTableUtilizadores.Rows)
            {
                Utilizador utilizador = new Utilizador((int)row[0], (string)row[1], (string)row[2], (FerramentaUtilizadores.EnumUtilizadores)row[3]);
                utilizadores.Add(utilizador);
            }
        }


        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                FormDialogEditarUtilizador formEditarUtilizador = new FormDialogEditarUtilizador(returnUtilizadorEscolhido());
                var result = formEditarUtilizador.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    setup();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
           
            
        }

        private Utilizador returnUtilizadorEscolhido()
        {
            return utilizadores[currentSelectedIndex];
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
            FormDialogAdicionarUtilizador formAdicionarUtilizador = new FormDialogAdicionarUtilizador();  
            var result = formAdicionarUtilizador.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                setup();
            }
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedUserId = returnUtilizadorEscolhido().IdUtilizador;
                if (selectedUserId != Program.GetUtilizador().IdUtilizador)
                {
                    FormDialogConfirmarApagar formApagarUtilizador = new FormDialogConfirmarApagar("Utilizador", null);
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
                }
                else
                {
                    MessageBox.Show("Não pode apagar o utilizador com sessão iniciada. Por favor mude de sessão e tente de novo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
