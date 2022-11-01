using System.Windows;
using System.Windows.Input;

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
    }
}
