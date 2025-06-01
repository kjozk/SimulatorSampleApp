namespace SimulatorSampleApp.Model.Calculation
{
    // --------------------------------
    // 球体用計算条件クラス
    // --------------------------------
    public class SphereCalculationCondition : CalculationConditionBase
    {
        public override CalculationShapeKind Kind => CalculationShapeKind.Sphere;

        public SphereCalculationShape Shape { get; set; } // 球体形状のプロパティ

        // 他の情報も必要に応じて追加可能
    }
}
