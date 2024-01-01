using System;

namespace DelegateBasicExample
{
    class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            LogText("pass text");

        }
        static void LogText(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
    }
}