using BuisnessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebGoD.Models;

namespace WebGoD.Controllers
{
    public class HouseController : ApiController
    {
        public List<HouseDTO> GetAllHouses()
        {
            List<HouseDTO> l = new List<HouseDTO>();
            foreach (House h in ThronesTournamentManager.ReturnHouses())
            {
                l.Add(new HouseDTO(h.Id, h.Name, h.NumberOfUnities, h.Gold));
            }
            return l;
        }

        public HouseDTO GetHouse(int id)
        {
            House h = ThronesTournamentManager.ReturnHouse(id);

            return new HouseDTO(h.Id, h.Name, h.NumberOfUnities, h.Gold);
        }

        public List<CharacterDTO> GetCharactersFromHouse(int idHouse, int maxValue)
        {
            List<Character> listeCharacter = ThronesTournamentManager.returnCharactersFromHouse(idHouse, maxValue);
            List<CharacterDTO> listeCharacterDTO = new List<CharacterDTO>(maxValue);

           int realMax= maxValue < listeCharacter.Count ? maxValue : listeCharacter.Count;

            for (int i=0;i<realMax;i++)
            {
                Character c = listeCharacter[i];
                    listeCharacterDTO.Add(new CharacterDTO(c.Id, c.FirstName, c.LastName));
 
                
            }

            return listeCharacterDTO;


            
        }
    }
}
