using Models;
using Service;
using System;
using System.Collections.Generic;

namespace Project_DigiKala
{
    class Program
    {
        private static ContactService _contactService { get; set; } = new ContactService();
        private static ProductService _productServise { get; set; } = new ProductService();
        private static OrderService _orderService { get; set; } = new OrderService();
        private static CatagoryService _categoryService { get; set; } = new CatagoryService();

        private static Utility _utility = new Utility();
        private static Menus _menus = new Menus();
        private static Login _login = new Login();

        public static int idSetContact = 10;
        public static int idSetProduct = 10;
        public static int idSetOrder = 10;
        public static int idSetCategory = 10;

        public static bool manageBack = true;
        public static bool manageAdminBack = true;
        public static bool manageAppBack = true;


        static void Main(string[] args)
        {
            ContactEntity contactEntity = new ContactEntity()
            {
                Name = "amir",
                Adress = "shz",
                ContactId = 1,
                OrderCounter = 0,
                PhoneNumber = "1234",
                PassWord = "amir"
            };
            _contactService.Add(contactEntity);

            CatagoryEntity catagoryEntity = new CatagoryEntity()
            {
                Id = 1,
                Name = "drinks",
                used = CatagoryEntity.Used.notused
            };
            _categoryService.Add(catagoryEntity);
            ProductEntity productEntity = new ProductEntity()
            {
                Catagory = catagoryEntity.Name,
                Entity = 10,
                Name = "soda",
                Price = 2500,
                ProductId = 1

            };

            _productServise.Add(productEntity);
            var idSetContact = 1000;
            var manageBack = true;

            while (manageBack == true)
            {
                manageBack = true;
                manageAppBack = true;
                manageAdminBack = true;

                Enums.Base choice;
                do
                {
                    bool flag = true;
                    try
                    {
                        choice = (Enums.Base)_menus.BaseMenu();
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


                switch (choice)
                {

                    case Enums.Base.enterAdmin://admin menu
                        var checkAdmin = _login.LogAdmin();
                        if (checkAdmin != true)
                        {
                            _utility.Log("Username or Password is wrong ... !", Enums.Loger.error);
                            break;
                        }
                        else
                        {
                            _utility.Log("log in . . . ", Enums.Loger.success);
                        }
                        while (manageAdminBack == true)
                        {
                            Enums.Admin choiceAdmin;
                            try
                            {
                                choiceAdmin = (Enums.Admin)_menus.AdminMenu();
                            }
                            catch
                            {
                                _utility.Log("Please enter number of menu !", Enums.Loger.error);
                                continue;
                            }

                            AdminMenu(choiceAdmin);
                        }
                        break;
                    case Enums.Base.enterApp://app menu

                        _utility.ShowHeader("Plese log in !");

                        ContactEntity found = null;
                        
                        bool flag = true;
                            
                        var tempUser = _utility.GetValue("Username :");
                        var tempPassword = _utility.GetValue("Password :");
                        var foundName = _contactService.ChekName(tempUser);
                        if (foundName == null)
                        {
                            _utility.Log("This user name not register in app ! ", Enums.Loger.error);
                        }
                        else
                        {
                            if (foundName.PassWord == tempPassword)
                            {
                                found = foundName;
                                flag = false;
                            }
                        }
                        if (flag == false)
                        {
                            _utility.Log("log in . . . ", Enums.Loger.success);
                        }
                        else
                        {
                            break;
                        }

                        while (manageAppBack == true)
                        {
                            Enums.App appChoice;
                            bool flagAppChoice = true;
                            do
                            {
                                try
                                {
                                    appChoice = (Enums.App)_menus.AppMenuByContac(found);
                                    flagAppChoice = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter number of menu !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagAppChoice == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            AppMenu(appChoice, found);
                        }
                        break;
                    case Enums.Base.signUp:
                        _utility.ShowHeader("Create Account");

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
                        if (tempPass == "")
                        {
                            _utility.Log("Password cant be blank ! ", Enums.Loger.error);
                        }
                        else
                        {
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
                            _utility.Log("Account created successfully . ", Enums.Loger.success);
                        }
                        break;
                    case Enums.Base.exit:
                        Environment.Exit(0);
                        break;
                    default:
                        _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                        break;
                }
            }

        }
        public static void AdminMenu(Enums.Admin choiceAdmin)
        {  
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
                        case Enums.Manage.add://add contact

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
                            if (tempPass == "")
                            {
                                _utility.Log("Password cant be blank ! ", Enums.Loger.error);
                            }
                            else
                            {
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
                            }
                            break;
                        case Enums.Manage.show://show contact

                            _utility.ShowHeader("All Contacts");

                            var contacts = _contactService.GetAll();

                            if (contacts.Count == 0)
                            {
                                _utility.Log("Contacts List is empty !", Enums.Loger.error);
                                break;
                            }
                            else
                            {
                                foreach (var item in contacts)
                                {
                                    ShowContacts(item);
                                }
                                Console.ReadLine();
                            }

                            break;
                        case Enums.Manage.search://search contact

                            _utility.ShowHeader("Search contact");

                            int searchId = int.Parse(_utility.GetValue("Please enter id for search"));

                            var found = _contactService.GetById(searchId);
                            if(found == null)
                            {
                                _utility.Log("Contact not found ! ", Enums.Loger.error);
                            }
                            else
                            {
                                ShowContacts(found);
                                Console.ReadLine();
                            }

                            break;
                        case Enums.Manage.edit://edit contact

                            _utility.ShowHeader("edit contact");

                            int editId = int.Parse(_utility.GetValue("Please enter id for search"));

                            ContactEntity editFound = _contactService.GetById(editId);
                            if (editFound == null)
                            {
                                _utility.Log("Contact not found ! ", Enums.Loger.error);
                            }
                            else
                            {
                                _utility.Log("contact found", Enums.Loger.success);

                                var tempNewPhoneNumber = _utility.GetValue("Enter New phone number :");
                                var tempNewAdress = _utility.GetValue("Enter New Adress : ");
                                var tempNewPass = _utility.GetValue("Enter New password : ");
                                if (tempNewPass != "")
                                {
                                    editFound.PhoneNumber = tempNewPhoneNumber;
                                    editFound.Adress = tempNewAdress;
                                    editFound.PassWord = tempNewPass;

                                    _utility.Log("contact edite successfully", Enums.Loger.success);
                                }
                                else
                                {
                                    _utility.Log("Password cant be blank ! ", Enums.Loger.error);
                                }
                            }
                            break;
                        case Enums.Manage.delete://delet contact
                            _utility.ShowHeader("Delete contact");

                            int deleteId ;
                            bool deleteChock = true;
                            do
                            {
                                try
                                {
                                    deleteId = int.Parse(_utility.GetValue("Please enter id for search"));
                                    deleteChock = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter ID (number) !", Enums.Loger.error);
                                    continue;
                                }
                                if (deleteChock == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            ContactEntity deleteFound = _contactService.GetById(deleteId);
                            if (deleteFound == null)
                            {
                                _utility.Log("Contact not found ! ", Enums.Loger.error);
                            }
                            else
                            {
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
                            }
                            break;
                        case Enums.Manage.back:
                            manageBack = false;
                            break;
                        default:
                            break;
                    }
                    break;
                case Enums.Admin.manageCatagory://manage catagory
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
                        case Enums.Manage.add://add ctagory
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
                        case Enums.Manage.show://show catagory

                            _utility.ShowHeader("all categorys");
                            var categorys = _categoryService.GetAll();
                            if (categorys.Count == 0)
                            {
                                _utility.Log("Catagory list is empty !", Enums.Loger.error);
                            }
                            else
                            {
                                foreach (var item in categorys)
                                {
                                    ShowCatagorys(item);
                                }
                                Console.ReadLine();
                            }

                            break;
                        case Enums.Manage.search://search catagory

                            _utility.ShowHeader("Search catagory");
                            int searchId ;
                            bool flagCatS = true;
                            do
                            {
                                try
                                {
                                    searchId = int.Parse(_utility.GetValue("Please enter id for search"));
                                    flagCatS = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter Id (Number) !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagCatS == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);
                            var found = _contactService.GetById(searchId);
                            if (found == null)
                            {
                                _utility.Log("Catagory Not found ! ", Enums.Loger.error);
                            }
                            else
                            {
                                ShowContacts(found);
                                Console.ReadLine();
                            }
                            break;
                        case Enums.Manage.edit://edit ctatgory
                            _utility.ShowHeader("edit catagory");

                            int editId ;
                            bool flagCatE = true;
                            do
                            {
                                try
                                {
                                    editId = int.Parse(_utility.GetValue("Please enter id for Edit"));
                                    flagCatE = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter Id (Number) !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagCatE == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            var editFound = _contactService.GetById(editId);
                            if(editFound == null)
                            {
                                _utility.Log("catagory not found", Enums.Loger.error);
                            }
                            else
                            {

                                _utility.Log("catagory found", Enums.Loger.success);

                                var tempNewName = _utility.GetValue("Enter New Name: ");

                                editFound.Name = tempNewName;

                                _utility.Log("contact edite successfully", Enums.Loger.success);
                            }
                            break;
                        case Enums.Manage.delete://delete catagory
                            _utility.ShowHeader("Delete catagory");

                            int deleteId ;
                            bool flagCatDe = true;
                            do
                            {
                                try
                                {
                                    deleteId = int.Parse(_utility.GetValue("Please enter id for search"));
                                    flagCatDe = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter Id (Number) !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagCatDe == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            CatagoryEntity deleteFound = _categoryService.GetById(deleteId);
                            var proChekCat = _productServise.GetAll();
                            bool flagChekCat = true;
                            foreach (var item in proChekCat)
                            {
                                if (deleteFound.Name == item.Catagory)
                                {
                                    flagChekCat = false;
                                }
                            }
                            if(deleteFound == null )
                            {
                                _utility.Log("Catagory not found ", Enums.Loger.error);
                            }
                            else if(flagChekCat == true)
                            {
                                _utility.Log("Catagory use in Product", Enums.Loger.error);
                            }
                            else
                            {
                                _utility.Log("catagory found", Enums.Loger.success);
                                if (deleteFound.used != CatagoryEntity.Used.used)
                                {
                                    var sure = _utility.GetValue("are you sure for delete this catagory ? ( Y / N )");
                                    sure = sure.ToLower();

                                    switch (sure)
                                    {
                                        case "y":
                                            _categoryService.Delete(deleteId);
                                            _utility.Log("Catagory delete successfully ", Enums.Loger.success);
                                            break;
                                        case "n":
                                            _utility.Log("Canaceld  deleted caragory ", Enums.Loger.error);
                                            break;
                                        default:
                                            Console.WriteLine("Wrong choice Please try Again.");
                                            break;
                                    }
                                }
                                else
                                {
                                    _utility.Log("Catagory not deleted (used in product catagory)", Enums.Loger.error);
                                }
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
                case Enums.Admin.manageOrders://manage order
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
                            _utility.ShowHeader("Add Order ;");
                            foreach (var item in _productServise.GetAll())
                            {
                                if (item.Entity != 0)
                                {
                                    ShowProducts(item);
                                }
                            }
                            int addToCart;
                            bool flagOrderAdd = true;
                            do
                            {
                                try
                                {
                                    addToCart = int.Parse(_utility.GetValue("Please Enter Id to add"));
                                    flagOrderAdd = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter number of menu !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagOrderAdd == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            var getProduct = _productServise.GetById(addToCart);
                            if(getProduct == null)
                            {
                                _utility.Log("Product not found !", Enums.Loger.error);
                            }
                            else
                            {
                                int entity;
                                int contacId;
                                bool flagAddOrderEn = true;
                                bool flagAddOrderId = true;
                                do
                                {
                                    try
                                    {
                                        entity = int.Parse(_utility.GetValue("Enter valu of product :"));
                                        flagAddOrderEn = false;
                                    }
                                    catch
                                    {
                                        _utility.Log("Please enter number !", Enums.Loger.error);
                                        continue;
                                    }
                                    if (flagAddOrderEn == true)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);
                                do
                                {
                                    try
                                    {
                                        contacId = int.Parse(_utility.GetValue("Enter id of contact :"));
                                        flagAddOrderId = false;
                                    }
                                    catch
                                    {
                                        _utility.Log("Please enter number !", Enums.Loger.error);
                                        continue;
                                    }
                                    if (flagAddOrderId == true)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                } while (true);
                                var foundContact = _contactService.GetById(contacId);
                                if (foundContact == null)
                                {
                                    _utility.Log("Contact not found ! ", Enums.Loger.error);
                                }
                                else
                                {
                                    if (entity > getProduct.Entity)
                                    {
                                        _utility.Log($"You cant buy more than {getProduct.Entity}", Enums.Loger.error);
                                        break;
                                    }
                                    else
                                    {
                                        OrderEntity order = new OrderEntity()
                                        {
                                            ProductId = getProduct.ProductId,
                                            OrderId = idSetOrder,
                                            OwnerId = foundContact.ContactId,
                                            Status = OrderEntity.status.notPay,
                                        };
                                        
                                        order.Entity += entity;
                                        foundContact.OrderCounter++;

                                        idSetOrder++;
                                        _orderService.Add(order);
                                        _utility.Log("Add to your order", Enums.Loger.success);
                                    }
                                }
                                
                            }
                            
                            break;
                        case Enums.Manage.show://show orders

                            _utility.ShowHeader("all Orders");
                            var orders = _orderService.GetAll();
                            if(orders.Count == 0)
                            {
                                _utility.Log("Order list is empty !", Enums.Loger.error);
                            }
                            else
                            {
                                var choice = (Enums.Sort)_menus.Sort("Sort By");
                                switch (choice)
                                {
                                    case Enums.Sort.Pay:
                                        _utility.ShowInfo("Pay");
                                        foreach (var item in orders)
                                        {
                                            if (item.paystatus == OrderEntity.Paystatus.pay)
                                            {
                                                ShowOrdersAdmin(item);
                                                ShowProDetails(item);
                                            }
                                        }
                                        Console.ReadLine();
                                        break;
                                    case Enums.Sort.NotPay:
                                        _utility.ShowInfo("Not Pay");
                                        foreach (var item in orders)
                                        {
                                            if (item.paystatus == OrderEntity.Paystatus.notPay)
                                            {
                                                ShowOrdersAdmin(item);
                                                ShowProDetails(item);
                                            }
                                        }
                                        Console.ReadLine();
                                        break;
                                    case Enums.Sort.InPro:
                                        _utility.ShowInfo("In Proccess");
                                        foreach (var item in orders)
                                        {
                                            if (item.Status == OrderEntity.status.inProccess)
                                            {
                                                ShowOrdersAdmin(item);
                                                ShowProDetails(item);
                                            }
                                        }
                                        Console.ReadLine();
                                        break;
                                    case Enums.Sort.SendPO:
                                        _utility.ShowInfo("Send to Post");
                                        foreach (var item in orders)
                                        {
                                            if (item.Status == OrderEntity.status.sendpost)
                                            {
                                                ShowOrdersAdmin(item);
                                                ShowProDetails(item);
                                            }
                                        }
                                        Console.ReadLine();
                                        break;
                                    case Enums.Sort.SendAdr:
                                        _utility.ShowInfo("Send to Adress");
                                        foreach (var item in orders)
                                        {
                                            if (item.Status == OrderEntity.status.sendtoAdress)
                                            {
                                                ShowOrdersAdmin(item);
                                                ShowProDetails(item);
                                            }
                                        }
                                        Console.ReadLine();
                                        break;
                                    case Enums.Sort.back:
                                        break;
                                    default:
                                        _utility.Log("Wrong Choice !", Enums.Loger.error);
                                        break;
                                }
                            }
                            
                            break;
                        case Enums.Manage.search://search order

                            _utility.ShowHeader("Search Order");
                            int searchId ;
                            bool flagSeOr = true;
                            do
                            {
                                try
                                {
                                    searchId = int.Parse(_utility.GetValue("Please enter id for search"));
                                    flagSeOr = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter ID !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagSeOr == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);
                            var found = _orderService.GetById(searchId);
                            if (found == null)
                            {
                                _utility.Log("Order not found !", Enums.Loger.error);
                            }
                            else
                            {
                                ShowOrdersAdmin(found);
                                Console.ReadLine();
                            }

                            break;
                        case Enums.Manage.edit://edit order

                            _utility.ShowHeader("edit ORder");

                            int editId ;
                            bool flagEdOr = true;
                            do
                            {
                                try
                                {
                                    editId = int.Parse(_utility.GetValue("Please enter id for search"));
                                    flagEdOr = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter number !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagEdOr == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            var editFound = _orderService.GetById(editId);
                            if(editFound == null)
                            {
                                _utility.Log("order not found", Enums.Loger.error);
                            }
                            else
                            {
                                if (editFound.paystatus == OrderEntity.Paystatus.pay)
                                {
                                    _utility.Log("Order found", Enums.Loger.success);

                                    Console.WriteLine("0. in proccess\n  1. send to post\n  2.send to adress");

                                    var statusId = int.Parse(_utility.GetValue("Enter status ID : "));

                                    switch (statusId)
                                    {
                                        case 0:
                                            editFound.Status = OrderEntity.status.inProccess;
                                            break;
                                        case 1:
                                            editFound.Status = OrderEntity.status.sendpost;
                                            break;
                                        case 2:
                                            editFound.Status = OrderEntity.status.sendtoAdress;
                                            break;
                                        default:
                                            _utility.Log("Wrong Iput for status", Enums.Loger.error);
                                            break;
                                    }
                                    _utility.Log("contact edite successfully", Enums.Loger.success);
                                }
                                else
                                {
                                    _utility.Log("Cant Edit This Order (Not pay)", Enums.Loger.error);
                                }
                            }
                            Console.ReadLine();
                            break;
                        case Enums.Manage.delete://delete order

                            _utility.Log("Cant Delete order !", Enums.Loger.error);
                            Console.ReadLine();

                            break;
                        case Enums.Manage.back:

                            manageBack = false;

                            break;
                        default:
                            _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                            break;
                    }
                    break;
                case Enums.Admin.manageProducts: // manage products

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
                        case Enums.Manage.add://add product

                            _utility.ShowHeader("Add product");

                            Console.WriteLine($"curent id set : {idSetProduct}");
                            Console.WriteLine();

                            var tempName = _utility.GetValue("Enter product name : ");

                            decimal tempPrice;
                            bool flagEntityPrice = true;
                            bool flagEntityEntity = true;
                            int tempEntity;
                            do
                            {
                                try
                                {
                                    tempPrice = decimal.Parse(_utility.GetValue("Enter product Price : "));
                                    flagEntityPrice = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter number !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagEntityPrice == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);
                            do
                            {
                                try
                                {
                                    tempEntity = int.Parse(_utility.GetValue("Enter entity of product : "));
                                    flagEntityEntity = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter number !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagEntityEntity == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);


                            var allCatgory = _categoryService.GetAll();
                            if (allCatgory.Count == 0)
                            {
                                _utility.Log("Catagory list is empty (please add catagory)",Enums.Loger.error);
                                Console.ReadLine();
                            }
                            else
                            {
                                foreach (var item in allCatgory)
                                {
                                    ShowCatagorys(item);
                                }
                                var tempCatagory = int.Parse(_utility.GetValue("Enter catagory id : "));
                                var choiceCatgory = _categoryService.GetById(tempCatagory);

                                ProductEntity product = new ProductEntity()
                                {
                                    ProductId = idSetProduct,
                                    Name = tempName,
                                    Price = tempPrice,
                                    Entity = tempEntity,
                                    Catagory = choiceCatgory.Name
                                };
                                choiceCatgory.used = CatagoryEntity.Used.used;

                                idSetProduct++;

                                _productServise.Add(product);

                                _utility.Log("Product added successfully . ", Enums.Loger.success);
                            }
                            
                            break;
                        case Enums.Manage.show: //show products

                            _utility.ShowHeader("All Products");
                            var products = _productServise.GetAll();
                            if(products.Count == 0)
                            {
                                _utility.Log("Product list is empty !", Enums.Loger.error);
                                Console.ReadLine();
                            }
                            else
                            {
                                foreach (var item in products)
                                {
                                    ShowProducts(item);
                                }
                                Console.ReadLine();
                            }

                            break;
                        case Enums.Manage.search: // search product
                            _utility.ShowHeader("Search product");

                            int searchId;
                            bool flagSePro = true;
                            do
                            {
                                try
                                {
                                    searchId = int.Parse(_utility.GetValue("Please enter id for search"));
                                    flagSePro = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter number !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagSePro == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);
                            
                            var found = _productServise.GetById(searchId);
                            if(found == null)
                            {
                                _utility.Log("Product not found !", Enums.Loger.error);
                            }
                            else
                            {
                                ShowProducts(found);
                                Console.ReadLine();
                            }

                            break;
                        case Enums.Manage.edit://edit products

                            _utility.ShowHeader("edit product");

                            int editId ;
                            bool flagEdPro = true;
                            do
                            {
                                try
                                {
                                    editId = int.Parse(_utility.GetValue("Please enter id for search"));
                                    flagEdPro = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter number !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagEdPro == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            ProductEntity editFound = _productServise.GetById(editId);
                            if(editFound == null )
                            {
                                _utility.Log("Product not found", Enums.Loger.error);
                            }
                            else
                            {
                                _utility.Log("Product found", Enums.Loger.success);

                                var tempNewName = _utility.GetValue("Enter new product name : ");
                                var tempNewPrice = decimal.Parse(_utility.GetValue("Enter new product Price : "));
                                var tempNewEntity = int.Parse(_utility.GetValue("Enter new entity of product : "));
                                var allEditCatgory = _categoryService.GetAll();
                                if (allEditCatgory == null)
                                {
                                    _utility.Log("Catagory list is empty (please add catagory)", Enums.Loger.error);
                                }
                                else
                                {
                                    foreach (var item in allEditCatgory)
                                    {
                                        ShowCatagorys(item);
                                    }
                                    var tempCatagory = int.Parse(_utility.GetValue("Enter catagory id : "));
                                    var choiceCatgory = _categoryService.GetById(tempCatagory);
                                    var tempNewCatagory = int.Parse(_utility.GetValue("Enter new catagory id : "));
                                    var ChoiceEditCat = _categoryService.GetById(tempNewCatagory);

                                    editFound.Name = tempNewName;
                                    editFound.Price = tempNewPrice;
                                    editFound.Entity = tempNewEntity;
                                    editFound.Catagory = ChoiceEditCat.Name;

                                    _utility.Log("Product edite successfully", Enums.Loger.success);
                                }
                            }
                            
                            break;
                        case Enums.Manage.delete://delete product

                            _utility.ShowHeader("Delete Product");

                            int deleteId ;
                            bool flagDePro = true;
                            do
                            {
                                try
                                {
                                    deleteId = int.Parse(_utility.GetValue("Please enter id for search"));
                                    flagDePro = false;
                                }
                                catch
                                {
                                    _utility.Log("Please enter number !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagDePro == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            ProductEntity deleteFound = _productServise.GetById(deleteId);
                            if (deleteFound.Entity != 0 )
                            {
                                _utility.Log("You cant Delete This Product (entity)", Enums.Loger.error);
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                _utility.Log("Product found", Enums.Loger.success);
                                Console.ReadLine();
                                var sure = _utility.GetValue("Are you sure for delete this product ? ( Y / N )");
                                sure = sure.ToLower();
                                switch (sure)
                                {
                                    case "y":
                                        _contactService.Delete(deleteId);
                                        _utility.Log("Product delete successfully ", Enums.Loger.success);
                                        break;
                                    case "n":

                                        _utility.Log("Product not deleted ", Enums.Loger.success);
                                        break;

                                    default:
                                        Console.WriteLine("Wrong choice Please try Again.");
                                        break;
                                }
                            }

                            

                            break;
                        case Enums.Manage.back:
                            manageAdminBack = false;
                            break;
                        default:
                            _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                            break;
                    }
                    break;

                case Enums.Admin.back:
                    manageAdminBack = false;
                    break;
                default:
                    _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                    break;
            }
        }
        public static void AppMenu(Enums.App choiceApp, ContactEntity contact)
        {
            switch (choiceApp)
            {
                case Enums.App.items://menu app show all 
                    bool flagChekProInApp = false;

                    _utility.ShowHeader("All Prdoucts ;");
                    var appProduct = _productServise.GetAll();
                    if (appProduct.Count == 0)
                    {
                        _utility.Log("Product list is empty !", Enums.Loger.error);
                    }
                    else
                    {
                        foreach (var item in appProduct)
                        {
                            if (item.Entity != 0)
                            {
                                Console.WriteLine($"Id : {item.ProductId}");
                                Console.WriteLine($"Name : {item.Name}");
                                Console.WriteLine($"Price : {item.Price}");
                                Console.WriteLine($"Catagory : {item.Catagory}");
                                Console.WriteLine("-----------------------------");
                            }
                            else
                            {
                                _utility.Log("Empty !", Enums.Loger.error);
                                flagChekProInApp = true;
                                break;
                            }
                        }
                        if (flagChekProInApp == false)
                        {
                            Console.WriteLine();
                            int addToCart;
                            bool flagAdd = true;
                            do
                            {
                                try
                                {
                                    addToCart = int.Parse(_utility.GetValue("Please Enter Id to add"));
                                    flagAdd = false;
                                }
                                catch
                                {
                                    _utility.Log("Please Enter id !", Enums.Loger.error);
                                    continue;
                                }
                                if (flagAdd == true)
                                {
                                    continue;
                                }
                                else
                                {
                                    break;
                                }

                            } while (true);

                            var getProduct = _productServise.GetById(addToCart);// greftn moshakhasat product
                            if (getProduct == null)
                            {
                                _utility.Log("Product not found !", Enums.Loger.error);
                            }
                            else
                            {
                                var getListProduct = _productServise.GetByList(addToCart);
                                if (getListProduct.Count == 0)
                                {
                                    _utility.Log("Product List is empty !", Enums.Loger.error);
                                }
                                else
                                {
                                    int entity;//tedad
                                    bool flagEntity = true;
                                    do
                                    {
                                        try
                                        {
                                            entity = int.Parse(_utility.GetValue("How mouch you want ?"));
                                            flagEntity = false;
                                        }
                                        catch
                                        {
                                            _utility.Log("Please Enter number you want !", Enums.Loger.error);
                                            continue;
                                        }
                                        if (flagEntity == true)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            break;
                                        }

                                    } while (true);

                                    if (entity > getProduct.Entity)// shart tedad
                                    {
                                        _utility.Log($"You cant buy more than {getProduct.Entity}", Enums.Loger.error);
                                        break;
                                    }
                                    else
                                    {
                                        OrderEntity order = new OrderEntity()
                                        {
                                            paystatus = OrderEntity.Paystatus.notPay,
                                            OwnerId = contact.ContactId,
                                            Status = OrderEntity.status.notPay,
                                            OrderId = idSetOrder,
                                            ProductId = getProduct.ProductId,
                                        };

                                        order.Entity += entity;
                                        contact.OrderCounter++;
                                        getProduct.Entity -= entity;


                                        idSetOrder++;
                                        _orderService.Add(order);
                                        _utility.Log("Add to your order", Enums.Loger.success);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case Enums.App.search://app menu search

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
                            _utility.Log("Please enter Id for search !", Enums.Loger.error);
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
                    if (found == null)
                    {
                        _utility.Log("Product not found", Enums.Loger.error);
                    }
                    else
                    {
                        Console.WriteLine($"Id : {found.ProductId}");
                        Console.WriteLine($"Name : {found.Name}");
                        Console.WriteLine($"Price : {found.Price}");
                        Console.WriteLine($"Catagory : {found.Catagory}");
                        Console.ReadLine();
                    }

                    break;
                case Enums.App.Profile: //app manage profile
                    _utility.ShowHeader("Edit profile");

                    var tempNewAddress = _utility.GetValue("New Adress :");
                    var tempNewPhoneNummber = _utility.GetValue("New phone number :");
                    var tempNewPass = _utility.GetValue("New password");
                    if (tempNewPass != "")
                    {
                        contact.Adress = tempNewAddress;
                        contact.PhoneNumber = tempNewPhoneNummber;
                        contact.PassWord = tempNewPass;
                        _utility.Log("Account information changed .", Enums.Loger.success);
                    }
                    else
                    {
                        _utility.Log("Password cant be blank ! ", Enums.Loger.error);
                    }

                    break;
                case Enums.App.cart: // order list

                    _utility.ShowHeader("Order List");

                    if (contact.OrderCounter != 0)
                    {
                        var orderFounds = _orderService.GetAll();
                        foreach (var item in orderFounds)
                        {
                            if (item.paystatus == OrderEntity.Paystatus.notPay)
                            {
                                ShowOrders(item, contact);
                                if (item.OwnerId == contact.ContactId)
                                {
                                    ShowProDetails(item);
                                    Console.WriteLine();
                                }
                                else
                                {
                                    _utility.Log("Empty list !", Enums.Loger.error);
                                }
                            }
                        }

                        int choiceF;
                        bool flagCart = true;
                        do
                        {
                            try
                            {
                                choiceF = int.Parse(_utility.GetValue("Enter your order id to Choce :"));
                                flagCart = false;
                            }
                            catch
                            {
                                _utility.Log("Please enter number !", Enums.Loger.error);
                                continue;
                            }
                            if (flagCart == true)
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }

                        } while (true);
                        var foundF = _orderService.GetById(choiceF);
                        if (foundF != null)
                        {
                            Enums.EditOrPay choiceEditOrPay = (Enums.EditOrPay)_menus.EditOrPay("pay / edit / delete ");

                            switch (choiceEditOrPay)
                            {
                                case Enums.EditOrPay.pay:
                                    _utility.ShowHeader("Pay");
                                    var sure = _utility.GetValue("Are you sure for buy these products ? ( Y / N )");
                                    switch (sure.ToLower())
                                    {
                                        case "y":
                                            var confirmPass = _utility.GetValue("Plese Enter you pass word again :");
                                            if (contact.PassWord == confirmPass)
                                            {
                                                foundF.paystatus = OrderEntity.Paystatus.pay;
                                                foundF.Status = OrderEntity.status.inProccess;
                                                _utility.Log("Order Payment successfully ", Enums.Loger.success);
                                            }
                                            else
                                            {
                                                _utility.Log("Order Cancel (Wrong Password) ", Enums.Loger.error);
                                            }
                                            break;
                                        case "n":
                                            _utility.Log("Order Cancel ", Enums.Loger.error);
                                            break;
                                        default:
                                            _utility.Log("Wrong Choice", Enums.Loger.error);
                                            break;

                                    }
                                    break;
                                case Enums.EditOrPay.edit:
                                    _utility.ShowHeader("Edit");

                                    var orderFoundsEdit = _orderService.GetAll();
                                    foreach (var item in orderFoundsEdit)
                                    {
                                        ShowOrders(item, contact);
                                        if (item.OwnerId == contact.ContactId && item.paystatus == OrderEntity.Paystatus.notPay)
                                        {
                                            ShowProDetails(item);
                                        }
                                        else
                                        {
                                            _utility.Log("Empty list !", Enums.Loger.error);
                                        }
                                    }

                                    var ChoiceEdit = int.Parse(_utility.GetValue("Enter Order id : "));
                                    var foundForEdit = _orderService.GetById(ChoiceEdit);
                                    var editEntity = _productServise.GetById(foundForEdit.ProductId);
                                    var tempEntity = int.Parse(_utility.GetValue("Enter new entity : "));
                                    editEntity.Entity += foundForEdit.Entity;
                                    editEntity.Entity -= tempEntity;
                                    foundForEdit.Entity = tempEntity;

                                    break;
                                case Enums.EditOrPay.delete:
                                    var orderFoundsDelete = _orderService.GetAll();
                                    foreach (var item in orderFoundsDelete)
                                    {
                                        ShowOrders(item, contact);
                                        if (item.OwnerId == contact.ContactId && item.paystatus == OrderEntity.Paystatus.notPay)
                                        {
                                            ShowProDetails(item);
                                        }
                                        else
                                        {
                                            _utility.Log("Empty list !", Enums.Loger.error);
                                        }
                                    }
                                    var ChoiceDelete = int.Parse(_utility.GetValue("Enter Order id : "));
                                    var foundForDelete = _orderService.GetById(ChoiceDelete);
                                    if (foundForDelete != null)
                                    {
                                        var sureDelete = _utility.GetValue("Are you sure for Delete these order ? ( Y / N )");
                                        switch (sureDelete.ToLower())
                                        {
                                            case "y":
                                                _orderService.Delete(foundForDelete.OrderId);
                                                _utility.Log("Order Deleted . ", Enums.Loger.success);
                                                break;
                                            case "n":
                                                _utility.Log("Order not Delete ", Enums.Loger.error);
                                                break;
                                            default:
                                                _utility.Log("Wrong Choice", Enums.Loger.error);
                                                break;
                                        }

                                    }
                                    else
                                    {
                                        _utility.Log("Order not found !", Enums.Loger.error);
                                    }

                                    break;
                                case Enums.EditOrPay.back:
                                    break;
                                default:
                                    _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                                    break;
                            }
                        }
                        else
                        {
                            _utility.Log("Order not found !", Enums.Loger.error);
                        }
                    
                    }
                    else
                    {
                        _utility.Log("Order List is empty ! ", Enums.Loger.error);
                    }
                    
                    break;
            case Enums.App.logout:
            manageAppBack = false;
                break;
            default:
                _utility.Log("Wrong choice . . .! ", Enums.Loger.error);
                break;
            }
        }
        public static void ShowProducts(ProductEntity product)
        {
            Console.WriteLine($"Id : {product.ProductId}");
            Console.WriteLine($"Name : {product.Name}");
            Console.WriteLine($"Price : {product.Price}");
            Console.WriteLine($"Catagory : {product.Catagory}");
            Console.WriteLine("-----------------------------");
        }
        public static void ShowContacts(ContactEntity contact)
        {
            Console.WriteLine($"Id : {contact.ContactId}");
            Console.WriteLine($"Name : {contact.Name}");
            Console.WriteLine($"Phone number : {contact.PhoneNumber}");
            Console.WriteLine($"Adress : {contact.Adress}");
            Console.WriteLine($"Orders : {contact.OrderCounter}");
            Console.WriteLine($"Pass : {contact.PassWord}");
            Console.WriteLine("--------------------------");
        }
        public static void ShowOrders(OrderEntity order, ContactEntity contact)
        {
            Console.WriteLine($"Order Id : {order.OrderId}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Order By : {contact.Name}");
            Console.WriteLine($"Phone number : {contact.PhoneNumber}");
            Console.WriteLine($"Adress : {contact.Adress}");
            Console.WriteLine("-----------------------------");
        }
        public static void ShowProDetails (OrderEntity product)
        {
            var proFound = _productServise.GetAll();

            foreach (var item in proFound)
            {
                if (product.ProductId == item.ProductId)
                {
                    Console.WriteLine($"Name : {item.Name}");
                    Console.WriteLine($"Price : {item.Price}");
                    Console.WriteLine($"Entity : {product.Entity}");
                    Console.WriteLine($"Catagory : {item.Catagory}");
                    Console.WriteLine($"Summ : {product.Entity * item.Price}");
                    Console.WriteLine("------------------------------");
                }
            }
        }
        public static void ShowOrdersAdmin(OrderEntity order)
        {
            Console.WriteLine($"Id : {order.OrderId}");
            Console.WriteLine($"Owner : {order.OwnerId}");
            Console.WriteLine($"Product : {order.ProductId}");
            Console.WriteLine($"Status : {order.Status}");
            Console.WriteLine($"Entity of product : {order.Entity}");
            Console.WriteLine($"Pay satus : {order.paystatus}");
        }
        public static void ShowCatagorys(CatagoryEntity catagory)
        {
            Console.WriteLine($"Id : {catagory.Id}({catagory.used})");
            Console.WriteLine($"Name : {catagory.Name}");
            Console.WriteLine("---------------------------");
        }

    }
}

