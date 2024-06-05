using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ControlPanel.ViewModels;

namespace ControlPanel.Views;

public partial class UserManager : UserControl
{
    private UserManagerViewModel _viewModel = new UserManagerViewModel();
    public UserManager()
    {
        InitializeComponent();
        this.DataContext = _viewModel;
    }
}