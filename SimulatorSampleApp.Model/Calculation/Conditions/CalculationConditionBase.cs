using System.Xml.Serialization;

namespace SimulatorSampleApp.Model.Calculation
{
    [XmlInclude(typeof(PlaneCalculationCondition))]
    [XmlInclude(typeof(SphereCalculationCondition))]
    public abstract class CalculationConditionBase : ICalculationCondition
    {
        public abstract CalculationShapeKind Kind { get; }
    }
}
