namespace Jaeger.Contable {
    partial class MainForm {
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
            this.Estado = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.mArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mCuentasPolizas = new System.Windows.Forms.ToolStripMenuItem();
            this.mCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mCuentasCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mPolizas = new System.Windows.Forms.ToolStripMenuItem();
            this.mPolizasConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.mPolizasCaptura = new System.Windows.Forms.ToolStripMenuItem();
            this.mContabilizarPeriodo = new System.Windows.Forms.ToolStripMenuItem();
            this.mConceptos = new System.Windows.Forms.ToolStripMenuItem();
            this.mCatalogosPartida = new System.Windows.Forms.ToolStripMenuItem();
            this.mTiposPoliza = new System.Windows.Forms.ToolStripMenuItem();
            this.mRangos = new System.Windows.Forms.ToolStripMenuItem();
            this.mMonedas = new System.Windows.Forms.ToolStripMenuItem();
            this.mTiposActivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mActivosFijos = new System.Windows.Forms.ToolStripMenuItem();
            this.mHistoricoActivos = new System.Windows.Forms.ToolStripMenuItem();
            this.mDepreciacionActivos = new System.Windows.Forms.ToolStripMenuItem();
            this.mAuditaria = new System.Windows.Forms.ToolStripMenuItem();
            this.mAuditoriaCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mAuditoriaRubros = new System.Windows.Forms.ToolStripMenuItem();
            this.mBalanzaComprobacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mVentana = new System.Windows.Forms.ToolStripMenuItem();
            this.Estado.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Estado
            // 
            this.Estado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.Estado.Location = new System.Drawing.Point(0, 458);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(793, 22);
            this.Estado.TabIndex = 3;
            this.Estado.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(16, 17);
            this.statusLabel.Text = "...";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mArchivo,
            this.mCuentasPolizas,
            this.mVentana});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.MdiWindowListItem = this.mVentana;
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(793, 24);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "menuStrip1";
            // 
            // mArchivo
            // 
            this.mArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mSalir});
            this.mArchivo.Name = "mArchivo";
            this.mArchivo.Size = new System.Drawing.Size(60, 20);
            this.mArchivo.Text = "Archivo";
            // 
            // mSalir
            // 
            this.mSalir.Name = "mSalir";
            this.mSalir.Size = new System.Drawing.Size(96, 22);
            this.mSalir.Text = "Salir";
            // 
            // mCuentasPolizas
            // 
            this.mCuentasPolizas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCuentas,
            this.mPolizas,
            this.mAuditaria});
            this.mCuentasPolizas.Name = "mCuentasPolizas";
            this.mCuentasPolizas.Size = new System.Drawing.Size(110, 20);
            this.mCuentasPolizas.Text = "Cuentas y Pólizas";
            // 
            // mCuentas
            // 
            this.mCuentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCuentasCuentas});
            this.mCuentas.Name = "mCuentas";
            this.mCuentas.Size = new System.Drawing.Size(123, 22);
            this.mCuentas.Text = "Cuentas";
            // 
            // mCuentasCuentas
            // 
            this.mCuentasCuentas.Name = "mCuentasCuentas";
            this.mCuentasCuentas.Size = new System.Drawing.Size(117, 22);
            this.mCuentasCuentas.Text = "Cuentas";
            // 
            // mPolizas
            // 
            this.mPolizas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mPolizasConsulta,
            this.mBalanzaComprobacion,
            this.mPolizasCaptura,
            this.mContabilizarPeriodo,
            this.mConceptos,
            this.mCatalogosPartida,
            this.mTiposPoliza,
            this.mRangos,
            this.mMonedas,
            this.mTiposActivo,
            this.mActivosFijos,
            this.mHistoricoActivos,
            this.mDepreciacionActivos});
            this.mPolizas.Name = "mPolizas";
            this.mPolizas.Size = new System.Drawing.Size(123, 22);
            this.mPolizas.Text = "Pólizas";
            // 
            // mPolizasConsulta
            // 
            this.mPolizasConsulta.Name = "mPolizasConsulta";
            this.mPolizasConsulta.Size = new System.Drawing.Size(201, 22);
            this.mPolizasConsulta.Text = "Consulta";
            // 
            // mBalanzaComprobacion
            // 
            this.mBalanzaComprobacion.Name = "mBalanzaComprobacion";
            this.mBalanzaComprobacion.Size = new System.Drawing.Size(201, 22);
            this.mBalanzaComprobacion.Text = "Balanza de comprobación";
            // 
            // 
            // mPolizasCaptura
            // 
            this.mPolizasCaptura.Name = "mPolizasCaptura";
            this.mPolizasCaptura.Size = new System.Drawing.Size(201, 22);
            this.mPolizasCaptura.Text = "Captura";
            // 
            // mContabilizarPeriodo
            // 
            this.mContabilizarPeriodo.Name = "mContabilizarPeriodo";
            this.mContabilizarPeriodo.Size = new System.Drawing.Size(201, 22);
            this.mContabilizarPeriodo.Text = "Contabilizar período";
            // 
            // mConceptos
            // 
            this.mConceptos.Name = "mConceptos";
            this.mConceptos.Size = new System.Drawing.Size(201, 22);
            this.mConceptos.Text = "Conceptos";
            // 
            // mCatalogosPartida
            // 
            this.mCatalogosPartida.Name = "mCatalogosPartida";
            this.mCatalogosPartida.Size = new System.Drawing.Size(201, 22);
            this.mCatalogosPartida.Text = "Catálogos de partidas";
            // 
            // mTiposPoliza
            // 
            this.mTiposPoliza.Name = "mTiposPoliza";
            this.mTiposPoliza.Size = new System.Drawing.Size(201, 22);
            this.mTiposPoliza.Text = "Tipos de póliza";
            // 
            // mRangos
            // 
            this.mRangos.Name = "mRangos";
            this.mRangos.Size = new System.Drawing.Size(201, 22);
            this.mRangos.Text = "Rangos";
            // 
            // mMonedas
            // 
            this.mMonedas.Name = "mMonedas";
            this.mMonedas.Size = new System.Drawing.Size(201, 22);
            this.mMonedas.Text = "Monedas";
            // 
            // mTiposActivo
            // 
            this.mTiposActivo.Name = "mTiposActivo";
            this.mTiposActivo.Size = new System.Drawing.Size(201, 22);
            this.mTiposActivo.Text = "Tipos de activo";
            // 
            // mActivosFijos
            // 
            this.mActivosFijos.Name = "mActivosFijos";
            this.mActivosFijos.Size = new System.Drawing.Size(201, 22);
            this.mActivosFijos.Text = "Activos fijos";
            // 
            // mHistoricoActivos
            // 
            this.mHistoricoActivos.Name = "mHistoricoActivos";
            this.mHistoricoActivos.Size = new System.Drawing.Size(201, 22);
            this.mHistoricoActivos.Text = "Histórico de activos";
            // 
            // mDepreciacionActivos
            // 
            this.mDepreciacionActivos.Name = "mDepreciacionActivos";
            this.mDepreciacionActivos.Size = new System.Drawing.Size(201, 22);
            this.mDepreciacionActivos.Text = "Control de depreciación";
            // 
            // mAuditaria
            // 
            this.mAuditaria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAuditoriaCuentas,
            this.mAuditoriaRubros});
            this.mAuditaria.Name = "mAuditaria";
            this.mAuditaria.Size = new System.Drawing.Size(123, 22);
            this.mAuditaria.Text = "Auditoria";
            // 
            // mAuditoriaCuentas
            // 
            this.mAuditoriaCuentas.Name = "mAuditoriaCuentas";
            this.mAuditoriaCuentas.Size = new System.Drawing.Size(117, 22);
            this.mAuditoriaCuentas.Text = "Cuentas";
            // 
            // mAuditoriaRubros
            // 
            this.mAuditoriaRubros.Name = "mAuditoriaRubros";
            this.mAuditoriaRubros.Size = new System.Drawing.Size(117, 22);
            this.mAuditoriaRubros.Text = "Rubros";
            // 
            // mVentana
            // 
            this.mVentana.Name = "mVentana";
            this.mVentana.Size = new System.Drawing.Size(61, 20);
            this.mVentana.Text = "Ventana";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 480);
            this.Controls.Add(this.Estado);
            this.Controls.Add(this.menuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Contable";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Estado.ResumeLayout(false);
            this.Estado.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip Estado;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem mArchivo;
        private System.Windows.Forms.ToolStripMenuItem mSalir;
        private System.Windows.Forms.ToolStripMenuItem mCuentasPolizas;
        private System.Windows.Forms.ToolStripMenuItem mCuentas;
        private System.Windows.Forms.ToolStripMenuItem mCuentasCuentas;
        private System.Windows.Forms.ToolStripMenuItem mPolizas;
        private System.Windows.Forms.ToolStripMenuItem mPolizasConsulta;
        private System.Windows.Forms.ToolStripMenuItem mPolizasCaptura;
        private System.Windows.Forms.ToolStripMenuItem mContabilizarPeriodo;
        private System.Windows.Forms.ToolStripMenuItem mConceptos;
        private System.Windows.Forms.ToolStripMenuItem mCatalogosPartida;
        private System.Windows.Forms.ToolStripMenuItem mTiposPoliza;
        private System.Windows.Forms.ToolStripMenuItem mRangos;
        private System.Windows.Forms.ToolStripMenuItem mMonedas;
        private System.Windows.Forms.ToolStripMenuItem mTiposActivo;
        private System.Windows.Forms.ToolStripMenuItem mActivosFijos;
        private System.Windows.Forms.ToolStripMenuItem mHistoricoActivos;
        private System.Windows.Forms.ToolStripMenuItem mDepreciacionActivos;
        private System.Windows.Forms.ToolStripMenuItem mAuditaria;
        private System.Windows.Forms.ToolStripMenuItem mAuditoriaCuentas;
        private System.Windows.Forms.ToolStripMenuItem mAuditoriaRubros;
        private System.Windows.Forms.ToolStripMenuItem mBalanzaComprobacion;
        private System.Windows.Forms.ToolStripMenuItem mVentana;
    }
}