using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ensurance.Models
{

    public enum PolicyRiskType
    {
        Low,
        Medium,
        MediumHigh,
        High
    }

    public class Policy
    {
        public Policy()
        {
            //this.CoveringPolicy = new HashSet<PolicyCovering>();
        }

        [Key]
        public int PolicyNumber { get; set; }
        public string Description { get; set; }

        public string Name { get; set; }

        public DateTime StartingDate { get; set; }

        public int CoveragePeriod { get; set; }

        public long Price { get; set; }

        public String RiskType { get; set; }
        public ICollection<PolicyCovering> CoveringPolicy { get; set; }
    }
}
