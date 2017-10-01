using NotePro.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NotePro.Services
{
    public interface INoteData
    {
        Task AddNoteAsync(Note note);

        Task<Note> GetNoteAsync(long id);

        Task<IEnumerable<Note>> GetNotesAsync();

        Task RemoveNoteAsync(long id);

        Task UpdateNoteAsync(Note note);
    }
}
