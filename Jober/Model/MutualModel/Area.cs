using System;
using System.Collections.Generic;
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
    [Table(nameof(Area))]
    public class Area:BaseProp
    {
        [Required]
        public string Name { get; set; }

        public ICollection<CompanyArea> CompanyAreas { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
