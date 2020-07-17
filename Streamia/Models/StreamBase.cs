using Streamia.Models.Enums;
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
        public string StreamKey { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Bouquets")]
        public List<int> BouquetIds { get; set; }

        public Category Category { get; set; }
        public StreamState State { get; set; } = StreamState.STOPPED;
    }
}
