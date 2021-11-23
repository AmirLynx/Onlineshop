using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DigiKala
{
    public class ShowItems
    {
        
        public void ShowProducts(ProductEntity product)
        {
            Console.WriteLine($"Id : {product.ProductId}");
            Console.WriteLine($"Name : {product.Name}");
            Console.WriteLine($"Price : {product.Price}");
            Console.WriteLine($"Catagory : {product.Catagory}");
            Console.WriteLine("-----------------------------");
        }
        public void ShowContacts(ContactEntity contact)
        {
            Console.WriteLine($"Id : {contact.ContactId}");
            Console.WriteLine($"Name : {contact.Name}");
            Console.WriteLine($"Phone number : {contact.PhoneNumber}");
            Console.WriteLine($"Adress : {contact.Adress}");
            Console.WriteLine($"Orders : {contact.OrderCounter}");
            Console.WriteLine($"Pass : {contact.PassWord}");
            Console.WriteLine("--------------------------");
        }
        public void ShowOrders(OrderEntity order)
        {

        }
        public void ShowCatagorys(CatagoryEntity catagory)
        {
            Console.WriteLine($"Id : {catagory.Id}({catagory.used})");
            Console.WriteLine($"Name : {catagory.Name}");
            Console.WriteLine("---------------------------");
        }
    }
}
