using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models
{
    public enum CategoryType
    {
        LIVE,
        MOVIE,
        SERIES
    }

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Type")]
        public CategoryType CategoryType { get; set; }

        [Required]
        public string Name { get; set; }

        //public int CategoryTypeId { get; set; } = 0;

    }
}
