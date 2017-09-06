using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotePro.Models
{
    public class Repository
    {

        private static List<Note> notes = new List<Note>();
        public static IEnumerable<Note> Notes
        {
            get
            {
                return notes;
            }
        }
        public static void AddResponse(Note note)
        {
            notes.Add(note);
        }
    }
}
