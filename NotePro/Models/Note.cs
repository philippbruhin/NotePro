using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace NotePro.Models
{
    public class Note
    {

        static int counter = 0;

        public int NoteId { get; private set; }

        public DateTime Creationdate { get; private set; }

        public Note()
        {
            NoteId = Interlocked.Increment(ref counter); ;
            Creationdate = DateTime.Now;
        }

        [Required(ErrorMessage = "Please enter a title for this task.")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description for this task.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$"), StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a priority for this task.")]
        public IEnumerable<Priority> Priority { get; set; }

        [Required(ErrorMessage = "Please enter a duedate for this task.")]
        [DataType(DataType.Date)]
        public DateTime Duedate { get; set; }


    }

}
