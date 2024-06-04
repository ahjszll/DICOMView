using Avalonia.Controls;
using Avalonia.Media.Imaging;
using FellowOakDicom;
using FellowOakDicom.Imaging.Reconstruction;
using FellowOakDicom.Media;
using System.Collections.Generic;
using System.Diagnostics;

namespace DICOMViewApp
{
    public partial class MainWindow : Window
    {
        private List<DicomFile> _files = new List<DicomFile>();
        private List<Bitmap> _images = new List<Bitmap>();
        private List<ImageData> _imageDatas = new List<ImageData>();
        private VolumeData? _volumeData = null;

        public MainWindow()
        {
            new DicomSetupBuilder()
  .RegisterServices(s => s.AddFellowOakDicom().AddTranscoderManager<FellowOakDicom.Imaging.NativeCodec.NativeTranscoderManager>())
  .SkipValidation()
  .Build();
            InitializeComponent();
            LoadDCM();
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
            Debug.WriteLine(pos);
        }

        private void Iimg_PointerWheelChanged(object? sender, Avalonia.Input.PointerWheelEventArgs e)
        {
            pos += (int)e.Delta.Y;
            if (pos < 0)
                pos = 0;
            if (pos >= _images.Count)
                pos = _images.Count - 1;
            Debug.WriteLine(pos);
        }

        private void LoadDCM()
        {
            var scan = new DicomFileScanner();
            scan.FileFound += Scan_FileFound;
            scan.Complete += Scan_Complete;
            scan.Start(@"H:\DICOM\series-000001");
        }

        private void Scan_Complete(DicomFileScanner scanner)
        {
            _volumeData = new VolumeData(_imageDatas);
            var stack = new Stack(_volumeData, StackType.Axial, 2, 2);
            foreach (var item in stack.Slices)
            {
            }
        }

        private void Scan_FileFound(DicomFileScanner scanner, DicomFile file, string fileName)
        {
            _imageDatas.Add(new ImageData(fileName));
        }
    }
}