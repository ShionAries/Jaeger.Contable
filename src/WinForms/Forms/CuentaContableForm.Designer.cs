namespace Jaeger.Contable.Forms {
    partial class CuentaContableForm {
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
            this.groupCuenta = new System.Windows.Forms.GroupBox();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.labelNoCuenta = new System.Windows.Forms.Label();
            this.txtNoCuenta = new System.Windows.Forms.MaskedTextBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.listRubros = new System.Windows.Forms.ListBox();
            this.groupTipo = new System.Windows.Forms.GroupBox();
            this.Detalle = new System.Windows.Forms.RadioButton();
            this.Acumulativa = new System.Windows.Forms.RadioButton();
            this.tabPageFiscales = new System.Windows.Forms.TabControl();
            this.tabPageGenerales = new System.Windows.Forms.TabPage();
            this.maskedCuentaPadre = new System.Windows.Forms.MaskedTextBox();
            this.groupSaldoMonedaExtranjera = new System.Windows.Forms.GroupBox();
            this.textSaldoFinalExtranjera = new System.Windows.Forms.TextBox();
            this.textSaldoInicialExtranjera = new System.Windows.Forms.TextBox();
            this.labelSaldoInicialExtranjera = new System.Windows.Forms.Label();
            this.labelSaldoFinalExtranjera = new System.Windows.Forms.Label();
            this.groupSaldoMonetaContable = new System.Windows.Forms.GroupBox();
            this.textSaldoFinalContable = new System.Windows.Forms.TextBox();
            this.textSaldoInicialContable = new System.Windows.Forms.TextBox();
            this.labelSaldoFinalContable = new System.Windows.Forms.Label();
            this.labelSaldoInicialContable = new System.Windows.Forms.Label();
            this.labelTipoMoneda = new System.Windows.Forms.Label();
            this.checkAfectaPolizaAjuste = new System.Windows.Forms.CheckBox();
            this.TipoMoneda = new System.Windows.Forms.ComboBox();
            this.EsDepartamental = new System.Windows.Forms.CheckBox();
            this.tabPageAtributos = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDesasocuarCeunta = new System.Windows.Forms.Button();
            this.groupNaturaleza = new System.Windows.Forms.GroupBox();
            this.radioNaturalezaAcreedora = new System.Windows.Forms.RadioButton();
            this.radioNaturalezaDeudora = new System.Windows.Forms.RadioButton();
            this.buttonAsociarCuenta = new System.Windows.Forms.Button();
            this.labelPerteneceRubros = new System.Windows.Forms.Label();
            this.textContraPartida = new System.Windows.Forms.MaskedTextBox();
            this.labelContraPartida = new System.Windows.Forms.Label();
            this.Fiscales = new System.Windows.Forms.TabPage();
            this.labelAplicarTerceros = new System.Windows.Forms.Label();
            this.labelFiscalNombre = new System.Windows.Forms.Label();
            this.labelAplicarFormaPago = new System.Windows.Forms.Label();
            this.textRazonSocial = new System.Windows.Forms.TextBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.labelIDFiscal = new System.Windows.Forms.Label();
            this.comboAplicarFormaPago = new System.Windows.Forms.ComboBox();
            this.textIdFiscal = new System.Windows.Forms.TextBox();
            this.checkOperacionConTerceros = new System.Windows.Forms.CheckBox();
            this.labelRFC = new System.Windows.Forms.Label();
            this.checkCapturaComprobantes = new System.Windows.Forms.CheckBox();
            this.textRFC = new System.Windows.Forms.TextBox();
            this.checkCapturaFormaPago = new System.Windows.Forms.CheckBox();
            this.buttonBuscarDirectorio = new System.Windows.Forms.Button();
            this.labelCodigoAgrupador = new System.Windows.Forms.Label();
            this.buttonSAT = new System.Windows.Forms.Button();
            this.comboCodigoAgrupador = new System.Windows.Forms.ComboBox();
            this.Aceptar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Guardar = new System.Windows.Forms.Button();
            this.Ayuda = new System.Windows.Forms.Button();
            this.groupCuenta.SuspendLayout();
            this.groupTipo.SuspendLayout();
            this.tabPageFiscales.SuspendLayout();
            this.tabPageGenerales.SuspendLayout();
            this.groupSaldoMonedaExtranjera.SuspendLayout();
            this.groupSaldoMonetaContable.SuspendLayout();
            this.tabPageAtributos.SuspendLayout();
            this.groupNaturaleza.SuspendLayout();
            this.Fiscales.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupCuenta
            // 
            this.groupCuenta.Controls.Add(this.textDescripcion);
            this.groupCuenta.Controls.Add(this.labelNoCuenta);
            this.groupCuenta.Controls.Add(this.txtNoCuenta);
            this.groupCuenta.Controls.Add(this.labelDescripcion);
            this.groupCuenta.Location = new System.Drawing.Point(12, 12);
            this.groupCuenta.Name = "groupCuenta";
            this.groupCuenta.Size = new System.Drawing.Size(287, 78);
            this.groupCuenta.TabIndex = 0;
            this.groupCuenta.TabStop = false;
            this.groupCuenta.Text = "Cuenta";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(87, 46);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(194, 20);
            this.textDescripcion.TabIndex = 5;
            // 
            // labelNoCuenta
            // 
            this.labelNoCuenta.AutoSize = true;
            this.labelNoCuenta.Location = new System.Drawing.Point(6, 22);
            this.labelNoCuenta.Name = "labelNoCuenta";
            this.labelNoCuenta.Size = new System.Drawing.Size(75, 13);
            this.labelNoCuenta.TabIndex = 3;
            this.labelNoCuenta.Text = "No. de cuenta";
            // 
            // txtNoCuenta
            // 
            this.txtNoCuenta.Location = new System.Drawing.Point(87, 19);
            this.txtNoCuenta.Name = "txtNoCuenta";
            this.txtNoCuenta.Size = new System.Drawing.Size(194, 20);
            this.txtNoCuenta.TabIndex = 4;
            this.txtNoCuenta.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(6, 49);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(63, 13);
            this.labelDescripcion.TabIndex = 3;
            this.labelDescripcion.Text = "Descripción";
            // 
            // listRubros
            // 
            this.listRubros.FormattingEnabled = true;
            this.listRubros.Location = new System.Drawing.Point(140, 34);
            this.listRubros.Name = "listRubros";
            this.listRubros.Size = new System.Drawing.Size(129, 69);
            this.listRubros.TabIndex = 5;
            // 
            // groupTipo
            // 
            this.groupTipo.Controls.Add(this.Detalle);
            this.groupTipo.Controls.Add(this.Acumulativa);
            this.groupTipo.Location = new System.Drawing.Point(305, 12);
            this.groupTipo.Name = "groupTipo";
            this.groupTipo.Size = new System.Drawing.Size(95, 78);
            this.groupTipo.TabIndex = 1;
            this.groupTipo.TabStop = false;
            this.groupTipo.Text = "Tipo";
            // 
            // Detalle
            // 
            this.Detalle.AutoSize = true;
            this.Detalle.Location = new System.Drawing.Point(6, 45);
            this.Detalle.Name = "Detalle";
            this.Detalle.Size = new System.Drawing.Size(58, 17);
            this.Detalle.TabIndex = 0;
            this.Detalle.TabStop = true;
            this.Detalle.Text = "Detalle";
            this.Detalle.UseVisualStyleBackColor = true;
            // 
            // Acumulativa
            // 
            this.Acumulativa.AutoSize = true;
            this.Acumulativa.Location = new System.Drawing.Point(6, 22);
            this.Acumulativa.Name = "Acumulativa";
            this.Acumulativa.Size = new System.Drawing.Size(83, 17);
            this.Acumulativa.TabIndex = 0;
            this.Acumulativa.TabStop = true;
            this.Acumulativa.Text = "Acumulativa";
            this.Acumulativa.UseVisualStyleBackColor = true;
            // 
            // tabPageFiscales
            // 
            this.tabPageFiscales.Controls.Add(this.tabPageGenerales);
            this.tabPageFiscales.Controls.Add(this.tabPageAtributos);
            this.tabPageFiscales.Controls.Add(this.Fiscales);
            this.tabPageFiscales.Location = new System.Drawing.Point(12, 96);
            this.tabPageFiscales.Name = "tabPageFiscales";
            this.tabPageFiscales.SelectedIndex = 0;
            this.tabPageFiscales.Size = new System.Drawing.Size(392, 220);
            this.tabPageFiscales.TabIndex = 2;
            // 
            // tabPageGenerales
            // 
            this.tabPageGenerales.Controls.Add(this.maskedCuentaPadre);
            this.tabPageGenerales.Controls.Add(this.groupSaldoMonedaExtranjera);
            this.tabPageGenerales.Controls.Add(this.groupSaldoMonetaContable);
            this.tabPageGenerales.Controls.Add(this.labelTipoMoneda);
            this.tabPageGenerales.Controls.Add(this.checkAfectaPolizaAjuste);
            this.tabPageGenerales.Controls.Add(this.TipoMoneda);
            this.tabPageGenerales.Controls.Add(this.EsDepartamental);
            this.tabPageGenerales.Location = new System.Drawing.Point(4, 22);
            this.tabPageGenerales.Name = "tabPageGenerales";
            this.tabPageGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGenerales.Size = new System.Drawing.Size(384, 194);
            this.tabPageGenerales.TabIndex = 0;
            this.tabPageGenerales.Text = "Generales";
            this.tabPageGenerales.UseVisualStyleBackColor = true;
            // 
            // maskedCuentaPadre
            // 
            this.maskedCuentaPadre.Location = new System.Drawing.Point(9, 157);
            this.maskedCuentaPadre.Mask = "0000-000-000-00";
            this.maskedCuentaPadre.Name = "maskedCuentaPadre";
            this.maskedCuentaPadre.Size = new System.Drawing.Size(92, 20);
            this.maskedCuentaPadre.TabIndex = 7;
            // 
            // groupSaldoMonedaExtranjera
            // 
            this.groupSaldoMonedaExtranjera.Controls.Add(this.textSaldoFinalExtranjera);
            this.groupSaldoMonedaExtranjera.Controls.Add(this.textSaldoInicialExtranjera);
            this.groupSaldoMonedaExtranjera.Controls.Add(this.labelSaldoInicialExtranjera);
            this.groupSaldoMonedaExtranjera.Controls.Add(this.labelSaldoFinalExtranjera);
            this.groupSaldoMonedaExtranjera.Location = new System.Drawing.Point(195, 63);
            this.groupSaldoMonedaExtranjera.Name = "groupSaldoMonedaExtranjera";
            this.groupSaldoMonedaExtranjera.Size = new System.Drawing.Size(180, 88);
            this.groupSaldoMonedaExtranjera.TabIndex = 6;
            this.groupSaldoMonedaExtranjera.TabStop = false;
            this.groupSaldoMonedaExtranjera.Text = "Saldos en moneda extranjera";
            // 
            // textSaldoFinalExtranjera
            // 
            this.textSaldoFinalExtranjera.Location = new System.Drawing.Point(69, 51);
            this.textSaldoFinalExtranjera.Name = "textSaldoFinalExtranjera";
            this.textSaldoFinalExtranjera.Size = new System.Drawing.Size(76, 20);
            this.textSaldoFinalExtranjera.TabIndex = 14;
            // 
            // textSaldoInicialExtranjera
            // 
            this.textSaldoInicialExtranjera.Location = new System.Drawing.Point(69, 25);
            this.textSaldoInicialExtranjera.Name = "textSaldoInicialExtranjera";
            this.textSaldoInicialExtranjera.Size = new System.Drawing.Size(76, 20);
            this.textSaldoInicialExtranjera.TabIndex = 12;
            // 
            // labelSaldoInicialExtranjera
            // 
            this.labelSaldoInicialExtranjera.AutoSize = true;
            this.labelSaldoInicialExtranjera.Location = new System.Drawing.Point(34, 28);
            this.labelSaldoInicialExtranjera.Name = "labelSaldoInicialExtranjera";
            this.labelSaldoInicialExtranjera.Size = new System.Drawing.Size(34, 13);
            this.labelSaldoInicialExtranjera.TabIndex = 11;
            this.labelSaldoInicialExtranjera.Text = "Inicial";
            // 
            // labelSaldoFinalExtranjera
            // 
            this.labelSaldoFinalExtranjera.AutoSize = true;
            this.labelSaldoFinalExtranjera.Location = new System.Drawing.Point(34, 54);
            this.labelSaldoFinalExtranjera.Name = "labelSaldoFinalExtranjera";
            this.labelSaldoFinalExtranjera.Size = new System.Drawing.Size(29, 13);
            this.labelSaldoFinalExtranjera.TabIndex = 13;
            this.labelSaldoFinalExtranjera.Text = "Final";
            // 
            // groupSaldoMonetaContable
            // 
            this.groupSaldoMonetaContable.Controls.Add(this.textSaldoFinalContable);
            this.groupSaldoMonetaContable.Controls.Add(this.textSaldoInicialContable);
            this.groupSaldoMonetaContable.Controls.Add(this.labelSaldoFinalContable);
            this.groupSaldoMonetaContable.Controls.Add(this.labelSaldoInicialContable);
            this.groupSaldoMonetaContable.Location = new System.Drawing.Point(9, 63);
            this.groupSaldoMonetaContable.Name = "groupSaldoMonetaContable";
            this.groupSaldoMonetaContable.Size = new System.Drawing.Size(180, 88);
            this.groupSaldoMonetaContable.TabIndex = 5;
            this.groupSaldoMonetaContable.TabStop = false;
            this.groupSaldoMonetaContable.Text = "Saldos en moneda contable";
            // 
            // textSaldoFinalContable
            // 
            this.textSaldoFinalContable.Location = new System.Drawing.Point(67, 51);
            this.textSaldoFinalContable.Name = "textSaldoFinalContable";
            this.textSaldoFinalContable.Size = new System.Drawing.Size(76, 20);
            this.textSaldoFinalContable.TabIndex = 10;
            // 
            // textSaldoInicialContable
            // 
            this.textSaldoInicialContable.Location = new System.Drawing.Point(67, 25);
            this.textSaldoInicialContable.Name = "textSaldoInicialContable";
            this.textSaldoInicialContable.Size = new System.Drawing.Size(76, 20);
            this.textSaldoInicialContable.TabIndex = 8;
            // 
            // labelSaldoFinalContable
            // 
            this.labelSaldoFinalContable.AutoSize = true;
            this.labelSaldoFinalContable.Location = new System.Drawing.Point(32, 54);
            this.labelSaldoFinalContable.Name = "labelSaldoFinalContable";
            this.labelSaldoFinalContable.Size = new System.Drawing.Size(29, 13);
            this.labelSaldoFinalContable.TabIndex = 9;
            this.labelSaldoFinalContable.Text = "Final";
            // 
            // labelSaldoInicialContable
            // 
            this.labelSaldoInicialContable.AutoSize = true;
            this.labelSaldoInicialContable.Location = new System.Drawing.Point(32, 28);
            this.labelSaldoInicialContable.Name = "labelSaldoInicialContable";
            this.labelSaldoInicialContable.Size = new System.Drawing.Size(34, 13);
            this.labelSaldoInicialContable.TabIndex = 7;
            this.labelSaldoInicialContable.Text = "Inicial";
            // 
            // labelTipoMoneda
            // 
            this.labelTipoMoneda.AutoSize = true;
            this.labelTipoMoneda.Location = new System.Drawing.Point(200, 16);
            this.labelTipoMoneda.Name = "labelTipoMoneda";
            this.labelTipoMoneda.Size = new System.Drawing.Size(84, 13);
            this.labelTipoMoneda.TabIndex = 3;
            this.labelTipoMoneda.Text = "Tipo de moneda";
            // 
            // checkAfectaPolizaAjuste
            // 
            this.checkAfectaPolizaAjuste.AutoSize = true;
            this.checkAfectaPolizaAjuste.Location = new System.Drawing.Point(8, 37);
            this.checkAfectaPolizaAjuste.Name = "checkAfectaPolizaAjuste";
            this.checkAfectaPolizaAjuste.Size = new System.Drawing.Size(181, 17);
            this.checkAfectaPolizaAjuste.TabIndex = 3;
            this.checkAfectaPolizaAjuste.Text = "Afecta póliza de ajuste cambiario";
            this.checkAfectaPolizaAjuste.UseVisualStyleBackColor = true;
            // 
            // TipoMoneda
            // 
            this.TipoMoneda.FormattingEnabled = true;
            this.TipoMoneda.Location = new System.Drawing.Point(203, 35);
            this.TipoMoneda.Name = "TipoMoneda";
            this.TipoMoneda.Size = new System.Drawing.Size(169, 21);
            this.TipoMoneda.TabIndex = 4;
            // 
            // EsDepartamental
            // 
            this.EsDepartamental.AutoSize = true;
            this.EsDepartamental.Location = new System.Drawing.Point(8, 14);
            this.EsDepartamental.Name = "EsDepartamental";
            this.EsDepartamental.Size = new System.Drawing.Size(108, 17);
            this.EsDepartamental.TabIndex = 3;
            this.EsDepartamental.Text = "Es departamental";
            this.EsDepartamental.UseVisualStyleBackColor = true;
            // 
            // tabPageAtributos
            // 
            this.tabPageAtributos.Controls.Add(this.button1);
            this.tabPageAtributos.Controls.Add(this.buttonDesasocuarCeunta);
            this.tabPageAtributos.Controls.Add(this.groupNaturaleza);
            this.tabPageAtributos.Controls.Add(this.buttonAsociarCuenta);
            this.tabPageAtributos.Controls.Add(this.labelPerteneceRubros);
            this.tabPageAtributos.Controls.Add(this.textContraPartida);
            this.tabPageAtributos.Controls.Add(this.listRubros);
            this.tabPageAtributos.Controls.Add(this.labelContraPartida);
            this.tabPageAtributos.Location = new System.Drawing.Point(4, 22);
            this.tabPageAtributos.Name = "tabPageAtributos";
            this.tabPageAtributos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAtributos.Size = new System.Drawing.Size(384, 194);
            this.tabPageAtributos.TabIndex = 1;
            this.tabPageAtributos.Text = "Atributos";
            this.tabPageAtributos.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 20);
            this.button1.TabIndex = 11;
            this.button1.Text = "B";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonDesasocuarCeunta
            // 
            this.buttonDesasocuarCeunta.Location = new System.Drawing.Point(275, 62);
            this.buttonDesasocuarCeunta.Name = "buttonDesasocuarCeunta";
            this.buttonDesasocuarCeunta.Size = new System.Drawing.Size(103, 23);
            this.buttonDesasocuarCeunta.TabIndex = 8;
            this.buttonDesasocuarCeunta.Text = "Desasociar cuenta";
            this.buttonDesasocuarCeunta.UseVisualStyleBackColor = true;
            // 
            // groupNaturaleza
            // 
            this.groupNaturaleza.Controls.Add(this.radioNaturalezaAcreedora);
            this.groupNaturaleza.Controls.Add(this.radioNaturalezaDeudora);
            this.groupNaturaleza.Location = new System.Drawing.Point(9, 12);
            this.groupNaturaleza.Name = "groupNaturaleza";
            this.groupNaturaleza.Size = new System.Drawing.Size(122, 91);
            this.groupNaturaleza.TabIndex = 3;
            this.groupNaturaleza.TabStop = false;
            this.groupNaturaleza.Text = "Naturaleza";
            // 
            // radioNaturalezaAcreedora
            // 
            this.radioNaturalezaAcreedora.AutoSize = true;
            this.radioNaturalezaAcreedora.Location = new System.Drawing.Point(16, 50);
            this.radioNaturalezaAcreedora.Name = "radioNaturalezaAcreedora";
            this.radioNaturalezaAcreedora.Size = new System.Drawing.Size(74, 17);
            this.radioNaturalezaAcreedora.TabIndex = 4;
            this.radioNaturalezaAcreedora.TabStop = true;
            this.radioNaturalezaAcreedora.Text = "Acreedora";
            this.radioNaturalezaAcreedora.UseVisualStyleBackColor = true;
            // 
            // radioNaturalezaDeudora
            // 
            this.radioNaturalezaDeudora.AutoSize = true;
            this.radioNaturalezaDeudora.Location = new System.Drawing.Point(16, 27);
            this.radioNaturalezaDeudora.Name = "radioNaturalezaDeudora";
            this.radioNaturalezaDeudora.Size = new System.Drawing.Size(66, 17);
            this.radioNaturalezaDeudora.TabIndex = 5;
            this.radioNaturalezaDeudora.TabStop = true;
            this.radioNaturalezaDeudora.Text = "Deudora";
            this.radioNaturalezaDeudora.UseVisualStyleBackColor = true;
            // 
            // buttonAsociarCuenta
            // 
            this.buttonAsociarCuenta.Location = new System.Drawing.Point(275, 34);
            this.buttonAsociarCuenta.Name = "buttonAsociarCuenta";
            this.buttonAsociarCuenta.Size = new System.Drawing.Size(103, 23);
            this.buttonAsociarCuenta.TabIndex = 8;
            this.buttonAsociarCuenta.Text = "Asociar cuenta";
            this.buttonAsociarCuenta.UseVisualStyleBackColor = true;
            // 
            // labelPerteneceRubros
            // 
            this.labelPerteneceRubros.AutoSize = true;
            this.labelPerteneceRubros.Location = new System.Drawing.Point(137, 12);
            this.labelPerteneceRubros.Name = "labelPerteneceRubros";
            this.labelPerteneceRubros.Size = new System.Drawing.Size(113, 13);
            this.labelPerteneceRubros.TabIndex = 4;
            this.labelPerteneceRubros.Text = "Pertenece a los rubros";
            // 
            // textContraPartida
            // 
            this.textContraPartida.Location = new System.Drawing.Point(93, 109);
            this.textContraPartida.Name = "textContraPartida";
            this.textContraPartida.Size = new System.Drawing.Size(133, 20);
            this.textContraPartida.TabIndex = 7;
            this.textContraPartida.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // labelContraPartida
            // 
            this.labelContraPartida.AutoSize = true;
            this.labelContraPartida.Location = new System.Drawing.Point(12, 112);
            this.labelContraPartida.Name = "labelContraPartida";
            this.labelContraPartida.Size = new System.Drawing.Size(70, 13);
            this.labelContraPartida.TabIndex = 6;
            this.labelContraPartida.Text = "Contrapartida";
            // 
            // Fiscales
            // 
            this.Fiscales.Controls.Add(this.labelAplicarTerceros);
            this.Fiscales.Controls.Add(this.labelFiscalNombre);
            this.Fiscales.Controls.Add(this.labelAplicarFormaPago);
            this.Fiscales.Controls.Add(this.textRazonSocial);
            this.Fiscales.Controls.Add(this.comboBox5);
            this.Fiscales.Controls.Add(this.labelIDFiscal);
            this.Fiscales.Controls.Add(this.comboAplicarFormaPago);
            this.Fiscales.Controls.Add(this.textIdFiscal);
            this.Fiscales.Controls.Add(this.checkOperacionConTerceros);
            this.Fiscales.Controls.Add(this.labelRFC);
            this.Fiscales.Controls.Add(this.checkCapturaComprobantes);
            this.Fiscales.Controls.Add(this.textRFC);
            this.Fiscales.Controls.Add(this.checkCapturaFormaPago);
            this.Fiscales.Controls.Add(this.buttonBuscarDirectorio);
            this.Fiscales.Controls.Add(this.labelCodigoAgrupador);
            this.Fiscales.Controls.Add(this.buttonSAT);
            this.Fiscales.Controls.Add(this.comboCodigoAgrupador);
            this.Fiscales.Location = new System.Drawing.Point(4, 22);
            this.Fiscales.Name = "Fiscales";
            this.Fiscales.Size = new System.Drawing.Size(384, 194);
            this.Fiscales.TabIndex = 2;
            this.Fiscales.Text = "Fiscales";
            this.Fiscales.UseVisualStyleBackColor = true;
            // 
            // labelAplicarTerceros
            // 
            this.labelAplicarTerceros.AutoSize = true;
            this.labelAplicarTerceros.Location = new System.Drawing.Point(183, 163);
            this.labelAplicarTerceros.Name = "labelAplicarTerceros";
            this.labelAplicarTerceros.Size = new System.Drawing.Size(48, 13);
            this.labelAplicarTerceros.TabIndex = 14;
            this.labelAplicarTerceros.Text = "Aplicar a";
            // 
            // labelFiscalNombre
            // 
            this.labelFiscalNombre.AutoSize = true;
            this.labelFiscalNombre.Location = new System.Drawing.Point(18, 11);
            this.labelFiscalNombre.Name = "labelFiscalNombre";
            this.labelFiscalNombre.Size = new System.Drawing.Size(47, 13);
            this.labelFiscalNombre.TabIndex = 6;
            this.labelFiscalNombre.Text = "Nombre:";
            // 
            // labelAplicarFormaPago
            // 
            this.labelAplicarFormaPago.AutoSize = true;
            this.labelAplicarFormaPago.Location = new System.Drawing.Point(183, 116);
            this.labelAplicarFormaPago.Name = "labelAplicarFormaPago";
            this.labelAplicarFormaPago.Size = new System.Drawing.Size(48, 13);
            this.labelAplicarFormaPago.TabIndex = 14;
            this.labelAplicarFormaPago.Text = "Aplicar a";
            // 
            // textRazonSocial
            // 
            this.textRazonSocial.Location = new System.Drawing.Point(99, 8);
            this.textRazonSocial.Name = "textRazonSocial";
            this.textRazonSocial.Size = new System.Drawing.Size(249, 20);
            this.textRazonSocial.TabIndex = 7;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(237, 159);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(111, 21);
            this.comboBox5.TabIndex = 15;
            // 
            // labelIDFiscal
            // 
            this.labelIDFiscal.AutoSize = true;
            this.labelIDFiscal.Location = new System.Drawing.Point(18, 37);
            this.labelIDFiscal.Name = "labelIDFiscal";
            this.labelIDFiscal.Size = new System.Drawing.Size(46, 13);
            this.labelIDFiscal.TabIndex = 6;
            this.labelIDFiscal.Text = "Id fiscal:";
            // 
            // comboAplicarFormaPago
            // 
            this.comboAplicarFormaPago.FormattingEnabled = true;
            this.comboAplicarFormaPago.Location = new System.Drawing.Point(237, 112);
            this.comboAplicarFormaPago.Name = "comboAplicarFormaPago";
            this.comboAplicarFormaPago.Size = new System.Drawing.Size(111, 21);
            this.comboAplicarFormaPago.TabIndex = 15;
            // 
            // textIdFiscal
            // 
            this.textIdFiscal.Location = new System.Drawing.Point(99, 34);
            this.textIdFiscal.Name = "textIdFiscal";
            this.textIdFiscal.Size = new System.Drawing.Size(249, 20);
            this.textIdFiscal.TabIndex = 7;
            // 
            // checkOperacionConTerceros
            // 
            this.checkOperacionConTerceros.AutoSize = true;
            this.checkOperacionConTerceros.Location = new System.Drawing.Point(21, 161);
            this.checkOperacionConTerceros.Name = "checkOperacionConTerceros";
            this.checkOperacionConTerceros.Size = new System.Drawing.Size(148, 17);
            this.checkOperacionConTerceros.TabIndex = 13;
            this.checkOperacionConTerceros.Text = "Operaciones con terceros";
            this.checkOperacionConTerceros.UseVisualStyleBackColor = true;
            // 
            // labelRFC
            // 
            this.labelRFC.AutoSize = true;
            this.labelRFC.Location = new System.Drawing.Point(18, 64);
            this.labelRFC.Name = "labelRFC";
            this.labelRFC.Size = new System.Drawing.Size(31, 13);
            this.labelRFC.TabIndex = 8;
            this.labelRFC.Text = "RFC:";
            // 
            // checkCapturaComprobantes
            // 
            this.checkCapturaComprobantes.AutoSize = true;
            this.checkCapturaComprobantes.Location = new System.Drawing.Point(21, 137);
            this.checkCapturaComprobantes.Name = "checkCapturaComprobantes";
            this.checkCapturaComprobantes.Size = new System.Drawing.Size(148, 17);
            this.checkCapturaComprobantes.TabIndex = 13;
            this.checkCapturaComprobantes.Text = "Captura de comprobantes";
            this.checkCapturaComprobantes.UseVisualStyleBackColor = true;
            // 
            // textRFC
            // 
            this.textRFC.Location = new System.Drawing.Point(99, 60);
            this.textRFC.Name = "textRFC";
            this.textRFC.Size = new System.Drawing.Size(160, 20);
            this.textRFC.TabIndex = 9;
            // 
            // checkCapturaFormaPago
            // 
            this.checkCapturaFormaPago.AutoSize = true;
            this.checkCapturaFormaPago.Location = new System.Drawing.Point(21, 114);
            this.checkCapturaFormaPago.Name = "checkCapturaFormaPago";
            this.checkCapturaFormaPago.Size = new System.Drawing.Size(149, 17);
            this.checkCapturaFormaPago.TabIndex = 13;
            this.checkCapturaFormaPago.Text = "Captura de forma de pago";
            this.checkCapturaFormaPago.UseVisualStyleBackColor = true;
            // 
            // buttonBuscarDirectorio
            // 
            this.buttonBuscarDirectorio.Location = new System.Drawing.Point(265, 59);
            this.buttonBuscarDirectorio.Name = "buttonBuscarDirectorio";
            this.buttonBuscarDirectorio.Size = new System.Drawing.Size(41, 20);
            this.buttonBuscarDirectorio.TabIndex = 10;
            this.buttonBuscarDirectorio.Text = "B";
            this.buttonBuscarDirectorio.UseVisualStyleBackColor = true;
            // 
            // labelCodigoAgrupador
            // 
            this.labelCodigoAgrupador.AutoSize = true;
            this.labelCodigoAgrupador.Location = new System.Drawing.Point(18, 89);
            this.labelCodigoAgrupador.Name = "labelCodigoAgrupador";
            this.labelCodigoAgrupador.Size = new System.Drawing.Size(91, 13);
            this.labelCodigoAgrupador.TabIndex = 11;
            this.labelCodigoAgrupador.Text = "Código agrupador";
            // 
            // buttonSAT
            // 
            this.buttonSAT.Location = new System.Drawing.Point(306, 59);
            this.buttonSAT.Name = "buttonSAT";
            this.buttonSAT.Size = new System.Drawing.Size(42, 20);
            this.buttonSAT.TabIndex = 10;
            this.buttonSAT.Text = "SAT";
            this.buttonSAT.UseVisualStyleBackColor = true;
            // 
            // comboCodigoAgrupador
            // 
            this.comboCodigoAgrupador.FormattingEnabled = true;
            this.comboCodigoAgrupador.Location = new System.Drawing.Point(115, 86);
            this.comboCodigoAgrupador.Name = "comboCodigoAgrupador";
            this.comboCodigoAgrupador.Size = new System.Drawing.Size(233, 21);
            this.comboCodigoAgrupador.TabIndex = 12;
            // 
            // Aceptar
            // 
            this.Aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Aceptar.Location = new System.Drawing.Point(86, 331);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 3;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            // 
            // Cancelar
            // 
            this.Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancelar.Location = new System.Drawing.Point(167, 331);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 3;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // Guardar
            // 
            this.Guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Guardar.Location = new System.Drawing.Point(248, 331);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(75, 23);
            this.Guardar.TabIndex = 3;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // Ayuda
            // 
            this.Ayuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ayuda.Location = new System.Drawing.Point(329, 331);
            this.Ayuda.Name = "Ayuda";
            this.Ayuda.Size = new System.Drawing.Size(75, 23);
            this.Ayuda.TabIndex = 3;
            this.Ayuda.Text = "Ayuda";
            this.Ayuda.UseVisualStyleBackColor = true;
            this.Ayuda.Click += new System.EventHandler(this.Ayuda_Click);
            // 
            // CuentaContableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancelar;
            this.ClientSize = new System.Drawing.Size(416, 366);
            this.Controls.Add(this.Ayuda);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.tabPageFiscales);
            this.Controls.Add(this.groupTipo);
            this.Controls.Add(this.groupCuenta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CuentaContableForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar cuentas";
            this.Load += new System.EventHandler(this.CuentaContableForm_Load);
            this.groupCuenta.ResumeLayout(false);
            this.groupCuenta.PerformLayout();
            this.groupTipo.ResumeLayout(false);
            this.groupTipo.PerformLayout();
            this.tabPageFiscales.ResumeLayout(false);
            this.tabPageGenerales.ResumeLayout(false);
            this.tabPageGenerales.PerformLayout();
            this.groupSaldoMonedaExtranjera.ResumeLayout(false);
            this.groupSaldoMonedaExtranjera.PerformLayout();
            this.groupSaldoMonetaContable.ResumeLayout(false);
            this.groupSaldoMonetaContable.PerformLayout();
            this.tabPageAtributos.ResumeLayout(false);
            this.tabPageAtributos.PerformLayout();
            this.groupNaturaleza.ResumeLayout(false);
            this.groupNaturaleza.PerformLayout();
            this.Fiscales.ResumeLayout(false);
            this.Fiscales.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupCuenta;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label labelNoCuenta;
        private System.Windows.Forms.MaskedTextBox txtNoCuenta;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.GroupBox groupTipo;
        private System.Windows.Forms.RadioButton Detalle;
        private System.Windows.Forms.RadioButton Acumulativa;
        private System.Windows.Forms.TabControl tabPageFiscales;
        private System.Windows.Forms.TabPage tabPageGenerales;
        private System.Windows.Forms.TabPage tabPageAtributos;
        private System.Windows.Forms.TabPage Fiscales;
        private System.Windows.Forms.CheckBox EsDepartamental;
        private System.Windows.Forms.CheckBox checkAfectaPolizaAjuste;
        private System.Windows.Forms.Label labelTipoMoneda;
        private System.Windows.Forms.ComboBox TipoMoneda;
        private System.Windows.Forms.GroupBox groupSaldoMonetaContable;
        private System.Windows.Forms.TextBox textSaldoFinalContable;
        private System.Windows.Forms.TextBox textSaldoInicialContable;
        private System.Windows.Forms.Label labelSaldoFinalContable;
        private System.Windows.Forms.Label labelSaldoInicialContable;
        private System.Windows.Forms.GroupBox groupSaldoMonedaExtranjera;
        private System.Windows.Forms.TextBox textSaldoFinalExtranjera;
        private System.Windows.Forms.TextBox textSaldoInicialExtranjera;
        private System.Windows.Forms.Label labelSaldoInicialExtranjera;
        private System.Windows.Forms.Label labelSaldoFinalExtranjera;
        private System.Windows.Forms.GroupBox groupNaturaleza;
        private System.Windows.Forms.RadioButton radioNaturalezaAcreedora;
        private System.Windows.Forms.RadioButton radioNaturalezaDeudora;
        private System.Windows.Forms.Label labelPerteneceRubros;
        private System.Windows.Forms.ListBox listRubros;
        private System.Windows.Forms.MaskedTextBox textContraPartida;
        private System.Windows.Forms.Label labelContraPartida;
        private System.Windows.Forms.Button buttonAsociarCuenta;
        private System.Windows.Forms.Button buttonDesasocuarCeunta;
        private System.Windows.Forms.TextBox textRazonSocial;
        private System.Windows.Forms.Label labelFiscalNombre;
        private System.Windows.Forms.Label labelIDFiscal;
        private System.Windows.Forms.TextBox textIdFiscal;
        private System.Windows.Forms.TextBox textRFC;
        private System.Windows.Forms.Label labelRFC;
        private System.Windows.Forms.Button buttonBuscarDirectorio;
        private System.Windows.Forms.Button buttonSAT;
        private System.Windows.Forms.Label labelCodigoAgrupador;
        private System.Windows.Forms.ComboBox comboCodigoAgrupador;
        private System.Windows.Forms.CheckBox checkCapturaFormaPago;
        private System.Windows.Forms.CheckBox checkCapturaComprobantes;
        private System.Windows.Forms.CheckBox checkOperacionConTerceros;
        private System.Windows.Forms.Label labelAplicarFormaPago;
        private System.Windows.Forms.ComboBox comboAplicarFormaPago;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label labelAplicarTerceros;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Button Ayuda;
        private System.Windows.Forms.MaskedTextBox maskedCuentaPadre;
        private System.Windows.Forms.Button button1;
    }
}