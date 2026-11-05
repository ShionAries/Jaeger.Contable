namespace Jaeger.Contable.WinForms.Forms {
    partial class PeriodoContabilizacionForm {
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
            this.lblEjercicio = new System.Windows.Forms.Label();
            this._cmbEjercicio = new System.Windows.Forms.ComboBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this._cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.grupo = new System.Windows.Forms.GroupBox();
            this._rdbSoloNoContabilizadas = new System.Windows.Forms.RadioButton();
            this._rdbTodas = new System.Windows.Forms.RadioButton();
            this._rdbSoloNoContabilizadasTipo = new System.Windows.Forms.RadioButton();
            this._btnCancelar = new System.Windows.Forms.Button();
            this._btnContabilizar = new System.Windows.Forms.Button();
            this._lblEstado = new System.Windows.Forms.Label();
            this._cmbTipoPoliza = new System.Windows.Forms.ComboBox();
            this.grupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEjercicio
            // 
            this.lblEjercicio.AutoSize = true;
            this.lblEjercicio.Location = new System.Drawing.Point(18, 20);
            this.lblEjercicio.Name = "lblEjercicio";
            this.lblEjercicio.Size = new System.Drawing.Size(50, 13);
            this.lblEjercicio.TabIndex = 0;
            this.lblEjercicio.Text = "Ejercicio:";
            // 
            // _cmbEjercicio
            // 
            this._cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbEjercicio.FormattingEnabled = true;
            this._cmbEjercicio.Location = new System.Drawing.Point(74, 16);
            this._cmbEjercicio.Name = "_cmbEjercicio";
            this._cmbEjercicio.Size = new System.Drawing.Size(193, 21);
            this._cmbEjercicio.TabIndex = 1;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(18, 47);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(46, 13);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Periodo:";
            // 
            // _cmbPeriodo
            // 
            this._cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbPeriodo.FormattingEnabled = true;
            this._cmbPeriodo.Location = new System.Drawing.Point(74, 43);
            this._cmbPeriodo.Name = "_cmbPeriodo";
            this._cmbPeriodo.Size = new System.Drawing.Size(193, 21);
            this._cmbPeriodo.TabIndex = 1;
            // 
            // grupo
            // 
            this.grupo.Controls.Add(this._rdbSoloNoContabilizadasTipo);
            this.grupo.Controls.Add(this._rdbTodas);
            this.grupo.Controls.Add(this._rdbSoloNoContabilizadas);
            this.grupo.Controls.Add(this._cmbTipoPoliza);
            this.grupo.Location = new System.Drawing.Point(18, 70);
            this.grupo.Name = "grupo";
            this.grupo.Size = new System.Drawing.Size(249, 140);
            this.grupo.TabIndex = 2;
            this.grupo.TabStop = false;
            this.grupo.Text = "Criterio de contabilización";
            // 
            // _rdbSoloNoContabilizadas
            // 
            this._rdbSoloNoContabilizadas.AutoSize = true;
            this._rdbSoloNoContabilizadas.Checked = true;
            this._rdbSoloNoContabilizadas.Location = new System.Drawing.Point(15, 25);
            this._rdbSoloNoContabilizadas.Name = "_rdbSoloNoContabilizadas";
            this._rdbSoloNoContabilizadas.Size = new System.Drawing.Size(131, 17);
            this._rdbSoloNoContabilizadas.TabIndex = 0;
            this._rdbSoloNoContabilizadas.TabStop = true;
            this._rdbSoloNoContabilizadas.Text = "Sólo no contabilizadas";
            this._rdbSoloNoContabilizadas.UseVisualStyleBackColor = true;
            // 
            // _rdbTodas
            // 
            this._rdbTodas.AutoSize = true;
            this._rdbTodas.Location = new System.Drawing.Point(15, 53);
            this._rdbTodas.Name = "_rdbTodas";
            this._rdbTodas.Size = new System.Drawing.Size(55, 17);
            this._rdbTodas.TabIndex = 0;
            this._rdbTodas.Text = "Todas";
            this._rdbTodas.UseVisualStyleBackColor = true;
            // 
            // _rdbSoloNoContabilizadasTipo
            // 
            this._rdbSoloNoContabilizadasTipo.AutoSize = true;
            this._rdbSoloNoContabilizadasTipo.Location = new System.Drawing.Point(15, 81);
            this._rdbSoloNoContabilizadasTipo.Name = "_rdbSoloNoContabilizadasTipo";
            this._rdbSoloNoContabilizadasTipo.Size = new System.Drawing.Size(185, 17);
            this._rdbSoloNoContabilizadasTipo.TabIndex = 0;
            this._rdbSoloNoContabilizadasTipo.Text = "Sólo las no contabilizadas de tipo:";
            this._rdbSoloNoContabilizadasTipo.UseVisualStyleBackColor = true;
            // 
            // _btnCancelar
            // 
            this._btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancelar.Location = new System.Drawing.Point(203, 247);
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(75, 23);
            this._btnCancelar.TabIndex = 3;
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.UseVisualStyleBackColor = true;
            // 
            // _btnContabilizar
            // 
            this._btnContabilizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnContabilizar.Location = new System.Drawing.Point(122, 247);
            this._btnContabilizar.Name = "_btnContabilizar";
            this._btnContabilizar.Size = new System.Drawing.Size(75, 23);
            this._btnContabilizar.TabIndex = 3;
            this._btnContabilizar.Text = "Contabilizar";
            this._btnContabilizar.UseVisualStyleBackColor = true;
            // 
            // _lblEstado
            // 
            this._lblEstado.AutoSize = true;
            this._lblEstado.Location = new System.Drawing.Point(15, 215);
            this._lblEstado.Name = "_lblEstado";
            this._lblEstado.Size = new System.Drawing.Size(170, 13);
            this._lblEstado.TabIndex = 0;
            this._lblEstado.Text = "Seleccione el ejercicio y el periodo";
            // 
            // _cmbTipoPoliza
            // 
            this._cmbTipoPoliza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbTipoPoliza.FormattingEnabled = true;
            this._cmbTipoPoliza.Location = new System.Drawing.Point(36, 104);
            this._cmbTipoPoliza.Name = "_cmbTipoPoliza";
            this._cmbTipoPoliza.Size = new System.Drawing.Size(195, 21);
            this._cmbTipoPoliza.TabIndex = 1;
            // 
            // PeriodoContabilizacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 282);
            this.Controls.Add(this._btnContabilizar);
            this.Controls.Add(this._btnCancelar);
            this.Controls.Add(this.grupo);
            this.Controls.Add(this._cmbPeriodo);
            this.Controls.Add(this._lblEstado);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this._cmbEjercicio);
            this.Controls.Add(this.lblEjercicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PeriodoContabilizacionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contabilización de pólizas";
            this.grupo.ResumeLayout(false);
            this.grupo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEjercicio;
        private System.Windows.Forms.ComboBox _cmbEjercicio;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ComboBox _cmbPeriodo;
        private System.Windows.Forms.GroupBox grupo;
        private System.Windows.Forms.RadioButton _rdbSoloNoContabilizadasTipo;
        private System.Windows.Forms.RadioButton _rdbTodas;
        private System.Windows.Forms.RadioButton _rdbSoloNoContabilizadas;
        private System.Windows.Forms.Button _btnCancelar;
        private System.Windows.Forms.Button _btnContabilizar;
        private System.Windows.Forms.Label _lblEstado;
        private System.Windows.Forms.ComboBox _cmbTipoPoliza;
    }
}