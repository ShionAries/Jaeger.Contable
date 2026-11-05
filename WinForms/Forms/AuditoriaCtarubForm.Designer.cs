namespace Jaeger.Contable.WinForms.Forms {
    partial class AuditoriaCtarubForm {
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
            this.encabezado = new System.Windows.Forms.Panel();
            this._soloErrores = new System.Windows.Forms.Button();
            this._resumen = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this._detalle = new System.Windows.Forms.TextBox();
            this.encabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // encabezado
            // 
            this.encabezado.Controls.Add(this._soloErrores);
            this.encabezado.Controls.Add(this._resumen);
            this.encabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.encabezado.Location = new System.Drawing.Point(0, 0);
            this.encabezado.Name = "encabezado";
            this.encabezado.Size = new System.Drawing.Size(884, 34);
            this.encabezado.TabIndex = 0;
            // 
            // _soloErrores
            // 
            this._soloErrores.Dock = System.Windows.Forms.DockStyle.Right;
            this._soloErrores.Location = new System.Drawing.Point(739, 0);
            this._soloErrores.Name = "_soloErrores";
            this._soloErrores.Size = new System.Drawing.Size(145, 34);
            this._soloErrores.TabIndex = 1;
            this._soloErrores.Text = "Mostrar solo errores";
            this._soloErrores.UseVisualStyleBackColor = true;
            // 
            // _resumen
            // 
            this._resumen.AutoSize = true;
            this._resumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this._resumen.Location = new System.Drawing.Point(0, 0);
            this._resumen.Name = "_resumen";
            this._resumen.Padding = new System.Windows.Forms.Padding(10, 8, 10, 0);
            this._resumen.Size = new System.Drawing.Size(55, 21);
            this._resumen.TabIndex = 0;
            this._resumen.Text = "label1";
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.AllowUserToDeleteRows = false;
            this._grid.AllowUserToResizeRows = false;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(0, 34);
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.Size = new System.Drawing.Size(884, 317);
            this._grid.TabIndex = 1;
            // 
            // _detalle
            // 
            this._detalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._detalle.Location = new System.Drawing.Point(0, 351);
            this._detalle.Multiline = true;
            this._detalle.Name = "_detalle";
            this._detalle.ReadOnly = true;
            this._detalle.Size = new System.Drawing.Size(884, 110);
            this._detalle.TabIndex = 2;
            // 
            // AuditoriaCtarubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._detalle);
            this.Controls.Add(this.encabezado);
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.Name = "AuditoriaCtarubForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auditoría de CTARUB";
            this.encabezado.ResumeLayout(false);
            this.encabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel encabezado;
        private System.Windows.Forms.Label _resumen;
        private System.Windows.Forms.Button _soloErrores;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _detalle;
    }
}