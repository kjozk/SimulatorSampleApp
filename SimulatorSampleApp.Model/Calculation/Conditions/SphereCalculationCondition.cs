using System;

namespace SimulatorSampleApp.Model.Calculation
{
    // --------------------------------
    // 球体用計算条件クラス
    // --------------------------------
    public class SphereCalculationCondition : CalculationConditionBase
    {
        public override CalculationShapeKind Kind => CalculationShapeKind.Sphere;

        public SphereCalculationShape Shape { get; set; } // 球体形状のプロパティ

        /// <summary>
        /// 現在のオブジェクトが、指定されたオブジェクトと等しいかどうかを判断します。
        /// </summary>
        /// <param name="obj">現在のオブジェクトと比較するオブジェクト。</param>
        /// <returns>指定されたオブジェクトが現在のオブジェクトと等しい場合は true。それ以外の場合は false。</returns>
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
            {
                return false; // 基底クラスの等価性チェックを通過しない場合は false
            }
            if (obj is SphereCalculationCondition other)
            {
                return this.Shape.Equals(other.Shape);
            }
            return false; // 型が異なる場合は false
        }

        /// <summary>
        /// 現在のオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>現在のオブジェクトのハッシュコード。</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Shape);
        }
    }
}
