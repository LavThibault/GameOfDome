﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MVCGoD.Models;
using Newtonsoft.Json;
using WebGoD.Models;

namespace MVCGoD.Controllers
{
    public class CharacterController : Controller
    {

        static IEnumerable<CharacterModel> characList = new List<CharacterModel>();
        static int maxId=0;

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

        //Called after clicking on "Edit"
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
                CharacterModel C = ((List<CharacterModel>)characList).Find(c => id == c.Id);
                C.House.Housers.Remove(C);
                ((List<CharacterModel>)characList).Remove(C);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Called after saving the changes
        [HttpPost]
        public ActionResult Edit(int id, CharacterModel C)
        {
            CharacterDto t = new CharacterDto(C.Id, C.FirstName,C.LastName);

            try
            {
                HttpResponseMessage responsePutMethod = ClientPutRequest(t);
                ((List<CharacterModel>)characList).Remove(((List<CharacterModel>)characList).Find(c => id == c.Id));
                C.House.Housers.Remove(C);
                C.House = HouseController.getHouseById(int.Parse(C.HouseId));
                C.House.Housers.Add(C);
                ((List<CharacterModel>)characList).Add(C);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private HttpResponseMessage ClientPutRequest(CharacterDto C)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54197/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
            HttpResponseMessage response = client.PutAsync("api/Character?uid="+C.Id, new StringContent(new JavaScriptSerializer().Serialize(C),Encoding.UTF8, "application/json")).Result;
            return response;
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
                C.House.Housers.Add(C);
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