using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace Labas_4
{
    class ReadInfo
    {
        public static Phonenote[] ReadXml()
        {
            XmlSerializer xmls = new XmlSerializer(typeof(Phonenote[]));
            using (StreamReader stream = new StreamReader("info.xml"))
            {
                return (Phonenote[])xmls.Deserialize(stream);
            }
        }
        static Phonenote SplitUp(string lineWithData)
        {
            string[] array = lineWithData.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string initials = array[0]+" "+array[1];
            string phoneNumber = array[2];
            string[] data = array[3].Trim().Split('.');
            int[] dateOfBirth = { Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), Convert.ToInt32(data[2])};
            return new Phonenote(initials, phoneNumber, dateOfBirth);
        }
        public static Phonenote[] ReadTxt(string inf)
        {
            int count = System.IO.File.ReadAllLines(inf).Length;
            Phonenote[] info = new Phonenote[count];
            using (StreamReader read = new StreamReader(inf))
            {
                for (int i = 0; i < count; i++)
                {
                    info[i] = SplitUp(read.ReadLine());
                }
            }
            return info;
        }
        public static void DoPart()
        {
            Console.Clear();
            Phonenote[] info;
            string inf = "info.txt";
            Phonenote[] infoXml;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Введіть 1 щоб зчитати інформацію з txt файлу.");
            Console.WriteLine("Введіть 2 щоб зчитати інформацію з xml файлу.");
            Console.WriteLine("Введіть 0 щоб повернутись до головного меню.");
            Console.WriteLine("--------------------------------------------");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    info = ReadTxt("info.txt");
                    foreach (Phonenote obj in info)
                    {
                        Console.WriteLine(obj.ToString());
                    }
                    Console.WriteLine("Натисніть Enter щоб повернутися до головного меню.");
                    Console.ReadKey();
                    break;
                case 2:
                    infoXml = ReadXml();
                    foreach (Phonenote obj in infoXml)
                    {
                        Console.WriteLine(obj.ToString());
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