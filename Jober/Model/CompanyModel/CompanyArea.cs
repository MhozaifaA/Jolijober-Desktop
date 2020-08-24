using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Jober.Model.baseclass;
using Jober.Model.MutualModel;

namespace Jober.Model.CompanyModel
{
    [Table(nameof(CompanyArea))]
    public class CompanyArea : BaseProp
    {
        
        public int AreaId { get; set; }
        public Area Area { get; set; }

        public int CompanyId { get; set; }
        public Company  Company { get; set; }

        public ICollection<CompanyJobPost> CompanyJobPosts { get; set; }
    }
}
