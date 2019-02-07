using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ensurance.Models
{
    public class Covering
    {
        public Covering()
        {
            //this.Policies = new HashSet<PolicyCovering>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Description { get; set; }
        public ICollection<PolicyCovering> CoveringPolicy { get; set; }

    }
}
