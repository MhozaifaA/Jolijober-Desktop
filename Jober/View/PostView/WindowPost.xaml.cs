using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Jober.Migrations;
using Jober.Model;
using Jober.Model.CompanyModel;
using Jober.Model.MutualModel;
using Jober.Model.PostModel;
using Jober.View.PostView.Layout;
using Jober.View.PostView.RawPost;
using Jober.ViewModel.VMJobPost;
using MaterialDesignThemes.Wpf;

namespace Jober.View.PostView
{
    /// <summary>
    /// Interaction logic for WindowPost.xaml
    /// </summary>
    public partial class WindowPost :Window
    {
        public ConnectionDbContext Context;
        private BackgroundWorker Worker = new BackgroundWorker();

        private ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }

        private ObservableCollection<Company> Companies;

        private ObservableCollection<Specification> Specifications;

        private ObservableCollection<Area> Areas;

        private ObservableCollection<Category> Categories;

        //private ObservableCollection<JobPost> JobPosts;

        //public to posts
        public ObservableCollection<ViewModelJobPost> _posts;

        public WindowPost()
        {
            InitializeComponent();

            Context=new ConnectionDbContext();

            Worker.DoWork += worker_DoWork;
            Worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            load();
        }
        public void load()
        {
        //    DialogHostWaitDisplay.IsOpen = true;
           // DialogHostWaitWindow.IsOpen = true;
           DialogHostWaitPost.IsOpen = true;

            if (!Worker.IsBusy)
                Worker.RunWorkerAsync();
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            Companies = toObservableCollection(
                from c in Context.Companies
                where !c.IsDeleted
                select c
            );

            Specifications = toObservableCollection(
                from s in   Context.Specifications
                where !s.IsDeleted 
                    select s
                );

            Areas = toObservableCollection(
                from a in Context.Areas
                where !a.IsDeleted
                select a
            );

            Categories = toObservableCollection(
                from c in Context.Categories
                where !c.IsDeleted
                select c
            );


            // JobPosts = toObservableCollection(Context.JobPosts.Include(nameof(CompanySpecification)).Where(jp=>!jp.IsDeleted));

            _posts = toObservableCollection(
                Context.JobPosts.Include(nameof(CompanySpecification)).
                    Where(p => !p.IsDeleted).
                    Select(p =>
                    new ViewModelJobPost()
                    {
                        JobPostId = p.Id,
                        Date = p.Date,
                        NumReact = p.NumReact,
                        Age = p.Age,
                        WorkHour = p.WorkHour,
                        Salary = p.Salary,
                        Skills = p.Skills,
                        More = p.Note,

                        Specification = p.CompanySpecification.Specification,

                        Company = p.CompanySpecification.Company,

                        Field = p.CompanySpecification.Company.Field,

                        Categories = p.JobPostCategories.
                            Where(jpc => !jpc.IsDeleted).
                            Select(jpc => jpc.Category).ToList(),


                        JobPostAreaNums = p.CompanyJobPosts.
                            Where(cjp => !cjp.IsDeleted).
                            Select(cjp => new JobPostAreaNum()
                            {
                                Numjob = cjp.NumJob ?? 0,
                                Area = cjp.CompanyArea.Area
                            }).ToList()


                    }).OrderByDescending(p=>p.Date)

            );





        
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                                                         // StackPanelPost.Children.Clear();

            ComboBoxRegisterCompany.ItemsSource = Companies;

            ComboBoxCompany.ItemsSource = Companies;

            ComboBoxSpecification.ItemsSource = Specifications;

            ComboBoxArea.ItemsSource = Areas;

            ComboBoxCatgory.ItemsSource = Categories;

                                                          // BadgedNumPost.Badge = _posts.Count;

           

                                                              //foreach (var Post in _posts)
                                                              //{
                                                              //   UserControlPost controlPost = new UserControlPost(this);
                                                           
                                                              //    controlPost.ToggleButtonShow.CommandParameter = Post.JobPostId;
                                                           
                                                              //    controlPost.TextBlockDate.Text = Post.Date.ToString();
                                                           
                                                              //    controlPost.BadgedNumReact.Badge = Post.NumReact;
                                                           
                                                              //    //Age
                                                              //    //WorkHour
                                                              //    //Salary 
                                                              //    //Skills 
                                                              //    //More 
                                                           
                                                              //    controlPost.TextBlockSpecification.Text = Post.Specification.Name;
                                                           
                                                              //    controlPost.TextBlockCompanyName.Text = Post.Company.Name;
                                                                
                                                              //    //hyper
                                                              //    //controlPost.HyperlinkCompany.NavigateUri = Post.Company.Mail;
                                                           
                                                              //    //Field
                                                           
                                                              //    foreach (var category in Post.Categories)
                                                              //    {
                                                              //         Chip chipCategory =new Chip();
                                                           
                                                              //        chipCategory.Content = category.Name;
                                                              //        chipCategory.Margin = new Thickness(5,0,5,5);
                                                           
                                                              //        controlPost.StackPanelCategory.Children.Add(chipCategory);
                                                              //    }
                                                           
                                                              //    //JobPostAreaNums  ,Area ,NumJob
                                                           
                                                              //    StackPanelPost.Children.Add(controlPost);
                                                              //   // Box.Items.Add(controlPost);
                                                              //}

            getResPost(_posts);
                                                           
              DialogHostWaitPost.IsOpen = false;

            //  DialogHostWaitDisplay.IsOpen = false;
            // DialogHostWaitWindow.IsOpen = false;
        }

