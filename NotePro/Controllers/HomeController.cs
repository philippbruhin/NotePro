using Microsoft.AspNetCore.Mvc;
using NotePro.Models;
using NotePro.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NotePro.Controllers
{
    public class HomeController : Controller
    {

        private readonly INoteData noteData;

        public HomeController(INoteData _noteData)
        {
            noteData = _noteData ?? throw new ArgumentNullException(nameof(_noteData));
        }

        public async Task<IActionResult> Index()
        {
            return View("NotesList", await noteData.GetNotesAsync());
        }

        public IActionResult NewNote()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditNote(long id)
        {
            return View("EditNote", await noteData.GetNoteAsync(id));
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
                return View("NewNote");
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
                return View("EditNote");
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
