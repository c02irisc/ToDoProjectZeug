using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Models;

namespace ToDoProject.ViewModels
{
    class ListenAnsichtViewModel : INotifyPropertyChanged
    {
        ToDoListContext ctx = new ToDoListContext();

        public event PropertyChangedEventHandler PropertyChanged;
        public ToDoList aktuellesToDo { get; set; }

        public Aufgabe SelectedAufgabe { get; set; }

        private ObservableCollection<Aufgabe> _AllAufgaben;
        public ObservableCollection<Aufgabe> AllAufgaben
        {
            get
            {
                return _AllAufgaben;
            }
            set
            {
                _AllAufgaben = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AllAufgaben"));
                }
            }
        }
        private ObservableCollection<Aufgabe> _Aufgaben;
        public ObservableCollection<Aufgabe> Aufgaben
        {
            get
            {
                return _Aufgaben;
            }
            set
            {
                _Aufgaben = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Aufgaben"));


                }
            }
        }
        private ObservableCollection<Aufgabe> _ResponsiveAufgabenListe;
        public ObservableCollection<Aufgabe> ResponsiveAufgabenListe
        {
            get
            {
                return _ResponsiveAufgabenListe;
            }
            set
            {
                _ResponsiveAufgabenListe = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ResponsiveAufgabenListe"));
                   
                }
            }
        }

        private int _CountDone;
        public int CountDone
        {
            get
            {
                return _CountDone;
            }
            set
            {
                _CountDone = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CountDone"));
                }
            }
        }
        private int _CountAll;
        public int CountAll
        {
            get
            {
                return _CountAll;
            }
            set
            {
                _CountAll = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CountAll"));
                }
            }
        }

        public void FilterBy(String filter)
        {
            ResponsiveAufgabenListe = new ObservableCollection<Aufgabe>();

            if (filter == "Prio")
            {
                ResponsiveAufgabenListe = new ObservableCollection<Aufgabe>(Aufgaben.OrderBy(x => x.Prio));
            }
            else if (filter == "Kategorie")
            {
                ResponsiveAufgabenListe = new ObservableCollection<Aufgabe>(Aufgaben.OrderBy(x => x.Category));
            }
            else if (filter == "Name")
            {
                ResponsiveAufgabenListe = new ObservableCollection<Aufgabe>(Aufgaben.OrderBy(x => x.Topic));
            }
            else if (filter == "Undone")
            {
                ResponsiveAufgabenListe = new ObservableCollection<Aufgabe>(Aufgaben.Where(x => x.Done == false));
            }
            else if (filter == "Done")
            {
                ResponsiveAufgabenListe = new ObservableCollection<Aufgabe>(Aufgaben.Where(x => x.Done == true));
            }
        }

        internal void FillAufgabenliste()
        {
            Aufgaben = new ObservableCollection<Aufgabe>();

            if (AllAufgaben != null)
            {
                foreach (var item in AllAufgaben)
                {
                    if (item.ParentToDoList == aktuellesToDo)
                    {
                        Aufgaben.Add(item);
                    }

                }
            }

            ResponsiveAufgabenListe = Aufgaben;
            updateCount();
        }

        public void updateCount()
        {
            if (Aufgaben == null)
            {
                CountDone = 0;
                CountAll = 0;
            }
            CountDone = Aufgaben.Where(g => g.Done == true).ToList().Count;
            CountAll = Aufgaben.Count;
        }
    }
}
