using System;
using System.Xml.Serialization;

namespace SimulatorSampleApp.Model.Calculation
{
    [XmlInclude(typeof(PlaneCalculationCondition))]
    [XmlInclude(typeof(SphereCalculationCondition))]
    public abstract class CalculationConditionBase : ICalculationCondition
    {
        public abstract CalculationShapeKind Kind { get; }

        /// <summary>
        /// 現在のオブジェクトが、指定されたオブジェクトと等しいかどうかを判断します。
        /// </summary>
        /// <param name="obj">現在のオブジェクトと比較するオブジェクト。</param>
        /// <returns>指定されたオブジェクトが現在のオブジェクトと等しい場合は true。それ以外の場合は false。</returns>
        public override bool Equals(object obj)
        {
            if (obj is CalculationConditionBase other)
            {
                return this.Kind == other.Kind;
            }
            return false; // 型が異なる場合は false
        }

        /// <summary>
        /// 現在のオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>現在のオブジェクトのハッシュコード。</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Kind);
        }
    }
}
