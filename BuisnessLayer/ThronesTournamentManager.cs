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
        static Dictionary<int,Fight> listOfCurrentFight = new Dictionary<int,Fight>();


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

        public static int NewCharacterId()
        {
            return DalManager.Instance.NewCharacterId();
        }

        public static int NewHouseId()
        {
            return DalManager.Instance.NewHouseId();
        }

        public static List<Character> returnCharactersFromHouse(int houseId)
        {
            return DalManager.Instance.returnCharactersFromHouse(houseId);
        }

        public static bool UpdateHouse(int id, House house)
        {
            return DalManager.Instance.UpdateHouse(id, house);
        }

        public static bool AddCharacter(Character character)
        {
            return DalManager.Instance.AddCharacter(character);
        }

        public static bool DeleteCharacter(int id)
        {
            return DalManager.Instance.DeleteCharacter(id);
        }

        public static bool AddHouse(House house)
        {
            return DalManager.Instance.AddHouse(house);
        }

        public static bool DeleteHouse(int id)
        {
            return DalManager.Instance.DeleteHouse(id);
        }


        public static Fight letsFight(int id)
        {
            try
            {
                listOfCurrentFight[id].roundFight();
            
            }
            catch ( Exception e)
            {
                //NEED TO CHECK FOR THE RIGHT EXCEPTION OUT OF RANGE
                List<House> tempList = ReturnHouses();

                // IS NOT RANDOM FOR NOW 
                int randomHouseID = tempList[0].Id;
                if (randomHouseID == id)
                {
                    randomHouseID = tempList[1].Id;
                }

                listOfCurrentFight.Add(id, new Fight(ReturnHouse(id), ReturnHouse(randomHouseID)));
                
            }
            return listOfCurrentFight[id];
        }

        public static Fight letsFightTwoHouse(int id,int id2)
        {
            try
            {
                listOfCurrentFight[id].roundFight();

            }
            catch (Exception e)
            {
                //NEED TO CHECK FOR THE RIGHT EXCEPTION OUT OF RANGE
 

                listOfCurrentFight.Add(id, new Fight(ReturnHouse(id), ReturnHouse(id2)));

            }
            return listOfCurrentFight[id];
        }
        public static House ReturnWinningHouse(int id)
        {
            List<House> houses = DalManager.Instance.ReturnWinningHouse(id);
            return LetsFight(houses[0], houses[1]);
        }

        public static House LetsFight(House h1, House h2)
        {
            return h1;
        }
    }
}
