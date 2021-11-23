using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DigiKala
{
    public class Utility
    {
        public void ShowHeader(string msg)
        {
            Console.Clear();
            Console.WriteLine($"---   {msg.ToUpper()}   ---");
            Console.WriteLine();
        }
        public string GetValue(string msg)
        {
            Console.WriteLine($"{msg}");
            return Console.ReadLine();
        }
        public void Log(string msg, Enums.Loger logType)
        {
            switch (logType)
            {
                case Enums.Loger.success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(msg);
                    Console.ResetColor();
                    break;
                case Enums.Loger.error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);
                    Console.ResetColor();
                    break;
                case Enums.Loger.info:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(msg);
                    Console.ResetColor();
                    break;
            }
            Console.ReadLine();

        }
        public void ShowInfo(string msg)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----------");
            Console.WriteLine(msg);
            Console.WriteLine("-----------");
            Console.ResetColor();

        }
    }
}
