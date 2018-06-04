namespace FormataLayoutExcel
{
    partial class AbreExcel
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.ColunaExcel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaLayout = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btn_open = new System.Windows.Forms.Button();
            this.Ofd_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.layoutsComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColunaExcel,
            this.ColunaLayout});
            this.Grid.Location = new System.Drawing.Point(12, 72);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(372, 210);
            this.Grid.TabIndex = 5;
            // 
            // ColunaExcel
            // 
            this.ColunaExcel.HeaderText = "Coluna Excel";
            this.ColunaExcel.Name = "ColunaExcel";
            this.ColunaExcel.ReadOnly = true;
            this.ColunaExcel.Width = 150;
            // 
            // ColunaLayout
            // 
            this.ColunaLayout.HeaderText = "Coluna Layout";
            this.ColunaLayout.Name = "ColunaLayout";
            this.ColunaLayout.Width = 150;
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(219, 22);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(29, 23);
            this.btn_open.TabIndex = 3;
            this.btn_open.Text = "...";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // Ofd_OpenFile
            // 
            this.Ofd_OpenFile.Multiselect = true;
            // 
            // layoutsComboBox
            // 
            this.layoutsComboBox.FormattingEnabled = true;
            this.layoutsComboBox.Location = new System.Drawing.Point(12, 22);
            this.layoutsComboBox.Name = "layoutsComboBox";
            this.layoutsComboBox.Size = new System.Drawing.Size(201, 21);
            this.layoutsComboBox.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Confirmar Mapeamento";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(173, 293);
            this.progressBar.Maximum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(211, 23);
            this.progressBar.Step = 20;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(309, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Config";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AbreExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 328);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.layoutsComboBox);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.btn_open);
            this.Name = "AbreExcel";
            this.Text = "Organizador de Colunas";
            this.Load += new System.EventHandler(this.AbreExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.OpenFileDialog Ofd_OpenFile;
        private System.Windows.Forms.ComboBox layoutsComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaExcel;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColunaLayout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button2;
    }
}