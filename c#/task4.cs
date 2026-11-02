
using System;
using System.Globalization;

namespace Demid
{
    abstract class Delivery
    {
        protected string name;
        protected decimal price;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не может быть пустым");

                if (value.Length > 20)
                    throw new ArgumentException("Название слишком длинное");

                name = value;
            }
        }

        public decimal Price
        {
            get { return price; }
        }

        public Delivery(string deliveryName)
        {
            Name = deliveryName;
        }

        public abstract void CalculatePrice(decimal cost);

        public override string ToString()
        {
            return $"Доставка: {Name} | Стоимость: {Price:C}";
        }
    }

    class StandardDelivery : Delivery
    {
        public StandardDelivery(string name) : base(name)
        {
        }

        public override void CalculatePrice(decimal cost)
        {
            price = cost;
        }
    }

    class ExpressDelivery : Delivery
    {
        public ExpressDelivery(string name) : base(name)
        {
        }

        public override void CalculatePrice(decimal cost)
        {
            price = cost * 2.5m;
        }
    }

    class InternationalDelivery : Delivery
    {
        public InternationalDelivery(string name) : base(name)
        {
        }

        public override void CalculatePrice(decimal cost)
        {
            price = cost * 4m;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Расчет стоимости доставки");
            Console.WriteLine();

            decimal cost = ReadPrice();

            Delivery[] deliveries = new Delivery[3];

            deliveries[0] = CreateDelivery("обычной");
            deliveries[1] = CreateDelivery("быстрой");
            deliveries[2] = CreateDelivery("международной");

            Console.WriteLine();
            Console.WriteLine("Результаты:");

            foreach (Delivery item in deliveries)
            {
                item.CalculatePrice(cost);
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static decimal ReadPrice()
        {
            decimal result;

            while (true)
            {
                Console.Write("Введите начальную стоимость: ");
                string input = Console.ReadLine();

                bool correct = decimal.TryParse(
                    input,
                    NumberStyles.Any,
                    CultureInfo.CurrentCulture,
                    out result
                );

                if (!correct)
                {
                    correct = decimal.TryParse(
                        input,
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out result
                    );
                }

                if (correct && result >= 0)
                {
                    return result;
                }

                Console.WriteLine("Неверное число, попробуйте снова.");
            }
        }

        static Delivery CreateDelivery(string type)
        {
            while (true)
            {
                Console.Write($"Введите название {type} доставки: ");
                string title = Console.ReadLine();

                try
                {
                    if (type == "обычной")
                    {
                        return new StandardDelivery(title);
                    }
                    else if (type == "быстрой")
                    {
                        return new ExpressDelivery(title);
                    }
                    else if (type == "международной")
                    {
                        return new InternationalDelivery(title);
                    }
                    else
                    {
                        throw new ArgumentException("Неизвестная доставка");
                    }
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine("Ошибка: " + error.Message);
                }
            }
        }
    }
}
