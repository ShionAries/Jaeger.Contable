namespace Jaeger.Contable.WinForms.Forms {
    partial class PeriodoContableAdministrarForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.Ejercicio = new System.Windows.Forms.NumericUpDown();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCrearEjercicio = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnBajar = new System.Windows.Forms.Button();
            this.btnAbrirPeriodo = new System.Windows.Forms.Button();
            this.btnCerrarPeriodo = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Periodo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Ejercicio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cerrado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CTPolizas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReqTrasp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Ejercicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ejercicio";
            // 
            // Ejercicio
            // 
            this.Ejercicio.Location = new System.Drawing.Point(57, 7);
            this.Ejercicio.Name = "Ejercicio";
            this.Ejercicio.Size = new System.Drawing.Size(78, 20);
            this.Ejercicio.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(145, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnCrearEjercicio
            // 
            this.btnCrearEjercicio.Location = new System.Drawing.Point(226, 6);
            this.btnCrearEjercicio.Name = "btnCrearEjercicio";
            this.btnCrearEjercicio.Size = new System.Drawing.Size(89, 23);
            this.btnCrearEjercicio.TabIndex = 2;
            this.btnCrearEjercicio.Text = "Crear ejercicio";
            this.btnCrearEjercicio.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(332, 11);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(35, 13);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "label1";
            // 
            // gridData
            // 
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Periodo,
            this.Ejercicio1,
            this.Cerrado,
            this.CTPolizas,
            this.ReqTrasp});
            this.gridData.Location = new System.Drawing.Point(10, 41);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersVisible = false;
            this.gridData.Size = new System.Drawing.Size(506, 237);
            this.gridData.TabIndex = 3;
            // 
            // btnSubir
            // 
            this.btnSubir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubir.Location = new System.Drawing.Point(12, 293);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(75, 23);
            this.btnSubir.TabIndex = 2;
            this.btnSubir.Text = "Subir";
            this.btnSubir.UseVisualStyleBackColor = true;
            // 
            // btnBajar
            // 
            this.btnBajar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBajar.Location = new System.Drawing.Point(93, 293);
            this.btnBajar.Name = "btnBajar";
            this.btnBajar.Size = new System.Drawing.Size(75, 23);
            this.btnBajar.TabIndex = 2;
            this.btnBajar.Text = "Bajar";
            this.btnBajar.UseVisualStyleBackColor = true;
            // 
            // btnAbrirPeriodo
            // 
            this.btnAbrirPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbrirPeriodo.Location = new System.Drawing.Point(174, 293);
            this.btnAbrirPeriodo.Name = "btnAbrirPeriodo";
            this.btnAbrirPeriodo.Size = new System.Drawing.Size(86, 23);
            this.btnAbrirPeriodo.TabIndex = 2;
            this.btnAbrirPeriodo.Text = "Abrir periodo";
            this.btnAbrirPeriodo.UseVisualStyleBackColor = true;
            // 
            // btnCerrarPeriodo
            // 
            this.btnCerrarPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCerrarPeriodo.Location = new System.Drawing.Point(266, 293);
            this.btnCerrarPeriodo.Name = "btnCerrarPeriodo";
            this.btnCerrarPeriodo.Size = new System.Drawing.Size(86, 23);
            this.btnCerrarPeriodo.TabIndex = 2;
            this.btnCerrarPeriodo.Text = "Cerrar Periodo";
            this.btnCerrarPeriodo.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(445, 293);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.Ejercicio);
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.btnCrearEjercicio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 35);
            this.panel1.TabIndex = 4;
            // 
            // Periodo
            // 
            this.Periodo.HeaderText = "Periodo";
            this.Periodo.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.Periodo.Name = "Periodo";
            this.Periodo.ReadOnly = true;
            // 
            // Ejercicio1
            // 
            this.Ejercicio1.DataPropertyName = "Ejercicio";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ejercicio1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Ejercicio1.HeaderText = "Ejercicio";
            this.Ejercicio1.Name = "Ejercicio1";
            this.Ejercicio1.ReadOnly = true;
            this.Ejercicio1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ejercicio1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cerrado
            // 
            this.Cerrado.HeaderText = "Auditado";
            this.Cerrado.Name = "Cerrado";
            this.Cerrado.ReadOnly = true;
            // 
            // CTPolizas
            // 
            this.CTPolizas.DataPropertyName = "CtPolizas";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = false;
            this.CTPolizas.DefaultCellStyle = dataGridViewCellStyle2;
            this.CTPolizas.HeaderText = "Pólizas no contabilizadas";
            this.CTPolizas.Name = "CTPolizas";
            this.CTPolizas.ReadOnly = true;
            this.CTPolizas.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ReqTrasp
            // 
            this.ReqTrasp.DataPropertyName = "ReqTrasp";
            this.ReqTrasp.HeaderText = "Requiere traspaso?";
            this.ReqTrasp.Name = "ReqTrasp";
            this.ReqTrasp.ReadOnly = true;
            this.ReqTrasp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ReqTrasp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PeriodoContableAdministrarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 328);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCerrarPeriodo);
            this.Controls.Add(this.btnBajar);
            this.Controls.Add(this.btnAbrirPeriodo);
            this.Controls.Add(this.btnSubir);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PeriodoContableAdministrarForm";
            this.ShowInTaskbar = false;
            this.Text = "Periodos Contables";
            ((System.ComponentModel.ISupportInitialize)(this.Ejercicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Ejercicio;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCrearEjercicio;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnBajar;
        private System.Windows.Forms.Button btnAbrirPeriodo;
        private System.Windows.Forms.Button btnCerrarPeriodo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Periodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ejercicio1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cerrado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CTPolizas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ReqTrasp;
    }
}