using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jober.Model.CompanyModel;
using Jober.Model.MutualModel;
using Jober.Model.PostModel;

namespace Jober.ViewModel.VMJobPost
{
    public class ViewModelJobPost
    {

        public int JobPostId { get; set; }

        public DateTime Date { get; set; }

        public int NumReact { get; set; }

        public string Age { get; set; }

        public string WorkHour { get; set; }

        public double Salary { get; set; }

        public string Skills { get; set; }

        public string More { get; set; }


        public virtual Specification Specification { get; set; }

        public virtual Company Company { get; set; }

        public virtual Field Field { get; set; }


        public ICollection<Category> Categories { get; set; }

        public ICollection<JobPostAreaNum> JobPostAreaNums { get; set; }


    }
}
