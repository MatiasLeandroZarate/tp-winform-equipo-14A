namespace TPWinForm_Equipo14A
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvART = new System.Windows.Forms.DataGridView();
            this.pbx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvART)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvART
            // 
            this.dgvART.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvART.Location = new System.Drawing.Point(12, 71);
            this.dgvART.Name = "dgvART";
            this.dgvART.RowHeadersWidth = 51;
            this.dgvART.Size = new System.Drawing.Size(495, 167);
            this.dgvART.TabIndex = 0;
            this.dgvART.SelectionChanged += new System.EventHandler(this.dgvART_SelectionChanged);
            // 
            // pbx
            // 
            this.pbx.Location = new System.Drawing.Point(524, 71);
            this.pbx.Name = "pbx";
            this.pbx.Size = new System.Drawing.Size(252, 167);
            this.pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx.TabIndex = 2;
            this.pbx.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(848, 331);
            this.Controls.Add(this.pbx);
            this.Controls.Add(this.dgvART);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvART)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvART;
        private System.Windows.Forms.PictureBox pbx;
    }
}

