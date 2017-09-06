using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotePro.Models;

namespace NotePro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewNote()
        {
            return View();
        }


        [HttpGet]
        public ViewResult NoteForm()
        {
            return View("NewNote");
        }

        [HttpPost]
        public ViewResult NoteForm(Note note)
        {
            if (ModelState.IsValid)
            {
                Repository.AddNote(note);
                return View("index", note);
            }
            else
            {
                // there is a validation error
                return View("NewNote");
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Können wir von mir aus drin lassen und etwas über uns schreiben.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
