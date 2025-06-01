using SimulatorSampleApp.Model.Calculation;
using System.Collections.Generic;
using System.Threading;

namespace SimulatorSampleApp.Engine.Calculation
{
    public interface ICalculationStrategy
    {
        ICalculationCondition Condition { get; }

        IReadOnlyList<CalculationResultItem> Results { get; }

        void Execute(CancellationToken token);
    }
}
