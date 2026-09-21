namespace Bubnov
{
    class Program
    {
        static void Main()
        {
            Car bmw = new Car("BMW", "M5", 2022, 120);
            Car merc = new Car("Mercedes", "E", 2023, 150);

            ShowModel(bmw);
            ShowModel(merc);

            bmw.Speed = 200;
            Console.WriteLine("Скорость BMW изменена:");
            ShowModel(bmw);

            bmw.Accelerate(50);
            Console.WriteLine("BMW ускорилась:");
            ShowModel(bmw);

            Console.ReadLine();
        }

        public static void ShowModel(Car car)
        {
            Console.WriteLine("Марка: " + car.Brand);
            Console.WriteLine("Модель: " + car.Model);
            Console.WriteLine("Год: " + car.Year);
            Console.WriteLine("Скорость: " + car.Speed + " км/ч");
            Console.ReadLine();
        }
    }

    class Car
    {
        private string brand;
        private string model;
        private int year;
        private int speed;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int Speed
        {
            get { return speed; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Скорость не может быть отрицательной!");
                }
                else
                {
                    speed = value;
                }
            }
        }

        public Car(string brand, string model, int year, int speed)
        {
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.Speed = speed;
        }

        public void Accelerate(int value)
        {
            Speed = Speed + value;
        }
    }
}
