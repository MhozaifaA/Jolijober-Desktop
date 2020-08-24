using Jober.Model;
using Jober.Model.PostModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Jober
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //seed
            using (ConnectionDbContext context = new ConnectionDbContext())
            {
                context.Database.CreateIfNotExists();
                if (!context.Categories.Any())
                {
                 context.Categories.AddRange( new List<Category> { new Category() { Name= "Administrative " }, new Category() { Name= "Specialist" }, new Category() { Name="Manger" }, new Category() { Name = "Government" }, new Category() { Name = "Office" }, } );
                }
            }

             MainWindow window = new MainWindow();
            window.ShowDialog();
        }
    }
}
