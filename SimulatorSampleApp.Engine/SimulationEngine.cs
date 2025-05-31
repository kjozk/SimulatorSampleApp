using SimulatorSampleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SimulatorSampleApp.Engine
{
    public class SimulationEngine
    {
        public ICalculationCondition Condition { get; private set; }

        public List<CalculationResultItem> Results { get; private set; }

        public SimulationEngine(ICalculationCondition condition)
        {
            Condition = condition ?? throw new ArgumentNullException(nameof(condition));
            Results = new List<CalculationResultItem>();
        }

        public void Run(CancellationToken token)
        {
            if (Condition is PlaneCalculationCondition plane)
            {
                // NativeBridge に渡す
                var nativeResults = NativeBridge.NativeInterface.CalculatePlane(
                    plane.Origin.X, plane.Origin.X, plane.Width, plane.Depth,
                    plane.CountX, plane.CountY);

                // マッピング
                Results = nativeResults.Select(r => {
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
                            throw new NotSupportedException($"Unsupported result kind: {r.Kind}");
                    }
                    return new CalculationResultItem(calculationResultKind, r.Value);
                }).ToList();
                return;
            }

            throw new NotSupportedException("Unsupported condition type.");
        }
    }
}
