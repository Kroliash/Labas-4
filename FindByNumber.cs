using System;
using System.Collections.Generic;
using System.Text;

namespace Labas_4
{
    class FindByNumber
    {
        public static void DoPart()
        {
            Console.Clear();
            Phonenote[] information;
            Console.WriteLine("Введіть номер контакту, що шукаєте:");
            string phNumber = Console.ReadLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Введіть 1, щоб перевірити наявність в txt.");
            Console.WriteLine("Введіть 2,щоб перевірити наявність в xml.");
            Console.WriteLine("Введіть 0 щоб повернутись до головного меню.");
            Console.WriteLine("--------------------------------------------");
            int ch = int.Parse(Console.ReadLine());
            bool exsist = false;
            switch (ch)
            {   
                case 1:
                    information = ReadInfo.ReadTxt("info.txt");
                    foreach (Phonenote obj in information)
                    {
                        if (obj.phoneNumber == phNumber)
                        {
                            exsist = true;
                            Console.WriteLine(obj.ToString());
                        }
                    }
                    if (exsist == false)
                    {
                        Console.WriteLine("Такого номеру не існує.");
                    }
                    Console.WriteLine("Натисніть Enter щоб повернутися до головного меню.");
                    Console.ReadKey();
                    break;  
                case 2:
                    information = ReadInfo.ReadXml();
                    foreach (Phonenote obj in information)
                    {
                        if (obj.phoneNumber == phNumber)
                        {
                            exsist = true;
                            Console.WriteLine(obj.ToString());
                        }
                    }
                    if (exsist == false)
                    {
                        Console.WriteLine("Такого номеру не існує.");
                    }
                    Console.WriteLine("Натисніть Enter щоб повернутися до головного меню.");
                    Console.ReadKey();
                    break;
                case 0:
                    Console.WriteLine("Добре, повертаємось!");
                    break;
                default:
                    Console.WriteLine("Такого значення не існує, спробуйте ще раз.");
                    break;
            }
        }
    }
}