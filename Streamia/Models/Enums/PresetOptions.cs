using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Models.Enums
{
    public enum PresetOptions
    {
        [Display(Name = "Very Slow")]
        VerySlow,
        Slower,
        Slow,
        Medium,
        Fast,
        Faster,
        [Display(Name = "Very Fast")]
        VeryFast,
        [Display(Name = "Super Fast")]
        SuperFast,
        [Display(Name = "Ultra Fast")]
        UltraFast,
        Placebo
    }
}
