using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;

namespace Jober.Model.CompanyModel
{
    [Table(nameof(Contract))]
    public class Contract:BaseProp
    {
        //password

        public string Note { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd{ get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
