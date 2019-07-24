using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Delegate_Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            //print_01();//대리자 delegate
            //print_02();//대리자를 이용한 오름차순 내림차순
            //print_03();//generic 대리자(일반화)
            //print_04(); //대리자 체인 방법
            //print_05(); //대리자 체인을 이용한 예제
            //print_06(); //익명 메소드
            print_07();
        }

        static void print_01()
        {
            MyDelegate calc = new MyDelegate();
            Callback_dele Callback;

            Callback = new Callback_dele(calc.Plus);
            Console.WriteLine(Callback(3, 4));

            Callback = new Callback_dele(calc.Minus);
            Console.WriteLine(Callback(7, 5));
        }

        static void print_02()
        {
            int[] arr = { 8, 5, 3, 6, 2, 1, 10 };
            MyDelegate md = new MyDelegate();

            md.BubbleSort(arr, new Compare(md.AscendCompare));

            Console.WriteLine("오름차순");
            foreach (int eles in arr)
            {
                Console.Write(eles + " ");
            }

            int[] arr2 = { 8, 5, 3, 6, 2, 1, 10, 1 };
            Console.WriteLine("내림차순");
            md.BubbleSort(arr2, new Compare(md.DescendCompare));
            foreach (int eles in arr2)
            {
                Console.Write(eles + " ");
            }
            Console.WriteLine(3.CompareTo(4));
        }

        static void print_03()
        {
            int[] arr = { 3, 4, 5, 6, 1, 23, 54, 100, 124, 7 };
            string[] arr2 = { "mbc", "kbs", "jtbc", "kbs2", "sbs", "twitch" };

            Console.WriteLine("오름차순 1");
            BubbleS(arr, new GCompare<int>(AscendCom));
            foreach (int eles in arr)
            {
                Console.Write(eles + " ");
            }
            Console.WriteLine("\n내림차순 1");
            BubbleS(arr, new GCompare<int>(DescendCom));
            foreach (int eles in arr)
            {
                Console.Write(eles + " ");
            }


            Console.WriteLine("\n오름차순 2");
            BubbleS(arr2, new GCompare<string>(AscendCom));
            foreach (string eles in arr2)
            {
                Console.Write(eles + " ");
            }

            Console.WriteLine("\n내림차순 2");
            BubbleS(arr2, new GCompare<string>(DescendCom));
            foreach (string eles in arr2)
            {
                Console.Write(eles + " ");
            }
            Console.WriteLine();
        }

        static void print_04()
        {
            ThereIsFire fire;
            fire = new ThereIsFire(MyDelegate.Call119);
            fire += new ThereIsFire(MyDelegate.ShotOut);
            fire += new ThereIsFire(MyDelegate.Escape);

            ThereIsFire fire2 =
                (ThereIsFire)Delegate.Combine
                (
                new ThereIsFire(MyDelegate.Call119),
                new ThereIsFire(MyDelegate.ShotOut),
                new ThereIsFire(MyDelegate.Escape)
                );

            ThereIsFire fire3;
            fire3 = MyDelegate.Call119;
            fire3 += MyDelegate.ShotOut;
            fire3 += MyDelegate.Escape;

            fire("반대편");
            fire2("일본");
            fire3("중국");
        }

        static void print_05()
        {
            Notifier notifier = new Notifier();
            EventListener eventListener01 = new EventListener()
            {
                Name = "Listener01"
            };
            EventListener eventListener02 = new EventListener()
            {
                Name = "Listener02"
            };
            EventListener eventListener03 = new EventListener()
            {
                Name = "Listener03"
            };

            notifier.notifier += eventListener01.SomethingHappend;
            notifier.notifier += eventListener02.SomethingHappend;
            notifier.notifier += eventListener03.SomethingHappend;
            notifier.notifier("You've got mail");

            Console.WriteLine();
            notifier.notifier -= eventListener02.SomethingHappend;
            notifier.notifier("Download Complete");

            Console.WriteLine();
            notifier.notifier = new Notify(eventListener02.SomethingHappend);
            notifier.notifier += new Notify(eventListener03.SomethingHappend);
            notifier.notifier("Nuclear launch detected");

            Console.WriteLine();
            notifier.notifier = (Notify)Delegate.Combine(
                new Notify(eventListener01.SomethingHappend),
                new Notify(eventListener02.SomethingHappend)
                );

            notifier.notifier("Fire!!");

            Console.WriteLine();
            notifier.notifier = (Notify)Delegate.Remove(notifier.notifier, new Notify(eventListener02.SomethingHappend));
            notifier.notifier("RPG!");
        }

        static void print_06()
        {
            int[] arr = { 5, 8, 10, 4, 7, 2, 1 };
            MyDelegate md = new MyDelegate();
            md.BubbleSort_2(arr, delegate (int a, int b)
            {
                return a.CompareTo(b);
            });

            foreach (int eles in arr)
            {
                Console.Write(eles + " ");
            }
        }

        static void print_07()
        {
            Event_Concept ec = new Event_Concept();
            ec.eventhandler += new EventHandler(MyEvent);

            EventHandler eh = new EventHandler(MyEvent);
            EventHandler eh2 = new EventHandler(delegate (string msg)
            {
                if(msg =="30")
                {
                    Console.WriteLine("축하합니다!! {0}번째 고객 이벤트에 당첨되셨습니다.", msg);
                }
            });
            eh("123");
            eh2("30");

            for(int i=0;i < 30; i++)
            {
                ec.DoSomething(i);
            }
        }

        public static void MyEvent(string msg)
        {
            Console.WriteLine(msg);
        }

        static int AscendCom<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b);
        }
        static int DescendCom<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) * -1;
        }

        static void BubbleS<T>(T[] arr, GCompare<T> compare)
        {
            int i = 0;
            int j = 0;
            T temp;
            for (i = 0; i < arr.Length; i++)
            {
                for (j = (i >= arr.Length ? i + 1 : i); j < arr.Length; j++)
                {
                    if (compare(arr[i], arr[j]) > 0)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }


    }
}
