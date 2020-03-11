using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    class ImageAPI
    {

        public class RootObject
        {
            public string id { get; set; }
            public string author { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string url { get; set; }
            public string download_url { get; set; }
        }

    }
}
