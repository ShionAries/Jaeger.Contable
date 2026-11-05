namespace Jaeger.Contable.WinForms.Forms {
    partial class TipoActivoCatalogoForm {
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
            this._btnCerrar = new System.Windows.Forms.Button();
            this._btnEliminar = new System.Windows.Forms.Button();
            this._btnGuardar = new System.Windows.Forms.Button();
            this._btnNuevo = new System.Windows.Forms.Button();
            this._numMoneda = new System.Windows.Forms.NumericUpDown();
            this._numClave = new System.Windows.Forms.NumericUpDown();
            this._grid = new System.Windows.Forms.DataGridView();
            this._txtMetodo = new System.Windows.Forms.TextBox();
            this._txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblPrefijo = new System.Windows.Forms.Label();
            this._txtBuscar = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._numDedNormal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this._numDedImed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._numMaxDed = new System.Windows.Forms.NumericUpDown();
            this._numDepProy = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this._txtCtaActivo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._txtCtaDepre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._txtCtaGastos = new System.Windows.Forms.TextBox();
            this._txtCtaGan = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this._numMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDedNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDedImed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numMaxDed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDepProy)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnCerrar
            // 
            this._btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCerrar.Location = new System.Drawing.Point(773, 381);
            this._btnCerrar.Name = "_btnCerrar";
            this._btnCerrar.Size = new System.Drawing.Size(75, 23);
            this._btnCerrar.TabIndex = 30;
            this._btnCerrar.Text = "Cerrar";
            this._btnCerrar.UseVisualStyleBackColor = true;
            // 
            // _btnEliminar
            // 
            this._btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnEliminar.Location = new System.Drawing.Point(172, 381);
            this._btnEliminar.Name = "_btnEliminar";
            this._btnEliminar.Size = new System.Drawing.Size(75, 23);
            this._btnEliminar.TabIndex = 29;
            this._btnEliminar.Text = "Eliminar";
            this._btnEliminar.UseVisualStyleBackColor = true;
            // 
            // _btnGuardar
            // 
            this._btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnGuardar.Location = new System.Drawing.Point(91, 381);
            this._btnGuardar.Name = "_btnGuardar";
            this._btnGuardar.Size = new System.Drawing.Size(75, 23);
            this._btnGuardar.TabIndex = 28;
            this._btnGuardar.Text = "Guardar";
            this._btnGuardar.UseVisualStyleBackColor = true;
            // 
            // _btnNuevo
            // 
            this._btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnNuevo.Location = new System.Drawing.Point(10, 381);
            this._btnNuevo.Name = "_btnNuevo";
            this._btnNuevo.Size = new System.Drawing.Size(75, 23);
            this._btnNuevo.TabIndex = 27;
            this._btnNuevo.Text = "Nuevo";
            this._btnNuevo.UseVisualStyleBackColor = true;
            // 
            // _numMoneda
            // 
            this._numMoneda.Location = new System.Drawing.Point(749, 24);
            this._numMoneda.Name = "_numMoneda";
            this._numMoneda.Size = new System.Drawing.Size(78, 20);
            this._numMoneda.TabIndex = 24;
            // 
            // _numClave
            // 
            this._numClave.Location = new System.Drawing.Point(52, 24);
            this._numClave.Name = "_numClave";
            this._numClave.Size = new System.Drawing.Size(89, 20);
            this._numClave.TabIndex = 22;
            // 
            // _grid
            // 
            this._grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Location = new System.Drawing.Point(12, 42);
            this._grid.Name = "_grid";
            this._grid.RowHeadersVisible = false;
            this._grid.Size = new System.Drawing.Size(831, 185);
            this._grid.TabIndex = 21;
            // 
            // _txtMetodo
            // 
            this._txtMetodo.Location = new System.Drawing.Point(615, 24);
            this._txtMetodo.Name = "_txtMetodo";
            this._txtMetodo.Size = new System.Drawing.Size(73, 20);
            this._txtMetodo.TabIndex = 20;
            // 
            // _txtDescripcion
            // 
            this._txtDescripcion.Location = new System.Drawing.Point(219, 24);
            this._txtDescripcion.Name = "_txtDescripcion";
            this._txtDescripcion.Size = new System.Drawing.Size(317, 20);
            this._txtDescripcion.TabIndex = 17;
            // 
            // lblPrefijo
            // 
            this.lblPrefijo.AutoSize = true;
            this.lblPrefijo.Location = new System.Drawing.Point(542, 28);
            this.lblPrefijo.Name = "lblPrefijo";
            this.lblPrefijo.Size = new System.Drawing.Size(67, 13);
            this.lblPrefijo.TabIndex = 13;
            this.lblPrefijo.Text = "Método dep:";
            // 
            // _txtBuscar
            // 
            this._txtBuscar.Location = new System.Drawing.Point(58, 16);
            this._txtBuscar.Name = "_txtBuscar";
            this._txtBuscar.Size = new System.Drawing.Size(397, 20);
            this._txtBuscar.TabIndex = 16;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(147, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(66, 13);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Descripción:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(694, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Moneda:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 28);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(37, 13);
            this.lblCodigo.TabIndex = 15;
            this.lblCodigo.Text = "Clave:";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(12, 20);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 7;
            this.lblBuscar.Text = "Buscar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Dep. Normal:";
            // 
            // _numDedNormal
            // 
            this._numDedNormal.Location = new System.Drawing.Point(81, 50);
            this._numDedNormal.Name = "_numDedNormal";
            this._numDedNormal.Size = new System.Drawing.Size(98, 20);
            this._numDedNormal.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Dep. Inmediata:";
            // 
            // _numDedImed
            // 
            this._numDedImed.Location = new System.Drawing.Point(273, 50);
            this._numDedImed.Name = "_numDedImed";
            this._numDedImed.Size = new System.Drawing.Size(98, 20);
            this._numDedImed.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Máx. dep:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(542, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dep. Proyectada:";
            // 
            // _numMaxDed
            // 
            this._numMaxDed.Location = new System.Drawing.Point(437, 50);
            this._numMaxDed.Name = "_numMaxDed";
            this._numMaxDed.Size = new System.Drawing.Size(98, 20);
            this._numMaxDed.TabIndex = 24;
            // 
            // _numDepProy
            // 
            this._numDepProy.Location = new System.Drawing.Point(638, 50);
            this._numDepProy.Name = "_numDepProy";
            this._numDepProy.Size = new System.Drawing.Size(98, 20);
            this._numDepProy.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cuenta activo:";
            // 
            // _txtCtaActivo
            // 
            this._txtCtaActivo.Location = new System.Drawing.Point(8, 101);
            this._txtCtaActivo.Name = "_txtCtaActivo";
            this._txtCtaActivo.Size = new System.Drawing.Size(150, 20);
            this._txtCtaActivo.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cuenta depresiación:";
            // 
            // _txtCtaDepre
            // 
            this._txtCtaDepre.Location = new System.Drawing.Point(164, 101);
            this._txtCtaDepre.Name = "_txtCtaDepre";
            this._txtCtaDepre.Size = new System.Drawing.Size(150, 20);
            this._txtCtaDepre.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cuenta gastos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(485, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Cuenta ganancias:";
            // 
            // _txtCtaGastos
            // 
            this._txtCtaGastos.Location = new System.Drawing.Point(320, 101);
            this._txtCtaGastos.Name = "_txtCtaGastos";
            this._txtCtaGastos.Size = new System.Drawing.Size(150, 20);
            this._txtCtaGastos.TabIndex = 17;
            // 
            // _txtCtaGan
            // 
            this._txtCtaGan.Location = new System.Drawing.Point(485, 101);
            this._txtCtaGan.Name = "_txtCtaGan";
            this._txtCtaGan.Size = new System.Drawing.Size(150, 20);
            this._txtCtaGan.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._numDepProy);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._numDedImed);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this._numMaxDed);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this._numDedNormal);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this._numMoneda);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._numClave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblPrefijo);
            this.groupBox1.Controls.Add(this._txtMetodo);
            this.groupBox1.Controls.Add(this._txtDescripcion);
            this.groupBox1.Controls.Add(this._txtCtaGan);
            this.groupBox1.Controls.Add(this._txtCtaActivo);
            this.groupBox1.Controls.Add(this._txtCtaDepre);
            this.groupBox1.Controls.Add(this._txtCtaGastos);
            this.groupBox1.Location = new System.Drawing.Point(10, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 133);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // TipoActivoCatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._btnCerrar);
            this.Controls.Add(this._btnEliminar);
            this.Controls.Add(this._btnGuardar);
            this.Controls.Add(this._btnNuevo);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(876, 455);
            this.Name = "TipoActivoCatalogoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TipoActivoCatalogoForm";
            ((System.ComponentModel.ISupportInitialize)(this._numMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDedNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDedImed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numMaxDed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numDepProy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnCerrar;
        private System.Windows.Forms.Button _btnEliminar;
        private System.Windows.Forms.Button _btnGuardar;
        private System.Windows.Forms.Button _btnNuevo;
        private System.Windows.Forms.NumericUpDown _numMoneda;
        private System.Windows.Forms.NumericUpDown _numClave;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.TextBox _txtMetodo;
        private System.Windows.Forms.TextBox _txtDescripcion;
        private System.Windows.Forms.Label lblPrefijo;
        private System.Windows.Forms.TextBox _txtBuscar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _numDedNormal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _numDedImed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown _numMaxDed;
        private System.Windows.Forms.NumericUpDown _numDepProy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtCtaActivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _txtCtaDepre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _txtCtaGastos;
        private System.Windows.Forms.TextBox _txtCtaGan;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}