using System;

namespace SimulatorSampleApp.Model.Common
{
    /// <summary>
    /// 浮動小数点数比較のためのユーティリティメソッドを提供します。
    /// </summary>
    public static class FloatingPointComparer
    {
        // 小数点以下3桁までを比較するための許容誤差 (0.001 / 2)
        // 必要に応じて、異なる精度のEpsilonを持つオーバーロードを定義することも可能です。
        public const double DefaultEpsilon = 0.0005;

        /// <summary>
        /// 2つの倍精度浮動小数点数が、指定された許容誤差の範囲内で等しいかどうかを判断します。
        /// </summary>
        /// <param name="value1">比較する最初の値。</param>
        /// <param name="value2">比較する2番目の値。</param>
        /// <param name="epsilon">許容誤差。デフォルトは DefaultEpsilon (0.0005)。</param>
        /// <returns>2つの値の絶対差がepsilonより小さい場合は true。それ以外の場合は false。</returns>
        public static bool AreEqual(double value1, double value2, double epsilon = DefaultEpsilon)
        {
            return Math.Abs(value1 - value2) < epsilon;
        }

        /// <summary>
        /// 2つの単精度浮動小数点数が、指定された許容誤差の範囲内で等しいかどうかを判断します。
        /// </summary>
        /// <param name="value1">比較する最初の値。</param>
        /// <param name="value2">比較する2番目の値。</param>
        /// <param name="epsilon">許容誤差。デフォルトは DefaultEpsilon (0.0005) を float にキャストした値。</param>
        /// <returns>2つの値の絶対差がepsilonより小さい場合は true。それ以外の場合は false。</returns>
        public static bool AreEqual(float value1, float value2, float epsilon = (float)DefaultEpsilon)
        {
            return Math.Abs(value1 - value2) < epsilon;
        }
    }
}
