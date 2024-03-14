using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._03._2024
{
    class Chair
    {
        public int Number { get; set; }
        public string Color { get; set; }
        public string OccupantName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Генерація списку стільців
            List<Chair> chairs = GenerateChairs();

            // Сортування стільців за порядковим номером
            chairs.Sort((x, y) => x.Number.CompareTo(y.Number));

            // Сортування за кольором, виключаючи червоні біля зелених
            chairs.Sort((x, y) =>
            {
                if (x.Color == "Red" && y.Color == "Green")
                    return 1;
                else if (x.Color == "Green" && y.Color == "Red")
                    return -1;
                else
                    return 0;
            });

            // Сортування за іменами, виключаючи Максима біля Івана
            chairs.Sort((x, y) =>
            {
                if (x.OccupantName == "Max" && y.OccupantName == "Ivan")
                    return 1;
                else if (x.OccupantName == "Ivan" && y.OccupantName == "Max")
                    return -1;
                else
                    return 0;
            });

            // Виведення відсортованих стільців
            Console.WriteLine("Sorted chairs:");
            foreach (var chair in chairs)
            {
                Console.WriteLine("Номер:" + chair.Number + ", Колір:" + chair.Color + ", Зайнятий:" + chair.OccupantName);
            }

            Console.ReadLine();
        }

        static List<Chair> GenerateChairs()
        {
            List<Chair> chairs = new List<Chair>();
            Random random = new Random();

            // Генерація 10 стільців з випадковими параметрами
            for (int i = 0; i < 10; i++)
            {
                Chair chair = new Chair();
                chair.Number = i + 1;
                chair.Color = GetRandomColor(random);
                chair.OccupantName = GetRandomName(random);
                chairs.Add(chair);
            }

            return chairs;
        }

        static string GetRandomColor(Random random)
        {
            string[] colors = { "Red", "Green", "Blue" };
            return colors[random.Next(colors.Length)];
        }

        static string GetRandomName(Random random)
        {
            string[] names = { "Max", "Ivan", "Sergiy" };
            return names[random.Next(names.Length)];
        }
    }
}