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
        public uint SeriesId { get; set; }
        public uint Number { get; set; }
        public uint Season { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string Director { get; set; }
        public string ReleaseDate { get; set; }
        public float Rating { get; set; }
        public Series Series { get; set; }
    }
}
