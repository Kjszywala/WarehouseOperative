using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace WarehouseOperative.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object Windowstyle { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
                //DragMove();
        }

        private void MinMax_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                string packUri = "pack://application:,,,/Views/Content/Icons/maximize4.png";
                MinMaxImage.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                //Style style = this.FindResource("NavigationButton") as Style;
                //MinMaxButton.Style = style;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                string packUri = "pack://application:,,,/Views/Content/Icons/minimalize2.png";
                MinMaxImage.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                //Style style = this.FindResource("NavigationButton") as Style;
                //MinMaxButton.Style = style;
            }
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Expander_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;

            if (fe is ToggleButton && fe.Name == "HeaderSite")
            {
                if (ButtonExpander.IsExpanded == true)
                {
                    Buttons_column.Width = new GridLength(25);
                }
                else
                {
                    Buttons_column.Width = new GridLength(150);
                }
            }
        }

        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as Grid;
            if (overflowGrid != null)
            {
                overflowGrid.Background = Brushes.Transparent;
                if (overflowGrid.IsMouseOver == true)
                {
                    overflowGrid.Background = Brushes.Transparent;
                }
            }

            var overflowButton = toolBar.Template.FindName("OverflowButton", toolBar) as ToggleButton;
            if (overflowButton != null)
            {
                overflowButton.Background = Brushes.Transparent;

            }

            var overflowPanel = toolBar.Template.FindName("PART_ToolBarOverflowPanel", toolBar) as ToolBarOverflowPanel;
            if (overflowPanel != null)
            {
                overflowPanel.Background = Brushes.Gray;
            }
        }
    }
}
