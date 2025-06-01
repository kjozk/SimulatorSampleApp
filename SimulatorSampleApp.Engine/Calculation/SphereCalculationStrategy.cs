using SimulatorSampleApp.Model.Calculation;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SimulatorSampleApp.Engine.Calculation
{
    public class SphereCalculationStrategy : ICalculationStrategy
    {
        #region プロパティ

        public ICalculationCondition Condition { get => _condition; }

        public IReadOnlyList<CalculationResultItem> Results { get; private set; }

        #endregion

        #region フィールド

        private readonly SphereCalculationCondition _condition;

        #endregion

        public SphereCalculationStrategy(SphereCalculationCondition condition)
        {
            _condition = condition ?? throw new ArgumentNullException(nameof(condition));
            this.Results = new List<CalculationResultItem>();
        }

        public void Execute(CancellationToken token)
        {
        }
    }
}
