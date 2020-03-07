using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject.ViewModels
{
    class ChooseBildViewModel
    {
        public List<string> Bilder { get; set; }
        public string SelectedBild { get; set; }

        public ChooseBildViewModel()
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
