namespace SimulatorSampleApp.Model.Calculation
{
    // --------------------------------
    // 計算条件のインターフェース
    // --------------------------------
    public interface ICalculationCondition
    {
        CalculationShapeKind Kind { get; }
    }
}
