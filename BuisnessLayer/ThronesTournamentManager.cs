using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataAccessLayer;

namespace BuisnessLayer
{
    public static class ThronesTournamentManager
    {
        public static List<Character> ReturnCharacters()
        {
            return DalManager.Instance.ReturnCharacters();
        }

        public static Character ReturnCharacter(int id)
        {
            return DalManager.Instance.ReturnCharacter(id);
        }

        public static Boolean UpdateCharacter(int id, Character character)
        {
            return DalManager.Instance.UpdateCharacter(id, character);
        }

        public static List<House> ReturnHouses()
        {
            return DalManager.Instance.ReturnHouses();
        }

        public static House ReturnHouse(int id)
        {
            return DalManager.Instance.ReturnHouse(id);
        }

        public static int newId()
        {
            return DalManager.Instance.newId();
        }

        public static List<Character> returnCharactersFromHouse(int houseId, int maxValue)
        {
            return DalManager.Instance.returnCharactersFromHouse(houseId, maxValue);
        }
    }
}
