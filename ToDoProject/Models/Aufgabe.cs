using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    public class Aufgabe
    {
        public int AufgabeID { get; set; }
        public String Topic { get; set; }
        public String Inhalt { get; set; }
        public Boolean Done { get; set; }
        public int Prio { get; set; }
        public String Category { get; set; }

        public virtual ToDoList ParentToDoList { get; set; }
    }
}
