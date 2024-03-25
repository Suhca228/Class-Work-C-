using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace _25._03._2024
{
    public class Client
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        private int Id { get; set; }

        public Client() { }

        public Client(string fullName, int age, string phoneNumber)
        {
            FullName = fullName;
            Age = age;
            PhoneNumber = phoneNumber;
            GenerateId();
        }

        private void GenerateId()
        {
            Random random = new Random();
            Id = random.Next(1000, 10000);
        }

        public int GetId()
        {
            return Id;
        }
    }

    public class Program
    {
        private static readonly string XmlFilePath = "clients.xml";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Chose:");
                Console.WriteLine("1) Add new client");
                Console.WriteLine("2) Edit client data");
                Console.WriteLine("3) View customer data");
                Console.WriteLine("0) Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddClient();
                        break;
                    case 2:
                        EditClient();
                        break;
                    case 3:
                        ListClients();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
            }
        }

        private static void AddClient()
        {
            Console.WriteLine("Enter the customer's name:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter the customer's age:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the customer's phone number:");
            string phoneNumber = Console.ReadLine();

            var client = new Client(fullName, age, phoneNumber);

            var clients = GetClients();
            clients.Add(client);

            SaveClients(clients);

            Console.WriteLine("Client successfully added!");
        }

        private static void EditClient()
        {
            Console.WriteLine("Enter the ID of the client whose data you want to edit:");
            int id = int.Parse(Console.ReadLine());

            var clients = GetClients();
            var client = clients.Find(c => c.Id == id);

            if (client == null)
            {
                Console.WriteLine("The client with this ID was not found!");
                return;
            }

            Console.WriteLine("Enter the new client's PIN:");
            string newFullName = Console.ReadLine();

            Console.WriteLine("Enter new customer age (or 0 to leave no change):");
            int newAge = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the customer's new phone number:");
            string newPhoneNumber = Console.ReadLine();

            if (!string.IsNullOrEmpty(newFullName))
                client.FullName = newFullName;

            if (newAge > 0)
                client.Age = newAge;

            if (!string.IsNullOrEmpty(newPhoneNumber))
                client.PhoneNumber = newPhoneNumber;

            SaveClients(clients);

            Console.WriteLine("Customer data successfully updated!");
        }

        private static void ListClients()
        {
            var clients = GetClients();

            foreach (var client in clients)
            {
                Console.WriteLine("ID:" + client.Id);
                Console.WriteLine("Full name:" + client.FullName);
                Console.WriteLine("age:" + client.Age);
                Console.WriteLine("Phone number:" + client.PhoneNumber);
                Console.WriteLine();
            }
        }

        private static List<Client> GetClients()
        {
            List<Client> clients;

            if (File.Exists(XmlFilePath))
            {
                using (var stream = File.OpenRead(XmlFilePath))
                {
                    var serializer = new XmlSerializer(typeof(List<Client>));
                    clients = (List<Client>)serializer.Deserialize(stream);
                }
            }
            else
            {
                clients = new List<Client>();
            }

            return clients;
        }

        private static void SaveClients(List<Client> clients)
        {
            using (var stream = File.Create(XmlFilePath))
            {
                var serializer = new XmlSerializer(typeof(List<Client>));
                serializer.Serialize(stream, clients);
            }
        }
    }
}
