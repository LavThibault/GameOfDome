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
            throw new NotImplementedException();
        }

        public List<House> ReturnHouseWithMoreThanx(int x)
        {
            throw new NotImplementedException();
        }

        public List<Territory> ReturnTerritories()
        {
            throw new NotImplementedException();
        }

        public List<Character> ReturnCharacters()
        {
            return access_manager.ReturnCharacters();
        }

        public Character ReturnCharacter(String firstName)
        {
            return access_manager.ReturnCharacter(firstName);
        }

        public Boolean UpdateCharacter(int id, Character character)
        {
            return access_manager.UpdateCharacter(id,character);
        }

        public int newId()
        {
            return access_manager.newId();
        }
    }
}
