﻿using System;
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
    }
}
