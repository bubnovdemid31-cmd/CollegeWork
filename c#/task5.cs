
using System;

namespace Demid
{
    struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point point)
        {
            double dx = point.X - X;
            double dy = point.Y - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    struct Rectangle
    {
        public double Width;
        public double Height;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return (Width + Height) * 2;
        }
    }

    struct Book
    {
        public string Title;
        public string Author;
        public int Year;

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public string GetInfo()
        {
            return $"{Title}, автор: {Author}, год: {Year}";
        }
    }

    struct ComplexNumber
    {
        public double Real;
        public double Imag;

        public ComplexNumber(double real, double imag)
        {
            Real = real;
            Imag = imag;
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Imag + b.Imag);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real - b.Real, a.Imag - b.Imag);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double real = a.Real * b.Real - a.Imag * b.Imag;
            double imag = a.Real * b.Imag + a.Imag * b.Real;

            return new ComplexNumber(real, imag);
        }

        public override string ToString()
        {
            if (Imag >= 0)
                return $"{Real} + {Imag}i";

            return $"{Real} - {Math.Abs(Imag)}i";
        }
    }

    struct Color
    {
        public byte R;
        public byte G;
        public byte B;

        public Color(byte red, byte green, byte blue)
        {
            R = red;
            G = green;
            B = blue;
        }

        public string ToHex()
        {
            return $"#{R:X2}{G:X2}{B:X2}";
        }
    }

    struct SimpleDate
    {
        public int Day;
        public int Month;
        public int Year;

        public SimpleDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public bool IsLeapYear()
        {
            if (Year % 400 == 0)
                return true;

            if (Year % 100 == 0)
                return false;

            return Year % 4 == 0;
        }
    }

    struct Vector2D
    {
        public double X;
        public double Y;

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector2D Normalize()
        {
            double length = Length();

            if (length == 0)
                return new Vector2D(0, 0);

            return new Vector2D(X / length, Y / length);
        }

        public double Dot(Vector2D vector)
        {
            return X * vector.X + Y * vector.Y;
        }

        public override string ToString()
        {
            return $"({X:F2}; {Y:F2})";
        }
    }

    struct Money
    {
        public long Rubles;
        public byte Kopecks;

        public Money(long rubles, byte kopecks)
        {
            Rubles = rubles + kopecks / 100;
            Kopecks = (byte)(kopecks % 100);
        }

        private long TotalKopecks
        {
            get { return Rubles * 100 + Kopecks; }
        }

        private static Money FromKopecks(long amount)
        {
            return new Money(amount / 100, (byte)(Math.Abs(amount) % 100));
        }

        public Money Add(Money money)
        {
            return FromKopecks(TotalKopecks + money.TotalKopecks);
        }

        public Money Subtract(Money money)
        {
            return FromKopecks(TotalKopecks - money.TotalKopecks);
        }

        public static bool operator >(Money a, Money b)
        {
            return a.TotalKopecks > b.TotalKopecks;
        }

        public static bool operator <(Money a, Money b)
        {
            return a.TotalKopecks < b.TotalKopecks;
        }

        public override string ToString()
        {
            return $"{Rubles} руб. {Kopecks:D2} коп.";
        }
    }

    struct Triangle
    {
        public Point A;
        public Point B;
        public Point C;

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double SideAB()
        {
            return A.DistanceTo(B);
        }

        public double SideBC()
        {
            return B.DistanceTo(C);
        }

        public double SideCA()
        {
            return C.DistanceTo(A);
        }

        public double GetPerimeter()
        {
            return SideAB() + SideBC() + SideCA();
        }

        public double GetArea()
        {
            double half = GetPerimeter() / 2;

            return Math.Sqrt(
                half *
                (half - SideAB()) *
                (half - SideBC()) *
                (half - SideCA())
            );
        }
    }

    struct Point3D
    {
        public double X;
        public double Y;
        public double Z;

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double DistanceTo(Point3D point)
        {
            double dx = point.X - X;
            double dy = point.Y - Y;
            double dz = point.Z - Z;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Практическая работа: структуры C#");
            Console.WriteLine();

            Console.WriteLine("Уровень 1");

            Point first = new Point(1, 2);
            Point second = new Point(4, 6);

            Console.WriteLine($"1. Расстояние между точками: {first.DistanceTo(second):F2}");

            Rectangle rectangle = new Rectangle(5, 8);

            Console.WriteLine($"2. Площадь: {rectangle.GetArea()}, периметр: {rectangle.GetPerimeter()}");

            Book book = new Book("Мастер и Маргарита", "Михаил Булгаков", 1967);

            Console.WriteLine($"3. {book.GetInfo()}");

            Console.WriteLine();
            Console.WriteLine("Уровень 2");

            ComplexNumber number1 = new ComplexNumber(4, 3);
            ComplexNumber number2 = new ComplexNumber(2, -1);

            Console.WriteLine($"4. ({number1}) * ({number2}) = {number1 * number2}");

            Color color = new Color(138, 43, 226);

            Console.WriteLine($"5. HEX цвет: {color.ToHex()}");

            SimpleDate date = new SimpleDate(1, 1, 2024);

            Console.WriteLine($"6. {date.Year} - високосный год: {date.IsLeapYear()}");

            Console.WriteLine();
            Console.WriteLine("Уровень 3");

            Vector2D vector = new Vector2D(3, 4);

            Console.WriteLine($"7. Вектор {vector}, длина: {vector.Length()}, нормализация: {vector.Normalize()}");

            Money money1 = new Money(150, 70);
            Money money2 = new Money(49, 50);

            Console.WriteLine($"8. {money1} - {money2} = {money1.Subtract(money2)}");
            Console.WriteLine($"Первое значение больше второго: {money1 > money2}");

            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(0, 3),
                new Point(4, 0)
            );

            Console.WriteLine($"9. Периметр: {triangle.GetPerimeter()}, площадь: {triangle.GetArea()}");

            Point3D point1 = new Point3D(1, 2, 3);
            Point3D point2 = new Point3D(4, 6, 8);

            Console.WriteLine($"10. Расстояние в 3D: {point1.DistanceTo(point2):F2}");

            Console.WriteLine();
            Console.WriteLine("Все задания выполнены.");
        }
    }
}
