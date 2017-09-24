﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NotePro.Utilities
{
    public enum FilterOption
    {
        [Display(Name = "Hide Finished")]
        ExcludeFinished,

        [Display(Name = "Show Finished")]
        NoFilter
    };
}
