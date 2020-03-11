using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static ToDoProject.Models.ImageAPI;


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
            String resultBild = "https://picsum.photos/id/";

            HttpClient client = new HttpClient();
            string path = "https://picsum.photos/v2/list?page=2&limit=100";

            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var stringcontent = response.Content.ReadAsStringAsync().Result;
                List<RootObject> pictures = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RootObject>>(stringcontent);
                
                Random random = new Random();
                int p = random.Next(0, pictures.Count);

                String url = pictures[p].download_url;
                url = url.Substring(0, url.LastIndexOf("/"));
                url = url.Substring(0, url.LastIndexOf("/"));

                resultBild = url + "/300/300?blur=5";
            }

            return resultBild;
        }
    }
}
