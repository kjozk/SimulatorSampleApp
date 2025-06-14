using SimulatorSampleApp.Model.Common;
using System;

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

        public override bool Equals(object obj)
        {
            if (obj is CalculationResultItem other)
            {
                return Kind == other.Kind &&
                       FloatingPointComparer.AreEqual(Value, other.Value) &&
                       Unit == other.Unit;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Kind, Value, Unit);
        }
    }
}
