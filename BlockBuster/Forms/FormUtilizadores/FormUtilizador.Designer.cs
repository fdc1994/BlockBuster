namespace CamadaInterface.Forms
{
    partial class FormUtilizador
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
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(47, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(513, 453);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView_SelectionChanged);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_onKeyUp);
            // 
            // addEditDelete1
            // 
            this.addEditDelete1.Location = new System.Drawing.Point(93, 471);
            this.addEditDelete1.Name = "addEditDelete1";
            this.addEditDelete1.Size = new System.Drawing.Size(419, 180);
            this.addEditDelete1.TabIndex = 2;

            // 
            // buttonEditar
            // 

            this.addEditDelete1.buttonEditar.Size = new System.Drawing.Size(176, 38);
            this.addEditDelete1.buttonEditar.TabIndex = 3;
            this.addEditDelete1.buttonEditar.Text = "Editar Utilizador";
            this.addEditDelete1.buttonEditar.UseVisualStyleBackColor = true;
            this.addEditDelete1.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonApagar
            // 
            this.addEditDelete1.buttonApagar.TabIndex = 4;
            this.addEditDelete1.buttonApagar.Text = "Apagar Utilizador";
            this.addEditDelete1.buttonApagar.UseVisualStyleBackColor = true;
            this.addEditDelete1.buttonApagar.Click += new System.EventHandler(this.buttonApagar_Click);

            // 
            // buttonAdicionar
            // 
            this.addEditDelete1.buttonAdicionar.TabIndex = 5;
            this.addEditDelete1.buttonAdicionar.Text = "Adiconar Utilizador";
            this.addEditDelete1.buttonAdicionar.UseVisualStyleBackColor = true;
            this.addEditDelete1.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);

            // 
            // FormUtilizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 650);
            this.Controls.Add(this.addEditDelete1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUtilizador";
            this.Text = "Utilizadores";
            this.Load += new System.EventHandler(this.FormUtilizadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dataGridView1;
        private AddEditDelete addEditDelete1;
    }
}