using SimulatorSampleApp.Model.Common;
using System;

namespace SimulatorSampleApp.Model.Calculation
{
    /// <summary>
    /// 平面形状
    /// </summary>
    public class PlaneCalculationShape
    {
        public Point3D Origin { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public int CountX { get; set; }
        public int CountY { get; set; }

        public PlaneCalculationShape(Point3D origin, double width, double depth, int countX, int countY)
        {
            Origin = origin;
            Width = width;
            Depth = depth;
            CountX = countX;
            CountY = countY;
        }

        public PlaneCalculationShape() { }

        /// <summary>
        /// 現在のオブジェクトが、指定されたオブジェクトと等しいかどうかを判断します。
        /// </summary>
        /// <param name="obj">現在のオブジェクトと比較するオブジェクト。</param>
        /// <returns>指定されたオブジェクトが現在のオブジェクトと等しい場合は true。それ以外の場合は false。</returns>
        public override bool Equals(object obj)
        {
            if (obj is PlaneCalculationShape other)
            {
                return Origin.Equals(other.Origin) &&
                       FloatingPointComparer.AreEqual(Width, other.Width) &&
                       FloatingPointComparer.AreEqual(Depth, other.Depth) &&
                       CountX == other.CountX &&
                       CountY == other.CountY;
            }
            return false;
        }

        /// <summary>
        /// 現在のオブジェクトのハッシュコードを返します。
        /// </summary>
        /// <returns>現在のオブジェクトのハッシュコード。</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Origin, Width, Depth, CountX, CountY);
        }
    }
}
