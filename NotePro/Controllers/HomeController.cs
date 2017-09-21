using Microsoft.AspNetCore.Mvc;
using NotePro.Models;
using NotePro.Services;
using NotePro.Utilities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NotePro.Controllers
{
    public class HomeController : Controller
    {

        private readonly INoteData noteData;
        private readonly INoteDataPreparation NoteDataPreparation;

        public HomeController(INoteData noteData, INoteDataPreparation NoteDataPreparation)
        {
            this.noteData = noteData ?? throw new ArgumentNullException(nameof(noteData));
            this.NoteDataPreparation = NoteDataPreparation ?? throw new ArgumentNullException(nameof(NoteDataPreparation));
        }

        public async Task<IActionResult> Index(int SortOptionIndex, int FilterOptionIndex)
        {
            var notes = await noteData.GetNotesAsync();
            var sortOption = (SortOption) SortOptionIndex;
            var filterOption = (FilterOption)FilterOptionIndex;
            notes = NoteDataPreparation.Sort(notes, sortOption);
            notes = NoteDataPreparation.Filter(notes, filterOption);

            return View("NotesList", new NotesListViewModel
            {
                Notes = notes,
                SortOption = sortOption,
                FilterOption = filterOption
            });
        }

        public IActionResult NewNote()
        {
            return View("Note");
        }

        [HttpGet]
        public async Task<IActionResult> EditNote(long id)
        {       
            var note = await noteData.GetNoteAsync(id);

            if (note == null)
            {
                return BadRequest();
            }

            return View("Note", note);
        }

        [HttpPost]
        public async Task<ActionResult> AddNote(Note note)
        {
            if (ModelState.IsValid)
            {
                await noteData.AddNoteAsync(note);
                return RedirectToAction("Index"); 
            }
            else
            {
                return View("Note");
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateNote(Note note)
        {
            if (ModelState.IsValid)
            {
                await noteData.UpdateNoteAsync(note);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Note");
            }
        }

        [HttpGet] 
        public async Task<ActionResult> DeleteNote(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await noteData.RemoveNoteAsync(id);

            return RedirectToAction("Index"); 
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
