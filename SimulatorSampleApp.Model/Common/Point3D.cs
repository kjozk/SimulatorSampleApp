using System;
using System.Xml.Serialization;

namespace SimulatorSampleApp.Model.Common
{
    // --------------------------------
    // 共通座標クラス
    // --------------------------------
    public struct Point3D
    {
        [XmlAttribute("X")] // XML要素ではなく属性としてシリアル化
        public double X { get; set; }
        [XmlAttribute("Y")]
        public double Y { get; set; }
        [XmlAttribute("Z")]
        public double Z { get; set; }

        public Point3D(double x, double y, double z = 0)
        {
            X = x; Y = y; Z = z;
        }

        // 座標を変更したい場合は、新しいインスタンスを返すメソッドを追加
        public Point3D WithX(double x) => new Point3D(x, Y, Z);
        public Point3D WithY(double y) => new Point3D(X, y, Z);
        public Point3D WithZ(double z) => new Point3D(X, Y, z);

        public override string ToString() => $"({X}, {Y}, {Z})";
        public override bool Equals(object obj) => obj is Point3D other && X == other.X && Y == other.Y && Z == other.Z;
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);
        public static bool operator ==(Point3D left, Point3D right) => left.Equals(right);
        public static bool operator !=(Point3D left, Point3D right) => !(left == right);
    }
}
