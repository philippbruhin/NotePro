using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NotePro.Controllers;
using NotePro.DataStorage;
using NotePro.Models;
using NotePro.Services;
using NotePro.Tests.Controllers;
using System;
using System.Net;
using Xunit;


namespace XUnitTestNotePro
{
    public class HomeControllerTest
    {

        private readonly FakeHttpContextAccessor _fakeHttpContextAccessor;


        public HomeControllerTest()
        {
            _fakeHttpContextAccessor = new FakeHttpContextAccessor();
        }

        [Fact]
        public async void ShouldReturn404DueToMissingNote()
        {
            var services = new ServiceCollection();

            services.AddDbContext<DbContextDefault>(options => options.UseInMemoryDatabase("NoteDatabase"));

            var serviceProvider = services.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<DbContextDefault>();
            var noteData = new NoteData(dbContext);
            var noteDataPreparation = new NoteDataPreparation();
            var controller = new HomeController(noteData, noteDataPreparation, _fakeHttpContextAccessor);
            var result =  (StatusCodeResult) await controller.EditNote(-1);

            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async void ShouldUpdateANoteSuccessfully()
        {
            var services = new ServiceCollection();

            services.AddDbContext<DbContextDefault>(options => options.UseInMemoryDatabase("NoteDatabase"));

            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetService<DbContextDefault>();

            var noteData = new NoteData(dbContext);
            var noteDataPreparation = new NoteDataPreparation();
            var controller = new HomeController(noteData, noteDataPreparation, _fakeHttpContextAccessor);

            var note = new Note
            {
                Title = "This is updatable",
                Description = "Make sure it is actually updateable. Otherwise this woulud be a pitty",
                DueDate = DateTime.Parse("30.09.2017"),
                Priority = 3,
                Finished = false
            };

            // Add new note to database
            await noteData.AddNoteAsync(note);
            
            // Get Note from Database again and amend due date
            var dueDate= DateTime.Parse("31.10.2017"); 
            note = await noteData.GetNoteAsync(note.Id);
            note.DueDate = DateTime.Parse("31.10.2017");

            // Update Database with amended Due Date
            await controller.UpdateNote(note);

            // Get Note with updated Due Date from Database;
            var result = await noteData.GetNoteAsync(note.Id);

            Assert.Equal(result, note);
        }

    }
}
