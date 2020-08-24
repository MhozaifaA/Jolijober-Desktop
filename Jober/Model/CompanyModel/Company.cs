using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.baseclass;
using Jober.Model.MutualModel;
using Jober.Model.PostModel;
using Jober.Model.UserModel;


namespace Jober.Model.CompanyModel
{
    [Table("Company")]
    public class Company:BaseProp
    {
      
           
        [Required]
        public string Name { get; set; }

        [DataType(dataType:DataType.Url)]
        public string Mail { get; set; }
       // public Uri Mail { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

       
        public string Description { get; set; }

        
       
    
        public int? FieldId { get; set; }
        public  Field Field { get; set; }
       
      
  
            
        public ICollection<CompanyArea> CompanyAreas { get; set; }
        
        public ICollection<CompanySpecification> CompanySpecifications { get; set; }

        public ICollection<Contract> Contracts { get; set; }
       
        public ICollection<ReactApplyPostCompany> ReactApplyPostCompanies { get; set; }


    }
}
