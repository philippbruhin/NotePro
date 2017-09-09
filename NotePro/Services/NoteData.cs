using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotePro.Models;
using NotePro.DataStorage;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Note> GetNoteAsync(Guid uid)
        {
            return await dbContext.Notes.FindAsync(uid);
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await dbContext.Notes.ToListAsync();
        }

        public async Task RemoveNoteAsync(Guid uid)
        {
            var note = await GetNoteAsync(uid);
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
