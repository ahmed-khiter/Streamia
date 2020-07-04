using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Series : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
