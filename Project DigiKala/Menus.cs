using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DigiKala
{
    
    class Menus
    {
        private Utility _utility = new Utility();

        public int BaseMenu()
        {
            _utility.ShowHeader("DigiKala");

            Console.WriteLine("1. Admin");
            Console.WriteLine("2. App");
            Console.WriteLine("3. Signup");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\n----------------");

            return int.Parse(_utility.GetValue("Enter your choice : "));

        }

        public int AdminMenu()
        {
            _utility.ShowHeader("Admin Menu");

            Console.WriteLine("1. Manage contacts");
            Console.WriteLine("2. Manage catagorys");
            Console.WriteLine("3. Manage orders");
            Console.WriteLine("4. Manage products");
            Console.WriteLine("5. Log out");
            Console.WriteLine("\n----------------");

            return int.Parse(_utility.GetValue("Enter your choice : "));
        }
        public int AppMenuByContac(ContactEntity contact)
        {
            _utility.ShowHeader($"Hello {contact.Name}");
            

            Console.WriteLine("1. Shop items");
            Console.WriteLine("2. Search product");
            Console.WriteLine("3. Cart");
            Console.WriteLine("4. Profile");
            Console.WriteLine("5. Log out");
            Console.WriteLine("\n----------------");

            return int.Parse(_utility.GetValue("Enter your choice : "));
        }
        public int ManageMenu(string msg)
        {
            _utility.ShowHeader(msg);

            Console.WriteLine($"1. Add new {msg}");
            Console.WriteLine($"2. Show All {msg}");
            Console.WriteLine($"3. Search in {msg}");
            Console.WriteLine($"4. Edit {msg}");
            Console.WriteLine($"5. Delete {msg}");
            Console.WriteLine("6. Back");
            Console.WriteLine("------------");//todo : edit menu

            return int.Parse(_utility.GetValue("Enter Your Choice"));
        }
        public int EditOrPay (string msg)
        {
            _utility.ShowHeader(msg);
            Console.WriteLine("1. Pay");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Back");
            Console.WriteLine();
            return int.Parse(_utility.GetValue("Enter your choice"));
        }
        public int Sort(string msg)
        {
            _utility.ShowHeader(msg);
            Console.WriteLine("1. Pay");
            Console.WriteLine("2. Not Pay");
            Console.WriteLine("3. In Proccess");
            Console.WriteLine("4. Send Post");
            Console.WriteLine("5. Send To Adress");
            Console.WriteLine("6. back");
            return int.Parse(_utility.GetValue("Enter your choice :"));
        }
    }
}
