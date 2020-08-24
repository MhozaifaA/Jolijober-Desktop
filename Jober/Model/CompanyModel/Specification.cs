using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;
using Jober.Model.PostModel;
using Jober.Model.UserModel;

namespace Jober.Model.CompanyModel
{
    [Table(nameof(Specification))]
    public  class Specification:BaseProp
    {
        [Required]
        public string Name { get; set; }

        public ICollection<CompanySpecification> CompanySpecifications { get; set; }

       

        public  ICollection<ApplyPost>  ApplyPosts {get;set;}
    }
}
