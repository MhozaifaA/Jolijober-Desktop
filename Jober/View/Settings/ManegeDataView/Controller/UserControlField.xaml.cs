using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data.Entity;
using System.Diagnostics;
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
using Jober.Model.CompanyModel;

namespace Jober.View.Settings.ManegeDataView.Controller
{
    /// <summary>
    /// Interaction logic for UserControlField.xaml
    /// </summary>
    public partial class UserControlField : UserControl
    {
        public ConnectionDbContext Context;
        private BackgroundWorker Worker = new BackgroundWorker();

        private ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
        public ObservableCollection<Field> Fields;

        public Field FieldRow;


        public UserControlField()
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

            Fields = toObservableCollection(Context.Fields.Where(f => !f.IsDeleted));

        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            DataGridField.ItemsSource = Fields;

            TextBoxNumField.Text = Fields.Count().ToString();

            DialogHostWait.IsOpen = false;


        }

        private void GridSplitter_OnMouseEnter(object sender, MouseEventArgs e)
        {
            GridSplitter.Width = 10;

            //  GridSplitter.Background = new SolidColorBrush(Color.FromArgb(255, 0, 104, 120));
        }

        private void GridSplitter_OnMouseLeave(object sender, MouseEventArgs e)
        {
            GridSplitter.Width = 3;
            // GridSplitter.Background = new SolidColorBrush(Color.FromArgb(0,0,104,120));

        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {

            if (FieldRow == null)
            {

                if (TextBoxName.Text != String.Empty)
                {
                    Context.Fields.Add(new Field()
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
                    MessageBoxResult result = MessageBox.Show("Do you want Edit this Field", "Edit", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (TextBoxName.Text != String.Empty)
                        {
                            FieldRow.Name = TextBoxName.Text;

                            Context.SaveChanges();
                            FieldRow = null;
                            TextBoxName.Text = String.Empty;
                            //dispose
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Fill the data");
                        }
                    }
                    else if(result == MessageBoxResult.Cancel)
                    {
                        FieldRow = null;
                        TextBoxName.Text = String.Empty;
                    }
                    
                }
                catch (Exception exception)
                {
                    FieldRow = null;
                    TextBoxName.Text = String.Empty;
                    throw;
                }
                
            }
        }

        private void TextBoxSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearch.Text != String.Empty)
            {
                DataGridField.ItemsSource = Fields.Where(f => f.Name.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
            }
            else
            {
                load();
            }
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
           Button ButtonDelete=(sender) as Button;
            int ID =(int) ButtonDelete.CommandParameter;

            this.FieldRow = null;
            TextBoxName.Text = String.Empty;


            var FieldRow = Context.Fields.Find(ID);
            if ( FieldRow != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want delete this Field", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    FieldRow.IsDeleted = true;
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
            int ID =(int) buttonEdit.CommandParameter;
           
            FieldRow = Context.Fields.Find(ID);
            TextBoxName.Text = FieldRow.Name;
        }
    }
}
