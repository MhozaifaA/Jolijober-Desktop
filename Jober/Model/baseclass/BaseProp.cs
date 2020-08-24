using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jober.Model.baseclass
{
   public  class BaseProp
    {
       
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
