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
    public partial class FormLogin : Form
    {

        private FormGestao childForm;

        public FormLogin()
        {
            InitializeComponent();
            childForm = new FormGestao(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            childForm.Show();
            this.Hide();
        }
    }
}
