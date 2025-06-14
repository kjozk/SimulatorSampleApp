namespace SimulatorSampleApp.Model.Calculation
{
    // --------------------------------
    // 計算形状種別列挙型
    // --------------------------------
    public enum CalculationShapeKind
    {
        Invalid,
        Plane,
        Sphere,
    }

    // --------------------------------
    // 計算結果種別列挙型
    // --------------------------------
    public enum CalculationResultKind
    {
        Unknown,
        Average,
        Maximum,
        Minimum,
    }

    // --------------------------------
    // 計算単位種別列挙型
    // --------------------------------
    public enum CalculationUnitKind
    {
        None,
        Meter,
        Kilogram,
        Second,
        Lumen,
    }
}
