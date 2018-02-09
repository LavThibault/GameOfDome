using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MVCGoD.Models;
using Newtonsoft.Json;

namespace MVCGoD.Controllers
{
    public class CharacterController : Controller
    {

        static IEnumerable<CharacterModel> characList = new List<CharacterModel>();
        static int maxId=0;

        public async Task<ActionResult> Index()
        {
            try {
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
                    maxId=((List<CharacterModel>)characList).Max(c => c.Id);
                }
            }
            }
            catch(Exception e) { }
            return View(characList);
        }

        public ActionResult Edit(int id)
        {

            return View(((List<CharacterModel>)characList).Find(c => id == c.Id));
        }

        public ActionResult Delete(int id)
        {

            return View(((List<CharacterModel>)characList).Find(c => id == c.Id));
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ((List<CharacterModel>)characList).Remove(((List<CharacterModel>)characList).Find(c => id == c.Id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, CharacterModel C)
        {
            try
            {
                /*          ((List<CharacterModel>)characList).Remove(((List<CharacterModel>)characList).Find(c => id == c.Id));
                      ((List<CharacterModel>)characList).Add(C);
                      return RedirectToAction("Index");*/
                HttpResponseMessage responsePutMethod = ClientPutRequest("api/character?id=" + id, C);
                return RedirectToAction("Index");
        }
            catch
            {
                return View();
    }
}

        private HttpResponseMessage ClientPutRequest(string requestURI, CharacterModel C)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54197/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsync("api/Character?uid="+C.Id+"&FirstName="+C.FirstName, new StringContent("",Encoding.UTF8, "application/json")).Result;
            return response;
        }

        public ActionResult Details(int id)
        {

            return View(((List<CharacterModel>)characList).Find(c => id == c.Id));
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(CharacterModel C)
        {
            try
            {
                C.Id = maxId + 1;
                maxId++;
                ((List<CharacterModel>)characList).Add(C);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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