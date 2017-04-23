using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Finder.Models
{
    public class CompanyRating
    {
        [Key, ForeignKey("CompanyInfo")]
        public int Id { get; set; }

        public double Salary { get; set; }

        public double Stress { get; set; }

        public double Benefit { get; set; }

        public double Opportunity { get; set; }

        public double Respect { get; set; }

        public CompanyInfo CompanyInfo { get; set; }
    }
}
