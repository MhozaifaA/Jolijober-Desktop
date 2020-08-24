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
using Jober.Model.MutualModel;

namespace Jober.Model.UserModel
{
    //break ApplyPost-Company
    [Table(nameof(ReactApplyPostCompany))]
    public class ReactApplyPostCompany:BaseProp
    {
      
        public DateTime Date { get; set; }

        public string Comment { get; set; }

        [DefaultValue(false)]
        public bool IsAccept { get; set; }

        public int ApplyPostId { get; set; }
        public ApplyPost ApplyPost { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }


    }
}
