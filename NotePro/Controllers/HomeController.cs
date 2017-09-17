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
        private readonly INoteSort noteSort;

        public HomeController(INoteData noteData, INoteSort noteSort)
        {
            this.noteData = noteData ?? throw new ArgumentNullException(nameof(noteData));
            this.noteSort = noteSort ?? throw new ArgumentNullException(nameof(noteSort));
        }

        public async Task<IActionResult> Index(int SortOptionIndex, int DisplayOptionIndex)
        {
            var notes = await noteData.GetNotesAsync();
            var sortOption = (SortOption) SortOptionIndex;
            var displayOption = (DisplayOption)DisplayOptionIndex;
            return View("NotesList", new NotesListViewModel
            {
                Notes = noteSort.Sort(notes, sortOption),
                SortOption = sortOption
            });
        }

        public IActionResult NewNote()
        {
            return View("Note");
        }

        [HttpGet]
        public async Task<IActionResult> EditNote(long id)
        {
            return View("Note", await noteData.GetNoteAsync(id));
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

        [HttpGet] //todo only hack, potential security hole
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
