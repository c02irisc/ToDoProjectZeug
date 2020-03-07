using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Models;

namespace ToDoProject.ViewModels
{
    class NeueListeViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ToDoList neueListe { get; set; }

        public List<string> Bilder { get; set; }

        private String _SelectedBild { get; set; }

        public String SelectedBild
        {
            get
            {
                return _SelectedBild;
            }
            set
            {
                _SelectedBild = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedBild"));
                }
            }
        }

        public NeueListeViewModel()
        {
            Bilder = new List<string>();

            for (int i = 0; i < 19; i++)
            {
                string cache = "Pics/0" + i + ".png";
                Bilder.Add(cache);
            }
        }
    }
}
