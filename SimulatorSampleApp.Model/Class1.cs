using System;
using System.Collections.Generic;
using System.Globalization;

namespace SimulatorSampleApp.Model
{
    // --------------------------------
    // 共通座標クラス
    // --------------------------------
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z = 0)
        {
            X = x; Y = y; Z = z;
        }

        public override string ToString() => $"({X}, {Y}, {Z})";
    }

    // --------------------------------
    // 計算条件種別列挙型
    // --------------------------------
    public enum CalculationConditionKind
    {
        Plane,
        Sphere,
        // 将来拡張用に追加可
    }

    // --------------------------------
    // 計算結果種別列挙型（例示）
    // --------------------------------
    public enum CalculationResultKind
    {
        Average,
        Maximum,
        Minimum,
    }

    // --------------------------------
    // 計算条件のインターフェース
    // --------------------------------
    public interface ICalculationCondition
    {
        CalculationConditionKind Kind { get; }
    }

    // --------------------------------
    // 計算条件ベースクラス（必要なら）
    // --------------------------------
    public abstract class CalculationConditionBase : ICalculationCondition
    {
        public abstract CalculationConditionKind Kind { get; }
    }

    // --------------------------------
    // 平面用計算条件クラス
    // --------------------------------
    public class PlaneCalculationCondition : CalculationConditionBase
    {
        public override CalculationConditionKind Kind => CalculationConditionKind.Plane;

        public Point3D Origin { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public int CountX { get; set; }
        public int CountY { get; set; }

        public PlaneCalculationCondition(Point3D origin, double width, double depth, int countX, int countY)
        {
            Origin = origin;
            Width = width;
            Depth = depth;
            CountX = countX;
            CountY = countY;
        }
    }

    // --------------------------------
    // 球体用計算条件クラス
    // --------------------------------
    public class SphereCalculationCondition : CalculationConditionBase
    {
        public override CalculationConditionKind Kind => CalculationConditionKind.Sphere;

        public Point3D Center { get; set; }
        public double Radius { get; set; }
        public int CountTheta { get; set; }
        public int CountPhi { get; set; }

        public SphereCalculationCondition(Point3D center, double radius, int countTheta, int countPhi)
        {
            Center = center;
            Radius = radius;
            CountTheta = countTheta;
            CountPhi = countPhi;
        }
    }

    // --------------------------------
    // 計算結果アイテムクラス
    // --------------------------------
    public class CalculationResultItem
    {
        public CalculationResultKind Kind { get; }
        public double Value { get; }

        public CalculationResultItem(CalculationResultKind kind, double value)
        {
            Kind = kind;
            Value = value;
        }
    }

    // --------------------------------
    // 計算結果コレクション
    // --------------------------------
    public class CalculationResult : List<CalculationResultItem>
    {
        public CalculationResult() : base() { }

        public CalculationResult(IEnumerable<CalculationResultItem> items) : base(items) { }
    }
}
