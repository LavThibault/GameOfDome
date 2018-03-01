/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
namespace StubDataAccesLayer
{

    public class DalManager
    {
        private List<House> ListeHouse { get; set; }
        private List<Territory> ListeTerritory { get; set; }
        private List<Character> ListeCharacter { get; set; }

        public DalManager()
        {
            ListeHouse = new List<House>();
            ListeTerritory = new List<Territory>();
            ListeCharacter = new List<Character>();

            ListeHouse.Add(new House("F5",2000,5000));
            ListeHouse.Add(new House("sweedishHouseMafia",120,40));
            ListeHouse.Add(new House("lesNazes",0,2));
            ListeHouse.Add(new House("LesZZeros",400,400));

            ListeTerritory.Add(new Territory("Aurillac"));
            ListeTerritory.Add(new Territory("Clermont",ListeHouse[1]));
            ListeTerritory.Add(new Territory("A214", ListeHouse[0]));

            ListeCharacter.Add(new Character("thibault", "Lavigne", 100));
            ListeCharacter.Add(new Character("jeremy", "Cotineau", 50));
            ListeCharacter.Add(new Character("Patrick", "Pitulet", 20));
            ListeCharacter.Add(new Character("FFFFFFFFFF", "JAMMES", 100));


            ListeHouse[0].AddHouser(ListeCharacter[0]);
            ListeHouse[0].AddHouser(ListeCharacter[1]);

            ListeHouse[1].AddHouser(ListeCharacter[2]);
            ListeHouse[2].AddHouser(ListeCharacter[3]);

        }

        public List<House> ReturnHouses()
        {
            return ListeHouse;
        }
        
        public List<House> ReturnHouseWithMoreThanx(int x)
        {
            return ListeHouse.Where<House>(mHouse => mHouse.NumberOfUnities > x).Select(mHouse=> mHouse).ToList<House>();
        }

        public List<Territory> ReturnTerritories()
        {
            return ListeTerritory;
        }

        public List<Character> ReturnCharacters()
        {
            return ListeCharacter;
        }

    }
}
*/