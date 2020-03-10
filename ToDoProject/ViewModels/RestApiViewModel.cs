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
            
            String resultBild = "hallo";
            
            HttpClient client = new HttpClient();
            string path = "https://picsum.photos/id/0/info";

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                var stringcontent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(stringcontent);
            }

            
            return resultBild;
           

        }

    }
}
