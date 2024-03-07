using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _04._03._2024.Program;

//Створіть узагальнений метод Swap, який обмінює значення двох змінних типу T.
//Використайте параметр типу для забезпечення гнучкості обміну різних типів даних.

using System;

namespace _04._03._2024
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 228;
            int b = 008 ;

            Console.WriteLine("Before a = " + a + ", b = " + b);

            Swap(ref a, ref b);

            Console.WriteLine("After a = " + a + ", b = " + b);

            string str1 = "321";
            string str2 = "123";

            Console.WriteLine("Before str1 = " + str1 + " " + str2 + " = " + str2);

            Swap(ref str1, ref str2);

            Console.WriteLine("After str1 = " + str1 + " " + str2 + " = " + str2);
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}