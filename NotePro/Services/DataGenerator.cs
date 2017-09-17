using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotePro.Models;
using NotePro.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace NotePro.Services
{
    public class DataGenerator
    {
        
        public void createSampleData(DbContextDefault dbContext)
        {
            INoteData noteData = new NoteData(dbContext);

            Note note = new Note
            {
                Title = "Call my mummy",
                Description = "It's her birthday",
                DueDate = DateTime.Parse("25.11.2017"),
                Priority = 5
            };

            noteData.AddNoteAsync(note);

            note = new Note
            {
                Title = "Buy a new shampoo for Gianna",
                Description = "Panthene Pro V",
                DueDate = DateTime.Now.AddDays(7),
                Priority = 2,
                Finished = false
            };
            noteData.AddNoteAsync(note);

            note = new Note
            {
                Title = "Hand in Internet Technologies Advanced Notes Pro",
                Description = "Make sure that it works",
                DueDate = DateTime.Parse("08.10.2017"),
                Priority = 4,
                Finished = false
            };
            noteData.AddNoteAsync(note);

            note = new Note
            {
                Title = "Organize VAT for new company",
                Description = "Call according administrative authority in Zug.",
                DueDate = DateTime.Parse("30.09.2017"),
                Priority = 3,
                Finished = false
            };
            noteData.AddNoteAsync(note);

            note = new Note
            {
                Title = "Talk to Indian Design Company for Business Card Design.",
                Description = "Option 3 seems suitable",
                DueDate = DateTime.Parse("30.09.2017"),
                Priority = 3,
                Finished = true
            };
            noteData.AddNoteAsync(note);

            note = new Note
            {
                Title = "Buy milk",
                Description = "No soy milk.",
                DueDate = DateTime.Now.AddDays(-1),
                Priority = 1,
                Finished = false
            };
            noteData.AddNoteAsync(note);


        }
    }
}
