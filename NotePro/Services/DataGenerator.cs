using NotePro.DataStorage;
using NotePro.Models;
using System;

namespace NotePro.Services
{
    public class DataGenerator
    {
        
        public void CreateSampleData(DbContextDefault dbContext)
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
                DueDate = DateTime.Now.AddDays(2),
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
                DueDate = DateTime.Parse("30.12.2017"),
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

            note = new Note
            {
                Title = "Spaghetti",
                Description = "Buy spaghetti at Migros.",
                DueDate = DateTime.Now.AddDays(2),
                Priority = 1,
                Finished = false
            };
            noteData.AddNoteAsync(note);

            note = new Note
            {
                Title = "10 vor 10",
                Description = "Watch on SRF1 regarding Korea Conflict.",
                DueDate = DateTime.Now,
                Priority = 1,
                Finished = false
            };
            noteData.AddNoteAsync(note);

            note = new Note
            {
                Title = "Blabla",
                Description = "Blablabla",
                DueDate = DateTime.Now.AddDays(+8),
                Priority = 1,
                Finished = false
            };
            noteData.AddNoteAsync(note);

            note = new Note
            {
                Title = "Buy beer",
                Description = "For weekend. Quöllfrisch only!",
                DueDate = DateTime.Now.AddDays(+1),
                Priority = 1,
                Finished = false
            };
            noteData.AddNoteAsync(note);

            note = new Note
            {
                Title = "Test 999 characters",
                Description = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu.",
                DueDate = DateTime.Now.AddDays(+100),
                Priority = 1,
                Finished = false
            };
            noteData.AddNoteAsync(note);

        }
    }
}
