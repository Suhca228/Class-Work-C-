using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15._02._2024
{
using System;
    using System.Collections.Generic;

    public interface IBook
    {
        string name { get; }
        string Author { get; }
        int year { get; }
    }

    public class book1 : IBook
    {
        public string name => "Метро 2033(Subway 2033)";
        public string Author => "Дмитро Ґлуховський(Dmytro Glukhovskyi)";
        public int year => 2005;
    }

    public class book2 : IBook
    {
        public string name => "Моя боротьба(My struggle)";
        public string Author => "Адольф Гітлер(Adolf Hitler)";
        public int year => 1925;
    }

    public class book3 : IBook
    {
        public string name => "Пікнік на узбіччі(Picnic on the roadside)";
        public string Author => "Стругацькі Аркадій та Борис(Strugatsky Arkady and Boris)";
        public int year => 1980;
    }

    public interface ILibrary
    {
        void addbook(IBook book);
        void removebook(IBook book);
        IEnumerable<IBook> getlist();
    }

    public class Library : ILibrary
    {
        private readonly List<IBook> _books = new List<IBook>();

        public void addbook(IBook book)
        {
            _books.Add(book);
        }

        public void removebook(IBook book)
        {
            _books.Remove(book);
        }

        public IEnumerable<IBook> getlist()
        {
            return _books;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();

            library.addbook(new book1());
            library.addbook(new book2());
            library.addbook(new book3());

            Console.WriteLine("list books:");
            foreach (var book in library.getlist())
            {
                Console.WriteLine(book.name, book.Author, book.year);
            }

            Console.WriteLine();

            library.removebook(new book2());

            Console.WriteLine("list books after remove:");
            foreach (var book in library.getlist())
            {
                Console.WriteLine( book.name, book.Author, book.year);
            }
        }
    }
}
    //public interface IElectronicDevice
    //{
    //    void TurnOn();
    //    void TurnOff();
    //}

    //public class Television : IElectronicDevice
    //{
    //    public void TurnOn()
    //    {
    //        Console.WriteLine("Television turned on");
    //    }
    //    public void TurnOff()
    //    {
    //        Console.WriteLine("Television turned off");
    //    }
    //}
    //public class MobilePhone : IElectronicDevice
    //{
    //    public void TurnOn()
    //    {
    //        Console.WriteLine("Mobile phone turned on");
    //    }
    //    public void TurnOff()
    //    {
    //        Console.WriteLine("Mobile phone turned off");
    //    }
    //}
    //public class Laptop : IElectronicDevice
    //{
    //    public void TurnOn()
    //    {
    //        Console.WriteLine("Laptop turned on");
    //    }
    //    public void TurnOff()
    //    {
    //        Console.WriteLine("Laptop turned off");
    //    }
    //}
    //public class RemoteControl
    //{
    //    public void TurnOnDevice(IElectronicDevice device)
    //    {
    //        device.TurnOn();
    //    }
    //    public void TurnOffDevice(IElectronicDevice device)
    //    {
    //        device.TurnOff();
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        RemoteControl remote = new RemoteControl();

    //        Television tv = new Television();
    //        MobilePhone phone = new MobilePhone();
    //        Laptop laptop = new Laptop();

    //        remote.TurnOnDevice(tv);
    //        remote.TurnOnDevice(phone);
    //        remote.TurnOnDevice(laptop);

    //        Console.WriteLine();

    //        remote.TurnOffDevice(tv);
    //        remote.TurnOffDevice(phone);
    //        remote.TurnOffDevice(laptop);
    //    }
    //}
