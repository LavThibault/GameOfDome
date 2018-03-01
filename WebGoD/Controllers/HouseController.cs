using BuisnessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebGoD.Models;

namespace WebGoD.Controllers
{
    [RoutePrefix("api/house")]
    public class HouseController : ApiController
    {
        // GET: api/house
        public List<HouseDto> GetAllHouses()
        {
            new HouseControllerUnitTest().test();

            List<HouseDto> l = new List<HouseDto>();
            foreach (House h in ThronesTournamentManager.ReturnHouses())
            {
                l.Add(new HouseDto(h.Id, h.Name, h.NumberOfUnities, h.Gold));
            }
            return l;
        }

        // GET: api/house/5
        public HouseDto GetHouse(int id)
        {
            House h = ThronesTournamentManager.ReturnHouse(id);
            return new HouseDto(h.Id, h.Name, h.NumberOfUnities, h.Gold);
        }

        // GET: api/house/5/character
        [Route("{id}/characters")]
        public List<CharacterDto> GetCharactersFromHouse(int id)
        {
            List<Character> listeCharacter = ThronesTournamentManager.returnCharactersFromHouse(id);
            List<CharacterDto> listeCharacterDTO = new List<CharacterDto>();

            foreach (Character c in listeCharacter)
            {
                listeCharacterDTO.Add(new CharacterDto(c.Id, c.FirstName, c.LastName));
            }

            return listeCharacterDTO;
        }

        // POST: api/War
        public HttpResponseMessage Post(HouseDto house)
        {
            House h = new House(house.Id, house.Name, house.NumberOfUnities, house.Gold);
            if (ThronesTournamentManager.AddHouse(h))
            {
                var response = new HttpResponseMessage();
                response.Headers.Add("Message", "Successfuly Created!");
                return response;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/War/5
        public HttpResponseMessage Put(int id, HouseDto house)
        {
            House h = new House(house.Id, house.Name, house.NumberOfUnities, house.Gold);
            if (ThronesTournamentManager.UpdateHouse(id, h))
            {
                var response = new HttpResponseMessage();
                response.Headers.Add("Message", "Successfuly Updated!");
                return response;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/War/5
        public HttpResponseMessage Delete(int id)
        {
            if (ThronesTournamentManager.DeleteHouse(id))
            {
                var response = new HttpResponseMessage();
                response.Headers.Add("Message", "Successfuly Deleted!");
                return response;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
