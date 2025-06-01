using SimulatorSampleApp.Model.Calculation;
using System;

namespace SimulatorSampleApp.Engine.Calculation
{
    public class CalculationFactory
    {
        // --- ファクトリーメソッド ---
        public static ICalculationStrategy Create(ICalculationCondition condition)
        {
            if (condition is PlaneCalculationCondition planeCondition)
            {
                return new PlaneCalculationStrategy(planeCondition);
            }
            if (condition is SphereCalculationCondition sphereCondition)
            {
                return new SphereCalculationStrategy(sphereCondition);
            }
            throw new NotSupportedException($"Unsupported calculation condition kind: {condition.Kind}");
        }
    }
}
