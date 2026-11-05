using SqlSugar;
namespace Jaeger.Contable.DataAccess.Entities {
    [SugarTable("paramemp")]
    public class ParamempEntity {
        #region Identificación y domicilio
        [SugarColumn(ColumnName = "IDEMP", IsPrimaryKey = true)] public int IdEmp { get; set; }
        [SugarColumn(ColumnName = "DIREC", IsNullable = true, Length = 30)] public string Direc { get; set; }
        [SugarColumn(ColumnName = "POBL", IsNullable = true, Length = 30)] public string Pobl { get; set; }
        [SugarColumn(ColumnName = "COD_POS", IsNullable = true, Length = 5)] public string CodPos { get; set; }
        [SugarColumn(ColumnName = "RFC_EMP", IsNullable = true, Length = 30)] public string RfcEmp { get; set; }
        [SugarColumn(ColumnName = "CED_EMP", IsNullable = true, Length = 30)] public string CedEmp { get; set; }
        #endregion

        #region Estructura del catálogo de cuentas
        [SugarColumn(ColumnName = "DIGCTA1", IsNullable = true)] public int? DigCta1 { get; set; }
        [SugarColumn(ColumnName = "DIGCTA2", IsNullable = true)] public int? DigCta2 { get; set; }
        [SugarColumn(ColumnName = "DIGCTA3", IsNullable = true)] public int? DigCta3 { get; set; }
        [SugarColumn(ColumnName = "DIGCTA4", IsNullable = true)] public int? DigCta4 { get; set; }
        [SugarColumn(ColumnName = "DIGCTA5", IsNullable = true)] public int? DigCta5 { get; set; }
        [SugarColumn(ColumnName = "DIGCTA6", IsNullable = true)] public int? DigCta6 { get; set; }
        [SugarColumn(ColumnName = "DIGCTA7", IsNullable = true)] public int? DigCta7 { get; set; }
        [SugarColumn(ColumnName = "DIGCTA8", IsNullable = true)] public int? DigCta8 { get; set; }
        [SugarColumn(ColumnName = "DIGCTA9", IsNullable = true)] public int? DigCta9 { get; set; }
        [SugarColumn(ColumnName = "NIVELACTU", IsNullable = true)] public short? NivelActu { get; set; }
        [SugarColumn(ColumnName = "GUION_SINO", IsNullable = true, Length = 1)] public string GuionSiNo { get; set; }
        #endregion

        #region Configuración contable
        [SugarColumn(ColumnName = "REDO_P", IsNullable = true, Length = 1)] public string RedoP { get; set; }
        [SugarColumn(ColumnName = "CAPSALINI", IsNullable = true, Length = 1)] public string CapSalIni { get; set; }
        [SugarColumn(ColumnName = "ASIGSECPOL", IsNullable = true, Length = 1)] public string AsigSecPol { get; set; }
        [SugarColumn(ColumnName = "CONTABLINEA", IsNullable = true, Length = 1)] public string ContabLinea { get; set; }
        [SugarColumn(ColumnName = "MESCIERRE", IsNullable = true)] public short? MesCierre { get; set; }
        [SugarColumn(ColumnName = "SUBDIR", IsNullable = true, Length = 255)] public string SubDir { get; set; }
        [SugarColumn(ColumnName = "CAPCTASPOL", IsNullable = true, Length = 1)] public string CapCtasPol { get; set; }
        [SugarColumn(ColumnName = "DEPTO_SINO", IsNullable = true, Length = 1)] public string DeptoSiNo { get; set; }
        [SugarColumn(ColumnName = "TRASPASO", IsNullable = true, Length = 1)] public string Traspaso { get; set; }
        #endregion

