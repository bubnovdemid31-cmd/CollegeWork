using System;
namespace demid
{
    class Box <T>
    {
        public T value;
        public void Put(T item)
        {
            value = item;
        }
        public T Get()
        {
            return value;
        }
        
    }
    class Utils
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
    class Pair<T1, T2>
    {
        public T1 First;
        public T2 Second;
        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Box<int> number = new Box<int>();
            number.Put(42);
            Box<string> text = new Box<string>();
            text.Put("Привет");
            Console.WriteLine("Число в коробке:" + number.Get());
            Console.WriteLine("Слово в коробке:" + text.Get());
            Console.WriteLine();
            int a = 3;
            int b= 4;
            Utils.Swap(ref a, ref b);
            Console.WriteLine($"Числа после swap {a}, {b}");
            string word1 = "привет";
            string word2 = "мир";
            Utils.Swap(ref word1, ref word2);
            Console.WriteLine($"Слова после swap {word1}, {word2}");
            Console.WriteLine();
            Pair<int, string> pair = new Pair<int, string>(17, "Демид");
            Console.WriteLine($"Меня зовут - {pair.Second}, и мне {pair.First} лет");
            Console.ReadLine();
        }
    }
}
