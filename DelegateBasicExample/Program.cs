using System;
using System.IO;

namespace DelegateBasicExample
{
    class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            Log log = new Log();

            LogDel LogTextToScreenDel,LogTextToFileDel;
            LogTextToScreenDel = new LogDel(log.LogText);
            LogTextToFileDel = new LogDel(log.LogTextToFile);

            Console.WriteLine("Please enter your name:");
            var name = Console.ReadLine();

            LogDel multiLogDel = LogTextToFileDel + LogTextToScreenDel;
            LogText(multiLogDel, name);

        }
        //static void LogText(string text)
        //{
        //    Console.WriteLine($"{DateTime.Now}: {text}");
        //}
        //static void LogTextToFile(string text)
        //{
        //    using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
        //    {
        //        sw.WriteLine($"{DateTime.Now}: {text}");
        //    }
        //}
        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
        public class Log
        {
            public void LogText(string text)
            {
                Console.WriteLine($"{DateTime.Now}: {text}");
            }
            public void LogTextToFile(string text)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
                {
                    sw.WriteLine($"{DateTime.Now}: {text}");
                }
            }
        }
    }
}