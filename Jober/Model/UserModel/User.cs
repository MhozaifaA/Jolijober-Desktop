using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;
using Jober.Model.MutualModel;
using Jober.Model.PostModel;

namespace Jober.Model.UserModel
{

    [Table(nameof(User))]
    public class User:BaseProp
    {
        [Required]
        public string Name { get; set; }

        [DataType(dataType:DataType.Url)]
        public string Mail { get; set; }

        public string Phone { get; set; }

        public DateTime Birthday { get; set; }

        public string Note { get; set; }

        public bool? Gender { get; set; }

        public int? AreaId { get; set; }
        public Area Area { get; set; }


       public ICollection<ReactUserJobPost> ReactUserPostJobs { get; set; }

        public ICollection<RequestCompanyJobPostUser> RequestCompanyJobPostUsers { get; set; }

        public ICollection<UserQualification> UserQualifications { get; set; }

        public ICollection<ApplyPost> ApplyPosts { get; set; }
    }
}
