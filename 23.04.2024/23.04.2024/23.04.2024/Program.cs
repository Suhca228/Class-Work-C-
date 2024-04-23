
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._04._2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>(); // змініть тип колекції за потреби

            // Заповнення колекції даними через консоль
            Console.WriteLine("Введіть елементи колекції (для завершення введіть 'done'):");
            string input;
            while ((input = Console.ReadLine()) != "done")
            {
                if (int.TryParse(input, out int number))
                    collection.Add(number);
                else
                    Console.WriteLine("Невірний формат числа, спробуйте ще раз.");
            }

            // Меню операцій
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nОберіть операцію:");
                Console.WriteLine("1. Фільтрація");
                Console.WriteLine("2. Сортування");
                Console.WriteLine("3. Групування");
                Console.WriteLine("4. Преобразування");
                Console.WriteLine("5. Агрегація");
                Console.WriteLine("6. Вийти");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            // Виконання фільтрації
                            Console.WriteLine("Введіть умову фільтрації:");
                            int filterCondition = int.Parse(Console.ReadLine());
                            var filteredCollection = collection.Where(item => item > filterCondition); // змініть умову за потреби
                            Console.WriteLine("Результати фільтрації:");
                            foreach (var item in filteredCollection)
                                Console.WriteLine(item);
                            break;
                        case 2:
                            // Виконання сортування
                            Console.WriteLine("Сортування за зростанням або спаданням? (asc/desc)");
                            string sortOrder = Console.ReadLine();
                            var sortedCollection = sortOrder.ToLower() == "asc" ?
                                collection.OrderBy(item => item) :
                                collection.OrderByDescending(item => item);
                            Console.WriteLine("Результати сортування:");
                            foreach (var item in sortedCollection)
                                Console.WriteLine(item);
                            break;
                        case 3:
                            // Виконання групування
                            var groupedCollection = collection.GroupBy(item => item % 2 == 0 ? "Парні" : "Непарні");
                            Console.WriteLine("Результати групування:");
                            foreach (var group in groupedCollection)
                            {
                                Console.WriteLine(group.Key + ":");
                                foreach (var item in group)
                                    Console.WriteLine(item);
                            }
                            break;
                        case 4:
                            // Виконання преобразування
                            var transformedCollection = collection.Select(item => item * 2); // змініть логіку преобразування за потреби
                            Console.WriteLine("Результати преобразування:");
                            foreach (var item in transformedCollection)
                                Console.WriteLine(item);
                            break;
                        case 5:
                            // Виконання агрегації
                            int sum = collection.Sum();
                            Console.WriteLine("Сума елементів колекції: " + sum);
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Невірний вибір опції. Спробуйте ще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Невірний ввід. Спробуйте ще раз.");
                }
            }
        }
    }
}
