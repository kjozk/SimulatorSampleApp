using SimulatorSampleApp.Model.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SimulatorSampleApp.Engine.Calculation
{
    public class PlaneCalculationStrategy : ICalculationStrategy
    {
        // NativeBridge の Kind 列挙型から Model の Kind 列挙型へのマッピング
        private static readonly Dictionary<NativeBridge.CalculationResultKind, CalculationResultKind> _resultKindMapping =
            new Dictionary<NativeBridge.CalculationResultKind, CalculationResultKind>
            {
                { NativeBridge.CalculationResultKind.None, CalculationResultKind.Unknown },
                { NativeBridge.CalculationResultKind.Average, CalculationResultKind.Average },
                { NativeBridge.CalculationResultKind.Maximum, CalculationResultKind.Maximum },
                { NativeBridge.CalculationResultKind.Minimum, CalculationResultKind.Minimum },
                // 他の種類があればここに追加
            };

        // NativeBridge の Unit 列挙型から Model の Unit 列挙型へのマッピング
        private static readonly Dictionary<NativeBridge.CalculationUnitKind, CalculationUnitKind> _unitKindMapping =
            new Dictionary<NativeBridge.CalculationUnitKind, CalculationUnitKind>
            {
                { NativeBridge.CalculationUnitKind.None, CalculationUnitKind.None },
                { NativeBridge.CalculationUnitKind.Meter, CalculationUnitKind.Meter },
                { NativeBridge.CalculationUnitKind.Kilogram, CalculationUnitKind.Kilogram },
                { NativeBridge.CalculationUnitKind.Second, CalculationUnitKind.Second },
                { NativeBridge.CalculationUnitKind.Lumen, CalculationUnitKind.Lumen },
                // 他の単位があればここに追加
            };

        #region プロパティ

        public ICalculationCondition Condition { get => _condition; } 

        public IReadOnlyList<CalculationResultItem> Results { get; private set; }

        #endregion

        #region フィールド

        private readonly PlaneCalculationCondition _condition;

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
            var nativeResults = NativeBridge.Calculation.CalculatePlane(
                shape.Origin.X, shape.Origin.X, shape.Width, shape.Depth,
                shape.CountX, shape.CountY);

            SetResults(nativeResults);
        }

        private void SetResults(List<NativeBridge.CalculationResultItem> nativeResults)
        {
            // マッピング
            this.Results = nativeResults.Select(r =>
            {
                return new CalculationResultItem(ToModelResultKind(r.Kind), r.Value, ToModelUnitKind(r.Unit));
            }).ToList();
        }


        private static CalculationResultKind ToModelResultKind(NativeBridge.CalculationResultKind nativeKind)
        {
            // TryGetValue を使うことで、キーが存在しない場合のデフォルト値を指定できる
            // または ContainsKey で存在チェック後、直接アクセスする
            if (_resultKindMapping.TryGetValue(nativeKind, out var modelKind))
            {
                return modelKind;
            }
            // マッピングされていない場合はUnknownを返す（Model側の列挙型にUnknownが必要）
            return CalculationResultKind.Unknown;
        }

        private static CalculationUnitKind ToModelUnitKind(NativeBridge.CalculationUnitKind nativeUnit)
        {
            if (_unitKindMapping.TryGetValue(nativeUnit, out var modelUnit))
            {
                return modelUnit;
            }
            // マッピングされていない場合はUnknownを返す（Model側の列挙型にUnknownが必要）
            return CalculationUnitKind.None;
        }
    }
}
