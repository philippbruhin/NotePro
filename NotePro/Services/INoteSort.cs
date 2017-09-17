using NotePro.Models;
using NotePro.Utilities;
using System.Collections.Generic;


namespace NotePro.Services
{
    public interface INoteSort
    {
        IEnumerable<Note> Sort(IEnumerable<Note> notes, SortOption sortOption);

    }
}
