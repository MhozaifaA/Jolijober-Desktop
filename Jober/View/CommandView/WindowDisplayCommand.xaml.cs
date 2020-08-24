using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Jober.Model;
using Jober.Model.CommandModel;
using Jober.Model.CompanyModel;
using MaterialDesignThemes.Wpf;

namespace Jober.View
{
    /// <summary>
    /// Interaction logic for WindowDisplayCommand.xaml
    /// </summary>
    public partial class WindowDisplayCommand : Window
    {
        ConnectionDbContext Context = new ConnectionDbContext();

        private BackgroundWorker Worker = new BackgroundWorker();

        public ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> a)
        {
            return new ObservableCollection<T>(a);
        }

        public ObservableCollection<Command> Commands;

        public WindowDisplayCommand()
        {
            InitializeComponent();

      

            //Worker.DoWork += worker_DoWork;
            //Worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            //load();
        }

        public void load()
        {
            Context = new ConnectionDbContext();

            DialogHostWait.IsOpen = true;
            if (!Worker.IsBusy) Worker.RunWorkerAsync();


        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            //  Commands = toObservableCollection(Context.Commands.Where(c => !c.IsDeleted));

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           
            DialogHostWait.IsOpen = false;




        }

        private void ButtonAddCommand_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DialogHostWait.IsOpen = true;
                ModifyCommand modifyCommand = new ModifyCommand(this);
                modifyCommand.ShowDialog();



                DialogHostWait.IsOpen = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());

            }


        }

        private void WindowDisplayCommand_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DialogHostWait.IsOpen = true;

                foreach (var command in Context.Commands.Where(c => !c.IsDeleted))
                {

                    UserControlCommand userControlCommand = new UserControlCommand(this);


                    userControlCommand.ButtonDelete.CommandParameter = command.Id;
                    userControlCommand.ButtonEdit.CommandParameter = command.Id;



                    userControlCommand.GroupBoxCommand.Header = command.Description;



                    userControlCommand.RichTextBoxQuery.AppendText(command.Query);



                    WrapPanelCommand.Children.Add(userControlCommand);

                }

                DialogHostWait.IsOpen = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

        }


        private void WindowDisplayCommand_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void ButtonMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonMaximize_OnClick(object sender, RoutedEventArgs e)
        {
          
            WindowState= WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void GridSplitter_MouseEnter(object sender, MouseEventArgs e)
        {
                GridSplitter.Height = 10;
        }

        private void GridSplitter_OnMouseLeave(object sender, MouseEventArgs e)
        {
            GridSplitter.Height = 3;
        }
    }
}
