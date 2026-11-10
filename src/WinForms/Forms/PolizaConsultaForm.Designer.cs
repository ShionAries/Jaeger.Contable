namespace Jaeger.Contable.Forms {
    partial class PolizaConsultaForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolizaConsultaForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.lblTipo = new System.Windows.Forms.ToolStripLabel();
            this.cmbTipo = new System.Windows.Forms.ToolStripComboBox();
            this.lblNumero = new System.Windows.Forms.ToolStripLabel();
            this.txtNumero = new System.Windows.Forms.ToolStripTextBox();
            this.lblEjercicio = new System.Windows.Forms.ToolStripLabel();
            this.nudEjercicio = new System.Windows.Forms.ToolStripComboBox();
            this.lblPeriodo = new System.Windows.Forms.ToolStripLabel();
            this.nudPeriodo = new System.Windows.Forms.ToolStripComboBox();
            this.btnConsulta = new System.Windows.Forms.ToolStripSplitButton();
            this.periodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polizaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCuenta = new System.Windows.Forms.ToolStripTextBox();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnRevertir = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.polizas = new System.Windows.Forms.DataGridView();
            this.detalle = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.estado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.TipoPoliza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPoliza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogAudita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contabilizada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPartidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polizas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalle)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTipo,
            this.cmbTipo,
            this.lblNumero,
            this.txtNumero,
            this.lblEjercicio,
            this.nudEjercicio,
            this.lblPeriodo,
            this.nudPeriodo,
            this.btnConsulta,
            this.txtCuenta,
            this.btnEditar,
            this.btnEliminar,
            this.btnRevertir,
            this.btnCerrar});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(1049, 25);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.Text = "toolStrip1";
            // 
            // lblTipo
            // 
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(33, 22);
            this.lblTipo.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 25);
            // 
            // lblNumero
            // 
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(38, 22);
            this.lblNumero.Text = "Póliza";
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 25);
            // 
            // lblEjercicio
            // 
            this.lblEjercicio.Name = "lblEjercicio";
            this.lblEjercicio.Size = new System.Drawing.Size(54, 22);
            this.lblEjercicio.Text = "Ejercicio:";
            // 
            // nudEjercicio
            // 
            this.nudEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nudEjercicio.Name = "nudEjercicio";
            this.nudEjercicio.Size = new System.Drawing.Size(80, 25);
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(48, 22);
            this.lblPeriodo.Text = "Periodo";
            // 
            // nudPeriodo
            // 
            this.nudPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nudPeriodo.Name = "nudPeriodo";
            this.nudPeriodo.Size = new System.Drawing.Size(120, 25);
            // 
            // btnConsulta
            // 
            this.btnConsulta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnConsulta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.periodoToolStripMenuItem,
            this.polizaToolStripMenuItem,
            this.cuentaToolStripMenuItem});
            this.btnConsulta.Image = ((System.Drawing.Image)(resources.GetObject("btnConsulta.Image")));
            this.btnConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(70, 22);
            this.btnConsulta.Text = "Consulta";
            this.btnConsulta.ButtonClick += new System.EventHandler(this.btnConsulta_ButtonClick);
            // 
            // periodoToolStripMenuItem
            // 
            this.periodoToolStripMenuItem.Name = "periodoToolStripMenuItem";
            this.periodoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.periodoToolStripMenuItem.Text = "Periodo";
            this.periodoToolStripMenuItem.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // polizaToolStripMenuItem
            // 
            this.polizaToolStripMenuItem.Name = "polizaToolStripMenuItem";
            this.polizaToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.polizaToolStripMenuItem.Text = "Poliza";
            this.polizaToolStripMenuItem.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cuentaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cuentaToolStripMenuItem.Image")));
            this.cuentaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cuentaToolStripMenuItem.Text = "Por Cuenta";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.ShortcutsEnabled = false;
            this.txtCuenta.Size = new System.Drawing.Size(100, 25);
            this.txtCuenta.Visible = false;
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(41, 22);
            this.btnEditar.Text = "Editar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(54, 22);
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnRevertir
            // 
            this.btnRevertir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRevertir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRevertir.Name = "btnRevertir";
            this.btnRevertir.Size = new System.Drawing.Size(51, 22);
            this.btnRevertir.Text = "Revertir";
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.polizas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.detalle);
            this.splitContainer1.Size = new System.Drawing.Size(1049, 403);
            this.splitContainer1.SplitterDistance = 152;
            this.splitContainer1.TabIndex = 1;
            // 
            // polizas
            // 
            this.polizas.AllowUserToAddRows = false;
            this.polizas.AllowUserToDeleteRows = false;
            this.polizas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.polizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.polizas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoPoliza,
            this.NumeroPoliza,
            this.LogAudita,
            this.Fecha,
            this.Concepto,
            this.Contabilizada,
            this.Origen,
            this.NumeroPartidas});
            this.polizas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polizas.Location = new System.Drawing.Point(0, 0);
            this.polizas.MultiSelect = false;
            this.polizas.Name = "polizas";
            this.polizas.ReadOnly = true;
            this.polizas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.polizas.Size = new System.Drawing.Size(1049, 152);
            this.polizas.TabIndex = 0;
            this.polizas.SelectionChanged += new System.EventHandler(this.polizas_SelectionChanged);
            // 
            // detalle
            // 
            this.detalle.AllowUserToAddRows = false;
            this.detalle.AllowUserToDeleteRows = false;
            this.detalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detalle.Location = new System.Drawing.Point(0, 0);
            this.detalle.MultiSelect = false;
            this.detalle.Name = "detalle";
            this.detalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.detalle.Size = new System.Drawing.Size(1049, 247);
            this.detalle.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1049, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            // 
            // estado
            // 
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(32, 17);
            this.estado.Text = "Listo";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // TipoPoliza
            // 
            this.TipoPoliza.DataPropertyName = "TipoPoliza";
            this.TipoPoliza.HeaderText = "Tipo";
            this.TipoPoliza.Name = "TipoPoliza";
            this.TipoPoliza.ReadOnly = true;
            this.TipoPoliza.Width = 53;
            // 
            // NumeroPoliza
            // 
            this.NumeroPoliza.DataPropertyName = "NumeroPoliza";
            this.NumeroPoliza.HeaderText = "Número";
            this.NumeroPoliza.Name = "NumeroPoliza";
            this.NumeroPoliza.ReadOnly = true;
            this.NumeroPoliza.Width = 69;
            // 
            // LogAudita
            // 
            this.LogAudita.DataPropertyName = "LogAudita";
            this.LogAudita.HeaderText = "Auditada";
            this.LogAudita.Name = "LogAudita";
            this.LogAudita.ReadOnly = true;
            this.LogAudita.Width = 74;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 62;
            // 
            // Concepto
            // 
            this.Concepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Concepto.DataPropertyName = "Concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.ReadOnly = true;
            // 
            // Contabilizada
            // 
            this.Contabilizada.DataPropertyName = "Contabilizada";
            this.Contabilizada.HeaderText = "Contabilizada";
            this.Contabilizada.Name = "Contabilizada";
            this.Contabilizada.ReadOnly = true;
            this.Contabilizada.Width = 85;
            // 
            // Origen
            // 
            this.Origen.DataPropertyName = "Origen";
            this.Origen.HeaderText = "Origen";
            this.Origen.Name = "Origen";
            this.Origen.ReadOnly = true;
            this.Origen.Width = 63;
            // 
            // NumeroPartidas
            // 
            this.NumeroPartidas.DataPropertyName = "NumeroPartidas";
            this.NumeroPartidas.HeaderText = "Partidas";
            this.NumeroPartidas.Name = "NumeroPartidas";
            this.NumeroPartidas.ReadOnly = true;
            this.NumeroPartidas.Width = 85;
            // 
            // PolizaConsultaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.statusStrip1);
            this.Name = "PolizaConsultaForm";
            this.Text = "Póliza: Consulta";
            this.Load += new System.EventHandler(this.PolizaConsultaForm_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.polizas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detalle)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripComboBox cmbTipo;
        private System.Windows.Forms.ToolStripLabel lblTipo;
        private System.Windows.Forms.ToolStripLabel lblNumero;
        private System.Windows.Forms.ToolStripTextBox txtNumero;
        private System.Windows.Forms.ToolStripLabel lblEjercicio;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView polizas;
        private System.Windows.Forms.DataGridView detalle;
        private System.Windows.Forms.ToolStripComboBox nudEjercicio;
        private System.Windows.Forms.ToolStripLabel lblPeriodo;
        private System.Windows.Forms.ToolStripComboBox nudPeriodo;
        private System.Windows.Forms.ToolStripSplitButton btnConsulta;
        private System.Windows.Forms.ToolStripMenuItem periodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polizaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel estado;
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtCuenta;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnRevertir;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPoliza;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPoliza;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogAudita;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contabilizada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPartidas;
    }
}