namespace Jaeger.Contable.WinForms.Forms {
    partial class PartidaSelectorForm {
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
            this._txtBuscar = new System.Windows.Forms.TextBox();
            this._grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtBuscar
            // 
            this._txtBuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this._txtBuscar.Location = new System.Drawing.Point(0, 0);
            this._txtBuscar.Name = "_txtBuscar";
            this._txtBuscar.Size = new System.Drawing.Size(334, 20);
            this._txtBuscar.TabIndex = 0;
            // 
            // _grid
            // 
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 20);
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(334, 291);
            this._grid.TabIndex = 1;
            // 
            // CatalogoPartidaSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._txtBuscar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatalogoPartidaSelectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CatalogoPartidaSelectorForm";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtBuscar;
        private System.Windows.Forms.DataGridView _grid;
    }
}