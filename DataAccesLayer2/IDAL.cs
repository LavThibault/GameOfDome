using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    interface IDal
    {
        List<House> ReturnHouses();
        List<Character> returnCharactersFromHouse(int houseId);
        House ReturnHouse(int id);
        List<Territory> ReturnTerritories();
        List<Character> ReturnCharacters();
        Character ReturnCharacter(int id);
        bool UpdateCharacter(int id, Character character);
        bool AddCharacter(Character character);
        bool UpdateHouse(int id, House house);
        bool DeleteCharacter(int id);
        bool DeleteHouse(int id);
        bool AddHouse(House house);
        int NewCharacterId();
        int NewHouseId();
    }
}
