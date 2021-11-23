using System;
using Models;
using Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DigiKala
{
    class AppMenu
    {
        private static ContactService _contactService { get; set; } = new ContactService();
        private static ProductService _productServise { get; set; } = new ProductService();
        private static OrderService _orderService { get; set; } = new OrderService();
        private static CatagoryService _categoryService { get; set; } = new CatagoryService();

        private static Utility _utility = new Utility();
        private static Menus _menus = new Menus();
        private static Login _login = new Login();
        private static ShowItems _showItems = new ShowItems();
        public AppMenu(Enums.App choiceApp)
        {
            var appChoice = (Enums.App)_menus.AppMenu();

            switch (appChoice)
            {
                case Enums.App.showAll:

                    _utility.ShowHeader("All Prdoucts ;");

                    foreach (var item in _productServise.GetAll())
                    {
                        if (item.Entity != 0)
                        {
                            Console.WriteLine($"Id : {item.ProductId}");
                            Console.WriteLine($"Name : {item.Name}");
                            Console.WriteLine($"Price : {item.Price}");
                            Console.WriteLine($"Catagory : {item.Catagory}");
                            Console.WriteLine("-----------------------------");
                        }
                    }
                    Console.WriteLine();

                    int addToCart;
                    bool flag = true;
                    do
                    {
                        try
                        {
                            addToCart = int.Parse(_utility.GetValue("Please Enter Id to add"));
                            flag = false;
                        }
                        catch
                        {
                            _utility.Log("Please enter number of menu !", Enums.Loger.error);
                            continue;
                        }
                        if (flag == true)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);

                    var getProduct = _productServise.GetById(addToCart);

                    int entity = int.Parse(_utility.GetValue("Enter valu of product :"));

                    if (entity > getProduct.Entity)
                    {
                        _utility.Log($"You cant buy more than {getProduct.Entity}", Enums.Loger.error);
                        //continue;
                    }

                    break;
                case Enums.App.search:

                    _utility.ShowHeader("Search product ");
                    int searchInput;
                    bool flagSer = true;
                    do
                    {
                        try
                        {
                            searchInput = int.Parse(_utility.GetValue("Please Enter Id to add"));
                            flagSer = false;
                        }
                        catch
                        {
                            _utility.Log("Please enter number of menu !", Enums.Loger.error);
                            continue;
                        }
                        if (flagSer == true)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);
                    
                    var found = _productServise.GetById(searchInput);

                    Console.WriteLine($"Id : {found.ProductId}");
                    Console.WriteLine($"Name : {found.Name}");
                    Console.WriteLine($"Price : {found.Price}");
                    Console.WriteLine($"Catagory : {found.Catagory}");

                    break;
                case Enums.App.cart:
                    break;
                case Enums.App.manageProfile:
                    break;
                case Enums.App.orderList:

                    _utility.ShowHeader("Order List");

                    var searchId = int.Parse(_utility.GetValue("please enter contact id for search orders"));

                    var foundContact = _contactService.GetById(searchId);

                    foreach (var item in _orderService.GetAll())
                    {
                        if (item.OwnerId == foundContact.ContactId)
                        {
                            var foundProduct = _productServise.GetById(item.ProductId);
                            Console.WriteLine($"Order Id : {item.OrderId}");
                            Console.WriteLine($"Status : {item.Status}");
                            Console.WriteLine($"Owner : {foundContact.Name}");
                            Console.WriteLine($"Owner Adress : {foundContact.Adress}");
                            Console.WriteLine($"owner Phonenumber : {foundContact.PhoneNumber}");
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine($"Product Id : {item.ProductId}");
                            Console.WriteLine($"Product Name : {foundProduct.Name}");
                            Console.WriteLine($"Product Catagory : {foundProduct.Catagory}");
                            Console.WriteLine($"Product Price : {foundProduct.Price}");
                            Console.WriteLine($"Product Entity : {item.Entity}");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine($"Order sum : {item.Entity * foundProduct.Price}");
                        }
                    }

                    break;
                case Enums.App.back:
                    break;
                default:
                    _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                    break;
            }
            Console.ReadLine();
        }
    }
}
