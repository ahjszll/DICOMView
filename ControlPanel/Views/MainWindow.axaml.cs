using Avalonia.Controls;
using FluentAvalonia.UI.Windowing;

namespace ControlPanel.Views
{
    public partial class MainWindow : AppWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            TitleBar.ExtendsContentIntoTitleBar = true;
            TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
        }
    }
}