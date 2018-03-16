using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer;

namespace ThronesTournamentConsole
{
    static class Program
    {

        static void Main(string[] args)
        {
            String i;
            while (true)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("A. afficher la liste des character");
                Console.WriteLine("B. afficher la liste des maisons");
                Console.WriteLine("-----------------------");
                i = Console.ReadLine();
               
                
                switch (i)
                {
                    case "A":
          
                        foreach (var item in ThronesTournamentManager.ReturnCharacters())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "B":
                        foreach (var item in ThronesTournamentManager.ReturnHouses())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    default:
                        Console.WriteLine("passage par default");
                        break;
                }
            }
        }
    }
}
