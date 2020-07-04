using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Bouquet : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<BouquetSources> BouquetSources { get; set; }
    }
}
