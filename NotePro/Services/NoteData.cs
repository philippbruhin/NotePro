using Microsoft.EntityFrameworkCore;
using NotePro.DataStorage;
using NotePro.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotePro.Services
{
    public class NoteData : INoteData
    {
        private readonly DbContextDefault dbContext;

        public NoteData(DbContextDefault _dbContext)
        {
            dbContext = _dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task AddNoteAsync(Note note)
        {
            await dbContext.AddAsync(note);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Note> GetNoteAsync(long id)
        {
            return await dbContext.Notes.FindAsync(id);
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await dbContext.Notes.ToListAsync();
        }

        public async Task RemoveNoteAsync(long id)
        {
            var note = await GetNoteAsync(id);
            dbContext.Remove(note);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateNoteAsync(Note note)
        {
            dbContext.Update(note);
            await dbContext.SaveChangesAsync();
        }
    }
}
