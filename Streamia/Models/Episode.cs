using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Episode : TMDBResult
    {
        [NotMapped]
        public override string StreamKey { get; set; }

        [NotMapped]
        public override int CategoryId { get; set; }

        [NotMapped]
        public override List<int> BouquetIds { get; set; }

        [NotMapped]
        public override Category Category { get; set; }

        [NotMapped]
        public override StreamState State { get; set; }

        [NotMapped]
        public override string Cast { get; set; }

        [NotMapped]
        public override string Gener { get; set; }

        [NotMapped]
        public override int Runtime { get; set; }

        public int SeriesId { get; set; }
        public int Number { get; set; }
        public int Season { get; set; }
        public string Source { get; set; }
        public Series Series { get; set; }
    }
}
