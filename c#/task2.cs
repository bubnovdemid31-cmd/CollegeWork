using System;
using System.Collections.Generic;

namespace OOP_IT_SOIP_25_P2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie inception = new Movie("мстители финал", 148);
            Movie matrix = new Movie("Человек паук совершенно новый день", 136);
            Movie interstellar = new Movie("Интерстеллар", 169);

            CinemaHall hall = new CinemaHall(10);

            BookingService service = new BookingService(hall);
            service.AddMovie(inception);
            service.AddMovie(matrix);
            service.AddMovie(interstellar);

            Customer customer = new Customer("Иван");

            service.ShowMovies();

            Console.Write("Выберите номер фильма: ");
            int movieIndex = int.Parse(Console.ReadLine());

            hall.ShowScheme();

            Console.Write("Выберите номер места: ");
            int seatNumber = int.Parse(Console.ReadLine());

            service.Book(movieIndex, seatNumber, customer);

            hall.ShowScheme();

            customer.ShowBookings();
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public int Duration { get; set; }

        public Movie(string title, int duration)
        {
            Title = title;
            if (duration <= 0) Duration = 0;
            else Duration = duration;
        }
    }

    public class Seat
    {
        public int Number { get; set; }
        public bool IsReserved { get; private set; }

        public Seat(int number)
        {
            Number = number;
            IsReserved = false;
        }

        public bool Reserve()
        {
            if (IsReserved)
            {
                Console.WriteLine($"Место {Number} уже занято!");
                return false;
            }
            IsReserved = true;
            return true;
        }
    }

    public class CinemaHall
    {
        private List<Seat> seats = new List<Seat>();

        public CinemaHall(int seatCount)
        {
            for (int i = 1; i <= seatCount; i++)
            {
                seats.Add(new Seat(i));
            }
        }

        public Seat GetSeat(int number)
        {
            foreach (var seat in seats)
            {
                if (seat.Number == number)
                    return seat;
            }
            return null;
        }

        public void ShowScheme()
        {
            Console.WriteLine("Схема зала ([N] — свободно, [X] — занято):");
            foreach (var seat in seats)
            {
                if (seat.IsReserved)
                    Console.Write($"[{seat.Number} X] ");
                else
                    Console.Write($"[{seat.Number}] ");
            }
            Console.WriteLine();
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public List<string> Bookings { get; private set; }

        public Customer(string name)
        {
            Name = name;
            Bookings = new List<string>();
        }

        public void ShowBookings()
        {
            Console.WriteLine($"Брони клиента {Name}:");
            if (Bookings.Count == 0)
            {
                Console.WriteLine("  (нет броней)");
                return;
            }
            foreach (var b in Bookings)
            {
                Console.WriteLine("  " + b);
            }
        }
    }

    public class BookingService
    {
        private CinemaHall hall;
        private List<Movie> movies = new List<Movie>();

        public BookingService(CinemaHall hall)
        {
            this.hall = hall;
        }

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
            Console.WriteLine($"Фильм \"{movie.Title}\" добавлен");
        }

        public void ShowMovies()
        {
            Console.WriteLine("Доступные фильмы:");
            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {movies[i].Title} ({movies[i].Duration} мин)");
            }
        }

        public void Book(int movieIndex, int seatNumber, Customer customer)
        {
            int i = movieIndex - 1;
            if (i < 0 || i >= movies.Count)
            {
                Console.WriteLine("Неверный номер фильма!");
                return;
            }

            Seat seat = hall.GetSeat(seatNumber);
            if (seat == null)
            {
                Console.WriteLine("Неверный номер места!");
                return;
            }

            bool ok = seat.Reserve();
            if (!ok) return;

            Movie movie = movies[i];
            string booking = $"\"{movie.Title}\" — место {seat.Number}";
            customer.Bookings.Add(booking);

            Console.WriteLine($"Бронь оформлена: {booking}");
        }
    }
}
