using Streamia.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class IptvUser : BaseEntity
    {
        [Required]
        [UsernameUnique]
        public string Username { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public long Subscription { get; set; }

        public string Notes { get; set; }

        [Required]
        [Display(Name = "Bouqet")]
        public int BouquetId { get; set; }

        public Bouquet Bouquet { get; set; }
    }
}