        public void getResPost(ObservableCollection<ViewModelJobPost> resPost)
        {
            StackPanelPost.Children.Clear();
            BadgedNumPost.Badge = resPost.Count;
            foreach (var Post in resPost)
            {
                UserControlPost controlPost = new UserControlPost(this);

                controlPost.ToggleButtonShow.CommandParameter = Post.JobPostId;

                controlPost.TextBlockDate.Text = Post.Date.ToString();

                controlPost.BadgedNumReact.Badge = Post.NumReact;

                //Age
                //WorkHour
                //Salary 
                //Skills 
                //More 

                controlPost.TextBlockSpecification.Text = Post.Specification.Name;

                controlPost.TextBlockCompanyName.Text = Post.Company.Name;

                //hyper
                //controlPost.HyperlinkCompany.NavigateUri = Post.Company.Mail;

                //Field

                foreach (var category in Post.Categories)
                {
                    Chip chipCategory = new Chip();

                    chipCategory.Content = category.Name;
                    chipCategory.Margin = new Thickness(5, 0, 5, 5);

                    controlPost.StackPanelCategory.Children.Add(chipCategory);
                }

                //JobPostAreaNums  ,Area ,NumJob

                StackPanelPost.Children.Add(controlPost);
                // Box.Items.Add(controlPost);
            }

        }

        private void GridSplitterResize_OnMouseEnter(object sender, MouseEventArgs e)
        {
            GridSplitter gridSplitter = (sender) as GridSplitter;

            gridSplitter.Width = 10;
        }

        private void GridSplitterResize_OnMouseLeave(object sender, MouseEventArgs e)
        {
            GridSplitter gridSplitter = (sender) as GridSplitter;
            gridSplitter.Width = 3;
        }


        private void WindowPost_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void MenuItemLogout_OnClickuItemLogout_OnClick(object sender, RoutedEventArgs e)
        {
            //var _posts =
            //        Context.JobPosts.Include(nameof(CompanySpecification)).
            //            Where(p => !p.IsDeleted).
            //            Select(p =>
            //                new ViewModelJobPost()
            //                {
            //                    JobPostId = p.Id,
            //                    Date = p.Date,
            //                    NumReact = p.NumReact,
            //                    Age = p.Age,
            //                    WorkHour = p.WorkHour,
            //                    Salary = p.Salary,
            //                    Skills = p.Skills,
            //                    More = p.Note,

            //                    Specification = p.CompanySpecification.Specification,

            //                    Company = p.CompanySpecification.Company,

            //                    Field = p.CompanySpecification.Company.Field,

            //                    Categories = p.JobPostCategories.
            //                        Where(jpc => !jpc.IsDeleted).
            //                        Select(jpc => jpc.Category).ToList(),


            //                    JobPostAreaNums = p.CompanyJobPosts.
            //                        Where(cjp => !cjp.IsDeleted).
            //                        Select(cjp => new JobPostAreaNum()
            //                        {
            //                            Numjob = cjp.NumJob ?? 0,
            //                            Area = cjp.CompanyArea.Area
            //                        }).ToList()


            //                })

            //    ;

            //int x;
            //x = 1;

            this.Close();
        }

        private void ColorZoneTopBar_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            Transitioner.SelectedIndex = 1;
        }
      
        private void ToggleBack_OnClick(object sender, RoutedEventArgs e)
        {
            Transitioner.SelectedIndex = 0;
        }

        private void ButtonRegeste_OnClick(object sender, RoutedEventArgs e)
        {
            if (ComboBoxRegisterCompany.SelectedValue != null)
            {
                int ID =(int) ComboBoxRegisterCompany.SelectedValue;
                WindowModifyPost modifyPost = new WindowModifyPost(ID);
                modifyPost.ShowDialog();
                Transitioner.SelectedIndex = 0;

                load();

                Snackbar.IsActive = true;
                //  SnackbarMessageQueue messageQueue = new SnackbarMessageQueue();
                //Snackbar.MessageQueue = messageQueue;
                //messageQueue.Enqueue("Check"); 

            }
            else
            {
                MessageBox.Show("Please select company");
            }

           
        }

        private void SnackbarMessage_OnActionClick(object sender, RoutedEventArgs e)
        {
            Snackbar.IsActive = false;
        }

        private void MenuItemModren_OnClick(object sender, RoutedEventArgs e)
        {
            GridSplitter.Visibility = Visibility.Collapsed;
            Grid0.Visibility = Visibility.Collapsed;
            Grid3.Visibility = Visibility.Hidden;
        }

        private void ComboBoxSpecification_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (sender) as ComboBox;

            if (comboBox.SelectedValue != null)
            {
                DialogHostWaitPost.IsOpen = true;
                var resSearch= _posts.Where(p => p.Specification.Id == (int) ComboBoxSpecification.SelectedValue);
                //MessageBox.Show(resSearch.Count().ToString());
                getResPost(toObservableCollection(resSearch));
                DialogHostWaitPost.IsOpen = false;

            }
            else
            {
                load();
            }
        }

        private void ToggleButtonSpecification_OnUnchecked(object sender, RoutedEventArgs e)
        {
            DialogHostWaitPost.IsOpen = true;
            ComboBoxSpecification.SelectedValue = null;
            load();
            DialogHostWaitPost.IsOpen = false;

        }
    }
}
