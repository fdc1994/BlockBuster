﻿namespace CamadaInterface.Forms.FormFilmes
{
    partial class FormFilmes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addEditDelete1 = new CamadaInterface.AddEditDelete();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(56, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(502, 286);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_onKeyUp);

            // 
            // buttonApagar
            // 
            this.addEditDelete1.buttonApagar.Size = new System.Drawing.Size(176, 39);
            this.addEditDelete1.buttonApagar.TabIndex = 7;
            this.addEditDelete1.buttonApagar.Text = "Apagar Filme";
            this.addEditDelete1.buttonApagar.UseVisualStyleBackColor = true;
            this.addEditDelete1.buttonApagar.Click += new System.EventHandler(this.buttonApagar_Click);
            // 
            // buttonEditar
            // 
            this.addEditDelete1.buttonEditar.Size = new System.Drawing.Size(176, 39);
            this.addEditDelete1.buttonEditar.TabIndex = 6;
            this.addEditDelete1.buttonEditar.Text = "Editar Filme";
            this.addEditDelete1.buttonEditar.UseVisualStyleBackColor = true;
            this.addEditDelete1.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonAdicionar
            // 
            this.addEditDelete1.buttonAdicionar.Size = new System.Drawing.Size(268, 46);
            this.addEditDelete1.buttonAdicionar.TabIndex = 5;
            this.addEditDelete1.buttonAdicionar.Text = "Adicionar Novo Filme";
            this.addEditDelete1.buttonAdicionar.UseVisualStyleBackColor = true;
            this.addEditDelete1.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // addEditDelete1
            // 
            this.addEditDelete1.Location = new System.Drawing.Point(113, 304);
            this.addEditDelete1.Name = "addEditDelete1";
            this.addEditDelete1.Size = new System.Drawing.Size(401, 156);
            this.addEditDelete1.TabIndex = 8;
            // 
            // FormFilmes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 491);
            this.Controls.Add(this.addEditDelete1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormFilmes";
            this.Text = "Filmes";
            this.Load += new System.EventHandler(this.FormFilmes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private AddEditDelete addEditDelete1;
    }
}