using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._02._2024
{
    public static class Algoritms
    {
        public static List<object> OpenArr(List<object> data)
        {
            List<object> result = new List<object>();

            foreach (var item in data)
            {
                if (item is List<object> list)
                {
                    result.AddRange(OpenArr(list));
                }
                else
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> myArr = new List<object> {
    6,
    44,
    23,
    new List<object> {
        53,
        new List<object> {
            22,
            32,
            67
        },
        12,
        new List<object> {
            4,
            6,
            2
        }
    }
};

            List<object> result = Algoritms.OpenArr(myArr);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }
    }
}


