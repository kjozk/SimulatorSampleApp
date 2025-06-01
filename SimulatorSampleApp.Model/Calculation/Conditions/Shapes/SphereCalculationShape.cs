using SimulatorSampleApp.Model.Common;

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
    }
}
