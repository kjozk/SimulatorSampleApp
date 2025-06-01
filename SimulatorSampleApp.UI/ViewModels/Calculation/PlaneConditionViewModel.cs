using SimulatorSampleApp.Model.Calculation;

namespace SimulatorSampleApp.UI.ViewModels
{
    public class PlaneConditionViewModel : ConditionViewModelWrapper
    {
        public new PlaneCalculationCondition Model => (PlaneCalculationCondition)base.Model;

        public PlaneConditionViewModel(PlaneCalculationCondition model) : base(model) { }

        public double OriginX
        {
            get => Model.Shape.Origin.X;
            set
            {
                if (Model.Shape.Origin.X != value)
                {
                    Model.Shape.Origin = Model.Shape.Origin.WithX(value);
                    OnPropertyChanged(nameof(OriginX));
                }
            }
        }

        public double OriginY
        {
            get => Model.Shape.Origin.Y;
            set
            {
                if (Model.Shape.Origin.Y != value)
                {
                    Model.Shape.Origin = Model.Shape.Origin.WithY(value);
                    OnPropertyChanged(nameof(OriginY));
                }
            }
        }

        public double Width
        {
            get => Model.Shape.Width;
            set => SetProperty(() => Model.Shape.Width, v => Model.Shape.Width = v, value);
        }

        public double Depth
        {
            get => Model.Shape.Depth;
            set => SetProperty(() => Model.Shape.Depth, v => Model.Shape.Depth = v, value);
        }

        public int PointCountX
        {
            get => Model.Shape.CountX;
            set => SetProperty(() => Model.Shape.CountX, v => Model.Shape.CountX = v, value, nameof(PointCountX));
        }

        public int PointCountY
        {
            get => Model.Shape.CountY;
            set => SetProperty(() => Model.Shape.CountY, v => Model.Shape.CountY = v, value, nameof(PointCountY));
        }
    }
}