        #region Moneda y bancos
        [SugarColumn(ColumnName = "CTMONEXT", IsNullable = true, Length = 1)] public string CtMonExt { get; set; }
        [SugarColumn(ColumnName = "CSTIPOCMB", IsNullable = true, Length = 1)] public string CsTipoCmb { get; set; }
        [SugarColumn(ColumnName = "CPTIPOCMB", IsNullable = true, Length = 1)] public string CpTipoCmb { get; set; }
        [SugarColumn(ColumnName = "CQUEMONEXT", IsNullable = true, Length = 1)] public string CqueMonExt { get; set; }
        [SugarColumn(ColumnName = "CQUEMONCTB", IsNullable = true, Length = 1)] public string CqueMonCtb { get; set; }
        [SugarColumn(ColumnName = "CTAIVA", IsNullable = true, Length = 40)] public string CtaIva { get; set; }
        [SugarColumn(ColumnName = "CTABANCO", IsNullable = true, Length = 50)] public string CtaBanco { get; set; }
        [SugarColumn(ColumnName = "CONMONTPOL", IsNullable = true)] public short? ConMontPol { get; set; }
        [SugarColumn(ColumnName = "DRIVERCOI", IsNullable = true)] public short? DriverCoi { get; set; }
        #endregion

        #region Operación y control
        [SugarColumn(ColumnName = "ALIAS", IsNullable = true, Length = 255)] public string Alias { get; set; }
        [SugarColumn(ColumnName = "FOLIOUNICO", IsNullable = true)] public int? FolioUnico { get; set; }
        [SugarColumn(ColumnName = "CAPTURADOS", IsNullable = true, Length = 1)] public string Capturados { get; set; }
        [SugarColumn(ColumnName = "POLDESCUAD", IsNullable = true, Length = 1)] public string PolDescuad { get; set; }
        [SugarColumn(ColumnName = "DIRTRAB", IsNullable = true, Length = 255)] public string DirTrab { get; set; }
        [SugarColumn(ColumnName = "IVADEF", IsNullable = true, Length = 2)] public string IvaDef { get; set; }
        [SugarColumn(ColumnName = "IVAENOPT", IsNullable = true)] public short? IvaEnOpt { get; set; }
        [SugarColumn(ColumnName = "IVAENINGR", IsNullable = true)] public short? IvaEnIngr { get; set; }
        [SugarColumn(ColumnName = "BUFFCUECUA", IsNullable = true, Length = 21)] public string BuffCueCua { get; set; }
        #endregion

        #region Datos fiscales y empresa
        [SugarColumn(ColumnName = "TIPOPERSONA", IsNullable = true, Length = 10)] public string TipoPersona { get; set; }
        [SugarColumn(ColumnName = "NACIONALIDAD", IsNullable = true, Length = 12)] public string Nacionalidad { get; set; }
        [SugarColumn(ColumnName = "TIPOEMPRESA", IsNullable = true, Length = 25)] public string TipoEmpresa { get; set; }
        [SugarColumn(ColumnName = "FCONSTITUCION", IsNullable = true, Length = 10)] public string FConstitucion { get; set; }
        [SugarColumn(ColumnName = "REGIMEN", IsNullable = true, Length = 25)] public string Regimen { get; set; }
        [SugarColumn(ColumnName = "NOMBREREPRE", IsNullable = true, Length = 60)] public string NombreRepre { get; set; }
        [SugarColumn(ColumnName = "RFCREPRE", IsNullable = true, Length = 13)] public string RfcRepre { get; set; }
        [SugarColumn(ColumnName = "CURPREPRE", IsNullable = true, Length = 18)] public string CurPrepre { get; set; }
        [SugarColumn(ColumnName = "PODERNOT", IsNullable = true, Length = 30)] public string PoderNot { get; set; }
        [SugarColumn(ColumnName = "TRASPASOSALDOS", IsNullable = true)] public short? TraspasoSaldos { get; set; }
        #endregion

