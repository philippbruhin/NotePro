using NotePro.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace NotePro.Services
{
    public interface INoteData
    {
        Task AddNoteAsync(Note note);

        Task<Note> GetNoteAsync(Guid uid);

        Task<IEnumerable<Note>> GetNotesAsync();

        Task RemoveNoteAsync(Guid uid);

        Task UpdateNoteAsync(Note note);
    }
}
