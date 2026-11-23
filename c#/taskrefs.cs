using System;

class Program1
{
    static void Main()
    {
        int x = 10;
        int y = 20;
        Console.WriteLine($"Исходные значения: x = {x}, y = {y}");
        SwapWithoutRef(x, y);
        Console.WriteLine($"После SwapWithoutRef: x = {x}, y = {y}");
        SwapWithRef(ref x, ref y);
        Console.WriteLine($"После SwapWithRef: x = {x}, y = {y}");
    }
    static void SwapWithoutRef(int a, int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void SwapWithRef(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
class Person
{
    public string Name { get; set; }
    public int? Age { get; set; }
}

class Program2
{
    static void ResetPersonWithoutRef(Person person)
    {
        person = null;
        Console.WriteLine("Внутри ResetPersonWithoutRef: person установлен в null.");
    }

    static void ResetPersonWithRef(ref Person person)
    {
        person = null;
        Console.WriteLine("Внутри ResetPersonWithRef: person установлен в null.");
    }

    static void Main()
    {
        Person person1 = new Person { Name = "Алексей", Age = 30 };
        Person person2 = new Person { Name = "Мария", Age = 25 };

        Console.WriteLine("Исходные данные:");
        Console.WriteLine($"Name: {person1.Name}, Age: {person1.Age}");
        Console.WriteLine($"Name: {person2.Name}, Age: {person2.Age}");

        Console.WriteLine("\n--- Попытка сброса БЕЗ ref ---");
        ResetPersonWithoutRef(person1);

        if (person1 != null)
            Console.WriteLine($"person1 не null: Name: {person1.Name}, Age: {person1.Age}");
        else
            Console.WriteLine("person1 is null");

        Console.WriteLine("\n--- Попытка сброса С ref ---");
        ResetPersonWithRef(ref person2);

        if (person2 != null)
            Console.WriteLine($"person2 не null: Name: {person2.Name}, Age: {person2.Age}");
        else
            Console.WriteLine("person2 is null : Name: null, Age: null;");

        Console.WriteLine("\n--- Изменение состояния объекта (без ref) ---");
        Person person3 = new Person { Name = "Петр", Age = 30 };
        Console.WriteLine($"Name: {person3.Name}, Age: {person3.Age}");
    }
}
