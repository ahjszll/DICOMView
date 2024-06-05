using ReactiveUI;

namespace UIComponet.ViewModels
{
    public class UcSingleViewModel : ReactiveObject
    {
        private double _xx = 0;
        public double XX
        {
            get => _xx;
            set => this.RaiseAndSetIfChanged(ref _xx, value);
        }

        private double _yy = 0;
        public double YY
        {
            get => _yy;
            set => this.RaiseAndSetIfChanged(ref _yy, value);
        }

        private EnumOperationMode _operationMode = EnumOperationMode.None;
        public EnumOperationMode OperationMode
        {
            get => _operationMode;
            set => this.RaiseAndSetIfChanged(ref _operationMode, value);
        }

        public void ChangeMode(EnumOperationMode operationMode)
        {
            OperationMode = operationMode;
        }
    }
    public enum EnumOperationMode
    {
        None,
        Move,
        Scale,
        Rotate
    }
}