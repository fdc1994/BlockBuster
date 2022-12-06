using CamadaInterface.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamadaInterface
{

    public partial class FormGestao : Form
    {
        Form parentForm;
        FormUtilizador formUtilizadores;
        public FormGestao(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            parentForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formUtilizadores = new FormUtilizador();
            formUtilizadores.Show();
        }
    }
}
