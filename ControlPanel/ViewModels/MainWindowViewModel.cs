using Avalonia.Threading;
using ReactiveUI;
using System;

namespace ControlPanel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {
        private DispatcherTimer _timer = new DispatcherTimer();


        private string _dateTimeNow = "";
        public string DateTimeNow
        {
            get => _dateTimeNow;
            set => this.RaiseAndSetIfChanged(ref _dateTimeNow, value);
        }


        public MainWindowViewModel()
        {
            _timer.Tick += _timer_Tick;
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Start();
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            DateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        void IDisposable.Dispose()
        {
            _timer.Stop();
        }
    }
}
