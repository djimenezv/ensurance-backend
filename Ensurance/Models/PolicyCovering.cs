using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ensurance.Models
{
    public class PolicyCovering
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int ID { get; set; }

        //[ForeignKey("PolicyNmber"), Column(Order = 0)]
        //[Key, Column(Order = 0)]
        public Policy Policy { get; set; }

        //[ForeignKey("Covering"), Column(Order = 1)]
        //[Key, Column(Order = 1)]
        public Covering Cover { get; set; }

        public int CoveringID { get; set; }
        public int PolicyNumber { get; set; }


        public double CoveragePercentage { get; set; }

    }

}
