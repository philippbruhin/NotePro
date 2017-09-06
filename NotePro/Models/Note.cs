using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

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
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description for this task.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a priority for this task.")]
        public string Priority { get; set; }

        [Required(ErrorMessage = "Please enter a duedate for this task.")]
        public DateTime Duedate { get; set; }


    }

}
