namespace CamadaInterface
{
    partial class FormDialogEditarUtilizador
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.comboBoxCargo = new System.Windows.Forms.ComboBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cargo";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(133, 19);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(205, 31);
            this.textBoxNome.TabIndex = 3;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(133, 74);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(205, 31);
            this.textBoxPass.TabIndex = 4;
            // 
            // comboBoxCargo
            // 
            this.comboBoxCargo.FormattingEnabled = true;
            this.comboBoxCargo.Location = new System.Drawing.Point(133, 123);
            this.comboBoxCargo.Name = "comboBoxCargo";
            this.comboBoxCargo.Size = new System.Drawing.Size(205, 33);
            this.comboBoxCargo.TabIndex = 5;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(177, 181);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(112, 34);
            this.buttonGuardar.TabIndex = 6;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // FormDialogEditarUtilizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 267);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.comboBoxCargo);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.Name = "FormDialogEditarUtilizador";
            this.Text = "Editar Utilizador";
            this.Load += new System.EventHandler(this.FormDialogEditarUtilizador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxNome;
        private TextBox textBoxPass;
        private ComboBox comboBoxCargo;
        private Button buttonGuardar;
    }
}