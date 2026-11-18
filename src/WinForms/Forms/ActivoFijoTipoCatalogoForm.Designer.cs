namespace Jaeger.Contable.WinForms.Forms {
    partial class ActivoFijoTipoCatalogoForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.numClave = new System.Windows.Forms.NumericUpDown();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepresiacionNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepresiacionInmediata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaximoDepresiacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetodoDepresiacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepresiacionProyectada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMoneda = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtMetodo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblPrefijo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblDepNormal = new System.Windows.Forms.Label();
            this.numDedNormal = new System.Windows.Forms.NumericUpDown();
            this.lblDepInmediata = new System.Windows.Forms.Label();
            this.numDedImed = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDepresia = new System.Windows.Forms.Label();
            this.lblDepProyectada = new System.Windows.Forms.Label();
            this.numMaxDepresiacion = new System.Windows.Forms.NumericUpDown();
            this.numDepProyectada = new System.Windows.Forms.NumericUpDown();
            this.lblCuentActiva = new System.Windows.Forms.Label();
            this.txtCtaActivo = new System.Windows.Forms.TextBox();
            this.lblCuentaDepresiacion = new System.Windows.Forms.Label();
            this.txtCtaDepre = new System.Windows.Forms.TextBox();
            this.lblCuentaGastos = new System.Windows.Forms.Label();
            this.lblCuentaGanancias = new System.Windows.Forms.Label();
            this.txtCtaGastos = new System.Windows.Forms.TextBox();
            this.txtCtaGan = new System.Windows.Forms.TextBox();
            this.grpInformacion = new System.Windows.Forms.GroupBox();
            this.btnCuentaGanancia = new System.Windows.Forms.Button();
            this.btnCuentaGastos = new System.Windows.Forms.Button();
            this.btnCuentaDepresia = new System.Windows.Forms.Button();
            this.btnCuentaActivo = new System.Windows.Forms.Button();
            this.btnMetodoDep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numClave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDedNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDedImed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDepresiacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDepProyectada)).BeginInit();
            this.grpInformacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(773, 381);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 30;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(172, 381);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.Location = new System.Drawing.Point(91, 381);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 28;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.Location = new System.Drawing.Point(10, 381);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 27;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // cboMoneda
            // 
            this.cboMoneda.DisplayMember = "Nombre";
            this.cboMoneda.Location = new System.Drawing.Point(695, 19);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(128, 21);
            this.cboMoneda.TabIndex = 24;
            // 
            // numClave
            // 
            this.numClave.Location = new System.Drawing.Point(52, 19);
            this.numClave.Name = "numClave";
            this.numClave.Size = new System.Drawing.Size(89, 20);
            this.numClave.TabIndex = 22;
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Descripcion,
            this.DepresiacionNormal,
            this.DepresiacionInmediata,
            this.MaximoDepresiacion,
            this.MetodoDepresiacion,
            this.DepresiacionProyectada,
            this.IdMoneda});
            this.gridData.Location = new System.Drawing.Point(12, 42);
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            this.gridData.RowHeadersVisible = false;
            this.gridData.Size = new System.Drawing.Size(831, 185);
            this.gridData.TabIndex = 21;
            // 
            // Clave
            // 
            this.Clave.DataPropertyName = "Clave";
            this.Clave.FillWeight = 50F;
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Width = 50;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 88;
            // 
            // DepresiacionNormal
            // 
            this.DepresiacionNormal.DataPropertyName = "DepresiacionNormal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = "0.00";
            this.DepresiacionNormal.DefaultCellStyle = dataGridViewCellStyle5;
            this.DepresiacionNormal.HeaderText = "Dep. normal";
            this.DepresiacionNormal.Name = "DepresiacionNormal";
            this.DepresiacionNormal.ReadOnly = true;
            // 
            // DepresiacionInmediata
            // 
            this.DepresiacionInmediata.DataPropertyName = "DepresiacionInmediata";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N4";
            this.DepresiacionInmediata.DefaultCellStyle = dataGridViewCellStyle6;
            this.DepresiacionInmediata.HeaderText = "Dep. inmediata";
            this.DepresiacionInmediata.Name = "DepresiacionInmediata";
            this.DepresiacionInmediata.ReadOnly = true;
            // 
            // MaximoDepresiacion
            // 
            this.MaximoDepresiacion.DataPropertyName = "MaximoDepresiacion";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N4";
            this.MaximoDepresiacion.DefaultCellStyle = dataGridViewCellStyle7;
            this.MaximoDepresiacion.HeaderText = "Máx. ded.";
            this.MaximoDepresiacion.Name = "MaximoDepresiacion";
            this.MaximoDepresiacion.ReadOnly = true;
            // 
            // MetodoDepresiacion
            // 
            this.MetodoDepresiacion.DataPropertyName = "MetodoDepresiacion";
            this.MetodoDepresiacion.HeaderText = "Método";
            this.MetodoDepresiacion.Name = "MetodoDepresiacion";
            this.MetodoDepresiacion.ReadOnly = true;
            // 
            // DepresiacionProyectada
            // 
            this.DepresiacionProyectada.DataPropertyName = "DepresiacionProyectada";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N4";
            this.DepresiacionProyectada.DefaultCellStyle = dataGridViewCellStyle8;
            this.DepresiacionProyectada.HeaderText = "Dep. proyectada";
            this.DepresiacionProyectada.Name = "DepresiacionProyectada";
            this.DepresiacionProyectada.ReadOnly = true;
            // 
            // IdMoneda
            // 
            this.IdMoneda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IdMoneda.DataPropertyName = "IdMoneda";
            this.IdMoneda.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.IdMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IdMoneda.HeaderText = "Moneda";
            this.IdMoneda.Name = "IdMoneda";
            this.IdMoneda.ReadOnly = true;
            this.IdMoneda.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdMoneda.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IdMoneda.Width = 71;
            // 
            // txtMetodo
            // 
            this.txtMetodo.Location = new System.Drawing.Point(522, 19);
            this.txtMetodo.Name = "txtMetodo";
            this.txtMetodo.Size = new System.Drawing.Size(73, 20);
            this.txtMetodo.TabIndex = 20;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(219, 19);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(226, 20);
            this.txtDescripcion.TabIndex = 17;
            // 
            // lblPrefijo
            // 
            this.lblPrefijo.AutoSize = true;
            this.lblPrefijo.Location = new System.Drawing.Point(449, 23);
            this.lblPrefijo.Name = "lblPrefijo";
            this.lblPrefijo.Size = new System.Drawing.Size(67, 13);
            this.lblPrefijo.TabIndex = 13;
            this.lblPrefijo.Text = "Método dep:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(58, 16);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(397, 20);
            this.txtBuscar.TabIndex = 16;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(147, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(66, 13);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Descripción:";
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(640, 23);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 10;
            this.lblMoneda.Text = "Moneda:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 23);
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
            // lblDepNormal
            // 
            this.lblDepNormal.AutoSize = true;
            this.lblDepNormal.Location = new System.Drawing.Point(6, 54);
            this.lblDepNormal.Name = "lblDepNormal";
            this.lblDepNormal.Size = new System.Drawing.Size(69, 13);
            this.lblDepNormal.TabIndex = 10;
            this.lblDepNormal.Text = "Dep. Normal:";
            // 
            // numDedNormal
            // 
            this.numDedNormal.Location = new System.Drawing.Point(81, 50);
            this.numDedNormal.Name = "numDedNormal";
            this.numDedNormal.Size = new System.Drawing.Size(98, 20);
            this.numDedNormal.TabIndex = 24;
            // 
            // lblDepInmediata
            // 
            this.lblDepInmediata.AutoSize = true;
            this.lblDepInmediata.Location = new System.Drawing.Point(185, 54);
            this.lblDepInmediata.Name = "lblDepInmediata";
            this.lblDepInmediata.Size = new System.Drawing.Size(82, 13);
            this.lblDepInmediata.TabIndex = 10;
            this.lblDepInmediata.Text = "Dep. Inmediata:";
            // 
            // numDedImed
            // 
            this.numDedImed.Location = new System.Drawing.Point(273, 50);
            this.numDedImed.Name = "numDedImed";
            this.numDedImed.Size = new System.Drawing.Size(98, 20);
            this.numDedImed.TabIndex = 24;
            // 
            // lblMaxDepresia
            // 
            this.lblMaxDepresia.AutoSize = true;
            this.lblMaxDepresia.Location = new System.Drawing.Point(377, 54);
            this.lblMaxDepresia.Name = "lblMaxDepresia";
            this.lblMaxDepresia.Size = new System.Drawing.Size(96, 13);
            this.lblMaxDepresia.TabIndex = 10;
            this.lblMaxDepresia.Text = "Máx. depresiación:";
            // 
            // lblDepProyectada
            // 
            this.lblDepProyectada.AutoSize = true;
            this.lblDepProyectada.Location = new System.Drawing.Point(580, 54);
            this.lblDepProyectada.Name = "lblDepProyectada";
            this.lblDepProyectada.Size = new System.Drawing.Size(90, 13);
            this.lblDepProyectada.TabIndex = 10;
            this.lblDepProyectada.Text = "Dep. Proyectada:";
            // 
            // numMaxDepresiacion
            // 
            this.numMaxDepresiacion.Location = new System.Drawing.Point(475, 50);
            this.numMaxDepresiacion.Name = "numMaxDepresiacion";
            this.numMaxDepresiacion.Size = new System.Drawing.Size(98, 20);
            this.numMaxDepresiacion.TabIndex = 24;
            // 
            // numDepProyectada
            // 
            this.numDepProyectada.Location = new System.Drawing.Point(676, 50);
            this.numDepProyectada.Name = "numDepProyectada";
            this.numDepProyectada.Size = new System.Drawing.Size(98, 20);
            this.numDepProyectada.TabIndex = 24;
            // 
            // lblCuentActiva
            // 
            this.lblCuentActiva.AutoSize = true;
            this.lblCuentActiva.Location = new System.Drawing.Point(8, 83);
            this.lblCuentActiva.Name = "lblCuentActiva";
            this.lblCuentActiva.Size = new System.Drawing.Size(76, 13);
            this.lblCuentActiva.TabIndex = 11;
            this.lblCuentActiva.Text = "Cuenta activo:";
            // 
            // txtCtaActivo
            // 
            this.txtCtaActivo.Location = new System.Drawing.Point(8, 101);
            this.txtCtaActivo.Name = "txtCtaActivo";
            this.txtCtaActivo.Size = new System.Drawing.Size(150, 20);
            this.txtCtaActivo.TabIndex = 17;
            // 
            // lblCuentaDepresiacion
            // 
            this.lblCuentaDepresiacion.AutoSize = true;
            this.lblCuentaDepresiacion.Location = new System.Drawing.Point(202, 83);
            this.lblCuentaDepresiacion.Name = "lblCuentaDepresiacion";
            this.lblCuentaDepresiacion.Size = new System.Drawing.Size(107, 13);
            this.lblCuentaDepresiacion.TabIndex = 11;
            this.lblCuentaDepresiacion.Text = "Cuenta depresiación:";
            // 
            // txtCtaDepre
            // 
            this.txtCtaDepre.Location = new System.Drawing.Point(202, 101);
            this.txtCtaDepre.Name = "txtCtaDepre";
            this.txtCtaDepre.Size = new System.Drawing.Size(150, 20);
            this.txtCtaDepre.TabIndex = 17;
            // 
            // lblCuentaGastos
            // 
            this.lblCuentaGastos.AutoSize = true;
            this.lblCuentaGastos.Location = new System.Drawing.Point(398, 83);
            this.lblCuentaGastos.Name = "lblCuentaGastos";
            this.lblCuentaGastos.Size = new System.Drawing.Size(78, 13);
            this.lblCuentaGastos.TabIndex = 11;
            this.lblCuentaGastos.Text = "Cuenta gastos:";
            // 
            // lblCuentaGanancias
            // 
            this.lblCuentaGanancias.AutoSize = true;
            this.lblCuentaGanancias.Location = new System.Drawing.Point(594, 82);
            this.lblCuentaGanancias.Name = "lblCuentaGanancias";
            this.lblCuentaGanancias.Size = new System.Drawing.Size(96, 13);
            this.lblCuentaGanancias.TabIndex = 11;
            this.lblCuentaGanancias.Text = "Cuenta ganancias:";
            // 
            // txtCtaGastos
            // 
            this.txtCtaGastos.Location = new System.Drawing.Point(398, 101);
            this.txtCtaGastos.Name = "txtCtaGastos";
            this.txtCtaGastos.Size = new System.Drawing.Size(150, 20);
            this.txtCtaGastos.TabIndex = 17;
            // 
            // txtCtaGan
            // 
            this.txtCtaGan.Location = new System.Drawing.Point(594, 102);
            this.txtCtaGan.Name = "txtCtaGan";
            this.txtCtaGan.Size = new System.Drawing.Size(150, 20);
            this.txtCtaGan.TabIndex = 17;
            // 
            // grpInformacion
            // 
            this.grpInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInformacion.Controls.Add(this.btnMetodoDep);
            this.grpInformacion.Controls.Add(this.btnCuentaGanancia);
            this.grpInformacion.Controls.Add(this.btnCuentaGastos);
            this.grpInformacion.Controls.Add(this.btnCuentaDepresia);
            this.grpInformacion.Controls.Add(this.btnCuentaActivo);
            this.grpInformacion.Controls.Add(this.lblCodigo);
            this.grpInformacion.Controls.Add(this.lblMoneda);
            this.grpInformacion.Controls.Add(this.lblNombre);
            this.grpInformacion.Controls.Add(this.lblDepNormal);
            this.grpInformacion.Controls.Add(this.lblCuentActiva);
            this.grpInformacion.Controls.Add(this.numDepProyectada);
            this.grpInformacion.Controls.Add(this.lblCuentaGastos);
            this.grpInformacion.Controls.Add(this.numDedImed);
            this.grpInformacion.Controls.Add(this.lblMaxDepresia);
            this.grpInformacion.Controls.Add(this.numMaxDepresiacion);
            this.grpInformacion.Controls.Add(this.lblCuentaDepresiacion);
            this.grpInformacion.Controls.Add(this.numDedNormal);
            this.grpInformacion.Controls.Add(this.lblCuentaGanancias);
            this.grpInformacion.Controls.Add(this.cboMoneda);
            this.grpInformacion.Controls.Add(this.lblDepInmediata);
            this.grpInformacion.Controls.Add(this.numClave);
            this.grpInformacion.Controls.Add(this.lblDepProyectada);
            this.grpInformacion.Controls.Add(this.lblPrefijo);
            this.grpInformacion.Controls.Add(this.txtMetodo);
            this.grpInformacion.Controls.Add(this.txtDescripcion);
            this.grpInformacion.Controls.Add(this.txtCtaGan);
            this.grpInformacion.Controls.Add(this.txtCtaActivo);
            this.grpInformacion.Controls.Add(this.txtCtaDepre);
            this.grpInformacion.Controls.Add(this.txtCtaGastos);
            this.grpInformacion.Location = new System.Drawing.Point(10, 233);
            this.grpInformacion.Name = "grpInformacion";
            this.grpInformacion.Size = new System.Drawing.Size(833, 133);
            this.grpInformacion.TabIndex = 31;
            this.grpInformacion.TabStop = false;
            // 
            // btnCuentaGanancia
            // 
            this.btnCuentaGanancia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCuentaGanancia.Location = new System.Drawing.Point(750, 102);
            this.btnCuentaGanancia.Name = "btnCuentaGanancia";
            this.btnCuentaGanancia.Size = new System.Drawing.Size(34, 20);
            this.btnCuentaGanancia.TabIndex = 32;
            this.btnCuentaGanancia.Text = "...";
            this.btnCuentaGanancia.UseVisualStyleBackColor = true;
            // 
            // btnCuentaGastos
            // 
            this.btnCuentaGastos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCuentaGastos.Location = new System.Drawing.Point(554, 101);
            this.btnCuentaGastos.Name = "btnCuentaGastos";
            this.btnCuentaGastos.Size = new System.Drawing.Size(34, 20);
            this.btnCuentaGastos.TabIndex = 32;
            this.btnCuentaGastos.Text = "...";
            this.btnCuentaGastos.UseVisualStyleBackColor = true;
            // 
            // btnCuentaDepresia
            // 
            this.btnCuentaDepresia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCuentaDepresia.Location = new System.Drawing.Point(358, 101);
            this.btnCuentaDepresia.Name = "btnCuentaDepresia";
            this.btnCuentaDepresia.Size = new System.Drawing.Size(34, 20);
            this.btnCuentaDepresia.TabIndex = 32;
            this.btnCuentaDepresia.Text = "...";
            this.btnCuentaDepresia.UseVisualStyleBackColor = true;
            // 
            // btnCuentaActivo
            // 
            this.btnCuentaActivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCuentaActivo.Location = new System.Drawing.Point(162, 101);
            this.btnCuentaActivo.Name = "btnCuentaActivo";
            this.btnCuentaActivo.Size = new System.Drawing.Size(34, 20);
            this.btnCuentaActivo.TabIndex = 32;
            this.btnCuentaActivo.Text = "...";
            this.btnCuentaActivo.UseVisualStyleBackColor = true;
            // 
            // btnMetodoDep
            // 
            this.btnMetodoDep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMetodoDep.Location = new System.Drawing.Point(601, 19);
            this.btnMetodoDep.Name = "btnMetodoDep";
            this.btnMetodoDep.Size = new System.Drawing.Size(34, 20);
            this.btnMetodoDep.TabIndex = 32;
            this.btnMetodoDep.Text = "...";
            this.btnMetodoDep.UseVisualStyleBackColor = true;
            // 
            // ActivoFijoTipoCatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 416);
            this.Controls.Add(this.grpInformacion);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(876, 455);
            this.Name = "ActivoFijoTipoCatalogoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipo Activo Catálogo";
            ((System.ComponentModel.ISupportInitialize)(this.numClave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDedNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDedImed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDepresiacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDepProyectada)).EndInit();
            this.grpInformacion.ResumeLayout(false);
            this.grpInformacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.NumericUpDown numClave;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.TextBox txtMetodo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblPrefijo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblDepNormal;
        private System.Windows.Forms.NumericUpDown numDedNormal;
        private System.Windows.Forms.Label lblDepInmediata;
        private System.Windows.Forms.NumericUpDown numDedImed;
        private System.Windows.Forms.Label lblMaxDepresia;
        private System.Windows.Forms.Label lblDepProyectada;
        private System.Windows.Forms.NumericUpDown numMaxDepresiacion;
        private System.Windows.Forms.NumericUpDown numDepProyectada;
        private System.Windows.Forms.Label lblCuentActiva;
        private System.Windows.Forms.TextBox txtCtaActivo;
        private System.Windows.Forms.Label lblCuentaDepresiacion;
        private System.Windows.Forms.TextBox txtCtaDepre;
        private System.Windows.Forms.Label lblCuentaGastos;
        private System.Windows.Forms.Label lblCuentaGanancias;
        private System.Windows.Forms.TextBox txtCtaGastos;
        private System.Windows.Forms.TextBox txtCtaGan;
        private System.Windows.Forms.GroupBox grpInformacion;
        private System.Windows.Forms.Button btnCuentaGastos;
        private System.Windows.Forms.Button btnCuentaDepresia;
        private System.Windows.Forms.Button btnCuentaActivo;
        private System.Windows.Forms.Button btnCuentaGanancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepresiacionNormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepresiacionInmediata;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaximoDepresiacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetodoDepresiacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepresiacionProyectada;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdMoneda;
        private System.Windows.Forms.Button btnMetodoDep;
    }
}