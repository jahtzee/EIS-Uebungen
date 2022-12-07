using System;
using System.Collections.Generic;
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

namespace Uebung03
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LinearGradientBrush gradient = new LinearGradientBrush();
            gradient.StartPoint = new Point(0, 0);
            gradient.EndPoint = new Point(1, 1);
            gradient.GradientStops.Add(
                new GradientStop(Colors.Yellow, 0.0));
            gradient.GradientStops.Add(
                new GradientStop(Colors.Red, 0.25));
            gradient.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.75));
            gradient.GradientStops.Add(
                new GradientStop(Colors.LimeGreen, 1.0));
            Window.Background = gradient;
            for (int i = 1; i < 11; i++) {
                TextBox tb = new TextBox();
                tb.Text = "Lorem ipsum dolor sit amet.";
                tb.Name = "TB_B_"+i;
                WrapPanel.Children.Add(tb);            
            }
        }
    }
}