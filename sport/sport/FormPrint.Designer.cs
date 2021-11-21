namespace sport
{
    partial class FormPrint
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridAplc = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAplc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.dataGridAplc);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 636);
            this.panel1.TabIndex = 0;
            // 
            // dataGridAplc
            // 
            this.dataGridAplc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAplc.Location = new System.Drawing.Point(35, 31);
            this.dataGridAplc.Name = "dataGridAplc";
            this.dataGridAplc.RowHeadersWidth = 51;
            this.dataGridAplc.RowTemplate.Height = 24;
            this.dataGridAplc.Size = new System.Drawing.Size(627, 529);
            this.dataGridAplc.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnPrint.ForeColor = System.Drawing.Color.LightGray;
            this.btnPrint.Location = new System.Drawing.Point(552, 587);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(97, 29);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "พิมพ์";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1363, 790);
            this.Controls.Add(this.panel1);
            this.Name = "FormPrint";
            this.Text = "FormPrint";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAplc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridAplc;
        private System.Windows.Forms.Button btnPrint;
    }
}