using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Setting:BaseEntity
    {
        [Display(Name ="User Value")]
        public int UserValue { get; set; }

        [Display(Name ="Unit Point")]
        public int UnitPoint { get; set; }

        public decimal Price { get; set; }

        public string SetAccountKey { get; set; }

        public string AdminUserId { get; set; }

        public AppUser AdminUser { get; set; }

    }
}
