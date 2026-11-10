namespace Jaeger.Contable.WinForms.Forms {
    partial class ActivoFijoHistoricoForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gridData = new System.Windows.Forms.DataGridView();
            this._txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblTipoDeActivo = new System.Windows.Forms.Label();
            this._cmbTabla = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // gridData
            // 
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Location = new System.Drawing.Point(13, 36);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersVisible = false;
            this.gridData.Size = new System.Drawing.Size(774, 482);
            this.gridData.TabIndex = 27;
            // 
            // _txtBuscar
            // 
            this._txtBuscar.Location = new System.Drawing.Point(304, 10);
            this._txtBuscar.Name = "_txtBuscar";
            this._txtBuscar.Size = new System.Drawing.Size(397, 20);
            this._txtBuscar.TabIndex = 26;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(258, 14);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 25;
            this.lblBuscar.Text = "Buscar";
            // 
            // lblTipoDeActivo
            // 
            this.lblTipoDeActivo.AutoSize = true;
            this.lblTipoDeActivo.Location = new System.Drawing.Point(15, 12);
            this.lblTipoDeActivo.Name = "lblTipoDeActivo";
            this.lblTipoDeActivo.Size = new System.Drawing.Size(37, 13);
            this.lblTipoDeActivo.TabIndex = 28;
            this.lblTipoDeActivo.Text = "Tabla:";
            // 
            // _cmbTabla
            // 
            this._cmbTabla.Location = new System.Drawing.Point(58, 9);
            this._cmbTabla.Name = "_cmbTabla";
            this._cmbTabla.Size = new System.Drawing.Size(194, 21);
            this._cmbTabla.TabIndex = 29;
            // 
            // ActivoFijoHistoricoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.lblTipoDeActivo);
            this.Controls.Add(this._cmbTabla);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this._txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActivoFijoHistoricoForm";
            this.Text = "ActivoFijoHistoricoForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.TextBox _txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblTipoDeActivo;
        private System.Windows.Forms.ComboBox _cmbTabla;
    }
}