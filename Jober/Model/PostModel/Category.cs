using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;

namespace Jober.Model.PostModel
{
    [Table(nameof(Category))]
    public class Category:BaseProp
    {
        [Required]
        public string Name { get; set; }

        public ICollection<JobPostCategory> JobPostCategories { get; set; }


    }
}
