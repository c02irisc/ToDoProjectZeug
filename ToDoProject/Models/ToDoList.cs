using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    public class ToDoList
    {
        public int ToDoListID { get; set; }
        public String Name { get; set; }
        public String Bild { get; set; }
        public virtual ICollection<Aufgabe> Aufgaben { get; set; }


    }
}
