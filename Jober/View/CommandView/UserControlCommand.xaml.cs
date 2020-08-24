using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using Jober.Properties;

namespace Jober.View
{
    /// <summary>
    /// Interaction logic for UserControlCommand.xaml
    /// </summary>
    public partial class UserControlCommand : UserControl
    {
        ConnectionDbContext Context = new ConnectionDbContext();

        WindowDisplayCommand WindowDisplayCommand;
        private bool IsExpanded;

        #region Raw Sql
        DataTable MyTable = new DataTable();
        SqlConnection myConnection = new SqlConnection("Data Source=.;Initial Catalog=JoliJober_DB;Integrated Security=True");
        SqlCommand MyCommand = new SqlCommand();
        SqlDataAdapter MyAdapter;
        #endregion
        public UserControlCommand(WindowDisplayCommand windowDisplayCommand)
        {
            InitializeComponent();

            WindowDisplayCommand = windowDisplayCommand;

            this.Height = 120;

            #region Raw Sql

            MyCommand.Connection = myConnection;
            MyAdapter = new SqlDataAdapter(MyCommand);
            #endregion
        }

     

        private void ButtonExecute_OnClick(object sender, RoutedEventArgs e)
        {
            //string richText = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
            try
            {
               WindowDisplayCommand.DialogHostWait.IsOpen = true;

                myConnection.Open();

                var CommandText = new TextRange(RichTextBoxQuery.Document.ContentStart, RichTextBoxQuery.Document.ContentEnd);

                MyCommand.CommandText = CommandText.Text;
                MyCommand.ExecuteNonQuery();

               // MyTable.Columns.Clear();
                   MyTable.Clear();
                MyAdapter.Fill(MyTable);

                myConnection.Close();

                WindowDisplayCommand.DataGridDisplay.ItemsSource = null;
                WindowDisplayCommand.DataGridDisplay.Items.Clear();
                WindowDisplayCommand.DataGridDisplay.Columns.Clear();
                WindowDisplayCommand.DataGridDisplay.Items.Refresh();

                WindowDisplayCommand.DataGridDisplay.ItemsSource = MyTable.DefaultView;

                  WindowDisplayCommand.DialogHostWait.IsOpen = false;
            }
            catch (Exception exception)
            {
                WindowDisplayCommand.DialogHostWait.IsOpen = false;
                myConnection.Close();
                MessageBox.Show("تأكد من الإدخال\n"+ exception+" ");
            }

        }

        private void ButtonExpand_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsExpanded)
            {
                this.Height = 200;
                IsExpanded = true;
            }
            else
            {
                this.Height = 120;
                IsExpanded = false;
            }
          
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowDisplayCommand.DialogHostWait.IsOpen = true;
                ModifyCommand modifyCommand = new ModifyCommand(this);
                modifyCommand.ShowDialog();
                WindowDisplayCommand.DialogHostWait.IsOpen = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
           
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Do you want delete this Command", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    WindowDisplayCommand.DialogHostWait.IsOpen = true;

                    WindowDisplayCommand.WrapPanelCommand.Children.Remove(this);

                    var CommandDelete = Context.Commands.Find(ButtonDelete.CommandParameter);

                    CommandDelete.IsDeleted = true;

                    Context.SaveChanges();

                    WindowDisplayCommand.DialogHostWait.IsOpen = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
           
           

        }
    }
}
