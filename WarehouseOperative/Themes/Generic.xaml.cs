
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WarehouseOperative.Themes
{
    partial class Generic : ResourceDictionary
    {
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
