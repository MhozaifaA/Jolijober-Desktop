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
using Jober.Model.PostModel;
using Jober.Model.UserModel;

namespace Jober.Model.MutualModel
{
    //braek [Company-JobPost]-User
    [Table(nameof(RequestCompanyJobPostUser))]
    public class RequestCompanyJobPostUser:BaseProp
    {
        public DateTime Date { get; set; }

        [DefaultValue(false)]
        public bool IsAccept { get; set; }

        public string Note { get; set; }

        public int CompanyJobPostId { get; set; }
        public CompanyJobPost CompanyJobPost { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        //public int? ReactUserJobPostId { get; set; }
        //public ReactUserJobPost ReactUserJobPost { get; set; }

    }
}
