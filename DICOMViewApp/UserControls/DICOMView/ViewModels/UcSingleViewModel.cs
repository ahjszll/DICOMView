using ReactiveUI;

namespace DICOMViewApp.UserControls.DICOMView.ViewModels
{
    public class UcSingleViewModel : ReactiveObject
    {
        private int _xx =0;
        public int XX
        {
            get => _xx;
            set => this.RaiseAndSetIfChanged(ref _xx, value);
        }

        private int _yy = 0;
        public int YY
        {
            get => _yy;
            set => this.RaiseAndSetIfChanged(ref _yy, value);
        }
    }
}