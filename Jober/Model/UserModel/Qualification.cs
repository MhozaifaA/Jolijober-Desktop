using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;

namespace Jober.Model.UserModel
{
    [Table(nameof(Qualification))]
    public class Qualification : BaseProp
    {
        [Required]
        public string Name { get; set; }

        public ICollection<UserQualification> UserQualifications { get; set; }
    }
}
