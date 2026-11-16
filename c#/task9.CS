using System;

namespace lecture
{
    internal class case1
    {
        unsafe static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            Console.Write("До: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
            int num = 67;
            int* ptr = &num;
            Console.WriteLine($"{(ulong)ptr}");


            fixed (int* p = numbers)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    *(p + i) += 10;
                }
            }

            Console.Write("После: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
    internal class case2
    {
        unsafe static void Main(string[] args)
        {
            int x = 50;

            int* p = &x;
            int** pp = &p;

            Console.WriteLine("Адрес x: 0x" + ((ulong)&x).ToString("X"));
            Console.WriteLine("Адрес p: 0x" + ((ulong)&p).ToString("X"));
            Console.WriteLine("Значение x до: " + x);

            **pp = 999;

            Console.WriteLine("Значение x после изменения через **pp: " + x);
        }
    }
}
