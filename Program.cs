using System;

namespace Labas_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("Введіть 1 для вводу інформації та її збереження в txt та xml файли.");
                Console.WriteLine("Введіть 2 для виводу інформації з txt або xml файлу.");
                Console.WriteLine("Введіть 3 для виводу інформації за номером телефону.");
                Console.WriteLine("Введіть 0 щоб завершити роботу програми.");
                Console.WriteLine("------------------------------------------------------------------------");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        WriteInfo.DoPart();
                        break;
                    case 2:
                        ReadInfo.DoPart();
                        break;
                    case 3:
                        FindByNumber.DoPart();
                        break;
                    case 0:
                        Console.WriteLine("Добре, завершую!");
                        break;
                    default:
                        Console.WriteLine("Такого значення не існує, спробуйте ще раз.");
                        break;
                }

            } while (choice != 0);
        }
    }
}