using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Test
    {
        private static readonly List<string> TestTexts = new List<string>
        {
            "Сворачивание НЭПа и введение полного контроля за экономикой через план. С 1929 года государство определяло не только что производить, но и в каком количестве.",
            "В ней закреплялись демократические элементы, например выборы, а по факту страна была тоталитарной.",
            "Сталин считал, что может позволить себе уничтожить миллионы людей, чтобы достичь цели: коммунизма.",
            "То же самое касается депортации целых народов.",
        
        };

        private static Stopwatch stopwatch = new Stopwatch();
        private static int users = 0;
        private static bool testCompleted = false;

        private static string GetRandomTestText()
        {
            Random random = new Random();
            int index = random.Next(TestTexts.Count);
            return TestTexts[index];
        }

        public static void StartTest(string userName)
        {
            Console.Clear();
            Console.WriteLine(" Нажмите клавишу Enter, чтобы начать тест.");
            Console.ReadLine();

            Console.Clear();
            string testText = GetRandomTestText();
            Console.WriteLine("Введите текст:");
            Console.WriteLine(testText.PadRight(Console.WindowWidth - 1));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            stopwatch.Start();

            Thread timerThread = new Thread(() =>
            {
                Thread.Sleep(60 * 1000); 
                testCompleted = true;
            });

            timerThread.Start();

            while (!testCompleted)
            {
                var keyInfo = Console.ReadKey(true);

                if (!testCompleted && users < testText.Length && keyInfo.KeyChar == testText[users])
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(keyInfo.KeyChar);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    users++;
                }
            }

            stopwatch.Stop();
            timerThread.Join(); 

            double Seconds = stopwatch.Elapsed.TotalSeconds;
            double Second1 = users / Seconds;
            double Minutes = users / (Second1 / 60);

            var user = new Usr
            {
                Name = userName,
                Seconds = (int)Second1,
                Minutes = (int)Minutes
            };

            Statistics.AddStatistics(user);

            Console.WriteLine("Стоп! Время вышло");
            Statistics.Stisticboards();
        }
    }
}
