using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WarehouseOperative.Views
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

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
            //    this.DragMove();
            //if (Mouse.LeftButton == MouseButtonState.Pressed)
            //    this.DragMove();
            DragMove();
        }

        private void MinMax_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                string packUri = "pack://application:,,,/Views/Content/Icons/maximize.png";
                MinMaxImage.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                string packUri = "pack://application:,,,/Views/Content/Icons/collapse(2).png";
                MinMaxImage.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            }
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
