using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._03._2024
{
    public class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }

        public Album(string title, string artist, int year)
        {
            Title = title;
            Artist = artist;
            Year = year;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Artist: {Artist}, Year: {Year}";
        }
    }

    public class CollectionManager<T>
    {
        private List<T> _items = new List<T>();

        public void AddItem(T item)
        {
            _items.Add(item);
        }

        public void RemoveItem(T item)
        {
            _items.Remove(item);
        }

        public void DisplayItems()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose collection:");
                Console.WriteLine("1. Numbers");
                Console.WriteLine("2. Strings");
                Console.WriteLine("3. Music albums");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CollectionManager<int> intCollection = new CollectionManager<int>();
                        intCollection.AddItem(1);
                        intCollection.AddItem(2);
                        intCollection.AddItem(3);
                        intCollection.DisplayItems();
                        break;
                    case 2:
                        CollectionManager<string> stringCollection = new CollectionManager<string>();
                        stringCollection.AddItem("qwe");
                        stringCollection.AddItem("rty");
                        stringCollection.AddItem("uio");
                        stringCollection.DisplayItems();
                        break;
                    case 3:
                        CollectionManager<Album> albumCollection = new CollectionManager<Album>();
                        albumCollection.AddItem(new Album("Svit takij", "FLiT", 2003));
                        albumCollection.AddItem(new Album("Zalupa Rock", "Zlyj Reper Zenyk", 2012));
                        albumCollection.AddItem(new Album("System of a down", "System of a down", 1998));
                        albumCollection.DisplayItems();
                        break;
                }

                Console.WriteLine("=========================================================");
            }
        }
    }
}
