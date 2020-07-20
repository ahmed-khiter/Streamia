using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Series : TMDBResult
    {
        public string Source { get; set; }

        public ICollection<BouquetSeries> BouquetSeries { get; set; }
        public ICollection<SeriesServer> SeriesServers { get; set; }

        public Series()
        {
            BouquetSeries = new List<BouquetSeries>();
            SeriesServers = new List<SeriesServer>();
        }
    }
}
