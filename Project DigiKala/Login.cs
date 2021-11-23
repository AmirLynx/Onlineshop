using System;
using Service;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DigiKala
{
    public class Login
    {
        private static ContactService _contactService { get; set; } = new ContactService();
        private static Utility _utility = new Utility();
        public bool LogAdmin()
        {
            _utility.ShowHeader("Please log in !");

            string User = "admin", pass = "admin";

            bool flag = false;

            var tempUser = _utility.GetValue("Enter Admin username :");
            var tempPass = _utility.GetValue("Enter Admin password :");

            if (tempUser == User)
            {
                if (tempPass == pass)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}
