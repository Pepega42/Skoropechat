using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using test;

class Program
{
    static void Main()
    {
        do
        {
            Console.Write("Как вас зовут: ");
            string UName = Console.ReadLine();
            Test.StartTest(UName);
            Console.WriteLine("Нажмите Enter, чтобы перезапустить тест");
        } while (Console.ReadKey().Key == ConsoleKey.Enter);
    }
}