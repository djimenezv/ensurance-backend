using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ensurance.Models
{
    public class Client
    {

        [Key]
        public int Identification { get; set; }

        public string Name { get; set; }
    }
}
