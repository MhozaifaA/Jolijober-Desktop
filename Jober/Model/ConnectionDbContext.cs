using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.CommandModel;
using Jober.Model.CompanyModel;
using Jober.Model.MutualModel;
using Jober.Model.PostModel;
using Jober.Model.UserModel;

namespace Jober.Model
{
   public class ConnectionDbContext:DbContext
   {
       public ConnectionDbContext() : base(@"Data Source=.;Initial Catalog=JoliJober_DB;Integrated Security=True")
        {
         
        }

       public DbSet<Command> Commands { get; set; }


       public DbSet<Company> Companies { get; set; }

       public DbSet<CompanyJobPost> CompanyJobPosts { get; set; }

       public DbSet<CompanySpecification> CompanySpecifications { get; set; }

       public DbSet<Contract> Contracts { get; set; }

       public DbSet<Field> Fields { get; set; }

       public DbSet<Specification> Specifications { get; set; }

       public DbSet<CompanyArea> CompanyAreas { get; set; }




       public DbSet<Area> Areas { get; set; }

       public DbSet<RequestCompanyJobPostUser>  RequestCompanyJobPostUsers { get; set; }



       public DbSet<Category> Categories { get; set; }

       public DbSet<JobPost> JobPosts { get; set; }

       public DbSet<JobPostCategory> JobPostCategories { get; set; }

       public DbSet<ReactUserJobPost> ReactUserJobPosts { get; set; }


       public DbSet<ApplyPost> ApplyPosts { get; set; }

       public DbSet<Qualification> Qualifications { get; set; }

       public DbSet<ReactApplyPostCompany> ReactApplyPostCompanies { get; set; }

        public DbSet<User> Users { get; set; }

       public DbSet<UserQualification> UserQualifications { get; set; }

       

       
   }
}
