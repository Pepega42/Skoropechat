using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public static class Statistics
    {
        private const string FileName = "fiel.json";
        private static List<Usr> static1 = new List<Usr>();
        static Statistics()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                static1 = JsonConvert.DeserializeObject<List<Usr>>(json);
            }
        }
        public static void AddStatistics(Usr userData)
        {
            static1.Add(userData);
            SaveStatistics();
        }
        public static void Stisticboards()
        {
            Console.WriteLine("Статистика:");
            Console.WriteLine("Имя    слов в минуту   слов в секунду");

            foreach (var user in static1.OrderByDescending(s => s.Minutes))
            {
                Console.WriteLine($"{user.Minutes} {user.Seconds} {user.Name}");
            }
        }
        private static void SaveStatistics()
        {
            var json = JsonConvert.SerializeObject(static1, Formatting.Indented);
            File.WriteAllText(FileName, json);
        }
    }
}
