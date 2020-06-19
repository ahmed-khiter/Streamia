using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Channel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Path { get; set; }
        public Category Category { get; set; }
        public string Logo { get; set; }
        public string Note { get; set; }
        public bool StartChannel { get; set; } = false;
        [Required]
        public List<Server> Servers { get; set; }

        public List<BouquetSource> BouquetSources { get; set; }
    }
}
