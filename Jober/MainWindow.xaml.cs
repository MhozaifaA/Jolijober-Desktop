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
using Jober.View;
using Jober.View.PostView;
using Jober.View.Settings.ManegeDataView;
using Jober.View.Settings.StatisticsView;

namespace Jober
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

        private ManegeData manegeData;

        private Statistics Statistics;

       

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();

        }


        private void MainWindow_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          
            base.OnMouseLeftButtonDown(e);
           this.DragMove();
          
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonMaximize_OnClick(object sender, RoutedEventArgs e)
        {
          
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;


        }

        private void ButtonMinimize_OnClick(object sender, RoutedEventArgs e)
        {
           
            this.WindowState = WindowState.Minimized;
        }

        private void ListViewItemOpenCommand_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
         
            try
            {
                DialogHostWait.IsOpen = true;
                WindowDisplayCommand windowDisplayCommand = new WindowDisplayCommand();
                windowDisplayCommand.ShowDialog();
                DialogHostWait.IsOpen = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void StackPanelManegeData_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            if (manegeData==null)
            manegeData=new ManegeData();

            ContentControlUser.Content = manegeData;

        }

        private void StackPanelSideBar_OnMouseLeave(object sender, MouseEventArgs e)
        {
            TreeViewItemSettings.IsExpanded = false;
        }

        private void TreeView_OnMouseEnter(object sender, MouseEventArgs e)
        {
            TreeViewItemSettings.IsExpanded = true;
        }

        private void TreeView_OnMouseLeave(object sender, MouseEventArgs e)
        {
            TreeViewItemSettings.IsExpanded = false;
        }

       
        private void StackPanelPost_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowPost post = new WindowPost();

            post.ShowDialog();
        }


        private void StackPanelStatistics_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          if(Statistics==null)
              Statistics=new Statistics();

            ContentControlUser.Content = Statistics;
        }
    }
}
