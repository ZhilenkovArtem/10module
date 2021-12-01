using System;

namespace _1and2Task
{
    class Program
    {
        static ILogger Logger { get; set; }
        static void Main()
        {
            Logger logger = new Logger();
            ISummator summator = new Summator(logger);
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите два числа:");
                    
                    summator.Sum(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                }
                catch
                {
                    logger.Error("Числа введены неверное. Попробуйте еще раз.");
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }
    }
    public interface ISummator
    {
        int Sum(int a, int b);
    }
    public class Summator : ISummator
    {
        public ILogger Logger { get; }
        public Summator(ILogger logger)
        {
            Logger = logger;
        }
        public int Sum(int a, int b)
        {
            var c = a + b;
            this.Logger.Event($"Записаны числа {a} и {b}. Получен результат {c}.");
            return c;
        }
    }
    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }
    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
