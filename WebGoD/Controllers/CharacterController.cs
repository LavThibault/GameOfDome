using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntitiesLayer;
using BuisnessLayer;

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
            Character c = ThronesTournamentManager.ReturnCharacter(firstName);
            return c;
        }
    }
}
