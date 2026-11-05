namespace Jaeger.Contable.Forms {
    partial class CuentaContableCatalogoForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuentaContableCatalogoForm));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.Agregar = new System.Windows.Forms.ToolStripButton();
            this.Editar = new System.Windows.Forms.ToolStripButton();
            this.Desactivar = new System.Windows.Forms.ToolStripButton();
            this.Reactivar = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.Contenedor1 = new System.Windows.Forms.SplitContainer();
            this.grdRubros = new System.Windows.Forms.DataGridView();
            this.Rango = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tvCuentas = new System.Windows.Forms.TreeView();
            this.EstadoStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Contenedor1)).BeginInit();
            this.Contenedor1.Panel1.SuspendLayout();
            this.Contenedor1.Panel2.SuspendLayout();
            this.Contenedor1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRubros)).BeginInit();
            this.EstadoStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Agregar,
            this.Editar,
            this.Desactivar,
            this.Reactivar,
            this.btnCerrar});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(925, 25);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.Text = "toolStrip1";
            // 
            // Agregar
            // 
            this.Agregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Agregar.Image = ((System.Drawing.Image)(resources.GetObject("Agregar.Image")));
            this.Agregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(53, 22);
            this.Agregar.Text = "Agregar";
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Editar
            // 
            this.Editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Editar.Image = ((System.Drawing.Image)(resources.GetObject("Editar.Image")));
            this.Editar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(41, 22);
            this.Editar.Text = "Editar";
            this.Editar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Editar.Click += new System.EventHandler(this.Editar_Click);
            // 
            // Desactivar
            // 
            this.Desactivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Desactivar.Name = "Desactivar";
            this.Desactivar.Size = new System.Drawing.Size(65, 22);
            this.Desactivar.Text = "Desactivar";
            this.Desactivar.Click += new System.EventHandler(this.Desactivar_Click);
            // 
            // Reactivar
            // 
            this.Reactivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Reactivar.Name = "Reactivar";
            this.Reactivar.Size = new System.Drawing.Size(59, 22);
            this.Reactivar.Text = "Reactivar";
            this.Reactivar.Click += new System.EventHandler(this.Reactivar_Click);
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
            // Contenedor1
            // 
            this.Contenedor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor1.Location = new System.Drawing.Point(0, 25);
            this.Contenedor1.Name = "Contenedor1";
            // 
            // Contenedor1.Panel1
            // 
            this.Contenedor1.Panel1.Controls.Add(this.grdRubros);
            // 
            // Contenedor1.Panel2
            // 
            this.Contenedor1.Panel2.Controls.Add(this.lblTitulo);
            this.Contenedor1.Panel2.Controls.Add(this.tvCuentas);
            this.Contenedor1.Size = new System.Drawing.Size(925, 524);
            this.Contenedor1.SplitterDistance = 229;
            this.Contenedor1.TabIndex = 1;
            // 
            // grdRubros
            // 
            this.grdRubros.AllowUserToAddRows = false;
            this.grdRubros.AllowUserToDeleteRows = false;
            this.grdRubros.AllowUserToResizeRows = false;
            this.grdRubros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRubros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rango,
            this.DESCRIP});
            this.grdRubros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRubros.Location = new System.Drawing.Point(0, 0);
            this.grdRubros.Name = "grdRubros";
            this.grdRubros.ReadOnly = true;
            this.grdRubros.RowHeadersVisible = false;
            this.grdRubros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRubros.Size = new System.Drawing.Size(229, 524);
            this.grdRubros.TabIndex = 0;
            this.grdRubros.SelectionChanged += new System.EventHandler(this.PolizaGrid_SelectionChanged);
            // 
            // Rango
            // 
            this.Rango.DataPropertyName = "Rango";
            this.Rango.FillWeight = 50F;
            this.Rango.HeaderText = "Rango";
            this.Rango.Name = "Rango";
            this.Rango.ReadOnly = true;
            this.Rango.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rango.Width = 64;
            // 
            // DESCRIP
            // 
            this.DESCRIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DESCRIP.DataPropertyName = "Descripcion";
            this.DESCRIP.HeaderText = "Descripción";
            this.DESCRIP.Name = "DESCRIP";
            this.DESCRIP.ReadOnly = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(692, 20);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "   Cuenta  |  Descripción de la cuenta";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tvCuentas
            // 
            this.tvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvCuentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCuentas.ItemHeight = 19;
            this.tvCuentas.Location = new System.Drawing.Point(0, 0);
            this.tvCuentas.Name = "tvCuentas";
            this.tvCuentas.Size = new System.Drawing.Size(692, 524);
            this.tvCuentas.TabIndex = 0;
            // 
            // EstadoStrip
            // 
            this.EstadoStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.EstadoStrip.Location = new System.Drawing.Point(0, 549);
            this.EstadoStrip.Name = "EstadoStrip";
            this.EstadoStrip.Size = new System.Drawing.Size(925, 22);
            this.EstadoStrip.SizingGrip = false;
            this.EstadoStrip.TabIndex = 2;
            this.EstadoStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(15, 17);
            this.statusLabel.Text = "[]";
            // 
            // CuentaContableCatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 571);
            this.Controls.Add(this.Contenedor1);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.EstadoStrip);
            this.Name = "CuentaContableCatalogoForm";
            this.Text = "Catálogo de Cuentas Contables";
            this.Load += new System.EventHandler(this.CuentaContableCatalogoForm_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.Contenedor1.Panel1.ResumeLayout(false);
            this.Contenedor1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Contenedor1)).EndInit();
            this.Contenedor1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRubros)).EndInit();
            this.EstadoStrip.ResumeLayout(false);
            this.EstadoStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton Agregar;
        private System.Windows.Forms.SplitContainer Contenedor1;
 
        private System.Windows.Forms.DataGridView grdRubros;
        private System.Windows.Forms.TreeView tvCuentas;
        private System.Windows.Forms.StatusStrip EstadoStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripButton Editar;
        private System.Windows.Forms.ToolStripButton Desactivar;
        private System.Windows.Forms.ToolStripButton Reactivar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rango;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIP;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ToolStripButton btnCerrar;
    }
}