using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Jober.Model.baseclass;

namespace Jober.Model.CompanyModel
{
    [Table(nameof(Field))]
    public class Field : BaseProp
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Company> Companies { get; set; }

    }
}