        #region Costos, grupos e impuestos
        [SugarColumn(ColumnName = "NOMBRE", IsNullable = true, Length = 60)] public string Nombre { get; set; }
        [SugarColumn(ColumnName = "CCOSTOS", IsNullable = true)] public int? CCostos { get; set; }
        [SugarColumn(ColumnName = "CGRUPOS", IsNullable = true)] public int? CGrupos { get; set; }
        [SugarColumn(ColumnName = "ETQCCOSTOS", IsNullable = true, Length = 40)] public string EtqCCostos { get; set; }
        [SugarColumn(ColumnName = "ETQCGRUPOS", IsNullable = true, Length = 40)] public string EtqCGrupos { get; set; }
        [SugarColumn(ColumnName = "IVADEFIETU", IsNullable = true, Length = 2)] public string IvaDefIetu { get; set; }
        [SugarColumn(ColumnName = "TIPODECAPTURADIOT", IsNullable = true)] public short? TipoDeCapturaDiot { get; set; }
        [SugarColumn(ColumnName = "TIPODECAPTURAIETU", IsNullable = true)] public short? TipoDeCapturaIetu { get; set; }
        [SugarColumn(ColumnName = "CUENTAIVAACREDITABLE", IsNullable = true, Length = 31)] public string CuentaIvaAcreditable { get; set; }
        [SugarColumn(ColumnName = "CUENTAIVATRASLADADO", IsNullable = true, Length = 31)] public string CuentaIvaTrasladado { get; set; }
        #endregion

        #region Pólizas y cuentas fiscales relacionadas
        [SugarColumn(ColumnName = "TIPOPOLIZA", IsNullable = true, Length = 2)] public string TipoPoliza { get; set; }
        [SugarColumn(ColumnName = "TIPOPOLIZATER", IsNullable = true, Length = 2)] public string TipoPolizaTer { get; set; }
        [SugarColumn(ColumnName = "GIRO", IsNullable = true, Length = 6)] public string Giro { get; set; }
        [SugarColumn(ColumnName = "DEV_COMPRAS", IsNullable = true, Length = 21)] public string DevCompras { get; set; }
        [SugarColumn(ColumnName = "DEV_VENTAS", IsNullable = true, Length = 21)] public string DevVentas { get; set; }
        [SugarColumn(ColumnName = "GASTO_ACTIVO", IsNullable = true, Length = 21)] public string GastoActivo { get; set; }
        [SugarColumn(ColumnName = "IEPS_POR_ACREDITAR", IsNullable = true, Length = 21)] public string IepsPorAcreditar { get; set; }
        [SugarColumn(ColumnName = "IEPS_POR_TRASLADAR", IsNullable = true, Length = 21)] public string IepsPorTrasladar { get; set; }
        [SugarColumn(ColumnName = "IMP_LOCAL_RETENIDO", IsNullable = true, Length = 21)] public string ImpLocalRetenido { get; set; }
        [SugarColumn(ColumnName = "IMP_LOCAL_TRASLADADO", IsNullable = true, Length = 21)] public string ImpLocalTrasladado { get; set; }
        [SugarColumn(ColumnName = "ISR_RETENIDO", IsNullable = true, Length = 21)] public string IsrRetenido { get; set; }
        [SugarColumn(ColumnName = "IVA_ACREDITAR", IsNullable = true, Length = 21)] public string IvaAcreditar { get; set; }
        [SugarColumn(ColumnName = "IVA_POR_TRASLADAR", IsNullable = true, Length = 21)] public string IvaPorTrasladar { get; set; }
        [SugarColumn(ColumnName = "IVA_RETENIDO", IsNullable = true, Length = 21)] public string IvaRetenido { get; set; }
        [SugarColumn(ColumnName = "VENTAS", IsNullable = true, Length = 21)] public string Ventas { get; set; }
        #endregion

