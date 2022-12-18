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

namespace CamadaInterface.Forms.FormUtilizadores.Dialogs
{
    public partial class FormDialogConfirmarApagar : Form
    {
        private string itemASerApagado = String.Empty;
        private string acaoAExecutar = String.Empty;
        public FormDialogConfirmarApagar(string contextString, string actionString)
        {
            InitializeComponent();
            this.itemASerApagado = contextString;
            if(actionString == null)
            {
                actionString= "apagar";
            }
            this.acaoAExecutar = actionString;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FormDialogConfirmarApagarFilme_Load(object sender, EventArgs e)
        {
            this.label1.Text = "Tem a certeza que pretende " + acaoAExecutar + " este " + itemASerApagado + "?";
        }
    }
}
