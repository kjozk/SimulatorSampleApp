using System;

namespace SimulatorSampleApp.Model.Calculation
{
    // --------------------------------
    // 平面用計算条件クラス
    // --------------------------------
    public class PlaneCalculationCondition : CalculationConditionBase
    {
        public override CalculationShapeKind Kind => CalculationShapeKind.Plane;

        public PlaneCalculationShape Shape { get; set; } // 平面形状のプロパティ

        public PlaneCalculationCondition()
        {
            this.Shape = new PlaneCalculationShape(); // コンストラクタで初期化
        }

        public PlaneCalculationCondition(PlaneCalculationShape shape)
        {
            this.Shape = shape ?? throw new ArgumentNullException(nameof(shape));
        }
    }
}
