using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;

namespace Jober.Model.PostModel
{
    //break  JobPost-Category
    [Table(nameof(JobPostCategory))]
    public class JobPostCategory : BaseProp
    {
        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
