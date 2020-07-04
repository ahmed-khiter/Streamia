using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class BouquetSources
    {
        public int BouquetId { get; set; }
        public int SourceId { get; set; }
        public SourceType SourceType { get; set; }
        public Bouquet Bouquet { get; set; }
    }
}
