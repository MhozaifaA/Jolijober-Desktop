using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;
using Jober.Model.CompanyModel;

namespace Jober.Model.PostModel
{
    [Table(nameof(JobPost))]
    public class JobPost:BaseProp
    {
        public DateTime Date { get; set; }
        
        [DefaultValue(0)]
        public int NumReact { get; set; }

        
        public string Age { get; set; }

        public string WorkHour  { get; set; }

        public double Salary  { get; set; }

        public string Skills { get; set; }

        public string Note { get; set; }

       
        public int CompanySpecificationId { get; set; }
        public CompanySpecification CompanySpecification { get; set; }

        public ICollection<JobPostCategory> JobPostCategories { get; set; }

        public ICollection<CompanyJobPost> CompanyJobPosts { get; set; }

        public ICollection<ReactUserJobPost> ReactUserPostJobs { get; set; }




    }
}
