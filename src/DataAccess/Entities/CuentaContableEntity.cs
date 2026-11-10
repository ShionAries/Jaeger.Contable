using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    [SugarTable("cuentas25")]
    public class CuentaContableEntity {
        /// <summary>
        /// numero de cuenta contable
        /// </summary>
        [SugarColumn(ColumnName = "NUM_CTA", IsPrimaryKey = true, Length = 21)]
        public string NumCta { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [SugarColumn(ColumnName = "STATUS", IsNullable = true, Length = 1)]
        public string Status { get; set; }

        /// <summary>
        /// Tipo
        /// </summary>
        [SugarColumn(ColumnName = "TIPO", IsNullable = true, Length = 1)]
        public string Tipo { get; set; }

        /// <summary>
        /// obtener o establecer nombre o descripcion de la cuenta
        /// </summary>
        [SugarColumn(ColumnName = "NOMBRE", IsNullable = true, Length = 40)]
        public string Nombre { get; set; }

        /// <summary>
        /// es de departamento o no
        /// </summary>
        [SugarColumn(ColumnName = "DEPTSINO", IsNullable = true, Length = 1)]
        public string DeptoSiNo { get; set; }

        /// <summary>
        /// obteneri establecer bandera para indicar si maneja multimoneda
        /// </summary>
        [SugarColumn(ColumnName = "BANDMULTI", IsNullable = true)]
        public short? BandMulti { get; set; }

        /// <summary>
        /// Indica si afecta poliza de ajuste cambiario
        /// </summary>
        [SugarColumn(ColumnName = "BANDAJT", IsNullable = true, Length = 1)]
        public string BandAjt { get; set; }

        /// <summary>
        /// cuenta papa
        /// </summary>
        [SugarColumn(ColumnName = "CTA_PAPA", IsNullable = true, Length = 21)]
        public string CtaPapa { get; set; }

        /// <summary>
        /// cuenta raiz
        /// </summary>
        [SugarColumn(ColumnName = "CTA_RAIZ", IsNullable = true, Length = 21)]
        public string CtaRaiz { get; set; }

        /// <summary>
        /// nivel
        /// </summary>
        [SugarColumn(ColumnName = "NIVEL", IsNullable = true)]
        public short? Nivel { get; set; }

        /// <summary>
        /// cuenta contrapartida
        /// </summary>
        [SugarColumn(ColumnName = "CTA_COMP", IsNullable = true, Length = 21)]
        public string CtaComp { get; set; }

        /// <summary>
        /// naturaleza de la cuenta
        /// </summary>
        [SugarColumn(ColumnName = "NATURALEZA", IsNullable = true)]
        public short? Naturaleza { get; set; }

        /// <summary>
        /// RFC
        /// </summary>
        [SugarColumn(ColumnName = "RFC", IsNullable = true, Length = 30)]
        public string Rfc { get; set; }

        /// <summary>
        /// codigo de agrupacion
        /// </summary>
        [SugarColumn(ColumnName = "CODAGRUP", IsNullable = true, Length = 10)]
        public string CodAgrup { get; set; }

        /// <summary>
        /// indica si se captura formas de pag
        /// </summary>
        [SugarColumn(ColumnName = "CAPTURACHEQUE", IsNullable = true)]
        public short? CapturaCheque { get; set; }

        /// <summary>
        /// Indica si se captura comprobantes
        /// </summary>
        [SugarColumn(ColumnName = "CAPTURAUUID", IsNullable = true)]
        public short? CapturaUuid { get; set; }

        /// <summary>
        /// banco capturado en la forma de pago
        /// </summary>
        [SugarColumn(ColumnName = "BANCO", IsNullable = true)]
        public int? Banco { get; set; }

        /// <summary>
        /// Cuenta bancaria capturada en la forma de pago
        /// </summary>
        [SugarColumn(ColumnName = "CTABANCARIA", IsNullable = true, Length = 50)]
        public string CtaBancaria { get; set; }

        /// <summary>
        /// tipo de movimiento
        /// </summary>
        [SugarColumn(ColumnName = "CAPCHEQTIPOMOV", IsNullable = true, Length = 1)]
        public string CapCheqTipoMov { get; set; }

        /// <summary>
        /// indica que no se incluira al general el xml de contabilidad
        /// </summary>
        [SugarColumn(ColumnName = "NOINCLUIRXML", IsNullable = true)]
        public int? NoIncluirXml { get; set; }

        /// <summary>
        /// identificador Fiscal
        /// </summary>
        [SugarColumn(ColumnName = "IDFISCAL", IsNullable = true, Length = 40)]
        public string IdFiscal { get; set; }

        /// <summary>
        /// indica si es flujo de efectivo
        /// </summary>
        [SugarColumn(ColumnName = "ESFLUJODEEFECTIVO", IsNullable = true)]
        public short? EsFlujoDeEfectivo { get; set; }

        /// <summary>
        /// banco extranjero
        /// </summary>
        [SugarColumn(ColumnName = "BANCOEXTRANJERO", IsNullable = true, Length = 225)]
        public string BancoExtranjero { get; set; }

        /// <summary>
        /// RFCEmisor Cuenta ordenante o RFCEmisor cuenta beneficiario
        /// </summary>
        [SugarColumn(ColumnName = "RFCFLUJO", IsNullable = true, Length = 15)]
        public string RfcFlujo { get; set; }
    }
}
