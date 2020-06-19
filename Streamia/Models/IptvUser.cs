using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class IptvUser
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public long Subscription { get; set; }

        [Required]
        public Bouquet Bouquet { get; set; }

    }
}
