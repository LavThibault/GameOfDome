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
            setHousesViewBag();
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
                ((List<CharacterModel>)characList).Remove(((List<CharacterModel>)characList).Find(c => id == c.Id));
                C.House = HouseController.getHouseById(int.Parse(C.HouseId));
                ((List<CharacterModel>)characList).Add(C);
            return RedirectToAction("Index");
        }
            catch
            {
                return View();
    }
}

        public ActionResult Details(int id)
        {

            return View(((List<CharacterModel>)characList).Find(c => id == c.Id));
        }
        public ActionResult Create()
        {
            setHousesViewBag();
            return View();
        }

        private void setHousesViewBag()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (HouseModel h in HouseController.getHouses())
            {
                items.Add(new SelectListItem { Text = h.Name, Value = "" + h.Id });
            }

            ViewBag.HouseList = items;
        }

        [HttpPost]
        public ActionResult Create(CharacterModel C)
        {
            try
            {
                C.Id = maxId + 1;
                C.House = HouseController.getHouseById(int.Parse(C.HouseId));
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