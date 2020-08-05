﻿using Streamia.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class StreamBase : BaseEntity
    {
        public virtual string StreamKey { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Range(1, uint.MaxValue, ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public virtual uint CategoryId { get; set; }

        [Display(Name = "Transcode")]
        public virtual uint? TranscodeId { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Bouquets")]
        public virtual List<uint> BouquetIds { get; set; }
        public DateTime Uptime { get; set; } = DateTime.Now;
        public virtual Category Category { get; set; }
        public virtual Transcode Transcode { get; set; }
        public virtual StreamState State { get; set; }
    }
}
