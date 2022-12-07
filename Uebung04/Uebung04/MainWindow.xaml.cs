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

namespace Uebung04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush alterBG;
        String alterContent;
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            MyButton.Click += MyButton_Handler;
            MyButton.Click += MyButton_Handler_BG;
        }

        private void MyButton_Handler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hallo Welt!");
        }

        private void MyButton_Handler_BG(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            MyButton.Background = new SolidColorBrush(Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));
        }

        private void MouseEnterHandler(object sender, MouseEventArgs e)
        {
            alterBG = (SolidColorBrush)((TextBox)sender).Background;
            alterContent = (String)((TextBox)sender).Text;
            ((TextBox)sender).Background = new SolidColorBrush(Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256)));
            ((TextBox)sender).Text = "Neuer Content";
        }

        private void MouseLeaveHandler(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).Background = alterBG;
            ((TextBox)sender).Text = alterContent;
        }
    }
}
