using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    interface IDal
    {
        List<House> ReturnHouses();
        List<House> ReturnHouseWithMoreThanx(int x);
        List<Territory> ReturnTerritories();
        List<Character> ReturnCharacters();
        Character ReturnCharacter(String firstName);
        Boolean UpdateCharacter(int id, Character character);
        int newId();
    }
}
