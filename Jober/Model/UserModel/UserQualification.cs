using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;

namespace Jober.Model.UserModel
{
    //break User-Qualification
    [Table(nameof(UserQualification))]
    public class UserQualification : BaseProp
    {
        public int? UserId { get; set; }
        public User User { get; set; }

        public int? QualificationId { get; set; }
        public Qualification Qualification { get; set; }

    }
}
