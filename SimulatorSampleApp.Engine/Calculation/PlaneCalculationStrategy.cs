using SimulatorSampleApp.Model.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SimulatorSampleApp.Engine.Calculation
{
    public class PlaneCalculationStrategy : ICalculationStrategy
    {
        #region プロパティ

        public ICalculationCondition Condition { get => _condition; } 

        public IReadOnlyList<CalculationResultItem> Results { get; private set; }

        #endregion

        #region フィールド

        private PlaneCalculationCondition _condition;

        #endregion

        public PlaneCalculationStrategy(PlaneCalculationCondition condition)
        {
            _condition = condition ?? throw new ArgumentNullException(nameof(condition));
            this.Results = new List<CalculationResultItem>();
        }

        public void Execute(CancellationToken token)
        {
            // NativeBridge に渡す
            var shape = _condition.Shape;

            // NativeBridge のインターフェースを呼び出して計算を実行
            var nativeResults = NativeBridge.NativeInterface.CalculatePlane(
                shape.Origin.X, shape.Origin.X, shape.Width, shape.Depth,
                shape.CountX, shape.CountY);

            SetResults(nativeResults);
        }

        private void SetResults(List<NativeBridge.CalculationResultItem> nativeResults)
        {
            // マッピング
            this.Results = nativeResults.Select(r =>
            {
                CalculationResultKind calculationResultKind;
                switch (r.Kind)
                {
                    case "Average":
                        calculationResultKind = CalculationResultKind.Average;
                        break;
                    case "Max":
                        calculationResultKind = CalculationResultKind.Maximum;
                        break;
                    case "Min":
                        calculationResultKind = CalculationResultKind.Minimum;
                        break;
                    default:
                        calculationResultKind = CalculationResultKind.Unknown;
                        break;
                }
                return new CalculationResultItem(calculationResultKind, r.Value);
            }).ToList();
        }
    }
}
