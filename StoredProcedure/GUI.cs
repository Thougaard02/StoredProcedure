using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedure
{
    class GUI
    {
        DalManager manager = new DalManager();
        public void Menu()
        {
            Console.WriteLine("1. Show all customers");
            Console.WriteLine("2. Search a customer");
            Console.WriteLine("3. Search a product name");

            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                Console.Clear();
                manager.SelectAllCustomers();
                Console.ReadKey();
            }
            else if (userInput == 2)
            {
                Console.Clear();
                Console.WriteLine("Insert customer firstname");
                string firstName = Console.ReadLine();
                Console.WriteLine("Insert customer lastname");
                string lastName = Console.ReadLine();
                manager.SearchCustomersName(firstName, lastName);
                Console.ReadKey();
            }
            else if (userInput == 3)
            {
                Console.Clear();
                Console.WriteLine("Insert customer firstname");
                string firstName = Console.ReadLine();
                Console.WriteLine("Insert customer lastname");
                string lastName = Console.ReadLine();
                Console.WriteLine("Insert product name");
                string product = Console.ReadLine();
                manager.SearchCustomersProduct(firstName, lastName, product);
                Console.ReadKey();
            }
        }
    }
}
