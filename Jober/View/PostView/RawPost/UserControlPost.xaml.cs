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

namespace Jober.View.PostView.RawPost
{
    /// <summary>
    /// Interaction logic for UserControlPost.xaml
    /// </summary>
    public partial class UserControlPost : UserControl
    {
       // public ConnectionDbContext Context;

        private WindowPost WindowPost;

       // private BackgroundWorker Worker = new BackgroundWorker();

        //private ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> enumerable)
        //{
        //    return new ObservableCollection<T>(enumerable);
        //}

        public UserControlPost()
        {
            InitializeComponent();
        }
        public UserControlPost(WindowPost windowPost)
        {
            InitializeComponent();

         //   Context=new ConnectionDbContext();

           WindowPost = windowPost;
        }

        private void ScrollViewer_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            if (e.Delta < 0)
            {
                scrollViewer.LineRight();
            }
            else
            {
                scrollViewer.LineLeft();
            }
            e.Handled = true;
        }

        private void ToggleButtonShow_OnClick(object sender, RoutedEventArgs e)
        {
           int? ID=(int) ToggleButtonShow.CommandParameter;
            if (ID != null)
            {
                var InfoShow = WindowPost._posts.
                    Single(p => p.JobPostId == ID);

                WindowPost.TextBlockDate.Text = InfoShow.Date.ToString();

                WindowPost.RadioButtonSpecification.Content = InfoShow.Specification.Name;

                WindowPost.LabelField.Content = InfoShow.Field.Name;

                WindowPost.TextBlockCompanyName.Text = InfoShow.Company.Name;

                WindowPost.TextBlockAboutCompany.Text = InfoShow.Company.Description;

                WindowPost.DataGridAreaNum.ItemsSource = InfoShow.JobPostAreaNums;

                WindowPost.TextBoxSalary.Text = InfoShow.Salary.ToString();

                WindowPost.TextBoxWorkHour.Text = InfoShow.WorkHour;

                WindowPost.TextBoxSkills.Text = InfoShow.Skills;

                WindowPost.TextBoxMore.Text = InfoShow.More;
            }
            
        }
    }
}
