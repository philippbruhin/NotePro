using Microsoft.AspNetCore.Mvc;
using NotePro.Models;
using NotePro.Services;
using NotePro.Utilities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NotePro.DataStorage;
using Microsoft.AspNetCore.Http;

namespace NotePro.Controllers
{
    public class HomeController : Controller
    {

        private readonly INoteData noteData;
        private readonly INoteDataPreparation NoteDataPreparation;
        private readonly ApplicationSession _session;

        public HomeController(INoteData noteData, INoteDataPreparation NoteDataPreparation, IHttpContextAccessor httpContextAccessor)
        {
            this.noteData = noteData ?? throw new ArgumentNullException(nameof(noteData));
            this.NoteDataPreparation = NoteDataPreparation ?? throw new ArgumentNullException(nameof(NoteDataPreparation));
            this._session = new ApplicationSession(httpContextAccessor.HttpContext.Session);
        }

        public async Task<IActionResult> Index(int SortOptionIndex, int FilterOptionIndex)
        {

            var notes = await noteData.GetNotesAsync();
            var sortOption = (SortOption) SortOptionIndex;
            var filterOption = (FilterOption)FilterOptionIndex;

            notes = NoteDataPreparation.Filter(notes, filterOption);
            notes = NoteDataPreparation.Sort(notes, sortOption);

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
                return NotFound();
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
        public async Task<ActionResult> DeleteNote(long id, int SortOptionIndex, int FilterOptionIndex)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await noteData.RemoveNoteAsync(id);

            return RedirectToAction("Index", new { SortOptionIndex = SortOptionIndex, FilterOptionIndex = FilterOptionIndex }); 
        }

        public IActionResult ToggleLayout(int SortOptionIndex, int FilterOptionIndex)
        {
            _session.DefaultLayout = !_session.DefaultLayout;
            return RedirectToAction("Index", new { SortOptionIndex = SortOptionIndex, FilterOptionIndex = FilterOptionIndex });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