        #region Certificados y servicios externos
        [SugarColumn(ColumnName = "RCERTIFICADO", IsNullable = true, Length = 1024)] public string RCertificado { get; set; }
        [SugarColumn(ColumnName = "RLLAVEPRIVADA", IsNullable = true, Length = 1024)] public string RLlavePrivada { get; set; }
        [SugarColumn(ColumnName = "CONTRASENIALLAVEPRIVADA", IsNullable = true, Length = 256)] public string ContraseniaLlavePrivada { get; set; }
        [SugarColumn(ColumnName = "PROVEEDORTIMBRADO", IsNullable = true, Length = 256)] public string ProveedorTimbrado { get; set; }
        [SugarColumn(ColumnName = "USUARIOTIMBRADO", IsNullable = true, Length = 256)] public string UsuarioTimbrado { get; set; }
        [SugarColumn(ColumnName = "CONTRASENIATIMBRADO", IsNullable = true, Length = 256)] public string ContraseniaTimbrado { get; set; }
        [SugarColumn(ColumnName = "PROVEEDORCANCELACION", IsNullable = true, Length = 256)] public string ProveedorCancelacion { get; set; }
        [SugarColumn(ColumnName = "USUARIOCANCELACION", IsNullable = true, Length = 256)] public string UsuarioCancelacion { get; set; }
        [SugarColumn(ColumnName = "CONTRASENIACANCELACION", IsNullable = true, Length = 256)] public string ContraseniaCancelacion { get; set; }
        [SugarColumn(ColumnName = "ESPACIOASPEL", IsNullable = true, Length = 256)] public string EspacioAspel { get; set; }
        [SugarColumn(ColumnName = "USUARIOESPACIO", IsNullable = true, Length = 256)] public string UsuarioEspacio { get; set; }
        [SugarColumn(ColumnName = "CONTRASENIAESPACIO", IsNullable = true, Length = 256)] public string ContraseniaEspacio { get; set; }
        [SugarColumn(ColumnName = "IDCATEGORIAESPACIO", IsNullable = true)] public int? IdCategoriaEspacio { get; set; }
        [SugarColumn(ColumnName = "NOMBRECATEGORIAESPACIO", IsNullable = true, Length = 256)] public string NombreCategoriaEspacio { get; set; }
        [SugarColumn(ColumnName = "ASIGCATEGORIA", IsNullable = true)] public short? AsigCategoria { get; set; }
        #endregion

        #region Configuración adicional
        [SugarColumn(ColumnName = "GDIOTAPARTIRCFDI", IsNullable = true)] public short? GDiotAPartirCfdi { get; set; }
        [SugarColumn(ColumnName = "GUARDAROPEAUTO", IsNullable = true)] public short? GuardarOpeAuto { get; set; }
        [SugarColumn(ColumnName = "CFDIENTODASLASPARTIDAS", IsNullable = true)] public short? CfdiEnTodasLasPartidas { get; set; }
        [SugarColumn(ColumnName = "LOGO", ColumnDataType = "longblob", IsNullable = true)] public byte[] Logo { get; set; }
        #endregion

        #region Interfaz y certificados FIEL
        [SugarColumn(ColumnName = "FIELCERTIF", IsNullable = true, Length = 1024)]
        public string FielCertif { get; set; }
        [SugarColumn(ColumnName = "FIELPRIVKEY", IsNullable = true, Length = 1024)]
        public string FielPrivKey { get; set; }
        [SugarColumn(ColumnName = "CVEACCESOFIEL", IsNullable = true, Length = 1024)]
        public string CveAccesoFiel { get; set; }
        #endregion

        #region Configuracion de polizas de costos
        [SugarColumn(ColumnName = "GENERAPOLIZACOSTOS", IsNullable = true)]
        public short? GeneraPolizaCostos { get; set; }
        #endregion

        #region Interfaz externa
        [SugarColumn(ColumnName = "UUIDEMPRESA_INTERFAZ", IsNullable = true, Length = 36)]
        public string UuidEmpresaInterfaz { get; set; }
        [SugarColumn(ColumnName = "CONTABILIZAAUTO_INTERFAZ", IsNullable = true)]
        public int? ContabilizaAutoInterfaz { get; set; }
        [SugarColumn(ColumnName = "CORREO_INTERFAZ", IsNullable = true, Length = 100)]
        public string CorreoInterfaz { get; set; }
        [SugarColumn(ColumnName = "ACCES_INTERFAZ", IsNullable = true, Length = 15)]
        public string AccesInterfaz { get; set; }
        #endregion

    }
}