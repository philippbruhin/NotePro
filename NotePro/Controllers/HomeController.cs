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
        public async Task<IActionResult> EditNote(Guid uid)
        {
            return View("EditNote", await noteData.GetNoteAsync(uid));
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

        //[HttpPut]
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
        public async Task<ActionResult> DeleteNote(Guid uid)
        {
            if (uid == null)
            {
                return BadRequest();
            }
            await noteData.RemoveNoteAsync(uid);
            return RedirectToAction("Index"); 
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
