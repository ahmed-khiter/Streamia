using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Episode : BaseEntity
    {
        public int SeriesId { get; set; }
        public int Number { get; set; }
        public int Season { get; set; }
        public string Source { get; set; }
        public Series Series { get; set; }
    }
}
