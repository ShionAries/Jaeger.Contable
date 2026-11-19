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
            this.mPeriodosContables = new System.Windows.Forms.ToolStripMenuItem();
            this.mSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mCuentasPolizas = new System.Windows.Forms.ToolStripMenuItem();
            this.mCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mCuentasCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mPolizas = new System.Windows.Forms.ToolStripMenuItem();
            this.bPolizas = new System.Windows.Forms.ToolStripMenuItem();
            this.mPolizasConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.mPolizasCaptura = new System.Windows.Forms.ToolStripMenuItem();
            this.mAuxiliares = new System.Windows.Forms.ToolStripMenuItem();
            this.mAuxiliarCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mContabilizarPeriodo = new System.Windows.Forms.ToolStripMenuItem();
            this.mConceptos = new System.Windows.Forms.ToolStripMenuItem();
            this.mTiposPoliza = new System.Windows.Forms.ToolStripMenuItem();
            this.mRangos = new System.Windows.Forms.ToolStripMenuItem();
            this.mBalanza = new System.Windows.Forms.ToolStripMenuItem();
            this.mBalanzaComprobacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mSegmentos = new System.Windows.Forms.ToolStripMenuItem();
            this.bDepartamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.bCentroCostos = new System.Windows.Forms.ToolStripMenuItem();
            this.bProyectos = new System.Windows.Forms.ToolStripMenuItem();
            this.mAuditaria = new System.Windows.Forms.ToolStripMenuItem();
            this.mAuditoriaCuentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mAuditoriaRubros = new System.Windows.Forms.ToolStripMenuItem();
            this.mMonedas = new System.Windows.Forms.ToolStripMenuItem();
            this.bMonedas = new System.Windows.Forms.ToolStripMenuItem();
            this.mActivos = new System.Windows.Forms.ToolStripMenuItem();
            this.bActivos = new System.Windows.Forms.ToolStripMenuItem();
            this.mTiposActivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mActivosFijos = new System.Windows.Forms.ToolStripMenuItem();
            this.mHistoricoActivos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mDepreciacionActivos = new System.Windows.Forms.ToolStripMenuItem();
            this.bDepreciación = new System.Windows.Forms.ToolStripMenuItem();
            this.mVentana = new System.Windows.Forms.ToolStripMenuItem();
            this.mAuxiliarCuentaDeptos = new System.Windows.Forms.ToolStripMenuItem();
            this.Estado.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Estado
            // 
            this.Estado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.Estado.Location = new System.Drawing.Point(0, 539);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(977, 22);
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
            this.mActivos,
            this.mVentana});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.MdiWindowListItem = this.mVentana;
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(977, 24);
            this.menuMain.TabIndex = 4;
            this.menuMain.Text = "menuStrip1";
            // 
            // mArchivo
            // 
            this.mArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mPeriodosContables,
            this.mSalir});
            this.mArchivo.Name = "mArchivo";
            this.mArchivo.Size = new System.Drawing.Size(60, 20);
            this.mArchivo.Text = "Archivo";
            // 
            // mPeriodosContables
            // 
            this.mPeriodosContables.Name = "mPeriodosContables";
            this.mPeriodosContables.Size = new System.Drawing.Size(174, 22);
            this.mPeriodosContables.Text = "Periodos contables";
            // 
            // mSalir
            // 
            this.mSalir.Name = "mSalir";
            this.mSalir.Size = new System.Drawing.Size(174, 22);
            this.mSalir.Text = "Salir";
            // 
            // mCuentasPolizas
            // 
            this.mCuentasPolizas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCuentas,
            this.mPolizas,
            this.mBalanza,
            this.mSegmentos,
            this.mMonedas,
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
            this.mCuentas.Size = new System.Drawing.Size(180, 22);
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
            this.bPolizas,
            this.mConceptos,
            this.mTiposPoliza,
            this.mRangos,
            this.mContabilizarPeriodo});
            this.mPolizas.Name = "mPolizas";
            this.mPolizas.Size = new System.Drawing.Size(180, 22);
            this.mPolizas.Text = "Pólizas";
            // 
            // bPolizas
            // 
            this.bPolizas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mPolizasConsulta,
            this.mPolizasCaptura,
            this.mAuxiliares});
            this.bPolizas.Name = "bPolizas";
            this.bPolizas.Size = new System.Drawing.Size(186, 22);
            this.bPolizas.Text = "Pólizas";
            // 
            // mPolizasConsulta
            // 
            this.mPolizasConsulta.Name = "mPolizasConsulta";
            this.mPolizasConsulta.Size = new System.Drawing.Size(180, 22);
            this.mPolizasConsulta.Text = "Pólizas";
            // 
            // mPolizasCaptura
            // 
            this.mPolizasCaptura.Name = "mPolizasCaptura";
            this.mPolizasCaptura.Size = new System.Drawing.Size(180, 22);
            this.mPolizasCaptura.Text = "Captura";
            // 
            // mAuxiliares
            // 
            this.mAuxiliares.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAuxiliarCuentas,
            this.mAuxiliarCuentaDeptos});
            this.mAuxiliares.Name = "mAuxiliares";
            this.mAuxiliares.Size = new System.Drawing.Size(180, 22);
            this.mAuxiliares.Text = "Auxiliares";
            // 
            // mAuxiliarCuentas
            // 
            this.mAuxiliarCuentas.Name = "mAuxiliarCuentas";
            this.mAuxiliarCuentas.Size = new System.Drawing.Size(226, 22);
            this.mAuxiliarCuentas.Text = "Auxiliar de cuentas";
            // 
            // mContabilizarPeriodo
            // 
            this.mContabilizarPeriodo.Name = "mContabilizarPeriodo";
            this.mContabilizarPeriodo.Size = new System.Drawing.Size(186, 22);
            this.mContabilizarPeriodo.Text = "Contabilizar período";
            // 
            // mConceptos
            // 
            this.mConceptos.Name = "mConceptos";
            this.mConceptos.Size = new System.Drawing.Size(186, 22);
            this.mConceptos.Text = "Conceptos de pólizas";
            // 
            // mTiposPoliza
            // 
            this.mTiposPoliza.Name = "mTiposPoliza";
            this.mTiposPoliza.Size = new System.Drawing.Size(186, 22);
            this.mTiposPoliza.Text = "Tipos de póliza";
            // 
            // mRangos
            // 
            this.mRangos.Name = "mRangos";
            this.mRangos.Size = new System.Drawing.Size(186, 22);
            this.mRangos.Text = "Rangos";
            // 
            // mBalanza
            // 
            this.mBalanza.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mBalanzaComprobacion});
            this.mBalanza.Name = "mBalanza";
            this.mBalanza.Size = new System.Drawing.Size(180, 22);
            this.mBalanza.Text = "Balanza";
            // 
            // mBalanzaComprobacion
            // 
            this.mBalanzaComprobacion.Name = "mBalanzaComprobacion";
            this.mBalanzaComprobacion.Size = new System.Drawing.Size(211, 22);
            this.mBalanzaComprobacion.Text = "Balanza de comprobación";
            // 
            // mSegmentos
            // 
            this.mSegmentos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bDepartamentos,
            this.bCentroCostos,
            this.bProyectos});
            this.mSegmentos.Name = "mSegmentos";
            this.mSegmentos.Size = new System.Drawing.Size(180, 22);
            this.mSegmentos.Text = "Segmentos";
            // 
            // bDepartamentos
            // 
            this.bDepartamentos.Name = "bDepartamentos";
            this.bDepartamentos.Size = new System.Drawing.Size(163, 22);
            this.bDepartamentos.Text = "Departamentos";
            // 
            // bCentroCostos
            // 
            this.bCentroCostos.Name = "bCentroCostos";
            this.bCentroCostos.Size = new System.Drawing.Size(163, 22);
            this.bCentroCostos.Text = "Centro de costos";
            // 
            // bProyectos
            // 
            this.bProyectos.Name = "bProyectos";
            this.bProyectos.Size = new System.Drawing.Size(163, 22);
            this.bProyectos.Text = "Proyectos";
            // 
            // mAuditaria
            // 
            this.mAuditaria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAuditoriaCuentas,
            this.mAuditoriaRubros});
            this.mAuditaria.Name = "mAuditaria";
            this.mAuditaria.Size = new System.Drawing.Size(180, 22);
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
            // mMonedas
            // 
            this.mMonedas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bMonedas});
            this.mMonedas.Name = "mMonedas";
            this.mMonedas.Size = new System.Drawing.Size(180, 22);
            this.mMonedas.Text = "Monedas";
            // 
            // bMonedas
            // 
            this.bMonedas.Name = "bMonedas";
            this.bMonedas.Size = new System.Drawing.Size(123, 22);
            this.bMonedas.Text = "Monedas";
            // 
            // mActivos
            // 
            this.mActivos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bActivos,
            this.bDepreciación});
            this.mActivos.Name = "mActivos";
            this.mActivos.Size = new System.Drawing.Size(58, 20);
            this.mActivos.Text = "Activos";
            // 
            // bActivos
            // 
            this.bActivos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mTiposActivo,
            this.mActivosFijos,
            this.mHistoricoActivos,
            this.toolStripMenuItem3,
            this.mDepreciacionActivos});
            this.bActivos.Name = "bActivos";
            this.bActivos.Size = new System.Drawing.Size(143, 22);
            this.bActivos.Text = "Activos";
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
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem3.Text = "Tabla I.N.P.C.";
            // 
            // mDepreciacionActivos
            // 
            this.mDepreciacionActivos.Name = "mDepreciacionActivos";
            this.mDepreciacionActivos.Size = new System.Drawing.Size(201, 22);
            this.mDepreciacionActivos.Text = "Control de depreciación";
            // 
            // bDepreciación
            // 
            this.bDepreciación.Name = "bDepreciación";
            this.bDepreciación.Size = new System.Drawing.Size(143, 22);
            this.bDepreciación.Text = "Depreciación";
            // 
            // mVentana
            // 
            this.mVentana.Name = "mVentana";
            this.mVentana.Size = new System.Drawing.Size(61, 20);
            this.mVentana.Text = "Ventana";
            // 
            // mAuxiliarCuentaDeptos
            // 
            this.mAuxiliarCuentaDeptos.Name = "mAuxiliarCuentaDeptos";
            this.mAuxiliarCuentaDeptos.Size = new System.Drawing.Size(226, 22);
            this.mAuxiliarCuentaDeptos.Text = "Auxiliares con departamento";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 561);
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
        private System.Windows.Forms.ToolStripMenuItem mPeriodosContables;
        private System.Windows.Forms.ToolStripMenuItem mTiposPoliza;
        private System.Windows.Forms.ToolStripMenuItem mRangos;
        private System.Windows.Forms.ToolStripMenuItem bMonedas;
        private System.Windows.Forms.ToolStripMenuItem mTiposActivo;
        private System.Windows.Forms.ToolStripMenuItem mActivosFijos;
        private System.Windows.Forms.ToolStripMenuItem mHistoricoActivos;
        private System.Windows.Forms.ToolStripMenuItem mDepreciacionActivos;
        private System.Windows.Forms.ToolStripMenuItem mAuditaria;
        private System.Windows.Forms.ToolStripMenuItem mAuditoriaCuentas;
        private System.Windows.Forms.ToolStripMenuItem mAuditoriaRubros;
        private System.Windows.Forms.ToolStripMenuItem mBalanzaComprobacion;
        private System.Windows.Forms.ToolStripMenuItem mVentana;
        
        private System.Windows.Forms.ToolStripMenuItem mBalanza;
        private System.Windows.Forms.ToolStripMenuItem mMonedas;
        private System.Windows.Forms.ToolStripMenuItem mSegmentos;
        private System.Windows.Forms.ToolStripMenuItem bDepartamentos;
        private System.Windows.Forms.ToolStripMenuItem bCentroCostos;
        private System.Windows.Forms.ToolStripMenuItem bProyectos;
        private System.Windows.Forms.ToolStripMenuItem mActivos;
        private System.Windows.Forms.ToolStripMenuItem bActivos;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem bDepreciación;
        private System.Windows.Forms.ToolStripMenuItem mAuxiliares;
        private System.Windows.Forms.ToolStripMenuItem mAuxiliarCuentas;
        private System.Windows.Forms.ToolStripMenuItem bPolizas;
        private System.Windows.Forms.ToolStripMenuItem mAuxiliarCuentaDeptos;
    }
}