using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Jober.Model.CommandModel
{
    [Table("Command")]
  public  class Command
    {
        public int Id { get; set; }

        public String Description { get; set; }

        [Required]
        public String Query { get; set; }

        public bool IsDeleted { get; set; }
    }
}
