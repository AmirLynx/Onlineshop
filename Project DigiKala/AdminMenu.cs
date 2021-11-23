using System;
using Service;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DigiKala
{
    class AdminMenu
    {
        private static ContactService _contactService { get; set; } = new ContactService();
        private static ProductService _productServise { get; set; } = new ProductService();
        private static OrderService _orderService { get; set; } = new OrderService();
        private static CatagoryService _categoryService { get; set; } = new CatagoryService();

        private static Utility _utility = new Utility();
        private static Menus _menus = new Menus();
        private static Login _login = new Login();
        private static ShowItems _showItems = new ShowItems();

        public static int idSetContact = 10;
        public static int idSetProduct = 10;
        public static int idSetOrder = 10;
        public static int idSetCategory = 10;
        
        public AdminMenu(Enums.Admin choiceAdmin)
        {
            var manageBack = true;
            switch (choiceAdmin)
            {
                case Enums.Admin.manageContacts:
                    Enums.Manage manConChoice;
                    bool flag = true;
                    do
                    {
                        try
                        {
                            manConChoice = (Enums.Manage)_menus.ManageMenu("Contact");
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
                    
                    switch (manConChoice)
                    {
                        case Enums.Manage.add:

                            _utility.ShowHeader("Add contact");

                            Console.WriteLine($"Curent Id set : {idSetContact}");

                            ContactEntity checkName;
                            string tempName;

                            do
                            {
                                tempName = _utility.GetValue("Enter Name: ");
                                checkName = _contactService.ChekName(tempName);

                                if (checkName != null)
                                {
                                    _utility.Log("This name used ! please try Choice another name .", Enums.Loger.error);
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            var tempPhoneNumber = _utility.GetValue("Enter phone number :");
                            var tempAdress = _utility.GetValue("Enter Adress : ");
                            var tempPass = _utility.GetValue("Enter password : ");

                            ContactEntity contact = new ContactEntity()
                            {
                                Name = tempName,
                                PhoneNumber = tempPhoneNumber,
                                Adress = tempAdress,
                                PassWord = tempPass,
                                ContactId = idSetContact,
                                OrderCounter = 0
                            };
                            idSetContact++;
                            _contactService.Add(contact);
                            _utility.Log("Contact added successfully . ", Enums.Loger.success);
                            break;
                        case Enums.Manage.show:

                            _utility.ShowHeader("All Contacts");

                            var contacts = _contactService.GetAll();

                            if (contacts == null)
                            {
                                _utility.Log("Contacts List is empty", Enums.Loger.error);
                                Console.ReadLine();
                                break;
                            }

                            foreach (var item in contacts)
                            {
                                _showItems.ShowContacts(item);
                            }

                            break;
                        case Enums.Manage.search:

                            _utility.ShowHeader("Search contact");

                            int searchId = int.Parse(_utility.GetValue("Please enter id for search"));
                           
                            var found = _contactService.GetById(searchId);

                            _showItems.ShowContacts(found);

                            break;
                        case Enums.Manage.edit:

                            _utility.ShowHeader("edit contact");

                            int editId = int.Parse(_utility.GetValue("Please enter id for search"));
                            
                            ContactEntity editFound = _contactService.GetById(editId);
                            
                            _utility.Log("contact found", Enums.Loger.success);

                            var tempNewName = _utility.GetValue("Enter New Name: ");
                            var tempNewPhoneNumber = _utility.GetValue("Enter New phone number :");
                            var tempNewAdress = _utility.GetValue("Enter New Adress : ");
                            var tempNewPass = _utility.GetValue("Enter New password : ");

                            editFound.Name = tempNewName;
                            editFound.PhoneNumber = tempNewPhoneNumber;
                            editFound.Adress = tempNewAdress;
                            editFound.PassWord = tempNewPass;

                            _utility.Log("contact edite successfully", Enums.Loger.success);

                            break;
                        case Enums.Manage.delete:
                            _utility.ShowHeader("Delete contact");

                            int deleteId;
                            
                            deleteId = int.Parse(_utility.GetValue("Please enter id for search"));
                            
                            ContactEntity deleteFound;
                            
                            deleteFound = _contactService.GetById(deleteId);
                            
                            _utility.Log("contact found", Enums.Loger.success);
                            
                            var sure = _utility.GetValue("are you sure for delete this contact ? ( Y / N )");
                            sure = sure.ToLower();
                            switch (sure)
                            {
                                case "y":
                                    
                                    _contactService.Delete(deleteId);
                                    _utility.Log("Contact delete successfully ", Enums.Loger.success);
                                    
                                    break;
                                case "n":

                                    _utility.Log("Contact not deleted ", Enums.Loger.success);
                                    break;

                                default:
                                    Console.WriteLine("Wrong choice Please try Again.");
                                    break;
                            }

                            break;
                        case Enums.Manage.back:
                            manageBack = false;
                            break;
                        default:
                            break;
                    }
                    break;
                case Enums.Admin.manageCatagory:
                    Enums.Manage manCatChoice;
                    bool flagCat = true;
                    do
                    {
                        try
                        {
                            manCatChoice = (Enums.Manage)_menus.ManageMenu("category");
                            flagCat = false;
                        }
                        catch
                        {
                            _utility.Log("Please enter number of menu !", Enums.Loger.error);
                            continue;
                        }
                        if (flagCat == true)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);
                    switch (manCatChoice)
                    {
                        case Enums.Manage.add:
                            _utility.ShowHeader("add category");
                            Console.WriteLine($"curent id set : {idSetCategory}");
                            Console.WriteLine();

                            var tempName = _utility.GetValue("Enter category name : ");
                            CatagoryEntity catagory = new CatagoryEntity()
                            {
                                Id = idSetCategory,
                                Name = tempName,
                                used = CatagoryEntity.Used.notused
                            };

                            idSetCategory++;

                            _categoryService.Add(catagory);

                            _utility.Log("Category added successfully . ", Enums.Loger.success);
                            break;
                        case Enums.Manage.show:
                            _utility.ShowHeader("all categorys");
                            var categorys = _categoryService.GetAll();

                            foreach (var item in categorys)
                            {
                                _showItems.ShowCatagorys(item);
                            }
                            break;
                        case Enums.Manage.search:
                            _utility.ShowHeader("Search catagory");
                            int searchId = int.Parse(_utility.GetValue("Please enter id for search"));
                            var found = _contactService.GetById(searchId);
                            _showItems.ShowContacts(found);
                            break;
                        case Enums.Manage.edit:
                            _utility.ShowHeader("edit catagory");

                            int editId = int.Parse(_utility.GetValue("Please enter id for search"));

                            var editFound = _contactService.GetById(editId);

                            _utility.Log("catagory found", Enums.Loger.success);

                            var tempNewName = _utility.GetValue("Enter New Name: ");
                            
                            editFound.Name = tempNewName;

                            _utility.Log("contact edite successfully", Enums.Loger.success);
                            break;
                        case Enums.Manage.delete:
                            _utility.ShowHeader("Delete catagory");

                            int deleteId = int.Parse(_utility.GetValue("Please enter id for search"));

                            ContactEntity deleteFound = _contactService.GetById(deleteId);

                            _utility.Log("catagory found", Enums.Loger.success);

                            var sure = _utility.GetValue("are you sure for delete this catagory ? ( Y / N )");
                            sure = sure.ToLower();
                            switch (sure)
                            {
                                case "y":
                                    _contactService.Delete(deleteId);
                                    _utility.Log("Catagory delete successfully ", Enums.Loger.success);
                                    break;
                                case "n":

                                    _utility.Log("Catagory not deleted ", Enums.Loger.success);
                                    break;

                                default:
                                    Console.WriteLine("Wrong choice Please try Again.");
                                    break;
                            }
                            break;
                        case Enums.Manage.back:
                            manageBack = false;
                            break;
                        default:
                            _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                            break;
                    }
                    break;
                case Enums.Admin.manageOrders:
                    Enums.Manage manOChoice;
                    bool flagOr = true;
                    do
                    {
                        try
                        {
                            manOChoice = (Enums.Manage)_menus.ManageMenu("ordre");
                            flagOr = false;
                        }
                        catch
                        {
                            _utility.Log("Please enter number of menu !", Enums.Loger.error);
                            continue;
                        }
                        if (flagOr == true)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);
                    switch (manOChoice)
                    {
                        case Enums.Manage.add: // Add order
                            break;
                        case Enums.Manage.show://show orders
                            break;
                        case Enums.Manage.search://search order
                            break;
                        case Enums.Manage.edit://edit order
                            break;
                        case Enums.Manage.delete://delete order
                            break;
                        case Enums.Manage.back:
                            manageBack = false;
                            break;
                        default:
                            _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                            break;
                    }
                    break;
                case Enums.Admin.manageProducts:

                    Enums.Manage manPChoice;
                    bool flagPro = true;
                    do
                    {
                        try
                        {
                            manPChoice = (Enums.Manage)_menus.ManageMenu("Product");
                            flagPro = false;
                        }
                        catch
                        {
                            _utility.Log("Please enter number of menu !", Enums.Loger.error);
                            continue;
                        }
                        if (flagPro == true)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }

                    } while (true);

                    switch (manPChoice)
                    {
                        case Enums.Manage.add:

                            _utility.ShowHeader("Add product");

                            Console.WriteLine($"curent id set : {idSetProduct}");
                            Console.WriteLine();

                            var tempName = _utility.GetValue("Enter product name : ");
                            var tempPrice = decimal.Parse(_utility.GetValue("Enter product Price : "));
                            var tempEntity = int.Parse(_utility.GetValue("Enter entity of product : "));
                            var tempCatagory = int.Parse(_utility.GetValue("Enter catagory id : "));

                            ProductEntity product = new ProductEntity()
                            {
                                ProductId = idSetProduct,
                                Name = tempName,
                                Price = tempPrice,
                                Entity = tempEntity,
                                Catagory = tempCatagory
                            };

                            idSetProduct++;

                            _productServise.Add(product);

                            _utility.Log("Product added successfully . ", Enums.Loger.success);
                            break;
                        case Enums.Manage.show:

                            _utility.ShowHeader("All Products");
                            var products = _productServise.GetAll();
                            if (products == null)
                            {
                                _utility.Log("Product List is empty", Enums.Loger.error);
                                Console.ReadLine();
                                break;
                            }

                            foreach (var item in products)
                            {
                                _showItems.ShowProducts(item);
                            }

                            break;
                        case Enums.Manage.search:
                            _utility.ShowHeader("Search product");

                            int searchId;
                            
                            searchId = int.Parse(_utility.GetValue("Please enter id for search"));
                            
                            var found = _productServise.GetById(searchId);

                            _showItems.ShowProducts(found);

                            break;
                        case Enums.Manage.edit:

                            _utility.ShowHeader("edit product");

                            int editId = int.Parse(_utility.GetValue("Please enter id for search"));
                            
                            ProductEntity editFound;
                            
                            editFound = _productServise.GetById(editId);
                            
                            _utility.Log("contact found", Enums.Loger.success);

                            var tempNewName = _utility.GetValue("Enter new product name : ");
                            var tempNewPrice = decimal.Parse(_utility.GetValue("Enter new product Price : "));
                            var tempNewEntity = int.Parse(_utility.GetValue("Enter new entity of product : "));
                            var tempNewCatagory = int.Parse(_utility.GetValue("Enter new catagory id : "));

                            editFound.Name = tempNewName;
                            editFound.Price = tempNewPrice;
                            editFound.Entity = tempNewEntity;
                            editFound.Catagory = tempNewCatagory;

                            _utility.Log("Product edite successfully", Enums.Loger.success);

                            break;
                        case Enums.Manage.delete:

                            _utility.ShowHeader("Delete Product");

                            int deleteId = int.Parse(_utility.GetValue("Please enter id for search"));
                            

                            ProductEntity deleteFound = _productServise.GetById(deleteId);
                            
                            _utility.Log("contact found", Enums.Loger.success);

                            break;
                        case Enums.Manage.back:
                            manageBack = false;
                            break;
                        default:
                            _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                            break;
                    }
                    break;

                case Enums.Admin.back:
                    manageBack = false;
                    break;
                default:
                    _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                    break;
            }
        }

    }
}
