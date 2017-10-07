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

        private readonly FakeHttpContextAccessor fakeHttpContextAccessor;

        private readonly IServiceProvider serviceProvider;
        private readonly DbContextDefault dbContext;
        private readonly NoteData noteData;
        private readonly NoteDataPreparation noteDataPreparation;
        private readonly ServiceCollection services;

        public HomeControllerTest()
        {
            fakeHttpContextAccessor = new FakeHttpContextAccessor();

            services = new ServiceCollection();
            services.AddDbContext<DbContextDefault>(options => options.UseInMemoryDatabase("NoteDatabase"));
            serviceProvider = services.BuildServiceProvider();
            dbContext = serviceProvider.GetService<DbContextDefault>();
            noteData = new NoteData(dbContext);
            noteDataPreparation = new NoteDataPreparation();
        }

        [Fact]
        public async void ShouldReturn404DueToMissingNote()
        {
            // Arrange
            var controller = new HomeController(noteData, noteDataPreparation, fakeHttpContextAccessor);

            // Act
            var result =  (StatusCodeResult) await controller.EditNote(-1);

            // Assert
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async void ShouldUpdateANoteSuccessfully()
        {
            // Arrange
            var controller = new HomeController(noteData, noteDataPreparation, fakeHttpContextAccessor);

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

            // Act
            // Update Database with amended Due Date
            await controller.UpdateNote(note);

            // Get Note with updated Due Date from Database;
            var result = await noteData.GetNoteAsync(note.Id);

            // Assert
            Assert.Equal(result, note);
        }

    }
}
