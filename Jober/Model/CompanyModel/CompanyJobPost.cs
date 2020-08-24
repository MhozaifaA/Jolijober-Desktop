using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Jober.Model.baseclass;
using Jober.Model.MutualModel;
using Jober.Model.PostModel;

namespace Jober.Model.CompanyModel
{
    //breake Company-JobPost
    [Table(nameof(CompanyJobPost))]
    public class CompanyJobPost : BaseProp
    {
        public int? NumJob { get; set; }

        public int CompanyAreaId { get; set; }
        public CompanyArea CompanyArea { get; set; }

        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; }

        public ICollection<RequestCompanyJobPostUser> RequestCompanyJobPostUsers { get; set; }

    }
}
