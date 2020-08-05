using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class BouquetMovie : BaseEntity
    {
        public uint BouquetId { get; set; }
        public uint MovieId { get; set; }
        public Bouquet Bouquet { get; set; }
        public Movie Movie { get; set; }
    }
}
