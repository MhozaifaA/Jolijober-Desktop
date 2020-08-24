using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;
using Jober.Model.MutualModel;
using Jober.Model.UserModel;

namespace Jober.Model.PostModel
{
    //break  JobPost-User
    [Table(nameof(ReactUserJobPost))]
    public class ReactUserJobPost:BaseProp
    {
        

        public DateTime Date { get; set; }

        
        //public int? React { get; set; }

        public string Comment { get; set; }

        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        
     //   public ICollection<RequestCompanyJobPostUser> RequestCompanyJobPostUsers { get; set; }



    }
}
