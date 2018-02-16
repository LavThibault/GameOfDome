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
        public List<Character> GetAllCharacters()
        {
            List<Character> l = new List<Character>();
            foreach(Character c in ThronesTournamentManager.ReturnCharacters())
            {
                l.Add(c);
            }
            return l;
        }

        public Character GetCharacter(int id)
        {
            Character c = ThronesTournamentManager.ReturnCharacter(id);
            return c;
        }
        

        public HttpResponseMessage PutUpdateCharacter(int uid, CharacterDTO character)
        {
            Character c = new Character(character.Id, character.FirstName, character.LastName, 2);
            if(ThronesTournamentManager.UpdateCharacter(uid, c))
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
    }
}
