using SimulatorSampleApp.Model.Calculation;
using SimulatorSampleApp.MVVM;

namespace SimulatorSampleApp.UI.ViewModels
{
    public class ConditionViewModelWrapper : ViewModelWrapper<CalculationConditionBase>
    {
        protected ConditionViewModelWrapper(CalculationConditionBase model) : base(model) { }
    }
}
