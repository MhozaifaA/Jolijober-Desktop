using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Jober.Model.CompanyModel;

namespace Jober.View.Settings.ManegeDataView.Controller
{
    /// <summary>
    /// Interaction logic for UserControlSpecification.xaml
    /// </summary>
    public partial class UserControlSpecification : UserControl
    {
        public ConnectionDbContext Context;
        private BackgroundWorker Worker = new BackgroundWorker();

        private ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
        public ObservableCollection<Specification> Specifications;

        public Specification SpecificationRow;

        public UserControlSpecification()
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

            Specifications = toObservableCollection(Context.Specifications.Where(f => !f.IsDeleted));

        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           DataGridSpecification.ItemsSource = Specifications;

            TextBoxNumSpecification.Text = Specifications.Count().ToString();

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
                DataGridSpecification.ItemsSource = Specifications.Where(f => f.Name.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
            }
            else
            {
                load();
            }
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (SpecificationRow == null)
            {

                if (TextBoxName.Text != String.Empty)
                {
                    Context.Specifications.Add(new Specification()
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
                    MessageBoxResult result = MessageBox.Show("Do you want Edit this Specification", "Edit", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (TextBoxName.Text != String.Empty)
                        {
                            SpecificationRow.Name = TextBoxName.Text;

                            Context.SaveChanges();
                            SpecificationRow = null;
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
                        SpecificationRow = null;
                        TextBoxName.Text = String.Empty;
                    }

                }
                catch (Exception exception)
                {
                    SpecificationRow = null;
                    TextBoxName.Text = String.Empty;
                    throw;
                }

            }
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
           

            Button ButtonDelete = (sender) as Button;
            int ID = (int)ButtonDelete.CommandParameter;

            this.SpecificationRow = null;
            TextBoxName.Text = String.Empty;

            var SpecificationRow = Context.Specifications.Find(ID);
            if (SpecificationRow != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want delete this Specification", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    SpecificationRow.IsDeleted = true;
                    Context.SaveChanges();

                    load();
                }

            }
            else
            {
                MessageBox.Show("Try again");
            }

        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
     
            Button buttonEdit = (sender) as Button;
            int ID = (int)buttonEdit.CommandParameter;

            SpecificationRow = Context.Specifications.Find(ID);
            TextBoxName.Text = SpecificationRow.Name;

        }
    }
}
