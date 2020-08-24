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
using System.Windows.Shapes;
using Jober.Model;
using Jober.Model.CompanyModel;
using Jober.Model.MutualModel;
using Jober.Model.PostModel;
using Jober.ViewModel;

namespace Jober.View.PostView.Layout
{
    /// <summary>
    /// Interaction logic for WindowModifyPost.xaml
    /// </summary>
    public partial class WindowModifyPost : Window
    {

        public ConnectionDbContext Context;
        private BackgroundWorker Worker = new BackgroundWorker();

        private ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }

        /// 
        private ObservableCollection<_CompanySpecification> _CompanySpecifications;

        private ObservableCollection<CompanyArea> CompanyAreas;

        private ObservableCollection<Category> Categories;



        private int CommpanyId;

        private Company Company;


        #region Category

        public ObservableCollection<Category> CategoriesPick;
        public ICollection<int> PickCategoriesId;

        #endregion

        #region CompanyAreaNumJob

        private int? CompanyAreaID;
        private ICollection<CompanyAreaNumJob> PickCompanyAreaNumJobs;
        #endregion





        //not used
        public WindowModifyPost()
        {
            InitializeComponent();
        }
        //

        public WindowModifyPost(int Id)
        {
            InitializeComponent();

            CommpanyId = Id;
            Context = new ConnectionDbContext();

            CategoriesPick = new ObservableCollection<Category>();
            PickCategoriesId = new List<int>();

            PickCompanyAreaNumJobs=new List<CompanyAreaNumJob>();

            

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
            Company = Context.Companies.Find(CommpanyId);

            _CompanySpecifications = toObservableCollection(Context.CompanySpecifications.Include(nameof(Specification))
                .Where(cs => !cs.IsDeleted && cs.CompanyId == CommpanyId).
                Select(cs => new _CompanySpecification()
                {
                    Id = cs.Id,
                    Name = cs.Specification.Name,
                }));

            CompanyAreas =
                toObservableCollection(Context.CompanyAreas.Include(nameof(Area)).
                    Where(ca => !ca.IsDeleted && ca.CompanyId == CommpanyId));

            Categories = toObservableCollection(Context.Categories.Where(c => !c.IsDeleted));


        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TextBoxCompanyName.Text = Company.Name;

            ComboBoxSpecification.ItemsSource = _CompanySpecifications;

            DataGridRegion.ItemsSource = CompanyAreas;

            DatePickerDate.SelectedDate=DateTime.Now;

            DataGridCategory.ItemsSource = Categories;

            DialogHostWait.IsOpen = false;

        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

      

        private void ButtonPickCategory_OnClick(object sender, RoutedEventArgs e)
        {
            Button ButtonPick = (sender) as Button;
            int ID = (int)ButtonPick.CommandParameter;

            PickCategoriesId.Add(ID);

            CategoriesPick.Add(Categories.Where(c=>c.Id==ID).Single());

            DataGridCategoryPick.ItemsSource = CategoriesPick;

            DataGridCategory.ItemsSource = Categories.Where(c => !PickCategoriesId.Contains(c.Id));

        }

        private void ButtonDeleteCategory_OnClick(object sender, RoutedEventArgs e)
        {
            Button ButtonPick = (sender) as Button;
            int ID = (int)ButtonPick.CommandParameter;

            PickCategoriesId.Remove(ID);

            CategoriesPick.Remove(Categories.Where(a => a.Id == ID).Single());

            DataGridCategoryPick.ItemsSource = CategoriesPick;

            DataGridCategory.ItemsSource = Categories.Where(a => !PickCategoriesId.Contains(a.Id));
        }

        private void ButtonPickRegion_OnClick(object sender, RoutedEventArgs e)
        {
            Button ButtonPick = (sender) as Button;
             CompanyAreaID = (int)ButtonPick.CommandParameter;

            DialogHostRegion.IsOpen = true;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            if (CompanyAreaID.HasValue)
            {
                var Ca = CompanyAreas.Where(ca => ca.Id == CompanyAreaID).Single();

                PickCompanyAreaNumJobs.Add(new CompanyAreaNumJob()
                {
                    // send MVVM to DataGrid=> CompanyArea.Area.Name
                    CompanyAreaId =(int) CompanyAreaID,
                    CompanyArea = Ca ,
                    NumJob =TextBoxNumJob.Text.Trim()==String.Empty?0:Convert.ToInt32(TextBoxNumJob.Text)
                });

                DataGridRegionPick.ItemsSource = PickCompanyAreaNumJobs.ToList();

                //DataGridRegion.ItemsSource = CompanyAreas.
                //    Where(ca => PickCompanyAreaNumJobs..GetEnumerator().Current.CompanyArea.Id.Equals(ca.Id));

             // new for faster an Entity MHA ◄=♫
                DataGridRegion.ItemsSource = CompanyAreas.

                    Where(ca => !PickCompanyAreaNumJobs.Select(p => p.CompanyAreaId).Contains(ca.Id));
            
                //DataGridRegion.ItemsSource = CompanyAreas.
                //    Where(ca => !PickCompanyAreaNumJobs.Select(p => p.CompanyArea.Id).Contains(ca.Id));

               

            }

        }

        private void ButtonDeleteRegion_OnClick(object sender, RoutedEventArgs e)
        {
            Button ButtonPick = (sender) as Button;
             int ID = (int)ButtonPick.CommandParameter;

          //  var Ca = PickCompanyAreaNumJobs.Where(ca => ca.Id == CompanyAreaID).Single();

           PickCompanyAreaNumJobs.Remove(PickCompanyAreaNumJobs.Single(p=>p.CompanyAreaId== ID));

           DataGridRegionPick.ItemsSource = PickCompanyAreaNumJobs.ToList();

            DataGridRegion.ItemsSource = CompanyAreas.

                Where(ca => !PickCompanyAreaNumJobs.Select(p => p.CompanyAreaId).Contains(ca.Id));
        }


        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (ComboBoxSpecification.SelectedValue != null &&
                DatePickerDate.SelectedDate!=null && TextBoxSalary.Text!=string.Empty)              
            {
                
                var JobsPostSet=new JobPost()
                {
                    Date = DatePickerDate.SelectedDate.Value,
                    Age = TextBoxAge.Text,
                    WorkHour = TextBoxWorkHour.Text,
                    Salary = double.Parse(TextBoxSalary.Text),
                    Skills = TextBoxSkills.Text,
                    Note = TextBoxNote.Text,

                    CompanySpecificationId = (int) ComboBoxSpecification.SelectedValue
                };

                Context.JobPosts.Add(JobsPostSet);

                Context.SaveChanges();

                int JobPostId = JobsPostSet.Id;

                // fill JobPostCategory

                if (PickCategoriesId.Any())
                {
                    foreach (var Pick in PickCategoriesId)
                    {
                        Context.JobPostCategories.Add(new JobPostCategory()
                        {
                            CategoryId = Pick,
                            JobPostId = JobPostId
                        });
                    }

                    Context.SaveChanges();
                }

                // fill CompanyJobPost
                if (PickCompanyAreaNumJobs.Any())
                {
                    foreach (var Pick in PickCompanyAreaNumJobs)
                    {
                        var CompanyJobPostSet=new CompanyJobPost()
                        {
                            JobPostId = JobPostId,
                            CompanyAreaId = Pick.CompanyAreaId,
                            NumJob = Pick.NumJob

                        };
                        Context.CompanyJobPosts.Add(CompanyJobPostSet);
                    }

                    Context.SaveChanges();
                }


                MessageBox.Show("successful Add post");
                this.Close();

            }
            else
            {
                MessageBox.Show("Fill the miss Data");
            }



           // this.Close();
        }

    }
}
