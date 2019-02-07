using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ensurance.Models
{
    public class ClientPolicy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("Identification")]
        public Client Client { get; set; }

        [ForeignKey("PolicyId")]
        public Policy Policy { get; set; }

    }
}
