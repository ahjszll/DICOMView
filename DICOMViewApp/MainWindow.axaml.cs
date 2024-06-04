using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using FellowOakDicom;
using FellowOakDicom.Imaging;
using FellowOakDicom.Media;
using System.Collections.Generic;
using System.Diagnostics;

namespace DICOMViewApp
{
    public partial class MainWindow : Window
    {
        private List<DicomFile> _files = new List<DicomFile>();
        private List<Bitmap> _images = new List<Bitmap>();

        public MainWindow()
        {
            new DicomSetupBuilder()
  .RegisterServices(s => s.AddFellowOakDicom().AddTranscoderManager<FellowOakDicom.Imaging.NativeCodec.NativeTranscoderManager>())
  .SkipValidation()
  .Build();
            InitializeComponent();
            //LoadDCM();
            //iimg.PointerWheelChanged += Iimg_PointerWheelChanged;
            //this.PointerWheelChanged += MainWindow_PointerWheelChanged;
        }

        private int pos = 0;

        private void MainWindow_PointerWheelChanged(object? sender, Avalonia.Input.PointerWheelEventArgs e)
        {
            pos += (int)e.Delta.Y;
            if (pos < 0)
                pos = 0;
            if (pos >= _images.Count)
                pos = _images.Count - 1;
            iimg.Source = _images[pos];
            Debug.WriteLine(pos);
        }

        private void Iimg_PointerWheelChanged(object? sender, Avalonia.Input.PointerWheelEventArgs e)
        {
            pos += (int)e.Delta.Y;
            if (pos < 0)
                pos = 0;
            if (pos >= _images.Count)
                pos = _images.Count - 1;
            iimg.Source = _images[pos];
            Debug.WriteLine(pos);
        }

        private void LoadDCM()
        {
            var scan = new DicomFileScanner();
            scan.FileFound += Scan_FileFound;
            scan.Start(@"H:\DICOM\series-000001");

        }

        private void Scan_FileFound(DicomFileScanner scanner, DicomFile file, string fileName)
        {
            _files.Add(file);
            var img = new DicomImage(file.Dataset).RenderImage();

            Bitmap img2 = new Bitmap(Avalonia.Platform.PixelFormat.Bgra8888,
                Avalonia.Platform.AlphaFormat.Opaque,
                img.Pixels.Pointer,
                new Avalonia.PixelSize(img.Width, img.Height),
                new Avalonia.Vector(96, 96), img.Pixels.ByteSize / img.Pixels.Count * img.Width);
            _images.Add(img2);

        }
    }
}