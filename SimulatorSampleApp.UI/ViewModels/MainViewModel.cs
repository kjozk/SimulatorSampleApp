using SimulatorSampleApp.Engine;
using SimulatorSampleApp.Model;
using SimulatorSampleApp.MVVM;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;

namespace SimulatorSampleApp.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        private string _title = "Simulator";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ObservableCollection<string> ShapeTypes { get; } = new ObservableCollection<string>() { "Plane", "Sphere" };

        private string _selectedShape;
        public string SelectedShape
        {
            get => _selectedShape;
            set
            {
                if (SetProperty(ref _selectedShape, value))
                {
                    UpdateConditionViewModel();
                }
            }
        }

        private object _conditionViewModel;
        public object ConditionViewModel
        {
            get => _conditionViewModel;
            set => SetProperty(ref _conditionViewModel, value);
        }

        public ObservableCollection<CalculationResultItem> Results { get; } = new ObservableCollection<CalculationResultItem>();

        #endregion

        #region Commands

        public ICommand CalculateCommand { get; }

        #endregion

        public MainViewModel()
        {
            SelectedShape = "Plane"; // 初期選択
            CalculateCommand = new DelegateCommand(Calculate);
            UpdateConditionViewModel();
        }


        private void UpdateConditionViewModel()
        {
            switch (SelectedShape)
            {
                case "Plane":
                    ConditionViewModel = new PlaneConditionViewModel(new PlaneCalculationCondition(new Point3D(0,0,0), 10, 10, 0, 0));
                    break;
                case "Sphere":
                    ConditionViewModel = new SphereConditionViewModel();
                    break;
            }
        }

        private void Calculate()
        {
            Results.Clear();

            if (ConditionViewModel is PlaneConditionViewModel plane)
            {
                var engine = new SimulationEngine(plane.Model);

                engine.Run(CancellationToken.None);

                foreach (var item in engine.Results)
                {
                    Results.Add(item);
                }
            }
        }
    }
}
