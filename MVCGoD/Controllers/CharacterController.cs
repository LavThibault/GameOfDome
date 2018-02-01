using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCGoD.Models;
using Newtonsoft.Json;

namespace MVCGoD.Controllers
{
    public class CharacterController : Controller
    {
        public async Task<ActionResult> Index()
        {
            IEnumerable<CharacterModel> characList = new List<CharacterModel>();
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54197");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/character");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    characList = JsonConvert.DeserializeObject<IEnumerable<CharacterModel>>(temp);
                }
            }

            return View(characList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}