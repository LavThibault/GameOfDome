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

        public static Character ReturnCharacter(String firstName)
        {
            return DalManager.Instance.ReturnCharacter(firstName);
        }

        public static Boolean UpdateCharacter(int id, Character character)
        {
            return DalManager.Instance.UpdateCharacter(id, character);
        }

        public static int newId()
        {
            return DalManager.Instance.newId();
        }
    }
}
