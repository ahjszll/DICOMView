using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using ReactiveUI;
using System.Diagnostics;
using UIComponet.ViewModels;

namespace UIComponet.Views;

public partial class UcSingleView : UserControl
{
    private Point? _mouseDownPos = null;
    private Point? _imgOldPoint = null;
    private UcSingleViewModel _viewModel = new UcSingleViewModel();
    private EnumOperationMode _mode = EnumOperationMode.None;


    public UcSingleView()
    {
        InitializeComponent();
        this.Loaded += UcSingleView_Loaded;
        imgParent.PointerMoved += ImgParent_PointerMoved;
        imgParent.PointerPressed += ImgParent_PointerPressed;
        imgParent.PointerReleased += ImgParent_PointerReleased;
        _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        this.DataContext = _viewModel;
    }

    private void _viewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch (_viewModel.OperationMode) 
        {
            case EnumOperationMode.None: imgParent.Cursor = Cursor.Default; break;
            case EnumOperationMode.Move: imgParent.Cursor = new Cursor(StandardCursorType.Hand); break;
            case EnumOperationMode.Scale: imgParent.Cursor = new Cursor(StandardCursorType.DragMove); break;
            case EnumOperationMode.Rotate: imgParent.Cursor = new Cursor(StandardCursorType.Arrow); break;
        }
    }

    private void UcSingleView_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void ImgParent_PointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        _mouseDownPos = null;
    }

    private void ImgParent_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var point = e.GetCurrentPoint(sender as Control);
        if (point.Properties.IsLeftButtonPressed)
        {
            _mouseDownPos = point.Position;
            _imgOldPoint = new Point(_viewModel.XX, _viewModel.YY);
        }
    }

    private void ImgParent_PointerMoved(object? sender, PointerEventArgs e)
    {
        var point = e.GetCurrentPoint(sender as Control);
        if (point.Properties.IsLeftButtonPressed)
        {
            if (_mouseDownPos != null && _imgOldPoint != null)
            {
                var newPos = point.Position;
                var dis = (_mouseDownPos - newPos);
                _viewModel.XX = _imgOldPoint.Value.X - dis.Value.X;
                _viewModel.YY = _imgOldPoint.Value.Y - dis.Value.Y;
                Debug.WriteLine(dis.Value);
            }
        }
    }

    
}