using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Models;

namespace ToDoProject.ViewModels
{
    class MainWindowViewModel
    {
        ToDoListContext ctx = new ToDoListContext();

        public ObservableCollection<ToDoList> AllToDoLists { get; set; }
        public ObservableCollection<Aufgabe> AllAufgaben { get; set; }

        public ToDoList SelectedToDoList { get; set; }

        public String SelectedImage { get; set; }
 

        public void AddNewToDoList(ToDoList list)
        {
            ctx.ToDoListen.Add(list);
            ctx.SaveChanges();
        }

        public void RemoveToDoList(ToDoList list)
        {
            /*
             * How to delete the N-Part of the DB
            foreach(Aufgabe aufgabe in list.Aufgaben)
            {
                RemoveAufgabe(aufgabe);
            }
            */
            ctx.ToDoListen.Remove(list);
            ctx.SaveChanges();
        }
    
        public void AddAufgabe(Aufgabe erstellteAufgabe)
        {
            ctx.Aufgaben.Add(erstellteAufgabe);
            ctx.SaveChanges();
        }

        public void RemoveAufgabe(Aufgabe erstellteAufgabe)
        {
            ctx.Aufgaben.Remove(erstellteAufgabe);
            ctx.SaveChanges();
        }

        public void Update()
        {
            ctx.SaveChanges();
        }
        internal void FillData()
        {
            AllToDoLists = new ObservableCollection<ToDoList>();
            foreach (var item in ctx.ToDoListen)
            {
                AllToDoLists.Add(item);
            }

            AllAufgaben = new ObservableCollection<Aufgabe>();
            foreach (var item in ctx.Aufgaben.Include("ParentToDoList"))
            {
                AllAufgaben.Add(item);
            }
        }

        public void CreateSamples()
        {
            // 1 - Verbindung
            ToDoList Aufgabenliste = new ToDoList()
            {
                Name = "Test Aufgabenliste",
                Bild = "Pics/test.png"
            };

            // Aufgabenliste speichern
            ctx.ToDoListen.Add(Aufgabenliste);
            ctx.SaveChanges();

            // N - Verbindung
            // Variante 1: Verbindung herstellen 1:N -> Foreign Key 
            Aufgabe ErsteAufgabe = new Aufgabe()
            {
                Topic = "Test Aufgabe 1",
                Inhalt = "Test Inhalt 1 ",
                Done = false,
                Prio = 1,
                Category = "Test Kategorie 1",
            };

            Aufgabenliste.Aufgaben = new List<Aufgabe>();
            Aufgabenliste.Aufgaben.Add(ErsteAufgabe);
            ctx.Aufgaben.Add(ErsteAufgabe);

            // Variante 2 durch direkte Verknüpfung durch ParentToDoList
            Aufgabe ZweiteAufgabe = new Aufgabe()
            {
                Topic = "Test Aufgabe 2",
                Inhalt = "Test Inhalt 2",
                Done = false,
                Prio = 1,
                Category = "Test Kategorie 2",
                ParentToDoList = Aufgabenliste
            };
            Aufgabe DritteAufgabe = new Aufgabe()
            {
                Topic = "Test Aufgabe 2",
                Inhalt = "Test Inhalt 2",
                Done = false,
                Prio = 1,
                Category = "Test Kategorie 2",
                ParentToDoList = Aufgabenliste
            };
            ctx.Aufgaben.Add(ZweiteAufgabe);
            ctx.Aufgaben.Add(DritteAufgabe);
            ctx.SaveChanges();
        }

    }
}
