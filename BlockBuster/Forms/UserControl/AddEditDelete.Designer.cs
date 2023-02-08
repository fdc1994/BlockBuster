namespace CamadaInterface
{
    partial class AddEditDelete
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonApagar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonApagar
            // 
            this.buttonApagar.Location = new System.Drawing.Point(213, 45);
            this.buttonApagar.Name = "buttonApagar";
            this.buttonApagar.Size = new System.Drawing.Size(176, 38);
            this.buttonApagar.TabIndex = 6;
            this.buttonApagar.Text = "buttonApagar";
            this.buttonApagar.UseVisualStyleBackColor = true;
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(17, 45);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(176, 38);
            this.buttonEditar.TabIndex = 5;
            this.buttonEditar.Text = "buttonEditar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Location = new System.Drawing.Point(70, 101);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(269, 47);
            this.buttonAdicionar.TabIndex = 7;
            this.buttonAdicionar.Text = "buttonAdicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = true;
            // 
            // AddEditDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonApagar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonAdicionar);
            this.Name = "AddEditDelete";
            this.Size = new System.Drawing.Size(406, 193);
            this.Load += new System.EventHandler(this.AddEditDelete_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Button buttonApagar;
        public Button buttonEditar;
        public Button buttonAdicionar;
    }
}
