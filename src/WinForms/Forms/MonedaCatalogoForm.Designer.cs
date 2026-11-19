namespace Jaeger.Contable.WinForms.Forms {
    partial class MonedaCatalogoForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.IdMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESPAUTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CveSAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.codigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrefijo = new System.Windows.Forms.Label();
            this.txtPrefijo = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lblTipoCambio = new System.Windows.Forms.Label();
            this.numTipoCambio = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.lblDespAuto = new System.Windows.Forms.Label();
            this.txtDespAuto = new System.Windows.Forms.TextBox();
            this.lblClaveSAT = new System.Windows.Forms.Label();
            this.txtClassSat = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTipoCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(14, 16);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 14;
            this.lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(60, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(397, 20);
            this.txtBuscar.TabIndex = 0;
            // 
            // gridData
            // 
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMoneda,
            this.Nombre,
            this.Prefijo,
            this.Fecha,
            this.TipoCambio,
            this.Monto,
            this.DESPAUTO,
            this.CveSAT});
            this.gridData.Location = new System.Drawing.Point(12, 38);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersVisible = false;
            this.gridData.Size = new System.Drawing.Size(678, 150);
            this.gridData.TabIndex = 1;
            // 
            // IdMoneda
            // 
            this.IdMoneda.DataPropertyName = "IdMoneda";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Format = "000";
            dataGridViewCellStyle25.NullValue = null;
            this.IdMoneda.DefaultCellStyle = dataGridViewCellStyle25;
            this.IdMoneda.FillWeight = 60F;
            this.IdMoneda.HeaderText = "Clave";
            this.IdMoneda.Name = "IdMoneda";
            this.IdMoneda.ReadOnly = true;
            this.IdMoneda.Width = 60;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.FillWeight = 180F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 180;
            // 
            // Prefijo
            // 
            this.Prefijo.DataPropertyName = "Prefijo";
            this.Prefijo.FillWeight = 80F;
            this.Prefijo.HeaderText = "Prefijo";
            this.Prefijo.Name = "Prefijo";
            this.Prefijo.ReadOnly = true;
            this.Prefijo.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.Format = "dd/MM/yyyy";
            dataGridViewCellStyle26.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle26;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // TipoCambio
            // 
            this.TipoCambio.DataPropertyName = "TipoCambio";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "N2";
            dataGridViewCellStyle27.NullValue = null;
            this.TipoCambio.DefaultCellStyle = dataGridViewCellStyle27;
            this.TipoCambio.HeaderText = "T. Cambio";
            this.TipoCambio.Name = "TipoCambio";
            this.TipoCambio.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle28.Format = "N2";
            dataGridViewCellStyle28.NullValue = null;
            this.Monto.DefaultCellStyle = dataGridViewCellStyle28;
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // DESPAUTO
            // 
            this.DESPAUTO.DataPropertyName = "DESPAUTO";
            this.DESPAUTO.FillWeight = 80F;
            this.DESPAUTO.HeaderText = "Desp. auto";
            this.DESPAUTO.Name = "DESPAUTO";
            this.DESPAUTO.ReadOnly = true;
            this.DESPAUTO.Width = 80;
            // 
            // CveSAT
            // 
            this.CveSAT.DataPropertyName = "CveSAT";
            this.CveSAT.HeaderText = "Cve. SAT";
            this.CveSAT.Name = "CveSAT";
            this.CveSAT.ReadOnly = true;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(9, 206);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            // 
            // codigo
            // 
            this.codigo.Location = new System.Drawing.Point(55, 202);
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Size = new System.Drawing.Size(86, 20);
            this.codigo.TabIndex = 2;
            this.codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(147, 206);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(200, 202);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(339, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // lblPrefijo
            // 
            this.lblPrefijo.AutoSize = true;
            this.lblPrefijo.Location = new System.Drawing.Point(545, 206);
            this.lblPrefijo.Name = "lblPrefijo";
            this.lblPrefijo.Size = new System.Drawing.Size(39, 13);
            this.lblPrefijo.TabIndex = 0;
            this.lblPrefijo.Text = "Prefijo:";
            // 
            // txtPrefijo
            // 
            this.txtPrefijo.Location = new System.Drawing.Point(590, 202);
            this.txtPrefijo.Name = "txtPrefijo";
            this.txtPrefijo.Size = new System.Drawing.Size(100, 20);
            this.txtPrefijo.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(9, 236);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Location = new System.Drawing.Point(55, 235);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(78, 17);
            this.chkFecha.TabIndex = 4;
            this.chkFecha.Text = "Usar fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(139, 232);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(208, 20);
            this.dtFecha.TabIndex = 5;
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.AutoSize = true;
            this.lblTipoCambio.Location = new System.Drawing.Point(353, 236);
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.Size = new System.Drawing.Size(83, 13);
            this.lblTipoCambio.TabIndex = 0;
            this.lblTipoCambio.Text = "Tipo de cambio:";
            // 
            // numTipoCambio
            // 
            this.numTipoCambio.Location = new System.Drawing.Point(442, 232);
            this.numTipoCambio.Name = "numTipoCambio";
            this.numTipoCambio.Size = new System.Drawing.Size(97, 20);
            this.numTipoCambio.TabIndex = 3;
            this.numTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(544, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Monto:";
            // 
            // numMonto
            // 
            this.numMonto.Location = new System.Drawing.Point(590, 232);
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(97, 20);
            this.numMonto.TabIndex = 3;
            this.numMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDespAuto
            // 
            this.lblDespAuto.AutoSize = true;
            this.lblDespAuto.Location = new System.Drawing.Point(14, 267);
            this.lblDespAuto.Name = "lblDespAuto";
            this.lblDespAuto.Size = new System.Drawing.Size(69, 13);
            this.lblDespAuto.TabIndex = 0;
            this.lblDespAuto.Text = "DESPAUTO:";
            // 
            // txtDespAuto
            // 
            this.txtDespAuto.Location = new System.Drawing.Point(89, 263);
            this.txtDespAuto.Name = "txtDespAuto";
            this.txtDespAuto.Size = new System.Drawing.Size(79, 20);
            this.txtDespAuto.TabIndex = 1;
            // 
            // lblClaveSAT
            // 
            this.lblClaveSAT.AutoSize = true;
            this.lblClaveSAT.Location = new System.Drawing.Point(184, 267);
            this.lblClaveSAT.Name = "lblClaveSAT";
            this.lblClaveSAT.Size = new System.Drawing.Size(61, 13);
            this.lblClaveSAT.TabIndex = 0;
            this.lblClaveSAT.Text = "Clave SAT:";
            // 
            // txtClassSat
            // 
            this.txtClassSat.Location = new System.Drawing.Point(251, 263);
            this.txtClassSat.Name = "txtClassSat";
            this.txtClassSat.Size = new System.Drawing.Size(87, 20);
            this.txtClassSat.TabIndex = 1;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.Location = new System.Drawing.Point(12, 304);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(93, 304);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(174, 304);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(615, 304);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // MonedaCatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 339);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.chkFecha);
            this.Controls.Add(this.numMonto);
            this.Controls.Add(this.numTipoCambio);
            this.Controls.Add(this.codigo);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.txtPrefijo);
            this.Controls.Add(this.txtClassSat);
            this.Controls.Add(this.txtDespAuto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblClaveSAT);
            this.Controls.Add(this.lblPrefijo);
            this.Controls.Add(this.lblDespAuto);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTipoCambio);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblBuscar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonedaCatalogoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MonedaCatalogoForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTipoCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox codigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrefijo;
        private System.Windows.Forms.TextBox txtPrefijo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label lblTipoCambio;
        private System.Windows.Forms.NumericUpDown numTipoCambio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label lblDespAuto;
        private System.Windows.Forms.TextBox txtDespAuto;
        private System.Windows.Forms.Label lblClaveSAT;
        private System.Windows.Forms.TextBox txtClassSat;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESPAUTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CveSAT;
    }
}