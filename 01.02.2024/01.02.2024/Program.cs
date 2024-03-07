using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._02._2024
{
    public class Garage
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public Garage(int id, int workerId)
        {
            Id = id;
            WorkerId = workerId;
        }
    }
    public class Service
    {
        public string Title { get; set; }
        public int Time { get; set; }
        public int Cost { get; set; }

        public Service(string title, int time, int cost)
        {
            Title = title;
            Time = time;
            Cost = cost;
        }
    }
    public class Client
    {
        public int Name { get; set; }
        public DateTime Date { get; set; }
        public Client(int name, int date)
        {
            Name = name;
            Date = date;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Garage> garages = new List<Garage>()
            {
                new Garage(1, 1),
                new Garage(2, 1),
                new Garage(3, 2),
                new Garage(4, 1),
            };

            List<Service> services = new List<Service>()
            {
                new Service("Oil change", 60, 500),
                new Service("change wheels ", 30, 400),
                new Service("Engine diagnostics", 120, 1000),
            };


            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the desired recording time (in the format YYYY-MM-DD HH:MM): ");
            DateTime desiredTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine(desiredTime);

        }
    }
}