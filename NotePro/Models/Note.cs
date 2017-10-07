using System;
using System.ComponentModel.DataAnnotations;

namespace NotePro.Models
{
    public class Note
    {
        public long Id { get;  set; }

        [Display(Name ="Creation Date")]
        public DateTime CreationDate { get; private set; }

        [Required(ErrorMessage = "Please enter a title for this note.")]
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z0-9äöüÄÖÜß!?'-_\s]*$")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description for this note.")]
        [RegularExpression(@"^[a-zA-Z0-9äöüÄÖÜß!?'-_\s]*$"), StringLength(1000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a priority for this note.")]
        [Range(1,5)]

        [Display(Name = "Importance")]
        public int Priority { get; set; }

        [Display(Name = "Due Date")]
        [Required(ErrorMessage = "Please enter a due date for this note.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public bool Finished { get; set; }

        public Note()
        {
                CreationDate = DateTime.Now;
        }

    }
}
