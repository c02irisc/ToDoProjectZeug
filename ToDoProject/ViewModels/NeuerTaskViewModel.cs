using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Models;

namespace ToDoProject.ViewModels
{

    class NeuerTaskViewModel
    {

        AufgabeContext ctx = new AufgabeContext();
        public List<string> ComboBoxKategorie { get; set; }
        public Aufgabe Aufgabe { get; set; }
        public ToDoList ToDoList { get; set; }
        public NeuerTaskViewModel()
        {
            Aufgabe = new Aufgabe()
            {
                Topic = "Aufgabe",
                Prio = 0,
                Category = "none"
            };
      
            ComboBoxKategorie = new List<string>() {
                "Arbeit",
                "Zuhause",
                "Sport",
                "Freizeit"
            };
        }

        internal void AddAufgabe(Aufgabe erstellteAufgabe)
        {
            ctx.Aufgaben.Add(erstellteAufgabe);
           
            ctx.SaveChanges();

        }

    }

}
