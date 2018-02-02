using MVCGoD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCGoD.Controllers
{

    public class HouseController : Controller
    {

        static IEnumerable<HouseModel> houseList = new List<HouseModel>();
        static int maxId = 0;

        static HouseModel getHouseById(int id)
        {
            return ((List<HouseModel>)houseList).Find(h => id == h.Id);
        }
        static IEnumerable<HouseModel> getHouses()
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
        public ActionResult Index()
        {
            return View(getHouses());
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
    }
}
