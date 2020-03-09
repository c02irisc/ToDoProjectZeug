using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject.ViewModels
{
    class RestApiViewModel
    {

        public String GeladenesBild { get; set; }



        public RestApiViewModel()
        {
            GeladenesBild = GetPicture();
        }

        public String GetPicture()
        {
            /*
            String resultBild = "";

            HttpClient client = new HttpClient();
            string path = "https://picsum.photos/id/237/200/300";

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var stringcontent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(stringcontent);
            }


            return resultBild;
            */
            return "Hallo";

        }

    }
}
