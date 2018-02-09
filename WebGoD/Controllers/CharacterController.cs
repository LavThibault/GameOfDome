using System;
using System.Collections.Generic;
using System.Web.Http;
using EntitiesLayer;
using BuisnessLayer;
using System.Net.Http;
using System.Net;

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

        public Character GetCharacter(String firstName)
        {
     
            int a = ThronesTournamentManager.newId();

            Character c = ThronesTournamentManager.ReturnCharacter(firstName);
            return c;
        }

        //dabord creation de caracter puis set , donc numberOfObject incorrect
        public HttpResponseMessage PutUpdateCharacter(int uid, Character character)
        {
            
            if(ThronesTournamentManager.UpdateCharacter(uid, character))
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
