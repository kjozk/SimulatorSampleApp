using SimulatorSampleApp.Model.Common;

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
    }
}
