namespace Jaeger.Contable.WinForms.Forms {
    partial class PartidaCatalogoForm {
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
            this.lblCatalogo = new System.Windows.Forms.Label();
            this._cmbCatalogo = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this._txtBuscar = new System.Windows.Forms.TextBox();
            this._grid = new System.Windows.Forms.DataGridView();
            this._txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this._txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this._btnNuevo = new System.Windows.Forms.Button();
            this._btnGuardar = new System.Windows.Forms.Button();
            this._btnEliminar = new System.Windows.Forms.Button();
            this._btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCatalogo
            // 
            this.lblCatalogo.AutoSize = true;
            this.lblCatalogo.Location = new System.Drawing.Point(12, 16);
            this.lblCatalogo.Name = "lblCatalogo";
            this.lblCatalogo.Size = new System.Drawing.Size(52, 13);
            this.lblCatalogo.TabIndex = 0;
            this.lblCatalogo.Text = "Catálogo:";
            // 
            // _cmbCatalogo
            // 
            this._cmbCatalogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbCatalogo.FormattingEnabled = true;
            this._cmbCatalogo.Location = new System.Drawing.Point(75, 12);
            this._cmbCatalogo.Name = "_cmbCatalogo";
            this._cmbCatalogo.Size = new System.Drawing.Size(174, 21);
            this._cmbCatalogo.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(261, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // _txtBuscar
            // 
            this._txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtBuscar.Location = new System.Drawing.Point(310, 12);
            this._txtBuscar.Name = "_txtBuscar";
            this._txtBuscar.Size = new System.Drawing.Size(235, 20);
            this._txtBuscar.TabIndex = 2;
            // 
            // _grid
            // 
            this._grid.AllowUserToAddRows = false;
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 45);
            this._grid.MultiSelect = false;
            this._grid.Name = "_grid";
            this._grid.ReadOnly = true;
            this._grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._grid.Size = new System.Drawing.Size(536, 320);
            this._grid.TabIndex = 3;
            // 
            // _txtId
            // 
            this._txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtId.Location = new System.Drawing.Point(75, 378);
            this._txtId.Name = "_txtId";
            this._txtId.Size = new System.Drawing.Size(110, 20);
            this._txtId.TabIndex = 5;
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 382);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(43, 13);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "Código:";
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescripcion.Location = new System.Drawing.Point(280, 378);
            this._txtDescripcion.MaxLength = 40;
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(268, 20);
            this._txtDescripcion.TabIndex = 7;
            // 
            // lblDesc
            // 
            this.lblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(205, 382);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(66, 13);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Descripción:";
            // 
            // _btnNuevo
            // 
            this._btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnNuevo.Location = new System.Drawing.Point(12, 412);
            this._btnNuevo.Name = "_btnNuevo";
            this._btnNuevo.Size = new System.Drawing.Size(75, 23);
            this._btnNuevo.TabIndex = 8;
            this._btnNuevo.Text = "Nuevo";
            this._btnNuevo.UseVisualStyleBackColor = true;
            // 
            // _btnGuardar
            // 
            this._btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnGuardar.Location = new System.Drawing.Point(93, 412);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(75, 23);
            this._btnGuardar.TabIndex = 9;
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.UseVisualStyleBackColor = true;
            // 
            // _btnEliminar
            // 
            this._btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnEliminar.Location = new System.Drawing.Point(174, 412);
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(75, 23);
            this._btnEliminar.TabIndex = 9;
            this._btnEliminar.Text = "Eliminar";
            this._btnEliminar.UseVisualStyleBackColor = true;
            // 
            // _btnCerrar
            // 
            this._btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCerrar.Location = new System.Drawing.Point(470, 412);
            this._btnCerrar.Name = "_btnCerrar";
            this._btnCerrar.Size = new System.Drawing.Size(75, 23);
            this._btnCerrar.TabIndex = 9;
            this._btnCerrar.Text = "Cerrar";
            this._btnCerrar.UseVisualStyleBackColor = true;
            // 
            // PartidaCatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 447);
            this.Controls.Add(this._btnCerrar);
            this.Controls.Add(this._btnEliminar);
            this.Controls.Add(this._btnGuardar);
            this.Controls.Add(this._btnNuevo);
            this.Controls.Add(this._txtDescripcion);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this._txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._txtBuscar);
            this.Controls.Add(this._cmbCatalogo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.lblCatalogo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PartidaCatalogoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mantenimiento de catálogos de partidas";
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCatalogo;
        private System.Windows.Forms.ComboBox _cmbCatalogo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox _txtBuscar;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox _txtDescripcion;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button _btnNuevo;
        private System.Windows.Forms.Button _btnGuardar;
        private System.Windows.Forms.Button _btnEliminar;
        private System.Windows.Forms.Button _btnCerrar;
    }
}