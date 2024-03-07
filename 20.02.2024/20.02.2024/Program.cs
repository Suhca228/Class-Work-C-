using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Створіть інтерфейс "Тварина" (Animal), який містить методи "Голосити" та "Їсти". Створіть абстрактний клас "Ссавець" (Mammal), 
//який наслідується від інтерфейсу "Тварина" та містить властивість "Тип Харчування". Створіть клас "Собака" (Dog),
//який наслідується від "Ссавця" та має свою власну реалізацію методу "Гавкати". Створіть об'єкт класу "Собака", встановіть тип харчування та викличте всі методи.

namespace _20._02._2024
{
    internal class Program
    {
        interface IAnimal
        {
            void MakeSound();
            void Eat();
        }

        abstract class Mammal : IAnimal
        {
            public string Diet { get; set; }

            public abstract void MakeSound();

            public void Eat()
            {
                Console.WriteLine("A mammal eats.");
            }
        }
        class Dog : Mammal
        {
            public override void MakeSound()
            {
                Console.WriteLine("Hav!");
            }
        }


        static void Main(string[] args)
        {
            Dog dog = new Dog();

            dog.Diet = "Meat";

            dog.MakeSound();
            dog.Eat();
        }
    }
}