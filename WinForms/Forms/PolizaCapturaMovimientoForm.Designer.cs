namespace Jaeger.Contable {
    partial class PolizaCapturaMovimientoForm {
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
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.labelNoCuenta = new System.Windows.Forms.Label();
            this.txtNoCuenta = new System.Windows.Forms.MaskedTextBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.btnCuenta = new System.Windows.Forms.Button();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.NumericUpDown();
            this.cmbDebeHaber = new System.Windows.Forms.ComboBox();
            this.txtTipoCambio = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCentroCostos = new System.Windows.Forms.TextBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.lblDebeHaber = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblTipoCambio = new System.Windows.Forms.Label();
            this.lblCentroCostos = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.btnDepto = new System.Windows.Forms.Button();
            this.btnCosto = new System.Windows.Forms.Button();
            this.btnGrupo = new System.Windows.Forms.Button();
            this.txtDescripcionDepartamento = new System.Windows.Forms.TextBox();
            this.txtDescripcionCuenta = new System.Windows.Forms.TextBox();
            this.txtDescripcionCentroCostos = new System.Windows.Forms.TextBox();
            this.txtDescripcionGrupo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(97, 67);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(239, 20);
            this.txtConcepto.TabIndex = 9;
            // 
            // labelNoCuenta
            // 
            this.labelNoCuenta.AutoSize = true;
            this.labelNoCuenta.Location = new System.Drawing.Point(16, 24);
            this.labelNoCuenta.Name = "labelNoCuenta";
            this.labelNoCuenta.Size = new System.Drawing.Size(75, 13);
            this.labelNoCuenta.TabIndex = 6;
            this.labelNoCuenta.Text = "No. de cuenta";
            // 
            // txtNoCuenta
            // 
            this.txtNoCuenta.Location = new System.Drawing.Point(98, 21);
            this.txtNoCuenta.Name = "txtNoCuenta";
            this.txtNoCuenta.ReadOnly = true;
            this.txtNoCuenta.Size = new System.Drawing.Size(193, 20);
            this.txtNoCuenta.TabIndex = 8;
            this.txtNoCuenta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(16, 70);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(53, 13);
            this.labelDescripcion.TabIndex = 7;
            this.labelDescripcion.Text = "Concepto";
            // 
            // btnCuenta
            // 
            this.btnCuenta.Location = new System.Drawing.Point(297, 21);
            this.btnCuenta.Name = "btnCuenta";
            this.btnCuenta.Size = new System.Drawing.Size(39, 20);
            this.btnCuenta.TabIndex = 10;
            this.btnCuenta.Text = "...";
            this.btnCuenta.UseVisualStyleBackColor = true;
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(97, 93);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.ReadOnly = true;
            this.txtDepartamento.Size = new System.Drawing.Size(28, 20);
            this.txtDepartamento.TabIndex = 12;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(16, 96);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(74, 13);
            this.lblDepartamento.TabIndex = 11;
            this.lblDepartamento.Text = "Departamento";
            // 
            // txtImporte
            // 
            this.txtImporte.DecimalPlaces = 2;
            this.txtImporte.Location = new System.Drawing.Point(221, 119);
            this.txtImporte.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(114, 20);
            this.txtImporte.TabIndex = 13;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbDebeHaber
            // 
            this.cmbDebeHaber.FormattingEnabled = true;
            this.cmbDebeHaber.Location = new System.Drawing.Point(98, 119);
            this.cmbDebeHaber.Name = "cmbDebeHaber";
            this.cmbDebeHaber.Size = new System.Drawing.Size(69, 21);
            this.cmbDebeHaber.TabIndex = 14;
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.DecimalPlaces = 2;
            this.txtTipoCambio.Location = new System.Drawing.Point(97, 145);
            this.txtTipoCambio.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(70, 20);
            this.txtTipoCambio.TabIndex = 13;
            this.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(295, 252);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(214, 252);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtCentroCostos
            // 
            this.txtCentroCostos.Location = new System.Drawing.Point(108, 171);
            this.txtCentroCostos.Name = "txtCentroCostos";
            this.txtCentroCostos.ReadOnly = true;
            this.txtCentroCostos.Size = new System.Drawing.Size(27, 20);
            this.txtCentroCostos.TabIndex = 12;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(108, 197);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.ReadOnly = true;
            this.txtGrupo.Size = new System.Drawing.Size(27, 20);
            this.txtGrupo.TabIndex = 12;
            // 
            // lblDebeHaber
            // 
            this.lblDebeHaber.AutoSize = true;
            this.lblDebeHaber.Location = new System.Drawing.Point(16, 123);
            this.lblDebeHaber.Name = "lblDebeHaber";
            this.lblDebeHaber.Size = new System.Drawing.Size(77, 13);
            this.lblDebeHaber.TabIndex = 11;
            this.lblDebeHaber.Text = "Abono o cargo";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(173, 123);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(42, 13);
            this.lblImporte.TabIndex = 11;
            this.lblImporte.Text = "Importe";
            // 
            // lblTipoCambio
            // 
            this.lblTipoCambio.AutoSize = true;
            this.lblTipoCambio.Location = new System.Drawing.Point(15, 149);
            this.lblTipoCambio.Name = "lblTipoCambio";
            this.lblTipoCambio.Size = new System.Drawing.Size(80, 13);
            this.lblTipoCambio.TabIndex = 11;
            this.lblTipoCambio.Text = "Tipo de cambio";
            // 
            // lblCentroCostos
            // 
            this.lblCentroCostos.AutoSize = true;
            this.lblCentroCostos.Location = new System.Drawing.Point(16, 175);
            this.lblCentroCostos.Name = "lblCentroCostos";
            this.lblCentroCostos.Size = new System.Drawing.Size(87, 13);
            this.lblCentroCostos.TabIndex = 11;
            this.lblCentroCostos.Text = "Centro de costos";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(16, 200);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(36, 13);
            this.lblGrupo.TabIndex = 11;
            this.lblGrupo.Text = "Grupo";
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Location = new System.Drawing.Point(219, 145);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(117, 21);
            this.cmbMoneda.TabIndex = 14;
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(173, 149);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(46, 13);
            this.lblMoneda.TabIndex = 11;
            this.lblMoneda.Text = "Moneda";
            // 
            // btnDepto
            // 
            this.btnDepto.Location = new System.Drawing.Point(296, 93);
            this.btnDepto.Name = "btnDepto";
            this.btnDepto.Size = new System.Drawing.Size(40, 20);
            this.btnDepto.TabIndex = 10;
            this.btnDepto.Text = "...";
            this.btnDepto.UseVisualStyleBackColor = true;
            // 
            // btnCosto
            // 
            this.btnCosto.Location = new System.Drawing.Point(295, 171);
            this.btnCosto.Name = "btnCosto";
            this.btnCosto.Size = new System.Drawing.Size(41, 20);
            this.btnCosto.TabIndex = 10;
            this.btnCosto.Text = "...";
            this.btnCosto.UseVisualStyleBackColor = true;
            // 
            // btnGrupo
            // 
            this.btnGrupo.Location = new System.Drawing.Point(295, 196);
            this.btnGrupo.Name = "btnGrupo";
            this.btnGrupo.Size = new System.Drawing.Size(41, 20);
            this.btnGrupo.TabIndex = 10;
            this.btnGrupo.Text = "...";
            this.btnGrupo.UseVisualStyleBackColor = true;
            // 
            // txtDescripcionDepartamento
            // 
            this.txtDescripcionDepartamento.Location = new System.Drawing.Point(131, 93);
            this.txtDescripcionDepartamento.Name = "txtDescripcionDepartamento";
            this.txtDescripcionDepartamento.ReadOnly = true;
            this.txtDescripcionDepartamento.Size = new System.Drawing.Size(159, 20);
            this.txtDescripcionDepartamento.TabIndex = 9;
            // 
            // txtDescripcionCuenta
            // 
            this.txtDescripcionCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionCuenta.Location = new System.Drawing.Point(99, 45);
            this.txtDescripcionCuenta.Name = "txtDescripcionCuenta";
            this.txtDescripcionCuenta.ReadOnly = true;
            this.txtDescripcionCuenta.Size = new System.Drawing.Size(193, 13);
            this.txtDescripcionCuenta.TabIndex = 9;
            this.txtDescripcionCuenta.Text = "---- --- --- --";
            // 
            // txtDescripcionCentroCostos
            // 
            this.txtDescripcionCentroCostos.Location = new System.Drawing.Point(142, 171);
            this.txtDescripcionCentroCostos.Name = "txtDescripcionCentroCostos";
            this.txtDescripcionCentroCostos.ReadOnly = true;
            this.txtDescripcionCentroCostos.Size = new System.Drawing.Size(148, 20);
            this.txtDescripcionCentroCostos.TabIndex = 9;
            // 
            // txtDescripcionGrupo
            // 
            this.txtDescripcionGrupo.Location = new System.Drawing.Point(142, 197);
            this.txtDescripcionGrupo.Name = "txtDescripcionGrupo";
            this.txtDescripcionGrupo.ReadOnly = true;
            this.txtDescripcionGrupo.Size = new System.Drawing.Size(147, 20);
            this.txtDescripcionGrupo.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNoCuenta);
            this.groupBox1.Controls.Add(this.labelDescripcion);
            this.groupBox1.Controls.Add(this.txtNoCuenta);
            this.groupBox1.Controls.Add(this.cmbMoneda);
            this.groupBox1.Controls.Add(this.txtConcepto);
            this.groupBox1.Controls.Add(this.cmbDebeHaber);
            this.groupBox1.Controls.Add(this.txtDescripcionCuenta);
            this.groupBox1.Controls.Add(this.txtTipoCambio);
            this.groupBox1.Controls.Add(this.txtDescripcionCentroCostos);
            this.groupBox1.Controls.Add(this.txtImporte);
            this.groupBox1.Controls.Add(this.txtDescripcionDepartamento);
            this.groupBox1.Controls.Add(this.txtDescripcionGrupo);
            this.groupBox1.Controls.Add(this.btnCuenta);
            this.groupBox1.Controls.Add(this.txtGrupo);
            this.groupBox1.Controls.Add(this.btnDepto);
            this.groupBox1.Controls.Add(this.txtCentroCostos);
            this.groupBox1.Controls.Add(this.btnCosto);
            this.groupBox1.Controls.Add(this.txtDepartamento);
            this.groupBox1.Controls.Add(this.btnGrupo);
            this.groupBox1.Controls.Add(this.lblMoneda);
            this.groupBox1.Controls.Add(this.lblDepartamento);
            this.groupBox1.Controls.Add(this.lblGrupo);
            this.groupBox1.Controls.Add(this.lblDebeHaber);
            this.groupBox1.Controls.Add(this.lblCentroCostos);
            this.groupBox1.Controls.Add(this.lblImporte);
            this.groupBox1.Controls.Add(this.lblTipoCambio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 232);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // PolizaCapturaMovimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 287);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolizaCapturaMovimientoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Captura Movimiento";
            this.Load += new System.EventHandler(this.PolizaCapturaMovimientoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label labelNoCuenta;
        private System.Windows.Forms.MaskedTextBox txtNoCuenta;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.Button btnCuenta;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.NumericUpDown txtImporte;
        private System.Windows.Forms.ComboBox cmbDebeHaber;
        private System.Windows.Forms.NumericUpDown txtTipoCambio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtCentroCostos;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label lblDebeHaber;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblTipoCambio;
        private System.Windows.Forms.Label lblCentroCostos;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Button btnDepto;
        private System.Windows.Forms.Button btnCosto;
        private System.Windows.Forms.Button btnGrupo;
        private System.Windows.Forms.TextBox txtDescripcionDepartamento;
        private System.Windows.Forms.TextBox txtDescripcionCuenta;
        private System.Windows.Forms.TextBox txtDescripcionCentroCostos;
        private System.Windows.Forms.TextBox txtDescripcionGrupo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}