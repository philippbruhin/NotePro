using NotePro.Models;
using NotePro.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace NotePro.Services
{
    public class NoteDataPreparation : INoteDataPreparation
    {
        public IEnumerable<Note> Filter(IEnumerable<Note> notes, FilterOption filterOption)
        {
            IEnumerable<Note> sortedNotes;
            switch (filterOption)
            {
                case FilterOption.NoFilter:
                    sortedNotes = notes;
                    break;
                default:
                    sortedNotes = notes.Where(x => x.Finished == false);
                    break;
            }
            return sortedNotes;
        }

        public IEnumerable<Note> Sort(IEnumerable<Note> notes, SortOption sortOption = SortOption.Recent) 
        {
            IEnumerable<Note> sortedNotes;
            switch (sortOption)
            {
                case SortOption.DueDate:
                    sortedNotes = notes.OrderBy(x => x.DueDate);
                    break;
                case SortOption.Importance:
                    sortedNotes = notes.OrderByDescending(x => x.Priority);
                    break;
                case SortOption.Oldest:
                    sortedNotes = notes.OrderBy(x => x.CreationDate);
                    break;
                default:
                    sortedNotes = notes.OrderByDescending(x => x.CreationDate);
                    break;
            }
            return sortedNotes;
        }
    }
}
