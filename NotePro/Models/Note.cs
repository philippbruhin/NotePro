﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NotePro.Models
{
    public class Note
    {

        public Guid NoteId { get; private set; }

        public DateTime CreationDate { get; private set; }

        [Required(ErrorMessage = "Please enter a title for this note.")]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description for this note.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$"), StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a priority for this note.")]
        //[Range(1,5)] @todo: does not work yet
        public int Priority { get; set; }

        [Required(ErrorMessage = "Please enter a due date for this note.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Please specify if task is finished or not.")]
        public bool? Finished { get; set; }

        public Note()
        {
            NoteId = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

    }
}
