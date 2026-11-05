using System.Windows.Forms;

namespace Jaeger.Contable.WinForms.Forms {
    partial class ConceptoSelectorPolizaForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this._txtBuscar = new System.Windows.Forms.TextBox();
            this._grid = new System.Windows.Forms.DataGridView();
            this._btnNuevo = new System.Windows.Forms.Button();
            this._btnAceptar = new System.Windows.Forms.Button();
            this._btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // _txtBuscar
            // 
            this._txtBuscar.Location = new System.Drawing.Point(67, 19);
            this._txtBuscar.Name = "_txtBuscar";
            this._txtBuscar.Size = new System.Drawing.Size(315, 20);
            this._txtBuscar.TabIndex = 1;
            this._txtBuscar.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;
            // 
            // _grid
            // 
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 45);
            this._grid.Name = "_grid";
            this._grid.Size = new System.Drawing.Size(373, 305);
            this._grid.TabIndex = 2;
            // 
            // _btnNuevo
            // 
            this._btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnNuevo.Location = new System.Drawing.Point(145, 364);
            this._btnNuevo.Name = "_btnNuevo";
            this._btnNuevo.Size = new System.Drawing.Size(75, 23);
            this._btnNuevo.TabIndex = 3;
            this._btnNuevo.Text = "Nuevo";
            this._btnNuevo.UseVisualStyleBackColor = true;
            // 
            // _btnAceptar
            // 
            this._btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAceptar.Location = new System.Drawing.Point(226, 364);
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(75, 23);
            this._btnAceptar.TabIndex = 3;
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.UseVisualStyleBackColor = true;
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancelar.Location = new System.Drawing.Point(307, 364);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(75, 23);
            this._btnCancelar.TabIndex = 3;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            // 
            // SeleccionConceptoPolizaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 399);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this._btnAceptar);
            this.Controls.Add(this._btnNuevo);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._txtBuscar);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionConceptoPolizaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SeleccionConceptoPolizaForm";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtBuscar;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.Button _btnNuevo;
        private System.Windows.Forms.Button _btnAceptar;
        private System.Windows.Forms.Button _btnCancelar;
    }
}