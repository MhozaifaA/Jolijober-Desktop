using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Jober.Model;
using Jober.Model.CommandModel;

namespace Jober.View
{
    /// <summary>
    /// Interaction logic for ModifyCommand.xaml
    /// </summary>
    public partial class ModifyCommand : Window
    {
        ConnectionDbContext Context=new ConnectionDbContext();

        WindowDisplayCommand WindowDisplayCommand = new WindowDisplayCommand();

        UserControlCommand UserControlCommand;
        public ModifyCommand(WindowDisplayCommand windowDisplayCommand)
        {
            InitializeComponent();

            WindowDisplayCommand = windowDisplayCommand;
        }
        public ModifyCommand(UserControlCommand userControlCommand)
        {
            InitializeComponent();

            UserControlCommand = new UserControlCommand(WindowDisplayCommand);

            UserControlCommand = userControlCommand;

            TextBoxDescription.Text = UserControlCommand.GroupBoxCommand.Header.ToString();

            var QueryText = new TextRange(userControlCommand.RichTextBoxQuery.Document.ContentStart, userControlCommand.RichTextBoxQuery.Document.ContentEnd);

            TextBoxQuery.Text = QueryText.Text;
        }

        private void ButtonModify_OnClick(object sender, RoutedEventArgs e)
        {
            //ADD
            if (UserControlCommand == null)
            {
                try
                {
                    if (TextBoxQuery.Text != String.Empty && TextBoxQuery.Text != "" && TextBoxQuery.Text.Trim() != "")
                    {
                        DialogHostWait.IsOpen = true;


                        UserControlCommand userControlCommand = new UserControlCommand(WindowDisplayCommand);

                        var CommandSet = new Command()
                        {
                            Description = TextBoxDescription.Text,
                            Query = TextBoxQuery.Text
                        };
                        Context.Commands.Add(CommandSet);
                        Context.SaveChanges();

                        Context.Dispose();

                        userControlCommand.ButtonDelete.CommandParameter = CommandSet.Id;
                        userControlCommand.ButtonEdit.CommandParameter = CommandSet.Id;



                        userControlCommand.GroupBoxCommand.Header = TextBoxDescription.Text;

                        //string richText = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;


                        userControlCommand.RichTextBoxQuery.AppendText(TextBoxQuery.Text);



                        WindowDisplayCommand.WrapPanelCommand.Children.Add(userControlCommand);


                        DialogHostWait.IsOpen = false;

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("يجب إدخال كورية");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
               
            }
            else //Edit
            {
                try
                {
                    if (TextBoxQuery.Text != String.Empty && TextBoxQuery.Text != "" && TextBoxQuery.Text.Trim() != "")
                    {
                        DialogHostWait.IsOpen = true;
                        var CommandEdit = Context.Commands.Find(UserControlCommand.ButtonEdit.CommandParameter);

                        CommandEdit.Description = TextBoxDescription.Text;
                        CommandEdit.Query = TextBoxQuery.Text;

                        Context.SaveChanges();

                        UserControlCommand.RichTextBoxQuery.Document.Blocks.Clear();

                        UserControlCommand.GroupBoxCommand.Header = TextBoxDescription.Text;
                        UserControlCommand.RichTextBoxQuery.AppendText(TextBoxQuery.Text);


                        DialogHostWait.IsOpen = true;

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("يجب إدخال كورية");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());

                }


            }
        }
    }
}
