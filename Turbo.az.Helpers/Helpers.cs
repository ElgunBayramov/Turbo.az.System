using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Turbo.az.Helpers
{
    public class Helpers
    {
        public static void Init()
        {
            Console.Title = "Turbo.az";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            CultureInfo ci = new CultureInfo("az-Latn-Az");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
        public static int ReadInt(string caption, int minvalue = 0)
        {
        l1:

            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string value = Console.ReadLine();
            int number;

            if (!int.TryParse(value, out number))
            {
                PrintError("Düzgün rəqəm daxil edilməyib");
                goto l1;
            }
            else if (number < minvalue)
            {
                PrintError($"Minimal {minvalue} daxil edilə bilər");
                goto l1;
              
            }

            Console.ResetColor();
            return number;
        }

        public static double ReadDouble(string caption, double minvalue = 0)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string value = Console.ReadLine();
            double number;

            if (!double.TryParse(value, out number))
            {
                PrintError("Düzgün məlumat daxil edilməyib");
                goto l1;
            }

            else if (number < minvalue)
            {
                PrintError($"Minimal {minvalue} daxil edilə bilər");

                goto l1;
            }

            Console.ResetColor();
            return number;
        }

        public static string ReadString(string caption, bool required = false)
        {
        l1:
            Console.Write(caption);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string value = Console.ReadLine();

            if (required && string.IsNullOrWhiteSpace(value))
            {
                PrintError("Boş buraxıla bilməz ");
                goto l1;
            }

            Console.ResetColor();
            return value;
        }

        public static MenuStates ReadMenu(string caption)
        {
        l1:
            Console.Write(caption);
            string value = Console.ReadLine();
            if (!Enum.TryParse(value, out MenuStates menu))
            {
                PrintError("Belə menu mövcud deyil");
                goto l1;
            }
            bool success = Enum.IsDefined(typeof(MenuStates), menu);

            if (!success)
            {
                PrintError("Belə menu mövcud deyil");
                goto l1;
            }
            return menu;
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static DateTime ReadDate(string caption)
        {
        l1:
            Console.Write($"{caption} [yyyy]");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime value))
            {
                PrintError("Düzgün məlumat daxil edin: ");
                goto l1;
            }
            Console.ResetColor();
            return value;
        }

        public static FuelType FuelType(string caption)
        {
        l1:
            Console.Write(caption);

            if (!Enum.TryParse(Console.ReadLine(), out FuelType m))
            {
                PrintError("Yanacaq növü menusundan seçin: ");
                goto l1;
            }
            Console.ResetColor();
            return m;
        }
        public static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------Menu---------------");
            foreach(var item in Enum.GetValues(typeof(MenuStates)))
            {
                Console.WriteLine($"{((byte)item).ToString().PadLeft(2)}.{item}");
            }
            Console.WriteLine("---------------------------------");
            Console.ResetColor();
        }

    }
}