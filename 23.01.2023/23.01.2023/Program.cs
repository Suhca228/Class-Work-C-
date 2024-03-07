using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._01._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.WriteLine(i);

            i = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine(i);

            string[] arr = new string[i];

            for (int j = 0; j < i; j++)
                arr[j] = Console.ReadLine();


            for (int q = 0; q < 5; q++)
                Console.WriteLine(arr[q]);





        }
    }
}
 

//+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-

//int i;

//int[] one = new int[5];
//int[] two = new int[5];
//int[] three = new int[5];

//for (i = 0; i < 5; i++)
//    one[i] = i;

//for (i = 0; i < 5; i++)
//    Console.WriteLine(one[i]);

//Console.WriteLine();

//for (i = 0; i < 5; i++)
//    two[i] = i;


//for (i = 0; i < 5; i++)
//    Console.WriteLine(two[i]);


//for (i = 0; i < 5; i++)
//    three[i] = one[i] + two[i];

//Console.WriteLine();

//for (i = 0; i < 5; i++)
//    Console.WriteLine(three[i]);
