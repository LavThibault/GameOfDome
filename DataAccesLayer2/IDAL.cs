using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    interface IDal
    {
        List<House> ReturnHouses();
        List<Character> returnCharactersFromHouse(int houseId, int maxValue);
        House ReturnHouse(int id);
        List<Territory> ReturnTerritories();
        List<Character> ReturnCharacters();
        Character ReturnCharacter(int id);
        Boolean UpdateCharacter(int id, Character character);
        int newId();
    }
}
