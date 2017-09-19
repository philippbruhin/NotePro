using NotePro.Models;
using NotePro.Utilities;
using System.Collections.Generic;


namespace NotePro.Services
{
    public interface INoteDataPreparation
    {
        IEnumerable<Note> Sort(IEnumerable<Note> notes, SortOption sortOption);

        IEnumerable<Note> Filter(IEnumerable<Note> notes, FilterOption filterOption);

    }
}
