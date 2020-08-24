using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Jober.Model;
using Jober.Model.MutualModel;

namespace Jober.View.Settings.ManegeDataView.Controller
{
    /// <summary>
    /// Interaction logic for UserControlArea.xaml
    /// </summary>
    public partial class UserControlArea : UserControl
    {
        public ConnectionDbContext Context;
        private BackgroundWorker Worker = new BackgroundWorker();

        private ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
        public ObservableCollection<Area> Areas;

        public Area AreaRow;
        public UserControlArea()
        {
            InitializeComponent();

            Context = new ConnectionDbContext();

            Worker.DoWork += worker_DoWork;
            Worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            load();

        }

        public void load()
        {
            DialogHostWait.IsOpen = true;
            if (!Worker.IsBusy)
                Worker.RunWorkerAsync();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            Areas = toObservableCollection(Context.Areas.Where(f => !f.IsDeleted));

        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            DataGridArea.ItemsSource = Areas;

            TextBoxNumArea.Text = Areas.Count().ToString();

            DialogHostWait.IsOpen = false;


        }

        private void GridSplitter_OnMouseEnter(object sender, MouseEventArgs e)
        {
            GridSplitter.Width = 10;
        }

        private void GridSplitter_OnMouseLeave(object sender, MouseEventArgs e)
        {
            GridSplitter.Width = 3;
        }

        private void TextBoxSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearch.Text != String.Empty)
            {
                DataGridArea.ItemsSource = Areas.Where(f => f.Name.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
            }
            else
            {
                load();
            }
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (AreaRow == null)
            {

                if (TextBoxName.Text != String.Empty)
                {
                    Context.Areas.Add(new Area()
                    {
                        Name = TextBoxName.Text
                    });
                    Context.SaveChanges();
                    // Context.Dispose();

                    TextBoxName.Text = String.Empty;
                    load();


                }
                else
                {
                    MessageBox.Show("Fill the data");
                }
            }
            else //Edit
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Do you want Edit this Area", "Edit", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (TextBoxName.Text != String.Empty)
                        {
                            AreaRow.Name = TextBoxName.Text;

                            Context.SaveChanges();
                            AreaRow = null;
                            TextBoxName.Text = String.Empty;
                            //dispose
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Fill the data");
                        }
                    }
                    else if (result == MessageBoxResult.Cancel)
                    {
                        AreaRow = null;
                        TextBoxName.Text = String.Empty;
                    }

                }
                catch (Exception exception)
                {
                    AreaRow = null;
                    TextBoxName.Text = String.Empty;
                    throw;
                }

            }
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Button buttonEdit = (sender) as Button;
            int ID = (int)buttonEdit.CommandParameter;

            AreaRow = Context.Areas.Find(ID);
            TextBoxName.Text = AreaRow.Name;
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Button ButtonDelete = (sender) as Button;
            int ID = (int)ButtonDelete.CommandParameter;

            this.AreaRow = null;
            TextBoxName.Text = String.Empty;


            var AreaRow = Context.Areas.Find(ID);
            if (AreaRow != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want delete this Area", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    AreaRow.IsDeleted = true;
                    Context.SaveChanges();

                    load();
                }

            }
            else
            {
                MessageBox.Show("Try again");
            }
        }
    }
}
