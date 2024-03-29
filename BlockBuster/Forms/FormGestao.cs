﻿using BlockBuster;
using CamadaInterface.Forms;
using CamadaInterface.Forms.FormAluno;
using CamadaInterface.Forms.FormFilmes;
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
        FormFilmes formFilmes;
        FormReservas formReservas;
        FormAluno formAluno;
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
            if(formUtilizadores == null || formUtilizadores.IsDisposed)
            {
                formUtilizadores = new FormUtilizador();
                formUtilizadores.Show();
            } else
            {
                formUtilizadores.BringToFront();
            }
           
        }

        private void FormGestao_Load(object sender, EventArgs e)
        {
            string name = Program.GetUtilizador().NomeUtilizador;
            this.labelWelcome.Text = "Welcome " + name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (formFilmes == null || formFilmes.IsDisposed)
            {
                formFilmes = new FormFilmes();
                formFilmes.Show();
            }
            else
            {
                formFilmes.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formReservas == null || formReservas.IsDisposed)
            {
                formReservas = new FormReservas();
                formReservas.Show();
            }
            else
            {
                formReservas.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (formAluno == null || formAluno.IsDisposed)
            {
                formAluno = new FormAluno();
                formAluno.Show();
            }
            else
            {
                formAluno.BringToFront();
            }
        }
    }
}
