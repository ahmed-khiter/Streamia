using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public class Setting : BaseEntity
    {
        [Display(
            Name = "Points Per Dollar",
            Description = "How many points to be added to reseller credit per dollar, EX: 50 points per $1"
        )]
        [Required]
        [Range(1, uint.MaxValue)]
        public uint PointsPerMoney { get; set; }

        [Required]
        [Range(1, uint.MaxValue)]
        [Display(
            Name = "Points Per Created User", 
            Description = "How many points to be charged from reseller credit for each user reseller creates, EX: 10 points per created user"
        )]
        public uint PointsPerCreatedUser { get; set; }
    }
}
