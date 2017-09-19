using System.Collections.Generic;
using NotePro.Utilities;

namespace NotePro.Models
{
    public class NotesListViewModel
    {
        public SortOption SortOption { get; set; }

        public FilterOption FilterOption { get; set; }

        public IEnumerable<Note> Notes { get; set; }


    }
}
