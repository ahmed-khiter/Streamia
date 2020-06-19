using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class BouquetSource
    {
        [Key]
        public int Id { get; set; }
        public int BouquetId { get; set; }
        public int StreamId { get; set; }
        public int ChannelId { get; set; }
        public int SeriesId { get; set; }
        public int MovieId { get; set; }
        public Bouquet Bouquet { get; set; }
        public Stream Stream { get; set; }
        public Channel Channel { get; set; }
        public Movie Movie { get; set; }
        public Series Series { get; set; }

    }
}
