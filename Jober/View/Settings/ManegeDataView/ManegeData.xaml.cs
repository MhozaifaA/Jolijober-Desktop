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
using Jober.View.Settings.ManegeDataView.Controller;

namespace Jober.View.Settings.ManegeDataView
{
    /// <summary>
    /// Interaction logic for ManegeData.xaml
    /// </summary>
    public partial class ManegeData : UserControl
    {
        private UserControlField controlField;
        private UserControlSpecification ControlSpecification;
        private UserControlArea ControlArea;
        private UserControlCompany ControlCompany;
        private bool IsClick = false;

        public ManegeData()
        {
            InitializeComponent();
        }

        private void BorderManege_OnMouseEnter(object sender, MouseEventArgs e)
        { 
           

            Border border= (sender) as Border;

            if (border == BorderUser)
            {
                LabelUsers.Background = new SolidColorBrush(Color.FromRgb(255, 171, 0));
                LabelQualifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelSpecifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelAreas.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelCompanies.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelFields.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelContracts.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));

            }
            else if(border== BorderQualification)
            {
              
                LabelUsers.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelQualifications.Background = new SolidColorBrush(Color.FromRgb(255, 171, 0));
                LabelSpecifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelAreas.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelCompanies.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelFields.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelContracts.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
            }
            else if (border == BorderSpecification)
            {
                LabelUsers.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelQualifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelSpecifications.Background = new SolidColorBrush(Color.FromRgb(255, 171, 0));
                LabelAreas.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelCompanies.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelFields.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelContracts.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
            }
            else if (border == BorderAre)
            {
                LabelUsers.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelQualifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelSpecifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelAreas.Background = new SolidColorBrush(Color.FromRgb(255, 171, 0));
                LabelCompanies.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelFields.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelContracts.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
            }
            else if (border == BorderCompany)
            {
                LabelUsers.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelQualifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelSpecifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelAreas.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelCompanies.Background = new SolidColorBrush(Color.FromRgb(255, 171, 0));
                LabelFields.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelContracts.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
            }
            else if (border == BorderField)
            {
                LabelUsers.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelQualifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelSpecifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelAreas.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelCompanies.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelFields.Background = new SolidColorBrush(Color.FromRgb(255, 171, 0));
                LabelContracts.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
            }
            else if (border == BorderContract)
            {
                LabelUsers.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelQualifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelSpecifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelAreas.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelCompanies.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelFields.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelContracts.Background = new SolidColorBrush(Color.FromRgb(255, 171, 0));
            }


        }

        private void DockPanelMange_OnMouseLeave(object sender, MouseEventArgs e)
        {
            //  if (!IsClick)
            {
                LabelUsers.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelQualifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelSpecifications.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelAreas.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelCompanies.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelFields.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
                LabelContracts.Background = new SolidColorBrush(Color.FromRgb(0, 151, 167));
            }
        }

        private void BorderUser_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //  BorderUser.Background=
            //LinearGradientBrush gradientBrush = new LinearGradientBrush();
            //gradientBrush.StartPoint = new Point(0.5, 0);
            //gradientBrush.EndPoint = new Point(0.5, 1);


            //GradientStop gradientStop1 = new GradientStop();

            //gradientStop1.Color = Color.FromRgb(0, 151, 167);

            //gradientStop1.Offset = 0;

            //gradientBrush.GradientStops.Add(gradientStop1);

            //GradientStop gradientStop2 = new GradientStop();

            //gradientStop2.Color = Color.FromRgb(200, 100, 90);

            //gradientStop2.Offset = 5;

            //gradientBrush.GradientStops.Add(gradientStop2.);


            //BorderUser.Background=;
            LabelUsers.Background = new SolidColorBrush(Color.FromRgb(255, 171, 0));
            IsClick = true;


        }

        private void BorderField_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(controlField==null)
            controlField=new UserControlField();


            ContentControlManageData.Content = controlField;
        }

        private void BorderSpecification_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ControlSpecification == null)
                ControlSpecification = new UserControlSpecification();


            ContentControlManageData.Content = ControlSpecification;
        }

        private void BorderAre_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ControlArea == null)
                ControlArea = new UserControlArea();


            ContentControlManageData.Content = ControlArea;
        }

        private void BorderCompany_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ControlCompany == null)
                ControlCompany = new UserControlCompany();


            ContentControlManageData.Content = ControlCompany;
        }
    }
}
