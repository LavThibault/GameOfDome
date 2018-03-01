using System;
using System.Collections.Generic;
using System.Text;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DalManager : IDal
    {
        private static DalManager _instance;
        private static readonly object padlock = new object();
        private readonly IDal access_manager;

        public static DalManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DalManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private DalManager()
        {
            access_manager = new DalAccessManagerSql();
        }

        public List<House> ReturnHouses()
        {
            return access_manager.ReturnHouses();
        }

        public House ReturnHouse(int id)
        {
            return access_manager.ReturnHouse(id);
        }

        public List<Territory> ReturnTerritories()
        {
            throw new NotImplementedException();
        }

        public List<Character> ReturnCharacters()
        {
            return access_manager.ReturnCharacters();
        }

        public Character ReturnCharacter(int id)
        {
            return access_manager.ReturnCharacter(id);
        }

        public Boolean UpdateCharacter(int id, Character character)
        {
            return access_manager.UpdateCharacter(id,character);
        }

        public int NewCharacterId()
        {
            return access_manager.NewCharacterId();
        }

        public int NewHouseId()
        {
            return access_manager.NewHouseId();
        }

        public List<Character> returnCharactersFromHouse(int houseId)
        {
            return access_manager.returnCharactersFromHouse(houseId);
        }

        public bool UpdateHouse(int id, House house)
        {
            return access_manager.UpdateHouse(id, house);
        }

        public bool AddCharacter(Character character)
        {
            return access_manager.AddCharacter(character);
        }

        public bool DeleteCharacter(int id)
        {
            return access_manager.DeleteCharacter(id);
        }

        public bool AddHouse(House house)
        {
            return access_manager.AddHouse(house);
        }

        public bool DeleteHouse(int id)
        {
            return access_manager.DeleteHouse(id);
        }

        public List<House> ReturnWinningHouse(int id)
        {
            return access_manager.ReturnWinningHouse(id);
        }
    }
}
