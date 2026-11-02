
using System;
using System.Collections.Generic;

namespace NotificationSystem
{
    interface INotifier
    {
        void Send(string text);
    }

    class EmailNotifier : INotifier
    {
        public void Send(string text)
        {
            Console.WriteLine("[Email] Письмо отправлено: " + text);
        }
    }

    class SmsNotifier : INotifier
    {
        public void Send(string text)
        {
            Console.WriteLine("[SMS] Сообщение отправлено: " + text);
        }
    }

    class TelegramNotifier : INotifier
    {
        public void Send(string text)
        {
            Console.WriteLine("[Telegram] Сообщение отправлено: " + text);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Напишите сообщение: ");
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Привет всем!";
            }

            List<INotifier> senders = new List<INotifier>();

            senders.Add(new EmailNotifier());
            senders.Add(new SmsNotifier());
            senders.Add(new TelegramNotifier());

            Console.WriteLine("\nНачинаем отправку сообщений:");

            foreach (INotifier sender in senders)
            {
                sender.Send(text);
            }
        }
    }
}
