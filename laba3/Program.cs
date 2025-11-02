using System;
using System.Text;

namespace PracticalWork
{
    class Program
    {
      
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть верхню межу n: ");
            int n = int.Parse(Console.ReadLine());

            // Викликаємо методи для пошуку та друку чисел
            PrintAllPerfectNumbers(n);
            PrintAllAmicableNumbersPairs(n);

            // Чекаємо натискання клавіші, щоб консоль не закрилася
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }

       
        static int CalcSumOfDivisors(int number)
        {
            int sum = 0;
            // цикл починається з 1
            // Цикл іде до number / 2, бо найбільший дільник (крім самого числа) не може бути більшим за його половину
            for (int i = 1; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

       
        /// 2. Тут виводить всі досконалі числа в діапазоні [2, n].
        /// Досконале число - це число, що дорівнює сумі своїх дільників.
       
        static void PrintAllPerfectNumbers(int n)
        {
            Console.WriteLine($"\n Досконалі числа в діапазоні [2, {n}] ");
            for (int i = 2; i <= n; i++)
            {
                // Якщо число дорівнює сумі своїх дільників - воно досконале
                if (i == CalcSumOfDivisors(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

  
        /// 3. Виводить всі пари дружніх чисел в діапазоні [2, n].
        /// Дружні числа - це пара (a, b), де сума дільників a = b, а сума дільників b = a.
        
        static void PrintAllAmicableNumbersPairs(int n)
        {
            Console.WriteLine($"\n Дружні пари чисел в діапазоні [2, {n}] ");
            for (int a = 2; a <= n; a++)
            {
                int b = CalcSumOfDivisors(a);

                // Умови для дружньої пари:
                // 1. a < b: щоб уникнути дублікатів (b, a) та само-пар (a, a)
                // 2. b <= n: переконуємось, що друге число також в нашому діапазоні
                if (a < b && b <= n)
                {
                    // Перевіряємо зворотну умову: сума дільників b має дорівнювати a
                    if (CalcSumOfDivisors(b) == a)
                    {
                        Console.WriteLine($"({a}, {b})");
                    }
                }
            }
        }
    }
}