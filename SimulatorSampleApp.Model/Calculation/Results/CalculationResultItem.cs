namespace SimulatorSampleApp.Model.Calculation
{
    // --------------------------------
    // 計算結果アイテムクラス
    // --------------------------------
    public class CalculationResultItem
    {
        public CalculationResultKind Kind { get; set; }
        public double Value { get; set; }
        public CalculationUnitKind Unit { get; set; }

        public CalculationResultItem()
        {
            Kind = CalculationResultKind.Unknown;
            Value = 0;
            Unit = CalculationUnitKind.None;
        }

        public CalculationResultItem(CalculationResultKind kind, double value, CalculationUnitKind unit = CalculationUnitKind.None)
        {
            Kind = kind;
            Value = value;
            Unit = unit;
        }
    }
}
