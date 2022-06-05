using System;
using System.IO;
using System.Xml.Serialization;

namespace Labas_4
{
    class WriteInfo
    {
        static void AddXml(Phonenote[] info)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(Phonenote[]));
            using (FileStream stream = new FileStream("info.xml", FileMode.Create))
            {
                xmls.Serialize(stream, info);
            }
        }
        static void AddTxt(Phonenote[] info)
        {
            using (FileStream stream = new FileStream("info.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    foreach (Phonenote obj in info)
                    {
                        sw.WriteLine(obj.initials + " " + obj.phoneNumber + " " + obj.dateOfBirth[0] + "." + obj.dateOfBirth[1] + "." + obj.dateOfBirth[2]);
                    }
                }
            }
        }
        static Phonenote ReadFromKeyboard()
        {
            Console.WriteLine();
            Console.WriteLine("Введіть прізвище та ім'я контакту:");
            string initials = Console.ReadLine();
            Console.WriteLine("Введіть номер телефону контакта:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Введіть дату народження в форматі dd.mm.yy:");
            string[] data = Console.ReadLine().Trim().Split('.');
            int[] dateOfBirth = {Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), Convert.ToInt32(data[2])};
            return new Phonenote(initials, phoneNumber, dateOfBirth);
        }
        public static void DoPart()
        {
            Console.Clear();
            Console.WriteLine("Введіть кількість контактів, які записуватимуться:");
            int n = int.Parse(Console.ReadLine());
            Phonenote[] info = new Phonenote[n];
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = ReadFromKeyboard();
            }
            Array.Sort(info);
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Введіть 1 щоб записати данні у txt.");
            Console.WriteLine("Введіть 2 щоб записати данні у xml.");
            Console.WriteLine("Введіть 0 щоб повернутись до головного меню.");
            Console.WriteLine("-------------------------------------------");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    AddTxt(info);
                    break;
                case 2:
                    AddXml(info);
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