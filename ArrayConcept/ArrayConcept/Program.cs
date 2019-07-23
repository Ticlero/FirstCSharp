using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Console;
namespace ArrayConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            //print_01(); //배열을 가지고 평균내기
            //print_02(); //배열의 다양한 선언방법
            //print_03();
            //print_04(); //System.Array 관련 기능
            //print_05(); //2차원 배열
            //print_06();//3차원 배열
            //print_07() //가변배열
            //print_08(); //Collections - Hashtable
            //print_09(); //콜렉션 초기화
            //print_10(); //인덱서 - 객체를 마치 배열처럼 사용할 수 있게 만들어 주는 기능
            //print_11(); //foreach문으로 출력 가능하게 만들기_01
            print_12();//foreacg문으로 출력 가능하게 만들기 위한 IEnumerator, IEnumerable  - print_10()과 비교

        }

        static void print_01()
        {
            Score_Cal sc = new Score_Cal()
            {
                Score = new int[] { 90, 70, 60, 80, 50 }
            };
            sc.print_avg();
        }

        public static void print_02()
        {
            Score_Cal sc = new Score_Cal();
            Score_Cal sc2 = new Score_Cal();
            sc.hello = new string[] { "안녕", "반가워", "잘가" };
            sc2.hello = new string[3] { "hello", "nice to meet you", "bye bye~" };
            //string[] hello = { "", "", ""}; 가능

            foreach (string eles in sc.hello)
                Console.Write(eles + " ");

            Console.WriteLine("\n");

            foreach (string eles in sc2.hello)
                Console.Write(eles + " ");
        }

        public static void print_03()
        {
            int[] array = new int[] { 10, 30, 20, 7, 1 };
            Console.WriteLine(array.Length);
            Array.Sort(array);

            foreach (int eles in array)
                Console.WriteLine(eles + " ");
        }

        static void print_04()
        {
            Score_Cal sc = new Score_Cal()
            {
                Score = new int[] { 80, 74, 81, 90, 34 }
            };
            sc.print_score(sc.Score);
            Console.WriteLine("\n");

            Array.Sort(sc.Score); //정렬
            Array.ForEach<int>(sc.Score, new Action<int>(sc.Print)); //배열 요소 하나하나에 지정한 메소드 실행
            Console.WriteLine();

            Console.WriteLine("Binary Search : 81 is at {0}", Array.BinarySearch<int>(sc.Score, 81));
            Console.WriteLine("Binary Search : 90 is at {0}", Array.BinarySearch<int>(sc.Score, 90));
            //Console.WriteLine("Binary Search : 100 is at {0}", Array.BinarySearch<int>(sc.Score, 100));

            Console.WriteLine("Everyone Passed ? : {0}", Array.TrueForAll<int>(sc.Score, sc.CheckPassed)); //배열에 있는 모든 요소가 지정된 메소드를 통해 부합한지 확인

            Console.WriteLine($"Number of dimensions : {sc.Score.Rank}"); //1차원 배열 - 배열의 차원 확인

            int index = Array.FindIndex<int>(sc.Score, delegate (int scr)
            {
                if (scr < 60)
                    return true;
                else
                    return false;
            });

            sc.Score[index] = 61;

            Console.WriteLine("EveryOne Passed ? : {0}", Array.TrueForAll<int>(sc.Score, sc.CheckPassed));

            Console.WriteLine($"Old length of score : {sc.Score.GetLength(0)}");

            int[] arr = new int[5] { 80, 74, 81, 90, 34 };
            Array.Sort(arr);
            Array.Resize<int>(ref arr, 10);
            Console.WriteLine();
            Console.WriteLine($"New length of score : {arr.GetLength(0)}");
            Array.ForEach<int>(arr, sc.Print);
            Console.WriteLine();
            Array.Clear(arr, 2, 4);
            Array.ForEach<int>(arr, sc.Print);
            //Array.Resize<int>(ref sc.Score, 10);

        }

        static void print_05()
        {
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 2, 3, 4 } };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"[{i}],[{j}] : {arr[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int[,] arr2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write($"[{i}],[{j}] : {arr2[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("foreach");
            foreach (int eles in arr2)
            {
                Console.Write(eles + " ");
            }

        }

        static void print_06()
        {
            int[,,] arr = new int[,,]
            {
                { { 1, 2 }, { 3, 4 }, { 5, 6 } },
                { { 1, 4 }, { 2, 5 },{ 3, 6 } },
                { { 6, 5 }, { 4, 3 }, { 2, 1 } },
                { { 6, 3 }, { 5, 2 }, { 4, 1 } }
            };

            for(int i=0; i<arr.GetLength(2); i++)
            {
                for(int j=0; j<arr.GetLength(0); j++)
                {
                    for(int k = 0; k<arr.GetLength(1); k++)
                    {
                        Console.Write($"arr[{j},{k},{i}]: {arr[j, k, i]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }

        static void print_07()
        {
            //가변 배열- 데이터형[][] 배열이름 = new 데이터형[용량][];
            int[][] jagged = new int[3][];
            jagged[0] = new int[5] { 1, 2, 3, 4, 5 };
            jagged[1] = new int[] { 10, 20, 30 };
            jagged[2] = new int[] { 10, 20 };

            //선언과 동시에 초기화
            int[][] jagged2 = new int[2][]
            {
                new int[] {100,200,300},
                new int[4] {6,7,8,9}
            };

        }

        static void print_08()
        {
            Hashtable ht = new Hashtable();
            ht["하나"] = "one";
            ht["둘"] = 2;
            ht["셋"] = "three";
            ht["넷"] = "four";
            ht["다섯"] = 5;

            WriteLine(ht["하나"]);
            WriteLine(ht["둘"]);
            WriteLine(ht["셋"]);
            WriteLine(ht["넷"]);
            WriteLine(ht["다섯"]);
        }

        static void print_09()
        {
            int[] arr = { 123, 456, 789 };

            //stack queue arraylist
            Stack stack = new Stack(arr);
            Queue queue = new Queue(arr);
            ArrayList arraylist = new ArrayList(arr);

            ArrayList arraylist2 = new ArrayList() { 123, 456, 789 };


            WriteLine("ArrayList Foreach");
            foreach (int eles in arraylist)
            {
                WriteLine($"arraylist_01: {eles}");
            }


            WriteLine("\nStack Foreach");
            foreach(var eles in stack)
            {
                WriteLine($"Stack_01: {eles}");
            }

            WriteLine("\nQueue Foreach");
            foreach (var eles in queue)
            {
                WriteLine($"Queue_01: {eles}");
            }


            //hashtable
            Hashtable ht = new Hashtable()
            {
                ["one"] = 1,
                ["two"] = 2,
                ["three"] = 3,
                ["four"] = 4
            };

            WriteLine("\nhashtable Foreach");
            
            foreach (var eles in ht)
            {
                WriteLine(eles);
            }
        }

        static void print_10()
        {
            Indexer indexer = new Indexer();

            for (int i =0; i<5; i++)
            {
                indexer[i] = i;
            }

            for(int i = 0; i<indexer.Length; i++)
            {
                WriteLine(indexer[i]);
            }
        }

        static void print_11()
        {
            var obj = new MyEnumerator();
            foreach(var i in obj)
            {
                WriteLine(i);
            }
        }

        static void print_12()
        {
            Indexer2 index = new Indexer2();
            for(int i=0; i<5; i++)
            {
                index[i] = i;
            }

            foreach (int eles in index)
            {
                WriteLine(eles);
            }
        }
    }
}
