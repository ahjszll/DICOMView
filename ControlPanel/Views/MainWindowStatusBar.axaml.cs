using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ControlPanel.ViewModels;

namespace ControlPanel.Views;

public partial class MainWindowStatusBar : UserControl
{
    private UserManagerViewModel _viewModel = new UserManagerViewModel();
    public MainWindowStatusBar()
    {
        InitializeComponent();
        this.DataContext = _viewModel;
    }
}