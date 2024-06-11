
//Кравченко Володимир Олегович
//Завдання:
//Реалізувати систему для інтеграції старих систем з новими інтерфейсами.
//Використати Adapter для інтеграції старих систем.
//Використати Facade для спрощеного доступу до складної системи.
//Використати Observer для сповіщень про зміни у системі.
//Інструкції:
//Створити класи старих систем з їхніми інтерфейсами.
//Реалізувати клас Adapter, що дозволяє взаємодію старих систем з новими інтерфейсами.
//Створити клас SystemFacade для спрощеного доступу до функціоналу старих систем.
//Реалізувати механізм сповіщення про зміни у системі за допомогою Observer.





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._05._2024
{
    class Program
    {
        public interface IOldSystem
        {
            void OldOperation();
        }

        public interface INewSystem
        {
            void NewOperation();
        }

        public class OldSystem : IOldSystem
        {
            public void OldOperation()
            {
                Console.WriteLine("Old System Operation");
            }
        }

        public class Adapter : INewSystem
        {
            private readonly IOldSystem _oldSystem;

            public Adapter(IOldSystem oldSystem)
            {
                _oldSystem = oldSystem;
            }

            public void NewOperation()
            {
                _oldSystem.OldOperation();
            }
        }

        public class SystemFacade
        {
            private  INewSystem _newSystem;

            public SystemFacade(INewSystem newSystem)
            {
                _newSystem = newSystem;
            }

            public void FacadeOperation()
            {
                _newSystem.NewOperation();
            }
        }

        public class Observer
        {
            private List<INewSystem> _systems = new List<INewSystem>();

            public void Attach(INewSystem system)
            {
                _systems.Add(system);
            }

            public void Detach(INewSystem system)
            {
                _systems.Remove(system);
            }

            public void Notify()
            {
                foreach (var system in _systems)
                {
                    system.NewOperation();
                }
            }
        }

        static void Main(string[] args)
        {

            IOldSystem oldSystem = new OldSystem();
            INewSystem adaptedSystem = new Adapter(oldSystem);

            SystemFacade facade = new SystemFacade(adaptedSystem);

            facade.FacadeOperation();

            Observer observer = new Observer();
            observer.Attach(adaptedSystem);

            observer.Notify();
        }
    }
}




//internal class Program
//{

//    public class Hdmi
//    {
//        public string ConnectHdmi() => "Connect with Hdmi";
//    }

//    public class Vga
//    {
//        public string ConnectVga() => "Connect with Vga";
//    }

//    public class VgaToHdmiAdapter : Hdmi
//    {
//        private readonly Vga _vga;

//        public VgaToHdmiAdapter(Vga vga)
//        {
//            _vga = vga;
//        }

//        public string ConnectHdmi()
//        {
//            return _vga.ConnectVga();
//        }

//        Vga vga = new Vga();
//        VgaToHdmiAdapter adapter = new VgaToHdmiAdapter(vga);
//        Console.WriteLine(adapter.ConnectHdmi());