using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using DICOMViewApp.UserControls.DICOMView.ViewModels;

namespace DICOMViewApp.UserControls.DICOMView;

public partial class UcSingleView : UserControl
{
    private bool _pressed = false;
    private UcSingleViewModel _viewModel = new UcSingleViewModel();


    public UcSingleView()
    {
        InitializeComponent();
        imgParent.PointerMoved += ImgParent_PointerMoved;
        imgParent.PointerPressed += ImgParent_PointerPressed;
        imgParent.PointerReleased += ImgParent_PointerReleased;
        this.DataContext = _viewModel;
    }

    private void ImgParent_PointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        _pressed = false;
    }

    private void ImgParent_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        _pressed = true;
    }

    private void ImgParent_PointerMoved(object? sender, PointerEventArgs e)
    {
        if (_pressed) 
        {
            _viewModel.XX = (int)e.GetPosition(imgParent).X;
            _viewModel.YY = (int)e.GetPosition(imgParent).Y;
        }
    }
}