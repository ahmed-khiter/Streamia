using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Series
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }     

        [Required]
        public List<Server> Servers { get; set; }

        public List<BouquetSource> BouquetSources { get; set; }
    }
}
