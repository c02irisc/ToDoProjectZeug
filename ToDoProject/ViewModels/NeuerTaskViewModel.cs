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
        public String SelectedCategory { get; set; }
        public Aufgabe Aufgabe { get; set; }
        public ToDoList ToDoList { get; set; }
        public NeuerTaskViewModel()
        {
            Aufgabe = new Aufgabe()
            {
                Topic = "",
                Prio = 0,
                Category = "Keine",
            };

            ComboBoxKategorie = new List<string>() {
                "Keine",
                "Einkaufen",
                "Erinnerung",
                "Haushalt",
                "Idee",
                "Kontaktaufnahme",
                "Sport",
                "Termin",
                "Keine"
            };
        }

    }

}
