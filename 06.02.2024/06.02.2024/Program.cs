using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._02._2024
{
    public abstract class Tvarina
    {
        public string Imya { get; set; }

        public abstract string Zvuk { get; }
    }
    public class Sobaka : Tvarina
    {
        public override string Zvuk => "Gaw";
        public Sobaka(string imya)
        {
            Imya = imya;
        }
    }
    public class Kit : Tvarina
    {
        public override string Zvuk => "Maw";
        public Kit(string imya)
        {
            Imya = imya;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sobaka sobaka = new Sobaka("Bobik");
            Console.WriteLine(sobaka.Zvuk);

            Kit kit = new Kit("Snigok");
            Console.WriteLine(kit.Zvuk);
        }
    }

}






//Створіть базовий клас Фігура, який має властивість Площа. 
//Створіть два похідні класи: Квадрат і Коло. Реалізуйте метод розрахунку площі для кожного класу. 
//Використовуйте наслідування для спільного використання змінних та методів базового класу.

    //class Figura
    //{
    //    public double S {  get; set; }

//    //public Figura(double s)
//    //{
//    //    this.S = S;
//    //}
//}

//class Kvadrat : Figura
//{
//    public double side;

//    public Kvadrat(double side)
//    {
//        this.side = side;
//    }
//    public double S => side * side; 

//}

//class Kolo : Figura
//{
//    public double radius;

//    public Kolo(double radius)
//    {
//        this.radius = radius;
//    }
//    public double S => 3.14 * radius * radius;
//}



//internal class Program
//{
//    static void Main(string[] args)
//    {

//        Kvadrat kvadrat = new Kvadrat(5);
//        Console.WriteLine(kvadrat.S);

//        Kolo kolo = new Kolo(5);
//        Console.WriteLine(kolo.S);

//    }
//}