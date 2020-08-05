using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class BouquetSeries : BaseEntity
    {
        public uint BouquetId { get; set; }
        public uint SeriesId { get; set; }
        public Bouquet Bouquet { get; set; }
        public Series Movie { get; set; }
    }
}
