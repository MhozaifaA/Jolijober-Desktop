using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;
using Jober.Model.PostModel;

namespace Jober.Model.CompanyModel
{
    //break Company-Specification
    [Table(nameof(CompanySpecification))]
    public class CompanySpecification:BaseProp
    {
        public int?  CompanyId { get; set; }
        public Company Company { get; set; }

        public int? SpecificationId { get; set; }
        public Specification Specification { get; set; }

        public ICollection<JobPost> JobPosts { get; set; }
    }
}
