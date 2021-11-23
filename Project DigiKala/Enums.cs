using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DigiKala
{
    public class Enums
    {
        public enum Base
        {
            enterAdmin = 1,
            enterApp,
            signUp,
            exit
        }
        public enum Admin
        {
            manageContacts = 1,
            manageCatagory,
            manageOrders,
            manageProducts,
            back
        }
        public enum App
        {
            items = 1,
            search,
            cart,
            Profile,
            logout
        }
        public enum Manage
        {
            add = 1,
            show,
            search,
            edit,
            delete,
            back
        }
        public enum Catagory
        {
            food = 1,
            applinces,
            electrics,
            waer,
            other
        }
        public enum Loger
        {
            success,
            error,
            info
        }
        public enum EditOrPay
        {
            pay=1,
            edit,
            delete,
            back
        }
        public enum Sort
        {
            Pay = 1,
            NotPay,
            InPro,
            SendPO,
            SendAdr,
            back
        }
    }
}
