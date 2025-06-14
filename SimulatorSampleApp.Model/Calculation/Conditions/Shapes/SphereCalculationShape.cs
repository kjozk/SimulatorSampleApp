using SimulatorSampleApp.Model.Common;
using System;

namespace SimulatorSampleApp.Model.Calculation
{
    /// <summary>
    /// 球体形状
    /// </summary>
    public class SphereCalculationShape
    {
        public Point3D Center { get; set; }
        public double Radius { get; set; }
        public int CountTheta { get; set; }
        public int CountPhi { get; set; }
        public SphereCalculationShape() { }

        /// <summary>
        /// 現在のオブジェクトが、指定されたオブジェクトと等しいかどうかを判断します。
        /// </summary>
        /// <param name="obj">現在のオブジェクトと比較するオブジェクト。</param>
        /// <returns>指定されたオブジェクトが現在のオブジェクトと等しい場合は true。それ以外の場合は false。</returns>
        public override bool Equals(object obj)
        {
            if (obj is SphereCalculationShape other)
            {
                return Center.Equals(other.Center) &&
                       FloatingPointComparer.AreEqual(Radius, other.Radius) &&
                       CountTheta == other.CountTheta &&
                       CountPhi == other.CountPhi;
            }
            return false;
        }

        /// <summary>
        /// 現在のオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>現在のオブジェクトのハッシュコード。</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Center, Radius, CountTheta, CountPhi);
        }
    }
}
