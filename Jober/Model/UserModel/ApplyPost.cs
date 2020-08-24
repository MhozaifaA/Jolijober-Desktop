using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using Jober.Model.baseclass;
using Jober.Model.CompanyModel;

namespace Jober.Model.UserModel
{
    [Table(nameof(ApplyPost))]

    public class ApplyPost:BaseProp
    {
        public DateTime Date { get; set; }

        public string Note { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public int? SpecificationId { get; set; }
        public Specification Specification { get; set; }

        public ICollection<ReactApplyPostCompany> ReactApplyPostCompanies { get; set; }
    }
}
