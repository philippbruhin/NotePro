using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NotePro.Utilities
{
    public enum SortOption
    {
        [Display(Name = "Recent")]
        Recent,

        [Display(Name = "Oldest")]
        Oldest,

        [Display(Name = "Due Date")]
        DueDate,

        [Display(Name = "Importance")]
        Importance
    };
}
