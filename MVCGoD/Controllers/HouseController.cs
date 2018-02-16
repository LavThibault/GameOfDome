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
            return View();
        }

        // GET: House/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: House/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: House/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: House/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: House/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
