using SqlSugar;

namespace Jaeger.Contable.DataAccess.Entities {
    [SugarTable("SALDOS25")]
    public sealed class SaldosEntity {
        [SugarColumn(IsPrimaryKey = true)] public string NUM_CTA { get; set; }
        [SugarColumn(IsPrimaryKey = true)] public short EJERCICIO { get; set; }
        public double? INICIAL { get; set; }
        public double? INICIALEX { get; set; }
        public double? CARGO01 { get; set; } public double? ABONO01 { get; set; } public double? CARGOEX01 { get; set; } public double? ABONOEX01 { get; set; }
        public double? CARGO02 { get; set; } public double? ABONO02 { get; set; } public double? CARGOEX02 { get; set; } public double? ABONOEX02 { get; set; }
        public double? CARGO03 { get; set; } public double? ABONO03 { get; set; } public double? CARGOEX03 { get; set; } public double? ABONOEX03 { get; set; }
        public double? CARGO04 { get; set; } public double? ABONO04 { get; set; } public double? CARGOEX04 { get; set; } public double? ABONOEX04 { get; set; }
        public double? CARGO05 { get; set; } public double? ABONO05 { get; set; } public double? CARGOEX05 { get; set; } public double? ABONOEX05 { get; set; }
        public double? CARGO06 { get; set; } public double? ABONO06 { get; set; } public double? CARGOEX06 { get; set; } public double? ABONOEX06 { get; set; }
        public double? CARGO07 { get; set; } public double? ABONO07 { get; set; } public double? CARGOEX07 { get; set; } public double? ABONOEX07 { get; set; }
        public double? CARGO08 { get; set; } public double? ABONO08 { get; set; } public double? CARGOEX08 { get; set; } public double? ABONOEX08 { get; set; }
        public double? CARGO09 { get; set; } public double? ABONO09 { get; set; } public double? CARGOEX09 { get; set; } public double? ABONOEX09 { get; set; }
        public double? CARGO10 { get; set; } public double? ABONO10 { get; set; } public double? CARGOEX10 { get; set; } public double? ABONOEX10 { get; set; }
        public double? CARGO11 { get; set; } public double? ABONO11 { get; set; } public double? CARGOEX11 { get; set; } public double? ABONOEX11 { get; set; }
        public double? CARGO12 { get; set; } public double? ABONO12 { get; set; } public double? CARGOEX12 { get; set; } public double? ABONOEX12 { get; set; }
        public double? CARGO13 { get; set; } public double? ABONO13 { get; set; } public double? CARGOEX13 { get; set; } public double? ABONOEX13 { get; set; }
        public double? CARGO14 { get; set; } public double? ABONO14 { get; set; } public double? CARGOEX14 { get; set; } public double? ABONOEX14 { get; set; }
        public short? MOV01 { get; set; } public short? MOV02 { get; set; } public short? MOV03 { get; set; } public short? MOV04 { get; set; } public short? MOV05 { get; set; } public short? MOV06 { get; set; } public short? MOV07 { get; set; }
        public short? MOV08 { get; set; } public short? MOV09 { get; set; } public short? MOV10 { get; set; } public short? MOV11 { get; set; } public short? MOV12 { get; set; } public short? MOV13 { get; set; } public short? MOV14 { get; set; }
    }
}
