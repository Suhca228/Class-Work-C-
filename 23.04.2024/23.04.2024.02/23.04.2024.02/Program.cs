using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

//Розробіть консольний додаток на мові C# з використанням принципів об'єктно-орієнтованого програмування (ООП).
//Додаток буде моделювати систему інвентаризації та керування персонажем в рольовій грі. Виконайте наступні завдання:

//Класи:
//Створіть клас Персонаж, який містить такі поля: імена, рівень, здоров'я, сила, спритність, інтелект, інвентар (список об'єктів класу Предмет).
//Створіть клас Предмет, який містить такі поля: назва, тип (наприклад, зброя, броня, зілля тощо), вартість, вага.
//Створіть клас Гра, який містить такі поля: список персонажів, список предметів.

//Функціональність:
//Реалізуйте можливість створення нового персонажа з заданими характеристиками.
//Реалізуйте можливість видалення персонажа.
//Реалізуйте можливість додавання нових предметів до інвентаря персонажа.
//Реалізуйте можливість видалення предметів з інвентаря персонажа.
//Реалізуйте можливість зміни рівня персонажа, його здоров'я, сили, спритності та інтелекту.
//Реалізуйте можливість відображення всіх предметів в інвентарі персонажа.
//Реалізуйте можливість збереження даних про персонажів і предмети в інвентарі у форматі JSON або XML.

//Інтерфейс користувача:
//Забезпечте зручний консольний інтерфейс для взаємодії з системою.
//Реалізуйте функції пошуку персонажа за ім'ям.
//Реалізуйте функції додавання, видалення та зміни предметів в інвентарі персонажа.
//Реалізуйте функції відображення характеристик персонажа та його інвентаря.


namespace _23._04._2024._02
{
    [Serializable]
    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public int Weight { get; set; }

        public Item() { }

        public Item(string name, string type, int value, int weight)
        {
            Name = name;
            Type = type;
            Value = value;
            Weight = weight;
        }
    }

    [Serializable]
    public class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public List<Item> Inventory { get; set; }

        public Character() { }

        public Character(string name, int level, int health, int strength, int agility, int intelligence)
        {
            Name = name;
            Level = level;
            Health = health;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Inventory = new List<Item>();
        }
    }

    [Serializable]
    public class Game
    {
        public List<Character> Characters { get; set; }
        public List<Item> Items { get; set; }

        public Game()
        {
            Characters = new List<Character>();
            Items = new List<Item>();
        }

        public void SaveToXml(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static Game LoadFromXml(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            using (TextReader reader = new StreamReader(filename))
            {
                return (Game)serializer.Deserialize(reader);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while (true)
            {
                Console.WriteLine("1. Create Character");
                Console.WriteLine("2. Delete Character");
                Console.WriteLine("3. Save Game");
                Console.WriteLine("4. Load Game");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateCharacter(game);
                        break;
                    case "2":
                        // Implement delete character functionality
                        break;
                    case "3":
                        SaveGame(game);
                        break;
                    case "4":
                        LoadGame(ref game);
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateCharacter(Game game)
        {
            Console.Write("Enter character name: ");
            string name = Console.ReadLine();
            Console.Write("Enter character level: ");
            int level = int.Parse(Console.ReadLine());
            Console.Write("Enter character health: ");
            int health = int.Parse(Console.ReadLine());
            Console.Write("Enter character strength: ");
            int strength = int.Parse(Console.ReadLine());
            Console.Write("Enter character agility: ");
            int agility = int.Parse(Console.ReadLine());
            Console.Write("Enter character intelligence: ");
            int intelligence = int.Parse(Console.ReadLine());

            Character character = new Character(name, level, health, strength, agility, intelligence);
            game.Characters.Add(character);
            Console.WriteLine("Character created successfully!");
        }

        static void SaveGame(Game game)
        {
            Console.Write("Enter filename to save: ");
            string filename = Console.ReadLine();
            game.SaveToXml(filename);
            Console.WriteLine("Game saved successfully!");
        }

        static void LoadGame(ref Game game)
        {
            Console.Write("Enter filename to load: ");
            string filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                game = Game.LoadFromXml(filename);
                Console.WriteLine("Game loaded successfully!");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
