using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Models
{
    public class Country
    {
        [Display(Name = "Nazwa:")]
        public string Name { get; set; }

        [Display(Name = "Stolica:")]
        public string Capital { get; set; }

        [Display(Name = "Populacja:")]
        public int Population { get; set; }        
    }
}
