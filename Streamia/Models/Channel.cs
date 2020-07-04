using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Channel : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Path { get; set; }
        public string Logo { get; set; }
        public string Note { get; set; }
        public bool StartChannel { get; set; } = false;
        public Category Category { get; set; }
    }
}
