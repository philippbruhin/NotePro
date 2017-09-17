using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotePro.Utilities;
using NotePro.Models;

namespace NotePro.Services
{
    public class NoteSort : INoteSort
    {
        public IEnumerable<Note> Sort(IEnumerable<Note> notes, SortOption sortOption = SortOption.Recent) 
        {
            switch (sortOption)
            {
                case SortOption.DueDate:
                    notes = notes.OrderByDescending(x => x.DueDate);
                    break;
                case SortOption.Importance:
                    notes = notes.OrderByDescending(x => x.Priority);
                    break;
                case SortOption.Oldest:
                    notes = notes.OrderBy(x => x.CreationDate);
                    break;
                default:
                    notes = notes.OrderByDescending(x => x.CreationDate);
                    break;
            }
            return notes;
        }
    }
}
