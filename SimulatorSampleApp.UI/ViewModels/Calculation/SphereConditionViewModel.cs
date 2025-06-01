using SimulatorSampleApp.Model.Calculation;

namespace SimulatorSampleApp.UI.ViewModels
{
    public class SphereConditionViewModel :  ConditionViewModelWrapper
    {
        public new SphereCalculationCondition Model => (SphereCalculationCondition)base.Model;

        public SphereConditionViewModel(SphereCalculationCondition model) : base(model) { }

        public double Radius { get; set; }
        public int SampleCount { get; set; }
    }
}
