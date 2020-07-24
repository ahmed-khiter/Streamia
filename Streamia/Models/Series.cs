using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Series : TMDBResult
    {
        public ICollection<BouquetSeries> BouquetSeries { get; set; }
        public ICollection<SeriesServer> SeriesServers { get; set; }
        public ICollection<Episode> Episodes { get; set; }

        [NotMapped]
        public override int Runtime { get; set; }

        [NotMapped]
        public override string Director { get; set; }

        public Series()
        {
            BouquetSeries = new List<BouquetSeries>();
            SeriesServers = new List<SeriesServer>();
            Episodes = new List<Episode>();
        }
    }
}
