using SimulatorSampleApp.Model;
using SimulatorSampleApp.MVVM;

namespace SimulatorSampleApp.UI.ViewModels
{
    public class PlaneConditionViewModel : ViewModelWrapper<PlaneCalculationCondition>
    {
        public PlaneConditionViewModel(PlaneCalculationCondition model) : base(model) { }

        public double OriginX
        {
            get => Model.Origin.X;
            set
            {
                if (Model.Origin.X != value)
                {
                    var temp = Model.Origin;
                    temp.X = value;
                    Model.Origin = temp;
                    OnPropertyChanged(nameof(OriginX));
                }
            }
        }

        public double OriginY
        {
            get => Model.Origin.Y;
            set
            {
                if (Model.Origin.Y != value)
                {
                    var temp = Model.Origin;
                    temp.Y = value;
                    Model.Origin = temp;
                    OnPropertyChanged(nameof(OriginY));
                }
            }
        }

        public double Width
        {
            get => Model.Width;
            set => SetProperty(() => Model.Width, v => Model.Width = v, value);
        }

        public double Depth
        {
            get => Model.Depth;
            set => SetProperty(() => Model.Depth, v => Model.Depth = v, value);
        }

        public int PointCountX
        {
            get => Model.CountX;
            set => SetProperty(() => Model.CountX, v => Model.CountX = v, value, nameof(PointCountX));
        }

        public int PointCountY
        {
            get => Model.CountY;
            set => SetProperty(() => Model.CountY, v => Model.CountY = v, value, nameof(PointCountY));
        }
    }
}
