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

namespace CamadaInterface.Forms
{
    public partial class FormUtilizadores : Form
    {
        DataTable dataTableUtilizadores = new DataTable();
        
        public FormUtilizadores()
        {
            InitializeComponent();
        }

        private void carregarUtilizadores()
        {
            Utilizador utilizador = new Utilizador();

            string erro = String.Empty;

            dataTableUtilizadores = utilizador.ObterUtilizador(1, out erro);    
            setupViews();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carregarUtilizadores();
        }

        private void FormUtilizadores_Load(object sender, EventArgs e)
        {
            carregarUtilizadores();
        }

      

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentCell.RowIndex.ToString());
        }

        private void setupViews()
        {
            dataGridView1.DataSource = dataTableUtilizadores;
            dataGridView1.ReadOnly = true;  
            dataGridView1.SelectionMode= DataGridViewSelectionMode.FullRowSelect; 

        }
    }
}
