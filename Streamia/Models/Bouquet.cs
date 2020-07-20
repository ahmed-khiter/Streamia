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
        public ICollection<BouquetStream> BouquetStreams { get; set; }
        public ICollection<BouquetMovie> BouquetMovies { get; set; }
        public ICollection<BouquetSeries> BouquetSeries { get; set; }
    }
}
