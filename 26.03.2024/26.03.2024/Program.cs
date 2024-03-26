using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public decimal Balance { get; set; }
    public UserStatus Status { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Country { get; set; }

    public User() { }

    public User(string name, string password, string email, int age, decimal balance, UserStatus status, DateTime dateOfBirth, string country)
    {
        Name = name;
        Password = password;
        Email = email;
        Age = age;
        Balance = balance;
        Status = status;
        DateOfBirth = dateOfBirth;
        Country = country;
    }
}

public enum UserStatus
{
    Active,
    Inactive,
    Blocked
}

public class Program
{
    private static readonly string _filePath = "users.xml";

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Create a new user");
            Console.WriteLine("2. Edit an existing user");
            Console.WriteLine("3. Display information of all users");
            Console.WriteLine("4. Display information by filter");
            Console.WriteLine("5. Delete a user");
            Console.WriteLine("0. Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateUser();
                    break;
                case 2:
                    EditUser();
                    break;
                case 3:
                    GetAllUsers();
                    break;
                case 4:
                    GetUsersByFilter();
                    break;
                case 5:
                    DeleteUser();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    private static void CreateUser()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter password: ");
        string password = Console.ReadLine();

        Console.WriteLine("Enter email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Enter age: ");
        int age;
        if (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.WriteLine("Invalid age! Please enter a valid positive number.");
            return;
        }

        Console.WriteLine("Enter balance: ");
        decimal balance;
        if (!decimal.TryParse(Console.ReadLine(), out balance) || balance < 0)
        {
            Console.WriteLine("Invalid balance! Please enter a valid positive number.");
            return;
        }

        Console.WriteLine("Enter status (Active, Inactive, Blocked): ");
        UserStatus status;
        if (!Enum.TryParse(Console.ReadLine(), true, out status))
        {
            Console.WriteLine("Invalid status! Please enter Active, Inactive, or Blocked.");
            return;
        }

        Console.WriteLine("Enter date of birth (yyyy-MM-dd): ");
        DateTime dateOfBirth;
        if (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
        {
            Console.WriteLine("Invalid date format! Please enter a valid date in yyyy-MM-dd format.");
            return;
        }

        Console.WriteLine("Enter country: ");
        string country = Console.ReadLine();

        var user = new User(name, password, email, age, balance, status, dateOfBirth, country);

        List<User> users = File.Exists(_filePath) ? DeserializeUsers() : new List<User>();

        users.Add(user);

        SerializeUsers(users);

        Console.WriteLine("User created successfully!");
    }

    private static void EditUser()
    {
        Console.WriteLine("Enter the name of the user you want to edit: ");
        string name = Console.ReadLine();

        List<User> users = DeserializeUsers();

        var user = users.Find(u => u.Name == name);

        if (user == null)
        {
            Console.WriteLine("User not found!");
            return;
        }

        Console.WriteLine("Enter new values (leave blank to keep unchanged):");

        Console.WriteLine("Password: ");
        string password = Console.ReadLine();
        if (!string.IsNullOrEmpty(password))
        {
            user.Password = password;
        }

        Console.WriteLine("Email: ");
        string email = Console.ReadLine();
        if (!string.IsNullOrEmpty(email))
        {
            user.Email = email;
        }

        Console.WriteLine("Age: ");
        string ageStr = Console.ReadLine();
        if (!string.IsNullOrEmpty(ageStr))
        {
            int age;
            if (int.TryParse(ageStr, out age) && age >= 0)
            {
                user.Age = age;
            }
            else
            {
                Console.WriteLine("Invalid age! Please enter a valid positive number.");
            }
        }

        Console.WriteLine("Balance: ");
        string balanceStr = Console.ReadLine();
        if (!string.IsNullOrEmpty(balanceStr))
        {
            decimal balance;
            if (decimal.TryParse(balanceStr, out balance) && balance >= 0)
            {
                user.Balance = balance;
            }
            else
            {
                Console.WriteLine("Invalid balance! Please enter a valid positive number.");
            }
        }

        Console.WriteLine("Status (Active, Inactive, Blocked): ");
        string statusStr = Console.ReadLine();
        if (!string.IsNullOrEmpty(statusStr))
        {
            UserStatus status;
            if (Enum.TryParse(statusStr, true, out status))
            {
                user.Status = status;
            }
            else
            {
                Console.WriteLine("Invalid status! Please enter Active, Inactive, or Blocked.");
            }
        }

        Console.WriteLine("Date of birth (yyyy-MM-dd): ");
        string dateOfBirthStr = Console.ReadLine();
        if (!string.IsNullOrEmpty(dateOfBirthStr))
        {
            DateTime dateOfBirth;
            if (DateTime.TryParse(dateOfBirthStr, out dateOfBirth))
            {
                user.DateOfBirth = dateOfBirth;
            }
            else
            {
                Console.WriteLine("Invalid date format! Please enter a valid date in yyyy-MM-dd format.");
            }
        }

        Console.WriteLine("Country: ");
        string country = Console.ReadLine();
        if (!string.IsNullOrEmpty(country))
        {
            user.Country = country;
        }

        SerializeUsers(users);

        Console.WriteLine("User updated successfully!");
    }

    private static void GetAllUsers()
    {
        List<User> users = DeserializeUsers();

        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }

    private static void GetUsersByFilter()
    {
        Console.WriteLine("Enter field for filtering (Name, Age, Status): ");
        string filterField = Console.ReadLine();

        Console.WriteLine("Enter value for filtering: ");
        string filterValue = Console.ReadLine();

        List<User> users = DeserializeUsers();

        var filteredUsers = users.FindAll(u =>
        {
            switch (filterField)
            {
                case "Name":
                    return u.Name.Contains(filterValue);
                case "Age":
                    return u.Age == int.Parse(filterValue);
                case "Status":
                    return u.Status.ToString().Equals(filterValue, StringComparison.OrdinalIgnoreCase);
                default:
                    return false;
            }
        });

        foreach (var user in filteredUsers)
        {
            Console.WriteLine(user);
        }
    }

    private static void DeleteUser()
    {

        Console.WriteLine("Enter the name of the user you want to delete: ");
        string name = Console.ReadLine();

        List<User> users = DeserializeUsers();

        var user = users.Find(u => u.Name == name);

        if (user == null)
        {
            Console.WriteLine("User not found!");
            return;
        }

        users.Remove(user);

        SerializeUsers(users);

        Console.WriteLine("User deleted successfully!");
    }

    private static List<User> DeserializeUsers()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

        try
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                return (List<User>)serializer.Deserialize(reader);
            }
        }
        catch (FileNotFoundException)
        {
            return new List<User>();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deserializing users:" + ex.Message);
            return new List<User>();
        }
    }

    private static void SerializeUsers(List<User> users)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

        try
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                serializer.Serialize(writer, users);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error serializing users: " + ex.Message);
        }
    }
}

