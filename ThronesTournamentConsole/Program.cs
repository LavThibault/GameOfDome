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
                Console.WriteLine("A. afficher la liste des terrains");
                Console.WriteLine("B. afficher la liste des maisons à plus de 200 unité");
                Console.WriteLine("C. afficher la liste des maisons");
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
                        
                        break;
                    case "C":
                        
                        break;
                    default:
                        Console.WriteLine("passage par default");
                        break;
                }
            }
        }
    }
}
