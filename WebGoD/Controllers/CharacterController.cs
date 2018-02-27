using System;
using System.Collections.Generic;
using System.Web.Http;
using EntitiesLayer;
using BuisnessLayer;
using System.Net.Http;
using System.Net;
using WebGoD.Models;

namespace WebGoD.Controllers
{
    public class CharacterController : ApiController
    {
        // GET: api/character
        public List<Character> GetAllCharacters()
        {
            List<Character> l = new List<Character>();
            foreach(Character c in ThronesTournamentManager.ReturnCharacters())
            {
                l.Add(c);
            }
            return l;
        }

        // GET: api/character/5
        public Character GetCharacter(int id)
        {
            Character c = ThronesTournamentManager.ReturnCharacter(id);
            return c;
        }

        // POST: api/character
        public HttpResponseMessage Post(CharacterDto character)
        {
            Character c = new Character(character.Id, character.FirstName, character.LastName, 2);
            if (ThronesTournamentManager.AddCharacter(c))
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

        // PUT: api/character/5
        public HttpResponseMessage Put(int id, CharacterDto character)
        {
            Character c = new Character(character.Id, character.FirstName, character.LastName, 2);
            if(ThronesTournamentManager.UpdateCharacter(id, c))
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

        // DELETE: api/character/5
        public HttpResponseMessage Delete(int id)
        {
            if (ThronesTournamentManager.DeleteCharacter(id))
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
