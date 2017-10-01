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
