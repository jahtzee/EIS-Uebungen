using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Uebung06_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColorSelectionHandler(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show((string)((Button)sender).Content);
            
            switch ((string)((Button)sender).Content)
            {
                case ("Rot"):
                    canvas.DefaultDrawingAttributes.Color = Color.FromRgb(255, 0, 0);
                    break;
                case ("Grün"):
                    canvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 255, 0);
                    break;
                case ("Blau"):
                    canvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 0, 255);
                    break;
                default:
                    canvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 0, 0);
                    break;
            }
        }

        private void DrawingToolSelectionHandler(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show((string)((RadioButton)sender).Content);
            switch ((string)((RadioButton)sender).Content)
            {
                case ("Pinsel"):
                    canvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case ("Radierer"):
                    canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                default:
                    canvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
            }
        }

        private void SizeSelectionHandler(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show((string)((ListBoxItem)sender).Content);
            switch ((string)((ListBoxItem)sender).Content)
            {
                case ("Groß"):
                    canvas.DefaultDrawingAttributes.Width = 20;
                    canvas.DefaultDrawingAttributes.Height = 20;
                    break;
                case ("Mittel"):
                    canvas.DefaultDrawingAttributes.Width = 10;
                    canvas.DefaultDrawingAttributes.Height = 10;
                    break;
                case ("Klein"):
                    canvas.DefaultDrawingAttributes.Width = 1;
                    canvas.DefaultDrawingAttributes.Height = 1;
                    break;
                default:
                    canvas.DefaultDrawingAttributes.Width = 1;
                    canvas.DefaultDrawingAttributes.Height = 1;
                    break;
            }
        }

        private void SaveBtnHandler(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Image"; // Default Dateiname
            dlg.DefaultExt = ".png"; // Default Dateierweiterung
            dlg.Filter = "Image Files (.png)|*.png"; // Typfilter für Dateispeicherdialog
                                                     // Zeige den Dateispeicherdialog
            Nullable<bool> result = dlg.ShowDialog();
            // Verarbeite Ergebnis. Nur wenn “OK” geklickt wird, wird auch gespeichert!
            if (result == true)
            {
                // Speichere die Bilddaten in die Datei
                string filename = dlg.FileName;
                MemoryStream ms = new MemoryStream();
                FileStream fs = new FileStream(filename, FileMode.Create);
                RenderTargetBitmap rtb = new
               RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight,
               96d, 96d, PixelFormats.Default);
                rtb.Render(canvas);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                encoder.Save(fs);
                fs.Close();
            }
        }
    }
}
