namespace Jaeger.Contable.Forms {
    partial class PolizaCapturaForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolizaCapturaForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TPoliza = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.btnAgregarPartida = new System.Windows.Forms.ToolStripButton();
            this.btnRemoverPartida = new System.Windows.Forms.ToolStripButton();
            this.btnDuplicarPartida = new System.Windows.Forms.ToolStripButton();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.btnConcepto = new System.Windows.Forms.Button();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.datFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.gridPartidas = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDebe = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHaber = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NumeroCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebeHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TPoliza.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPartidas)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TPoliza
            // 
            this.TPoliza.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.Separator1,
            this.Separator2,
            this.btnCerrar});
            this.TPoliza.Location = new System.Drawing.Point(0, 0);
            this.TPoliza.Name = "TPoliza";
            this.TPoliza.Size = new System.Drawing.Size(754, 25);
            this.TPoliza.TabIndex = 0;
            this.TPoliza.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(53, 22);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCerrar
            // 
            this.btnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(43, 22);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAgregarPartida
            // 
            this.btnAgregarPartida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAgregarPartida.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarPartida.Image")));
            this.btnAgregarPartida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarPartida.Name = "btnAgregarPartida";
            this.btnAgregarPartida.Size = new System.Drawing.Size(53, 22);
            this.btnAgregarPartida.Text = "Agregar";
            this.btnAgregarPartida.Click += new System.EventHandler(this.btnAgregarPartida_Click);
            // 
            // btnRemoverPartida
            // 
            this.btnRemoverPartida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemoverPartida.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoverPartida.Image")));
            this.btnRemoverPartida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoverPartida.Name = "btnRemoverPartida";
            this.btnRemoverPartida.Size = new System.Drawing.Size(54, 22);
            this.btnRemoverPartida.Text = "Eliminar";
            this.btnRemoverPartida.Click += new System.EventHandler(this.btnRemoverPartida_Click);
            // 
            // btnDuplicarPartida
            // 
            this.btnDuplicarPartida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDuplicarPartida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDuplicarPartida.Name = "btnDuplicarPartida";
            this.btnDuplicarPartida.Size = new System.Drawing.Size(55, 22);
            this.btnDuplicarPartida.Text = "Duplicar";
            this.btnDuplicarPartida.Click += new System.EventHandler(this.btnDuplicarPartida_Click);
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.Controls.Add(this.btnConcepto);
            this.panelEncabezado.Controls.Add(this.lblConcepto);
            this.panelEncabezado.Controls.Add(this.datFecha);
            this.panelEncabezado.Controls.Add(this.cmbTipo);
            this.panelEncabezado.Controls.Add(this.lblFecha);
            this.panelEncabezado.Controls.Add(this.lblTipo);
            this.panelEncabezado.Controls.Add(this.txtConcepto);
            this.panelEncabezado.Controls.Add(this.txtNumero);
            this.panelEncabezado.Controls.Add(this.lblNumero);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 25);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(754, 81);
            this.panelEncabezado.TabIndex = 1;
            // 
            // btnConcepto
            // 
            this.btnConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConcepto.Location = new System.Drawing.Point(716, 33);
            this.btnConcepto.Name = "btnConcepto";
            this.btnConcepto.Size = new System.Drawing.Size(20, 40);
            this.btnConcepto.TabIndex = 9;
            this.btnConcepto.Text = "B";
            this.btnConcepto.UseVisualStyleBackColor = true;
            this.btnConcepto.Click += new System.EventHandler(this.btnConcepto_Click);
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Location = new System.Drawing.Point(12, 36);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(53, 13);
            this.lblConcepto.TabIndex = 8;
            this.lblConcepto.Text = "Concepto";
            // 
            // datFecha
            // 
            this.datFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datFecha.Location = new System.Drawing.Point(536, 7);
            this.datFecha.Name = "datFecha";
            this.datFecha.Size = new System.Drawing.Size(200, 20);
            this.datFecha.TabIndex = 7;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(44, 7);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(493, 11);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(10, 11);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "&Tipo";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConcepto.Location = new System.Drawing.Point(71, 33);
            this.txtConcepto.MaxLength = 120;
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(639, 40);
            this.txtConcepto.TabIndex = 5;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(221, 7);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 5;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(171, 11);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 4;
            this.lblNumero.Text = "Número";
            // 
            // gridPartidas
            // 
            this.gridPartidas.AllowUserToAddRows = false;
            this.gridPartidas.AllowUserToDeleteRows = false;
            this.gridPartidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPartidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroCuenta,
            this.NumeroDepartamento,
            this.Column3,
            this.Grupo,
            this.Concepto,
            this.TipoCambio,
            this.DebeHaber,
            this.ColumnDebe,
            this.Column8});
            this.gridPartidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPartidas.Location = new System.Drawing.Point(0, 131);
            this.gridPartidas.MultiSelect = false;
            this.gridPartidas.Name = "gridPartidas";
            this.gridPartidas.ReadOnly = true;
            this.gridPartidas.RowHeadersVisible = false;
            this.gridPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPartidas.Size = new System.Drawing.Size(754, 297);
            this.gridPartidas.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDebe,
            this.lblHaber,
            this.lblEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(754, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDebe
            // 
            this.lblDebe.AutoSize = false;
            this.lblDebe.Name = "lblDebe";
            this.lblDebe.Size = new System.Drawing.Size(120, 17);
            this.lblDebe.Text = "Debe: 0.00";
            // 
            // lblHaber
            // 
            this.lblHaber.AutoSize = false;
            this.lblHaber.Name = "lblHaber";
            this.lblHaber.Size = new System.Drawing.Size(120, 17);
            this.lblHaber.Text = "Haber: 0.00";
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(499, 17);
            this.lblEstado.Spring = true;
            this.lblEstado.Text = "Agregue partidas.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarPartida,
            this.btnRemoverPartida,
            this.btnDuplicarPartida});
            this.toolStrip1.Location = new System.Drawing.Point(0, 106);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(754, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // NumeroCuenta
            // 
            this.NumeroCuenta.DataPropertyName = "NumeroCuenta";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "0000-000-000";
            dataGridViewCellStyle1.NullValue = null;
            this.NumeroCuenta.DefaultCellStyle = dataGridViewCellStyle1;
            this.NumeroCuenta.HeaderText = "No. Cuenta";
            this.NumeroCuenta.MaxInputLength = 21;
            this.NumeroCuenta.Name = "NumeroCuenta";
            this.NumeroCuenta.ReadOnly = true;
            this.NumeroCuenta.ToolTipText = "Número de cuenta que va a ser afectada";
            this.NumeroCuenta.Width = 86;
            // 
            // NumeroDepartamento
            // 
            this.NumeroDepartamento.DataPropertyName = "NumeroDepartamento";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "000";
            dataGridViewCellStyle2.NullValue = null;
            this.NumeroDepartamento.DefaultCellStyle = dataGridViewCellStyle2;
            this.NumeroDepartamento.HeaderText = "Depto";
            this.NumeroDepartamento.Name = "NumeroDepartamento";
            this.NumeroDepartamento.ReadOnly = true;
            this.NumeroDepartamento.Width = 61;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CentroCostos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "000";
            dataGridViewCellStyle3.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "C. Costos";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 77;
            // 
            // Grupo
            // 
            this.Grupo.DataPropertyName = "Grupo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "000";
            dataGridViewCellStyle4.NullValue = null;
            this.Grupo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            this.Grupo.Width = 61;
            // 
            // Concepto
            // 
            this.Concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Concepto.DataPropertyName = "Concepto";
            this.Concepto.HeaderText = "Concepto del movimiento (F2)";
            this.Concepto.MaxInputLength = 120;
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            // 
            // TipoCambio
            // 
            this.TipoCambio.DataPropertyName = "TipoCambio";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.TipoCambio.DefaultCellStyle = dataGridViewCellStyle5;
            this.TipoCambio.HeaderText = "T. Cambio";
            this.TipoCambio.Name = "TipoCambio";
            this.TipoCambio.ReadOnly = true;
            this.TipoCambio.Width = 80;
            // 
            // DebeHaber
            // 
            this.DebeHaber.DataPropertyName = "DebeHaber";
            this.DebeHaber.HeaderText = "D/H";
            this.DebeHaber.Name = "DebeHaber";
            this.DebeHaber.ReadOnly = true;
            this.DebeHaber.Visible = false;
            this.DebeHaber.Width = 53;
            // 
            // ColumnDebe
            // 
            this.ColumnDebe.DataPropertyName = "Debe";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.ColumnDebe.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnDebe.HeaderText = "Debe";
            this.ColumnDebe.Name = "ColumnDebe";
            this.ColumnDebe.ReadOnly = true;
            this.ColumnDebe.Width = 58;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Haber";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column8.HeaderText = "Haber";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 61;
            // 
            // PolizaCapturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 450);
            this.Controls.Add(this.gridPartidas);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelEncabezado);
            this.Controls.Add(this.TPoliza);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolizaCapturaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Póliza";
            this.TPoliza.ResumeLayout(false);
            this.TPoliza.PerformLayout();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPartidas)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TPoliza;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnConcepto;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.DateTimePicker datFecha;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.DataGridView gridPartidas;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripButton btnAgregarPartida;
        private System.Windows.Forms.ToolStripButton btnRemoverPartida;
        private System.Windows.Forms.ToolStripButton btnDuplicarPartida;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDebe;
        private System.Windows.Forms.ToolStripStatusLabel lblHaber;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebeHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}