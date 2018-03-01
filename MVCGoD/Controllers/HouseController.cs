using MVCGoD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCGoD.Controllers
{
    public class HouseController : Controller
    {

        static IEnumerable<HouseModel> houseList = new List<HouseModel>();
        static int maxId = 0;
        static int HouseId;

        public static HouseModel getHouseById(int id)
        {
            return ((List<HouseModel>)houseList).Find(h => id == h.Id);
        }
        public static IEnumerable<HouseModel> getHouses()
        {
            return houseList;
        }
        static void editHouse(int id, HouseModel h)
        {
            deleteHouseById(id);
            addHouse(h);
        }
        static void addHouse(HouseModel h)
        {
            h.Id = maxId + 1;
            maxId++;
            ((List<HouseModel>)houseList).Add(h);
        }
        static void deleteHouseById(int id)
        {
            ((List<HouseModel>)houseList).Remove(((List<HouseModel>)houseList).Find(c => id == c.Id));
        }




        // GET: House
        public async Task<ActionResult> Index()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:54197");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/house");
                    if (response.IsSuccessStatusCode)
                    {
                        string temp = await response.Content.ReadAsStringAsync();
                        houseList = JsonConvert.DeserializeObject<IEnumerable<HouseModel>>(temp);
                        maxId = ((List<HouseModel>)houseList).Max(c => c.Id);
                    }
                }
            }
            catch (Exception e) { }
            return View(houseList);
        }

        // GET: House/Details/5
        public ActionResult Details(int id)
        {
            return View(getHouseById(id));
        }

        // GET: House/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: House/Create
        [HttpPost]
        public ActionResult Create(HouseModel house)
        {
            try
            {
                addHouse(house);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: House/Edit/5
        public ActionResult Edit(int id)
        {
            return View(getHouseById(id));
        }

        // POST: House/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HouseModel house)
        {
            try
            {
                editHouse(id, house);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Play(int id)
        {
            HouseId = id;
            return View(getHouseById(id));
        }


        // GET: House/Delete/5
        public ActionResult Delete(int id)
        {
            return View(getHouseById(id));
        }

        // POST: House/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                deleteHouseById(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Acheter(int argent)
        {
            HouseModel h = getHouseById(HouseId);
            if (argent > 0 && h.Gold >= argent)
            {
                h.Gold -= ((int)argent / 5) * 5;
                h.NumberOfUnities += argent / 5;
            }
            if (argent < 0 && h.Gold >= -argent)
            {
                h.Gold += argent;
                h.Housers.Add(CharacterModel.HeroGenerator(HouseId));
            }


            return RedirectToAction("Play", new { id = HouseId });
        }
    }
}
