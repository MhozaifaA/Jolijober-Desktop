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
using Jober.Model.CompanyModel;
using Jober.Model.MutualModel;
using Jober.View.Settings.ManegeDataView.Windows;
using Jober.ViewModel;

namespace Jober.View.Settings.ManegeDataView.Controller
{
    /// <summary>
    /// Interaction logic for UserControlCompany.xaml
    /// </summary>
    public partial class UserControlCompany : UserControl
    {
        public ConnectionDbContext Context;
        private BackgroundWorker Worker = new BackgroundWorker();

        private ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }

        public ObservableCollection<Company> Companies;
        public ObservableCollection<CompanySpecification> CompanySpecifications;
        public ObservableCollection<CompanyArea> CompanyAreas;

        public Company CompanyCurrent;

        public IEnumerable<SearchBy> By;

        public UserControlCompany()
        {
            InitializeComponent();

            Context = new ConnectionDbContext();

            By = new List<SearchBy>()
            {
                new SearchBy()
                {
                    Id = 0,
                    Name = "All"
                },
                new SearchBy()
                {
                    Id = 1,
                    Name = "Name"
                },
                new SearchBy()
                {
                    Id = 2,
                    Name = "Mail"
                },
                new SearchBy()
                {
                    Id = 3,
                    Name = "Phone"
                },
                new SearchBy()
                {
                    Id = 4,
                    Name = "Address"
                },
                new SearchBy()
                {
                    Id = 5,
                    Name = "Field"
                },
                new SearchBy()
                {
                    Id = 6,
                    Name = "Description"
                },
            };

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

            Companies = toObservableCollection(Context.Companies.Include(nameof(Field)).Where(f => !f.IsDeleted));

            CompanySpecifications = toObservableCollection(Context.CompanySpecifications.Include(nameof(Specification))
                .Where(cs => !cs.IsDeleted));
            CompanyAreas =
                toObservableCollection(Context.CompanyAreas.Include(nameof(Area)).Where(ca => !ca.IsDeleted));

           

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            DataGridCompany.ItemsSource = Companies;

            ComboBoxBy.ItemsSource = By;
            //DataGridSpecification.ItemsSource = CompanySpecifications.Where(cs => cs.CompanyId==1);
            //  DataGridArea.ItemsSource = CompanyAreas.Where(cs => cs.CompanyId==1);

            TextBoxNumCompany.Text = Companies.Count().ToString();

            DialogHostWait.IsOpen = false;


        }

        private void GridSplitter_OnMouseEnter(object sender, MouseEventArgs e)
        {
            GridSplitter splitter = (sender) as GridSplitter;
            if (splitter.Name == "GridSplitter")
                splitter.Width = 10;
            else
            {
                splitter.Height = 10;
            }
        }


        private void GridSplitter_OnMouseLeave(object sender, MouseEventArgs e)
        {
            GridSplitter splitter = (sender) as GridSplitter;
            if (splitter.Name == "GridSplitter")
                splitter.Width = 3;
            else
            {
                splitter.Height = 3;
            }

        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            WindowModifierCompany modifierCompany = new WindowModifierCompany();

            modifierCompany.ShowDialog();
            load();

        }

        private void DataGridCompany_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CompanyCurrent = DataGridCompany.SelectedItem as Company;
            if (CompanyCurrent != null)
            {
                DataGridSpecification.ItemsSource =
                    CompanySpecifications.Where(cs => cs.CompanyId == CompanyCurrent.Id);
                TextBoxNumSpecification.Text = DataGridSpecification.Items.Count.ToString();

                DataGridArea.ItemsSource = CompanyAreas.Where(ca => ca.CompanyId == CompanyCurrent.Id);
                TextBoxNumArea.Text = DataGridArea.Items.Count.ToString();

            }
        }

        private void TextBoxSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearch.Text != String.Empty)
            {
                if ((int) ComboBoxBy.SelectedValue == 0)
                    DataGridCompany.ItemsSource = Companies.Where(c =>
                        c.Name.ToUpper().Contains(TextBoxSearch.Text.ToUpper()) ||
                        c.Mail.ToUpper().Contains(TextBoxSearch.Text.ToUpper()) ||
                        c.Phone.ToUpper().Contains(TextBoxSearch.Text.ToUpper()) ||
                        c.Address.ToUpper().Contains(TextBoxSearch.Text.ToUpper()) ||
                        c.Field.Name.ToUpper().Contains(TextBoxSearch.Text.ToUpper()) ||
                        c.Description.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
                else if ((int) ComboBoxBy.SelectedValue == 1)
                    DataGridCompany.ItemsSource = Companies.Where(c =>
                        c.Name.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
                else if ((int)ComboBoxBy.SelectedValue == 2)
                    DataGridCompany.ItemsSource = Companies.Where(c =>
                        c.Mail.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
                else if ((int)ComboBoxBy.SelectedValue == 3)
                    DataGridCompany.ItemsSource = Companies.Where(c =>
                        c.Phone.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
                else if ((int)ComboBoxBy.SelectedValue == 4)
                    DataGridCompany.ItemsSource = Companies.Where(c =>
                        c.Address.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
                else if ((int)ComboBoxBy.SelectedValue == 5)
                    DataGridCompany.ItemsSource = Companies.Where(c =>
                        c.Field.Name.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
                else if ((int) ComboBoxBy.SelectedValue == 6)
                    DataGridCompany.ItemsSource = Companies.Where(c =>
                        c.Description.ToUpper().Contains(TextBoxSearch.Text.ToUpper()));
                else
                    DataGridCompany.ItemsSource = Companies;                      
            }
            else
            {
                DataGridCompany.ItemsSource = Companies;
            }

        }
    }
}
