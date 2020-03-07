using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Models;

namespace ToDoProject.ViewModels
{
    class NeueListeViewModel
    {
        public ToDoList neueListe { get; set; }
        public NeueListeViewModel()
        {
            Console.WriteLine("Reached neue Liste");
            Console.WriteLine(neueListe.Name);

        }


        ToDoListContext ctx = new ToDoListContext();

        internal void AddListe(ToDoList erstellteListe)
        {
      
        }
    }
}
