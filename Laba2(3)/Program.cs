using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_3_
{
    class Program
    {
        static void OutputWithoutOdds(int size, int[] array)
        {
            var array2 = array.Where(n => n % 2 != 0);
            foreach(int i in array2)
            {
                Console.Write(i + " ");
            }
        }
        static void Output(int size, int[] array)
        {
           for (int i = 0; i < size; i++)
           {
              Console.Write("{0} ", array[i]);
           }
        }
        static void Random(int size, int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(-10, 10);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть розмір маcиву");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];
            Console.WriteLine("Оберіть метод вводу - вручну (напишіть 1), випадкова матриця (напишіть 2) ");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
               string input = Console.ReadLine();
               array = input.Split(' ').Select(int.Parse).ToArray() ;
            }
            if (answer == "2")
            {
                Random(size, array);
            }
            else if (answer != "1" && answer != "2")
            {
                Console.WriteLine("Некорректне введення !");
                
            }
            Console.WriteLine("Отримаємо масив : ");
            Console.WriteLine();
            Output(size, array);
            Console.WriteLine("\nМасив без парних : ");
            Console.WriteLine();
            OutputWithoutOdds(size, array);
            Console.ReadKey();
        }
    }
}
