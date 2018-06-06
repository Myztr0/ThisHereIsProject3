using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ThisHereIsProject3.Models
{
    public class GEModel
    {

        [Key]
        public int ID { get; set; }
        public string name { get; set; }

    }
}
