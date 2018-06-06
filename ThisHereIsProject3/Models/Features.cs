using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ThisHereIsProject3.Models
{
    public class Features
    {

        [Key]
        public int ID { get; set; }
        public string PLanguage { get; set; }
        public Boolean CrossPlatform { get; set; }
        public string License { get; set; }

    }
}
