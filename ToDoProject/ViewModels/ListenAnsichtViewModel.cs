using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Models;

namespace ToDoProject.ViewModels
{
    class ListenAnsichtViewModel

    {
        public ToDoList aktuellesToDo { get; set; }

        ToDoListContext ctx = new ToDoListContext();

        public ObservableCollection<Aufgabe> Aufgaben { get; set; }

        public String Statistic
        {
            get
            {
                return DoneCount() + " / " + aktuellesToDo.Aufgaben.Count;
            }
            set
            {
                Statistic = DoneCount() + " / " + aktuellesToDo.Aufgaben.Count;
            }
        }


        internal void FillAufgabenliste()
        {
            Aufgaben = new ObservableCollection<Aufgabe>();

            foreach (var item in ctx.Aufgaben.Include("ParentToDoList"))
            {
                Aufgaben.Add(item);
            }
        }



        public int DoneCount()
        {
            return aktuellesToDo.Aufgaben.Where(g => g.Done == true).ToList().Count;
        }

    }
}
