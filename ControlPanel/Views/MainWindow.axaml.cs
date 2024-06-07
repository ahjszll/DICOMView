using Avalonia;
using Avalonia.Controls;
using ControlPanel.ViewModels;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;
using System.Threading.Tasks;

namespace ControlPanel.Views
{
    public partial class MainWindow : AppWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            TitleBar.ExtendsContentIntoTitleBar = true;
            TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Design.IsDesignMode)
                return;
            await ShowInputDialogAsync();
        }


        public async Task ShowInputDialogAsync()
        {
            var dialog = new ContentDialog();
            var viewModel = new LoginViewModel(dialog);
            dialog.Content = new Login() { DataContext = viewModel };
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.None)
                this.Close();
        }


    }
}