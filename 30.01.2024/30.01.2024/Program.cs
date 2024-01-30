using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._01._2024
{
    internal class Program
    {
        public static int[] FindChairs(string[][] rooms, int missingChairs)
        {
            if (missingChairs == 0)
            {
                return new int[] { };
            }


            int[] takenChairs = new int[rooms.Length];

            for (int i = 0; i < rooms.Length; i++)
            {
                int freeChairs = rooms[i][0].Length - rooms[i][1];

                if (freeChairs > 0)
                {
                    int chairsToTake = Math.Min(missingChairs, freeChairs);
                    takenChairs[i] = chairsToTake;
                    missingChairs -= chairsToTake;

                    if (missingChairs == 0)
                    {
                        break;
                    }


                }
            }

            static void Main(string[] args)
            {
                string[][] rooms1 = new string[][]
                {
                new string[] { "XXX", "3" },
                new string[] { "XXXXX", "6" },
                new string[] { "XXXXXX", "9" },
                new string[] { "XXX", "2" }
                };

                string[][] rooms2 = new string[][]
                {
                new string[] { "XXXXXX", "9" },
                new string[] { "XXXXXX", "9" },
                new string[] { "XXXXXX", "9" }
                };

                int missingChairs2 = 18;
                int[] result2 = FindChairs(rooms2, missingChairs2);
                Console.WriteLine(string.Join(", ", result2));
            }
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
 
//namespace Project18012024
//{
//    internal class Program
//    {
//        public static void Main(string[] args)
//        {
//            List<object[]> test1 = new List<object[]> { new object[] { "XXX", 3 },
//                                                        new object[] { "XXXXX", 6 },
//                                                        new object[] { "XXXXXX", 9 } };

//            List<object[]> test2 = new List<object[]> { new object[] { "XXX", 1 },
//                                                        new object[] { "XXXXXX", 6 },
//                                                        new object[] { "X", 2 },
//                                                        new object[] { "XXXXXX", 8 },
//                                                        new object[] { "X", 3 },
//                                                        new object[] { "XXX", 1 } };

//            List<object[]> test3 = new List<object[]> { new object[] { "XX", 2 },
//                                                        new object[] { "XXXX", 6 },
//                                                        new object[] { "XXXXX", 4 } };

//            List<object[]> test4 = new List<object[]> { new object[] { "XX", 2 },
//                                                        new object[] { "XXXX", 6 },
//                                                        new object[] { "XXXXX", 4 } };

//            Console.WriteLine(Meeting(test1, 4)); // [0, 1, 3]
//            Console.WriteLine(Meeting(test2, 5)); // [0, 0, 1, 2, 2]
//            Console.WriteLine(Meeting(test3, 0)); // 'Game On'
//            Console.WriteLine(Meeting(test4, 4)); // 'Not enough!'
//        }
//        public static dynamic Meeting(List<object[]> rooms, int need)
//        {
//            if (need == 0)
//                return "Game On";

//            List<int> result = new List<int>();
//            foreach (var room in rooms)
//            {
//                string occupants = room[0] as string;
//                int maxChairs = Convert.ToInt32(room[1]);
//                int occupiedChairs = occupants.Count(c => c == 'X');
//                int availableChairs = Math.Max(0, maxChairs - occupiedChairs);

//                if (availableChairs >= need)
//                {
//                    result.Add(need);
//                    return result.ToArray();
//                }
//                else if (availableChairs > 0)
//                {
//                    result.Add(availableChairs);
//                    need -= availableChairs;
//                }
//            }

//            return "Not enough!";
//        }
//    }
//}