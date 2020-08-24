using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
using System.Windows.Shapes;
using Jober.Model;
using Jober.Model.CompanyModel;
using Jober.Model.MutualModel;

namespace Jober.View.Settings.ManegeDataView.Windows
{
    /// <summary>
    /// Interaction logic for WindowModifierCompany.xaml
    /// </summary>
    public partial class WindowModifierCompany : Window
    {
        public ConnectionDbContext Context;
        private BackgroundWorker Worker = new BackgroundWorker();

        private ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
        public ObservableCollection<Field> Fields;

        public ObservableCollection<Specification> Specifications;

        public ObservableCollection<Area> Areas;

        public ObservableCollection<Specification> SpecificationsPick;

        public ICollection<int> PickSpecificationId;


        public ObservableCollection<Area> AreaPick;

        public ICollection<int> PickAreaId;


        public WindowModifierCompany()
        {
            InitializeComponent();

            InitializeComponent();
            Context = new ConnectionDbContext();

            SpecificationsPick = new ObservableCollection<Specification>();
            PickSpecificationId = new List<int>();

            AreaPick = new ObservableCollection<Area>();
            PickAreaId = new List<int>();

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
            Specifications = toObservableCollection(Context.Specifications.Where(f => !f.IsDeleted));
            Areas = toObservableCollection(Context.Areas.Where(f => !f.IsDeleted));

        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            ComboBoxField.ItemsSource = Fields;

            DataGridSpecification.ItemsSource = Specifications;

            DataGridArea.ItemsSource = Areas;

            DialogHostWait.IsOpen = false;


        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void GridSplitter_OnMouseEnter(object sender, MouseEventArgs e)
        {
            GridSplitter splitter = (sender) as GridSplitter;
            splitter.Width = 10;
        }

        private void GridSplitter_OnMouseLeave(object sender, MouseEventArgs e)
        {
            GridSplitter splitter = (sender) as GridSplitter;
            splitter.Width = 3;
        }

        private void ButtonPickSpecification_OnClick(object sender, RoutedEventArgs e)
        {
            Button ButtonPick = (sender) as Button;
            int ID = (int)ButtonPick.CommandParameter;


            PickSpecificationId.Add(ID);

            SpecificationsPick.Add(Specifications.Where(s => s.Id == ID).Single());

            DataGridSpecificationPick.ItemsSource = SpecificationsPick;

            DataGridSpecification.ItemsSource = Specifications.Where(s => !PickSpecificationId.Contains(s.Id));

            TextBoxSearchSpecification.Text = String.Empty;


            //   DataGridSpecification.ItemsSource = Specifications.Join(Ints,sc=>sc.Id,p=>p,(sc,p)=>sc);

        }


        private void ButtonDeleteSpecification_OnClick(object sender, RoutedEventArgs e)
        {
            Button ButtonPick = (sender) as Button;
            int ID = (int)ButtonPick.CommandParameter;


            PickSpecificationId.Remove(ID);

            SpecificationsPick.Remove(Specifications.Where(s => s.Id == ID).Single());

            DataGridSpecificationPick.ItemsSource = SpecificationsPick;

            DataGridSpecification.ItemsSource = Specifications.Where(s => !PickSpecificationId.Contains(s.Id));

            TextBoxSearchSpecificationPick.Text = String.Empty;
        }

        private void TextBoxSearchSpecification_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearchSpecification.Text != String.Empty)
                DataGridSpecification.ItemsSource = Specifications.
                    Where(s => !PickSpecificationId.Contains(s.Id)
                               && s.Name.ToUpper().Contains(TextBoxSearchSpecification.Text.ToUpper()));
            else
            {
                DataGridSpecification.ItemsSource = Specifications.
                    Where(s => !PickSpecificationId.Contains(s.Id));
            }

        }

        private void TextBoxSearchSpecificationPick_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearchSpecificationPick.Text != String.Empty)
                DataGridSpecificationPick.ItemsSource = SpecificationsPick.
                    Where(s => s.Name.ToUpper().Contains(TextBoxSearchSpecificationPick.Text.ToUpper()));
            else
            {
                DataGridSpecificationPick.ItemsSource = SpecificationsPick;
            }
        }



        private void ButtonPickArea_OnClick(object sender, RoutedEventArgs e)
        {
            Button ButtonPick = (sender) as Button;
            int ID = (int)ButtonPick.CommandParameter;


            PickAreaId.Add(ID);

            AreaPick.Add(Areas.Where(a => a.Id == ID).Single());

            DataGridAreaPick.ItemsSource = AreaPick;

            DataGridArea.ItemsSource = Areas.Where(a => !PickAreaId.Contains(a.Id));

            TextBoxSearchArea.Text = String.Empty;

        }

        private void ButtonDeleteArea_OnClick(object sender, RoutedEventArgs e)
        {
            Button ButtonPick = (sender) as Button;
            int ID = (int)ButtonPick.CommandParameter;


            PickAreaId.Remove(ID);

            AreaPick.Remove(Areas.Where(a => a.Id == ID).Single());

            DataGridAreaPick.ItemsSource = AreaPick;

            DataGridArea.ItemsSource = Areas.Where(a => !PickAreaId.Contains(a.Id));

            TextBoxSearchAreaPick.Text = String.Empty;
        }

        private void TextBoxSearchArea_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearchArea.Text != String.Empty)
                DataGridArea.ItemsSource = Areas.
                    Where(a => !PickAreaId.Contains(a.Id)
                               && a.Name.ToUpper().Contains(TextBoxSearchArea.Text.ToUpper()));
            else
            {
                DataGridArea.ItemsSource = Areas.
                    Where(a => !PickAreaId.Contains(a.Id));
            }
        }

        private void TextBoxSearchAreaPick_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearchAreaPick.Text != String.Empty)
                DataGridAreaPick.ItemsSource = AreaPick.
                    Where(a => a.Name.ToUpper().Contains(TextBoxSearchAreaPick.Text.ToUpper()));
            else
            {
                DataGridAreaPick.ItemsSource = AreaPick;
            }
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            DialogHostWait.IsOpen = true;
            if (ComboBoxField.SelectedValue != null && TextBoxName.Text.Trim() != String.Empty)
            {
                var CompanySet = new Company()
                {
                    Name = TextBoxName.Text,
                    Mail = TextBoxMail.Text,
                    Phone = TextBoxPhone.Text,
                    Address = TextBoxAddress.Text,
                    FieldId = (int) ComboBoxField.SelectedValue,
                    Description = TextBoxDescription.Text
                };

                Context.Companies.Add(CompanySet);
                Context.SaveChanges();


                // CompanySet.Id
                if (PickSpecificationId.Any())
                {
                    foreach (var SpecificationId in PickSpecificationId)
                    {
                        var CompanySpecificationSet = new CompanySpecification()
                        {
                            CompanyId = CompanySet.Id,
                            SpecificationId = SpecificationId
                        };

                        Context.CompanySpecifications.Add(CompanySpecificationSet);
                    }

                    Context.SaveChanges();
                }

                if (PickAreaId.Any())
                {
                    foreach (var AreaId in PickAreaId)
                    {
                        var CompanyAreaSet = new CompanyArea()
                        {
                            CompanyId = CompanySet.Id,
                            AreaId = AreaId
                        };

                        Context.CompanyAreas.Add(CompanyAreaSet);
                    }

                    Context.SaveChanges();
                }

                this.Close();
            }
            else
            {
                DialogHostWait.IsOpen = false;

                MessageBox.Show("Fill Data");

            }
            DialogHostWait.IsOpen = false;

         

        }
    }
}
