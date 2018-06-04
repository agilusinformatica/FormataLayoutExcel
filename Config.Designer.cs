namespace FormataLayoutExcel
{
    partial class Config
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
            this.okButton = new System.Windows.Forms.Button();
            this.servidorLabel = new System.Windows.Forms.Label();
            this.servidorTextBox = new System.Windows.Forms.TextBox();
            this.bancoDadosLabel = new System.Windows.Forms.Label();
            this.bancoDadosTextBox = new System.Windows.Forms.TextBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(108, 132);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 30);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // servidorLabel
            // 
            this.servidorLabel.AutoSize = true;
            this.servidorLabel.Location = new System.Drawing.Point(12, 37);
            this.servidorLabel.Name = "servidorLabel";
            this.servidorLabel.Size = new System.Drawing.Size(46, 13);
            this.servidorLabel.TabIndex = 1;
            this.servidorLabel.Text = "Servidor";
            // 
            // servidorTextBox
            // 
            this.servidorTextBox.Location = new System.Drawing.Point(103, 34);
            this.servidorTextBox.Name = "servidorTextBox";
            this.servidorTextBox.Size = new System.Drawing.Size(183, 20);
            this.servidorTextBox.TabIndex = 2;
            // 
            // bancoDadosLabel
            // 
            this.bancoDadosLabel.AutoSize = true;
            this.bancoDadosLabel.Location = new System.Drawing.Point(12, 76);
            this.bancoDadosLabel.Name = "bancoDadosLabel";
            this.bancoDadosLabel.Size = new System.Drawing.Size(85, 13);
            this.bancoDadosLabel.TabIndex = 3;
            this.bancoDadosLabel.Text = "Banco de dados";
            // 
            // bancoDadosTextBox
            // 
            this.bancoDadosTextBox.Location = new System.Drawing.Point(103, 73);
            this.bancoDadosTextBox.Name = "bancoDadosTextBox";
            this.bancoDadosTextBox.Size = new System.Drawing.Size(183, 20);
            this.bancoDadosTextBox.TabIndex = 4;
            // 
            // cancelarButton
            // 
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(211, 132);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 30);
            this.cancelarButton.TabIndex = 5;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 174);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.bancoDadosTextBox);
            this.Controls.Add(this.bancoDadosLabel);
            this.Controls.Add(this.servidorTextBox);
            this.Controls.Add(this.servidorLabel);
            this.Controls.Add(this.okButton);
            this.Name = "Config";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label servidorLabel;
        private System.Windows.Forms.TextBox servidorTextBox;
        private System.Windows.Forms.Label bancoDadosLabel;
        private System.Windows.Forms.TextBox bancoDadosTextBox;
        private System.Windows.Forms.Button cancelarButton;
    }
}